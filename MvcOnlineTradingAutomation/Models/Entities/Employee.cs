using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTradingAutomation.Models.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeeName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeeSurname { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string EmployeeImage { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public bool Status { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string EmployeeCity { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10,ErrorMessage ="Lütfen 10 Karakter Giriniz.")]
        public string EmployeePhone { get; set; }
        public ICollection<SaleOperation> SaleOperations { get; set; }


    }
}