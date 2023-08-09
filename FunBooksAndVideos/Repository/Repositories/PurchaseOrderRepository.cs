using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using FunBooksAndVideos.Models.Entity;
using FunBooksAndVideos.Repository.BaseRepository;
using FunBooksAndVideos.Repository.Interfaces;

namespace FunBooksAndVideos.Repository.Repositories
{
	public class PurchaseOrderRepository : GenericRepository<PurchaseOrder>,IPurchaseOrderRepository
    {
		public PurchaseOrderRepository(DbContext dbContext) : base(dbContext)
        {

		}
      
        public async Task<IEnumerable<PurchaseOrder>> FindOrderBasedOnConditionAsync(Expression<Func<PurchaseOrder, bool>> expression)
        {
            return await FindByConditionAsync(expression)
                .Include(po => po.Items)
                .Include(po => po.ShippingSlip)
                .ToListAsync();
        }

        public async Task<IEnumerable<PurchaseOrder>> GetAllPurchaseOrdersAsync()
        {
            return await GetAllAsync()
                .Include(po => po.Items)
                .Include(po => po.ShippingSlip)
               .ToListAsync();
        }

        public void SavePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            Create(purchaseOrder);
        }

        public void UpdatePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            Update(purchaseOrder);
        }

    }
}

