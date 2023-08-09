using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using FunBooksAndVideos.Models.Entity;
using FunBooksAndVideos.Repository.BaseRepository;
using FunBooksAndVideos.Repository.Interfaces;
using System.Threading.Tasks;

namespace FunBooksAndVideos.Repository.Repositories
{
	public class ItemRepository : GenericRepository<Item>,IItemRepository
    {
		public ItemRepository(DbContext dbContext): base(dbContext)
		{
		}

        public async Task<IEnumerable<Item>> GetAllItems()
        {
            return await GetAllAsync()
                        .OrderBy(x => x.ItemId)
                        .ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetItemByCondition(Expression<Func<Item, bool>> expression)
        {
            return await FindByConditionAsync(expression)
                         .OrderBy(x => x.ItemId)
                         .ToListAsync();
        }

        public async Task<Item?> FindItemByIdAsync(Guid id)
        {
            return await FindByConditionAsync(i => i.ItemId == id)
                 .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Item>> FindMultipleItemsByID(List<Guid> id)
        {
            return await GetAllAsync()
                        .Where(x => id.Contains(x.ItemId))
                        .OrderBy(x => x.ItemId)
                        .ToListAsync();
        }

        public void AddItem(Item item)
        {
            Create(item);
        }

        public void DeleteItem(Item item)
        {
            Delete(item);
        }

        public void UpdateItem(Item item)
        {
            Update(item);
        }
    }

}

