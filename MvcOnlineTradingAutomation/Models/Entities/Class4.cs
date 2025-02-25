using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTradingAutomation.Models.Entities
{
    public class Class4
    {
        public IEnumerable<Invoice> Invoices { get; set; }
        public IEnumerable<InvoiceDocument> InvoicesDocuments { get; set; }
    }
}