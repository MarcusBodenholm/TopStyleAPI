using Microsoft.EntityFrameworkCore;
using TopStyleAPI.Data.Interfaces;
using TopStyleAPI.Domain.Entities;

namespace TopStyleAPI.Data.Repos
{
    public class ProductRepo : IProductRepo
    {
        private readonly TopStyleDbContext _dbContext;

        public ProductRepo(TopStyleDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<Product>> GetAllProducts()
        {
            var result = await _dbContext.Products.ToListAsync();
            return result;
        }
        public async Task AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
        }
        
    }
}
