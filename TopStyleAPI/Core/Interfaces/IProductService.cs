using TopStyleAPI.Domain.DTO;
using TopStyleAPI.Domain.Entities;

namespace TopStyleAPI.Core.Interfaces
{
    public interface IProductService
    {
        public Task<List<ProductDTO>> GetAllProducts();
        public Task<List<ProductDTO>> GetAllProductsByCategory(string categoryName);
        public Task<List<ProductDTO>> SearchProducts(string search);
        public Task<ProductDTO> AddProduct(ProductCreateDTO product);

    }
}
