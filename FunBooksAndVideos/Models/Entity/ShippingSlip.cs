using System.ComponentModel.DataAnnotations;
using FunBooksAndVideos.Models.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FunBooksAndVideos.Models.Entity
{
	public class ShippingSlip 
	{
        [Key]
        public Guid ShippingSlipId { get; set; }
        public ShippingCarrier ShippingCarrier { get; set; }

        public Guid? PurchaseOrderId { get; set; } // Required foreign key property
        public PurchaseOrder? PurchaseOrder { get; set; } // Required reference navigation to principal
    }   
}

