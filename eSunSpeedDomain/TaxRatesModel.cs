using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class TaxRatesModel
    {  
        //This Model Used For Tax Category & GST Details      
        public int TaxCat_Id { get; set; }
        public int TaxRate_Id { get; set; }
        public DateTime wef { get; set; }
        public decimal Local_Tax { get; set; }
        public decimal Local_Schg { get; set; }
        public string Tax_Type { get; set; }
        public decimal Tax_Central { get; set; }
        public decimal Schg_Central { get; set; }
        public decimal Entry_Tax { get; set; }
        public decimal Service_Tax { get; set; }
        //GST
        public decimal CGST_Tax { get; set; }
        public decimal SGST_Tax { get; set; }
        public decimal IGST_Tax { get; set; }
        public decimal Cess { get; set; }
        public long GSTID { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
