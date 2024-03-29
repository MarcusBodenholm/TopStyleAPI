using TopStyleAPI.Domain.Entities;

namespace TopStyleAPI.Data.Interfaces
{
    public interface IProductRepo
    {
        public Task<List<Product>> GetAllProducts();
        public Task<List<Product>> GetAllProductsByCategory(string name);
        public Task<List<Product>> SearchProducts(string search);
        public Task AddProduct(Product product);
    }
}
