

namespace WarehouseInformationSystem
{
    public class Program
    {
        private static ApplicationDbContext? _appDbContext;
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder();
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            
            var services = new ServiceCollection();
            services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            var serviceProvider = services.BuildServiceProvider();
            _appDbContext = serviceProvider?.GetService<ApplicationDbContext>();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var app = builder.Build();
            var options = optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)).Options;

            using (ApplicationDbContext db = new(options))
            {
                //User tom = new ("test",123,"test");
                //db.Users.Add(tom);
                //db.SaveChanges();

                //var TESTinsertDb = new InsertDatabase(_appDbContext);
                //await TESTinsertDb.AddInformationInBdAsync();

                //var users = db.Users.ToList();
                //foreach (User u in users)
                //{
                //    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                //}

                //var employees = db.Employees.Include(u => u.Department).Include(u => u.Post).ToList();
                //foreach (Employee u in employees)
                //{
                //    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age} - {u.Salary:C2} - {u.Department?.Name} - {u.Post?.Name}");

                //}
                var products = db.Products.Include(u => u.Location)
                                                .ThenInclude(u => u!.Address)
                                          .Include(u => u.CategoryOfProduct)
                                          .ToList();

                foreach (Product product in products)
                {
                    Console.WriteLine($"{product.Name} \n- {product.Characteristic} \n- {product.SalePrice} \n-{product.PurchasePrice} " +
                        $"\n- {product.CategoryOfProduct?.Name} \n- {product.Location?.RackNumber} \n- {product.Location?.Address?.Name}");
                }
            }
            
        }

    }

    //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    //builder.Services.AddDbContext<ApplicationDbContext>(options =>
    //{
    //    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    //});


    //var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
    //var options = optionsBuilder
    //    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
    //    .Options;


    //в дальнейшем допилю
    /// <summary>
    /// поставщик
    /// </summary>
    //public class Provider : DefaultUser
    //{
    //    
    //}

    ///// <summary>
    ///// покупатель
    ///// </summary>
    //public class Buyer : DefaultUser
    //{
    //   
    //}


    //var builder = WebApplication.CreateBuilder();

    //var services = new ServiceCollection();
    //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    //services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

    //var serviceProvider = services.BuildServiceProvider();
    //_appDbContext = serviceProvider.GetService<ApplicationDbContext>();

    //var TESTinsertDb = new InsertDatabase(_appDbContext);
    //TESTinsertDb.AddInformationInBd();

    //var app = builder.Build();

    //          -------------
    //var builder = WebApplication.CreateBuilder();
    //string connection = builder.Configuration.GetConnectionString("DefaultConnection");
    //builder.Services.AddScoped<ApplicationDbContext>();
    //var app = builder.Build(); 

    //_appDbContext = app.Services.GetService<ApplicationDbContext>();

    //var TESTinsertDb = new InsertDatabase(_appDbContext);
    //TESTinsertDb.AddInformationInBd();
}



