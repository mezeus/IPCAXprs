using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eSunSpeed.BusinessLogic;
using eSunSpeedDomain;

namespace IPCAUI.Settings
{
    public partial class Accountsettings : DevExpress.XtraEditors.XtraForm
    {
        AccountSettingsBL objAccsBl = new AccountSettingsBL();
        public Accountsettings()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AccountSettingsModel objmodel = new AccountSettingsModel();
            objmodel.Billbybilldetails = chkBillbybill.Checked==true ? true:false;
            objmodel.creditlimits= chkCreditlimt.Checked == true ? true : false;
            objmodel.targets = chkTargets.Checked == true ? true : false;
            objmodel.costcenters = chkCostcenter.Checked == true ? true : false;
            objmodel.fbtreporting = chkFbtReport.Checked == true ? true : false;
            objmodel.bankreconcilations = chkBankRecon.Checked == true ? true : false;
            objmodel.postdatedcheques = chkPostdatedchq.Checked == true ? true : false;
            objmodel.saleswisemanbrokerwisereporting = chkSalesmanwiseRep.Checked == true ? true : false;
            objmodel.budgets = chkBudgets.Checked == true ? true : false;
            objmodel.royaltycalculation = chkRoylatyCal.Checked == true ? true : false;
            objmodel.companyactdepreciation = chkCompanyDesp.Checked == true ? true : false;
            objmodel.multicurrency = chkMultcurr.Checked == true ? true : false;
            objmodel.currencycondecimalplaces = tbxDecimalplaces.Text.Trim();
            objmodel.maintainsubledgers = chkSubLedgers.Checked == true ? true : false;
            objmodel.postingaccountssalespurchasereturn = chkPostingAccounts.Checked == true ? true : false;
            objmodel.doubleentrysystemforpaymentreceiptvoucher = chkDoubleEntity.Checked == true ? true : false;
            objmodel.showaccountscurrentbalduringvoucher = chkCurrentBalance.Checked == true ? true : false;
            objmodel.maintainimagenotes = chkMaintainImages.Checked == true ? true : false;
            objmodel.balancesheetstockupdate = cbxBalanceStockupdate.SelectedItem.ToString();
            objmodel.ledgerreconciliation = chkLedgerRecon.Checked == true ? true : false;
            objmodel.chequeprinting = chkChqPrinting.Checked == true ? true : false;
            objmodel.accountwiseinterstrate = chkAccountWiseInterest.Checked == true ? true : false;
            objmodel.enablepartydashboard = chkPartyDashboard.Checked == true ? true : false;
            objmodel.showpartydashboardselectingpartyvoucher = cbxSelectingParty.SelectedItem.ToString() == "Y" ? true : false;

            bool isscusses = objAccsBl.SaveAccountingSetting(objmodel);
              if(isscusses)
            {
                MessageBox.Show("Saved Scussfully");
            }
        }
    }
}
