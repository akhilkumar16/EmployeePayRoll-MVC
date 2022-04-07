using BusinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayRoll_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeBL employeeBL;
        public EmployeeController(IEmployeeBL employeeBL)
        {
            this.employeeBL = employeeBL;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                employeeBL.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        public IActionResult Index()
        {
            List<EmployeeModel> lstEmployee = new List<EmployeeModel>();
            lstEmployee = employeeBL.GetAllEmployee().ToList();

            return View(lstEmployee);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = employeeBL.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] EmployeeModel employee)
        {
            if (id != employee.EmpId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                employeeBL.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = employeeBL.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            employeeBL.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = employeeBL.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
    }
}
