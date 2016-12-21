using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class PurchaseReturnVoucherModel
    {
        public int PR_Id { get; set; }
        public int PV_Id { get; set; }
        public string PurchaseType { get; set; }
        public string Series { get; set; }
        public int Voucher_Number { get; set; }
        public int BillNo { get; set; }
        public DateTime DueDate { get; set; }        
        public DateTime PR_Date { get; set; }                        
        public string Party { get; set; }
        public string MatCenter { get; set; }
        public string Narration { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalQty { get; set; }
        public decimal BSTotalAmount { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public List<Item_VoucherModel> Item_Voucher { get; set; }
        public List<BillSundry_VoucherModel> BillSundry_Voucher { get; set; }
    }
}
