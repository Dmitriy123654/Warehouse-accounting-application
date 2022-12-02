

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
            }
            var menu = new Menu(_appDbContext);
            await menu.MainMenuAsync();

        }

    }

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



