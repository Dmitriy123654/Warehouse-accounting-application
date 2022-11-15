namespace WarehouseInformationSystem.model
{
    /// <summary>
    /// должность
    /// </summary>
    public class Post
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указана должность")]
        public string Name { get; set; }
        //связь
        public List<Employee> Employees { get; set; } = new();
    }
}
