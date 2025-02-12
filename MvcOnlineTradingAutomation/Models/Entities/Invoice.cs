using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTradingAutomation.Models.Entities
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public string InvoiceSerial { get; set; }
        public string InvoiceSequenceNum { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceTaxOffice { get; set; }
        public DateTime InvoiceTime { get; set; }
        public string InvoiceDelivery { get; set; }
        public string InvoiceRecever { get; set; }
        public bool InvoiceStatus { get; set; }
        public ICollection<InvoiceDocument> InvoiceDocuments { get; set; }
    }
}