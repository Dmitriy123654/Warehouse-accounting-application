namespace WarehouseInformationSystem.model
{
    public class Location
    {
        [Key]
        public int WarehouseNumber { get; set; }//номер склада
        public int RackNumber { get; set; }//стеллаж
        public int ShelfNumber { get; set; }//полка
        //связи:
        //товары
        public List<Product> Products { get; set; } = new();//товары склада
        //адрес
        public int AddressId { get; set; }
        public Address? Address { get; set; }
    }
}
