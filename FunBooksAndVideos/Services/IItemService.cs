using FunBooksAndVideos.Models.DTO;
using FunBooksAndVideos.Models.Entity;

namespace FunBooksAndVideos.Services
{
	public interface IItemService
	{
        Task<Item> SaveItem(Item item);
        Task<IEnumerable<Item>> GetAllTheItemsAsync();
    }
}