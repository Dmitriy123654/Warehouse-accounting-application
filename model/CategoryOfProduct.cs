namespace WarehouseInformationSystem.Model
{
    public class CategoryOfProduct
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано категория продукта")]
        [StringLength(30,MinimumLength =2, ErrorMessage = "Недопустимая длина категории")]
        public string Name { get; set; }
        public CategoryOfProduct(string name)
        {
            Name = name;
        }
        public List<Product> Products { get; set; } = new();
       
        public override string ToString()
        {
            return $"Категория товара: {Name} \n";
        }
    }
}
