
namespace WarehouseInformationSystem.View
{
    public class Output
    {
        private readonly ApplicationDbContext? db;
        private static RecieveBdInformation? RecieveBdInformation;
        public Output(ApplicationDbContext? _db)
        {
            db = _db;
            RecieveBdInformation = new RecieveBdInformation(db);
        }
       
        public void OutputEmployees()
        {
            List<Employee>? employees = RecieveBdInformation!.RecieveEmployees();
            int number = 1;
            Console.WriteLine("Список сотрудников компании:");
            foreach (Employee? employee in employees)
            {
                Console.WriteLine($"{number++}. {employee.Name} {employee.SecondName} - {employee.Age}\n" +
                            $"   Отдел: {employee?.Department?.Name}\n" +
                            $"   Должность: {employee?.Post?.Name}\n" +
                            $"   Зарплата: {employee?.Salary}\n" +
                            $"   Телефон: {employee?.Phone}\n");
            }
        }
        public void OutputWarehouse()
        {
            var (addresses,products) = RecieveBdInformation!.RecieveAddressesAndProducts();
            
            int numberWarehouse = 1;
            int allProduct = 0;
            foreach (var address in addresses)
            {
                Console.WriteLine($"\tСклад {numberWarehouse++}: {address.Name}");
               try { 
                    string? Category = products?.First(u => address.Id == u.Location?.AddressId)?.CategoryOfProduct?.Name;
                    Console.WriteLine($"\n   {Category}");
                    int numberProduct = 1;
                    OutputProductsSupportive(address, products, Category, ref numberProduct, ref allProduct);
                    numberProduct = 1;
                    Console.WriteLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Склад пустой");
                }
            }
            Console.WriteLine($"\nОбщая статистика: ");
            Console.WriteLine($"  Всего товаров на всех складах: {allProduct}\n");
                
        }
        public void OutputProducts()
        {
            var (addresses, products) = RecieveBdInformation!.RecieveAddressesAndProducts();
            int numberWarehouse = 1;
            int allProduct = 0;
            int numberProduct = 1;
            foreach (var address in addresses)
            {
                try
                {
                    Console.WriteLine($"\tСклад {numberWarehouse++}: {address.Name}");
                    string? Category = products.First(u => address.Id == u.Location?.AddressId)?.CategoryOfProduct?.Name;
                    Console.WriteLine($"\n   {Category}");
                    OutputProductsSupportive(address, products, Category, ref numberProduct, ref allProduct);
                    Console.WriteLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Склад пустой");
                }

            }
            Console.WriteLine($"\nОбщая статистика: ");
            Console.WriteLine($"  Всего товаров на всех складах: {allProduct}\n");

        }
        public void OutputDepartments()
        {
            var departments = db!.Departments.Include(u => u.Employees)
                                             .ThenInclude(u => u.Post)
                                             .OrderBy(u => u.Name)
                                             .ToList();
            foreach (Department? department in departments)
            {
                int number = 1;
                Console.WriteLine($"\t\t{department.Name}");
                if (department.Employees.Count != 0)
                {
                    foreach (Employee employee in department.Employees)
                    {
                        Console.WriteLine($"{number++}. {employee.Name} {employee.SecondName}" +
                            $"\n   Должность: {employee?.Post?.Name}\n   Зарплата: {employee?.Salary}\n");
                    }
                }
                else Console.WriteLine(" Сотрудники отсутствуют.\n");
            }
        }
       
        public void OutputProductsSupportive(Address address,List<Product>? products,string? Category, ref int numberProduct,ref int allProduct)
        {
            foreach (Product product in products!.Where(u => address.Id == u.Location.AddressId))
            {
                if (product?.CategoryOfProduct?.Name == Category)
                {
                    Console.WriteLine($"{numberProduct++}. {product?.Name} - {product?.Location?.RackNumber}|{product?.Location?.ShelfNumber} " +
                        $"\n   Цена продажи|закупки: {product?.SalePrice}|{product?.PurchasePrice} ");
                    ++allProduct;


                }
                else
                {
                    Category = product?.CategoryOfProduct?.Name;
                    Console.WriteLine($"\n   {Category}");
                    Console.WriteLine($"{numberProduct++}. {product?.Name} - {product?.Location?.RackNumber}|{product?.Location?.ShelfNumber} " +
                        $"\n   Цена продажи|закупки: {product?.SalePrice}|{product?.PurchasePrice} ");
                    ++allProduct;
                }
            }
        }

    }
}
