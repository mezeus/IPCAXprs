using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
 public   class MaterialCentreGroupMasterModel
    {
        public int MCG_ID { get; set; }
        public string Group { get; set; }
        public string Alias { get; set; }
        public bool PrimaryGroup { get; set; }
        public string UnderGroup { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
