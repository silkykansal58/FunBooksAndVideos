
using FunBooksAndVideos.Repository.Interfaces;

namespace FunBooksAndVideos.Uow
{
	public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        IItemRepository ItemRepository { get; }
        IPurchaseOrderRepository PurchaseOrderRepository { get; }
        IMembershipRepository MembershipRepository { get; }
        IShippingSlipRepository ShippingSlipRepository { get; }
        Task save();   
    }
}

