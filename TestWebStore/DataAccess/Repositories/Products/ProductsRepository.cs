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
        public async Task<bool> CreateAsync(Product product)
        {
            Products.Add(product);

            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return true;
            else
                return false;
        }
        public async Task<bool> UpdateAsync(Product updateProduct)
        {
            var currentProduct = await GetByIdAsync(updateProduct.Id);

            currentProduct.Name = updateProduct.Name;
            currentProduct.Description = updateProduct.Description;
            currentProduct.Price = updateProduct.Price;
            currentProduct.inStock = updateProduct.inStock;
            currentProduct.CategoryId = updateProduct.CategoryId;

            Products.Update(currentProduct);

            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return true;
            else
                return false;
        }

        public async Task<bool> DeleteAsync(Product deleteProduct)
        {
            var product = await GetByIdAsync(deleteProduct.Id);

            Products.Remove(product);

            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return true;
            else
                return false;
        }
    }
}
