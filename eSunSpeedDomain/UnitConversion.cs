using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
  public   class UnitConversionModel
    {
        public int ID { get; set; }
        public string MainUnit { get; set; }
        public string SubUnit { get; set; }
       public decimal ConFactor { get; set; }

    }
}
