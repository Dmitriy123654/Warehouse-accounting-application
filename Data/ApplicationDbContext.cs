namespace WarehouseInformationSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) 
        { }
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<CategoryOfProduct> CategoryOfProducts { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Location> Locations { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Property(p => p.Salary)
                .HasPrecision(20, 2);
            modelBuilder.Entity<Product>().Property(p => p.SalePrice)
                .HasPrecision(20, 2);
            modelBuilder.Entity<Product>().Property(p => p.PurchasePrice)
                .HasPrecision(20, 2);
        }
    }
    public class SampleContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            var builder = WebApplication.CreateBuilder();
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            var app = builder.Build();

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
