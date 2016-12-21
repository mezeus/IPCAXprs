using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class VatJournalOutputTaxModel
    {
        public string Month { get; set; }

        public string Tax_Inc_Dec { get; set; }
        public string Nature { get; set; }
        public decimal Sale_Amt { get; set; }
        public decimal Tax { get; set; }
        public decimal Output_Schg { get; set; }        
        public decimal Output_Inc_Amt { get; set; }                        
        public decimal Output_Inc_Schg { get; set; }
        public decimal Output_Dec_Amt { get; set; }
        public decimal Output_Dec_Schg { get; set; }
        public decimal Output_Total_Sale_Amt { get; set; }
        public decimal Output_Total_Inc_Amt { get; set; }
        public decimal Output_Total_Dec_Amt { get; set; }

        public string Output_Description { get; set; }
        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public List<AccountModel> JournalAccountModel { get; set; }
        //public List<Item_VoucherModel> Item_Voucher { get; set; }
        //public List<BillSundry_VoucherModel> BillSundry_Voucher { get; set; }
    }
}
