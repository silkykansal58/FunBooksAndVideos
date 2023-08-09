using FunBooksAndVideos.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace FunBooksAndVideos.Models.DTO
{
	public class AddItemDTO
	{
        [Required]
        [MinLength(2)]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Price should be greater than zero")]
        public decimal Price { get; set; }

        [Required]
        [EnumDataType(typeof(ItemTypeEnum), ErrorMessage = "Please enter a valid item type")]
        public ItemTypeEnum Type { get; set; }

        public string? Category { get; set; } = string.Empty;
    }
}

