namespace WarehouseInformationSystem.Controller
{
    public class InsertDatabase
    {
        private readonly ApplicationDbContext? db;
        public InsertDatabase(ApplicationDbContext? _db)
        {
            db = _db;
            
        }
        public async Task AddInformationInBdAsync()
        {
            await AddEmployeesInBdAsync();
            await AddProductsInBdAsync();
            await AddUsersInBdAsync();
            
        }
        public async Task AddEmployeesInBdAsync()
        {
            //department
            var supplyDepartment = new Department("Отдел снабжения");
            var directorsDepartment = new Department("-");
            var salesDepartment = new Department("Отдел сбыта");
            var technicalDepartment = new Department("Технический отдел");
            var accountingDepartment = new Department("Бухгалтерия");
            var warehouseDepartment = new Department("Склад");
            var warehouseTechnicalDepartment = new Department("Склад, Технический отдел");
            var warehouseWorkDepartment = new Department("Склад, Рабочий отдел");
            var warehouseAuxiliarDepartment = new Department("Склад, Вспомогательный отдел");
            var otherDepartments = new Department("Вспомогательный");

            await db!.Departments.AddRangeAsync(supplyDepartment, salesDepartment, technicalDepartment, accountingDepartment,
                warehouseDepartment, warehouseTechnicalDepartment, warehouseWorkDepartment, warehouseAuxiliarDepartment, otherDepartments);
            await db.SaveChangesAsync();

            //post
            var director = new Post("Директор Компании");
            var technicalDirector = new Post("Технический директор");
            var mainTechnologist = new Post("Главный технолог");

            var chiefAccountant = new Post("Главный бухгалтер");
            var accountant = new Post("Бухгалтер");

            var managerOfDepartment = new Post("Менеджер отдела");
            var engineerOfDepartment = new Post("Инженер отдела");
            var specialistOfDepartment = new Post("Специалист отдела");

            var headWarehouses = new Post("Заведующий складами");
            var headWarehouse = new Post("Заведующий склада");
            var shiftSupervisor1 = new Post("Начальник смены: 1");
            var shiftSupervisor2 = new Post("Начальник смены: 2");
            var shiftSupervisor3 = new Post("Начальник смены: 3");

            var maintenanceSpecialist = new Post("Специалист по обсуживанию систем");
            var electrician = new Post("Электрик");

            var loader = new Post("Грузчик");
            var auxiliaryWorker = new Post("Подсобный рабочий");
            var storekeeper = new Post("Кладовщик");
            var undertaker = new Post("Гробовщик");

            var cleaner = new Post("Уборщик");
            var security = new Post("Охранник");
            var driver = new Post("Водитель");


            await db.Posts.AddRangeAsync(director, technicalDirector, mainTechnologist, chiefAccountant, accountant,
                managerOfDepartment, engineerOfDepartment, specialistOfDepartment, headWarehouses, headWarehouse, shiftSupervisor1, shiftSupervisor2, shiftSupervisor3,
                maintenanceSpecialist, electrician, loader, auxiliaryWorker, storekeeper, undertaker, cleaner, security, driver);
            await db.SaveChangesAsync();


            //employee
            var dmitriy1 = new Employee("Дмитрий", 19, "Ермак", "375334895261", 2500)
            {
                Department = directorsDepartment,
                Post = director
            };

            var tom1 = new Employee("Том", 27, "Ключев", "+375336897278", 2000)
            {
                Department = technicalDepartment,
                Post = technicalDirector
            };

            //var tom1 = new Employee { Name = "Том", Age = 27, SecondName = "Ключев", Phone = "375336897278", Salary =2000 , Department = technicalDepartment, Post = technicalDirector};
            var vadim1 = new Employee("Вадим", 21, "Жук", "+375292780912", 1850)
            {
                Department = supplyDepartment,
                Post = managerOfDepartment
            };

            var anna1 = new Employee("Анна", 19, "Махнович", "", 1900)
            {
                Department = accountingDepartment,
                Post = chiefAccountant
            };

            var alexandra1 = new Employee("Александра", 15, "Лозюк", "+375445110212", 1900)
            {
                Department = salesDepartment,
                Post = managerOfDepartment
            };

            var anton1 = new Employee("Антон", 15, "Коллаур", "+375446589633", 1650)
            {
                Department = warehouseDepartment,
                Post = headWarehouses
            };
            await db!.Employees.AddRangeAsync(dmitriy1, tom1, vadim1, anna1, alexandra1, anton1);
            await db.SaveChangesAsync();

        }
        public async Task AddProductsInBdAsync()
        {

            //addresses
            var address1 = new Address("Якуба Коласа 28, Минск");
            var address2 = new Address("Дзержинского 95, Минск");
            var address3 = new Address("Гикало 9, Минск");
            await db!.Addresses.AddRangeAsync(address1,address2,address3);
            await db.SaveChangesAsync();

            //Locations
            //sklad1
            var sklad1_12_3 = new Location(12, 3) { Address = address1};
            var sklad1_2_4 = new Location(2, 4) { Address = address1 };
            var sklad1_3_5 = new Location(3, 5) { Address = address1 };
            var sklad1_3_2 = new Location(3, 2) { Address = address1 };
            var sklad1_20_1 = new Location(20, 1){ Address = address1}; 
            var sklad1_17_4 = new Location(17, 4) { Address = address1}; 
            var sklad1_11_2 = new Location(11, 2) { Address = address1 };
            await db.Locations.AddRangeAsync(sklad1_12_3, sklad1_2_4, sklad1_3_5, sklad1_3_2, sklad1_20_1, sklad1_17_4, sklad1_11_2);
            //sklad2
            var sklad2_1_3 = new Location(1, 3) { Address = address2 };
            var sklad2_2_4 = new Location(2, 4) { Address = address2 };
            var sklad2_3_5 = new Location(3, 5) { Address = address2 };
            var sklad2_10_2 = new Location(10, 2) { Address = address2 };
            await db.Locations.AddRangeAsync(sklad2_1_3, sklad2_2_4, sklad2_3_5, sklad2_10_2);
            //sklad3
            var sklad3_5_1 = new Location(5, 1) { Address = address3 };
            var sklad3_17_3 = new Location(17, 3) { Address = address3 };
            var sklad3_11_3 = new Location(11, 3) { Address = address3 };
            var sklad3_4_2 = new Location(4, 2) { Address = address3 };
            await db.Locations.AddRangeAsync(sklad3_5_1, sklad3_17_3, sklad3_11_3, sklad3_4_2);
            await db.SaveChangesAsync();

            //CategoryOfProduct
            var mobilePhone = new CategoryOfProduct("Мобильный телефон");
            var videoCard = new CategoryOfProduct("Видео карта");
            var laptop = new CategoryOfProduct("Ноутбук");
            var powerSupply = new CategoryOfProduct("Блок Питания");
            var cpu = new CategoryOfProduct("CPU");
            var ssd = new CategoryOfProduct("SSD");
            var hdd = new CategoryOfProduct("HDD");
            var gpu = new CategoryOfProduct("GPU");
            await db.CategoryOfProducts.AddRangeAsync(mobilePhone, videoCard, laptop, 
                powerSupply, cpu, ssd, hdd, gpu);
            await db.SaveChangesAsync();

            //Product
            //sklad 1
            var XiomiRedmiNote8Pro = new Product("Xiaomi Note 8 Pro",
                "Android, экран 6.53 IPS(1080x2340), Mediatek Helio G90T, ОЗУ 6 ГБ, флэш - память 128 ГБ, карты 64 Мп, 4500 мАч, 2 SIM, влагозащита IP52", 500, 370)
            {
                Location = sklad1_12_3,
                CategoryOfProduct = mobilePhone
            };

            var iPhone14_128_black = new Product("Apple iPhone 14(black)",
                "Apple iOS, экран 6.1 OLED(1170x2532), Apple A15 Bionic, ОЗУ 6 ГБ, флэш - память 128 ГБ, камера 12 Мп, 1 SIM, влагозащита IP68", 2440, 2000)
            {
                Location = sklad1_2_4,
                CategoryOfProduct = mobilePhone
            };

            var iPhone14_256_black = new Product("Apple iPhone 14(black)",
                "Apple iOS, экран 6.1 OLED(1170x2532), Apple A15 Bionic, ОЗУ 6 ГБ, флэш - память 256 ГБ, камера 12 Мп, 1 SIM, влагозащита IP68", 2859, 2250)
            {
                Location = sklad1_3_5,
                CategoryOfProduct = mobilePhone
            };

            var iPhone14_512_white = new Product("Apple iPhone 14(white)",
               "Apple iOS, экран 6.1 OLED(1170x2532), Apple A15 Bionic, ОЗУ 6 ГБ, флэш - память 512 ГБ, камера 12 Мп, 1 SIM, влагозащита IP68", 3315, 2400)
            {
                Location = sklad1_3_2,
                CategoryOfProduct = mobilePhone
            };

            var LenovoLegion5_15ACH6H_1 = new Product("Lenovo Legion 5 15ACH6H 82JU00TGPB",
                "15.6 1920 x 1080 IPS, 165 Гц, несенсорный, AMD Ryzen 5 5600H 3300 МГц, 16 ГБ DDR4, SSD 512 ГБ, " +
                "видеокарта NVIDIA GeForce RTX 3060 6 ГБ, Windows 11, цвет крышки темно-синий", 3700, 3000)
            {
                Location = sklad1_20_1,
                CategoryOfProduct = laptop
            };
            var LenovoLegion5_15ACH6H_2 = new Product("Lenovo Legion 5 15ACH6H 82JU00JKPB",
                "15.6 1920 x 1080 IPS, 165 Гц, несенсорный, AMD Ryzen 7 5800H 3200 МГц, 16 ГБ DDR4, SSD 1024 ГБ," +
                " видеокарта NVIDIA GeForce RTX 3060 6 ГБ, без ОС, цвет крышки темно - синий", 4329, 3700)
            {
                Location = sklad1_17_4,
                CategoryOfProduct = laptop
            };

            var XiaomiMiNotebookPro15 = new Product("Xiaomi Mi Notebook Pro 15 2021 Ryzen Edition JYU4332CN",
                "15.6 3456 x 2160 OLED, 60 Гц, несенсорный, AMD Ryzen 7 5800H 3200 МГц, 16 ГБ DDR4, SSD 512 ГБ, видеокарта встроенная, цвет крышки серебристый", 3717, 3100)
            {
                Location = sklad1_11_2,
                CategoryOfProduct = laptop
            };
            await db.Products.AddRangeAsync(XiomiRedmiNote8Pro, iPhone14_128_black, iPhone14_256_black, iPhone14_512_white, 
                LenovoLegion5_15ACH6H_1, LenovoLegion5_15ACH6H_2, XiaomiMiNotebookPro15);
            await db.SaveChangesAsync();
            //-------------------------
            //sklad 2
            var XiaomiRedmiBook16 = new Product("Xiaomi RedmiBook 16 JYU4277CN",
                "16.1 1920 x 1080 IPS, 60 Гц, несенсорный, AMD Ryzen 5 4500U 2300 МГц, 16 ГБ DDR4, SSD 512 ГБ, видеокарта встроенная, цвет крышки темно - серый", 2880, 2300)
            {
                Location = sklad2_1_3,
                CategoryOfProduct = laptop
            };

            var ASUSTUFGamingA15 = new Product("ASUS TUF Gaming A15 FA506IC-HN042",
                "15.6 1920 x 1080 IPS, 144 Гц, несенсорный, AMD Ryzen 5 4600H 3000 МГц, 8 ГБ DDR4, SSD 512 ГБ, " +
                "видеокарта NVIDIA GeForce RTX 3050 4 ГБ, без ОС, цвет крышки черный", 2600, 2200)
            {
                Location = sklad2_2_4,
                CategoryOfProduct = laptop
            };

            var iPhone14ProMax_256GB_Purple = new Product("Apple iPhone 14 Pro Max 256GB (темно-фиолетовый)",
                "Apple iOS, экран 6.7 OLED (1290x2796), Apple A16 Bionic, ОЗУ 6 ГБ, флэш-память 256 ГБ, камера 48 Мп, аккумулятор 4323 мАч, 1 SIM, влагозащита IP68",4680,3800)
            {
                Location = sklad2_3_5,
                CategoryOfProduct = mobilePhone
            };
            var iPhone14ProMax_512GB_Purple = new Product("Apple iPhone 14 Pro Max 512GB (темно-фиолетовый)",
                "Apple iOS, экран 6.7 OLED(1290x2796), Apple A16 Bionic, ОЗУ 6 ГБ, флэш - память 512 ГБ, камера 48 Мп, аккумулятор 4323 мАч, 1 SIM, влагозащита IP68",5000,4300)
            {
                Location = sklad2_10_2,
                CategoryOfProduct = mobilePhone
            };
            await db.Products.AddRangeAsync(XiaomiRedmiBook16, ASUSTUFGamingA15, iPhone14ProMax_256GB_Purple, iPhone14ProMax_512GB_Purple);
            await db.SaveChangesAsync();
            //-------------------------
            //sklad 3
            var SSDKingstonA400_960GB = new Product("SSD Kingston A400 960GB SA400S37/960G",
                "960 ГБ, 2.5, SATA 3.0, микросхемы 3D TLC NAND, последовательный доступ: 500 / 450 MBps", 218, 190)
            {
                Location = sklad3_5_1,
                CategoryOfProduct = ssd
            };
            var SSDKingstonA400_1920GB = new Product("SSD Kingston A400 1.92TB SA400S37/1920G",
                "1.92 ТБ, 2.5, SATA 3.0, микросхемы 3D TLC NAND, последовательный доступ: 500 / 450 MBps", 710, 560)
            {
                Location = sklad3_17_3,
                CategoryOfProduct = ssd
            };
            
            var SSDSamsung870Evo_1TB = new Product("SSD Samsung 870 Evo 1TB MZ-77E1T0BW",
                "1 ТБ, 2.5, SATA 3.0, контроллер Samsung MKX, микросхемы 3D TLC NAND, последовательный доступ: 560 / 530 MBps, случайный доступ: 98000 / 88000 IOps", 300, 250)
            {
                Location = sklad3_11_3,
                CategoryOfProduct = ssd
            };
            var SSDSamsung870Evo_2TB = new Product("SSD Samsung 870 Evo 2TB MZ-77E2T0BW",
               "2 ТБ, 2.5, SATA 3.0, контроллер Samsung MKX, микросхемы 3D TLC NAND, последовательный доступ: 560 / 530 MBps, случайный доступ: 98000 / 88000 IOps", 570, 500)
            {
                Location = sklad3_4_2,
                CategoryOfProduct = ssd
            };
            await db.Products.AddRangeAsync(SSDKingstonA400_960GB, SSDKingstonA400_1920GB, SSDSamsung870Evo_1TB, SSDSamsung870Evo_2TB);
            await db.SaveChangesAsync();

        }
        public async Task AddUsersInBdAsync()
        {
            var dmitriy1 = new User("Дмитрий", 19, "Ермак", "+375334895261");
            var tom1 = new User("Том23", 27, "Ключев", "+375336897278");
            var vadim1 = new User("Вади23м", 21, "Жук", "+375292780912");
            var anna1 = new User("Анна2", 19, "Махнович", "");
            await db!.Users.AddRangeAsync(dmitriy1, tom1, vadim1, anna1);
            await db.SaveChangesAsync();

        }

    }
}
