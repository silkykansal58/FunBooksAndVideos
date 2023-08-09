using FunBooksAndVideos.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace FunBooksAndVideos.Models.DTO
{
	public class ItemDTO
	{
        [Key]
        [Required]
        public Guid ItemId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public ItemTypeEnum  Type { get; set; }

        public string? Category { get; set; } = string.Empty;

       // public List<PurchaseOrderDTO> PurchaseOrders { get; set; } = new List<PurchaseOrderDTO>();
    }
}

