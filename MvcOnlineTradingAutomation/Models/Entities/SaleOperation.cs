using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTradingAutomation.Models.Entities
{
    public class SaleOperation
    {
        [Key]
        public int SaleOperationId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
    }
}