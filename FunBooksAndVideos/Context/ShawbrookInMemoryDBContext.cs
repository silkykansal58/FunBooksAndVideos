using FunBooksAndVideos.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos.Context;

public class ShawbrookInMemoryDBContext : DbContext
{
  public DbSet<Customer> Customers { get; set; }
  public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
  public DbSet<Item> items { get; set; }
 // public DbSet<PurchaseOrderItem> PurchaseOrderItem { get; set; }
  public DbSet<ShippingSlip> ShipingSlip { get; set; }
  public DbSet<Membership> Membership { get; set; }


    public ShawbrookInMemoryDBContext(DbContextOptions options) : base(options)
    {
        this.ChangeTracker.LazyLoadingEnabled = false;
    }    
}

