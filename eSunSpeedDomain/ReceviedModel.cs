using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class ReceviedModel
    {
        public int id { get; set; }
        public int VoucherNo { get; set; }
        public string Dated { get; set; }
        public decimal Amount { get; set; }
        public int ParentId { get; set; }
        public int BillNo { get; set;}
        public int BillDate { get; set; }
    }
}
