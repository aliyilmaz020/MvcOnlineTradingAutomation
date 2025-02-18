using MvcOnlineTradingAutomation.Context;
using MvcOnlineTradingAutomation.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTradingAutomation.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        // GET: Department
        Mvc5Context db = new Mvc5Context();

        public ActionResult Index()
        {
            var departments = db.Departments.Where(x=>x.Status==true).ToList();
            return View(departments);
        }
        [HttpGet]
        public ActionResult CreateDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDepartment(Department d)
        {
            d.Status = true;
            db.Departments.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult RemoveDepartment(int id)
        {
            var department = db.Departments.Find(id);
            department.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditDepartment(int id)
        {
            var department = db.Departments.Find(id);
            return View(department);
        }
        [HttpPost]
        public ActionResult EditDepartment(Department d)
        {
            var department = db.Departments.Find(d.DepartmentId);
            department.DepartmentName = d.DepartmentName;
            department.Status = d.Status;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DepartmentDetail(int id)
        {
            ViewBag.DepartmentName = db.Departments.Where(x=>x.DepartmentId==id).Select(x=>x.DepartmentName).FirstOrDefault();
            var employees = db.Employees.Where(x=>x.DepartmentId==id).ToList();
            return View(employees);
        }
        public ActionResult DepartmentEmployeeSale(int id)
        {
            ViewBag.Employee = db.Employees.Where(x => x.EmployeeId == id).Select(x => x.EmployeeName + " " + x.EmployeeSurname).FirstOrDefault();
            var values = db.SalesOperations.Where(x=>x.EmployeeId == id).ToList();
            return View(values);
        }
    }
}