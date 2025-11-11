using RestaurantApp.Core.DTOs;
using RestaurantApp.Core.Models;

namespace RestaurantApp.BLL.Mappers
{
    public static class OrderItemMapper
    {
        public static OrderItemDto ToDto(OrderItem entity)
        {
            if (entity == null) return null;

            return new OrderItemDto
            {
                Id = entity.Id,
                MenuItemId = entity.MenuItemId,
                MenuItemName = entity.MenuItem?.Name,
                MenuItemPrice = entity.MenuItem?.Price ?? 0,
                Count = entity.Count
            };
        }

        public static List<OrderItemDto> ToDtoList(IEnumerable<OrderItem> entities)
        {
            if (entities == null) return new List<OrderItemDto>();

            return entities.Select(ToDto).ToList();
        }
    }
}
