using InsuranceProject.Data;
using InsuranceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceProject.Services
{
    public class ClaimService : IClaimService
    {
        private readonly InsuranceDbContext _context;

        public ClaimService(InsuranceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Claim>> GetAllClaimsAsync()
        {
            return await _context.Claims
                .Include(c => c.Customer)
                .Include(c => c.Policy)
                .ToListAsync();
        }

        public async Task<Claim?> GetClaimByIdAsync(int id)
        {
            return await _context.Claims
                .Include(c => c.Customer)
                .Include(c => c.Policy)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Claim>> GetClaimsByCustomerIdAsync(int customerId)
        {
            return await _context.Claims
                .Include(c => c.Policy)
                .Where(c => c.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<Claim> CreateClaimAsync(Claim claim)
        {
            // Generate claim number
            claim.ClaimNumber = GenerateClaimNumber();
            claim.SubmittedDate = DateTime.UtcNow;
            
            _context.Claims.Add(claim);
            await _context.SaveChangesAsync();
            return claim;
        }

        public async Task<Claim?> UpdateClaimAsync(int id, Claim claim)
        {
            var existingClaim = await _context.Claims.FindAsync(id);
            if (existingClaim == null)
                return null;

            existingClaim.Status = claim.Status;
            existingClaim.Amount = claim.Amount;
            existingClaim.Description = claim.Description;
            existingClaim.AdjusterNotes = claim.AdjusterNotes;
            
            if (claim.Status == ClaimStatus.Approved || claim.Status == ClaimStatus.Rejected)
            {
                existingClaim.ProcessedDate = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
            return existingClaim;
        }

        public async Task<bool> DeleteClaimAsync(int id)
        {
            var claim = await _context.Claims.FindAsync(id);
            if (claim == null)
                return false;

            _context.Claims.Remove(claim);
            await _context.SaveChangesAsync();
            return true;
        }

        private string GenerateClaimNumber()
        {
            var year = DateTime.Now.Year;
            var random = new Random().Next(10000, 99999);
            return $"CL-{year}-{random}";
        }
    }
}