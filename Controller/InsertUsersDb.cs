namespace WarehouseInformationSystem.Controller
{
    public class InsertUsersDb
    {
        private readonly ApplicationDbContext? db;
        public InsertUsersDb(ApplicationDbContext? _db)
        {
            db = _db;
        }
        public void AddInformationInBd()
        {

            var dmitriy1 = new User("Дмитрий", 19);
            var tom1 = new User("Том", 27,"Ключев","+375336897278");
            var vadim1 = new User("Вадим", 21, "Жук", "+375292780912");
            var anna1 = new User("Анна", 19, "Махнович");
            var annaTest = new User("Анна", 19,"Тест","");
            db?.Users.AddRangeAsync(tom1,dmitriy1,vadim1,anna1,annaTest);
            db?.SaveChangesAsync();

        }
    }
}
