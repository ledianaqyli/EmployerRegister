using EmployerRegister.Data;
using EmployerRegister.Models;
using EmployerRegister.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployerRegister.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MVCDemoDbContext context;
        public EmployeesController(MVCDemoDbContext context)
        {
            this.context = context;


        }

        [HttpGet]
        public IActionResult Add()
        {
           return View();
        }
      

        [HttpPost]
        public async Task< IActionResult> Add(AddEmployeViewModel addEmploye)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmploye.Name,
                Email = addEmploye.Email,
                Salary = addEmploye.Salary,
                DateofBirth = addEmploye.DateofBirth,
                Department = addEmploye.Department,

            };

           await context.Employees.AddAsync(employee);
           await context.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
           var employeesList= await context.Employees.ToListAsync();

            return View(employeesList);
        }
    }
}
