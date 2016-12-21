using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class ListModel
    {
        public int Physical_Id { get; set; }
        public string Item { get; set; }
        public decimal Physical_Stock { get; set; }
        public decimal Difference { get; set; }

        public int Id { get; set; }

        public DateTime Date { get; set; }
        public string Type { get; set; }

        public int BillNo { get; set; }
        public int VoucherNo { get; set; }
        public string Account { get; set; }
        public int TotalAmt { get; set; }

        public int Debit { get; set; }
        public int Credit { get; set; }
        public string Narration { get; set; }
        
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        
    }
}
