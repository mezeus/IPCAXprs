using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeedDomain
{
    public class AccountSettingsModel
    {
        public int AccountsId { get; set; }
        public bool Billbybilldetails { get; set; }
        public bool creditlimits { get; set; }
        public bool targets { get; set; }
        public bool costcenters { get; set; }
        public bool fbtreporting { get; set; }
        public bool bankreconcilations { get; set; }
        public bool postdatedcheques { get; set; }
        public bool saleswisemanbrokerwisereporting { get; set; }
        public bool budgets { get; set; }
        public bool royaltycalculation { get; set; }
        public bool companyactdepreciation { get; set; }
        public bool multicurrency { get; set; }
        public string currencycondecimalplaces { get; set; }
        public bool maintainsubledgers { get; set; }
        public bool postingaccountssalespurchasereturn { get; set; }

        public bool doubleentrysystemforpaymentreceiptvoucher { get; set; }
        public bool showaccountscurrentbalduringvoucher { get; set; }

        public bool maintainimagenotes { get; set; }
        public string balancesheetstockupdate { get; set; }
        public bool ledgerreconciliation { get; set; }
        public bool enableFBTcalatGrouplevel { get; set; }
        public bool chequeprinting { get; set; }
        public bool accountwiseinterstrate { get; set; }
        public bool enablepartydashboard { get; set; }
        public bool showpartydashboardselectingpartyvoucher { get; set; }
       
    }
}
