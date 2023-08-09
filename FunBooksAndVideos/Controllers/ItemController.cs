using System;
using AutoMapper;
using FunBooksAndVideos.Models.DTO;
using FunBooksAndVideos.Models.Entity;
using FunBooksAndVideos.Services;
using Microsoft.AspNetCore.Mvc;

namespace FunBooksAndVideos.Controllers
{
    /// <summary>
    /// REST API end points for Item Entity.
    /// </summary>
    [ApiController]
    [Route("Item")]
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private IItemService itemService;
        private readonly IMapper mapper;

        public ItemController(ILogger<ItemController> logger, IItemService itemService,IMapper mapper)
        {
            _logger = logger;
            this.itemService = itemService;
            this.mapper = mapper;
        }

        [Route("api/additem")]
        [HttpPost]
        public async Task<IActionResult> SaveItem(AddItemDTO itemDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request");
            }

            try
            {
                _logger.LogInformation($"Save item : {itemDTO.Name}");
                var item = mapper.Map<Item>(itemDTO);
                Item newItem = await itemService.SaveItem(item);
                var newItemDTO = mapper.Map<ItemDTO>(newItem);
                return Ok(newItemDTO);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error in Saving Item : {exception.StackTrace} ");
                return StatusCode(500, exception.Message);
            }
        }


        [Route("api/allitems")]
        [HttpGet]
        public async Task<IActionResult> GetAllItemsAsync()
        {
            try
            {
                _logger.LogInformation("Getting all the Items information");
                IEnumerable<Item> items = await itemService.GetAllTheItemsAsync();
                var itemDTOs = mapper.Map<IEnumerable<ItemDTO>>(items);
                return Ok(itemDTOs);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error in getting all the items : {exception.StackTrace}");
                return StatusCode(500, exception.Message);
            }
        }
    }
}

