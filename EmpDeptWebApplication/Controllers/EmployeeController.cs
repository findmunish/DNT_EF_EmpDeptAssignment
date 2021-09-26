using EfAssignment;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpDeptWebApplication.Controllers
{
    public class EmployeeController : Controller
    {
        DatabaseContext _db;
        public EmployeeController(DatabaseContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var employees = _db.Employees.ToList();
            for (int i = 0; i < employees.Count; ++i)
            {
                employees[i].Department = _db.Departments.Find(employees[i].DeptId);
            }

            return View(employees);
        }

        public IActionResult Details(int id)
        {
            return _view(id, "View");
        }

        public IActionResult Create()
        {
            ViewBag.Departments = _db.Departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee empModel)
        {
            // ModelState.Remove("EmpId");
            if (ModelState.IsValid)
            {
                _db.Add(empModel);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Departments = _db.Departments.ToList();
            return View();
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Departments = _db.Departments.ToList();

            return _view(id, "Edit");
        }

        [HttpPost]
        public IActionResult Edit(int id, Employee empModel)
        {
            if (ModelState.IsValid)
            {
                _db.Update(empModel);
                _db.SaveChanges();

                return RedirectToAction ("Index");
            }
            ViewBag.Departments = _db.Departments.ToList();
            return View();
        }

        public IActionResult Delete(int id)
        {
            Employee empModel = _db.Employees.Find(id);
            if (empModel != null)
            {
                _db.Remove(empModel);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        private IActionResult _view(int id, string viewType)
        {
            Employee empModel = _db.Employees.Find(id);
            empModel.Department = _db.Departments.Find(empModel.DeptId);
            if (empModel == null)
            {
                return RedirectToAction("Index");
            }

            empModel.ViewType = viewType;
            return View("Create", empModel);
        }
    }
}
