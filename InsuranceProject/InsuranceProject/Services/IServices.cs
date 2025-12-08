using InsuranceProject.Models;

namespace InsuranceProject.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<Customer?> UpdateCustomerAsync(int id, Customer customer);
        Task<bool> DeleteCustomerAsync(int id);
        Task<Customer?> GetCustomerByEmailAsync(string email);
    }

    public interface IPolicyService
    {
        Task<IEnumerable<Policy>> GetAllPoliciesAsync();
        Task<Policy?> GetPolicyByIdAsync(int id);
        Task<IEnumerable<Policy>> GetPoliciesByCustomerIdAsync(int customerId);
        Task<Policy> CreatePolicyAsync(Policy policy);
        Task<Policy?> UpdatePolicyAsync(int id, Policy policy);
        Task<bool> DeletePolicyAsync(int id);
    }

    public interface IClaimService
    {
        Task<IEnumerable<Claim>> GetAllClaimsAsync();
        Task<Claim?> GetClaimByIdAsync(int id);
        Task<IEnumerable<Claim>> GetClaimsByCustomerIdAsync(int customerId);
        Task<Claim> CreateClaimAsync(Claim claim);
        Task<Claim?> UpdateClaimAsync(int id, Claim claim);
        Task<bool> DeleteClaimAsync(int id);
    }

    public interface IQuoteService
    {
        Task<IEnumerable<Quote>> GetAllQuotesAsync();
        Task<Quote?> GetQuoteByIdAsync(int id);
        Task<IEnumerable<Quote>> GetQuotesByCustomerIdAsync(int customerId);
        Task<Quote> CreateQuoteAsync(Quote quote);
        Task<Quote?> UpdateQuoteAsync(int id, Quote quote);
        Task<bool> DeleteQuoteAsync(int id);
        Task<decimal> CalculatePremiumAsync(PolicyType policyType, decimal coverageAmount, Customer customer);
    }

    public interface IAuthService
    {
        Task<AuthResponse?> LoginAsync(LoginRequest request);
        Task<AuthResponse?> RegisterAsync(RegisterRequest request);
        Task<User?> GetUserByUsernameAsync(string username);
    }
}