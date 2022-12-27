namespace WarehouseInformationSystem.Model
{
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
        public List<Employee> Employees { get; set; } = new();
       
        public override string ToString()
        {
            return $"{Name}\n";
        }
    }
}
