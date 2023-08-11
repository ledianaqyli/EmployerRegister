﻿using EmployerRegister.Data;
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

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
           var employee= await context.Employees.FirstOrDefaultAsync(x=> x.Id == id);
            if (employee != null)
            {
                var viewModel = new UpdateEmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    DateofBirth = employee.DateofBirth,
                    Department = employee.Department,
                };

                return await Task.Run(()=>View("View",viewModel));

            }
           
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateEmployeeViewModel model)
        {
            var employee = await context.Employees.FindAsync(model.Id);
            if (employee != null)
            {
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Salary = model.Salary;
                employee.DateofBirth = model.DateofBirth;
                employee.Department = model.Department;
                await context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Delete (UpdateEmployeeViewModel model)
        {
            var employee = await context.Employees.FindAsync(model.Id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


    }
}
