using Microsoft.EntityFrameworkCore;
using TopStyleAPI.Data.Interfaces;
using TopStyleAPI.Domain.Entities;

namespace TopStyleAPI.Data.Repos
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly TopStyleDbContext _dbContext;

        public CategoryRepo(TopStyleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category?> GetCategoryById(int id, bool tracking)
        {
            var result = tracking ?
                await _dbContext.Categories.SingleOrDefaultAsync(c => c.CategoryID == id) :
                await _dbContext.Categories.AsNoTracking().SingleOrDefaultAsync(c => c.CategoryID == id);
            return result;
        }

        public async Task<Category?> GetCategoryByName(string name, bool tracking)
        {
            var result = tracking ?
                await _dbContext.Categories.SingleOrDefaultAsync(c => c.CategoryName == name) :
                await _dbContext.Categories.AsNoTracking().SingleOrDefaultAsync(c => c.CategoryName == name);
            return result;
        }
    }
}
