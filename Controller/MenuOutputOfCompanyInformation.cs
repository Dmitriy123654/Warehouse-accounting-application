namespace WarehouseInformationSystem.Controller
{
    public class MenuOutputOfCompanyInformation
    {
        private readonly ApplicationDbContext? db;
        private static Output? Output;
        public MenuOutputOfCompanyInformation(ApplicationDbContext? _db)
        {
            db = _db;
            Output = new Output(db);
        }
        public void Menu1()
        {
            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?" +
                    "\n 1. Вывести информацию об отделах компании" +
                    "\n 2. Вывести информацию о сотрудниках компании" +
                    "\n 3. Вывести информацию о складах компании и их товарах" +
                    "\n 4.Выход");
                int k1 = Menu.CheckIncomingKey(4);
                switch (k1)
                {
                    case 1:
                        Console.Clear();
                        Output?.OutputDepartments();
                        break;
                    case 2:
                        Console.Clear();
                        Output?.OutputEmployees();
                        break;
                    case 3:
                        Console.Clear();
                        Output?.OutputWarehouse();
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("default");
                        break;
                }
                if (k1 == 4)
                    break;
            }
        }
    }
}
