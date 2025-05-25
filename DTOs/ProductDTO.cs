using EskitechDemo.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EskitechDemo.DTOs
{
    public class ProductDTO
    {
        [Required(ErrorMessage = "Article number is required.")]
        [StringLength(50, ErrorMessage = "Article number cannot exceed 50 characters.")]
        [DefaultValue("")]
        public string ArticleNumber { get; set; } 

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, ErrorMessage = "Product name cannot exceed 100 characters.")]
        [DefaultValue("")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        [DefaultValue("")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        [DefaultValue(0)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public ProductCategory Category { get; set; }

        public List<InventoryDTO> Inventories { get; set; }
    }
}

