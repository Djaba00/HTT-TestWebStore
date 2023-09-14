using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HTT_TestWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Электроника" },
                    { 2, "Посуда" },
                    { 3, "Компьютерная переферия" },
                    { 4, "Мебель" },
                    { 5, "Спорт" },
                    { 6, "Автомобили" },
                    { 7, "Продукты питания" },
                    { 8, "Бытовая техника" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "inStock" },
                values: new object[,]
                {
                    { 1, 8, "Это холодильник", "Холодильник", 10000, 50 },
                    { 2, 8, "Это плита", "Плита", 8000, 70 },
                    { 3, 8, "Это стиральная машина", "Стиральная машина", 6000, 30 },
                    { 4, 4, "Это диван", "Диван", 5000, 60 },
                    { 5, 4, "Это шкаф", "Шкаф", 15000, 20 },
                    { 6, 5, "Это беговая дорожка", "Беговая дорожка", 20000, 50 },
                    { 7, 6, "Это Lada Vesta", "Lada Vesta", 1500000, 10 },
                    { 8, 3, "Это клавиатура", "Клавиатура", 3000, 70 },
                    { 9, 3, "Это компьютерная мышь", "Компьютерная мышь", 2000, 70 },
                    { 10, 2, "Это сковорода", "Сковорода", 3000, 25 },
                    { 11, 7, "Это чизбургер", "Чизбургер", 50, 100 },
                    { 12, 1, "Это телевизор", "Телевизор", 30000, 50 },
                    { 13, 1, "Это телефон", "Телефон", 25000, 50 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
