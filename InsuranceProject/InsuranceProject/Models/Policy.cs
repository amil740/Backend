using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.Models
{
    public enum PolicyType
    {
        Auto,
        Home,
        Life,
        Health,
        Travel,
        Business
    }

    public enum PolicyStatus
    {
        Active,
        Expired,
        Cancelled,
        Suspended
    }

    public class Policy
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string PolicyNumber { get; set; } = string.Empty;
        
        [Required]
        public int CustomerId { get; set; }
        
        public PolicyType Type { get; set; }
        
        public PolicyStatus Status { get; set; } = PolicyStatus.Active;
        
        [Required]
        public decimal Premium { get; set; }
        
        [Required]
        public decimal CoverageAmount { get; set; }
        
        [Required]
        public DateTime StartDate { get; set; }
        
        [Required]
        public DateTime EndDate { get; set; }
        
        public string? Description { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        
        // Navigation properties
        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<Claim> Claims { get; set; } = new List<Claim>();
    }
}