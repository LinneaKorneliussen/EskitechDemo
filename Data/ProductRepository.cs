using EskitechDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EskitechDemo.Data
{
    public class ProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Methods to Get Product and Inventory Data
        public async Task<IEnumerable<Product>> GetAllProductsWithInventory()
        {
            return await _context.Products
                .Include(p => p.Inventories)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByArtNr(string articleNumber)
        {
            return await _context.Products
                .Where(p => p.ArticleNumber == articleNumber)
                .Include(p => p.Inventories)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(ProductCategory category)
        {
            return await _context.Products
                .Where(p => p.Category == category)
                .Include(p => p.Inventories)
                .ToListAsync();
        }
        #endregion

        #region Methods for Updating Product Inventory
        public async Task<bool> UpdateProductInventory(string articleNumber, string location, int newQuantity)
        {
            var product = await _context.Products
                .Include(p => p.Inventories)
                .FirstOrDefaultAsync(p => p.ArticleNumber == articleNumber);

            if (product == null)
            {
                return false;
            }

            var inventory = product.Inventories.FirstOrDefault(inv => inv.Location == location);

            if (inventory == null)
            {
                return false;
            }

            inventory.QuantityInStock = newQuantity;

            await _context.SaveChangesAsync();

            return true;
        }
        #endregion

        #region Add and Remove Product Methods
        public async Task<bool> AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> DeleteProductByArticleNumber(string articleNumber)
        {
            var product = await _context.Products
                .Include(p => p.Inventories)
                .FirstOrDefaultAsync(p => p.ArticleNumber == articleNumber);

            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }
        #endregion
    }
}
