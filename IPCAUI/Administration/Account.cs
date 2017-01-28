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
        public static int groupId = 0;
        public static AccountMasterModel objAccount = new AccountMasterModel();
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
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
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
                tbxName.Focus();
                return;
            }

            if (accMaster.IsAccountExists(tbxName.Text.Trim()))
            {
                MessageBox.Show("Account Name already Exists!");
                tbxName.Focus();
                return;
            }          
            objAccount.AccountName = tbxName.Text.Trim();
            objAccount.PrintName = tbxPrintname.Text.Trim()==null?string.Empty:tbxPrintname.Text.Trim();
            objAccount.ShortName = tbxAlias.Text == null ? string.Empty : tbxPrintname.Text.Trim();
            objAccount.LedgerType = cbxLedgertype.SelectedItem==null?string.Empty: cbxLedgertype.SelectedItem.ToString();
            objAccount.Group = cbxGroupname.SelectedItem == null ? string.Empty : cbxGroupname.SelectedItem.ToString();
            objAccount.MultiCurrency = Convert.ToBoolean(cbxMulticurrency.SelectedItem.ToString() == "Y" ? true : false);

            objAccount.OPBal = Convert.ToDecimal(tbxOpbal.Text.Trim()==string.Empty?"0.00": tbxOpbal.Text.Trim());
            if(objAccount.OPBal!=0)
            {
                PopupScreens.CostcenterPopup frmCost = new PopupScreens.CostcenterPopup();
                frmCost.StartPosition = FormStartPosition.CenterParent;
                frmCost.ShowDialog();
            }
            objAccount.PrevYearBal = Convert.ToDecimal(tbxPrevyearbal.Text.Trim()==string.Empty?"0.00": tbxPrevyearbal.Text.Trim());
            objAccount.DrCrOpeningBal = cbxCrDr.SelectedItem.ToString();
            objAccount.DrCrPrevBal = cbxPrevCrDr.SelectedItem.ToString();
            objAccount.MaintainBillwiseAccounts = cbxMaintainBalancing.SelectedItem.ToString() == "Y" ? true : false;
            objAccount.AllocateAmountItems = cbxAllocateAmount.SelectedItem.ToString() == "Y" ? true : false;
            objAccount.CreditDaysforSale = Convert.ToInt32(tbxCreditdaysforSale.Text==string.Empty ? "0":tbxCreditdaysforSale.Text.Trim());
            objAccount.CreditDaysforPurchase= Convert.ToInt32(tbxCreditdaysforPurc.Text == string.Empty ? "0" : tbxCreditdaysforPurc.Text.Trim());
            
            if(objAccount.MaintainBillwiseAccounts)
            {
                PopupScreens.MaintainBillByBillDetails frmbill = new PopupScreens.MaintainBillByBillDetails();
                frmbill.StartPosition = FormStartPosition.CenterParent;
                frmbill.ShowDialog();
            }
            PopupScreens.SalesManDetails frmSM = new PopupScreens.SalesManDetails();
            frmSM.StartPosition = FormStartPosition.CenterParent;
            frmSM.ShowDialog();
            //objAccount.CreditLimit = tbxcred.Text;
            PopupScreens.CreditLimitforAccount frmCredit = new PopupScreens.CreditLimitforAccount();
            frmSM.StartPosition = FormStartPosition.CenterParent;
            frmCredit.ShowDialog();
            PopupScreens.UnclearChequeDeposite frmDeposites = new PopupScreens.UnclearChequeDeposite();
            frmSM.StartPosition = FormStartPosition.CenterParent;
            frmDeposites.ShowDialog();
            PopupScreens.BudgetsforAccount frmBudget = new PopupScreens.BudgetsforAccount();
            frmSM.StartPosition = FormStartPosition.CenterScreen;
            frmBudget.ShowDialog();

            PopupScreens.UnclearChequeIssued frmIssued = new PopupScreens.UnclearChequeIssued();
            frmSM.StartPosition = FormStartPosition.CenterParent;
            frmIssued.ShowDialog();

            objAccount.Transport = tbxTransport.Text==null?string.Empty:tbxTransport.Text;
            objAccount.Station = tbxStation.Text == null ? string.Empty : tbxStation.Text;

            //objAccount.specifyDefaultSaleType = cbxSpecifydefaultSale.SelectedItem.ToString()=="Y"?true:false;
            //objAccount.FreezeSaleType = cbxFreezesaletype.SelectedItem.ToString() == "Y" ? true : false;
            //objAccount.DefaultSaleType = cbxDefaultsaletype.SelectedItem.ToString() == ""? string.Empty : cbxDefaultsaletype.SelectedItem.ToString();

            //objAccount.SpecifyDefaultPurType = cbxSpecifydefaultPurcType.SelectedItem.ToString().Equals("Y") ? true : false;
            //objAccount.DefaultPurcType = cbxDefaultPurcType.SelectedItem==null?string.Empty: cbxDefaultPurcType.SelectedItem.ToString();
            //objAccount.FreezePurcType = cbxFreezePurcType.SelectedItem.ToString() == "Y" ? true : false;

            objAccount.InterestRatePayable = Convert.ToDecimal(tbxInterestPay.Text==string.Empty?"0.00":tbxInterestPay.Text);
            objAccount.InterestRateReceivable = Convert.ToDecimal(tbxInterestrateReceviable.Text ==string.Empty? "0.00" :tbxInterestrateReceviable.Text.Trim());
            objAccount.address = tbxAddress.Text.Trim()==null?string.Empty:tbxAddress.Text.Trim();
            objAccount.address1 = tbxAddress1.Text.Trim() == null ? string.Empty : tbxAddress1.Text.Trim();
            objAccount.address2 = tbxAddress2.Text.Trim() == null ? string.Empty : tbxAddress2.Text.Trim();
            objAccount.address3 = tbxAddress3.Text.Trim() == null ? string.Empty : tbxAddress3.Text.Trim();
            objAccount.State = cbxState.SelectedItem.ToString();
            objAccount.area = tbxArea.Text.Trim() == null ? string.Empty : tbxArea.Text.Trim();
            objAccount.TelephoneNumber = tbxTelno.Text.Trim() == null ? string.Empty : tbxTelno.Text.Trim();

            objAccount.Fax = tbxFax.Text == null ? string.Empty : tbxFax.Text.Trim();
            objAccount.MobileNumber = tbxMobileno.Text == null ? string.Empty : tbxMobileno.Text.Trim();
            objAccount.email = tbxEmail.Text == null ? string.Empty : tbxEmail.Text.Trim();

            objAccount.enablemailquery = Convert.ToBoolean(tbxEmailQuery.Text.Trim().Equals("Y") ? true : false);
            objAccount.enableSMSquery = Convert.ToBoolean(tbxSMSQuery.Text.Trim().Equals("Y") ? true : false);

            objAccount.contactperson = tbxContactPerson.Text == null ? string.Empty : tbxContactPerson.Text.Trim();
            objAccount.ITPanNumber = tbxITpan.Text == null ? string.Empty : tbxITpan.Text.Trim();
            objAccount.Ward = tbxWard.Text == null ? string.Empty : tbxWard.Text.Trim();
            objAccount.LstNumber = tbxLstno.Text == null ? string.Empty : tbxLstno.Text.Trim();
            objAccount.CSTNumber = tbxCstno.Text == null ? string.Empty : tbxCstno.Text.Trim();
            objAccount.TIN = tbxTin.Text==null? string.Empty : tbxTin.Text.Trim();
            objAccount.LBTNumber = tbxlbtno == null ? string.Empty : tbxlbtno.Text.Trim();
            objAccount.ServiceTaxNumber =tbxServicetax== null ? string.Empty : tbxServicetax.Text.Trim();
            objAccount.IECode = tbxIecode.Text == null ? string.Empty : tbxIecode.Text.Trim();
            objAccount.DLNO1 = tbxDlno1.Text.Trim() == null ? string.Empty : tbxDlno1.Text.Trim();
            objAccount.No1 = tbxNo1.Text.Trim() == null ? string.Empty : tbxNo1.Text.Trim();
            objAccount.ChequePrintName = tbxChequePrintName.Text == null ? string.Empty : tbxChequePrintName.Text.Trim();
            objAccount.allowwebbasedreporting = tbxWebBasedReporting.Text.Trim()==null? string.Empty: tbxWebBasedReporting.Text.Trim();
            //objAccount.BankAccountNumber=
            string message = string.Empty;

            bool isSuccess = accMaster.SaveAccount(objAccount);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                ClearControls();
                groupId = 0;
            }

        }

        private void ListAccount_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.AccountList frmList = new Administration.List.AccountList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();

            FillAccountInfo();
        }

        private void FillAccountInfo()
        {
             objAccount = accMaster.GetListofAccountByAccountId(groupId);

            if(groupId==0)
            {
                tbxName.Focus();
                laCtrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                laCtrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                laCtrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                return;
            }
            //objAccount.AccountId = Convert.ToInt32(dr["Ac_ID"]);
            tbxName.Text= objAccount.AccountName;
            tbxAlias.Text= objAccount.ShortName;
            tbxPrintname.Text= objAccount.PrintName;
            cbxLedgertype.SelectedItem=objAccount.LedgerType.ToString();
            cbxMulticurrency.SelectedItem= (objAccount.MultiCurrency)?"Y":"N";
            cbxGroupname.SelectedItem= objAccount.Group.ToString();
            tbxOpbal.Text= objAccount.OPBal.ToString();
            tbxPrevyearbal.Text= objAccount.PrevYearBal.ToString();
            cbxCrDr.SelectedItem= objAccount.DrCrOpeningBal.ToString();
            cbxPrevCrDr.SelectedItem= objAccount.DrCrPrevBal.ToString();
            cbxMaintainBalancing.SelectedItem= objAccount.MaintainBillwiseAccounts?"Y":"N";
            //objAccount.ActivateInterestCal = Convert.ToBoolean(dr["ACC_ActivateInterestCal"]);
            cbxAllocateAmount.SelectedItem= objAccount.AllocateAmountItems?"Y":"N";
            tbxCreditdaysforSale.Text= objAccount.CreditDaysforSale.ToString();
            tbxCreditdaysforPurc.Text= objAccount.CreditDaysforPurchase.ToString();
            //objAccount.TypeofDealer = dr["ACC_TypeofDealer"].ToString();
            //objAccount.TypeofBuissness = dr["ACC_TypeofBuissness"].ToString();
            tbxTransport.Text= objAccount.Transport.ToString();
            tbxStation.Text= objAccount.Station.ToString();
            cbxSpecifydefaultSale.SelectedItem=(objAccount.specifyDefaultSaleType)?"Y":"N";
            cbxDefaultsaletype.SelectedItem=objAccount.DefaultSaleType.ToString();
            cbxFreezesaletype.SelectedItem= objAccount.FreezeSaleType?"Y":"N";
            cbxSpecifydefaultPurcType.SelectedItem= objAccount.SpecifyDefaultPurType?"Y":"N";
            cbxDefaultPurcType.SelectedItem=objAccount.DefaultPurcType.ToString();
            cbxFreezePurcType.SelectedItem= objAccount.FreezePurcType?"Y":"N";
            //objAccount.LockSalesType = Convert.ToBoolean(dr["ACC_LockSalesType"]);
            //objAccount.LockPurchaseType = Convert.ToBoolean(dr["ACC_LockPurcType"]);
            tbxAddress.Text= objAccount.address.ToString();
            tbxAddress1.Text= objAccount.address1.ToString();
            tbxAddress2.Text= objAccount.address2.ToString();
            tbxAddress3.Text= objAccount.address3.ToString();
            tbxArea.Text = objAccount.area.ToString();
            tbxTelno.Text= objAccount.TelephoneNumber.ToString();
            cbxState.SelectedItem = objAccount.State.ToString();
            tbxFax.Text= objAccount.Fax.ToString();
            tbxMobileno.Text= objAccount.MobileNumber.ToString();
            tbxEmail.Text= objAccount.email.ToString();
            //objAccount.WebSite = dr["ACC_Website"].ToString();
            tbxEmailQuery.SelectedItem= objAccount.enablemailquery?"Y":"N";
            tbxSMSQuery.SelectedItem= objAccount.enableSMSquery?"Y":"N";
            tbxContactPerson.Text= objAccount.contactperson.ToString();
            tbxITpan.Text= objAccount.ITPanNumber.ToString();
            tbxLstno.Text= objAccount.LstNumber.ToString();
            tbxCstno.Text= objAccount.CSTNumber;
            tbxTin.Text= objAccount.TIN;
            tbxDlno1.Text=objAccount.DLNO1;
            tbxNo1.Text= objAccount.No1;
            tbxServicetax.Text= objAccount.ServiceTaxNumber.ToString();
            tbxlbtno.Text=objAccount.LBTNumber.ToString();
             //objAccount.BankAccountNumber = dr["ACC_BankAccountNumber"].ToString();
            tbxIecode.Text= objAccount.IECode.ToString();
            tbxWard.Text= objAccount.Ward.ToString();
            tbxChequePrintName.Text= objAccount.ChequePrintName.ToString();
            tbxInterestPay.Text= objAccount.InterestRatePayable.ToString();
            tbxInterestrateReceviable.Text= objAccount.InterestRateReceivable.ToString();
            laCtrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            laCtrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //laCtrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            tbxName.Focus();
        }

        private void Account_Load(object sender, EventArgs e)
        {
            //layoutLedger.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            //Accountsettings();
           // Defaultscreen();
            LodaGroups();
            laCtrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            laCtrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            laCtrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            tbxName.Focus();
        }

        public void LodaGroups()
        {
            List<AccountGroupModel> objmodel = accMaster.GetListofAccountsGroups();
            //var lstgroups = objmodel
            //            .Select(i => new { i.GroupName })
            //            .Distinct()
            //            .OrderByDescending(i => i.GroupName)
            //            .ToList();
            foreach (AccountGroupModel objgroup in objmodel)
            {
                cbxGroupname.Properties.Items.Add(objgroup.GroupName);
            }
        }

        public void Defaultscreen()
        {
            cbxMulticurrency.SelectedIndex = 0;
            cbxPrevCrDr.SelectedIndex = 1;
            cbxCrDr.SelectedIndex = 1;
            //cbxMaintainbatchwise.SelectedIndex = 1;
            cbxState.SelectedIndex = 0;
            cbxMaintainBalancing.SelectedIndex = 1;
            cbxLedgertype.SelectedIndex = 0;
            cbxAllocateAmount.SelectedIndex = 0;
            cbxGroupname.SelectedIndex = 0;
            tbxEmailQuery.Text = "N";
            tbxSMSQuery.Text = "N";
            cbxDefaultsaletype.SelectedIndex = 1;
            cbxFreezesaletype.SelectedIndex = 1;
            cbxSpecifydefaultSale.SelectedIndex = 1;
            cbxSpecifydefaultPurcType.SelectedIndex = 1;
            cbxFreezePurcType.SelectedIndex = 1;
            cbxDefaultPurcType.SelectedIndex = 1;

            //lblMulticurrency.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            //layoutSubledger.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;           
            //lblFreezePurcType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            //lblFreezetype.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            //lblDefaultPurcType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            //lblSpecifySaletype.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            //lblDefaultSaleType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            //lblSpecifyPurcType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            //lblDLNo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            //lblDLNo1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            //grpCreditdays.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            //lblIPayable.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            //lblIReceviable.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            //lblChequePrinting.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            //lblAllocateAmont.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
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

            ////TODO: Conditions
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
            if (cbxGroupname.SelectedItem.ToString() == "Sundry Creditors")
            {

                //enable fields
            }
            if (cbxGroupname.SelectedItem.ToString() == "Bank Account")
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
            if (cbxGroupname.SelectedItem.ToString() == "Suspence Account")
            {
                cbxCrDr.SelectedIndex = 1;
                cbxPrevCrDr.SelectedIndex = 1;
            }
            if (cbxGroupname.SelectedItem.ToString() == "Sunday Debitors")
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

        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            tbxPrintname.Text = tbxName.Text.Trim();
            tbxAlias.Text = tbxName.Text.Trim();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tbxName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Account Name can not be blank!");
                tbxName.Focus();
                return;
            }

            if (accMaster.IsAccountExists(tbxName.Text.Trim()))
            {
                MessageBox.Show("Account Name already Exists!");
                tbxName.Focus();
                return;
            }
            objAccount.AccountName = tbxName.Text.Trim();
            objAccount.PrintName = tbxPrintname.Text.Trim() == null ? string.Empty : tbxPrintname.Text.Trim();
            objAccount.ShortName = tbxAlias.Text == null ? string.Empty : tbxPrintname.Text.Trim();
            objAccount.LedgerType = cbxLedgertype.SelectedItem == null ? string.Empty : cbxLedgertype.SelectedItem.ToString();
            objAccount.Group = cbxGroupname.SelectedItem == null ? string.Empty : cbxGroupname.SelectedItem.ToString();
            objAccount.MultiCurrency = Convert.ToBoolean(cbxMulticurrency.SelectedItem.ToString() == "Y" ? true : false);

            objAccount.OPBal = Convert.ToDecimal(tbxOpbal.Text.Trim() == string.Empty ? "0.00" : tbxOpbal.Text.Trim());
            if (objAccount.OPBal != 0)
            {
                PopupScreens.CostcenterPopup frmCost = new PopupScreens.CostcenterPopup();
                frmCost.StartPosition = FormStartPosition.CenterParent;
                frmCost.ShowDialog();
            }
            objAccount.PrevYearBal = Convert.ToDecimal(tbxPrevyearbal.Text.Trim() == string.Empty ? "0.00" : tbxPrevyearbal.Text.Trim());
            objAccount.DrCrOpeningBal = cbxCrDr.SelectedItem.ToString();
            objAccount.DrCrPrevBal = cbxPrevCrDr.SelectedItem.ToString();
            objAccount.MaintainBillwiseAccounts = cbxMaintainBalancing.SelectedItem.ToString() == "Y" ? true : false;
            objAccount.AllocateAmountItems = cbxAllocateAmount.SelectedItem.ToString() == "Y" ? true : false;
            objAccount.CreditDaysforSale = Convert.ToInt32(tbxCreditdaysforSale.Text == string.Empty ? "0" : tbxCreditdaysforSale.Text.Trim());
            objAccount.CreditDaysforPurchase = Convert.ToInt32(tbxCreditdaysforPurc.Text == string.Empty ? "0" : tbxCreditdaysforPurc.Text.Trim());

            if (objAccount.MaintainBillwiseAccounts)
            {
                PopupScreens.MaintainBillByBillDetails frmbill = new PopupScreens.MaintainBillByBillDetails();
                frmbill.StartPosition = FormStartPosition.CenterParent;
                frmbill.ShowDialog();
            }
            PopupScreens.SalesManDetails frmSM = new PopupScreens.SalesManDetails();
            frmSM.StartPosition = FormStartPosition.CenterParent;
            frmSM.ShowDialog();
            //objAccount.CreditLimit = tbxcred.Text;
            PopupScreens.CreditLimitforAccount frmCredit = new PopupScreens.CreditLimitforAccount();
            frmSM.StartPosition = FormStartPosition.CenterParent;
            frmCredit.ShowDialog();
            PopupScreens.UnclearChequeDeposite frmDeposites = new PopupScreens.UnclearChequeDeposite();
            frmSM.StartPosition = FormStartPosition.CenterParent;
            frmDeposites.ShowDialog();
            PopupScreens.BudgetsforAccount frmBudget = new PopupScreens.BudgetsforAccount();
            frmSM.StartPosition = FormStartPosition.CenterScreen;
            frmBudget.ShowDialog();

            PopupScreens.UnclearChequeIssued frmIssued = new PopupScreens.UnclearChequeIssued();
            frmSM.StartPosition = FormStartPosition.CenterParent;
            frmIssued.ShowDialog();

            objAccount.Transport = tbxTransport.Text == null ? string.Empty : tbxTransport.Text;
            objAccount.Station = tbxStation.Text == null ? string.Empty : tbxStation.Text;

            //objAccount.specifyDefaultSaleType = cbxSpecifydefaultSale.SelectedItem.ToString()=="Y"?true:false;
            //objAccount.FreezeSaleType = cbxFreezesaletype.SelectedItem.ToString() == "Y" ? true : false;
            //objAccount.DefaultSaleType = cbxDefaultsaletype.SelectedItem.ToString() == ""? string.Empty : cbxDefaultsaletype.SelectedItem.ToString();

            //objAccount.SpecifyDefaultPurType = cbxSpecifydefaultPurcType.SelectedItem.ToString().Equals("Y") ? true : false;
            //objAccount.DefaultPurcType = cbxDefaultPurcType.SelectedItem==null?string.Empty: cbxDefaultPurcType.SelectedItem.ToString();
            //objAccount.FreezePurcType = cbxFreezePurcType.SelectedItem.ToString() == "Y" ? true : false;

            objAccount.InterestRatePayable = Convert.ToDecimal(tbxInterestPay.Text == string.Empty ? "0.00" : tbxInterestPay.Text);
            objAccount.InterestRateReceivable = Convert.ToDecimal(tbxInterestrateReceviable.Text == string.Empty ? "0.00" : tbxInterestrateReceviable.Text.Trim());
            objAccount.address = tbxAddress.Text.Trim() == null ? string.Empty : tbxAddress.Text.Trim();
            objAccount.address1 = tbxAddress1.Text.Trim() == null ? string.Empty : tbxAddress1.Text.Trim();
            objAccount.address2 = tbxAddress2.Text.Trim() == null ? string.Empty : tbxAddress2.Text.Trim();
            objAccount.address3 = tbxAddress3.Text.Trim() == null ? string.Empty : tbxAddress3.Text.Trim();
            objAccount.State = cbxState.SelectedItem.ToString();
            objAccount.area = tbxArea.Text.Trim() == null ? string.Empty : tbxArea.Text.Trim();
            objAccount.TelephoneNumber = tbxTelno.Text.Trim() == null ? string.Empty : tbxTelno.Text.Trim();

            objAccount.Fax = tbxFax.Text == null ? string.Empty : tbxFax.Text.Trim();
            objAccount.MobileNumber = tbxMobileno.Text == null ? string.Empty : tbxMobileno.Text.Trim();
            objAccount.email = tbxEmail.Text == null ? string.Empty : tbxEmail.Text.Trim();

            objAccount.enablemailquery = Convert.ToBoolean(tbxEmailQuery.Text.Trim().Equals("Y") ? true : false);
            objAccount.enableSMSquery = Convert.ToBoolean(tbxSMSQuery.Text.Trim().Equals("Y") ? true : false);

            objAccount.contactperson = tbxContactPerson.Text == null ? string.Empty : tbxContactPerson.Text.Trim();
            objAccount.ITPanNumber = tbxITpan.Text == null ? string.Empty : tbxITpan.Text.Trim();
            objAccount.Ward = tbxWard.Text == null ? string.Empty : tbxWard.Text.Trim();
            objAccount.LstNumber = tbxLstno.Text == null ? string.Empty : tbxLstno.Text.Trim();
            objAccount.CSTNumber = tbxCstno.Text == null ? string.Empty : tbxCstno.Text.Trim();
            objAccount.TIN = tbxTin.Text == null ? string.Empty : tbxTin.Text.Trim();
            objAccount.LBTNumber = tbxlbtno == null ? string.Empty : tbxlbtno.Text.Trim();
            objAccount.ServiceTaxNumber = tbxServicetax == null ? string.Empty : tbxServicetax.Text.Trim();
            objAccount.IECode = tbxIecode.Text == null ? string.Empty : tbxIecode.Text.Trim();
            objAccount.DLNO1 = tbxDlno1.Text.Trim() == null ? string.Empty : tbxDlno1.Text.Trim();
            objAccount.No1 = tbxNo1.Text.Trim() == null ? string.Empty : tbxNo1.Text.Trim();
            objAccount.ChequePrintName = tbxChequePrintName.Text == null ? string.Empty : tbxChequePrintName.Text.Trim();
            objAccount.allowwebbasedreporting = tbxWebBasedReporting.Text.Trim() == null ? string.Empty : tbxWebBasedReporting.Text.Trim();
            //objAccount.BankAccountNumber=
            objAccount.AccountId = groupId;
            string message = string.Empty;

            bool isUpdate = accMaster.UpdateAccount(objAccount);
            if (isUpdate)
            {
                MessageBox.Show("Update Successfully!");
                ClearControls();
                groupId = 0;
                Administration.List.AccountList frmList = new Administration.List.AccountList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                FillAccountInfo();
            }
        }

        private void cbxState_Enter(object sender, EventArgs e)
        {
            cbxState.ShowPopup();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDelete = accMaster.DeleteAccountMasterById(groupId);
            if (isDelete)
            {
                MessageBox.Show("Delete Successfully!");
                ClearControls();
                groupId = 0;
                Administration.List.AccountList frmList = new Administration.List.AccountList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                FillAccountInfo();
            }
        }
        private void ClearControls()
        {
            objAccount = new AccountMasterModel();
            tbxName.Text = string.Empty;
            tbxAlias.Text = string.Empty;
            tbxPrintname.Text = string.Empty;
            cbxLedgertype.SelectedItem = string.Empty;
            cbxMulticurrency.SelectedItem = string.Empty;
            cbxGroupname.SelectedItem = string.Empty;
            tbxOpbal.Text = string.Empty;
            tbxPrevyearbal.Text = string.Empty;
            cbxCrDr.SelectedItem = string.Empty;
            cbxPrevCrDr.SelectedItem = string.Empty;
            cbxMaintainBalancing.SelectedItem = string.Empty;
            //objAccount.ActivateInterestCal = Convert.ToBoolean(dr["ACC_ActivateInterestCal"]);
            cbxAllocateAmount.SelectedItem = string.Empty;
            tbxCreditdaysforSale.Text = string.Empty;
            tbxCreditdaysforPurc.Text = string.Empty;
            //objAccount.TypeofDealer = dr["ACC_TypeofDealer"].ToString();
            //objAccount.TypeofBuissness = dr["ACC_TypeofBuissness"].ToString();
            tbxTransport.Text = string.Empty;
            tbxStation.Text = string.Empty;
            cbxSpecifydefaultSale.SelectedItem = string.Empty;
            cbxDefaultsaletype.SelectedItem = string.Empty;
            cbxFreezesaletype.SelectedItem = string.Empty;
            cbxSpecifydefaultPurcType.SelectedItem = string.Empty;
            cbxDefaultPurcType.SelectedItem = string.Empty;
            cbxFreezePurcType.SelectedItem = string.Empty;
            //objAccount.LockSalesType = Convert.ToBoolean(dr["ACC_LockSalesType"]);
            //objAccount.LockPurchaseType = Convert.ToBoolean(dr["ACC_LockPurcType"]);
            tbxAddress.Text = string.Empty;
            tbxAddress1.Text = string.Empty;
            tbxAddress2.Text = string.Empty;
            tbxAddress3.Text = string.Empty;
            tbxTelno.Text = string.Empty;
            cbxState.SelectedItem = string.Empty;
            tbxFax.Text = string.Empty;
            tbxMobileno.Text = string.Empty;
            tbxEmail.Text = string.Empty;
            //objAccount.WebSite = dr["ACC_Website"].ToString();
            tbxEmailQuery.SelectedItem = string.Empty;
            tbxSMSQuery.SelectedItem = string.Empty;
            tbxContactPerson.Text = string.Empty;
            tbxITpan.Text = string.Empty;
            tbxLstno.Text = string.Empty;
            tbxCstno.Text = string.Empty;
            tbxTin.Text = string.Empty;
            tbxServicetax.Text = string.Empty;
            tbxlbtno.Text = string.Empty;
            //objAccount.BankAccountNumber = dr["ACC_BankAccountNumber"].ToString();
            tbxIecode.Text = string.Empty;
            tbxWard.Text = string.Empty;
            tbxChequePrintName.Text = string.Empty;
            tbxInterestPay.Text = string.Empty;
            tbxInterestrateReceviable.Text = string.Empty;
        }

        private void tbxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar=='\r')
            {
                if (tbxName.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Account Name can not be blank!");
                    tbxName.Focus();
                    return;
                }
                if (groupId != 0)
                {
                    if (accMaster.IsAccountExists(tbxName.Text.Trim()))
                    {
                        MessageBox.Show("Account Name already Exists!");
                        tbxName.Focus();
                        return;
                    }
                }
            }          
        }
    }
}
