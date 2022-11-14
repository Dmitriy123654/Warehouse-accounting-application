using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test4
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    User user1 = new User { Name = "Tom", Age = 33 };
            //    User user2 = new User { Name = "Alice", Age = 26 };

            //    db.Users.AddRange(user1, user2);
            //    db.SaveChanges();
            //}
            //// получение данных
            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    var users = db.Users.ToList();
            //    Console.WriteLine("Список объектов:");
            //    foreach (User u in users)
            //    {
            //        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
            //    }
            //}

        }
    }
    /// <summary>
    /// поставщик
    /// </summary>
    public class Provider
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required(ErrorMessage = "Не указано имя пользователя")]
        public string Name { get; set; }
    }

    /// <summary>
    /// покупатель
    /// </summary>
    public class Buyer
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required(ErrorMessage = "Не указано имя покупателя")]
        public string Name { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указан адрес")] //обязательно для ввода,иначе выкинет исключение
        public string Name { get; set; }
        //связи
        public List<Location> Locations { get; set; } = new();
        

    }
    /// <summary>
    /// Категория товара
    /// </summary>
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано название")] //обязательно для ввода,иначе выкинет исключение
        public string Name { get; set; }
        //связи
        public List<Product> Products { get; set; } = new();
    }
    /// <summary>
    /// Товар
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required(ErrorMessage = "Не указано имя товара")] 
        public string? Name { get; set; }
        public decimal? SalePrice { get; set; }// цена продажи
        public decimal? PurchasePrice { get; set; }//закупочная
        //связи:
        //категория
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        //склад
        public int LocationWarehouseNumber { get; set; }// склад товара

    }
    /// <summary>
    /// Расположение
    /// </summary>
    public class Location {
        [Key]
        public int WarehouseNumber { get; set; }//номер склада
        public int RackNumber { get; set; }//стеллаж
        public int ShelfNumber { get; set; }//полка
        //связи:
        //товары
        public List<Product> Products { get; set; } = new();//товары склада
        //адрес
        public int AddressId { get; set; }
        public Address? Address { get; set; }
    }
    //public interface Person
    //{
    //    public string FirstName { get; set; }
    //    public string SecondName { get; set; }
    //    public string LastName { get; set; }
    //    public int Age  { get; set; }
    //}
    public class User 
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        public string FirstName { get; set; }
        public string? SecondName { get; set; } = "";
        public string? LastName { get; set; } = "";
        [Range(18, 100, ErrorMessage = "Недопустимый возраст")]
        public int Age { get; set; }
        //[Phone]
        public string? Phone { get; set; } = "";
        
    }
    public class Employee : User
    {
        public decimal Salary { get; set; }
        //???добавить отпуск
        //связи:
        //отдел 
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        // должность
        public int PostId { get; set; }
        public Post? Post { get; set; }

    }
    /// <summary>
    /// отдел работы
    /// </summary>
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано имя отдела")]
        public string Name { get; set; }
        //связи
        public List<Employee> Employees { get; set; } = new();
    }
    /// <summary>
    /// должность
    /// </summary>
    public class Post
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указана должность")]
        public string Name { get; set; }
        //связь
        public List<Employee> Employees { get; set; } = new();
    }
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public ApplicationContext()
        {
            //Database.EnsureCreated();
            //Database.EnsureDeleted();   // удаляем бд со старой схемой
            //Database.EnsureCreated();   // создаем бд с новой схемой
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user=root;password=dimka_erm;database=test;",
                new MySqlServerVersion(new Version(8, 0, 25)));
        }
        //допилить
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().HasCheckConstraint("Age", "Age > 0 AND Age < 120"); //проверка перед созданием
            //modelBuilder.Entity<User>().HasIndex(u => u.Age).IsUnique();//уникальность
        }
       
    }
}








//public class User
 //{
 //    public int Id { get; set; }
 //    public string? Name { get; set; }
 //    public int Age { get; set; }
 //}
 //public enum Category
 //{
 //    Mobiles,
 //    TV,
 //    Laptops
 //}
 //public enum Address
 //{
 //    Adres1,
 //    Adres2,
 //    Adres3
 //}