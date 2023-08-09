using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FunBooksAndVideos.Models.Entity
{
    //[PrimaryKey(nameof(OrderId), nameof(ItemId))]
    public class PurchaseOrderItem
    {
        [Key]
        public Guid PurchaseOrderItemId;

        [ForeignKey(nameof(PurchaseOrder))]
        public Guid PurchaseOrderId { get; set; }
        public Guid ItemId { get; set; }

        //public PurchaseOrder Order { get; set; }
        public Item Item { get; set; }

    }
}