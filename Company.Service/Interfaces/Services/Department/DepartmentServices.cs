using Company.Data.Entities;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;

namespace Company.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public void Add(Department department)
        {
           var mappedDepartment = new Department
           {
               Name = department.Name,
               Code = department.Code,
               CreateAt = DateTime.Now
           };
            _departmentRepository.Add(mappedDepartment);
        }

        public void Delete(Department entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetAll()
        {
            var department = _departmentRepository.GetAll();
            return department;
        }

        public Department GetById(int? id)
        {
            if(id is null)  throw new Exception("Id Is Null");

            var department = _departmentRepository.GetById(id.Value);

            if (department is null) return null;

            return department;
        }

        public void Update(Department entity)
        {
            throw new NotImplementedException();
        }
    }
}
