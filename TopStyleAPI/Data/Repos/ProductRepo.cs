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
            var result = await _dbContext.Products.Include(p => p.Category).AsNoTracking().ToListAsync();
            return result;
        }
        public async Task<List<Product>> GetAllProductsByCategory(string name)
        {
            var result = await _dbContext.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .Where(p => p.Category.CategoryName.ToLower() == name.ToLower())
                .ToListAsync();
            return result;
        }
        public async Task<List<Product>> SearchProducts(string search)
        {
            var result = await _dbContext.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .Where(p => p.Title.ToLower() == search.ToLower() ||
                            p.Description.ToLower() == search.ToLower())
                .ToListAsync();
            return result;
        }

        public async Task AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
        }
        
    }
}
