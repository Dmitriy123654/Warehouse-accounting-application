

namespace WarehouseInformationSystem
{
    public class Program
    {
        private static ApplicationDbContext? _appDbContext;
        public static async Task Main()
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
            }
            var menu = new Menu(_appDbContext);
            await menu.MainMenuAsync();

        }
    }
}



