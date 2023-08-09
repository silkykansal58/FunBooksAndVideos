using System.Linq.Expressions;
using System.Threading.Tasks;
using FunBooksAndVideos.Models.Entity;
using FunBooksAndVideos.Repository.BaseRepository;

namespace FunBooksAndVideos.Repository.Interfaces
{
	public interface IItemRepository: IGenericRepostory<Item>
	{
		Task<IEnumerable<Item>> GetAllItems();
		Task<Item?> FindItemByIdAsync(Guid id);
        Task<IEnumerable<Item>> FindMultipleItemsByID(List<Guid> id);
        Task<IEnumerable<Item>> GetItemByCondition(Expression<Func<Item, bool>> expression);
		void AddItem(Item entity);
		
	}
}

