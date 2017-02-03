using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    //This class will be the child model for all parent/main tables like trans_sales, trans_salesreturn, trans_purchase etc
    public class Item_VoucherModel
    {
        public long Item_ID { get; set; }
        public long ParentId { get; set; } //This should be the parent Id of transaction screen
                                          //Sales, Sales return, purchase, purchase return etc

        public string Item { get; set; }     
        public decimal Qty { get; set; }
        public string Unit { get; set; }
        public string Per { get; set; }
        public decimal Price { get; set; }
        public string Batch { get; set; }
        public decimal Free { get; set; }
        public decimal BasicAmt { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Amount { get; set; }
        public decimal VATPercentage { get; set; }
        public decimal VAT { get; set; }
        public decimal TotalQty { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
