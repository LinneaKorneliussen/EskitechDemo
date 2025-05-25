using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EskitechDemo.DTOs
{
    public class InventoryDTO
    {
        [Range(0, int.MaxValue, ErrorMessage = "Quantity in stock must be a non-negative integer.")]
        [DefaultValue(0)]
        public int QuantityInStock { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(100, ErrorMessage = "Location name cannot exceed 100 characters.")]
        [DefaultValue("")]
        public string Location { get; set; }
    }
}
