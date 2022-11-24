
namespace WarehouseInformationSystem.Model
{
    public class Employee : User
    {
        public decimal Salary { get; set; }
        //???добавить отпуск
        public Employee(string name, int age, string secondName, string phone, decimal salary)
            : base(name, age, secondName, phone)
        {
            Salary = salary;
            //Department = department;
            //Post = post;
        }
        //связи:
        //отдел 
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        // должность
        public int PostId { get; set; }
        public Post? Post { get; set; }
        //!!вывод



    }
}



//!!!????тестовый вариант!!!????
//public Employee(string name, int age, string secondName, string lastName, string phone, decimal salary, Department? department,  Post? post) : 
//    this( name,  age,  secondName,  lastName,  phone,  salary)
//{
//    DepartmentId = department.Id;
//    Department = department;
//    PostId = post.Id;
//    Post = post;
//}
//public Employee(string name, int age, string secondName, string lastName, string phone, decimal salary, int departmentId, int postId) :
//    this(name, age, secondName, lastName, phone, salary)
//{
//    DepartmentId = departmentId;
//    PostId = postId;
//}