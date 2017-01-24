using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class BillsofMaterialDetailsModel
    {
        public int id { get; set; }
        public int ParentId { get; set; }
        public int SNo { get; set; }
        public string ItemName { get; set; }
        public decimal Qty { get; set; }
        public string Unit { get; set; }
        public decimal TotalofConsumedqtyUnit { get; set; }
    }
}
