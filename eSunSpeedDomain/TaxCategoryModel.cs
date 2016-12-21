using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class TaxCategoryModel
    {
        public int TaxCat_Id { get; set; }
        public string Name { get; set; }
        public string TaxCat_Type { get; set; }
        public string Taxation_Type { get; set; }
        public decimal Local_Tax { get; set; }
        public decimal CentralTax { get; set; }
        public bool TaxonMRP { get; set; }
        public decimal CalculatedTaxon { get; set; }
        public string TaxonMRPMode { get; set; }
        public string HSNCode { get; set; }
        public string Tax_Desc { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public List<TaxRatesModel> TaxRates { get; set; }

    }
}
