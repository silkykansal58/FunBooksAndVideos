using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FunBooksAndVideos.Models.Entity
{
    // Entity
    public class PurchaseOrder
    {
        [Key]
        public Guid PurchaseOrderId { get; set; }

        [Required]
        public decimal TotalPrice { get; set; } = 0;

        public ICollection<Item> Items { get; set; }

        public ShippingSlip? ShippingSlip { get; set; } // Reference navigation to dependent

        [ForeignKey(nameof(Customer))]
        [Required]
        public Guid CustomerId { get; set; }  // Required foreign key property - Customer
        public Customer Customer { get; set; } // Required reference navigation to principal - Customer
    }
}