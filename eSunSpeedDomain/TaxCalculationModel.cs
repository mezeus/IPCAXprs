using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class TaxCalculationModel
    {
        public decimal Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Taxslab { get; set; }
        //We Need To Calculate
        public decimal TaxAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal BasicAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal CGSTAmount { get; set; }
        public decimal SGSTAmount { get; set; }
        public decimal IGSTAmount { get; set; }
    }
}
