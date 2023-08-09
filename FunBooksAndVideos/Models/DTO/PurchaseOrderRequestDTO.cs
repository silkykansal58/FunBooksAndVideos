using System;
using System.ComponentModel.DataAnnotations;

namespace FunBooksAndVideos.Models.DTO
{
	public class PurchaseOrderRequestDTO
	{
        public Guid CustomerId { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Price should be greater than zero")]
        public decimal TotalPrice { get; set; }

        public ICollection<ItemIdDTO> Items { get; set; }

    }
}

