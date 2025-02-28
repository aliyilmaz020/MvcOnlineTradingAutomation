using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcOnlineTradingAutomation.Models.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter giriniz.")]
        public string CustomerName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage ="Bu alan boş geçilemez!")]
        public string CustomerSurname { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CustomerCity { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CustomerMail { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(20)]
        public string CustomerPassword { get; set; }
        public bool Status { get; set; }
        public string Authority { get; set; }
        public ICollection<SaleOperation> SaleOperations { get; set; }

    }
}