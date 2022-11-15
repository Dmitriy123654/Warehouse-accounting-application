namespace WarehouseInformationSystem.model
{
    public class Address
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указан адрес")] 
        public string Name { get; set; }
        public string TEXT { get; set; }
        //связи
        public List<Location> Locations { get; set; } = new();


    }
}
