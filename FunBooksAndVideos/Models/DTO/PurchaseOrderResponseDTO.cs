using System;
using FunBooksAndVideos.Models.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FunBooksAndVideos.Models.DTO
{
	public class PurchaseOrderResponseDTO
	{
        [Key]
        public Guid PurchaseOrderId { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        public ICollection<ItemDTO> Items { get; set; }

        public ShippingSlipDTO? ShippingSlip { get; set; } // Reference navigation to dependent

        public Guid CustomerId { get; set; }
        //public CustomerDTO Customer { get; set; } 

    }
}

