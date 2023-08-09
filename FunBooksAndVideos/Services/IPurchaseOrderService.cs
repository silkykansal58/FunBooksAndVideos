using System;
using FunBooksAndVideos.Models.DTO;
using FunBooksAndVideos.Models.Entity;

namespace FunBooksAndVideos.Services
{
	public interface IPurchaseOrderService
	{
        Task<ShippingSlipDTO?> ProcessPurchaseOrder(PurchaseOrder purchaseOrderEntity);
    }
}

