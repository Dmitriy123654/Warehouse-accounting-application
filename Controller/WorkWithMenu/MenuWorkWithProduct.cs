namespace WarehouseInformationSystem.Controller.WorkWithMenu
{
    public class MenuWorkWithProduct
    {
        private readonly ApplicationDbContext? db;
        private static Output? Output;
        private static RecieveBdInformation? RecieveBdInformation;
        public MenuWorkWithProduct(ApplicationDbContext? _db)
        {
            db = _db;
            Output = new Output(db);
            RecieveBdInformation = new RecieveBdInformation(db);
        }
        public async Task MenuOfProducts()
        {
            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?" +
                   "\n 1. Добавить товар" +
                   "\n 2. Изменить товар" +
                   "\n 3. Удалить товар" +
                   "\n 4. Посмотреть характеристики товара" +
                   "\n 5. Просмотреть список товаров" +
                   "\n 6.Выход");
                int k3 = Menu.CheckIncomingKey(6);
                switch (k3)
                {
                    case 1:
                        await AddProductAsync(); //добавление
                        Console.Clear();
                        break;
                    case 2:
                        await AlterProductAsync(); //изменение
                        Console.Clear();
                        break;
                    case 3:
                        await DeleteProductAsync();    //удаление
                        Console.Clear();
                        break;
                    case 4:
                        await OutputCharacteristic();
                        break;
                    case 5:
                        Output?.OutputWarehouse();
                        break;
                    case 6:
                        break; ;
                    default:
                        Console.WriteLine("default");
                        break;
                }
                if (k3 == 6)
                    break;
            }
        }
        public async Task AddProductAsync()
        {
            var categoryOfProducts = db?.CategoryOfProducts.OrderBy(u => u.Name).ToList();
            var addresses = db?.Addresses.ToList();
            Console.WriteLine("   Добавление нового товара");
            Console.WriteLine("Введите название: ");
            string name = Console.ReadLine() ?? "";
            Console.WriteLine("Введите цену продажи: ");
            decimal salePrice = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Введите цену закупки: ");
            decimal? purchasePrice = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Введите характеристики: ");
            string characteristic = Console.ReadLine() ?? "";  

            CategoryOfProduct? categoryOfProduct = ChoiceCategoryOfProduct(categoryOfProducts);
            Address? warehouse = ChoiceWarehouse(addresses);

            Console.WriteLine("Введите номер стеллажа: ");
            int rackNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите номер полки: ");
            int shelfNumber = Convert.ToInt32(Console.ReadLine());
            var skladLocation = new Location(rackNumber, shelfNumber) { Address = warehouse };

            var AddProduct = new Product(name, characteristic, salePrice, purchasePrice)
            {
                Location = skladLocation,
                CategoryOfProduct = categoryOfProduct
            };
            Console.WriteLine("Элемент добавлен");
            //// Добавление
            await db!.Products.AddAsync(AddProduct);
            await db.SaveChangesAsync();

        }
        public async Task AlterProductAsync()
        {
            var addresses = db?.Addresses.ToList();
            var categoryOfProducts = db?.CategoryOfProducts.OrderBy(u => u.Name).ToList();
            List<Product> products = RecieveBdInformation!.RecieveProducts();
            Console.WriteLine("\n Выберите номер товара который хотите изменить\n");
            Output?.OutputProducts();
            Console.WriteLine(" Выберите номер товара который хотите изменить");

            Product? product1 = ChoiceProduct(products);
            while (true)
            {
                Console.WriteLine("Что вы хотите изменить?" +
                            "\n 1. Название\n 2. Цену продажи\n 3. Цену закупки\n 4. Характеристики\n 5. Категория товара\n 6. Номер стеллажа\n 7. Номер полки\n 8. Склад\n 9. Посмотреть результат\n10.Выйти назад");

                int? key = Menu.CheckIncomingKey(10);
                switch (key)
                {
                    case 1:
                        Console.Write("Введите имя: ");
                        product1!.Name = Console.ReadLine() ?? "";
                        break;
                    case 2:
                        Console.Write("Введите цену продажи: ");
                        product1!.SalePrice = Convert.ToDecimal(Console.ReadLine());
                        break;
                    case 3:
                        Console.Write("Введите цену закупки: ");
                        product1!.PurchasePrice = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 4:
                        Console.Write("Введите характеристики: ");
                        product1!.Characteristic = Console.ReadLine() ?? "";
                        break;
                    case 5:
                        CategoryOfProduct? categoryOfProduct = ChoiceCategoryOfProduct(categoryOfProducts);
                        product1!.CategoryOfProduct = categoryOfProduct;
                        break;
                    case 6:
                        Console.Write("Введите номер стеллажа: ");
                        product1!.Location!.RackNumber = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 7:
                        Console.Write("Введите номер полки: ");
                        product1!.Location!.ShelfNumber = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 8:
                        Address? address = ChoiceWarehouse(addresses);
                        product1!.Location!.Address = address;
                        break;
                    case 9:
                        Console.WriteLine($"{product1?.Name} - {product1?.CategoryOfProduct?.Name}" +
                            $"\n Адрес склада: {product1?.Location?.Address?.Name}" +
                            $"\n Стеллаж|полка: {product1?.Location?.RackNumber}|{product1?.Location?.ShelfNumber} " +
                            $"\n Цена продажи|закупки: {product1?.SalePrice}|{product1?.PurchasePrice} " +
                            $"\n Характеристики: {product1?.Characteristic} \n");
                        break;
                    case 10:
                        break;
                    default:
                        Console.WriteLine("default");
                        break;
                }
                await db!.SaveChangesAsync();
                if (key == 10) break;
            }
        }
        public async Task DeleteProductAsync()
        {
            List<Product> products = RecieveBdInformation!.RecieveProducts();
            Console.WriteLine("\n Выберите номер товара который хотите удалить\n");
            Output!.OutputProducts();
            Product? product = ChoiceProduct(products);
            if(product != null)
                db?.Remove(product);
            Console.WriteLine("Товар удален.");
            await db!.SaveChangesAsync();

        }
        public async Task OutputCharacteristic()
        {
            List<Product> products = RecieveBdInformation!.RecieveProducts();
            Console.WriteLine("\n Выберите номер товара, характеристики которого хотите просмотреть\n");
            Output!.OutputProducts();
            Product? product1 = ChoiceProduct(products);
            Console.WriteLine($"{product1?.Name} - {product1?.CategoryOfProduct?.Name}" +
                            $"\n Адрес склада: {product1?.Location?.Address?.Name}" +
                            $"\n Стеллаж|полка: {product1?.Location?.RackNumber}|{product1?.Location?.ShelfNumber} " +
                            $"\n Цена продажи|закупки: {product1?.SalePrice}|{product1?.PurchasePrice} " +
                            $"\n Характеристики: {product1?.Characteristic} \n");
            await db!.SaveChangesAsync();

        }
        //-----------
        //ДОБАВИТЬ ПРОВЕРКИ!!!!!!!!!!!!!!!!

        /// <summary>
        /// Выбирает категорию из уже существующих
        /// </summary>
        /// <param name="departments"></param>
        /// <returns>Выбранная категория</returns>
        public static CategoryOfProduct? ChoiceCategoryOfProduct(List<CategoryOfProduct>? categoryOfProducts)
        {
            Console.WriteLine("\nВыберите номер категории товара\nКатегории: ");
            for (int i = 0; i < categoryOfProducts?.Count; i++)
            {
                CategoryOfProduct categoryOfProduct = categoryOfProducts[i];
                Console.WriteLine($"{i + 1}. {categoryOfProduct.Name}");
            }
            int key = Menu.CheckIncomingKey(categoryOfProducts?.Count);

            CategoryOfProduct? categoryOfProduct1 = null;
            for (int i = 0; i < categoryOfProducts?.Count; i++)
            {
                if (key == i + 1)
                {
                    categoryOfProduct1 = categoryOfProducts[i];
                    break;
                }
            }
            return categoryOfProduct1;
        }
        /// <summary>
        /// Выбирает склад из уже существующих
        /// </summary>
        /// <param name="posts"></param>
        /// <returns>Выбранный склад</returns>
        public static Address? ChoiceWarehouse(List<Address>? addresses)
        {
            Console.WriteLine("\nВыберите номер склада\nСклады: ");
            for (int i = 0; i < addresses?.Count; i++)
            {
                Address address = addresses[i];
                Console.WriteLine($"{i + 1}. {address.Name}");
            }
            int? key = Menu.CheckIncomingKey(addresses?.Count);

            Address? address1 = null;
            for (int i = 0; i < addresses?.Count; i++)
            {
                if (key == i + 1)
                {
                    address1 = addresses[i];
                    break;
                }
            }
            return address1;
        }
        /// <summary>
        /// Ищет товар по номеру
        /// </summary>
        /// <param name="employees">Список сотрудников</param>
        /// <returns>Товар</returns>
        public static Product? ChoiceProduct(List<Product> products)
        {
            int? key = Menu.CheckIncomingKey(products?.Count);
            Product? product1 = null;
            for (int i = 0; i < products?.Count; i++)
            {
                if (key == i + 1)
                {
                    product1 = products[i];
                    break;

                }
            }
            return product1;
        }
    }
}
