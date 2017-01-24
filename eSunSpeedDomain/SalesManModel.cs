using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class SalesManModel:AddressModel
    {
        public int SalesMan_Id { get; set; }
        public string SM_Name { get; set; }        
        public string SM_Alias { get; set; }                
        public string SM_PrintName { get; set; }                
        public bool EnableDefCommision { get; set; }

        public string SM_AccounttobeCredited { get; set; }

        public string Commision_Mode { get; set; }
        public decimal DefCommision { get; set; }
        public bool FreezeCommision { get; set; }
        
        public string Sales_DebitMode { get; set; }
        public string Sales_AccDebited { get; set; }
        public string Sales_ACCredited { get; set; }

        public string Purchase_DebitMode { get; set; }
        public string Purchase_AccDebited { get; set; }
        public string Purchase_AccCredited { get; set; } 
        public string CreatedBy { get; set; }      
    }
}
