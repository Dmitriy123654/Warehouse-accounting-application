
namespace WarehouseInformationSystem.Controller
{
    public class MenuWorkWithInformation
    {
        private readonly ApplicationDbContext? db;
        //private static Output? Output;
        private static MenuWorkWithEmployee? MenuWorkWithEmployee;
        private static MenuWorkWithDepartment? MenuWorkWithDepartment;
        private static MenuWorkWithProduct? MenuWorkWithProduct;
        private static MenuWorkWithPost? MenuWorkWithPost;
        public MenuWorkWithInformation(ApplicationDbContext? _db)
        {
            db = _db;
            //Output = new Output(db);
            MenuWorkWithEmployee = new MenuWorkWithEmployee(db);
            MenuWorkWithDepartment = new MenuWorkWithDepartment(db);
            MenuWorkWithProduct = new MenuWorkWithProduct(db);
            MenuWorkWithPost = new MenuWorkWithPost(db);
        }
        public async Task Menu2Async()
        {
            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?" +
                    "\n 1. Работа с сотрудниками(добавление,изменение,увольнение)" +
                    "\n 2. Работа с товарами(добавление,изменение,удаление)" +
                    "\n -----------------------------------------------" +
                    "\n 3. Работа с отделами(добавление,изменение,удаление)" +
                    "\n 4. Работа с должностями(добавление,изменение,удаление)" +
                    "\n 5. Работа со складами(адресами)(добавление,изменение,удаление)" +
                    "\n 6. Работа с категориями товаров(добавление,изменение,удаление)" +
                    "\n 7. Работа с расположением товара(добавление,изменение)" +
                    "\n 8.Выход");
                int k2 = Menu.CheckIncomingKey(8);
                switch (k2)
                {
                    case 1:
                        await MenuWorkWithEmployee?.MenuOfEmployees();
                        Console.Clear();
                        break;
                    case 2:
                        await MenuWorkWithProduct.MenuOfProducts();
                        Console.Clear();
                        break;
                    case 3:
                        await MenuWorkWithPost.MenuOfPosts();
                        Console.Clear();
                        break;
                    case 4:
                        await MenuWorkWithDepartment?.MenuOfDepartments();
                        Console.Clear();
                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                    case 7:

                        break;
                    case 8:
                        break;
                    default:
                        Console.WriteLine("default");
                        break;
                }
                if (k2 == 8)
                    break;
            }
        }


    }
}
