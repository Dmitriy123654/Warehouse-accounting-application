namespace WarehouseInformationSystem.Controller.WorkWithMenu
{
    public class MenuWorkWithCategoryOfProduct
    {
        private readonly ApplicationDbContext? db;
        public MenuWorkWithCategoryOfProduct(ApplicationDbContext? _db)
        {
            db = _db;
        }
        public async Task MenuCategoryOfProducts()
        {
            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?" +
                   "\n 1. Добавить категорию товара" +
                   "\n 2. Изменить категорию товара" +
                   "\n 3. Удалить  категорию" +
                   "\n 4. Просмотреть категории" +
                   "\n 5.Выход");
                int k3 = Menu.CheckIncomingKey(5);
                switch (k3)
                {
                    case 1:
                        await AddCategoryOfProductAsync();
                        break;
                    case 2:
                        await AlterCategoryOfProductAsync();
                        break;
                    case 3:
                        await DeleteCategoryOfProductAsync();
                        break;
                    case 4:
                        OutputCategoryOfProducts();
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
        public async Task AddCategoryOfProductAsync()
        {
            Console.WriteLine("   Добавление новой категории");
            Console.WriteLine("Введите название: ");
            string name = Console.ReadLine() ?? "";

            CategoryOfProduct? categoryOfProduct = new (name);
            await db!.CategoryOfProducts.AddAsync(categoryOfProduct);
            Console.WriteLine("Категория добавлена.\n");
            await db.SaveChangesAsync();

        }
        public async Task AlterCategoryOfProductAsync()
        {
            var categoryOfProducts = db?.CategoryOfProducts.ToList();

            Console.WriteLine("Выберите номер категории\nКатегории: ");
            OutputCategoryOfProducts();
            int key = Menu.CheckIncomingKey(categoryOfProducts?.Count);

            for (int i = 0; i < categoryOfProducts?.Count; i++)
            {
                if (key == i + 1)
                {
                    Console.WriteLine("Введите название: ");
                    string name = Console.ReadLine() ?? "";
                    categoryOfProducts[i].Name = name;
                    break;
                }
            }
            Console.WriteLine();
            await db!.SaveChangesAsync();
        }
        public async Task DeleteCategoryOfProductAsync()
        {
            var categoryOfProducts = db?.CategoryOfProducts.ToList();
            Console.WriteLine("\n Выберите номер категории которую хотите удалить\n");
            OutputCategoryOfProducts();
            CategoryOfProduct? categoryOfProduct = MenuWorkWithProduct.ChoiceCategoryOfProduct(categoryOfProducts);
            if(categoryOfProduct != null)
                db?.Remove(categoryOfProduct);
            Console.WriteLine("Категория удалена.\n");
            await db!.SaveChangesAsync();

        }
        public void OutputCategoryOfProducts()
        {
            var categoryOfProducts = db?.CategoryOfProducts.ToList();
            for (int i = 0; i < categoryOfProducts?.Count; i++)
            {
                CategoryOfProduct categoryOfProduct = categoryOfProducts[i];
                Console.WriteLine($"{i + 1}. {categoryOfProduct.Name}");
            }
            Console.WriteLine();
        }
        

    }
 
}
