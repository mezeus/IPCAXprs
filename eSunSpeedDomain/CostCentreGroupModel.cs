using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
  public  class CostCentreGroupModel
    {
        public int CCG_ID { get; set; }        
        public string GroupName { get; set; }
        public string Alias { get; set; }
        public bool PrimaryGroup { get; set; }
        public string underGroup { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
    }
}
