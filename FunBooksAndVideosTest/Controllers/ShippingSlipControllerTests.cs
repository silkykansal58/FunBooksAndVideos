using System;
using AutoMapper;
using FunBooksAndVideos.Controllers;
using FunBooksAndVideos.Models.DTO;
using FunBooksAndVideos.Models.Entity;
using FunBooksAndVideos.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace FunBooksAndVideosTest.Controllers
{
    public class ShippingSlipControllerTests
    {
        private readonly Mock<IShippingSlipService> _shippingSlipServiceMock;
        private readonly Mock<ILogger<ShippingSlipController>> _iLoggerMock;

        private readonly ShippingSlipController _shippingSlipController;

        public ShippingSlipControllerTests()
        {
            var shippingSlipProfileTest = new ShippingSlipProfileTest();
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(shippingSlipProfileTest);
            });
            IMapper mapper = new Mapper(configuration);

            _shippingSlipServiceMock = new Mock<IShippingSlipService>();
            _iLoggerMock = new Mock<ILogger<ShippingSlipController>>();
            _shippingSlipController = new ShippingSlipController(_iLoggerMock.Object, _shippingSlipServiceMock.Object, mapper);
        }


        [Fact]
        public async void GetAllShippingSlipsAsync_WhenCalled_ReturnAllShippingSlips()
        {
            List<ShippingSlip> shippingSlips = new List<ShippingSlip>();

            ShippingSlip shippingSlip = new ShippingSlip();
            shippingSlip.ShippingCarrier = FunBooksAndVideos.Models.Enums.ShippingCarrier.DHL;
            shippingSlip.ShippingSlipId = Guid.NewGuid();
            shippingSlip.PurchaseOrderId = Guid.NewGuid();
            shippingSlips.Add(shippingSlip);

            IEnumerable<ShippingSlip> slipsEnumerable = shippingSlips;

            _shippingSlipServiceMock.Setup(service => service.GetAllShippingSlipsAsync())
                  .Returns(Task.FromResult(slipsEnumerable));

            IActionResult actionResult = await _shippingSlipController.GetAllShippingSlips();
            var okObjRes = actionResult as OkObjectResult;
            Assert.NotNull(okObjRes);
            var shippingSlipDTOs = okObjRes.Value as List<ShippingSlipDTO>;

            Assert.Equal(1, shippingSlipDTOs.Count);

            ShippingSlipDTO actual = shippingSlipDTOs.First();
            Assert.Equal(actual.ShippingCarrier, shippingSlip.ShippingCarrier);
        }



    }

    public class ShippingSlipProfileTest : Profile
    {
        public ShippingSlipProfileTest()
        {
            CreateMap<ShippingSlip, ShippingSlipDTO>().ReverseMap();
        }

    }

}



