using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class ItemBatchWiseDetailsModel
    {
        public int Batch_Id { get; set; }
        public int Parent_Id { get; set; }
        public int BatchNo { get; set; }
        public int Qty { get; set; }
        public string Unit { get; set; }
        public decimal MRP { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public DateTime MfgDate { get; set; }
        public DateTime Expdate { get; set; }
        public string Narration { get; set; }
        public string Barcode { get; set; }
    }
}
