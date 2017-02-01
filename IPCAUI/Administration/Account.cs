﻿using System;
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
using System.IO;
using System.Configuration;

namespace IPCAUI.Administration
{
    public partial class Account : Form
    {

        AccountMasterBL accMaster = new AccountMasterBL();
        AccountSettingsBL objacbl = new AccountSettingsBL();
        public static int groupId = 0;
        public static AccountMasterModel objAccount = new AccountMasterModel();
        AccountSettingsModel lstSettings;

        decimal decOpeningBalance = 0;
        int decLedgerId = 0;

        byte[] AccLogo = null;
        private object pbxLogo;

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
            objAccount.PrintName = tbxPrintname.Text.Trim() == null ? string.Empty : tbxPrintname.Text.Trim();
            objAccount.ShortName = tbxAlias.Text == null ? string.Empty : tbxPrintname.Text.Trim();
            objAccount.LedgerType = cbxLedgertype.SelectedItem == null ? string.Empty : cbxLedgertype.SelectedItem.ToString();
            objAccount.Group = cbxGroupname.SelectedItem == null ? string.Empty : cbxGroupname.SelectedItem.ToString();
            AccountGroupModel objGroup = accMaster.GetAccountGroupIdByGroupName(objAccount.Group);
            objAccount.AccGroupId = objGroup.UnderGroupId;
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
            //objAccount.MaintainBillwiseAccounts = cbxMaintainBalancing.SelectedItem.ToString() == "Y" ? true : false;
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
            frmCredit.StartPosition = FormStartPosition.CenterParent;
            frmCredit.ShowDialog();
            PopupScreens.UnclearChequeDeposite frmDeposites = new PopupScreens.UnclearChequeDeposite();
            frmDeposites.StartPosition = FormStartPosition.CenterParent;
            frmDeposites.ShowDialog();
            PopupScreens.BudgetsforAccount frmBudget = new PopupScreens.BudgetsforAccount();
            frmBudget.StartPosition = FormStartPosition.CenterParent;
            frmBudget.ShowDialog();

            PopupScreens.UnclearChequeIssued frmIssued = new PopupScreens.UnclearChequeIssued();
            frmIssued.StartPosition = FormStartPosition.CenterParent;
            frmIssued.ShowDialog();

            PopupScreens.MasterSeriesGroup frmMaster = new PopupScreens.MasterSeriesGroup();
            frmMaster.StartPosition = FormStartPosition.CenterParent;
            frmMaster.ShowDialog();

            objAccount.Transport = tbxTransport.Text == null ? string.Empty : tbxTransport.Text;
            objAccount.Station = tbxStation.Text == null ? string.Empty : tbxStation.Text;

            objAccount.specifyDefaultSaleType = cbxSpecifydefaultSale.SelectedItem.ToString() == "Y" ? true : false;
            objAccount.FreezeSaleType = cbxFreezesaletype.SelectedItem.ToString() == "Y" ? true : false;
            objAccount.DefaultSaleType = cbxDefaultsaletype.SelectedItem.ToString() == "" ? string.Empty : cbxDefaultsaletype.SelectedItem.ToString();

            objAccount.SpecifyDefaultPurType = cbxSpecifydefaultPurcType.SelectedItem.ToString().Equals("Y") ? true : false;
            objAccount.DefaultPurcType = cbxDefaultPurcType.SelectedItem == null ? string.Empty : cbxDefaultPurcType.SelectedItem.ToString();
            objAccount.FreezePurcType = cbxFreezePurcType.SelectedItem.ToString() == "Y" ? true : false;

            objAccount.InterestRatePayable = Convert.ToDecimal(tbxInterestPay.Text == string.Empty ? "0.00" : tbxInterestPay.Text);
            objAccount.InterestRateReceivable = Convert.ToDecimal(tbxInterestrateReceviable.Text == string.Empty ? "0.00" : tbxInterestrateReceviable.Text.Trim());
            objAccount.address = tbxAddress.Text.Trim() == null ? string.Empty : tbxAddress.Text.Trim();
            objAccount.address1 = tbxAddress1.Text.Trim() == null ? string.Empty : tbxAddress1.Text.Trim();
            objAccount.address2 = tbxAddress2.Text.Trim() == null ? string.Empty : tbxAddress2.Text.Trim();
            objAccount.address3 = tbxAddress3.Text.Trim() == null ? string.Empty : tbxAddress3.Text.Trim();
            objAccount.ImageData = AccLogo;
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
            string message = string.Empty;

