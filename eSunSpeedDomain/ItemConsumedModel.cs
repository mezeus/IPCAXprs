using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class ItemConsumedModel
    {
        //This Is Used For Production,Unassemble,Stock Journal Vouchers
        public int Item_ID { get; set; }
        public int ParentId { get; set; } 

        public string Item { get; set; }
        public string Batch { get; set; }
        public decimal BasicAmt { get; set; }

        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }

        public decimal VATPercentage { get; set; }
        public decimal VAT { get; set; }

        public decimal Qty { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalQty { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
