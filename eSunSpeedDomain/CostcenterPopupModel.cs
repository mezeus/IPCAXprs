using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class CostcenterPopupModel
    {
        public int CCId { get; set; }
        public int ParentId { get; set; }
        public string Costcenter { get; set; }
        public decimal Amount { get; set; }
        public string DC { get; set; }
        public string Shortnarration { get; set; }
    }
}
