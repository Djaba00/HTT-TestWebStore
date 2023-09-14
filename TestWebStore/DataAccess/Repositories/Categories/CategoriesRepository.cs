using Microsoft.EntityFrameworkCore;
using TestWebStore.DataAccess.ApplicationContext;
using TestWebStore.Models.Entities;

namespace TestWebStore.DataAccess.Repositories.Categories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        AppDbContext _context;
        public DbSet<Category> Categories { get; set; }
        public CategoriesRepository(AppDbContext context)
        {
            _context = context;
            var set = _context.Categories;
            set.Load();

            Categories = set;
        }
        public async Task<List<Category>> GetAllAsync()
        {
            return await Categories.Include(c => c.Products).ToListAsync();
        }

        public async Task<Category> GetAsync(string name)
        {
            return await Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<List<Category>> GetByNameAsync(string name)
        {
            return await Categories.Include(c => c.Products).Where(c => c.Name.Contains(name)).ToListAsync();
        }

        public async Task<bool> CreateAsync(Category category)
        {
            if (Categories.FirstOrDefault(c => c.Name == category.Name) is null)
            {
                Categories.Add(category);

                var result = await _context.SaveChangesAsync();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                throw new Exception("Данная категория уже существует");
            }
        }
        public async Task<bool> UpdateAsync(Category updateCategory)
        {
            var currentCategory = await GetAsync(updateCategory.Name);

            currentCategory.Name = updateCategory.Name;
            currentCategory.Products = updateCategory.Products;

            Categories.Update(currentCategory);

            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return true;
            else
                return false;
        }

        public async Task<bool> DeleteAsync(Category category)
        {
            Categories.Remove(category);

            var result = await _context.SaveChangesAsync();

            if (result > 0)
                return true;
            else
                return false;
        }

        
    }
}
