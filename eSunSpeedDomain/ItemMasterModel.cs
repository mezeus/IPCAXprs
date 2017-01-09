﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class ItemMasterModel
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string PrintName { get; set; }

        //Group

        public string Group { get; set; }
        public string Company { get; set; }

        public string MainUnit { get; set; }
        
        public double OpStockQty { get; set; }
        
        public double OpStockValue { get; set; }

        public string AltUnit { get; set; }
        public string Unit { get; set; }
        public decimal ConAltUnit { get; set; }
        public decimal ConMainUnit { get; set; }

        public string ConType { get; set; }
        
        public double AltOpQty { get; set; }
        public double Rate { get; set; }
        public string Per { get; set; }
        public double Value { get; set; }

        public string ApplySalesPrice { get; set; }
        public string ApplyPurchPrice { get; set; }

        //Item Main Unit Price Info
        public decimal MainSalePrice { get; set; }
        public decimal MainPurprice { get; set; }
        public decimal MainMRP { get; set; }
        public decimal MainMinSalePrice { get; set; }
        public decimal SelfValuePrice { get; set; }
        public string StockValMethod { get; set; }

        //Item Alt Unit Price Info
        public decimal AltSalePrice { get; set; }
        public decimal AltPurprice { get; set; }
        public decimal AltMRP { get; set; }
        public decimal AltMinSalePrice { get; set; }
        
        //Discount
        public decimal SaleDiscount { get; set; }      
        public decimal PurDiscount { get; set; }        
        public decimal SaleCompoundDiscount { get; set; }     
        public decimal PurCompoundDiscount { get; set; }

        //
        public bool DiscountInfo { get; set; }
        public bool MarkupInfo { get; set; }
        //Settings 

        public bool SpecifySaleDiscStructure { get; set; }
        public bool SpecifyPurDiscStructure { get; set; }
        //Need To Add Two Parameters

        //Markup
        public string SaleMarkup { get; set; }
        public string PurMarkup { get; set; }
        public string SaleCompMarkup { get; set; }
        public string PurCompMarkup { get; set; }
        public bool SpecifySaleMarkupStruct { get; set; }
        public bool SpecifyPurMarkupStruct { get; set; }

        //Tax Details
        public string TaxCategory { get; set; }
        public string TaxType { get; set; }

        
        public double ServiceTaxRate { get; set; }
        
        public double RateofTax_Local { get; set; }
        
        public double RateofTax_Central { get; set; }
        public bool TaxonMRP { get; set; }
        public string HSNCode { get; set; }
        
        //Item Description
        public string ItemDescription1 { get; set; }
        public string ItemDescription2 { get; set; }
        public string ItemDescription3 { get; set; }
        public string ItemDescription4 { get; set; }
        public string ItemDescription5 { get; set; }
        public string ItemDescription6 { get; set; }

        public bool SetCriticalLevel { get; set; }
        public bool MaintainRG23D { get; set; }
        public string TariffHeading { get; set; }
        public bool SerialNumberwiseDetails { get; set; }
        public bool MRPWiseDetails { get; set; }
        public bool ParameterizedDetails { get; set; }
        public bool BatchwiseDetails { get; set; }
        public bool ExpDateRequired { get; set; }
        public int ExpiryDays { get; set; }

        public string SalesAccount { get; set; }
        public string PurcAccount { get; set; }


        public bool SpecifyDefaultMC { get; set; }
        public bool FreezeMCforItem { get; set; }

        public int TotalNumberofAuthors { get; set; }
        public bool DontMaintainStockBal { get; set; }
        public bool PickItemSizefromDescription { get; set; }
        public bool SpecifyDefaultVendor { get; set; }

        public List<string> BarCodes { get; set; }

        //Audit 
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        //public ItemMasterModel()
        //{
        //    foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(this))
        //    {
        //        DefaultValueAttribute myAttribute = (DefaultValueAttribute)property.Attributes[typeof(DefaultValueAttribute)];

        //        if (myAttribute != null)
        //        {
        //            property.SetValue(this, myAttribute.Value);
        //        }
        //    }
        //}

    }
}
