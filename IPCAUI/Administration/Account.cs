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
        AccountSettingsBL objacbl = new AccountSettingsBL();

        AccountSettingsModel lstSettings;

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
            Settings.Accountsettings frm = new Settings.Accountsettings();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
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
            //obj.CreditLimit = tbxcred.Text;

            obj.Transport = tbxTransport.Text;
            obj.Station = tbxStation.Text;

            obj.specifyDefaultSaleType = cbxSpecifydefaultSale.SelectedItem.ToString()=="Y"?true:false;
            obj.DefaultSaleType = cbxDefaultsaletype.SelectedItem.ToString();
            obj.FreezeSaleType = cbxFreezesaletype.SelectedItem.ToString() == "Y" ? true : false;

            obj.SpecifyDefaultPurType = cbxSpecifydefaultPurcType.SelectedItem.ToString().Equals("Y") ? true : false;
            obj.specifyDefaultSaleType = cbxSpecifydefaultPurcType.SelectedItem.ToString().Equals("Y") ? true : false;
            obj.DefaultPurcType = DefaultPurcType.SelectedItem==null?string.Empty: DefaultPurcType.SelectedItem.ToString();

            obj.FreezePurcType = cbxFreezePurcType.SelectedItem.ToString() == "Y" ? true : false;
            obj.InterestRatePayable = Convert.ToDecimal(tbxInterestPay.Text);
            obj.InterestRateReceivable = Convert.ToDecimal(tbxInterestrateReceviable.Text);

            obj.address = tbxAddress.Text.Trim();
            obj.address1 = tbxAddress1.Text.Trim();
            obj.address2 = tbxAddress2.Text.Trim();
            obj.address3 = tbxAddress3.Text.Trim();
            obj.State = cbxState.SelectedItem.ToString();
            obj.area = tbxArea.Text.Trim();
            obj.TelephoneNumber = tbxTelno.Text.Trim();

            obj.Fax = tbxFax.Text;
            obj.MobileNumber = tbxMobileno.Text;
            obj.email = tbxEmail.Text;

            obj.enablemailquery = Convert.ToBoolean(tbxEmailQuery.Text.Trim().Equals("Y") ? true : false);
            obj.enableSMSquery = Convert.ToBoolean(tbxSMSQuery.Text.Trim().Equals("Y") ? true : false);

            obj.contactperson = tbxContactPerson.Text;
            obj.ITPanNumber = tbxITpan.Text;
            obj.Ward = string.Empty;
            obj.LstNumber = tbxLstno.Text;
            obj.CSTNumber = tbxCstno.Text;
            obj.TIN = string.Empty;
            obj.LBTNumber = string.Empty;
            obj.ServiceTaxNumber = string.Empty;
            obj.IECode = tbxIecode.Text;
            obj.DLNO1 = tbxDlno1.Text.Trim();
            obj.No1 = tbxNo1.SelectedText.ToString();
            obj.ChequePrintName = string.Empty;
            obj.allowwebbasedreporting = tbxWebBasedReporting.ToString();

            string message = string.Empty;

            bool isSuccess = accMaster.SaveAccount(obj);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }



            //obj.LockSalesType = cbxLockSalesType.SelectedItem.ToString().Equals("Y") ? true : false;
            // cbxLockSaleTypeAccount.Text = obj.

            //obj.MultiCurrency = cbxMultiCurrency.SelectedItem.ToString().Equals("Y") ? true : false;

            //obj.TypeofBuissness = cbxTypeofBusinessAccount.SelectedItem==null?string.Empty:cbxTypeofBusinessAccount.SelectedItem.ToString();
            //obj.ActivateInterestCal = cbxYesNoActivateInterestCalculation.SelectedItem.ToString().Equals("Y") ? true : false;

            //continue
            // obj.MaintainBillwiseAccounts = cbxYesNoMaintainBillwiseAccounts.SelectedItem.ToString().Equals("Y") ? true : false;

            //obj.Fax = tbxAccountFax.Text;

            //obj.BankAccountNumber = string.Empty;

            //obj.FreezeSaleType = string.Empty;

            //obj.TelephoneNumber = string.Empty;


            //obj.TypeofDealer = string.Empty;

            //obj.WebSite = string.Empty;



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

        private void Account_Load(object sender, EventArgs e)
        {
            layoutLedger.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            Accountsettings();
            Defaultscreen();
        }

        public void Defaultscreen()
        {
            cbxMulticurrency.SelectedIndex = 0;
            cbxPrevCrDr.SelectedIndex = 1;
            cbxCrDr.SelectedIndex = 1;
            cbxMaintainbatchwise.SelectedIndex = 1;
            cbxState.SelectedIndex = 0;
            cbxMaintainbatchwise.SelectedIndex = 1;
            cbxMaintainBalancing.SelectedIndex = 1;

            lblMulticurrency.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            layoutSubledger.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;           
            lblFreezePurcType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblFreezetype.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDefaultPurcType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblSpecifySaletype.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDefaultSaleType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblSpecifyPurcType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDLNo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDLNo1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            grpCreditdays.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblIPayable.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblIReceviable.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblChequePrinting.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblAllocateAmont.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }
        public void Accountsettings()
        {
            AccountSettingsModel lstSettings = objacbl.GetListofAccountSettings(2);
            if(lstSettings.Billbybilldetails)
            {
                //lblMaintainbillbybill.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            if(lstSettings.chequeprinting)
            {
                lblChequePrinting.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            
        }

        private void cbxGroupname_SelectedIndexChanged(object sender, EventArgs e)
        {

            //TODO: Conditions
            if (cbxGroupname.SelectedItem.ToString() == "Unsecured Loans")
            {
                grpCreditdays.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                cbxCrDr.SelectedIndex = 0;
                cbxPrevCrDr.SelectedIndex = 0;
            }
            else
            {
                grpCreditdays.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            }
            if (cbxGroupname.SelectedItem.ToString()=="Sundry Creditors")
            {
              
                //enable fields
            }
            if(cbxGroupname.SelectedItem.ToString()=="Bank Account")
            {
                lblSpecifyPurcType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblDefaultSaleType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblFreezetype.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblSpecifySaletype.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblDefaultPurcType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblFreezePurcType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                cbxSpecifydefaultSale.SelectedIndex = 1;
                cbxSpecifydefaultPurcType.SelectedIndex = 1;
                cbxFreezesaletype.SelectedIndex = 1;
                cbxFreezePurcType.SelectedIndex = 1;
                
            }
            else
            {
                lblSpecifyPurcType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblDefaultSaleType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblFreezetype.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblSpecifySaletype.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblDefaultPurcType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblFreezePurcType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            }
            if(cbxGroupname.SelectedItem.ToString()== "Suspence Account")
            {
                cbxCrDr.SelectedIndex = 1;
                cbxPrevCrDr.SelectedIndex = 1;
            }
            if(cbxGroupname.SelectedItem.ToString()== "Sunday Debitors")
            {
                cbxCrDr.SelectedIndex = 1;
                cbxPrevCrDr.SelectedIndex = 1;
                cbxMaintainBalancing.SelectedIndex = 0;
            }

        }

        private void cbxSpecifydefaultSale_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cbxSpecifydefaultSale_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(cbxSpecifydefaultSale.SelectedItem.ToString() == "N")
            {
                lblDefaultSaleType.Enabled = false;
            }
           else
            {
                lblDefaultSaleType.Enabled = true;
            }
        }

        private void cbxSpecifydefaultPurcType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSpecifydefaultPurcType.SelectedItem.ToString() == "N")
            {
                lblDefaultPurcType.Enabled = false;
            }
            else
            {
                lblDefaultPurcType.Enabled = true;
            }
           
        }

        private void cbxMaintainBalancing_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxMaintainBalancing.SelectedItem.ToString()=="Y")
            {
                grpCreditdays.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                grpCreditdays.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            }
        }
    }
}
