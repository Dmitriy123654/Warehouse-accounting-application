namespace WarehouseInformationSystem.Model
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано имя товара")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Недопустимая длина имени")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указаны характеристики/описание")]
        [StringLength(300, MinimumLength = 2, ErrorMessage = "Недопустимая длина имени")]
        public string Characteristic { get; set; } 
        [Required(ErrorMessage = "Не указана цена")]
        public decimal SalePrice { get; set; }
        public decimal? PurchasePrice { get; set; }
        public Product(string name, string characteristic, decimal salePrice, decimal? purchasePrice)
        {
            Name = name;
            Characteristic = characteristic;
            SalePrice = salePrice;
            PurchasePrice = purchasePrice;
           
        }

        public int CategoryOfProductId { get; set; }
        public CategoryOfProduct? CategoryOfProduct { get; set; }
        public int LocationWarehouseNumber { get; set; }
        public Location? Location { get; set; }
        public override string ToString()
        {
            return $"Название: {Name}\n" +
                $"Характеристики: {Characteristic}" +
                $"Цена продажи: {SalePrice}\n" +
                $"Цена закупки: {PurchasePrice}\n";
        }
    }
}
