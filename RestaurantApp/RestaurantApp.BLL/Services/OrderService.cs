using RestaurantApp.BLL.Interfaces;
using RestaurantApp.Core.Models;
using RestaurantApp.Core.Interfaces;

namespace RestaurantApp.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepository;

        public OrderService(IGenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async void AddOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Order null ola bilmez.");
            }

            if (order.OrderItems == null || !order.OrderItems.Any())
            {
                throw new ArgumentException("Order-de en azi bir item olmalidir.", nameof(order));
            }

            foreach (var orderItem in order.OrderItems)
            {
                if (orderItem.MenuItem == null)
                {
                    throw new ArgumentException("Order item-de menu item null ola bilmez.");
                }

                if (orderItem.Count <= 0)
                {
                    throw new ArgumentException("Order item sayi 0-dan boyuk olmalidir.");
                }
            }

            order.Date = DateTime.Now;

            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<List<Order>> GetOrderByDateIntervalAsync(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException("Baslangic tarixi bitme tarixinden boyuk ola bilmez.");
            }

            var orders = await _orderRepository.FindAsync(o => o.Date >= startDate && o.Date <= endDate);
            return orders.ToList();
        }

        public async ValueTask<Order> GetOrderByIdAsync(int orderId)
        {
            if (orderId <= 0)
            {
                throw new ArgumentException("Order ID 0-dan boyuk olmalidir.", nameof(orderId));
            }

            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
            {
                throw new ArgumentException("Bele bir order yoxdur.", nameof(orderId));
            }

            return order;
        }

        public async Task<Order?> GetOrderByNoAsync(int orderNo)
        {
            if (orderNo <= 0)
            {
                throw new ArgumentException("Order nomresi 0-dan boyuk olmalidir.", nameof(orderNo));
            }

            return await _orderRepository.FirstOrDefaultAsync(o => o.Id == orderNo);
        }

        public async Task<List<Order>> GetOrdersByPriceIntervalAsync(double minAmount, double maxAmount)
        {
            if (minAmount < 0 || maxAmount < 0)
            {
                throw new ArgumentOutOfRangeException("Meblegler menfi ola bilmez.");
            }

            if (minAmount > maxAmount)
            {
                throw new ArgumentException("Minimum mebleg maksimum meblegden boyuk ola bilmez.");
            }

            var allOrders = await _orderRepository.GetAllAsync();
            var filteredOrders = allOrders
                .Where(o => o.TotalPrice >= minAmount && o.TotalPrice <= maxAmount)
                .ToList();

            return filteredOrders;
        }

        public async void RemoveOrder(int orderId)
        {
            if (orderId <= 0)
            {
                throw new ArgumentException("Order ID 0-dan boyuk olmalidir.", nameof(orderId));
            }

            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
            {
                throw new ArgumentException("Bele bir order yoxdur.", nameof(orderId));
            }

            _orderRepository.Delete(order);
            await _orderRepository.SaveChangesAsync();
        }
    }
}
