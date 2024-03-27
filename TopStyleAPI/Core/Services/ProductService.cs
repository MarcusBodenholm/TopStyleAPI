using TopStyleAPI.Core.Interfaces;
using TopStyleAPI.Data.Interfaces;
using TopStyleAPI.Domain.DTO;
using TopStyleAPI.Domain.Entities;

namespace TopStyleAPI.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;

        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var result = await _productRepo.GetAllProducts();
            return result;
        }
        public Task AddProduct(ProductCreateDTO product)
        {
            throw new NotImplementedException();
        }

    }
}
