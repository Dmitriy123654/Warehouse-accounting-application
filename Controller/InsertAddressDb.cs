namespace WarehouseInformationSystem.Controller
{
    public class InsertAddressDb
    {
        private readonly ApplicationDbContext? db;
        public InsertAddressDb(ApplicationDbContext? _db)
        {
            db = _db;
        }
        public void AddInformationInBd()
        {

            //для теста сделал добавление
            var address1 = new Address("Якуба Коласа 28, Минск");
            var address2 = new Address("Дзержинского 95, Минск");
            var address3 = new Address("Гикало 9, Минск");
            db?.Addresses.AddRangeAsync(address1,address2,address3);
            db?.SaveChangesAsync();

        }

    }
}
