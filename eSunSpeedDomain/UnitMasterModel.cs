using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
  public   class UnitMasterModel
    {
        public int UM_ID { get; set; }
        public string UnitName { get; set; }
        public string PrintName { get; set; }
        public string ExciseReturn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
