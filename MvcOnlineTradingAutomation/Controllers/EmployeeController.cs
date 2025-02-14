using MvcOnlineTradingAutomation.Context;
using MvcOnlineTradingAutomation.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcOnlineTradingAutomation.Controllers
{
    public class EmployeeController : Controller
    {
        Mvc5Context db = new Mvc5Context();
        // GET: Employee
        public ActionResult Index()
        {
            var departments = db.Departments.Where(x => x.Status == true).Select(x => new
            {
                x.DepartmentId,
                x.DepartmentName
            }).ToList();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "DepartmentName");
            var employees = db.Employees.Where(x=>x.Status==true).ToList();
            return View(employees);
        }
        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEmployee(Employee emp, int? DepartmentId)
        {
            if (DepartmentId.HasValue) // Eğer departman seçildiyse
            {
                var department = db.Departments.Find(DepartmentId.Value);
                if (department != null)
                {
                    emp.DepartmentId = department.DepartmentId; // Foreign Key'i ata
                }
            }
            db.Employees.Add(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}