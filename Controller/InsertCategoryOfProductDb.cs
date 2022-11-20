namespace WarehouseInformationSystem.Controller
{
    public class InsertCategoryOfProductDb
    {
        private readonly ApplicationDbContext? db;
        public InsertCategoryOfProductDb(ApplicationDbContext? _db)
        {
            db = _db;
        }
        public void AddInformationInBd()
        {

            //для теста сделал добавление
            var mobilePhone = new CategoryOfProduct("Мобильный телефон");
            var videoCard = new CategoryOfProduct("Видео карта");
            var laptop = new CategoryOfProduct("Ноутбук");
            var powerSupply = new CategoryOfProduct("Блок Питания");
            var cpu = new CategoryOfProduct("CPU");
            var ssd = new CategoryOfProduct("SSD");
            var hdd = new CategoryOfProduct("HDD");
            var gpu = new CategoryOfProduct("GPU");
            db?.CategoryOfProducts.AddRangeAsync(mobilePhone, videoCard, laptop, powerSupply, 
                cpu, ssd, hdd, gpu);
            db?.SaveChangesAsync();

        }
    }
}
