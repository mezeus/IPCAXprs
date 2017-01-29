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
        decimal decOpeningBalance = 0;
        public static int groupId = 0;
        int decLedgerId = 0;
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

        /// <summary>
        ///Function to save ledgerposting incase of opening balance
        /// </summary>
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

                if (cbxCrDr.Text == "Dr")
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
        /// <summary>
        ///Function to edit ledgerposting incase of opening balance
        /// </summary> 
        public void LedgerPostingEdit()
        {
            //try
            //{
            //    string strfinancialId;
            //    decOpeningBalance = Convert.ToDecimal(((txtOpeningBalance.Text == "") ? "0" : txtOpeningBalance.Text.Trim()));
            //    LedgerPostingSP spLedgerPosting = new LedgerPostingSP();
            //    LedgerPostingInfo infoLedgerPosting = new LedgerPostingInfo();
            //    AccountLedgerSP spAccountLedger = new AccountLedgerSP();
            //    FinancialYearSP spFinancialYear = new FinancialYearSP();
            //    FinancialYearInfo infoFinancialYear = new FinancialYearInfo();
            //    infoFinancialYear = spFinancialYear.FinancialYearViewForAccountLedger(1);
            //    strfinancialId = infoFinancialYear.FromDate.ToString("dd-MMM-yyyy");
            //    infoLedgerPosting.VoucherTypeId = 1;
            //    infoLedgerPosting.Date = Convert.ToDateTime(strfinancialId.ToString());
            //    if (cmbOpeningBalanceCrOrDr.Text == "Dr")
            //    {
            //        infoLedgerPosting.Debit = decOpeningBalance;
            //    }
            //    else
            //    {
            //        infoLedgerPosting.Credit = decOpeningBalance;
            //    }
            //    infoLedgerPosting.DetailsId = 0;
            //    infoLedgerPosting.YearId = PublicVariables._decCurrentFinancialYearId;
            //    infoLedgerPosting.InvoiceNo = decAccountLedgerId.ToString();
            //    infoLedgerPosting.Extra1 = string.Empty;
            //    infoLedgerPosting.Extra2 = string.Empty;
            //    infoLedgerPosting.LedgerId = decAccountLedgerId;
            //    infoLedgerPosting.VoucherNo = decAccountLedgerId.ToString();
            //    infoLedgerPosting.ChequeNo = string.Empty;
            //    infoLedgerPosting.ChequeDate = DateTime.Now;
            //    DataTable dtbl = spLedgerPosting.GetLedgerPostingIds(decAccountLedgerId.ToString(), 1);
            //    if (dtbl.Rows.Count > 0)
            //    {
            //        if (decOpeningBalance > 0)
            //        {
            //            //Edit
            //            infoLedgerPosting.LedgerPostingId = Convert.ToDecimal(dtbl.Rows[0][0].ToString());
            //            spLedgerPosting.LedgerPostingEdit(infoLedgerPosting);
            //        }
            //        else
            //        {
            //            //Delete
            //            spAccountLedger.LedgerPostingDeleteByVoucherTypeAndVoucherNo(decAccountLedgerId.ToString(), 1);
            //        }
            //    }
            //    else
            //    {
            //        //Add new row
            //        spLedgerPosting.LedgerPostingAdd(infoLedgerPosting);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    formMDI.infoError.ErrorString = "AL5:" + ex.Message;
            //}
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
            obj.PrintName = tbxPrintname.Text.Trim()==null?string.Empty:tbxPrintname.Text.Trim();
            obj.ShortName = tbxAlias.Text == null ? string.Empty : tbxPrintname.Text.Trim();
            obj.LedgerType = cbxLedgertype.SelectedItem==null?string.Empty: cbxLedgertype.SelectedItem.ToString();
            obj.Group = cbxGroupname.SelectedItem == null ? string.Empty : cbxGroupname.SelectedItem.ToString();
            obj.MultiCurrency = Convert.ToBoolean(cbxMulticurrency.SelectedItem.ToString() == "Y" ? true : false);

            obj.OPBal = Convert.ToDecimal(tbxOpbal.Text);
            obj.PrevYearBal = Convert.ToDecimal(tbxPrevyearbal.Text);
            obj.DrCrOpeningBal = cbxCrDr.SelectedItem.ToString();
            obj.DrCrPrevBal = cbxPrevCrDr.SelectedItem.ToString();

            obj.CreditDaysforSale = Convert.ToInt32(tbxCreditdaysforSale.Text==string.Empty ? "0":tbxCreditdaysforSale.Text.Trim());
            obj.CreditDaysforPurchase= Convert.ToInt32(tbxCreditdaysforPurc.Text == string.Empty ? "0" : tbxCreditdaysforPurc.Text.Trim());
            obj.MaintainBillwiseAccounts = cbxMaintainBalancing.SelectedItem.ToString() == "Y" ? true : false;
            //obj.CreditLimit = tbxcred.Text;

            obj.Transport = tbxTransport.Text==null?string.Empty:tbxTransport.Text;
            obj.Station = tbxStation.Text == null ? string.Empty : tbxStation.Text;

            obj.specifyDefaultSaleType = cbxSpecifydefaultSale.SelectedItem.ToString()=="Y"?true:false;
            obj.FreezeSaleType = cbxFreezesaletype.SelectedItem.ToString() == "Y" ? true : false;
            obj.DefaultSaleType = cbxDefaultsaletype.SelectedItem.ToString() == ""? string.Empty : cbxDefaultsaletype.SelectedItem.ToString();

            obj.SpecifyDefaultPurType = cbxSpecifydefaultPurcType.SelectedItem.ToString().Equals("Y") ? true : false;
            obj.DefaultPurcType = cbxDefaultPurcType.SelectedItem==null?string.Empty: cbxDefaultPurcType.SelectedItem.ToString();
            obj.FreezePurcType = cbxFreezePurcType.SelectedItem.ToString() == "Y" ? true : false;

            obj.InterestRatePayable = Convert.ToDecimal(tbxInterestPay.Text==null?"0":tbxInterestPay.Text);
            obj.InterestRateReceivable = Convert.ToDecimal(tbxInterestrateReceviable.Text == null ? "0" :tbxInterestrateReceviable.Text);

            obj.address = tbxAddress.Text.Trim()==null?string.Empty:tbxAddress.Text.Trim();
            obj.address1 = tbxAddress1.Text.Trim() == null ? string.Empty : tbxAddress1.Text.Trim();
            obj.address2 = tbxAddress2.Text.Trim() == null ? string.Empty : tbxAddress2.Text.Trim();
            obj.address3 = tbxAddress3.Text.Trim() == null ? string.Empty : tbxAddress3.Text.Trim();
            obj.State = cbxState.SelectedItem.ToString();
            obj.area = tbxArea.Text.Trim() == null ? string.Empty : tbxArea.Text.Trim();
            obj.TelephoneNumber = tbxTelno.Text.Trim() == null ? string.Empty : tbxTelno.Text.Trim();

            obj.Fax = tbxFax.Text == null ? string.Empty : tbxFax.Text.Trim();
            obj.MobileNumber = tbxMobileno.Text == null ? string.Empty : tbxMobileno.Text.Trim();
            obj.email = tbxEmail.Text == null ? string.Empty : tbxEmail.Text.Trim();

            obj.enablemailquery = Convert.ToBoolean(tbxEmailQuery.Text.Trim().Equals("Y") ? true : false);
            obj.enableSMSquery = Convert.ToBoolean(tbxSMSQuery.Text.Trim().Equals("Y") ? true : false);

            obj.contactperson = tbxContactPerson.Text == null ? string.Empty : tbxContactPerson.Text.Trim();
            obj.ITPanNumber = tbxITpan.Text == null ? string.Empty : tbxITpan.Text.Trim();
            obj.Ward = tbxWard.Text == null ? string.Empty : tbxWard.Text.Trim();
            obj.LstNumber = tbxLstno.Text == null ? string.Empty : tbxLstno.Text.Trim();
            obj.CSTNumber = tbxCstno.Text == null ? string.Empty : tbxCstno.Text.Trim();
            obj.TIN = tbxTin.Text==null? string.Empty : tbxTin.Text.Trim();
            obj.LBTNumber = tbxlbtno == null ? string.Empty : tbxlbtno.Text.Trim();
            obj.ServiceTaxNumber =tbxServicetax== null ? string.Empty : tbxServicetax.Text.Trim();
            obj.IECode = tbxIecode.Text == null ? string.Empty : tbxIecode.Text.Trim();
            obj.DLNO1 = tbxDlno1.Text.Trim() == null ? string.Empty : tbxDlno1.Text.Trim();
            obj.No1 = tbxNo1.SelectedText.ToString();
            obj.ChequePrintName = tbxChequePrintName.Text == null ? string.Empty : tbxChequePrintName.Text.Trim();
            obj.allowwebbasedreporting = tbxWebBasedReporting.ToString();

            string message = string.Empty;

             decLedgerId = accMaster.SaveAccount(obj);
            if (decLedgerId>0)
            {
                if (Convert.ToDecimal(tbxOpbal.Text.Trim()) > 0)
                {
                    LedgerPostingAdd();
                }
                MessageBox.Show("Saved Successfully!");
            }

        }

        private void ListAccount_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.AccountList frmList = new Administration.List.AccountList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();

            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;

            btnSave.Visible = false;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            tbxName.Focus();
            cbxGroupname.ReadOnly = true;

            FillAccountInfo();
        }

        private void FillAccountInfo()
        {
            AccountMasterModel objMaster = accMaster.GetListofAccountByAccountId(groupId);

            //lblaccountid.Text = objMaster.AccountId.ToString();
            tbxName.Text = objMaster.AccountName;
            tbxPrintname.Text = objMaster.PrintName;
            tbxAlias.Text = objMaster.ShortName;
            cbxLedgertype.SelectedItem = objMaster.LedgerType;
            cbxGroupname.Text = objMaster.AccountName;

            tbxOpbal.Text = Convert.ToString(objMaster.OPBal);
            tbxPrevyearbal.Text = objMaster.PrevYearBal.ToString();
            cbxCrDr.SelectedItem = objMaster.DrCrOpeningBal;
            cbxPrevCrDr.SelectedItem = objMaster.DrCrPrevBal;

            tbxCreditdaysforPurc.Text =Convert.ToString(objMaster.CreditDaysforPurchase);
            tbxCreditdaysforSale.Text = Convert.ToString(objMaster.CreditDaysforSale);
            //tbxCreditLimitAccount.Text = objMaster.CreditLimit;

            tbxTransport.Text = objMaster.Transport;
            tbxStation.Text = objMaster.Station;
            
            cbxState.SelectedItem = objMaster.State;
            cbxDefaultPurcType.SelectedItem = objMaster.DefaultPurcType;
            cbxDefaultsaletype.SelectedItem = objMaster.DefaultSaleType;
            cbxFreezesaletype.SelectedItem = objMaster.LockSalesType ? "Y" : "N";
            cbxFreezePurcType.SelectedItem = objMaster.LockPurchaseType ? "Y" : "N";
            cbxSpecifydefaultSale.SelectedItem = objMaster.specifyDefaultSaleType;
            cbxSpecifydefaultPurcType.SelectedItem = objMaster.SpecifyDefaultPurType;
            cbxMulticurrency.SelectedItem = objMaster.MultiCurrency ? "Y" : "N";
            //cbx.Text = objMaster.TypeofBuissness;
            //cbxYesNoActivateInterestCalculation.text = objMaster.ActivateInterestCal ? "Y" : "N";

            cbxMaintainBalancing.SelectedItem = objMaster.MaintainBillwiseAccounts ? "Y" : "N";
            tbxInterestPay.Text =Convert.ToString(objMaster.InterestRatePayable);
            tbxInterestrateReceviable.Text = Convert.ToString(objMaster.InterestRateReceivable);

            tbxAddress.Text = objMaster.address;
            tbxAddress1.Text = objMaster.address1;
            tbxAddress2.Text = objMaster.address2;
            tbxAddress3.Text = objMaster.address3;

            tbxContactPerson.Text = objMaster.contactperson;
            tbxCstno.Text = objMaster.CSTNumber;
            tbxEmail.Text = objMaster.email;
            tbxEmailQuery.Text = objMaster.enablemailquery ? "Y" : "N";
            tbxSMSQuery.Text = objMaster.enableSMSquery ? "Y" : "N";

            tbxFax.Text = objMaster.Fax;
            tbxIecode.Text = objMaster.IECode;
            tbxITpan.Text = objMaster.ITPanNumber;
            tbxLstno.Text = objMaster.LstNumber;
            tbxMobileno.Text = objMaster.MobileNumber;
        }

        private void Account_Load(object sender, EventArgs e)
        {
            //layoutLedger.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            //Accountsettings();
            Defaultscreen();
            LodaGroups();
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
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
            AccountMasterModel obj = new AccountMasterModel();

            obj.AccountName = tbxName.Text.Trim();
            obj.PrintName = tbxPrintname.Text.Trim() == null ? string.Empty : tbxPrintname.Text.Trim();
            obj.ShortName = tbxAlias.Text == null ? string.Empty : tbxPrintname.Text.Trim();
            obj.LedgerType = cbxLedgertype.SelectedItem == null ? string.Empty : cbxLedgertype.SelectedItem.ToString();
            obj.Group = cbxGroupname.SelectedItem == null ? string.Empty : cbxGroupname.SelectedItem.ToString();
            obj.MultiCurrency = Convert.ToBoolean(cbxMulticurrency.SelectedItem.ToString() == "Y" ? true : false);

            obj.OPBal = Convert.ToDecimal(tbxOpbal.Text);
            obj.PrevYearBal = Convert.ToDecimal(tbxPrevyearbal.Text);
            obj.DrCrOpeningBal = cbxCrDr.SelectedItem.ToString();
            obj.DrCrPrevBal = cbxPrevCrDr.SelectedItem.ToString();

            obj.CreditDaysforSale = Convert.ToInt32(tbxCreditdaysforSale.Text == string.Empty ? "0" : tbxCreditdaysforSale.Text.Trim());
            obj.CreditDaysforPurchase = Convert.ToInt32(tbxCreditdaysforPurc.Text == string.Empty ? "0" : tbxCreditdaysforPurc.Text.Trim());
            obj.MaintainBillwiseAccounts = cbxMaintainBalancing.SelectedItem.ToString() == "Y" ? true : false;
            //obj.CreditLimit = tbxcred.Text;

            obj.Transport = tbxTransport.Text == null ? string.Empty : tbxTransport.Text;
            obj.Station = tbxStation.Text == null ? string.Empty : tbxStation.Text;

            obj.specifyDefaultSaleType = cbxSpecifydefaultSale.SelectedItem.ToString() == "Y" ? true : false;
            obj.FreezeSaleType = cbxFreezesaletype.SelectedItem.ToString() == "Y" ? true : false;
            obj.DefaultSaleType = cbxDefaultsaletype.SelectedItem.ToString() == "" ? string.Empty : cbxDefaultsaletype.SelectedItem.ToString();

            obj.SpecifyDefaultPurType = cbxSpecifydefaultPurcType.SelectedItem.ToString().Equals("Y") ? true : false;
            obj.DefaultPurcType = cbxDefaultPurcType.SelectedItem == null ? string.Empty : cbxDefaultPurcType.SelectedItem.ToString();
            obj.FreezePurcType = cbxFreezePurcType.SelectedItem.ToString() == "Y" ? true : false;

            obj.InterestRatePayable = Convert.ToDecimal(tbxInterestPay.Text == null ? "0" : tbxInterestPay.Text);
            obj.InterestRateReceivable = Convert.ToDecimal(tbxInterestrateReceviable.Text == null ? "0" : tbxInterestrateReceviable.Text);

            obj.address = tbxAddress.Text.Trim() == null ? string.Empty : tbxAddress.Text.Trim();
            obj.address1 = tbxAddress1.Text.Trim() == null ? string.Empty : tbxAddress1.Text.Trim();
            obj.address2 = tbxAddress2.Text.Trim() == null ? string.Empty : tbxAddress2.Text.Trim();
            obj.address3 = tbxAddress3.Text.Trim() == null ? string.Empty : tbxAddress3.Text.Trim();
            obj.State = cbxState.SelectedItem.ToString();
            obj.area = tbxArea.Text.Trim() == null ? string.Empty : tbxArea.Text.Trim();
            obj.TelephoneNumber = tbxTelno.Text.Trim() == null ? string.Empty : tbxTelno.Text.Trim();

            obj.Fax = tbxFax.Text == null ? string.Empty : tbxFax.Text.Trim();
            obj.MobileNumber = tbxMobileno.Text == null ? string.Empty : tbxMobileno.Text.Trim();
            obj.email = tbxEmail.Text == null ? string.Empty : tbxEmail.Text.Trim();

            obj.enablemailquery = Convert.ToBoolean(tbxEmailQuery.Text.Trim().Equals("Y") ? true : false);
            obj.enableSMSquery = Convert.ToBoolean(tbxSMSQuery.Text.Trim().Equals("Y") ? true : false);

            obj.contactperson = tbxContactPerson.Text == null ? string.Empty : tbxContactPerson.Text.Trim();
            obj.ITPanNumber = tbxITpan.Text == null ? string.Empty : tbxITpan.Text.Trim();
            obj.Ward = tbxWard.Text == null ? string.Empty : tbxWard.Text.Trim();
            obj.LstNumber = tbxLstno.Text == null ? string.Empty : tbxLstno.Text.Trim();
            obj.CSTNumber = tbxCstno.Text == null ? string.Empty : tbxCstno.Text.Trim();
            obj.TIN = tbxTin.Text == null ? string.Empty : tbxTin.Text.Trim();
            obj.LBTNumber = tbxlbtno == null ? string.Empty : tbxlbtno.Text.Trim();
            obj.ServiceTaxNumber = tbxServicetax == null ? string.Empty : tbxServicetax.Text.Trim();
            obj.IECode = tbxIecode.Text == null ? string.Empty : tbxIecode.Text.Trim();
            obj.DLNO1 = tbxDlno1.Text.Trim() == null ? string.Empty : tbxDlno1.Text.Trim();
            obj.No1 = tbxNo1.SelectedText.ToString();
            obj.ChequePrintName = tbxChequePrintName.Text == null ? string.Empty : tbxChequePrintName.Text.Trim();
            obj.allowwebbasedreporting = tbxWebBasedReporting.ToString();
            obj.AccountId = groupId;

            string message = string.Empty;
            bool isSuccess = accMaster.UpdateAccount(obj);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
            }
        }
    }
}
