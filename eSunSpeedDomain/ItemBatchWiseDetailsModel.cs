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
        public DateTime MfgDate { get; set; }
        public DateTime Expdate { get; set; }
    }
}
