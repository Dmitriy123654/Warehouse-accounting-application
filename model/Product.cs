namespace WarehouseInformationSystem.model
{
    /// <summary>
    /// Товар
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано имя товара")]
        public string? Name { get; set; }
        public decimal? SalePrice { get; set; }// цена продажи
        public decimal? PurchasePrice { get; set; }//закупочная
        //связи:
        //категория
        public int CategoryOfProductId { get; set; }
        public CategoryOfProduct? CategoryOfProduct { get; set; }
        //склад
        public int LocationWarehouseNumber { get; set; }// склад товара

    }
}
