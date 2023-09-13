namespace TestWeb.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int inStock { get; set; }
        public List<Category> Categories { get; set; }
    }
}
