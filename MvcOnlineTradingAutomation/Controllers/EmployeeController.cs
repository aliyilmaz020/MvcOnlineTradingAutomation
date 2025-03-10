﻿using MvcOnlineTradingAutomation.Context;
using MvcOnlineTradingAutomation.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcOnlineTradingAutomation.Controllers
{
    [Authorize]
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
            var employees = db.Employees.Where(x => x.Status == true).ToList();
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
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            if (DepartmentId.HasValue) // Eğer departman seçildiyse
            {
                var department = db.Departments.Find(DepartmentId.Value);
                if (department != null)
                {
                    emp.DepartmentId = department.DepartmentId; // Foreign Key'i ata
                }
            }
            emp.Status = true;
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string path = "~/Image/" + fileName;
                Request.Files[0].SaveAs(Server.MapPath(path));
                emp.EmployeeImage = "/Image/" + fileName;
            }
            db.Employees.Add(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetEmployee(int id)
        {
            List<SelectListItem> depart = db.Departments.Where(x => x.Status == true).Select(x => new SelectListItem
            {
                Text = x.DepartmentName,
                Value = x.DepartmentId.ToString()
            }).ToList();
            ViewBag.Departs = depart;
            var emp = db.Employees.Find(id);
            return View(emp);
        }
        public ActionResult EditEmployee(Employee e)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction($"GetEmployee/{e.EmployeeId}");
            }
            var employee = db.Employees.Find(e.EmployeeId);
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string path = "~/Image/" + fileName;
                Request.Files[0].SaveAs(Server.MapPath(path));
                e.EmployeeImage = "/Image/" + fileName;
            }
            employee.EmployeeImage = e.EmployeeImage;
            employee.EmployeeName = e.EmployeeName;
            employee.EmployeeSurname = e.EmployeeSurname;
            employee.DepartmentId = e.DepartmentId;
            employee.EmployeePhone = e.EmployeePhone;
            employee.EmployeeCity = e.EmployeeCity;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EmployeeSale(int id)
        {
            ViewBag.Employee = db.Employees.Where(x => x.EmployeeId == id).Select(x => x.EmployeeName + " " + x.EmployeeSurname).FirstOrDefault();
            var sales = db.SalesOperations.Where(x => x.EmployeeId == id).ToList();
            return View(sales);
        }
        public ActionResult EmployeeList()
        {
            var employees = db.Employees.Where(x => x.Status == true).ToList();
            return View(employees);
        }
    }
}