using AutoMapper;
using TopStyleAPI.Core.Interfaces;
using TopStyleAPI.Data.Interfaces;
using TopStyleAPI.Domain.DTO;
using TopStyleAPI.Domain.Entities;
using TopStyleAPI.ExceptionHandler.Exceptions;

namespace TopStyleAPI.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        private readonly ICategoryRepo _categoryRepo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepo productRepo, IMapper mapper, ICategoryRepo categoryRepo)
        {
            _productRepo = productRepo;
            _mapper = mapper;
            _categoryRepo = categoryRepo;
        }

        public async Task<List<ProductDTO>> GetAllProducts()
        {
            var products = await _productRepo.GetAllProducts();
            var result = products.Select(p => _mapper.Map<ProductDTO>(p)).ToList();
            return result;
        }
        public async Task<List<ProductDTO>> GetAllProductsByCategory(string categoryName)
        {
            var products = await _productRepo.GetAllProductsByCategory(categoryName);
            var result = products.Select(p => _mapper.Map<ProductDTO>(p)).ToList();
            return result;
        }
        public async Task<ProductDTO> AddProduct(ProductCreateDTO product)
        {
            Category? category = await _categoryRepo.GetCategoryById(product.CategoryID, true);
            if (category == null)
            {
                throw new CategoryNotFoundException(product.CategoryID);
            }
            var newProduct = _mapper.Map<Product>(product);
            newProduct.Category = category;
            await _productRepo.AddProduct(newProduct);
            var result = _mapper.Map<ProductDTO>(newProduct);
            return result;
        }

    }
}
