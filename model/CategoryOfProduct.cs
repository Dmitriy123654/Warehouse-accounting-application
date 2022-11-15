namespace WarehouseInformationSystem.model
{
    public class CategoryOfProduct
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано название")]
        public string Name { get; set; }
        //связи
        public List<Product> Products { get; set; } = new();
    }
}
