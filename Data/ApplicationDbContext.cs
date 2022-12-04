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
        // public DbSet<DefaultUser> DefaultUsers { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySql("server=localhost;user=root;password=dimka_erm;database=UniversityCourseDb;",
        //        ServerVersion.AutoDetect("server=localhost;user=root;password=dimka_erm;database=UniversityCourseDb;"));
        //    //new MySqlServerVersion(new Version(8, 0, 25)));
        //}
        //допилить
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().HasCheckConstraint("Age", "Age > 0 AND Age < 120"); //проверка перед созданием
            modelBuilder.Entity<Location>().HasIndex(u => new { u.RackNumber, u.ShelfNumber, u.AddressId }).IsUnique();//уникальность
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

            // appsettings.json
            var builder = WebApplication.CreateBuilder();
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            var app = builder.Build();

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            return new ApplicationDbContext(optionsBuilder.Options);


        }
    }
}
