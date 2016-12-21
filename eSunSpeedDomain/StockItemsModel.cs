using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class StockItemsModel
    {
        public int Parent_Id { get; set; }
        public int item_Id { get; set; }
        public string item { get; set; }
        public decimal Pstock { get; set; }
        public decimal Bstock { get; set; }
        public decimal Difference { get; set; }
    }
}
