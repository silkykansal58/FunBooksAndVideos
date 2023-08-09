using FunBooksAndVideos.Models.Entity;

namespace FunBooksAndVideos.Services
{
	public interface IShippingSlipService
	{
		Task<ShippingSlip?> FindShippingSlipForOrderIdAsync(Guid orderId);
		Task<IEnumerable<ShippingSlip?>> GetAllShippingSlipsAsync();
    }
}