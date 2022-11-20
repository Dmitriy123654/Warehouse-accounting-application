namespace WarehouseInformationSystem.Model
{
    /// <summary>
    /// отдел работы
    /// </summary>
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано имя отдела")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Недопустимая длина имени отдела")]
        public string Name { get; set; }
        public Department(string name)
        {
            Name = name;
        }
        //связи
        public List<Employee> Employees { get; set; } = new();
       
        public override string ToString()
        {
            return $"Отдел: {Name}\n";
        }
    }
}
