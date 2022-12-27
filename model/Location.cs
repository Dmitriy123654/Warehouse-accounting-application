namespace WarehouseInformationSystem.Model
{
    public class Location
    {
        [Key]
        public int WarehouseNumber { get; set; }
        [Required(ErrorMessage = "Не указан номер стеллажа")]
        public int RackNumber { get; set; }
        [Required(ErrorMessage = "Не указан номер полки")]
        public int ShelfNumber { get; set; }
        public Location(int rackNumber, int shelfNumber)
        {
            RackNumber = rackNumber;
            ShelfNumber = shelfNumber;

        }
        public List<Product> Products { get; set; } = new();
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
