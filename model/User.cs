
namespace WarehouseInformationSystem.model
{
    public abstract class DefaultUser
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }
    }
    public class User : DefaultUser
    {
        public string? SecondName { get; set; } = "";
        public string? LastName { get; set; } = "";
        [Range(18, 100, ErrorMessage = "Недопустимый возраст")]
        public int Age { get; set; }
        //[Phone]
        public string? Phone { get; set; } = "";

    }
}
