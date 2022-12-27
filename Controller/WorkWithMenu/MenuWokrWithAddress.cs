namespace WarehouseInformationSystem.Controller.WorkWithMenu
{
    public class MenuWokrWithAddress
    {
        private readonly ApplicationDbContext? db;
        public MenuWokrWithAddress(ApplicationDbContext? _db)
        {
            db = _db;
        }
        public async Task MenuOfAddresses()
        {
            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?" +
                   "\n 1. Добавить склад" +
                   "\n 2. Изменить адрес склада" +
                   "\n 3. Удалить  склад" +
                   "\n 4. Просмотреть склады" +
                   "\n 5.Выход");
                int k3 = Menu.CheckIncomingKey(5);
                switch (k3)
                {
                    case 1:
                        await AddAdressAsync();
                        break;
                    case 2:
                        await AlterAdressAsync();
                        break;
                    case 3:
                        await DeleteAdressAsync();
                        break;
                    case 4:
                        OutputAdresses();
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("default");
                        break;
                }
                if (k3 == 5)
                    break;
            }
        }
        public async Task AddAdressAsync()
        {
            Console.WriteLine("   Добавление новой склада");
            Console.WriteLine("Введите название: ");
            string name = Console.ReadLine() ?? "";

            Address? address = new(name);
            await db!.Addresses.AddAsync(address);
            Console.WriteLine("Склад добавлен.\n");
            await db.SaveChangesAsync();
        }
        public async Task AlterAdressAsync()
        {
            var addresses = db?.Addresses.ToList();

            Console.WriteLine("Выберите номер склада\nСклады: ");
            OutputAdresses();
            int key = Menu.CheckIncomingKey(addresses?.Count);

            for (int i = 0; i < addresses?.Count; i++)
            {
                if (key == i + 1)
                {
                    Console.WriteLine("Введите название: ");
                    string name = Console.ReadLine() ?? "";
                    addresses[i].Name = name;
                    break;
                }
            }
            Console.WriteLine();
            await db!.SaveChangesAsync();
        }
        public async Task DeleteAdressAsync()
        {
            var addresses = db?.Addresses.ToList();
            Console.WriteLine("\n Выберите номер склада который хотите удалить\n");
            OutputAdresses();
            Address? address = MenuWorkWithProduct.ChoiceWarehouse(addresses);
            if(address != null)
                db?.Remove(address);
            Console.WriteLine("Склад удален.\n");
            await db!.SaveChangesAsync();
        }
        public void OutputAdresses()
        {
            var addresses = db?.Addresses.ToList();
            for (int i = 0; i < addresses?.Count; i++)
            {
                Address address = addresses[i];
                Console.WriteLine($"{i + 1}. {address.Name}");
            }
            Console.WriteLine();
        }
    }
}

