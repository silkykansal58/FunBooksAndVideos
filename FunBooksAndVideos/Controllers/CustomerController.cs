using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;
using FunBooksAndVideos.Models.Entity;
using FunBooksAndVideos.Services;
using FunBooksAndVideos.Models.DTO;
using AutoMapper;
using FunBooksAndVideos.Exceptions;

namespace FunBooksAndVideos.Controllers;

/// <summary>
/// Rest API endpoints for the Customer Entity.
/// </summary>

[ApiController]
[Route("Customer")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private ICustomerService customerService;
    private readonly IMapper mapper;

    public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService, IMapper mapper)
    {
        _logger = logger;
        this.customerService = customerService;
        this.mapper = mapper;
    }

    [Route("api/savecustomer")]
    [HttpPost]
    public async Task<IActionResult> SaveCustomer(AddCustomerDTO customerRequestDTO)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request");
            }
            _logger.LogInformation($"Save customer API: {customerRequestDTO.FirstName}");
            var customer = mapper.Map<Customer>(customerRequestDTO);
            Customer newCustomer = await customerService.SaveCustomerAsync(customer);
            CustomerResponseDTO newCustomerDTO = mapper.Map<CustomerResponseDTO>(newCustomer);
            return Ok(newCustomerDTO);
        }
        catch (Exception exception)
        {
            _logger.LogError($"Error in saving customer : {exception.Message}");
            return StatusCode(500, exception.Message);
        }
    }

    [HttpGet("api/{CustomerId}")]
    public async Task<IActionResult> FetchCustomerByIdAsync(Guid CustomerId)
    {
        try
        {
            _logger.LogInformation($"Getting the information for cutomer : {CustomerId}");
            Customer? customer = await customerService.GetCustomerByIdAsync(CustomerId);
            if(customer == null)
            {
                throw new CustomerNotFoundException($"Customer not  found : {CustomerId}");
            }
            var customerDTOs = mapper.Map<CustomerResponseDTO>(customer);
            return Ok(customerDTOs);
        }
        catch (CustomerNotFoundException customerNotFoundException)
        {
            _logger.LogError($"Error in getting the customers : {customerNotFoundException.StackTrace}");
            return StatusCode(500, customerNotFoundException.Message);
        }
        catch (Exception e)
        {
            _logger.LogError($"Error in getting all the customers : {e.StackTrace}");
            return StatusCode(500, e.Message);
        }
    }

    [Route("api/allcustomers")]
    [HttpGet]
    public async Task<IActionResult> FetchAllCustomersAsync()
    {
        try
        {
            _logger.LogInformation("Getting all the customers information");
            IEnumerable<Customer> customers = await customerService.GetAllCustomersAsync();
            var customerDTOs = mapper.Map<IEnumerable<CustomerResponseDTO>>(customers);
            return Ok(customerDTOs);
        }
        catch(Exception e)
        {
            _logger.LogError($"Error in getting all the customers : {e.StackTrace}");
            return StatusCode(500, e.Message);
        }
    }
}