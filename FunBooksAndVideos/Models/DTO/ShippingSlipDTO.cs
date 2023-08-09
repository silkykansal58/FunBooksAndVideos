using FunBooksAndVideos.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace FunBooksAndVideos.Models.DTO
{
	public class ShippingSlipDTO
	{
        [Key]
        public Guid ShippingSlipId { get; set; }
        public ShippingCarrier ShippingCarrier { get; set; }

        public Guid PurchaseOrderId { get; set; }
        //public PurchaseOrder PurchaseOrder { get; set; }
    }
}

