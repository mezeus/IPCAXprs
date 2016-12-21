using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class MatIssuedModel
    {
        public int SR_Id { get; set; }
        public int Issued_Id { get; set; }       
        public string Series { get; set; }
        public int Voucher_Number { get; set; } 
        public DateTime Issued_Date { get; set; }                        
        public string Party { get; set; }
        public string MatCenter { get; set; }
        public string Narration { get; set; }
        public decimal TotalQty { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal BSTotalAmount { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public List<Item_VoucherModel> IssuedItem_Voucher { get; set; }
        public List<BillSundry_VoucherModel> IssuedBillSundry_Voucher { get; set; }
    }
}
