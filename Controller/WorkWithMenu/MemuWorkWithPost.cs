namespace WarehouseInformationSystem.Controller.WorkWithMenu
{
    public class MenuWorkWithPost
    {
        private readonly ApplicationDbContext? db;
        private static Output? Output;
        public MenuWorkWithPost(ApplicationDbContext? _db)
        {
            db = _db;
            Output = new Output(db);
        }
        public async Task MenuOfPosts()
        {
            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?" +
                   "\n 1. Добавить должность" +
                   "\n 2. Изменить должность" +
                   "\n 3. Удалить  должность" +
                   "\n 4. Просмотреть должности" +
                   "\n 5.Выход");
                int k3 = Menu.CheckIncomingKey(5);
                switch (k3)
                {
                    case 1:
                        await AddPostAsync();
                        break;
                    case 2:
                        await AlterPostAsync();
                        break;
                    case 3:
                        await DeletePostAsync();
                        break;
                    case 4:
                        OutputPosts();
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
        public async Task AddPostAsync()
        {
            Console.WriteLine("   Добавление новой должности");
            Console.WriteLine("Введите название: ");
            string? name = Console.ReadLine();

            Post? post = new Post(name);
            await db!.Posts.AddAsync(post);
            Console.WriteLine("Должность добавлена.\n");
            await db.SaveChangesAsync();

        }
        public async Task AlterPostAsync()
        {
            var posts = db?.Posts.ToList();

            Console.WriteLine("Выберите номер должности\nДолжность: ");
            OutputPosts();
            int key = Menu.CheckIncomingKey(posts?.Count);

            for (int i = 0; i < posts?.Count; i++)
            {
                if (key == i + 1)
                {
                    Console.WriteLine("Введите название: ");
                    string? name = Console.ReadLine();
                    posts[i].Name = name;
                    break;
                }
            }
            Console.WriteLine();
            await db!.SaveChangesAsync();
        }
        public async Task DeletePostAsync()
        {
            var posts = db?.Posts.ToList();
            Console.WriteLine("\n Выберите номер должности которую хотите удалить\n");
            OutputPosts();
            Post? post = MenuWorkWithEmployee.ChoicePost(posts);
            db.Remove(post);
            Console.WriteLine("Должность удалена.\n");
            await db.SaveChangesAsync();

        }
        public void OutputPosts()
        {
            var posts = db?.Posts.ToList();
            for (int i = 0; i < posts?.Count; i++)
            {
                Post post = posts[i];
                Console.WriteLine($"{i + 1}. {post.Name}");
            }
            Console.WriteLine();
        }
    }
}