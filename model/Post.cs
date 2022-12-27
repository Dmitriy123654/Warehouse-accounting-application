namespace WarehouseInformationSystem.Model
{
    public class Post
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указана должность")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Недопустимая длина должности")]
        public string Name { get; set; }
        public Post(string name) 
        { 
            Name = name; 
        }
        public List<Employee> Employees { get; set; } = new();
        public override string ToString()
        {
            return $"Должность: {Name}\n";
        }
    }
}
