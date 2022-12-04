namespace WarehouseInformationSystem.Controller.WorkWithMenu
{
    public class MenuWorkWithDepartment
    {
        private readonly ApplicationDbContext? db;
        private static Output? Output;
        public MenuWorkWithDepartment(ApplicationDbContext? _db)
        {
            db = _db;
            Output = new Output(db);
        }
        public async Task MenuOfDepartments()
        {
            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?" +
                   "\n 1. Добавить отдел" +
                   "\n 2. Изменить отдел" +
                   "\n 3. Удалить  отдел" +
                   "\n 4. Просмотреть отделы" +
                   "\n 5.Выход");
                int k3 = Menu.CheckIncomingKey(5);
                switch (k3)
                {
                    case 1:
                        await AddDepartmentAsync();
                        break;
                    case 2:
                        await AlterDepartmentAsync();
                        break;
                    case 3:
                        await DeleteDepartmentAsync();
                        break;
                    case 4:
                        OutputDepartments();
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
        public async Task AddDepartmentAsync()
        {
            Console.WriteLine("   Добавление нового отдела");
            Console.WriteLine("Введите название: ");
            string? name = Console.ReadLine();

            Department? department = new Department(name);
            await db!.Departments.AddAsync(department);
            Console.WriteLine("Отдел добавлен.\n");
            await db.SaveChangesAsync();

        }
        public async Task AlterDepartmentAsync()
        {
            var departments = db?.Departments.OrderBy(u => u.Name).ToList();

            Console.WriteLine("\nВыберите номер отдела\nОтделы: ");
            OutputDepartments();
            int key = Menu.CheckIncomingKey(departments?.Count);

            for (int i = 0; i < departments?.Count; i++)
            {
                if (key == i + 1)
                {
                    Console.WriteLine("Введите название: ");
                    string? name = Console.ReadLine();
                    departments[i].Name = name;
                    break;
                }
            }
            Console.WriteLine();
            await db!.SaveChangesAsync();
        }
        public async Task DeleteDepartmentAsync()
        {
            var departments = db?.Departments.OrderBy(u => u.Name).ToList();
            Console.WriteLine("\n Выберите номер отдела который хотите удалить\n");
            //OutputDepartments();
            Department? department = MenuWorkWithEmployee.ChoiceDepartment(departments);
            db.Remove(department);
            Console.WriteLine("Отдел удалён.");
            await db.SaveChangesAsync();

        }

        //public void OutputDepartments<t>(List<t> departments)
        //{
        //    //var departments = db?.Departments.ToList();
        public void OutputDepartments()
        {
            var departments = db?.Departments.OrderBy(u => u.Name).ToList();
            for (int i = 0; i < departments?.Count; i++)
            {
                Department department = departments[i];
                Console.WriteLine($"{i + 1}. {department.Name}");
            }
            Console.WriteLine();
        }
    }
}
