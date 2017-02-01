using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
  public class PurchaseTypeModel
    {
        public int Purch_Id { get; set; }
        public string PurchType { get; set; }
        //this GroupBox for sales Account Information of RadioButton
        public bool typeSpecifyHereSingleAccount { get; set; }//if select button Ledger CoboBoxWillope
        public string LedgerAccountBox { get; set; }
        public bool typeDifferentTaxRate { get; set; }//Setting Button will come enable thisRadioButton
        public bool typeSpecifyINVoucher { get; set; }

        //TaxationType: RadioButton Group
        public bool typeTaxable { get; set; }//if Enable Tax Calculation RadioButton Group Visible
        public bool typeMultiTax { get; set; }//if Enable:1)TaxInvoice: Y/N 2)Calculate Tax on Item MRP: Y/N 3)Tax Incluse Item Price:Y/N 4) Calculate Tax on: TexBox, 5)Adjust Tax in Sales Account: Y/N 6) Tax Account: Ledger List(cbx)
        public bool typeAgainstSTFrom { get; set; }
        public bool typeTaxpaid { get; set; }
        public bool typeExempt { get; set; }//if Enabble TaxInvoice: Y/N Will Hide
        public bool typeTaxFree { get; set; }
        public bool typeLUMSumDealer { get; set; }
        public bool typeUnRegDealer { get; set; }

        // other Information Group

        public bool TaxInvoice { get; set; }
        public string VatReturnCategory { get; set; }//This is Combobox;
        public bool VatSaleTaxReport { get; set; }
        public decimal CalculatedTax { get; set; }
        public string TaxAmount { get; set; }
        public bool SkipVatorSaleTaxReport { get; set; }

        //if Enable MultiTax Will Show on other Information Group
        public bool CalculateTaxonItemMRP { get; set; }
        public bool TaxInclusiveItemPrice { get; set; }
        public decimal CalculateTaxonpercentofAmount { get; set; }
        public bool AdjustTaxinSaleAccount { get; set; }
        public string TaxAccount { get; set; }

        //Region Radio Button GroupBox

        public bool TypeLocal { get; set; }
        public bool TypeCentral { get; set; }


        //Type of Transaction on Region GrupBox Sub

        public bool TypeStockTransfer { get; set; }
        public bool TypeOther { get; set; }
        public bool ExportNormal { get; set; }
        public bool SaleinTransit { get; set; }
        public bool ExportHighsea { get; set; }

        // Form Information:if Enabl typeAgainstSTFromT
        public bool IssueSTFrom { get; set; }// if Enable This STFrom List ComboBox will Show
        public string FromIssuable { get; set; }
        public bool ReceiveSTForm { get; set; }// if Enable This ReceiveFrom List
        public string FromReceivable { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        //Tax Calculation Group Box
        public bool SingleTaxRate { get; set; }
        public bool MultiTaxRate { get; set; }
        public decimal TaxinPercentage { get; set; }
        public decimal SurchargeInPercentage { get; set; }
        public bool freezeTaxinSales { get; set; }
        public bool freezeTaxinSalesReturn { get; set; }
        public string InvoiceHeading { get; set; }
        public string InvoiceDescription { get; set; }


    }
}