            decLedgerId = accMaster.SaveAccount(objAccount);
            if (decLedgerId > 0)
            {
                LedgerPostingAdd();
                MessageBox.Show("Saved Successfully!");
                ClearControls();
                tbxName.Focus();
                groupId = 0;
            }

        }
        public void LedgerPostingAdd()
        {
            try
            {
                string strfinancialId;
                decOpeningBalance = Convert.ToDecimal(tbxOpbal.Text.Trim());
                LedgerPostingBL objBL = new LedgerPostingBL();
                LedgerPostingModel infoLedgerPosting = new LedgerPostingModel();
                //FinancialYearSP spFinancialYear = new FinancialYearSP();
                //FinancialYearInfo infoFinancialYear = new FinancialYearInfo();
                //infoFinancialYear = spFinancialYear.FinancialYearViewForAccountLedger(1);

                //strfinancialId = infoFinancialYear.FromDate.ToString("dd-MMM-yyyy"); -NEED TO REVIEW AND RELEASE THIS

                infoLedgerPosting.VoucherTypeId = 1;
                infoLedgerPosting.Date = Convert.ToDateTime(DateTime.Today.ToString());
                infoLedgerPosting.LedgerId = decLedgerId;
                infoLedgerPosting.VoucherNo = decLedgerId.ToString();

                if (cbxCrDr.Text == "D")
                {
                    infoLedgerPosting.Debit = decOpeningBalance;
                }
                else
                {
                    infoLedgerPosting.Credit = decOpeningBalance;
                }
                infoLedgerPosting.DetailsId = 0;
                infoLedgerPosting.YearId = SessionVariables._decCurrentFinancialYearId;
                infoLedgerPosting.InvoiceNo = decLedgerId.ToString();
                infoLedgerPosting.ChequeNo = string.Empty;
                infoLedgerPosting.ChequeDate = DateTime.Now;
                infoLedgerPosting.Extra1 = string.Empty;
                infoLedgerPosting.Extra2 = string.Empty;
                objBL.LedgerPostingAdd(infoLedgerPosting);
            }
            catch (Exception ex)
            {

            }
        }
        public void LedgerPostingEdit(long id)
        {
            try
            {             
                string strfinancialId;
                decOpeningBalance = Convert.ToDecimal(tbxOpbal.Text.Trim());
                LedgerPostingBL objBL = new LedgerPostingBL();
                LedgerPostingModel infoLedgerPosting = new LedgerPostingModel();
                //FinancialYearSP spFinancialYear = new FinancialYearSP();
                //FinancialYearInfo infoFinancialYear = new FinancialYearInfo();
                //infoFinancialYear = spFinancialYear.FinancialYearViewForAccountLedger(1);

                //strfinancialId = infoFinancialYear.FromDate.ToString("dd-MMM-yyyy"); -NEED TO REVIEW AND RELEASE THIS
                infoLedgerPosting.ParentId = id;
                infoLedgerPosting.VoucherTypeId = 1;
                infoLedgerPosting.Date = Convert.ToDateTime(DateTime.Today.ToString());
                infoLedgerPosting.VoucherNo =id.ToString();

                if (cbxCrDr.Text == "D")
                {
                    infoLedgerPosting.Debit = decOpeningBalance;
                }
                else
                {
                    infoLedgerPosting.Credit = decOpeningBalance;
                }
                infoLedgerPosting.DetailsId = 0;
                infoLedgerPosting.YearId = SessionVariables._decCurrentFinancialYearId;
                infoLedgerPosting.InvoiceNo =id.ToString();
                infoLedgerPosting.ChequeNo = string.Empty;
                infoLedgerPosting.ChequeDate = DateTime.Now;
                infoLedgerPosting.Extra1 = string.Empty;
                infoLedgerPosting.Extra2 = string.Empty;
                objBL.LedgerPostingEdit(infoLedgerPosting);
            }
            catch (Exception ex)
            {

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

            if (groupId == 0)
            {
                tbxName.Focus();
                laCtrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                laCtrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                laCtrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                return;
            }
            //objAccount.AccountId = Convert.ToInt32(dr["Ac_ID"]);
            tbxName.Text = objAccount.AccountName;
            tbxAlias.Text = objAccount.ShortName;
            tbxPrintname.Text = objAccount.PrintName;
            cbxLedgertype.SelectedItem = objAccount.LedgerType.ToString();
            cbxMulticurrency.SelectedItem = (objAccount.MultiCurrency) ? "Y" : "N";
            cbxGroupname.SelectedItem = objAccount.Group.ToString();
            tbxOpbal.Text = objAccount.OPBal.ToString();
            tbxPrevyearbal.Text = objAccount.PrevYearBal.ToString();
            cbxCrDr.SelectedItem = objAccount.DrCrOpeningBal.ToString();
            cbxPrevCrDr.SelectedItem = objAccount.DrCrPrevBal.ToString();
            cbxMaintainBalancing.SelectedItem = objAccount.MaintainBillwiseAccounts ? "Y" : "N";
            //objAccount.ActivateInterestCal = Convert.ToBoolean(dr["ACC_ActivateInterestCal"]);
            cbxAllocateAmount.SelectedItem = objAccount.AllocateAmountItems ? "Y" : "N";
            tbxCreditdaysforSale.Text = objAccount.CreditDaysforSale.ToString();
            tbxCreditdaysforPurc.Text = objAccount.CreditDaysforPurchase.ToString();
            //objAccount.TypeofDealer = dr["ACC_TypeofDealer"].ToString();
            //objAccount.TypeofBuissness = dr["ACC_TypeofBuissness"].ToString();
            tbxTransport.Text = objAccount.Transport.ToString();
            tbxStation.Text = objAccount.Station.ToString();
            cbxSpecifydefaultSale.SelectedItem = (objAccount.specifyDefaultSaleType) ? "Y" : "N";
            cbxDefaultsaletype.SelectedItem = objAccount.DefaultSaleType.ToString();
            cbxFreezesaletype.SelectedItem = objAccount.FreezeSaleType ? "Y" : "N";
            cbxSpecifydefaultPurcType.SelectedItem = objAccount.SpecifyDefaultPurType ? "Y" : "N";
            cbxDefaultPurcType.SelectedItem = objAccount.DefaultPurcType.ToString();
            cbxFreezePurcType.SelectedItem = objAccount.FreezePurcType ? "Y" : "N";
            //objAccount.LockSalesType = Convert.ToBoolean(dr["ACC_LockSalesType"]);
            //objAccount.LockPurchaseType = Convert.ToBoolean(dr["ACC_LockPurcType"]);
            tbxAddress.Text = objAccount.address.ToString();
            tbxAddress1.Text = objAccount.address1.ToString();
            tbxAddress2.Text = objAccount.address2.ToString();
            tbxAddress3.Text = objAccount.address3.ToString();
            tbxArea.Text = objAccount.area.ToString();
            tbxTelno.Text = objAccount.TelephoneNumber.ToString();
            cbxState.SelectedItem = objAccount.State.ToString();
            tbxFax.Text = objAccount.Fax.ToString();
            tbxMobileno.Text = objAccount.MobileNumber.ToString();
            tbxEmail.Text = objAccount.email.ToString();
            //objAccount.WebSite = dr["ACC_Website"].ToString();
            tbxEmailQuery.SelectedItem = objAccount.enablemailquery ? "Y" : "N";
            tbxSMSQuery.SelectedItem = objAccount.enableSMSquery ? "Y" : "N";
            tbxContactPerson.Text = objAccount.contactperson.ToString();
            tbxITpan.Text = objAccount.ITPanNumber.ToString();
            tbxLstno.Text = objAccount.LstNumber.ToString();
            tbxCstno.Text = objAccount.CSTNumber;
            tbxTin.Text = objAccount.TIN;
            tbxDlno1.Text = objAccount.DLNO1;
            tbxNo1.Text = objAccount.No1;
            tbxServicetax.Text = objAccount.ServiceTaxNumber.ToString();
            tbxlbtno.Text = objAccount.LBTNumber.ToString();
            //objAccount.BankAccountNumber = dr["ACC_BankAccountNumber"].ToString();
            tbxIecode.Text = objAccount.IECode.ToString();
            tbxWard.Text = objAccount.Ward.ToString();
            tbxChequePrintName.Text = objAccount.ChequePrintName.ToString();
            tbxInterestPay.Text = objAccount.InterestRatePayable.ToString();
            tbxInterestrateReceviable.Text = objAccount.InterestRateReceivable.ToString();
            laCtrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            laCtrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            laCtrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
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
            cbxSpecifydefaultPurcType.SelectedIndex = 0;
            cbxDefaultsaletype.SelectedIndex = 0;
            cbxFreezesaletype.SelectedIndex = 0;
            cbxSpecifydefaultSale.SelectedIndex = 0;
            cbxDefaultPurcType.SelectedIndex = 0;
            cbxFreezePurcType.SelectedIndex = 0;
            cbxState.SelectedIndex = 0;
            cbxMaintainBalancing.SelectedIndex = 0;
            cbxAllocateAmount.SelectedIndex = 0;
            cbxMulticurrency.SelectedIndex = 0;
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
            if (lstSettings.Billbybilldetails)
            {
                //lblMaintainbillbybill.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            if (lstSettings.chequeprinting)
            {
                lblChequePrinting.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }

        }

        private void cbxGroupname_SelectedIndexChanged(object sender, EventArgs e)
        {

            ////TODO: Conditions
            AccountGroupModel objGroup = accMaster.GetAccountGroupIdByGroupName(cbxGroupname.SelectedItem.ToString());
            cbxCrDr.SelectedItem = objGroup.DC.ToString();
            cbxPrevCrDr.SelectedItem = objGroup.DC.ToString();
        }

        private void cbxSpecifydefaultSale_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cbxSpecifydefaultSale_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSpecifydefaultSale.SelectedItem.ToString() == "N")
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
            if (cbxMaintainBalancing.SelectedItem.ToString() == "Y")
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
            AccountGroupModel objGroup = accMaster.GetAccountGroupIdByGroupName(objAccount.Group);
            objAccount.AccGroupId = objGroup.UnderGroupId;
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
            frmCredit.StartPosition = FormStartPosition.CenterParent;
            frmCredit.ShowDialog();
            PopupScreens.UnclearChequeDeposite frmDeposites = new PopupScreens.UnclearChequeDeposite();
            frmDeposites.StartPosition = FormStartPosition.CenterParent;
            frmDeposites.ShowDialog();
            PopupScreens.BudgetsforAccount frmBudget = new PopupScreens.BudgetsforAccount();
            frmBudget.StartPosition = FormStartPosition.CenterScreen;
            frmBudget.ShowDialog();

            PopupScreens.UnclearChequeIssued frmIssued = new PopupScreens.UnclearChequeIssued();
            frmIssued.StartPosition = FormStartPosition.CenterParent;
            frmIssued.ShowDialog();
            PopupScreens.MasterSeriesGroup frmMaster = new PopupScreens.MasterSeriesGroup();
            frmMaster.StartPosition = FormStartPosition.CenterParent;
            frmMaster.ShowDialog();
            objAccount.Transport = tbxTransport.Text == null ? string.Empty : tbxTransport.Text;
            objAccount.Station = tbxStation.Text == null ? string.Empty : tbxStation.Text;

            objAccount.specifyDefaultSaleType = cbxSpecifydefaultSale.SelectedItem.ToString() == "Y" ? true : false;
            objAccount.FreezeSaleType = cbxFreezesaletype.SelectedItem.ToString() == "Y" ? true : false;
            objAccount.DefaultSaleType = cbxDefaultsaletype.SelectedItem.ToString() == "" ? string.Empty : cbxDefaultsaletype.SelectedItem.ToString();

            objAccount.SpecifyDefaultPurType = cbxSpecifydefaultPurcType.SelectedItem.ToString().Equals("Y") ? true : false;
            objAccount.DefaultPurcType = cbxDefaultPurcType.SelectedItem == null ? string.Empty : cbxDefaultPurcType.SelectedItem.ToString();
            objAccount.FreezePurcType = cbxFreezePurcType.SelectedItem.ToString() == "Y" ? true : false;

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
            LedgerPostingEdit(objAccount.AccountId);
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
                LedgerPostingBL objBL = new LedgerPostingBL();
                if (objBL.LedgerPostingDelete(groupId))
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
            if (e.KeyChar == '\r')
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

        private void btnNewEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            objAccount = new AccountMasterModel();
            ClearControls();
            groupId = 0;
            laCtrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            laCtrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            laCtrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        private void cbxAllocateAmount_Enter(object sender, EventArgs e)
        {
            cbxAllocateAmount.SelectedIndex = 0;
        }

        private void cbxGroupname_Enter(object sender, EventArgs e)
        {
            cbxGroupname.ShowPopup();
        }

        private void tbxOpbal_Leave(object sender, EventArgs e)
        {
            tbxPrevyearbal.Text = tbxOpbal.Text.Trim();
        }

        private void cbxLedgertype_Enter(object sender, EventArgs e)
        {
            cbxLedgertype.ShowPopup();
        }

        private void hylinkBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog AccImage = new OpenFileDialog();
            AccImage.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.PNG)|*.BMP;*.JPG;*.JPEG;*.PNG";
            //AccImage.FileName = string.Empty;
            
            if (DialogResult.OK == AccImage.ShowDialog())
            {
                //textEdit1.Text = AccImage.FileName;
                if (AccImage.FileName != string.Empty)
                {
                    try
                    {
                        AccLogo = ReadFile(AccImage.FileName);
                        MemoryStream ms = new MemoryStream(AccLogo);
                        Image newimage = Image.FromStream(ms);
                        pbxImage.Image = newimage;
                        pbxImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        private byte[] ReadFile(string fileName)
        {
            byte[] data = null;
            try
            {
                FileInfo fInfo = new FileInfo(fileName);
                long numBytes = fInfo.Length;
                FileStream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fStream);
                data = br.ReadBytes((int)numBytes);
            }
            catch (Exception ex)
            {
                //formMDI.infoError.ErrorString = "CR4:" + ex.Message;
            }
            return data;
        }

        private void cbxLedgertype_Leave(object sender, EventArgs e)
        {
           if(cbxLedgertype.Text==string.Empty)
            {
                cbxLedgertype.SelectedIndex =0;
            }
        }

        private void cbxGroupname_Leave(object sender, EventArgs e)
        {
            if (cbxGroupname.Text == string.Empty)
            {
                cbxGroupname.SelectedIndex = 0;
            }
        }
    }
}
