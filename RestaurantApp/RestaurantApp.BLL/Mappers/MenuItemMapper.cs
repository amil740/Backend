using RestaurantApp.Core.DTOs;
using RestaurantApp.Core.Models;

namespace RestaurantApp.BLL.Mappers
{
    public static class MenuItemMapper
    {
        public static MenuItemDto ToDto(MenuItem entity)
        {
            if (entity == null) return null;

            return new MenuItemDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                CategoryId = entity.CategoryId,
                CategoryName = entity.Category?.Name
            };
        }

        public static List<MenuItemDto> ToDtoList(IEnumerable<MenuItem> entities)
        {
            if (entities == null) return new List<MenuItemDto>();

            return entities.Select(ToDto).ToList();
        }

        public static MenuItem ToEntity(CreateMenuItemDto dto)
        {
            if (dto == null) return null;

            return new MenuItem
            {
                Name = dto.Name,
                Price = dto.Price,
                CategoryId = dto.CategoryId
            };
        }

        public static void UpdateEntity(MenuItem entity, UpdateMenuItemDto dto)
        {
            if (entity == null || dto == null) return;

            entity.Name = dto.Name;
            entity.Price = dto.Price;
        }
    }
}
