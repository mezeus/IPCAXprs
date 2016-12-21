using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class UnassembleVoucherModel
    {
        public int UA_Id { get; set; }
        public string AssembleType { get; set; }
        public string Series { get; set; }
        public int Voucher_Number { get; set; }      
        public DateTime UA_Date { get; set; }                        
        public string BOM_Name { get; set; }
        public string MatCenter1 { get; set; }
        public string MatCenter2 { get; set; }               
        public string Narration { get; set; }
        public decimal TotalQty { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal BSTotalAmount { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public List<Item_VoucherModel> AssembleItem_Voucher { get; set; }
        public List<BillSundry_VoucherModel> AssembleBillSundry_Voucher { get; set; }
    }
}
