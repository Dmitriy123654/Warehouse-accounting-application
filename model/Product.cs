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
        [Required(ErrorMessage = "Не указана цена")]
        public decimal SalePrice { get; set; }// цена продажи
        public decimal? PurchasePrice { get; set; }//закупочная
        public Product(string name, decimal salePrice, decimal? purchasePrice)
        {
            Name = name;
            SalePrice = salePrice;
            PurchasePrice = purchasePrice;
        }
        //public Product(string name, decimal salePrice, decimal? purchasePrice, int categoryOfProductId,int locationWarehouseNumber) :this (name,salePrice,purchasePrice)
        //{
        //    CategoryOfProductId = categoryOfProductId;
        //    LocationWarehouseNumber = locationWarehouseNumber;
        //}

        //связи:
        //категория
        public int CategoryOfProductId { get; set; }
        public CategoryOfProduct? CategoryOfProduct { get; set; }
        //склад
        public int LocationWarehouseNumber { get; set; }// склад товара
        public override string ToString()
        {
            return $"Name: {Name}\n" +
                $"SalePrice: {SalePrice}\n" +
                $"PurchasePrice: {PurchasePrice}\n";
        }

    }
}
