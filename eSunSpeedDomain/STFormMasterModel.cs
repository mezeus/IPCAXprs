using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class STFormMasterModel
    {
        public int STF_Id { get; set; }
        public string Name { get; set; }
        public string PrintName { get; set; }
        public string STRegType { get; set; }//ComboWillCome in 1.Local 2.Central.Road Permit
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
