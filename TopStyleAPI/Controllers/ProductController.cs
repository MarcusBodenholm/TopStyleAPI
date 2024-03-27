using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TopStyleAPI.Core.Interfaces;
using TopStyleAPI.Domain.DTO;

namespace TopStyleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var result = await _productService.GetAllProducts();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductCreateDTO product)
        {
            if (product == null) return BadRequest();
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(product);
            }

            
        }
    }
}
