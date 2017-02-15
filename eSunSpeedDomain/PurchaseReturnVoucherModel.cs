using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class PurchaseReturnVoucherModel
    {
        public long PR_Id { get; set; }
        public int PV_Id { get; set; }
        public string PurchaseType { get; set; }
        public string VoucherType { get; set; }
        public long VoucherNumber { get; set; }
        public long BillNo { get; set; }
        public string Terms { get; set; }
        public DateTime DueDate { get; set; }        
        public DateTime PR_Date { get; set; }                        
        public string Party { get; set; }
        public long LedgerId { get; set; }

        public string MatCenter { get; set; }
        public string Narration { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalQty { get; set; }
        public decimal TotalFree { get; set; }
        public decimal TotalBasicAmount { get; set; }
        public decimal TotalDisAmount { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public decimal BSTotalAmount { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public List<Item_VoucherModel> Item_Voucher { get; set; }
        public List<BillSundry_VoucherModel> BillSundry_Voucher { get; set; }
    }
}
