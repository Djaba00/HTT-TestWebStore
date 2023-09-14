using TestWebStore.Models.Entities;

namespace TestWebStore.DataAccess.Repositories.Products
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<List<Product>> GetByNameAsync(string name);
        Task<bool> CreateAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        Task<bool> DeleteAsync(Product product);
    }
}
