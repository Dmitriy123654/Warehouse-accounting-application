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

            //var insertUsersDb = new InsertUsersDb(db);
            //await insertUsersDb.AddInformationInBdAsync();

            //var insertEmployeeDb = new InsertEmployeeDb(db);
            //await insertEmployeeDb.AddInformationInBdAsync();
            
            //var insertProductDb = new InsertProductDb(db);
            //await insertProductDb.AddInformationInBdAsync();

        }
    }
}
