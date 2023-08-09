using AutoMapper;
using FunBooksAndVideos.Exceptions;
using FunBooksAndVideos.Models.DTO;
using FunBooksAndVideos.Models.Entity;
using FunBooksAndVideos.Services;
using Microsoft.AspNetCore.Mvc;

namespace FunBooksAndVideos.Controllers
{
    /// <summary>
    /// REST API end point for Process Order
    /// </summary>
    [ApiController]
    [Route("Order")]
    public class ProcessOrderController : ControllerBase
    {
        private readonly ILogger<ProcessOrderController> _logger;
        private readonly IPurchaseOrderService purchaseOrderService;
        private readonly IMapper mapper;

        public ProcessOrderController(ILogger<ProcessOrderController> logger, IPurchaseOrderService purchaseOrderService, IMapper mapper)
        {
            _logger = logger;
            this.purchaseOrderService = purchaseOrderService;
            this.mapper = mapper;
        }

        [Route("api/processorder")]
        [HttpPost]
        public async Task<IActionResult> ProcessOrder(PurchaseOrderRequestDTO purchaseOrderRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request");
            }

            try
            {
                _logger.LogInformation($"Processing order for Customer : {purchaseOrderRequestDTO.CustomerId}");
                var purchaseOrder = mapper.Map<PurchaseOrder>(purchaseOrderRequestDTO);
                ShippingSlipDTO? slip = await purchaseOrderService.ProcessPurchaseOrder(purchaseOrder);
                return Ok(slip);
            }
            catch(ItemNotFoundException itemNotFoundException)
            {
                _logger.LogError($"Exception in Process order: {itemNotFoundException.StackTrace} ");
                return BadRequest(itemNotFoundException.Message);
            }
            catch (CustomerNotFoundException customerNotFoundException)
            {
                _logger.LogError($"Exception in Process order: {customerNotFoundException.StackTrace} ");
                return BadRequest(customerNotFoundException.Message);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in Process order : {e.StackTrace}");
                return StatusCode(500, e.Message);
            }
        }

    }
}

