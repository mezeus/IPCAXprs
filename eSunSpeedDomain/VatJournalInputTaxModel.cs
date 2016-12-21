using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class VatJournalInputTaxModel
    {
        public string Month { get; set; }

        public string Tax_Inc_Dec { get; set; }
        public string Nature { get; set; }
        public decimal Pure_Amt { get; set; }
        public decimal Tax { get; set; }
        public decimal Schg { get; set; }        
        public decimal Inc_Amt { get; set; }                        
        public decimal Inc_Schg { get; set; }
        public decimal Dec_Amt { get; set; }
        public decimal Dec_Schg { get; set; }
        public decimal Total_Pure_Amt { get; set; }
        public decimal Total_Inc_Amt { get; set; }
        public decimal Total_Dec_Amt { get; set; }

        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        
       
    }
}
