using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using TestWebStore.Models.Entities;

namespace TestWebStore.DataAccess.ApplicationContext.EntityConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(c => c.Name).IsUnique();

            builder.HasData(
                new Category[]
                {
                    new Category { Id = 1, Name = "Электроника"},
                    new Category { Id = 2, Name = "Посуда"},
                    new Category { Id = 3, Name = "Компьютерная переферия"},
                    new Category { Id = 4, Name = "Мебель"},
                    new Category { Id = 5, Name = "Спорт"},
                    new Category { Id = 6, Name = "Автомобили"},
                    new Category { Id = 7, Name = "Продукты питания"},
                    new Category { Id = 8, Name = "Бытовая техника"},
                });
        }
    }
}
