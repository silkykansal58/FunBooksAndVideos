using System.ComponentModel.DataAnnotations;
using FunBooksAndVideos.Models.Enums;

namespace FunBooksAndVideos.Models.Entity
{
    // Item Entity
    public class Item
    {
        [Key]
        public Guid ItemId { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Price should be greater than zero")]
        public decimal Price { get; set; }

        [Required]
        [EnumDataType(typeof(ItemTypeEnum), ErrorMessage = "Please enter a valid item type")]
        public ItemTypeEnum Type { get; set; }

        [Required]
        public string Category { get; set; } = string.Empty;

        public List<PurchaseOrder>? PurchaseOrders { get; set; } = new List<PurchaseOrder>();
    }
}