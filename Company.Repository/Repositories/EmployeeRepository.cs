using Company.Data.Context;
using Company.Data.Entities;
using Company.Repository.Interfaces;


namespace Company.Repository.Repositories
{
    public class EmployeeRepository :GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly CompanyDbContext _context;

        public EmployeeRepository(CompanyDbContext context) : base(context)
        {
            _context=context;
        }

        public IEnumerable<Employee> GetEmployeeByAddress(string address)
        {
            return _context.Employees.Where(x => x.Address == address).ToList();
        }

        public  IEnumerable<Employee> GetEmployeeByName(string name)
            => _context.Employees.Where(x =>x.Name.Trim().ToLower().Contains(name.Trim().ToLower())).ToList();

    }
}
