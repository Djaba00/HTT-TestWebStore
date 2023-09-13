using TestWebStore.Models.Entities;

namespace TestWebStore.DataAccess.Repositories.Categories
{
    public interface ICategoriesRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category> GetAsync(string name);
        Task CreateAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Category category);
    }
}
