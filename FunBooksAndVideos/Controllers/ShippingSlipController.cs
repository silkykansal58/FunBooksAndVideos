using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;
using FunBooksAndVideos.Models.Entity;
using FunBooksAndVideos.Services;
using AutoMapper;
using FunBooksAndVideos.Models.DTO;
using System;

namespace FunBooksAndVideos.Controllers;

/// <summary>
/// REST API end points for Shipping Slip
/// </summary>
[ApiController]
[Route("Shipping")]
public class ShippingSlipController : ControllerBase
{
    private readonly ILogger<ShippingSlipController> _logger;
    private IShippingSlipService shippingSlipService;
    private readonly IMapper mapper;


    public ShippingSlipController(ILogger<ShippingSlipController> logger, IShippingSlipService shippingSlipService, IMapper mapper)
    {
        _logger = logger;
        this.mapper = mapper;
        this.shippingSlipService = shippingSlipService;
    }

    [Route("api/allshippingslips")]
    [HttpGet]
    public async Task<IActionResult> GetAllShippingSlips()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid Request");
        }

        try
        {
            _logger.LogInformation($"Get all the Shipping Slips");
            IEnumerable<ShippingSlip?> slips = await shippingSlipService.GetAllShippingSlipsAsync();
            var shippingSlipDTOs = mapper.Map<IEnumerable<ShippingSlipDTO>>(slips);
            return Ok(shippingSlipDTOs);
            
        }
        catch (Exception exception)
        {
            _logger.LogError($"Error in getting Shipping Slips : {exception.StackTrace}");
            return StatusCode(500, exception.Message);
        }
    }

    [HttpGet("api/{Orderid}")]
    public async Task<IActionResult> FindShippingSlipForOrderId(Guid Orderid)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid Request");
        }

        try
        {
            _logger.LogInformation($"Get shipping slip API based on Purchase Order ID : {Orderid}");
            ShippingSlip? slip = await shippingSlipService.FindShippingSlipForOrderIdAsync(Orderid);
            var shippingSlipDTO = mapper.Map<ShippingSlipDTO>(slip);
            return Ok(shippingSlipDTO);
        }
        catch (Exception exception)
        {
            _logger.LogError($"Error in getting shipping slip for Purchase Order ID : {exception.StackTrace}");
            return StatusCode(500, exception.Message);
        }
    }
}