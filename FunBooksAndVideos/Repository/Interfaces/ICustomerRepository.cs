using FunBooksAndVideos.Models.Entity;
using FunBooksAndVideos.Repository.BaseRepository;

namespace FunBooksAndVideos.Repository.Interfaces
{
	public interface ICustomerRepository : IGenericRepostory<Customer>
	{
		Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomerByIdAsync(Guid id);
        void CreateCustomer(Customer entity);

    }
}

