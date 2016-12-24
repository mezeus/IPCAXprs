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
namespace IPCAUI.Administration
{
    public partial class Account : Form
    {

        AccountMasterBL accMaster = new AccountMasterBL();

        public Account()
        {
            InitializeComponent();
        }

        private void tbxQuit_Click(object sender, EventArgs e)
        {
            
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void navbtnAccount_ItemChanged(object sender, EventArgs e)
        {
            
        }

        private void navbtnAccountsettings_ItemChanged(object sender, EventArgs e)
        {
           
        }

        private void navBarItem11_ItemChanged(object sender, EventArgs e)
        {
            //Settings.AccountsDemo frm = new Settings.AccountsDemo();
            //frm.StartPosition = FormStartPosition.CenterScreen;
            //frm.ShowDialog(this);
        }

        private void navbtnAccountsettings_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Settings.AccountsDemo frm = new Settings.AccountsDemo();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            //TODO: 1. Check whether the account name exists or not
            //2. if exist then do not allow to save with the same account name
            //3. Prompt user to change the account name as it already exists

            if (tbxName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Account Name can not be blank!");
                return;
            }

            if (accMaster.IsAccountExists(tbxName.Text.Trim()))
            {
                MessageBox.Show("Account Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
                tbxName.Focus();
                return;
            }

            AccountMasterModel obj = new AccountMasterModel();

            obj.AccountName = tbxName.Text.Trim();
            obj.PrintName = tbxPrintname.Text.Trim();
            obj.ShortName = tbxAlias.Text;
            //obj.LedgerType = cbxLederyType.SelectedItem==null?string.Empty: cbxLederyType.SelectedItem.ToString();

            obj.Group = cbxGroupname.SelectedItem == null ? string.Empty : cbxGroupname.SelectedItem.ToString();

            obj.OPBal = Convert.ToDecimal(tbxOpbal.Text);
            obj.PrevYearBal = Convert.ToDecimal(tbxPrevyearbal.Text);
            obj.DrCrOpeningBal = cbxCrDr.SelectedItem.ToString();
            obj.DrCrPrevBal = cbxPrevCrDr.SelectedItem.ToString();

            obj.CreditDaysforSale = Convert.ToInt32(tbxCreditdaysforSale.Text);
            obj.CreditDaysforPurchase= Convert.ToInt32(tbxCreditdaysforPurc.Text);
            //obj.CreditLimit = tbxCreditLimitAccount.Text;

            obj.Transport = tbxTransport.Text;
            obj.Station = tbxStation.Text;

            obj.specifyDefaultSaleType = cbxSpecifydefaultSale.SelectedItem.ToString()=="Y"?true:false;
            obj.DefaultSaleType = cbxDefaultsaletype.SelectedItem.ToString();
            obj.FreezeSaleType = cbxFreezesaletype.SelectedItem.ToString() == "Y" ? true : false;

            obj.SpecifyDefaultPurType = cbxSpecifydefaultPurcType.SelectedItem.ToString().Equals("Y") ? true : false;
            obj.specifyDefaultSaleType = cbxSpecifydefaultPurcType.SelectedItem.ToString().Equals("Y") ? true : false;
            obj.DefaultPurcType = DefaultPurcType.SelectedItem==null?string.Empty: DefaultPurcType.SelectedItem.ToString();

            obj.FreezePurcType = cbxFreezePurcType.SelectedItem.ToString() == "Y" ? true : false;
            obj.InterestRatePayable = Convert.ToInt32(tbxInterestPay.Text);
            obj.InterestRateReceivable = Convert.ToInt32(tbxInterestrateReceviable.Text);

            obj.State = cbxState.SelectedItem.ToString();
            
            //obj.LockSalesType = cbxLockSalesType.SelectedItem.ToString().Equals("Y") ? true : false;
            // cbxLockSaleTypeAccount.Text = obj.

            //obj.MultiCurrency = cbxMultiCurrency.SelectedItem.ToString().Equals("Y") ? true : false;

            //obj.TypeofBuissness = cbxTypeofBusinessAccount.SelectedItem==null?string.Empty:cbxTypeofBusinessAccount.SelectedItem.ToString();
            //obj.ActivateInterestCal = cbxYesNoActivateInterestCalculation.SelectedItem.ToString().Equals("Y") ? true : false;

            //continue
           // obj.MaintainBillwiseAccounts = cbxYesNoMaintainBillwiseAccounts.SelectedItem.ToString().Equals("Y") ? true : false;
            //obj.address1 = tbxAccountAddress.Text.Trim();
            //obj.address2 = tbxAccountAddressLine1.Text.Trim();
            //obj.address3 = tbxAccountAddressLine2.Text.Trim();
            //obj.address4 = tbxAccountAddressLine3.Text.Trim();

            //obj.contactperson = tbxAccountContactPerson.Text;
            //obj.CSTNumber = tbxAccountCSTNo.Text;
            //obj.email = tbxAccountEMail.Text;
            //obj.enablemailquery = cbxEnableEmail.SelectedItem.ToString().Equals("Y") ? true : false;
            //obj.enableSMSquery = cbxEnableSMS.SelectedItem.ToString().Equals("Y") ? true : false;

            //obj.Fax = tbxAccountFax.Text;
            //obj.IECode = tbxAccountIECode.Text;
            //obj.ITPanNumber = tbxAccountITPAN.Text;
            //obj.LstNumber = tbxAccountLstNo.Text;
            //obj.MobileNumber = tbxAccountMobileNo.Text;

            //obj.BankAccountNumber = string.Empty;
            //obj.ChequePrintName = string.Empty;
            //obj.FreezeSaleType = string.Empty;
            //obj.Ward = string.Empty;
            //obj.TelephoneNumber = string.Empty;
            //obj.ServiceTaxNumber = string.Empty;
            //obj.TIN = string.Empty;
            //obj.TypeofDealer = string.Empty;
            //obj.LBTNumber = string.Empty;
            //obj.WebSite = string.Empty;

            //string message = string.Empty;

            //bool isSuccess = accObj.SaveAccount(obj);

            //List<AccountMasterModel> lstAccounts = accObj.GetListofAccount();
            //dgvList.DataSource = lstAccounts;

            //Dialogs.PopUPDialog d = new Dialogs.PopUPDialog("Saved Successfully!");
            //d.ShowDialog();

    
        }

        private void ListAccount_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.AccountList frmList = new Administration.List.AccountList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
        }
    }
}
