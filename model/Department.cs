namespace WarehouseInformationSystem.model
{
    /// <summary>
    /// отдел работы
    /// </summary>
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано имя отдела")]
        public string Name { get; set; }
        //связи
        public List<Employee> Employees { get; set; } = new();
    }
}
