using AutoMapper;
using Company.Data.Entities;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Department.Dto;

namespace Company.Service.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(DepartmentDto departmentDto)
        {
            //var mappedDepartment = new DepartmentDto
            //{
            //    Name = department.Name,
            //    Code = department.Code,
            //    CreateAt = DateTime.Now
            //};
            var mappedDepartment = _mapper.Map<Department>(departmentDto);
            _unitOfWork.DepartmentRepository.Add(mappedDepartment);
        }

        public void Delete(DepartmentDto departmentDto)
        {
            var mappedDepartment = _mapper.Map<Department>(departmentDto);
            _unitOfWork.DepartmentRepository.Delete(mappedDepartment);
            _unitOfWork.Complete();
        }

        public IEnumerable<DepartmentDto> GetAll()
        {
            var department = _unitOfWork.DepartmentRepository.GetAll();
            var mappedDepartment = _mapper.Map<IEnumerable<DepartmentDto>>(department); 
            return mappedDepartment;
        }

        public DepartmentDto GetById(int? id)
        {
            if(id is null)  throw new Exception("Id Is Null");

            var department = _unitOfWork.DepartmentRepository.GetById(id.Value);

            if (department is null) return null;
            var mappedDepartment = _mapper.Map<DepartmentDto>(department);
            return mappedDepartment;
        }

        public void Update(DepartmentDto department)
        {
            //var dept = GetById(department.Id);
            //if (dept.Name != department.Name)
            //{
            //    if (GetAll().Any(x => x.Name == department.Name)) ;
            //        throw new Exception("Department Name Already Exist");
            //}
            //dept.Name = department.Name;
            //dept.Code = department.Code;
            //_unitOfWork.DepartmentRepository.Update(department);
        }
    }
}
