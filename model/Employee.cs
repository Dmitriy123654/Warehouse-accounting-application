
namespace WarehouseInformationSystem.model
{
    public class Employee : User
    {
        public decimal Salary { get; set; }
        //???добавить отпуск
        //связи:
        //отдел 
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        // должность
        public int PostId { get; set; }
        public Post? Post { get; set; }

    }
}
