using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class ListVoucherModel
    {
        public int Recevied_Id { get; set; }
        public int Issued_Id { get; set; }
        public DateTime Date { get; set; }
        public string Party { get; set; }
        public int VoucherNo { get; set; }
        public decimal Amount { get; set; }
        public int BillNo { get; set; }
        public string BillDate { get; set; }
    }
}
