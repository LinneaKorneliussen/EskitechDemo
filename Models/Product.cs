

namespace EskitechDemo.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ArticleNumber { get; set; }
        public string Name { get; set; }   
        public string Description { get; set; }
        public decimal Price { get; set; }  
        public ProductCategory Category { get; set; }

        public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

        public Product(string articleNumber, string name, string description, decimal price, ProductCategory category)
        {
            ArticleNumber = articleNumber;
            Name = name;
            Description = description;
            Price = price;
            Category = category;
        }
        public Product() { }

    }
}
