using TestWebStore.Models.Entities;

namespace TestWebStore.DataAccess.Repositories.Categories
{
    public interface ICategoriesRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category> GetAsync(string name);
        Task<bool> CreateAsync(Category category);
        Task<bool> UpdateAsync(Category category);
        Task<bool> DeleteAsync(Category category);
    }
}
