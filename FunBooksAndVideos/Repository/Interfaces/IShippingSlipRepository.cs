using FunBooksAndVideos.Models.Entity;
using FunBooksAndVideos.Repository.BaseRepository;

namespace FunBooksAndVideos.Repository.Interfaces
{
	public interface IShippingSlipRepository : IGenericRepostory<ShippingSlip>
    {
        Task<ShippingSlip?> GetShippingSlipForOrderIdAsync(Guid orderId);
        Task<IEnumerable<ShippingSlip?>> GetAllShippingSlipsAsync();
	}
}

