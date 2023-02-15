using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.NewFolder;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbcontext;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext )
        {
            _logger = logger;
            _dbcontext = dbContext;
        }

        public IActionResult Index()
        {



            return View();
        }

        [HttpGet]
        public IActionResult Employeeview()
        {

            var Employ = _dbcontext.Employees.Include(c => c.Department).DefaultIfEmpty();

            return View(Employ);
        }

        public IActionResult Add( )
        {


            return View();
        }
        [HttpPost]
        public IActionResult Add(Employee emp)
        {

            Employee employee = new Employee();
            
            employee.FirstName = emp.FirstName;
            employee.LastName = emp.LastName;
            employee.Gender = emp.Gender;
            employee.salary = emp.salary;

            _dbcontext.Add(employee);
            _dbcontext.SaveChanges();
            int latestEmpId = employee.Id;

            Department dpt = new Department();

            dpt.DepartmentName = emp.Department.DepartmentName;
            dpt.Location = emp.Department.Location;
            dpt.Employee = employee;
            _dbcontext.Add(dpt);
            _dbcontext.SaveChanges();
            
            return View();
        }


        public IActionResult EmployeeDelete(int? id)
        {
            if (id == null || _dbcontext.Employees == null)
            {
                return NotFound();
            }

            var obj = _dbcontext.Employees.Include(a=>a.Department)
                .FirstOrDefault(m => m.Id == id);
            if (obj == null)           {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost, ActionName("EmployeeDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult EmployeeDelete(int id)
        {
            if (_dbcontext.Employees == null)
            {
                return Problem("Entity set 'db1Context.Employee'  is null.");
            }
            var objj = _dbcontext.Employees.Find(id);
            if (objj != null)
            {
                _dbcontext.Employees.Remove(objj);

            }

            _dbcontext.SaveChanges();
            return RedirectToAction(nameof(Employeeview));
        }



        [HttpGet]
        public IActionResult EmployeeEdit(int? id)
        {
            var i = _dbcontext.Employees.Include(a => a.Department)
                .FirstOrDefault(m=>m.Id==id);
            return View(i);
        }
        [HttpPost]
        public IActionResult EmployeeEdit(Employee detail)
        {
            Employee employee=new Employee();
            employee.Id = detail.Id;
            employee.FirstName = detail.FirstName;
            employee.LastName = detail.LastName;
            employee.Gender = detail.Gender;
            employee.salary = detail.salary;

            _dbcontext.Update(employee);
            _dbcontext.SaveChanges();

            //int latestEmpId = employee.Id;

            Department dpt = new Department();
            dpt.Id = detail.Id;
            dpt.DepartmentName = detail.Department.DepartmentName;
            
            dpt.Location = detail.Department.Location;
            dpt.Employee = employee;       
            _dbcontext.Update(dpt);              
            _dbcontext.SaveChangesAsync();
            return RedirectToAction(nameof(Employeeview));
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}