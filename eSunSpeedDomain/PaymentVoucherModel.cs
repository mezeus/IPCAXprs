using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class PaymentVoucherModel
    {
        public long Pay_Id { get; set; }

        public string Type { get; set; }
        public string Voucher_Series { get; set; }
        public long Voucher_Number { get; set; }
        public long BillNo { get; set; }
        public decimal TotalCreditAmt { get; set; }
        public decimal TotalDebitAmt { get; set; }
        public DateTime PDCDate { get; set; }        
        public DateTime Pay_Date { get; set; }                        
        public string Party { get; set; }
        public string MatCenter { get; set; }
        public string LongNarration { get; set; }
        public string PaymentMode { get; set; }
        public long PaymentModeId { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public List<AccountModel> PaymentAccountModel { get; set; }
        //Ledger Posting Debit/credit
        public List<LedgerPostingModel> PaymentLPDebit { get; set; }
        public List<LedgerPostingModel> PaymentLPCredit { get; set; }
        
    }
}
