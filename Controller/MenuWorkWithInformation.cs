
namespace WarehouseInformationSystem.Controller
{
    public class MenuWorkWithInformation
    {
        private readonly ApplicationDbContext? db;
        private static MenuWorkWithEmployee? MenuWorkWithEmployee;
        private static MenuWorkWithDepartment? MenuWorkWithDepartment;
        private static MenuWorkWithProduct? MenuWorkWithProduct;
        private static MenuWorkWithPost? MenuWorkWithPost;
        private static MenuWokrWithAddress? MenuWokrWithAddress;
        private static MenuWorkWithCategoryOfProduct? MenuWorkWithCategoryOfProduct;
        public MenuWorkWithInformation(ApplicationDbContext? _db)
        {
            db = _db;
            MenuWorkWithEmployee = new MenuWorkWithEmployee(db);
            MenuWorkWithDepartment = new MenuWorkWithDepartment(db);
            MenuWorkWithPost = new MenuWorkWithPost(db);

            MenuWorkWithProduct = new MenuWorkWithProduct(db);
            MenuWokrWithAddress = new MenuWokrWithAddress(db);
            MenuWorkWithCategoryOfProduct = new MenuWorkWithCategoryOfProduct(db);

        }
        public async Task Menu2Async()
        {
            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?" +
                    "\n 1. Работа с сотрудниками" +
                    "\n 2. Работа с товарами" +
                    "\n --------------------" +
                    "\n 3. Работа с отделами" +
                    "\n 4. Работа с должностями" +
                    "\n 5. Работа со складами" +
                    "\n 6. Работа с категориями товаров" +
                    "\n 7.Выход");
                int k2 = Menu.CheckIncomingKey(7);
                switch (k2)
                {
                    case 1:
                        await MenuWorkWithEmployee!.MenuOfEmployees();
                        Console.Clear();
                        break;
                    case 2:
                        await MenuWorkWithProduct!.MenuOfProducts();
                        Console.Clear();
                        break;
                    case 3:
                        await MenuWorkWithDepartment!.MenuOfDepartments();
                        Console.Clear();
                        break;
                    case 4:
                        await MenuWorkWithPost!.MenuOfPosts();
                        Console.Clear();
                        break;
                    case 5:
                        await MenuWokrWithAddress!.MenuOfAddresses();
                        Console.Clear();
                        break;
                    case 6:
                        await MenuWorkWithCategoryOfProduct!.MenuCategoryOfProducts();
                        Console.Clear();
                        break;
                    case 7:
                        break;
                    default:
                        Console.WriteLine("default");
                        break;
                }
                if (k2 == 7)
                    break;
            }
        }
    }
}
