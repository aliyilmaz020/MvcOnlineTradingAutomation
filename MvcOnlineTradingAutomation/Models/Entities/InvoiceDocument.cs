using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTradingAutomation.Models.Entities
{
    public class InvoiceDocument
    {
        [Key]
        public int InvoiceDocumentId { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}