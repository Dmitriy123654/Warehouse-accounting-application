namespace WarehouseInformationSystem.Controller
{
    public class InsertUsersDb
    {
        private readonly ApplicationDbContext db;
        public InsertUsersDb(ApplicationDbContext _db)
        {
            db = _db;
        }
        public async Task AddInformationInBdAsync()
        {
            var dmitriy1 = new User("Дмитрий", 19, "Ермак", "+375334895261");
            var tom1 = new User("Том", 27, "Ключев", "+375336897278");
            var vadim1 = new User("Вадим", 21, "Жук", "+375292780912");
            var anna1 = new User("Анна", 19, "Махнович", "");
           // var annaTest = new User{ Name = "Аннеа", Age = 15, SecondName = "Тест", Phone = "0987654678908765435467890876543256789"};
            //var annaTest = new User("Аннеа", 15, "Тест", "0987654678908765435467890876543256789");
            await db.Users.AddRangeAsync(dmitriy1,tom1,vadim1,anna1);
            await db.SaveChangesAsync();

        }
    }
}
