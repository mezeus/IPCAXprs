using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class DebitNoteModel
    {
        public int DN_Id { get; set; }

        public string Type { get; set; }
        public string Voucher_Series { get; set; }
        public int Voucher_Number { get; set; }
                
        public DateTime DN_Date { get; set; }
        public DateTime PDC_Date { get; set; }
        public string LongNarration { get; set; }
        public decimal TotalCreditAmount { get; set; }
        public decimal TotalDebitAmount { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public List<AccountModel> DebitAccountModel { get; set; }
        
    }
}
