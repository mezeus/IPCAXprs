using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class PurchaseVoucherModel
    {
        public long Trans_Purc_Id { get; set; }
        public string VoucherType { get; set; }
        public string Series { get; set; }
        public DateTime PurcDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDeleted { get; set; }
        public long BillNo { get; set; }
        public decimal PriceList { get; set; }
        public string Terms { get; set; }
        public long VoucherNumber { get; set; }
        public string PurcType { get; set; }
        public string Party { get; set; }
        public string MatCentre { get; set; }

        public string Narration { get; set; }
        public decimal TotalQty { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal BSTotalAmount { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public List<Item_VoucherModel> Item_Voucher { get; set; }
        public List<BillSundry_VoucherModel> BillSundry_Voucher { get; set; }
    }
}
