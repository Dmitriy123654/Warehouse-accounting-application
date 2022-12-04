namespace WarehouseInformationSystem.Controller.WorkWithMenu
{
    public class MenuWorkWithEmployee
    {
        private readonly ApplicationDbContext? db;
        private static Output? Output;
        private static RecieveBdInformation? RecieveBdInformation;
        public MenuWorkWithEmployee(ApplicationDbContext? _db)
        {
            db = _db;
            Output = new Output(db);
            RecieveBdInformation = new RecieveBdInformation(db);
        }
        public async Task MenuOfEmployees()
        {
            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?" +
                   "\n 1. Добавить сотрудника" +
                   "\n 2. Изменить сотрудника" +
                   "\n 3. Уволить сотрудника" +
                   "\n 4. Просмотреть сотрудников" +
                   "\n 5.Выход");
                int k3 = Menu.CheckIncomingKey(5);
                switch (k3)
                {
                    case 1:
                        await AddEmployeeAsync(); //добавление
                        Console.Clear();
                        break;
                    case 2:
                        await AlterEmployeeAsync(); //изменение
                        Console.Clear();
                        break;
                    case 3:
                        await DeleteEmployeeAsync();    //удаление
                        Console.Clear();
                        break;
                    case 4:
                        Output?.OutputEmployees();
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
        public async Task AddEmployeeAsync()
        {
            //List<Employee>? employees = RecieveEmployees();
            var posts = db?.Posts.OrderBy(u => u.Name).ToList();
            var departments = db?.Departments.OrderBy(u => u.Name).ToList();
            Console.WriteLine("   Добавление нового сотрудника");
            Console.WriteLine("Введите имя: ");
            string? name = Console.ReadLine();
            Console.WriteLine("Введите фамилию: ");
            string? secondName = Console.ReadLine();
            Console.WriteLine("Введите возраст: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите телефон: ");
            string? tel = Console.ReadLine();
            Console.WriteLine("Введите зп: ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            Department? department1 = ChoiceDepartment(departments);
            Post? post1 = ChoicePost(posts);

            var AddEmployee = new Employee(name, age, secondName, tel, salary)
            {
                Department = department1,
                Post = post1
            };
            Console.WriteLine("Элемент добавлен");
            //// Добавление
            await db!.Employees.AddAsync(AddEmployee);
            await db.SaveChangesAsync();

        }
        public async Task AlterEmployeeAsync()
        {
            var posts = db?.Posts.OrderBy(u => u.Name).ToList();
            var departments = db?.Departments.OrderBy(u => u.Name).ToList();
            List<Employee>? employees = RecieveBdInformation?.RecieveEmployees();
            Console.WriteLine("\n Выберите номер сотрудника которого хотите изменить\n");
            Output.OutputEmployees();
            Console.WriteLine(" Выберите номер сотрудника которого хотите изменить");


            Employee? employee1 = ChoiceEmployee(employees);
            while (true)
            {
                Console.WriteLine("Что вы хотите изменить?" +
                            "\n 1. Имя\n 2. Фамилию\n 3. Возраст\n 4. Отдел\n 5. Должность\n 6. Зарплату\n 7. Телефон\n 8. Посмотреть результат\n 9.Выйти назад");

                int? key = Menu.CheckIncomingKey(9);
                switch (key)
                {
                    case 1:
                        Console.Write("Введите имя: ");
                        employee1!.Name = Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Введите фамилию: ");
                        employee1!.SecondName = Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Введите возраст: ");
                        employee1!.Age = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 4:
                        Department? department = ChoiceDepartment(departments);
                        employee1!.Department = department;
                        break;
                    case 5:
                        Post? post = ChoicePost(posts);
                        employee1!.Post = post;
                        break;
                    case 6:
                        Console.Write("Введите зарплату: ");
                        employee1!.Salary = Convert.ToDecimal(Console.ReadLine());
                        break;
                    case 7:
                        Console.Write("Введите телефон: ");
                        employee1!.Phone = Console.ReadLine();
                        break;
                    case 8:
                        Console.WriteLine($"\n{employee1.Name} {employee1.SecondName} - {employee1.Age}\n" +
                           $"   Отдел: {employee1?.Department?.Name}\n" +
                           $"   Должность: {employee1?.Post?.Name}\n" +
                           $"   Зарплата: {employee1?.Salary}\n" +
                           $"   Телефон: {employee1?.Phone}\n");
                        break;
                    case 9:
                        break;
                    default:
                        Console.WriteLine("default");
                        break;
                }
                await db!.SaveChangesAsync();
                if (key == 9) break;
            }
        }
        public async Task DeleteEmployeeAsync()
        {
            List<Employee>? employees = RecieveBdInformation?.RecieveEmployees();
            Console.WriteLine("\n Выберите номер сотрудника которого хотите удалить\n");
            Output.OutputEmployees();
            Employee? employee1 = ChoiceEmployee(employees);
            db.Remove(employee1);
            await db.SaveChangesAsync();

        }

        //-----------
        //ДОБАВИТЬ ПРОВЕРКИ!!!!!!!!!!!!!!!!

        /// <summary>
        /// Выбирает отдел из уже существующих
        /// </summary>
        /// <param name="departments"></param>
        /// <returns>Выбранный отдел</returns>
        public static Department? ChoiceDepartment(List<Department>? departments)
        {
            Console.WriteLine("\nВыберите номер отдела\nОтделы: ");
            for (int i = 0; i < departments?.Count; i++)
            {
                Department department = departments[i];
                Console.WriteLine($"{i + 1}. {department.Name}");
            }
            int key = Menu.CheckIncomingKey(departments?.Count);

            Department? department1 = null;
            for (int i = 0; i < departments?.Count; i++)
            {
                if (key == i + 1)
                {
                    department1 = departments[i];
                    break;
                }
            }
            return department1;
        }
        /// <summary>
        /// Выбирает должность из уже существующих
        /// </summary>
        /// <param name="posts"></param>
        /// <returns>Выбранная должность</returns>
        public static Post? ChoicePost(List<Post>? posts)
        {
            Console.WriteLine("\nВыберите номер должности\nДолжности: ");
            for (int i = 0; i < posts?.Count; i++)
            {
                Post post = posts[i];
                Console.WriteLine($"{i + 1}. {post.Name}");
            }
            int? key = Menu.CheckIncomingKey(posts?.Count);

            Post? post1 = null;
            for (int i = 0; i < posts?.Count; i++)
            {
                if (key == i + 1)
                {
                    post1 = posts[i];
                    break;
                }
            }
            return post1;
        }
        /// <summary>
        /// Ищет сотрудника по номеру
        /// </summary>
        /// <param name="employees">Список сотрудников</param>
        /// <returns>Сотрудник</returns>
        public static Employee? ChoiceEmployee(List<Employee> employees)
        {
            int? key = Menu.CheckIncomingKey(employees?.Count);
            Employee? employee1 = null;
            for (int i = 0; i < employees?.Count; i++)
            {
                if (key == i + 1)
                {
                    employee1 = employees[i];
                    break;

                }
            }
            return employee1;
        }
    }
}
