using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class ContraVoucherModel
    {
        public long Id { get; set; }
        public long CV_Id { get; set; }
        public string Type { get; set; }
        public string Voucher_Series { get; set; }
        public long Voucher_Number { get; set; }
        public long BillNo { get; set; }
        public DateTime PDCDate { get; set; }        
        public DateTime CV_Date { get; set; }                        
        public string Party { get; set; }
        public string MatCenter { get; set; }
        public string LongNarration { get; set; }
        public decimal TotalCreditAmount { get; set; }
        public decimal TotalDebitAmount { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public List<AccountModel> ContraAccountModel { get; set; }
    }
}
