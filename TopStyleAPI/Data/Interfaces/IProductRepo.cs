using TopStyleAPI.Domain.Entities;

namespace TopStyleAPI.Data.Interfaces
{
    public interface IProductRepo
    {
        public Task<List<Product>> GetAllProducts();
        public Task<List<Product>> GetAllProductsByCategory(string name);
        public Task<List<Product>> SearchProducts(string search);
        public Task AddProduct(Product product);
        public Task<Product?> GetProductByIdAsync(int id, bool tracking);
        public Product? GetProductById(int id, bool tracking);
    }
}
