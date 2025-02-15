using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTradingAutomation.Models.Entities
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string InvoiceSerial { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string InvoiceSequenceNum { get; set; }
        public DateTime InvoiceDate { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string InvoiceTaxOffice { get; set; }
        [Column(TypeName = "char")]
        [StringLength(5)]
        public string InvoiceTime { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string InvoiceDelivery { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string InvoiceRecevier { get; set; }
        public bool InvoiceStatus { get; set; }
        public decimal Total { get; set; }

        public ICollection<InvoiceDocument> InvoiceDocuments { get; set; }
    }
}