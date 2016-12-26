using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class AccountMasterModel
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string ShortName { get; set; }

        public string PrintName { get; set; }
        public string LedgerType { get; set; }
        public string Group { get; set; }

        public bool MultiCurrency { get; set; }
        public bool LockSalesType { get; set; }
        public bool LockPurchaseType { get; set; }

        public decimal OPBal { get; set; }
        public decimal PrevYearBal { get; set; }
        public string TypeofDealer { get; set; }

        public int CreditDaysforSale { get; set; }
        public int CreditDaysforPurchase { get; set; }

        public string Transport { get; set; }
        public string Station { get; set; }
        public bool specifyDefaultSaleType { get; set; }

        public string DefaultSaleType { get; set; }
        public bool FreezeSaleType { get; set; }
        public bool FreezePurcType { get; set; }
        public bool SpecifyDefaultPurType { get; set; }

        public decimal InterestRatePayable { get; set; }
        public decimal InterestRateReceivable { get; set; }

        public string DefaultPurcType { get; set; }
        public string address { get; set; }
        public string address1{ get; set; }
        public string address2{ get; set; }
        public string address3 { get; set; }
        public string area { get; set; }
        public string State { get; set; }

        public string TelephoneNumber { get; set; }
        public string Fax { get; set; }
        public string MobileNumber { get; set; }

        public string email { get; set; }
        public bool enablemailquery { get; set; }
        public bool enableSMSquery { get; set; }

        public string contactperson { get; set; }
        public string ITPanNumber { get; set; }        

        public string CSTNumber { get; set; }
        public string TIN { get; set; }
        public string LBTNumber { get; set; }

        public string BankAccountNumber { get; set; }
        public string Ward { get; set; }

        public string CreditLimit { get; set; }
        public string CreditDays { get; set; }
        public bool MaintainBillwiseAccounts { get; set; }
        public bool ActivateInterestCal { get; set; }

        public string DrCrOpeningBal { get; set; }
        public string DrCrPrevBal { get; set; }
        public string LstNumber { get; set; }
        public string ServiceTaxNumber { get; set; }

        public string IECode { get; set; }
        public string ChequePrintName { get; set; }
        public string AcctImage { get; set; }

        public string TypeofBuissness { get; set; }
        public string WebSite { get; set; }
        public string DLNO1 { get; set; }
        public string No1 { get; set; }
        public string allowwebbasedreporting { get; set; }

        public string CreatedBy { get; set; }        
        public string ModifiedBy { get; set; }
    }
}
