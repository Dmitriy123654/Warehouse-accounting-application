namespace WarehouseInformationSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { 
            // Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
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
            //modelBuilder.Entity<User>().HasIndex(u => u.Age).IsUnique();//уникальность
        }

    }
}
