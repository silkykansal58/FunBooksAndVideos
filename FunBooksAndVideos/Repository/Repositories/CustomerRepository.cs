using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using FunBooksAndVideos.Models.Entity;
using FunBooksAndVideos.Repository.BaseRepository;
using FunBooksAndVideos.Repository.Interfaces;

namespace FunBooksAndVideos.Repository.Repositories
{
	public class CustomerRepository : GenericRepository<Customer> , ICustomerRepository
    {
		public CustomerRepository(DbContext dbContext) : base(dbContext)
        {
		}

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await GetAllAsync()
                 .Include(c => c.Memberships)
                 .Include(c => c.PurchaseOrders)
                 .ThenInclude(p => p.Items)
                 .Include(c => c.PurchaseOrders)
                 .ThenInclude(p => p.ShippingSlip)
                 .OrderBy(c => c.CustomerId)
                 .ToListAsync();
        }

        public async Task<IEnumerable<Customer>> FindCustomerBasedOnCondition(Expression<Func<Customer, bool>> expression)
        {
            return await FindByConditionAsync(expression)
                 .Include(c => c.Memberships)
                 .Include(c => c.PurchaseOrders)
                 .ThenInclude(p => p.Items)
                 .Include(c => c.PurchaseOrders)
                 .ThenInclude(p => p.ShippingSlip)
                 .OrderBy(c => c.CustomerId)
                 .ToListAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync(Guid id)
        {
            return await FindByConditionAsync(c => c.CustomerId == id)
                 .Include(c => c.Memberships)
                 .Include(c => c.PurchaseOrders)
                 .ThenInclude(p => p.Items)
                 .Include(c => c.PurchaseOrders)
                 .ThenInclude(p => p.ShippingSlip)
                 .OrderBy(c => c.CustomerId)
                 .FirstOrDefaultAsync();
        }

        public void CreateCustomer(Customer entity)
        {
            Create(entity);
        }

        public void UpdateCustomer(Customer entity)
        {
            Update(entity);
        }

        public void DeleteCustomer(Customer entity)
        {
            Delete(entity);
        }

        
    }
}

