using System.ComponentModel.DataAnnotations;

namespace Pustok.ViewModels.Slider
{
    public class SliderEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Subtitle is required")]
        [StringLength(200)]
        public string Subtitle { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Button text is required")]
        [StringLength(50)]
        public string ButtonText { get; set; } = string.Empty;

        [Required(ErrorMessage = "Button URL is required")]
        [StringLength(500)]
        public string ButtonUrl { get; set; } = string.Empty;

        [Range(0, 999999.99)]
        public decimal Price { get; set; }

        public string? ImagePath { get; set; }
        public IFormFile? ImageFile { get; set; }

        [Required(ErrorMessage = "Background color is required")]
        [StringLength(50)]
        public string BackgroundColor { get; set; } = "bg-shade-whisper";

        [Required(ErrorMessage = "Image position is required")]
        [StringLength(50)]
        public string ImagePosition { get; set; } = "image-right";

        [Required(ErrorMessage = "Text alignment is required")]
        [StringLength(50)]
        public string TextAlignment { get; set; } = "text-start";

        [Range(0, 999)]
        public int Order { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; }
    }
}
