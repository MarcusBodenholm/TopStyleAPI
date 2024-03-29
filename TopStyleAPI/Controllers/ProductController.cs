using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TopStyleAPI.Core.Interfaces;
using TopStyleAPI.Domain.DTO;
using TopStyleAPI.Logger.Interfaces;

namespace TopStyleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILoggerManager _logger;

        public ProductController(IProductService productService, ILoggerManager logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var result = await _productService.GetAllProducts();
            return Ok(result);
        }
        [HttpGet]
        [Route("{category}")]
        public async Task<IActionResult> GetProductsByCategory(string category)
        {
            if (category == null) return BadRequest("Category missing.");
            var result = await _productService.GetAllProductsByCategory(category);
            return Ok(result);
        }
        [HttpGet]
        [Route("search/{search}")]
        public async Task<IActionResult> ProductSearch(string search)
        {
            if (search == null) return BadRequest("Search term missing");
            var result = await _productService.SearchProducts(search);
            return Ok(result);
        }
        [HttpPost]
        [Route("add-product")]
        public async Task<IActionResult> AddProduct(ProductCreateDTO product)
        {
            if (product == null) return BadRequest();
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(product);
            }
            var result = await _productService.AddProduct(product);
            return Ok(result);
        }
    }
}
