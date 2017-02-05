using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class TaxCategoryModel
    {
        //This Model Used For Tax Category & GST Details    
        public int TaxCat_Id { get; set; }
        public string Name { get; set; }
        public string TaxCat_Type { get; set; }
        public string Taxation_Type { get; set; }
        public decimal Local_Tax { get; set; }
        public decimal ServiceTax { get; set; }
        public decimal CentralTax { get; set; }
        public bool TaxonMRP { get; set; }
        public decimal CalculatedTaxon { get; set; }
        public string TaxonMRPMode { get; set; }
        public string HSNCode { get; set; }
        public string Tax_Desc { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        //GST Details
        public long GST_ID { get; set; }
        public string GSTName { get; set; }
        public decimal CGST_Tax { get; set; }
        public decimal SGST_Tax { get; set; }
        public decimal IGST_Tax { get; set; }
        public List<TaxRatesModel> TaxRates { get; set; }
        public List<TaxRatesModel> GSTTaxRates { get; set; }
    }
}
