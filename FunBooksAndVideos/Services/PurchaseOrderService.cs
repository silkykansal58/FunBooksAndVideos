using FunBooksAndVideos.Models.Entity;
using FunBooksAndVideos.BusinessLogic;
using FunBooksAndVideos.Models.DTO;
using FunBooksAndVideos.Repository.Interfaces;
using FunBooksAndVideos.Uow;
using FunBooksAndVideos.Exceptions;
using AutoMapper;

namespace FunBooksAndVideos.Services
{
	// Provide the business services related to PurchaseOrder
	public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository purchaseOrderRepository;
        private readonly IUnitOfWork UnitOfWork;
        private readonly ILogger<CustomerService> logger;
        private readonly IItemRepository itemRepository;
        private readonly IMapper mapper;

        public PurchaseOrderService(ILogger<CustomerService> logger, IUnitOfWork UnitOfWork, IMapper mapper)
        {
            this.UnitOfWork = UnitOfWork;
            this.logger = logger;
            purchaseOrderRepository = UnitOfWork.PurchaseOrderRepository;
            itemRepository = UnitOfWork.ItemRepository;
            this.mapper = mapper;
        }

        // Service to process the order
        public async Task<ShippingSlipDTO?> ProcessPurchaseOrder(PurchaseOrder entity)
		{
            logger.LogInformation($" Purchase order service for processing order the order for customer id: {entity.CustomerId}");

            // Get Items from catalog
            List<Guid> itemIds = entity.Items.Select(x => x.ItemId).ToList();
            IEnumerable<Item> entityItems = await itemRepository.FindMultipleItemsByID(itemIds);

            if(entityItems==null ||  entityItems.Count() == 0 || entity.Items.Count > entityItems.Count())
            {
                throw new ItemNotFoundException("Some Item(s) not found in Catalog");
            }
            entity.Items = entityItems.ToList();

            Customer? cust = await UnitOfWork.CustomerRepository.GetCustomerByIdAsync(entity.CustomerId);

            if(cust == null)
            {
                throw  new CustomerNotFoundException("Customer not found while processing the order");
            }

            entity.Customer = cust;

            // Save the order to DB
            purchaseOrderRepository.SavePurchaseOrder(entity);
            await UnitOfWork.save();

            // Apply business rules using Chain of Resp design patten.

			//TODO - Create chain.
            BusinessRuleProcessor businessRuleProcessor = new BusinessRuleProcessor(UnitOfWork);
			PurchaseOrderStatus status = await businessRuleProcessor.ApplyBusinessRulesAsync(entity);

			// commit the changes to DB
			await UnitOfWork.save();
            var shippingSlipDTO = mapper.Map<ShippingSlipDTO>(entity.ShippingSlip);
            return shippingSlipDTO;
        }

    }
}

