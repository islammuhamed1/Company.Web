using AutoMapper;
using Company.Data.Entities;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Employee.Dto;


namespace Company.Service.Services
{
    public class EmployeeServices : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public EmployeeServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public void Add(EmployeeDto employeeDto)
        {
            Employee employee = _mapper.Map<Employee>(employeeDto);
            _unitOfWork.EmployeeRepository.Add(employee);
            _unitOfWork.Complete();
        }
        public void Update(EmployeeDto employeeDto)
        {
            Employee employee = _mapper.Map<Employee>(employeeDto);
            _unitOfWork.EmployeeRepository.Update(employee);
            _unitOfWork.Complete();
        }
        public void Delete(EmployeeDto employeeDto)
        {
            Employee employee = _mapper.Map<EmployeeDto, Employee>(employeeDto);
            _unitOfWork.EmployeeRepository.Delete(employee);
            _unitOfWork.Complete();
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            var employees = _unitOfWork.EmployeeRepository.GetAll();

            IEnumerable<EmployeeDto> mappedEmployess = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return mappedEmployess;
        }

        public EmployeeDto GetById(int? id)
        {
            if (id is null)
                return null;
            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);
            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;

        }

        public IEnumerable<EmployeeDto> GetEmployeeByAddress(string address)
        {
            var employees = _unitOfWork.EmployeeRepository.GetEmployeeByAddress(address);
            _unitOfWork.EmployeeRepository.GetEmployeeByAddress(address);
            IEnumerable<EmployeeDto> mappedEmployess = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return mappedEmployess;

        }
        public IEnumerable<EmployeeDto> GetEmployeeByName(string name)
        {
            var employees =_unitOfWork.EmployeeRepository.GetEmployeeByName(name);
            IEnumerable<EmployeeDto> mappedEmployess = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return mappedEmployess;

        }
    }
}
