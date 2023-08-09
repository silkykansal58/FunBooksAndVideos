using FunBooksAndVideos.Models.Entity;
using FunBooksAndVideos.Repository.Interfaces;
using FunBooksAndVideos.Uow;

namespace FunBooksAndVideos.Services
{
	public class CustomerService  : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IUnitOfWork UnitOfWork;
        private readonly ILogger<CustomerService> logger;

        public CustomerService(ILogger<CustomerService> logger, IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
            this.logger = logger;
            customerRepository = UnitOfWork.CustomerRepository;
        }

        public async Task<Customer> SaveCustomerAsync(Customer customer)
        {
            logger.LogInformation($"Customer service for saving customer: {customer.FirstName}");
            customerRepository.CreateCustomer(customer);
            await UnitOfWork.save();
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            logger.LogInformation("Getting the all the customers information");
            return await customerRepository.GetAllCustomersAsync();
            
        }

        public async Task<Customer?> GetCustomerByIdAsync(Guid CustomerId)
        {
            return await customerRepository.GetCustomerByIdAsync(CustomerId);
        }
    }
}