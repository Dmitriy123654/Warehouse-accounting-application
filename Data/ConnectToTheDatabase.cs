namespace WarehouseInformationSystem.Data
{
    public static class ConnectToTheDatabase
    {
        public static void UseMySql()
        {
            var builder = WebApplication.CreateBuilder();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
            var app = builder.Build();
           

            
        }
    }
}
