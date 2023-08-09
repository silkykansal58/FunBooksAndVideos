using System.Linq.Expressions;
using FunBooksAndVideos.Models.Entity;
using FunBooksAndVideos.Repository.BaseRepository;

namespace FunBooksAndVideos.Repository.Interfaces
{
	public interface IPurchaseOrderRepository : IGenericRepostory<PurchaseOrder>
	{
        void SavePurchaseOrder(PurchaseOrder purchaseOrder);
        void UpdatePurchaseOrder(PurchaseOrder purchaseOrder);
        Task<IEnumerable<PurchaseOrder>> GetAllPurchaseOrdersAsync();
        Task<IEnumerable<PurchaseOrder>> FindOrderBasedOnConditionAsync(Expression<Func<PurchaseOrder, bool>> expression);
    }
}

