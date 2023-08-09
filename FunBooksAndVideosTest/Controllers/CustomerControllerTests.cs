using FunBooksAndVideos.Controllers;
using FunBooksAndVideos.Services;
using Microsoft.Extensions.Logging;
using Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FunBooksAndVideos.Models.DTO;
using FunBooksAndVideos.Models.Entity;

namespace FunBooksAndVideosTest.Controllers
{
	public class CustomerControllerTests
	{
		private readonly Mock<ICustomerService> _customerServiceMock;
		private readonly Mock<ILogger<CustomerController>> _iLoggerMock;

        private readonly CustomerController _customerController;

        public CustomerControllerTests()
		{
            var customerResponseProfile = new CustomerResponsePofileTest();
            var customerRequestProfile = new CustomerRequestPofileTest();
            var configuration = new MapperConfiguration(cfg => {
                cfg.AddProfile(customerResponseProfile);
                cfg.AddProfile(customerRequestProfile);
                });
            IMapper mapper = new Mapper(configuration);

            _customerServiceMock = new Mock<ICustomerService>();
			_iLoggerMock = new Mock<ILogger<CustomerController>>();
            _customerController = new CustomerController(_iLoggerMock.Object,_customerServiceMock.Object, mapper);
        }

		[Fact]
		public async void FetchAllCustomersAsync_WhenCalled_ReturnAllCustomers()
		{
            List<Customer> customers = new List<Customer>();

            Customer customer = new Customer();
            customer.Address = "Mock Address";
            customer.Email = "Mock@mock.com";
            customer.FirstName = "MockFirstName";
            customer.LastName = "MockLastName";
            customer.Phone = "07440568268";
            customers.Add(customer);

            IEnumerable<Customer> customersEnumerable = customers;

            _customerServiceMock.Setup(service => service.GetAllCustomersAsync())
                  .Returns(Task.FromResult(customersEnumerable)) ;

            IActionResult actionResult = await _customerController.FetchAllCustomersAsync();
            var okObjRes = actionResult as OkObjectResult;
            Assert.NotNull(okObjRes);
            var customerDTOs = okObjRes.Value as List<CustomerResponseDTO>;

            Assert.Equal(1, customerDTOs.Count);

            CustomerResponseDTO actual = customerDTOs.First();
            Assert.Equal(actual.Address , customer.Address);
            Assert.Equal(actual.Email, customer.Email);
            Assert.Equal(actual.FirstName, customer.FirstName);
            Assert.Equal(actual.LastName, customer.LastName);
            Assert.Equal(actual.Phone, customer.Phone);

        }

        [Fact]
        public async void SaveCustomer_WhenCalled_ReturnOkResult()
        {
            AddCustomerDTO customerDTO = new AddCustomerDTO();
            customerDTO.Address = "Mock Address";
            customerDTO.Email = "Mock@mock.com";
            customerDTO.FirstName = "MockFirstName";
            customerDTO.LastName = "MockLastName";
            customerDTO.Phone = "07440568268";


            Customer customer = new Customer();
            customer.Address = "Mock Address";
            customer.Email = "Mock@mock.com";
            customer.FirstName = "MockFirstName";
            customer.LastName = "MockLastName";
            customer.Phone = "07440568268";

            _customerServiceMock.Setup(service => service.SaveCustomerAsync(It.IsAny<Customer>()))
                 .Returns(Task.FromResult(customer));

            IActionResult actionResult = await _customerController.SaveCustomer(customerDTO);
            Assert.NotNull(actionResult);

            var okObjRes = actionResult as OkObjectResult;
            var customerResponseDTO = okObjRes.Value as CustomerResponseDTO;

            Assert.Equal(customerResponseDTO.Email, customer.Email);
            Assert.Equal(customerResponseDTO.FirstName, customer.FirstName);
            Assert.Equal(customerResponseDTO.LastName, customer.LastName);
        }
    }
}


public class CustomerResponsePofileTest : Profile
{
    public CustomerResponsePofileTest()
    {
        CreateMap<Customer, CustomerResponseDTO>().ReverseMap();
    }

}

public class CustomerRequestPofileTest : Profile
{
    public CustomerRequestPofileTest()
    {
        CreateMap<Customer, AddCustomerDTO>().ReverseMap();
    }

}