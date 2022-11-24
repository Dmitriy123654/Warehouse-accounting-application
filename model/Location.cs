namespace WarehouseInformationSystem.Model
{
    public class Location
    {
        [Key]
        public int WarehouseNumber { get; set; }//номер склада
        [Required(ErrorMessage = "Не указан номер стеллажа")]
        public int RackNumber { get; set; }//стеллаж
        [Required(ErrorMessage = "Не указан номер полки")]
        public int ShelfNumber { get; set; }//полка
        //???
        public Location(int rackNumber, int shelfNumber)
        {
            RackNumber = rackNumber;
            ShelfNumber = shelfNumber;

        }
        //связи:
        //товары
        public List<Product> Products { get; set; } = new();//товары склада
        //адрес
        public int AddressId { get; set; }
        public Address? Address { get; set; }
        public override string ToString()
        {
            return $"Номер склада: {WarehouseNumber}\n" +
               $"Номер стеллажа: {RackNumber}\n" +
               $"Номер полки: {ShelfNumber}\n" +
               $"{Address?.Name}";
        }
    }
}
//public Location(int warehouseNumber, int rackNumber, int shelfNumber,Address? address) :this(warehouseNumber,rackNumber,shelfNumber)
//{
//    Address = address;
//    AddressId = address.Id;
//}
//public Location(int warehouseNumber, int rackNumber, int shelfNumber, int addressId) : this(warehouseNumber, rackNumber, shelfNumber)
//{
//    AddressId = addressId;
//}
