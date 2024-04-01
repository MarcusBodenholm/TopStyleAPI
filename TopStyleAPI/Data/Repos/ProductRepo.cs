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
                .Where(p => p.Title.ToLower().Contains(search.ToLower()) ||
                            p.Description.ToLower().Contains(search.ToLower()))
                .ToListAsync();
            return result;
        }

        public async Task AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<Product?> GetProductByIdAsync(int id, bool tracking)
        {
            var result = tracking ?
                await _dbContext.Products
                .SingleOrDefaultAsync(p => p.ProductID == id) :
                await _dbContext.Products
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.ProductID == id);
            return result;
        }
        public Product? GetProductById(int id, bool tracking)
        {
            var result = tracking ?
                _dbContext.Products
                .SingleOrDefault(p => p.ProductID == id) :
                _dbContext.Products
                .AsNoTracking()
                .SingleOrDefault(p => p.ProductID == id);
            return result;
        }

    }
}
