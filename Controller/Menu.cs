namespace WarehouseInformationSystem.Controller
{
    public class Menu
    {
        private readonly ApplicationDbContext? db;
        public Menu(ApplicationDbContext? _db)
        {
            db = _db;

        }
        public async Task MainMenuAsync()
        {
            Console.WriteLine("Что вы хотите сделать?" +
                "\n 1. Вывести информацию о компании" +
                "\n 2. Работа с информацией" +
                "\n 3. ++");
            int k = Console.Read();
            switch (k)
            {
                case 1:
                    Console.WriteLine("Что вы хотите сделать?" +
                        "\n 1. Вывести информацию об отделах компании (все отделы+их сотрудники)" +
                        "\n 2. Вывести информацию о сотрудниках компании (все сотрудники,+- отдел)" +
                        "\n 3. Вывести информацию о складах компании и их товарах (#склада+товары на складе)");
                    int k1 = Console.Read();

                    switch (k1)
                    {
                        case 1:
                            OutputDepartments();
                            break;
                        case 2:
                            OutputEmployees();
                            break;

                        case 3:

                            break;
                        default:
                            break;
                    }
                    break;

                case 2:

                    Console.WriteLine("Что вы хотите сделать?" +
                        "\n 1. Работа с сотрудниками(добавление,изменение,увольнение)" +
                        "\n 2. Работа с товарами(добавление,изменение,удаление)" +
                        "\n -----------------------------------------------" +
                        "\n 3. Работа с отделами(добавление,изменение)" +
                        "\n 4. Работа с должностями(добавление,изменение,удаление)" +
                        "\n 5. Работа со складами(адресами)(добавление,изменение,удаление)" +
                        "\n 6. Работа с категориями товаров(добавление,изменение,удаление)" +
                        "\n 7. Работа с расположением товара(добавление,изменение)");
                    int k2 = Console.Read();
                    switch (k2)
                    {
                        case 1:

                            break;
                        case 2:

                            break;

                        case 3:

                            break;
                        default:
                            break;
                    }
                    break;

                case 3:

                    break;

                default:
                    break;
            }
        }
        public void OutputDepartments()
        {
            var departments = db!.Departments.Include(u => u.Employees)
                                             .ThenInclude(u => u.Post)
                                             .OrderBy(u=>u.Name)
                                             .ToList();
            foreach (Department? department in departments)
            {
                int number = 1;
                Console.WriteLine($"\t\t{department.Name}");
                if (department.Employees.Count != 0)
                {
                    foreach (Employee employee in department.Employees)
                    {
                        Console.WriteLine($"{number++}. {employee.Name} {employee.SecondName}\n" +
                            $"   Должность: {employee?.Post?.Name}\n   Зарплата: {employee?.Salary}\n");
                    }
                }
                else Console.WriteLine(" Сотрудники отсутствуют.\n");
            }
        }
        public void OutputEmployees()
        {
            var employees = db!.Employees.Include(u => u.Department)
                                         .Include(u => u.Post)
                                         .OrderByDescending(u => u.DepartmentId).ThenByDescending(u=>u.Salary)
                                         .ToList();
            int number = 1;
            Console.WriteLine("Список сотрудников компании:");
            foreach (Employee? employee in employees)
            {
                Console.WriteLine($"{number++}. {employee.Name} {employee.SecondName}\n" +
                            $"   Отдел: {employee?.Department?.Name}\n" +
                            $"   Должность: {employee?.Post?.Name}\n" +
                            $"   Зарплата: {employee?.Salary}\n" +
                            $"   Телефон: {employee?.Phone}\n\n");
            }
        }
        public void OutputWarehouse()
        {
            var addresses = db!.Addresses.Include(u => u.Locations)
                                         .ToList();
            var products = db!.Products.Include(u => u.CategoryOfProduct)
                                       .OrderBy(u=>u.Location.AddressId)
                                       .ThenBy(u=>u.CategoryOfProductId)
                                       .ThenBy(u=>u.Name)
                                       .ToList();
            foreach(var address in addresses)
            {
                Console.WriteLine($"{address.Name}\n");
                string? Category = products.First(u => address.Id == u.Location.AddressId).CategoryOfProduct.Name;
                Console.WriteLine(Category);
                foreach(Product product in products!.Where(u=>address.Id==u.Location.AddressId))
                {
                    if (product?.CategoryOfProduct?.Name == Category)
                    {
                        Console.WriteLine($"{product.Name}  - {product?.Location?.RackNumber}\n");
                        
                    }
                    else
                    {
                        
                        Category = product?.CategoryOfProduct?.Name;
                        Console.WriteLine(Category);
                        Console.WriteLine($"{product.Name}  - {product?.Location?.RackNumber}\n");
                    }
                    
                }
                //for(int i = 0; i < products.Where(u => address.Id == u.Location.AddressId).Count; i++)
                //{
                //    Product product = products[i];
                //}
                
            }
        }

    }
}
