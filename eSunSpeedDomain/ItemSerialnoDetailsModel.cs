using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class ItemSerialnoDetailsModel
    {
        public int SL_ID { get; set; }
        public int parent_Id { get; set; }

        public int SerialNumber { get; set; }
        public decimal MRP { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Costprice { get; set; }
        public string Unit { get; set; }
        public string Barcode { get; set; }
    }
}
