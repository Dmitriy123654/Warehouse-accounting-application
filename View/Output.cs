namespace WarehouseInformationSystem.View
{
    public class Output
    {
        private readonly ApplicationDbContext? db;
        public Output(ApplicationDbContext? _db)
        {
            db = _db;
        }
        public List<type1> Departments<type1,type2>() where type1 : class
            where type2 : DbSet<type1>
        {
            // List<type1> test = db!.Departments.ToList() as List<type1>;
            //var t = db.Departments;
            return null;
        }
    }
}
