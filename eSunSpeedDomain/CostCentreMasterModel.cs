using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
  public   class CostCentreMasterModel
    {
        public int CCM_ID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Group { get; set; }
        public decimal opBal { get; set; }
        public string  DrCr { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
    }
}
