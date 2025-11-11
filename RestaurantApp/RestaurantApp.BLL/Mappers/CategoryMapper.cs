using RestaurantApp.Core.DTOs;
using RestaurantApp.Core.Models;

namespace RestaurantApp.BLL.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToDto(Category entity)
        {
            if (entity == null) return null;

            return new CategoryDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public static List<CategoryDto> ToDtoList(IEnumerable<Category> entities)
        {
            if (entities == null) return new List<CategoryDto>();

            return entities.Select(ToDto).ToList();
        }

        public static Category ToEntity(CreateCategoryDto dto)
        {
            if (dto == null) return null;

            return new Category
            {
                Name = dto.Name
            };
        }
    }
}
