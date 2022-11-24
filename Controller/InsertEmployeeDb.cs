namespace WarehouseInformationSystem.Controller
{
    public class InsertEmployeeDb
    {
        private readonly ApplicationDbContext? db;
        public InsertEmployeeDb(ApplicationDbContext? _db)
        {
            db = _db;
        }

        public async Task AddInformationInBdAsync()
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

            //await db.Departments.AddRangeAsync(supplyDepartment, salesDepartment, technicalDepartment, accountingDepartment,
            //    warehouseDepartment, warehouseTechnicalDepartment, warehouseWorkDepartment, warehouseAuxiliarDepartment, otherDepartments);
            //await db.SaveChangesAsync();

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


            //await db.Posts.AddRangeAsync(director, technicalDirector, mainTechnologist, chiefAccountant, accountant,
            //    managerOfDepartment, engineerOfDepartment, specialistOfDepartment, headWarehouses, headWarehouse, shiftSupervisor1, shiftSupervisor2, shiftSupervisor3,
            //    maintenanceSpecialist, electrician, loader, auxiliaryWorker, storekeeper, undertaker, cleaner, security, driver);
            //await db.SaveChangesAsync();


            //employee
            var dmitriy1 = new Employee("Дмитрий", 19,"Ермак", "375334895261",2500);
            dmitriy1.Department = directorsDepartment;
            dmitriy1.Post = director;

            var tom1 = new Employee("Том", 27, "Ключев", "+375336897278",2000);
            tom1.Department = technicalDepartment;
            tom1.Post = technicalDirector;

            //var tom1 = new Employee { Name = "Том", Age = 27, SecondName = "Ключев", Phone = "375336897278", Salary =2000 , Department = technicalDepartment, Post = technicalDirector};
            var vadim1 = new Employee("Вадим", 21, "Жук", "+375292780912",1850);
            vadim1.Department = supplyDepartment;
            vadim1.Post = managerOfDepartment;

            var anna1 = new Employee("Анна", 19, "Махнович","",1900);
            anna1.Department = accountingDepartment;
            anna1.Post = chiefAccountant;

            var alexandra1 = new Employee("Александра", 15, "Лозюк", "+375445110212", 1900);
            alexandra1.Department = salesDepartment;
            alexandra1.Post = managerOfDepartment;

            var anton1 = new Employee("Антон", 15, "Коллаур", "+375446589633", 1650);
            anton1.Department = warehouseDepartment;
            anton1.Post = headWarehouses;
            await db!.Employees.AddRangeAsync(dmitriy1,tom1,vadim1,anna1,alexandra1,anton1);
            await  db.SaveChangesAsync();

        }
    }
}
