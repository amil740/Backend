using RestaurantApp.BLL.Interfaces;
using RestaurantApp.BLL.Mappers;
using RestaurantApp.Core.Models;
using RestaurantApp.Core.DTOs;
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

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return OrderMapper.ToDtoList(orders);
        }

        public async Task<List<OrderDto>> GetOrderByDateIntervalAsync(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException("Baslangic tarixi bitme tarixinden boyuk ola bilmez.");
            }

            var orders = await _orderRepository.FindAsync(o => o.Date >= startDate && o.Date <= endDate);
            return OrderMapper.ToDtoList(orders);
        }

        public async ValueTask<OrderDto> GetOrderByIdAsync(int orderId)
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

            return OrderMapper.ToDto(order);
        }

        public async Task<OrderDto?> GetOrderByNoAsync(int orderNo)
        {
            if (orderNo <= 0)
            {
                throw new ArgumentException("Order nomresi 0-dan boyuk olmalidir.", nameof(orderNo));
            }

            var order = await _orderRepository.FirstOrDefaultAsync(o => o.Id == orderNo);
            return OrderMapper.ToDto(order);
        }

        public async Task<List<OrderDto>> GetOrdersByPriceIntervalAsync(double minAmount, double maxAmount)
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

            return OrderMapper.ToDtoList(filteredOrders);
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
