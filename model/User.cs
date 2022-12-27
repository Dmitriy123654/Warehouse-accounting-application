

namespace WarehouseInformationSystem.Model
{
    public abstract class DefaultUser
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(50, MinimumLength =1, ErrorMessage = "Недопустимая длина имени")]
        public string Name { get; set; }
        public DefaultUser(string name)
        {
            Name = name;
        }
    }
    public class User : DefaultUser
    {
        [StringLength(50, ErrorMessage = "Недопустимая длина фамилии")]
        public string? SecondName { get; set; } = "";
        [Range(18, 100, ErrorMessage = "Недопустимый возраст")]
        public int Age { get; set; }
        [Range(10, 20, ErrorMessage = "Недопустимый номер телефона")]
        public string? Phone { get; set; } = "";
        public User(string name, int age,string? secondName="",string? phone="") : base(name)
        {
            Age = age;
            SecondName = secondName;
            Phone = phone;
        }
        public override string ToString()
        {
            return $"Имя: {Name}\n" +
                $"Фамилия: {SecondName}\n" +
                $"Возраст: {Age}\n" +
                $"Телефон: {Phone}\n";
        }
    }
}
