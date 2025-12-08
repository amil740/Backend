using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.Models
{
    public enum QuoteStatus
    {
        Draft,
        Generated,
        Sent,
        Accepted,
        Declined,
        Expired
    }

    public class Quote
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string QuoteNumber { get; set; } = string.Empty;
        
        [Required]
        public int CustomerId { get; set; }
        
        public PolicyType PolicyType { get; set; }
        
        public QuoteStatus Status { get; set; } = QuoteStatus.Draft;
        
        [Required]
        public decimal EstimatedPremium { get; set; }
        
        [Required]
        public decimal CoverageAmount { get; set; }
        
        public DateTime ValidUntil { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        
        public string? Notes { get; set; }
        
        // Navigation property
        public virtual Customer Customer { get; set; } = null!;
    }
}