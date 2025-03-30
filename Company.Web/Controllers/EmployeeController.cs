using Company.Data.Entities;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Employee.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService , IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }
        public IActionResult Index(string seacrhInput)
        {
            //TempData["TextTempMessage"] = "Hello From Employee (TempData)";
            IEnumerable<EmployeeDto> employess = new List<EmployeeDto>();
            if (!string.IsNullOrEmpty(seacrhInput))
                employess = _employeeService.GetEmployeeByName(seacrhInput);
            else
                employess = _employeeService.GetEmployeeByName(seacrhInput);
            return View(employess);
        }



        [HttpGet]
        public IActionResult Create()
        {
            var departments = _departmentService.GetAll();
            ViewBag.Departments=_departmentService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeDto employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.Add(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
