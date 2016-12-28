using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class CompanyModel
    {
        public int CompanyId { get; set; }

        public string Name { get; set; }
        public string PrintName { get; set; }
        public string ShortName { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public DateTime FYBegining { get; set; }
        public DateTime BooksCommencing { get; set; }
        public string Address { get; set; }
        public string CIN { get; set; }
        public string PAN { get; set; }
        public string Ward { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string CurrencyString { get; set; }
        public string CurrencySubString { get; set; }                          
        public string CurrencyFont { get; set; }
        public string CurrencyCharacter { get; set; }
        public string CurrencySymbol { get; set; }
        public string VAT { get; set; }
        public bool EnableTaxSchg { get; set; }
        public string Type { get; set; }
        public string TIN { get; set; }
        public string CSTNo { get; set; }
        
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
       
    }    
}
