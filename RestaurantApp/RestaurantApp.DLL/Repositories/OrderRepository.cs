using Microsoft.EntityFrameworkCore;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Core.Models;
using RestaurantApp.DLL.Data;
using System.Linq.Expressions;

namespace RestaurantApp.DLL.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(RestaurantDbContext context) : base(context)
        {
        }

        public async Task<Order> GetByIdWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.MenuItem)
                        .ThenInclude(mi => mi.Category)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Order>> GetAllWithDetailsAsync()
        {
            return await _dbSet
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.MenuItem)
                        .ThenInclude(mi => mi.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> FindWithDetailsAsync(Expression<Func<Order, bool>> predicate)
        {
            return await _dbSet
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.MenuItem)
                        .ThenInclude(mi => mi.Category)
                .Where(predicate)
                .ToListAsync();
        }
    }
}
