using System;
using AutoMapper;
using Castle.Core.Resource;
using FunBooksAndVideos.Controllers;
using FunBooksAndVideos.Models.DTO;
using FunBooksAndVideos.Models.Entity;
using FunBooksAndVideos.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace FunBooksAndVideosTest.Controllers
{
	public class ItemControllerTests
	{
        private readonly Mock<IItemService> _itemServiceMock;
        private readonly Mock<ILogger<ItemController>> _iLoggerMock;

        private readonly ItemController _itemController;

        public ItemControllerTests()
        {
            var itemResponseProfileTest = new ItemResponseProfileTest();
            var itemIdProfileTest = new ItemIdProfileTest();
            var addItemProfileTest = new AddItemProfileTest();
            var configuration = new MapperConfiguration(cfg => {
                cfg.AddProfile(itemResponseProfileTest);
                cfg.AddProfile(itemIdProfileTest);
                cfg.AddProfile(addItemProfileTest);
            });
            IMapper mapper = new Mapper(configuration);

            _itemServiceMock = new Mock<IItemService>();
            _iLoggerMock = new Mock<ILogger<ItemController>>();
            _itemController = new ItemController(_iLoggerMock.Object, _itemServiceMock.Object, mapper);
        }


        [Fact]
        public async void FetchAllCustomersAsync_WhenCalled_ReturnAllItems()
        {
            List<Item> items = new List<Item>();

            Item item = new Item();
            item.Name = "MacbookPro";
            item.Price = 1000;
            item.Type = FunBooksAndVideos.Models.Enums.ItemTypeEnum.BookMembership;
            items.Add(item);

            IEnumerable<Item> itemsEnumerable = items;

            _itemServiceMock.Setup(service => service.GetAllTheItemsAsync())
                  .Returns(Task.FromResult(itemsEnumerable));

            IActionResult actionResult = await _itemController.GetAllItemsAsync();
            var okObjRes = actionResult as OkObjectResult;
            Assert.NotNull(okObjRes);
            var itemDTOs = okObjRes.Value as List<ItemDTO>;

            Assert.Equal(1, itemDTOs.Count);

            ItemDTO actual = itemDTOs.First();
            Assert.Equal(actual.Category, item.Category);
            Assert.Equal(actual.Name, item.Name);
            Assert.Equal(actual.Price, item.Price);
        }

        [Fact]
        public async void SaveItem_WhenCalled_ReturnOkResult()
        {
            AddItemDTO itemDTO = new AddItemDTO();
            itemDTO.Name = "BookM";
            itemDTO.Price = 1000;
            itemDTO.Type = FunBooksAndVideos.Models.Enums.ItemTypeEnum.BookMembership;

            Item item = new Item();
            item.Name = "BookM";
            item.Price = 1000;
            item.Type = FunBooksAndVideos.Models.Enums.ItemTypeEnum.BookMembership;

            _itemServiceMock.Setup(service => service.SaveItem(It.IsAny<Item>()))
                 .Returns(Task.FromResult(item));


            IActionResult actionResult = await _itemController.SaveItem(itemDTO);
            Assert.NotNull(actionResult);

            var okObjRes = actionResult as OkObjectResult;
            var itemResponse = okObjRes.Value as ItemDTO;

            Assert.Equal(itemResponse.Name, itemDTO.Name);
            Assert.Equal(itemResponse.Price, itemDTO.Price);
            Assert.Equal(itemResponse.Type, itemDTO.Type);

        }

    }
}


public class ItemResponseProfileTest : Profile
{
    public ItemResponseProfileTest()
    {
        CreateMap<Item, ItemDTO>().ReverseMap();
    }

}

public class ItemIdProfileTest : Profile
{
    public ItemIdProfileTest()
    {
        CreateMap<Item, ItemIdDTO>().ReverseMap();
    }

}

public class AddItemProfileTest : Profile
{
    public AddItemProfileTest()
    {
        CreateMap<Item, AddItemDTO>().ReverseMap();
    }

}

