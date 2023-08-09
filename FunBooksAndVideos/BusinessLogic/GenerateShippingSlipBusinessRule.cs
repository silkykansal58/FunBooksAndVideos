using FunBooksAndVideos.Models.DTO;
using FunBooksAndVideos.Models.Entity;
using FunBooksAndVideos.Models.Enums;
using FunBooksAndVideos.Uow;
using FunBooksAndVideos.Repository.Interfaces;

namespace FunBooksAndVideos.BusinessLogic
{
	public class GenerateShippingSlipBusinessRule: PurchaseOrderBusinessRule
	{
        private PurchaseOrderStatus status;
        private IPurchaseOrderRepository purchaseOrderRepository;
        private IUnitOfWork unitOfWork;

        public GenerateShippingSlipBusinessRule
            (
                PurchaseOrderBusinessRule? nextProcessor,
                PurchaseOrderStatus purchaseOrderStatus,
                IUnitOfWork unitOfWork
            ): base(nextProcessor,purchaseOrderStatus)
        {
            this.status = purchaseOrderStatus;
            this.unitOfWork = unitOfWork;
            purchaseOrderRepository = unitOfWork.PurchaseOrderRepository;
        }

        public override async Task ApplyBusinessRuleAsync(PurchaseOrder order)
        {   
            List<Item> shippingItems =
                order.Items
                .Where(x => x.Type.Equals(ItemTypeEnum.Product)).ToList();

            if (shippingItems.Count > 0)
            {
                order.ShippingSlip = new ShippingSlip();
                order.ShippingSlip.PurchaseOrderId = order.PurchaseOrderId;
                order.ShippingSlip.ShippingCarrier = ShippingCarrier.DHL;
                order.ShippingSlip.PurchaseOrder = order;

                purchaseOrderRepository.Update(order);
            }
            await unitOfWork.save();
            await base.ApplyBusinessRuleAsync(order);
        }
    }
}

