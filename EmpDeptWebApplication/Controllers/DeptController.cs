using EfAssignment;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpDeptWebApplication.Controllers
{
    public class DeptController : Controller
    {
        DatabaseContext _db;
        public DeptController(DatabaseContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var depts = _db.Departments.ToList();
            return View(depts);
        }

        public IActionResult Details(int id)
        {
            return _view(id, "View");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department deptModel)
        {
            ModelState.Remove("DeptId");
            if (ModelState.IsValid)
            {
                _db.Add(deptModel);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            return _view(id, "Edit");
        }

        [HttpPost]
        public IActionResult Edit(int id, Department deptModel)
        {
            if (ModelState.IsValid)
            {
                _db.Update(deptModel);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View("Create");
        }

        public IActionResult Delete(int id)
        {
            var deptModel = _db.Departments.Find(id);
            if (deptModel != null)
            {
                _db.Remove(deptModel);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        private IActionResult _view(int id, string viewType)
        {
            Department deptModel = _db.Departments.Find(id);
            if (deptModel == null)
            {
                return RedirectToAction("Index");
            }

            deptModel.ViewType = viewType;
            return View("Create", deptModel);
        }
    }
}
