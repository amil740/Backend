namespace Pustok.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ButtonText { get; set; } = string.Empty;
        public string ButtonUrl { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string BackgroundColor { get; set; } = "bg-shade-whisper";
        public string ImagePosition { get; set; } = "image-right";
        public string TextAlignment { get; set; } = "text-start";
        public int Order { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
