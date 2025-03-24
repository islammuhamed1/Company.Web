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
            _departmentRepository.Delete(entity);
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

        public void Update(Department department)
        {
            //var dept = GetById(department.Id);
            //if (dept.Name != department.Name)
            //{
            //    if (GetAll().Any(x => x.Name == department.Name)) ;
            //        throw new Exception("Department Name Already Exist");
            //}
            //dept.Name = department.Name;
            //dept.Code = department.Code;
            _departmentRepository.Update(department);
        }
    }
}
