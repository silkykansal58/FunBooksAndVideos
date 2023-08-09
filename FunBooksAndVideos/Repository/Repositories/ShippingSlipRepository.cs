using Microsoft.EntityFrameworkCore;
using FunBooksAndVideos.Models.Entity;
using FunBooksAndVideos.Repository.BaseRepository;
using FunBooksAndVideos.Repository.Interfaces;

namespace FunBooksAndVideos.Repository.Repositories
{
    public class ShippingSlipRepository : GenericRepository<ShippingSlip>, IShippingSlipRepository
    {
        public ShippingSlipRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ShippingSlip?>> GetAllShippingSlipsAsync()
        {
            return await GetAllAsync()
                 .OrderBy(c => c.ShippingSlipId)
                 .ToListAsync();
        }

        public async Task<ShippingSlip?> GetShippingSlipForOrderIdAsync(Guid orderId)
        {
            return await FindByConditionAsync(slip => slip.PurchaseOrderId == orderId)
                 .FirstOrDefaultAsync();
        }
    }
}

