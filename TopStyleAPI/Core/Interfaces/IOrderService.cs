using TopStyleAPI.Domain.DTO;

namespace TopStyleAPI.Core.Interfaces
{
    public interface IOrderService
    {
        public Task<List<OrderDTO>> GetUsersOrders();
        public Task CreateOrder(OrderPlacementDTO orderInfo);
        public Task DeleteOrder(int id);
        public Task AddProductToOrder(OrderAddProductDTO info);
    }
}
