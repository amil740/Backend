using RestaurantApp.Core.Models;

namespace RestaurantApp.BLL.Interfaces
{
    public interface IOrderService
    {
        void AddOrder(Order order);
        void RemoveOrder(int orderId);
        ValueTask<Order> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<List<Order>> GetOrdersByPriceIntervalAsync(double minAmount, double maxAmount);
        Task<Order?> GetOrderByNoAsync(int orderNo);
        Task<List<Order>> GetOrderByDateIntervalAsync(DateTime startDate, DateTime endDate);
    }
}
