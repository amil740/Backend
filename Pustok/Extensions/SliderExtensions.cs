using Pustok.Models;
using Pustok.ViewModels.Slider;

namespace Pustok.Extensions
{
    public static class SliderExtensions
    {
        public static SliderViewModel ToViewModel(this Slider slider)
        {
            return new SliderViewModel
            {
                Id = slider.Id,
                Title = slider.Title,
                Subtitle = slider.Subtitle,
                Description = slider.Description,
                ButtonText = slider.ButtonText,
                ButtonUrl = slider.ButtonUrl,
                Price = slider.Price,
                ImagePath = slider.ImagePath,
                BackgroundColor = slider.BackgroundColor,
                ImagePosition = slider.ImagePosition,
                TextAlignment = slider.TextAlignment,
                Order = slider.Order,
                IsActive = slider.IsActive
            };
        }

        public static SliderListViewModel ToListViewModel(this Slider slider)
        {
            return new SliderListViewModel
            {
                Id = slider.Id,
                Title = slider.Title,
                Subtitle = slider.Subtitle,
                ImagePath = slider.ImagePath,
                Order = slider.Order,
                IsActive = slider.IsActive,
                CreatedDate = slider.CreatedDate
            };
        }

        public static SliderEditViewModel ToEditViewModel(this Slider slider)
        {
            return new SliderEditViewModel
            {
                Id = slider.Id,
                Title = slider.Title,
                Subtitle = slider.Subtitle,
                Description = slider.Description,
                ButtonText = slider.ButtonText,
                ButtonUrl = slider.ButtonUrl,
                Price = slider.Price,
                ImagePath = slider.ImagePath,
                BackgroundColor = slider.BackgroundColor,
                ImagePosition = slider.ImagePosition,
                TextAlignment = slider.TextAlignment,
                Order = slider.Order,
                IsActive = slider.IsActive,
                CreatedDate = slider.CreatedDate
            };
        }

        public static Slider ToEntity(this SliderCreateViewModel model, string imagePath)
        {
            return new Slider
            {
                Title = model.Title,
                Subtitle = model.Subtitle,
                Description = model.Description,
                ButtonText = model.ButtonText,
                ButtonUrl = model.ButtonUrl,
                Price = model.Price,
                ImagePath = imagePath,
                BackgroundColor = model.BackgroundColor,
                ImagePosition = model.ImagePosition,
                TextAlignment = model.TextAlignment,
                Order = model.Order,
                IsActive = model.IsActive,
                CreatedDate = DateTime.Now
            };
        }

        public static void UpdateFromViewModel(this Slider slider, SliderEditViewModel model)
        {
            slider.Title = model.Title;
            slider.Subtitle = model.Subtitle;
            slider.Description = model.Description;
            slider.ButtonText = model.ButtonText;
            slider.ButtonUrl = model.ButtonUrl;
            slider.Price = model.Price;
            slider.BackgroundColor = model.BackgroundColor;
            slider.ImagePosition = model.ImagePosition;
            slider.TextAlignment = model.TextAlignment;
            slider.Order = model.Order;
            slider.IsActive = model.IsActive;
        }
    }
}
