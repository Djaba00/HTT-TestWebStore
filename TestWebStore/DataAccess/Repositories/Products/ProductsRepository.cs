using Microsoft.EntityFrameworkCore;
using TestWebStore.DataAccess.ApplicationContext;
using TestWebStore.Models.Entities;

namespace TestWebStore.DataAccess.Repositories.Products
{
    public class ProductsRepository : IProductsRepository
    {
        AppDbContext _context;
        public DbSet<Product> Products { get; set; }
        public ProductsRepository(AppDbContext context)
        {
            _context = context;
            var set = _context.Products;
            set.Load();

            Products = set;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await Products.Include(p => p.Category).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Product>> GetByNameAsync(string name)
        {
            return await Products.Include(p => p.Category).Where(p => p.Name.Contains(name)).ToListAsync();
        }
        public async Task CreateAsync(Product product)
        {
            Products.Add(product);

            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Product updateProduct)
        {
            var currentProduct = await GetByIdAsync(updateProduct.Id);

            currentProduct.Name = updateProduct.Name;
            currentProduct.Description = updateProduct.Description;
            currentProduct.Price = updateProduct.Price;
            currentProduct.inStock = updateProduct.inStock;
            currentProduct.CategoryId = updateProduct.CategoryId;
            currentProduct.Category = updateProduct.Category;

            Products.Update(currentProduct);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            Products.Remove(product);

            await _context.SaveChangesAsync();
        }
    }
}
