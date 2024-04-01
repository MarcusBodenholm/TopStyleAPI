using Microsoft.EntityFrameworkCore;
using TopStyleAPI.Data.Interfaces;
using TopStyleAPI.Domain.Entities;

namespace TopStyleAPI.Data.Repos
{
    public class OrderRepo : IOrderRepo
    {
        private readonly TopStyleDbContext _dbContext;

        public OrderRepo(TopStyleDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Order>> GetUsersOrders(string userid)
        {
            var result = await _dbContext
                .Orders
                .Include(o => o.Products)
                .ThenInclude(p => p.Category)
                .Include(o => o.Customer)
                .AsNoTracking()
                .Where(o => o.Customer.Id == userid)
                .ToListAsync();
            return result;
        }
        public async Task<Order?> GetOrder(int id, bool tracking)
        {
            var result = tracking ?
                await _dbContext
                .Orders
                .Include(o => o.Products)
                .ThenInclude(p => p.Category)
                .Include(o => o.Customer)
                .SingleOrDefaultAsync(o => o.OrderID == id)
                :
                await _dbContext
                .Orders
                .Include(o => o.Products)
                .ThenInclude(p => p.Category)
                .Include(o => o.Customer)
                .AsNoTracking()
                .SingleOrDefaultAsync(o => o.OrderID == id);

            return result;
        }
        public async Task UpdateOrder()
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task CreateOrder(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteOrder(Order order)
        {
            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();
        }
    }
}
