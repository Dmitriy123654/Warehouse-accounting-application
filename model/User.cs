

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
        [StringLength(50, ErrorMessage = "Недопустимая длина отчества")]
        public string? LastName { get; set; } = "";
        [Range(18, 100, ErrorMessage = "Недопустимый возраст")]
        public int Age { get; set; }
        //[Phone]
        [Range(10, 20, ErrorMessage = "Недопустимый номер телефона")]
        public string? Phone { get; set; } = "";
        public User(string name, int age,string secondName,string lastName,string phone) : base(name)
        {
            Age = age;
            SecondName = secondName;
            LastName = lastName;
            Phone = phone;
        }
        public override string ToString()
        {
            return $"Name: {Name}\n" +
                $"SecondName: {SecondName}\n" +
                $"LastName: {LastName}\n" +
                $"Age {Age}\n" +
                $"Phone: {Phone}\n";
        }


    }
}
