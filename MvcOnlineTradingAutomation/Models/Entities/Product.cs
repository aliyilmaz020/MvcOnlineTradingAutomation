using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTradingAutomation.Models.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ProductBrand { get; set; }
        public short ProductStock { get; set; }
        public decimal ProductCashPrice { get; set; }
        public decimal ProductSalePrice { get; set; }
        public bool ProductStatus { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string ProductImage { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<SaleOperation> SaleOperations { get; set; }

    }
}