using TopStyleAPI.Domain.Entities;

namespace TopStyleAPI.Data.Interfaces
{
    public interface IOrderRepo
    {
        public Task<List<Order>> GetUsersOrders(string userid);
        public Task<Order?> GetOrder(int id, bool tracking);
        public Task UpdateOrder();
        public Task CreateOrder(Order order);
        public Task DeleteOrder(Order order);

    }
}
