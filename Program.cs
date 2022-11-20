
//using Microsoft.Extensions.Configuration;
//using System.Text;

namespace WarehouseInformationSystem
{
    public class Program
    {
        private static ApplicationDbContext? _appDbContext;
        public static void Main(string[] args)
        {

           var builder = WebApplication.CreateBuilder();

            var services = new ServiceCollection();
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            var serviceProvider = services.BuildServiceProvider();
            _appDbContext = serviceProvider.GetService<ApplicationDbContext>();

            var TESTinsertDb = new InsertDatabase(_appDbContext);
            TESTinsertDb.AddInformationInBd();

            var app = builder.Build();
            //app.Run();
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
}



