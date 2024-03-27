using TopStyleAPI.Domain.DTO;
using TopStyleAPI.Domain.Entities;

namespace TopStyleAPI.Core.Interfaces
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllProducts();
        public Task AddProduct(ProductCreateDTO product);

    }
}
