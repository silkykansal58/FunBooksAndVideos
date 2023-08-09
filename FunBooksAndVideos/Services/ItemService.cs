using FunBooksAndVideos.Models.DTO;
using FunBooksAndVideos.Models.Entity;
using FunBooksAndVideos.Repository.Interfaces;
using FunBooksAndVideos.Uow;

namespace FunBooksAndVideos.Services
{
	public class ItemService : IItemService
    {
        private readonly IItemRepository itemRepository;
        private readonly IUnitOfWork UnitOfWork;
        private readonly ILogger<CustomerService> logger;

        public ItemService(ILogger<CustomerService> logger, IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
            this.logger = logger;
            itemRepository = UnitOfWork.ItemRepository;
        }

        public async Task<Item> SaveItem(Item item)
        {
            logger.LogInformation($" Item service for saving item: {item.Name}");
            itemRepository.AddItem(item);
            await UnitOfWork.save();
            return item;
        }

        public async Task<IEnumerable<Item>> GetAllTheItemsAsync()
        {
            logger.LogInformation("Getting the all the items information");
            return await itemRepository.GetAllItems();
        }

    }
}