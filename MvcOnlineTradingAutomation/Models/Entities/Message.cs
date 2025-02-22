using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTradingAutomation.Models.Entities
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        
        [Column(TypeName ="Varchar")]
        [StringLength(50)]
        public string Sender { get; set; }
        
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Receiver { get; set; }
        
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Subject { get; set; }
        
        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string Content { get; set; }

        [Column(TypeName = "Datetime")]
        public DateTime Date { get; set; }
    }
}