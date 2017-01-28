using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class UnclearedChecqueDetailsModel
    {
        public int id { get; set; }
        public int ParentId { get; set; }
        public DateTime Date { get; set; }
        public long  Vchno { get; set; }
        public string Account { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public string Shortnarration { get; set; }
    }
}
