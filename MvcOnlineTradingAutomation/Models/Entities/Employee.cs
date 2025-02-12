using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTradingAutomation.Models.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeeImage { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<SaleOperation> SaleOperations { get; set; }


    }
}