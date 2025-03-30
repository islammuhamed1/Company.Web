
namespace Company.Data.Entities
{
   public class Employee : BaseEntity
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ImgUrl { get; set; }
        public decimal Salary { get; set; }
        public DateTime HiringDate { get; set; }
        public int? DepartmentId { get; set; }  

    }
}
