using RestaurantApp.Core.Models;
using RestaurantApp.Core.DTOs;

namespace RestaurantApp.BLL.Interfaces
{
    public interface IOrderService
    {
        Task AddOrder(Order order);
        Task RemoveOrder(int orderId);
        ValueTask<OrderDto> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
        Task<List<OrderDto>> GetOrdersByPriceIntervalAsync(double minAmount, double maxAmount);
        Task<OrderDto?> GetOrderByNoAsync(int orderNo);
        Task<List<OrderDto>> GetOrderByDateIntervalAsync(DateTime startDate, DateTime endDate);
    }
}
