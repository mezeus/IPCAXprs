using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class MaintainBillbyBillModel
    {
        public int BillId { get; set; }
        public int ParentId { get; set; }
        public string Reference { get; set; }
        public DateTime Dated { get; set; }
        public decimal Amount { get; set; }
        public string DC { get; set; }
        public DateTime Duedate { get; set; }
        public string Group { get; set; }
        public string Narration { get; set; }
    }
}
