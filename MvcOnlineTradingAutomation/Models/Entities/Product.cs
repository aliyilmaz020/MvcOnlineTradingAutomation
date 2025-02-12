using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTradingAutomation.Models.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductBrand { get; set; }
        public short ProductStock { get; set; }
        public decimal ProductCashPrice { get; set; }
        public decimal ProductSalePrice { get; set; }
        public bool ProductStatus { get; set; }
        public string ProductImage { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<SaleOperation> SaleOperations { get; set; }

    }
}