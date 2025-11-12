using RestaurantApp.Core.Models;

namespace RestaurantApp.Core.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order> GetByIdWithDetailsAsync(int id);
        Task<IEnumerable<Order>> GetAllWithDetailsAsync();
        Task<IEnumerable<Order>> FindWithDetailsAsync(System.Linq.Expressions.Expression<Func<Order, bool>> predicate);
    }
}
