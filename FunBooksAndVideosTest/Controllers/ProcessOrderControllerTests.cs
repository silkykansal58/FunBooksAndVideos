using System;
using AutoMapper;
using FunBooksAndVideos.Controllers;
using FunBooksAndVideos.Models.DTO;
using FunBooksAndVideos.Models.Entity;
using FunBooksAndVideos.Models.Enums;
using FunBooksAndVideos.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace FunBooksAndVideosTest.Controllers
{
	public class ProcessOrderControllerTests
	{
        private readonly Mock<IPurchaseOrderService> _purchaseOrderServiceMock;
        private readonly Mock<ILogger<ProcessOrderController>> _iLoggerMock;

        private readonly ProcessOrderController _processOrderController;

        public ProcessOrderControllerTests()
        {
            var purchaseOrderResponseProfileTest = new PurchaseOrderResponseProfileTest();
            var purchaseOrderRequestProfileTest = new PurchaseOrderRequestProfileTest();
            var itemIdProfileTest = new ItemIdProfileTest();

            var configuration = new MapperConfiguration(cfg => {
                cfg.AddProfile(purchaseOrderResponseProfileTest);
                cfg.AddProfile(purchaseOrderRequestProfileTest);
                cfg.AddProfile(itemIdProfileTest);
            });
            IMapper mapper = new Mapper(configuration);

            _purchaseOrderServiceMock = new Mock<IPurchaseOrderService>();
            _iLoggerMock = new Mock<ILogger<ProcessOrderController>>();
            _processOrderController = new ProcessOrderController(_iLoggerMock.Object, _purchaseOrderServiceMock.Object, mapper);
        }

        [Fact]
        public async void ProcessOrder_WhenCalled_ReturnOkResult()
        {
            PurchaseOrderRequestDTO purchaseOrder = new PurchaseOrderRequestDTO();

            ItemIdDTO itemIdDTO = new ItemIdDTO();
            itemIdDTO.ItemId = Guid.NewGuid();

            List<ItemIdDTO> items = new List<ItemIdDTO>();
            items.Add(itemIdDTO);

            ICollection<ItemIdDTO> obj = items;

            purchaseOrder.CustomerId = Guid.NewGuid();
            purchaseOrder.TotalPrice = 100;
            purchaseOrder.Items = obj;

            ShippingSlipDTO shippingSlip = new ShippingSlipDTO();
            shippingSlip.ShippingCarrier = ShippingCarrier.DHL;
            shippingSlip.ShippingSlipId = Guid.NewGuid();
            shippingSlip.PurchaseOrderId = Guid.NewGuid();

            _purchaseOrderServiceMock.Setup(service => service.ProcessPurchaseOrder(It.IsAny<PurchaseOrder>()))
                 .Returns(Task.FromResult(shippingSlip));

            IActionResult actionResult = await _processOrderController.ProcessOrder(purchaseOrder);
            Assert.NotNull(actionResult);

            var okObjRes = actionResult as OkObjectResult;
            Assert.NotNull(okObjRes);

            var shippingSlipResponse = okObjRes.Value as ShippingSlipDTO;
            Assert.Equal(shippingSlipResponse.ShippingCarrier, shippingSlip.ShippingCarrier);
        }

    }


    public class PurchaseOrderResponseProfileTest : Profile
    {
        public PurchaseOrderResponseProfileTest()
        {
            CreateMap<PurchaseOrder, PurchaseOrderResponseDTO>().ReverseMap();
        }

    }

    public class PurchaseOrderRequestProfileTest : Profile
    {
        public PurchaseOrderRequestProfileTest()
        {
            CreateMap<PurchaseOrder, PurchaseOrderRequestDTO>().ReverseMap();
        }

    }

}