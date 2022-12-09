namespace WarehouseInformationSystem.Controller
{
    public class RecieveBdInformation
    {
        private readonly ApplicationDbContext? db;
        
        public RecieveBdInformation(ApplicationDbContext? _db)
        {
            db = _db;
            
        }
        public List<Employee> RecieveEmployees()
        {
            var employees = db!.Employees.Include(u => u.Department)
                                         .Include(u => u.Post)
                                         .OrderBy(u => u.Name)
                                         .ThenByDescending(u => u.SecondName)
                                         //.OrderByDescending(u => u.DepartmentId)
                                         .ThenByDescending(u => u.Salary)
                                         .ToList();
            return employees;
        }
        public List<Product> RecieveProducts()
        {
            var products = db!.Products.Include(u => u.CategoryOfProduct)
                                       .Include(u => u.Location)
                                            .ThenInclude(u => u!.Address)
                                            .OrderBy(u => u.Location!.AddressId)
                                            .ThenBy(u => u.CategoryOfProductId)
                                            .ThenBy(u => u.Name)
                                       .ToList();
            return products;
        }
        public (List<Address>, List<Product>) RecieveAddressesAndProducts()
        {
            var addresses = db!.Addresses.Include(u => u.Locations)
                                         .ToList();
            var products = db!.Products.Include(u => u.CategoryOfProduct)
                                       .OrderBy(u => u.Location!.AddressId)
                                            .ThenBy(u => u.CategoryOfProductId)
                                            .ThenBy(u => u.Name)
                                       .ToList();
            return (addresses, products);
        }
    }
}
