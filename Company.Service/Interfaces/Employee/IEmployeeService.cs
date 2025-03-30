using Company.Service.Interfaces.Employee.Dto;

namespace Company.Service.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeDto GetById(int? id);
        IEnumerable<EmployeeDto> GetAll();
        void Add(EmployeeDto employee);
        void Update(EmployeeDto employee);
        void Delete(EmployeeDto id);


        IEnumerable<EmployeeDto> GetEmployeeByAddress(string address);
        IEnumerable<EmployeeDto> GetEmployeeByName(string name);
    }
}
