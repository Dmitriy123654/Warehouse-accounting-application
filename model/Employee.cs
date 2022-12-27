
namespace WarehouseInformationSystem.Model
{
    public class Employee : User
    {
        public decimal Salary { get; set; }
        public Employee(string name, int age, string? secondName, string? phone, decimal salary)
            : base(name, age, secondName, phone)
        {
            Salary = salary;
        }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public int PostId { get; set; }
        public Post? Post { get; set; }
    }
}
