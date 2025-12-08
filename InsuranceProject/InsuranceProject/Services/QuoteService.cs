using InsuranceProject.Data;
using InsuranceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceProject.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly InsuranceDbContext _context;

        public QuoteService(InsuranceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Quote>> GetAllQuotesAsync()
        {
            return await _context.Quotes
                .Include(q => q.Customer)
                .ToListAsync();
        }

        public async Task<Quote?> GetQuoteByIdAsync(int id)
        {
            return await _context.Quotes
                .Include(q => q.Customer)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<IEnumerable<Quote>> GetQuotesByCustomerIdAsync(int customerId)
        {
            return await _context.Quotes
                .Where(q => q.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<Quote> CreateQuoteAsync(Quote quote)
        {
            // Generate quote number
            quote.QuoteNumber = GenerateQuoteNumber();
            quote.CreatedDate = DateTime.UtcNow;
            quote.ValidUntil = DateTime.UtcNow.AddDays(30); // Quote valid for 30 days
            
            _context.Quotes.Add(quote);
            await _context.SaveChangesAsync();
            return quote;
        }

        public async Task<Quote?> UpdateQuoteAsync(int id, Quote quote)
        {
            var existingQuote = await _context.Quotes.FindAsync(id);
            if (existingQuote == null)
                return null;

            existingQuote.Status = quote.Status;
            existingQuote.EstimatedPremium = quote.EstimatedPremium;
            existingQuote.CoverageAmount = quote.CoverageAmount;
            existingQuote.Notes = quote.Notes;

            await _context.SaveChangesAsync();
            return existingQuote;
        }

        public async Task<bool> DeleteQuoteAsync(int id)
        {
            var quote = await _context.Quotes.FindAsync(id);
            if (quote == null)
                return false;

            _context.Quotes.Remove(quote);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<decimal> CalculatePremiumAsync(PolicyType policyType, decimal coverageAmount, Customer customer)
        {
            // Simple premium calculation logic
            decimal basePremium = policyType switch
            {
                PolicyType.Auto => coverageAmount * 0.02m,
                PolicyType.Home => coverageAmount * 0.003m,
                PolicyType.Life => coverageAmount * 0.005m,
                PolicyType.Health => coverageAmount * 0.02m,
                PolicyType.Travel => coverageAmount * 0.03m,
                PolicyType.Business => coverageAmount * 0.004m,
                _ => coverageAmount * 0.01m
            };

            // Age factor for certain policies
            if (policyType == PolicyType.Auto || policyType == PolicyType.Life)
            {
                var age = DateTime.Now.Year - customer.DateOfBirth.Year;
                if (age < 25) basePremium *= 1.2m; // Higher premium for younger drivers/life insurance
                else if (age > 65) basePremium *= 1.1m; // Slightly higher for older drivers
            }

            return Math.Round(basePremium, 2);
        }

        private string GenerateQuoteNumber()
        {
            var year = DateTime.Now.Year;
            var random = new Random().Next(10000, 99999);
            return $"QT-{year}-{random}";
        }
    }
}