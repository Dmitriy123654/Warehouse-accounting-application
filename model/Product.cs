namespace WarehouseInformationSystem.Model
{
    /// <summary>
    /// Товар
    /// </summary>
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
        public decimal SalePrice { get; set; }// цена продажи
        public decimal? PurchasePrice { get; set; }//закупочная
        public Product(string name, string characteristic, decimal salePrice, decimal? purchasePrice, CategoryOfProduct categoryOfProduct, Location location)
        {
            Name = name;
            Characteristic = characteristic;
            SalePrice = salePrice;
            PurchasePrice = purchasePrice;
            CategoryOfProduct = categoryOfProduct;
            Location = location;
        }

        //связи:
        //категория
        public int CategoryOfProductId { get; set; }
        public CategoryOfProduct? CategoryOfProduct { get; set; }
        //склад
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
//public Product(string name, decimal salePrice, decimal? purchasePrice, int categoryOfProductId,int locationWarehouseNumber) :this (name,salePrice,purchasePrice)
//{
//    CategoryOfProductId = categoryOfProductId;
//    LocationWarehouseNumber = locationWarehouseNumber;
//}
