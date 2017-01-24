using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class ItemMRPWiseDetailsModel
    {
        public int MRP_Id { get; set; }
        public int ParentId { get; set; }
        public decimal MRP { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Costprice { get; set; }
        public string Unit { get; set; }
        public string Barcode { get; set; }
    }
}
