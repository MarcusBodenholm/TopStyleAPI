using TopStyleAPI.Domain.Entities;

namespace TopStyleAPI.Data.Interfaces
{
    public interface IProductRepo
    {
        public Task<List<Product>> GetAllProducts();
        public Task AddProduct();
    }
}
