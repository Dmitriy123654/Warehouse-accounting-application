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
        public Location(int warehouseNumber, int rackNumber, int shelfNumber)
        {
            WarehouseNumber = warehouseNumber;
            RackNumber = rackNumber;
            ShelfNumber = shelfNumber;
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

        //связи:
        //товары
        public List<Product> Products { get; set; } = new();//товары склада
        //адрес
        public int AddressId { get; set; }
        public Address? Address { get; set; }
        public override string ToString()
        {
            return $"WarehouseNumber: {WarehouseNumber}\n" +
               $"RackNumber: {RackNumber}\n" +
               $"ShelfNumber: {ShelfNumber}\n";
        }
    }
}
