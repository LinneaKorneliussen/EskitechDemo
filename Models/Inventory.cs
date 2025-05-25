namespace EskitechDemo.Models
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public int QuantityInStock { get; set; }
        public string Location { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public Inventory(int quantityInStock, string location, Product product)
        {
            QuantityInStock = quantityInStock;
            Product = product; 
            Location = location;
        }

        public Inventory() { }
    }
}
