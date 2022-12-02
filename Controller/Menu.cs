namespace WarehouseInformationSystem.Controller
{
    public class Menu
    {
        private readonly ApplicationDbContext? db;
        private static MenuOutputOfCompanyInformation? MenuOutputOfCompanyInformation;
        private static MenuWorkWithInformation? MenuWorkWithInformation;
        public Menu(ApplicationDbContext? _db)
        {
            db = _db;
            MenuOutputOfCompanyInformation = new MenuOutputOfCompanyInformation(db);
            MenuWorkWithInformation = new MenuWorkWithInformation(db);
        }


        public async Task MainMenuAsync()
        {
            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?" +
                    "\n 1. Вывести информацию о компании" +
                    "\n 2. Работа с информацией" +
                    "\n 3.Завершить работу программы");
                int k = CheckIncomingKey(3);
                switch (k)
                {
                    case 1:
                        MenuOutputOfCompanyInformation?.Menu1();
                        Console.Clear();
                        break;
                    case 2:
                        await MenuWorkWithInformation.Menu2Async();
                        Console.Clear();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("default");
                        break;
                }
                if (k == 3) break;
            }
        }


        /// <summary>
        /// Ввод и проверка введенного ключа
        /// </summary>
        /// <param name="count">Максимальный диапазон</param>
        /// <returns>Ключ</returns>
        public static int CheckIncomingKey(int? count)
        {
            while (true)
            {
                Console.Write("Введите номер: ");
                //key = Convert.ToInt32();
                int number1 = 0;
                bool canConvert = int.TryParse(Console.ReadLine(), out number1);

                if ( canConvert == true && (number1 >= 1 && number1 <= count))
                {
                    Console.WriteLine();
                    return number1;
                }
                else
                    Console.WriteLine("Вы ввели несуществующий номер,попробуйте ещё раз.");
                
            }
        }
    }
}
