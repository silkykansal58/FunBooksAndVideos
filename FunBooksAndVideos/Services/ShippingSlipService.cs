using System;
using FunBooksAndVideos.Models.Entity;
using FunBooksAndVideos.Repository.Interfaces;
using FunBooksAndVideos.Uow;

namespace FunBooksAndVideos.Services
{
	public class ShippingSlipService : IShippingSlipService
    {
        private readonly IShippingSlipRepository shippingSlipRepository;
        private readonly IUnitOfWork UnitOfWork;
        private readonly ILogger<ShippingSlipService> logger;

        public ShippingSlipService(ILogger<ShippingSlipService> logger, IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
            this.logger = logger;
            shippingSlipRepository = UnitOfWork.ShippingSlipRepository;
        }

        public async Task<ShippingSlip?> FindShippingSlipForOrderIdAsync(Guid orderId)
		{
            logger.LogInformation($" Shipping slip service for fetching shipping slip based on order id : {orderId}");
            return await shippingSlipRepository.GetShippingSlipForOrderIdAsync(orderId);
		}

        public async Task<IEnumerable<ShippingSlip?>> GetAllShippingSlipsAsync()
        {
            logger.LogInformation("Getting the all the shipping slips information");
            return await shippingSlipRepository.GetAllShippingSlipsAsync();
        }
    }
}

