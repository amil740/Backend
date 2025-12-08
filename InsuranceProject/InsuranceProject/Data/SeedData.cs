using InsuranceProject.Models;

namespace InsuranceProject.Data
{
    public static class SeedData
    {
        public static void Initialize(InsuranceDbContext context)
        {
            if (context.Customers.Any())
                return; // DB has been seeded

            // Seed Users
            var users = new List<User>
            {
                new User
                {
                    Username = "admin",
                    Email = "admin@insurance.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                    Role = "Admin"
                },
                new User
                {
                    Username = "agent1",
                    Email = "agent1@insurance.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("agent123"),
                    Role = "Agent"
                },
                new User
                {
                    Username = "customer1",
                    Email = "customer1@email.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("customer123"),
                    Role = "Customer"
                }
            };

            // Seed Customers
            var customers = new List<Customer>
            {
                new Customer
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@email.com",
                    Phone = "(555) 123-4567",
                    Address = "123 Main St, Anytown, ST 12345",
                    DateOfBirth = new DateTime(1985, 5, 15),
                    DriversLicense = "D123456789"
                },
                new Customer
                {
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@email.com",
                    Phone = "(555) 987-6543",
                    Address = "456 Oak Ave, Somewhere, ST 67890",
                    DateOfBirth = new DateTime(1990, 8, 22),
                    DriversLicense = "D987654321"
                },
                new Customer
                {
                    FirstName = "Bob",
                    LastName = "Johnson",
                    Email = "bob.johnson@email.com",
                    Phone = "(555) 456-7890",
                    Address = "789 Pine Rd, Elsewhere, ST 13579",
                    DateOfBirth = new DateTime(1978, 12, 10),
                    DriversLicense = "D456789123"
                }
            };

            context.Users.AddRange(users);
            context.Customers.AddRange(customers);
            context.SaveChanges();

            // Seed Policies
            var policies = new List<Policy>
            {
                new Policy
                {
                    PolicyNumber = "AUTO-2024-001",
                    CustomerId = 1,
                    Type = PolicyType.Auto,
                    Premium = 1200.00m,
                    CoverageAmount = 50000.00m,
                    StartDate = DateTime.Now.AddMonths(-6),
                    EndDate = DateTime.Now.AddMonths(6),
                    Description = "Full coverage auto insurance"
                },
                new Policy
                {
                    PolicyNumber = "HOME-2024-001",
                    CustomerId = 2,
                    Type = PolicyType.Home,
                    Premium = 800.00m,
                    CoverageAmount = 250000.00m,
                    StartDate = DateTime.Now.AddMonths(-3),
                    EndDate = DateTime.Now.AddMonths(9),
                    Description = "Homeowners insurance with replacement cost coverage"
                },
                new Policy
                {
                    PolicyNumber = "LIFE-2024-001",
                    CustomerId = 3,
                    Type = PolicyType.Life,
                    Premium = 500.00m,
                    CoverageAmount = 100000.00m,
                    StartDate = DateTime.Now.AddMonths(-12),
                    EndDate = DateTime.Now.AddMonths(12),
                    Description = "Term life insurance policy"
                }
            };

            context.Policies.AddRange(policies);
            context.SaveChanges();

            // Seed Quotes
            var quotes = new List<Quote>
            {
                new Quote
                {
                    QuoteNumber = "QT-2024-001",
                    CustomerId = 1,
                    PolicyType = PolicyType.Health,
                    EstimatedPremium = 300.00m,
                    CoverageAmount = 15000.00m,
                    ValidUntil = DateTime.Now.AddDays(30),
                    Status = QuoteStatus.Generated,
                    Notes = "Health insurance quote for individual coverage"
                },
                new Quote
                {
                    QuoteNumber = "QT-2024-002",
                    CustomerId = 2,
                    PolicyType = PolicyType.Travel,
                    EstimatedPremium = 150.00m,
                    CoverageAmount = 5000.00m,
                    ValidUntil = DateTime.Now.AddDays(15),
                    Status = QuoteStatus.Sent,
                    Notes = "Travel insurance for upcoming vacation"
                }
            };

            context.Quotes.AddRange(quotes);
            context.SaveChanges();

            // Seed Claims
            var claims = new List<Claim>
            {
                new Claim
                {
                    ClaimNumber = "CL-2024-001",
                    CustomerId = 1,
                    PolicyId = 1,
                    Amount = 2500.00m,
                    Description = "Minor fender bender - rear bumper damage",
                    IncidentDate = DateTime.Now.AddDays(-10),
                    Status = ClaimStatus.UnderReview,
                    AdjusterNotes = "Photos received, scheduling inspection"
                },
                new Claim
                {
                    ClaimNumber = "CL-2024-002",
                    CustomerId = 2,
                    PolicyId = 2,
                    Amount = 5000.00m,
                    Description = "Water damage from burst pipe in kitchen",
                    IncidentDate = DateTime.Now.AddDays(-5),
                    Status = ClaimStatus.Approved,
                    ProcessedDate = DateTime.Now.AddDays(-1),
                    AdjusterNotes = "Approved for repair costs, contractor estimate received"
                }
            };

            context.Claims.AddRange(claims);
            context.SaveChanges();
        }
    }
}