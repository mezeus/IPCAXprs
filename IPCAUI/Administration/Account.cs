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

            //if (tbxName.Text.Equals(string.Empty))
            //{
            //    MessageBox.Show("Account Name can not be blank!");
            //    return;
            //}

            //if (accObj.IsAccountExists(tbxAccountName.Text.Trim()))
            //{
            //    MessageBox.Show("Account Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
            //    tbxAccountName.Focus();
            //    return;
            //}

            //AccountMasterModel obj = new AccountMasterModel();

            //obj.AccountName = tbxAccountName.Text.Trim();
            //obj.PrintName = tbxPrintNameAccount.Text.Trim();
            //obj.ShortName = tbxShortNameAccount.Text;
            ////obj.LedgerType = cbxLederyType.SelectedItem==null?string.Empty: cbxLederyType.SelectedItem.ToString();

            //obj.Group = cbxAccountGroup.SelectedItem == null ? string.Empty : cbxAccountGroup.SelectedItem.ToString();

            //obj.OPBal = Convert.ToDecimal(tbxAccountOpeningBalace.Text);
            //obj.PrevYearBal = Convert.ToDecimal(tbxPrevBalance.Text);
            //obj.DrCrOpeningBal = cbxAccountDrCrOpeningBalance.SelectedItem.ToString();
            //obj.DrCrPrevBal = cbxAccountDrCrPrevYearBalance.SelectedItem.ToString();

            //obj.CreditDays = tbxCreditDaysAccount.Text;
            ////obj.CreditLimit = tbxCreditLimitAccount.Text;

            //obj.Transport = tbxTransport.Text;
            //obj.Station = tbxStation.Text;


            ////obj.State = cbxAccountState.SelectedItem==null?string.Empty:cbxAccountState.SelectedItem.ToString();
            ////obj.DefaultPurcType = cbxDefaultPurchaseTypeAccount.SelectedItem==null?string.Empty: cbxDefaultPurchaseTypeAccount.SelectedItem.ToString();
            ////obj.DefaultSaleType = cbxDefaultSaleTypeAccount.SelectedItem==null?string.Empty: cbxDefaultSaleTypeAccount.SelectedItem.ToString();
            ////obj.LockSalesType = cbxLockSalesType.SelectedItem.ToString().Equals("Y") ? true : false;
            //// cbxLockSaleTypeAccount.Text = obj.

            ////obj.MultiCurrency = cbxMultiCurrency.SelectedItem.ToString().Equals("Y") ? true : false;
            ////obj.SpecifyDefaultPurType = cbxSpecifyDefaultPurcTypeAccount.SelectedItem.ToString().Equals("Y") ? true : false;
            ////obj.specifyDefaultSaleType = cbxSpecifyDefaultSaleTypeAccount.SelectedItem.ToString().Equals("Y") ? true : false;
            ////obj.TypeofBuissness = cbxTypeofBusinessAccount.SelectedItem==null?string.Empty:cbxTypeofBusinessAccount.SelectedItem.ToString();
            ////obj.ActivateInterestCal = cbxYesNoActivateInterestCalculation.SelectedItem.ToString().Equals("Y") ? true : false;

            ////continue
            //obj.MaintainBillwiseAccounts = cbxYesNoMaintainBillwiseAccounts.SelectedItem.ToString().Equals("Y") ? true : false;
            ////obj.address1 = tbxAccountAddress.Text.Trim();
            ////obj.address2 = tbxAccountAddressLine1.Text.Trim();
            ////obj.address3 = tbxAccountAddressLine2.Text.Trim();
            ////obj.address4 = tbxAccountAddressLine3.Text.Trim();

            ////obj.contactperson = tbxAccountContactPerson.Text;
            ////obj.CSTNumber = tbxAccountCSTNo.Text;
            ////obj.email = tbxAccountEMail.Text;
            ////obj.enablemailquery = cbxEnableEmail.SelectedItem.ToString().Equals("Y") ? true : false;
            ////obj.enableSMSquery = cbxEnableSMS.SelectedItem.ToString().Equals("Y") ? true : false;

            ////obj.Fax = tbxAccountFax.Text;
            ////obj.IECode = tbxAccountIECode.Text;
            ////obj.ITPanNumber = tbxAccountITPAN.Text;
            ////obj.LstNumber = tbxAccountLstNo.Text;
            ////obj.MobileNumber = tbxAccountMobileNo.Text;

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

        private void tbxName_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void Account_Load(object sender, EventArgs e)
        {
            cbxLedgertype.SelectedIndex = 0;
            cbxGroupname.SelectedIndex = 0;
            cbxMulticurrency.SelectedIndex = 0;
            cbxMaintainbatchwise.SelectedIndex = 0;
            cbxCrDr.SelectedIndex = 0;
            cbxPrevCrDr.SelectedIndex = 0;
            cbxMaintainBalancing.SelectedIndex = 0;
            cbxSpecifydefaultSale.SelectedIndex = 0;
            cbxSpecifydefaultPurcType.SelectedIndex = 0;
            cbxFreezePurcType.SelectedIndex = 0;
            cbxFreezesaletype.SelectedIndex = 0;
            cbxState.SelectedIndex = 0;
            

        }

        private void tbxName_Leave(object sender, EventArgs e)
        {
            if (tbxName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Group Name can not be blank!");
                tbxName.Focus();
                return;
            }
           
        }

        private void tbxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                //if (obj.IsGroupExists(tbxName.Text.Trim()))
                //{
                //    MessageBox.Show("Group Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
                //    tbxGroupName.Focus();
                //    return;
                //}
                if (this.ActiveControl == null)
                {
                    MessageBox.Show("Account Name Can Not Be Blank!");
                    return;
                    this.ActiveControl = tbxName;

                }
                //e.Handled = true; // Mark the event as handled
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
