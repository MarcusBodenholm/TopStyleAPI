using TopStyleAPI.Domain.Entities;

namespace TopStyleAPI.Data.Interfaces
{
    public interface ICategoryRepo
    {
        public Task<Category?> GetCategoryById(int id, bool tracking);
        public Task<Category?> GetCategoryByName(string name, bool tracking);
    }
}
