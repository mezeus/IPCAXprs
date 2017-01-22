using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class ItemParameterizedModel
    {
        public int Param_Id { get; set; }
        public int Parent_Id { get; set; }
        public string ItemName { get; set; }
        public int Qty { get; set; }
        public string Unit { get; set; }
        public decimal MRP { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Costprice { get; set; }
        public string Barcode { get; set; }
    }
    
}
