using InsuranceProject.Data;
using InsuranceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceProject.Services
{
    public class PolicyService : IPolicyService
    {
        private readonly InsuranceDbContext _context;

        public PolicyService(InsuranceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Policy>> GetAllPoliciesAsync()
        {
            return await _context.Policies
                .Include(p => p.Customer)
                .Include(p => p.Claims)
                .ToListAsync();
        }

        public async Task<Policy?> GetPolicyByIdAsync(int id)
        {
            return await _context.Policies
                .Include(p => p.Customer)
                .Include(p => p.Claims)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Policy>> GetPoliciesByCustomerIdAsync(int customerId)
        {
            return await _context.Policies
                .Include(p => p.Claims)
                .Where(p => p.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<Policy> CreatePolicyAsync(Policy policy)
        {
            // Generate policy number
            policy.PolicyNumber = GeneratePolicyNumber(policy.Type);
            
            _context.Policies.Add(policy);
            await _context.SaveChangesAsync();
            return policy;
        }

        public async Task<Policy?> UpdatePolicyAsync(int id, Policy policy)
        {
            var existingPolicy = await _context.Policies.FindAsync(id);
            if (existingPolicy == null)
                return null;

            existingPolicy.Status = policy.Status;
            existingPolicy.Premium = policy.Premium;
            existingPolicy.CoverageAmount = policy.CoverageAmount;
            existingPolicy.StartDate = policy.StartDate;
            existingPolicy.EndDate = policy.EndDate;
            existingPolicy.Description = policy.Description;

            await _context.SaveChangesAsync();
            return existingPolicy;
        }

        public async Task<bool> DeletePolicyAsync(int id)
        {
            var policy = await _context.Policies.FindAsync(id);
            if (policy == null)
                return false;

            _context.Policies.Remove(policy);
            await _context.SaveChangesAsync();
            return true;
        }

        private string GeneratePolicyNumber(PolicyType type)
        {
            var prefix = type.ToString().ToUpper();
            var year = DateTime.Now.Year;
            var random = new Random().Next(1000, 9999);
            return $"{prefix}-{year}-{random}";
        }
    }
}