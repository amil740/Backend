using RestaurantApp.Core.DTOs;
using RestaurantApp.Core.Models;

namespace RestaurantApp.BLL.Mappers
{
    public static class OrderMapper
    {
        public static OrderDto ToDto(Order entity)
        {
            if (entity == null) return null;

            var orderDto = new OrderDto
            {
                Id = entity.Id,
                Date = entity.Date,
                TotalPrice = entity.TotalPrice,
                OrderItems = entity.OrderItems?.Select(OrderItemMapper.ToDto).ToList() ?? new List<OrderItemDto>()
            };

            orderDto.TotalItemCount = orderDto.OrderItems.Sum(oi => oi.Count);

            return orderDto;
        }

        public static List<OrderDto> ToDtoList(IEnumerable<Order> entities)
        {
            if (entities == null) return new List<OrderDto>();

            return entities.Select(ToDto).ToList();
        }
    }
}
