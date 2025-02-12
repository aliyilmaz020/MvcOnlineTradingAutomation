using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTradingAutomation.Models.Entities
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
    }
}