
using FunBooksAndVideos.Context;
using FunBooksAndVideos.Repository.Interfaces;
using FunBooksAndVideos.Repository.Repositories;

namespace FunBooksAndVideos.Uow;

public class UnitOfWork : IUnitOfWork
{
	private  ShawbrookInMemoryDBContext dbContext;

    public ICustomerRepository CustomerRepository { get; private set; }
    public IItemRepository ItemRepository { get; private set; }
    public IPurchaseOrderRepository PurchaseOrderRepository { get; private set; }
    public IMembershipRepository MembershipRepository { get; private set; }
    public IShippingSlipRepository ShippingSlipRepository { get; private set; }
    private CancellationTokenSource cancellationTokenSource;
    private CancellationToken token;

    public UnitOfWork (ShawbrookInMemoryDBContext ShawbrookInMemoryDBContext){
        dbContext = ShawbrookInMemoryDBContext;

        CustomerRepository = new CustomerRepository(dbContext);
        ItemRepository = new ItemRepository(dbContext);
        PurchaseOrderRepository = new PurchaseOrderRepository(dbContext);
        MembershipRepository = new MembershipRepository(dbContext);
        ShippingSlipRepository = new ShippingSlipRepository(dbContext);
        cancellationTokenSource = new CancellationTokenSource();
        token = cancellationTokenSource.Token;

        // Cancel the Async task if not responded in 10 seconds.
        // It needs to be configurable.
        cancellationTokenSource.CancelAfter(10000);
    }

    public async Task save()
	{
       await dbContext.SaveChangesAsync(token);
	}

}
