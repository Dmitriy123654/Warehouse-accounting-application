namespace WarehouseInformationSystem.Controller
{
    public class InsertDatabase
    {
        private readonly ApplicationDbContext? db;
        public InsertDatabase(ApplicationDbContext? _db)
        {
            db = _db;
        }
        public void AddInformationInBd()
        {
            //var insertAddressDb = new InsertAddressDb(db);
            //insertAddressDb.AddInformationInBd();

            //var insertCategoryOfProductDb = new InsertCategoryOfProductDb(db);
            //insertCategoryOfProductDb.AddInformationInBd();

            var insertEmployeeDb = new InsertEmployeeDb(db);
            insertEmployeeDb.AddInformationInBd();


        }
    }
}
