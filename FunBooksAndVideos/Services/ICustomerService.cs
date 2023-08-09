using FunBooksAndVideos.Models.Entity;

namespace FunBooksAndVideos.Services
{
	public interface ICustomerService
	{
        Task<Customer> SaveCustomerAsync(Customer customer);
        Task<Customer?> GetCustomerByIdAsync(Guid CustomerId);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
    }
}

