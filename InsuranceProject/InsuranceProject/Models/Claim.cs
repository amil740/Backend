using System.ComponentModel.DataAnnotations;

namespace InsuranceProject.Models
{
    public enum ClaimStatus
    {
        Submitted,
        UnderReview,
        Approved,
        Rejected,
        Closed
    }

    public class Claim
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string ClaimNumber { get; set; } = string.Empty;
        
        [Required]
        public int CustomerId { get; set; }
        
        [Required]
        public int PolicyId { get; set; }
        
        public ClaimStatus Status { get; set; } = ClaimStatus.Submitted;
        
        [Required]
        public decimal Amount { get; set; }
        
        [Required]
        public string Description { get; set; } = string.Empty;
        
        public DateTime IncidentDate { get; set; }
        
        public DateTime SubmittedDate { get; set; } = DateTime.UtcNow;
        
        public DateTime? ProcessedDate { get; set; }
        
        public string? AdjusterNotes { get; set; }
        
        // Navigation properties
        public virtual Customer Customer { get; set; } = null!;
        public virtual Policy Policy { get; set; } = null!;
    }
}