using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWebStore.Models.Entities;

namespace TestWebStore.DataAccess.ApplicationContext.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Price).IsRequired();

            builder.HasData(
                new Product[]
                {
                    new Product { Id = 1, Name = "Холодильник", Description = "Это холодильник", Price = 10000, inStock=50, CategoryId = 8},
                    new Product { Id = 2, Name = "Плита", Description = "Это плита", Price = 8000, inStock=70, CategoryId = 8},
                    new Product { Id = 3, Name = "Стиральная машина", Description = "Это стиральная машина", Price = 6000, inStock=30, CategoryId = 8},
                    new Product { Id = 4, Name = "Диван", Description = "Это диван", Price = 5000, inStock=60, CategoryId = 4},
                    new Product { Id = 5, Name = "Шкаф", Description = "Это шкаф", Price = 15000, inStock=20, CategoryId = 4},
                    new Product { Id = 6, Name = "Беговая дорожка", Description = "Это беговая дорожка", Price = 20000, inStock=50, CategoryId = 5},
                    new Product { Id = 7, Name = "Lada Vesta", Description = "Это Lada Vesta", Price = 1500000, inStock=10, CategoryId = 6},
                    new Product { Id = 8, Name = "Клавиатура", Description = "Это клавиатура", Price = 3000, inStock=70, CategoryId = 3},
                    new Product { Id = 9, Name = "Компьютерная мышь", Description = "Это компьютерная мышь", Price = 2000, inStock=70, CategoryId = 3},
                    new Product { Id = 10, Name = "Сковорода", Description = "Это сковорода", Price = 3000, inStock=25, CategoryId = 2},
                    new Product { Id = 11, Name = "Чизбургер", Description = "Это чизбургер", Price = 50, inStock=100, CategoryId = 7},
                    new Product { Id = 12, Name = "Телевизор", Description = "Это телевизор", Price = 30000, inStock=50, CategoryId = 1},
                    new Product { Id = 13, Name = "Телефон", Description = "Это телефон", Price = 25000, inStock=50, CategoryId = 1},
                });
        }
    }
}
