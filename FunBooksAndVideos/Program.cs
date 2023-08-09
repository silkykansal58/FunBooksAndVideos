using System.Text.Json.Serialization;
using FunBooksAndVideos.Context;
using FunBooksAndVideos.Uow;
using FunBooksAndVideos.Services;
using Microsoft.EntityFrameworkCore;

class Program
{
    public static void Main(String[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        // Add DBContext (InMemory database)
        builder.Services.AddDbContext<ShawbrookInMemoryDBContext>(option => option.UseInMemoryDatabase(("SBInMemDB")));

        // Add Unit of Work
        builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

        // Add Auto Mappeer
        builder.Services.AddAutoMapper(typeof(Program));

        // Add Services
        builder.Services.AddTransient<ICustomerService, CustomerService>();
        builder.Services.AddTransient<IItemService, ItemService>();
        builder.Services.AddTransient<IShippingSlipService, ShippingSlipService>();
        builder.Services.AddTransient<IPurchaseOrderService, PurchaseOrderService>();

        // Add Console Logger. We can use Serilog for multiple Log Sinks.
        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();

        builder.Services.AddControllers()
           .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddAutoMapper(typeof(Program));
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();

    }
}