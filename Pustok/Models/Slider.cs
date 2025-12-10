using System.ComponentModel.DataAnnotations;

namespace Pustok.Models
{
    public class Slider
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 200 characters")]
        public string Title { get; set; } = string.Empty;
 
        [Required(ErrorMessage = "Subtitle is required")]
        [StringLength(200, ErrorMessage = "Subtitle cannot exceed 200 characters")]
        public string Subtitle { get; set; } = string.Empty;
        
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Button text is required")]
        [StringLength(50, ErrorMessage = "Button text cannot exceed 50 characters")]
        public string ButtonText { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Button URL is required")]
        [StringLength(500, ErrorMessage = "Button URL cannot exceed 500 characters")]
        public string ButtonUrl { get; set; } = string.Empty;
      
        [Range(0, 999999.99, ErrorMessage = "Price must be between 0 and 999,999.99")]
        public decimal Price { get; set; }
        
        [Required(ErrorMessage = "Image is required")]
        public string ImagePath { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Background color is required")]
        [StringLength(50, ErrorMessage = "Background color cannot exceed 50 characters")]
        public string BackgroundColor { get; set; } = "bg-shade-whisper";
        
        [Required(ErrorMessage = "Image position is required")]
        [StringLength(50, ErrorMessage = "Image position cannot exceed 50 characters")]
        public string ImagePosition { get; set; } = "image-right";
        
        [Required(ErrorMessage = "Text alignment is required")]
        [StringLength(50, ErrorMessage = "Text alignment cannot exceed 50 characters")]
        public string TextAlignment { get; set; } = "text-start";
   
        [Range(0, 999, ErrorMessage = "Order must be between 0 and 999")]
        public int Order { get; set; }
        
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
