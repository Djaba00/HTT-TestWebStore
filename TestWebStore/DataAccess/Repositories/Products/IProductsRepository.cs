using TestWebStore.Models.Entities;

namespace TestWebStore.DataAccess.Repositories.Products
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<List<Product>> GetByNameAsync(string name);
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
    }
}
