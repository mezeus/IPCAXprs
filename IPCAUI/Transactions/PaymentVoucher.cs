using System;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IPCAUI.Models;
using eSunSpeed.BusinessLogic;
using eSunSpeedDomain;

namespace IPCAUI.Transactions
{
    public partial class PaymentVoucher : Form
    {
        PaymentVoucherBL objpaybl = new PaymentVoucherBL();
        AccountMasterBL objAccBL = new AccountMasterBL();
        DataTable dtAcc = new DataTable();
        DataTable dtLedger = new DataTable();
        DataTable dtPayAcc = new DataTable();
        public static long Payid = 0;
        public PaymentVoucher()
        {
            InitializeComponent();
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

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void PaymentVoucher_Load(object sender, EventArgs e)
        {
            
            dtAcc.Columns.Add("S.No");
            dtAcc.Columns.Add("DC");
            dtAcc.Columns.Add("Account");
            dtAcc.Columns.Add("Debit");
            dtAcc.Columns.Add("Credit");
            dtAcc.Columns.Add("Amount");
            dtAcc.Columns.Add("Narration");
            dtAcc.Columns.Add("ParentId");
            dtAcc.Columns.Add("Ac_Id");
            gdvMainPayment.DataSource = dtAcc;

            dtLedger.Columns.Add("Name");
            dtLedger.Columns.Add("Group");
            dtLedger.Columns.Add("Op.Bal");
            dtLedger.Columns.Add("Address");
            dtLedger.Columns.Add("Mobile");

            dtPayAcc.Columns.Add("Name");
            dtPayAcc.Columns.Add("Group");
            dtPayAcc.Columns.Add("Op.Bal");
            dtPayAcc.Columns.Add("Address");
            dtPayAcc.Columns.Add("Mobile");
            dtAcc.Rows.Clear();
            DataRow drAcc;
            List<AccountMasterModel> lstAccount = objAccBL.GetListofAccount();
            foreach (AccountMasterModel objAcc in lstAccount)
            {
                if(objAcc.AccGroupId==72 || objAcc.AccGroupId == 73|| objAcc.AccGroupId == 74)
                {
                    drAcc = dtPayAcc.NewRow();
                    drAcc["Name"] = objAcc.AccountName;
                    drAcc["Group"] = objAcc.Group;
                    drAcc["Op.Bal"] = objAcc.OPBal;
                    drAcc["Address"] = objAcc.address;
                    drAcc["Mobile"] = objAcc.MobileNumber;
                    dtPayAcc.Rows.Add(drAcc);
                }
                
            }
            cbxPayMode.Properties.DataSource = dtPayAcc;
            cbxPayMode.Properties.DisplayMember = "Name";
            dtLedger.Rows.Clear();
            RepositoryItemLookUpEdit AccLookup = new RepositoryItemLookUpEdit();
            DataRow drparty;
            List<AccountMasterModel> lstAccounts = objAccBL.GetListofAccount();
            foreach (AccountMasterModel objAcc in lstAccounts)
            {
                drparty = dtLedger.NewRow();
                drparty["Name"] = objAcc.AccountName;
                drparty["Group"] = objAcc.Group;
                drparty["Op.Bal"] = objAcc.OPBal;
                drparty["Address"] = objAcc.address;
                drparty["Mobile"] = objAcc.MobileNumber;
                dtLedger.Rows.Add(drparty);
            }
            AccLookup.DataSource = dtLedger;
            AccLookup.ValueMember = "Name";
            AccLookup.DisplayMember = "Name";
            AccLookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            AccLookup.AutoSearchColumnIndex = 1;
            gdvPayment.Columns["Account"].ColumnEdit = AccLookup;
            gdvPayment.BestFitColumns();

            RepositoryItemLookUpEdit riDCLookup = new RepositoryItemLookUpEdit();
            riDCLookup.DataSource = new string[] { "D", "C" };
            gdvPayment.Columns["DC"].ColumnEdit = riDCLookup;

            riDCLookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            riDCLookup.AutoSearchColumnIndex = 1;

            riDCLookup.DropDownRows = 0;

            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            SingleEntryMode();
        }

        private void gdvPayment_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "SNo")
            {
                GridView gridView = (GridView)sender;
                e.DisplayText = (gridView.GetRowHandle(e.ListSourceRowIndex) + 1).ToString();

                if (Convert.ToInt32(e.DisplayText) < 0)
                {
                    e.DisplayText = "";
                }
            }
        }

        private void gdvPayment_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "Account")
            {
                gdvPayment.ShowEditor();
                ((LookUpEdit)gdvPayment.ActiveEditor).ShowPopup();
            }
        }

        private void gdvMainPayment_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PaymentVoucherModel objPayment = new PaymentVoucherModel();

            if (tbxVchNumber.Text.Trim() == "")
            {
                MessageBox.Show("Voucher Number Can Not Be Blank!");
                return;
            }
            objPayment.Voucher_Series = tbxVoucherSeries.Text.Trim();
            objPayment.Voucher_Number = Convert.ToInt32(tbxVchNumber.Text.Trim());
            objPayment.Pay_Date = Convert.ToDateTime(dtDate.Text);
            objPayment.Type = tbxType.Text.Trim() == null ? string.Empty : tbxType.Text.Trim();
            objPayment.PDCDate = Convert.ToDateTime(dtPDCDate.Text);
            objPayment.LongNarration = tbxLongNarration.Text.Trim()==null?string.Empty:tbxLongNarration.Text.Trim();
            objPayment.PaymentModeId =objAccBL.GetLedgerIdByAccountName(cbxPayMode.Text.Trim() == null ? string.Empty : cbxPayMode.Text.Trim());
            if(objPayment.PaymentModeId==0)
            {
                objPayment.TotalDebitAmt = Convert.ToDecimal(colDebit.SummaryItem.SummaryValue);
                objPayment.TotalCreditAmt = Convert.ToDecimal(colCredit.SummaryItem.SummaryValue);
            }
            else
            {
                objPayment.TotalCreditAmt = Convert.ToDecimal(colAmount.SummaryItem.SummaryValue);
            }

            //Payment details
            AccountModel objacc;
            List<AccountModel> lstAccounts = new List<AccountModel>();

            for (int i = 0; i < gdvPayment.DataRowCount; i++)
            {
                DataRow row = gdvPayment.GetDataRow(i);

                objacc = new AccountModel();
                objacc.DC = row["DC"].ToString();
                objacc.Account = row["Account"].ToString();
                objacc.LedgerId = objAccBL.GetLedgerIdByAccountName(row["Account"].ToString());
                if(objPayment.PaymentModeId==0)
                {
                    objacc.Debit = Convert.ToDecimal(row["Debit"].ToString() == string.Empty ? "0.00" : row["Debit"].ToString());
                    objacc.Credit = Convert.ToDecimal(row["Credit"].ToString() == string.Empty ? "0.00" : row["Credit"].ToString());
                }
                else
                {
                    objacc.Debit = Convert.ToDecimal(row["Amount"].ToString() == string.Empty ? "0.00" : row["Amount"].ToString());
                }               
                objacc.Narration = row["Narration"].ToString()==null?string.Empty: row["Narration"].ToString();
                lstAccounts.Add(objacc);
            }
            objPayment.PaymentAccountModel = lstAccounts;
            //Ledger Posting
            if(objPayment.PaymentModeId!=0)
            {
                //Single Entery Ledger Debit Posting
            LedgerPostingModel objLedger;
            List<LedgerPostingModel> lstLedgerDebit = new List<LedgerPostingModel>();

            for (int i = 0; i < gdvPayment.DataRowCount; i++)
            {
                DataRow row = gdvPayment.GetDataRow(i);

                objLedger = new LedgerPostingModel();
                objLedger.LedgerId= objAccBL.GetLedgerIdByAccountName(row["Account"].ToString());
                objLedger.Date= Convert.ToDateTime(dtDate.Text.Trim());
                objLedger.Debit = Convert.ToDecimal(row["Amount"].ToString() == string.Empty ? "0.00" : row["Amount"].ToString());
                objLedger.Credit =0;
                objLedger.VoucherNo = tbxVchNumber.Text.Trim();
                objLedger.VoucherTypeId = 1;
                objLedger.ChequeNo = string.Empty;
                objLedger.ChequeDate = DateTime.Now;
                objLedger.Extra1 = string.Empty;
                objLedger.Extra2 = string.Empty;
                objLedger.DetailsId = 0;
                objLedger.YearId = 1;
                lstLedgerDebit.Add(objLedger);
            }
            objPayment.PaymentLPDebit = lstLedgerDebit;
            //Single Entery Ledger Credit Posting
            LedgerPostingModel objLedgerCredit;
            List<LedgerPostingModel> lstLedgerCredit = new List<LedgerPostingModel>();

            for (int i = 0; i < gdvPayment.DataRowCount; i++)
            {
                DataRow row = gdvPayment.GetDataRow(i);

                objLedgerCredit = new LedgerPostingModel();
                objLedgerCredit.LedgerId = objPayment.PaymentModeId;
                objLedgerCredit.Date = Convert.ToDateTime(dtDate.Text.Trim());
                objLedgerCredit.Credit = Convert.ToDecimal(row["Amount"].ToString() == string.Empty ? "0.00" : row["Amount"].ToString());
                objLedgerCredit.Debit = 0;
                objLedgerCredit.VoucherNo = tbxVchNumber.Text.Trim();
                objLedgerCredit.VoucherTypeId = 1;
                objLedgerCredit.ChequeNo = string.Empty;
                objLedgerCredit.ChequeDate = DateTime.Now;
                objLedgerCredit.Extra1 = string.Empty;
                objLedgerCredit.Extra2 = string.Empty;
                objLedgerCredit.DetailsId = 0;
                objLedgerCredit.DetailsId = 1;
                lstLedgerCredit.Add(objLedgerCredit);
            }
            objPayment.PaymentLPCredit = lstLedgerCredit;
            }
            else
            {

            }
            


            bool isSuccess = objpaybl.SavePaymentVoucher(objPayment);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                Payid = 0;
                //ClearFormValues();
            }
        }
        public void LedgerPostingAdd()
        {
            try
            {
                string strfinancialId;
                //decOpeningBalance = Convert.ToDecimal(tbxOpbal.Text.Trim());
                LedgerPostingBL objBL = new LedgerPostingBL();
                LedgerPostingModel infoLedgerPosting = new LedgerPostingModel();

                FinancialYeaBL objFinBL = new FinancialYeaBL();

                FinancialYearModel infoFinancialYear = new FinancialYearModel();

                infoFinancialYear = objFinBL.FinancialYearViewForAccountLedger(1);

                strfinancialId = infoFinancialYear.FromDate.ToString("dd-MMM-yyyy");

                infoLedgerPosting.VoucherTypeId = 1;
                infoLedgerPosting.Date = Convert.ToDateTime(dtDate.Text.Trim());
                infoLedgerPosting.LedgerId = Convert.ToDecimal(objAccBL.GetLedgerIdByAccountName(cbxPayMode.Text.Trim()==null?String.Empty:cbxPayMode.Text.Trim()));
                infoLedgerPosting.VoucherNo =tbxVchNumber.Text.Trim();

                //if (cbxCrDr.Text == "D")
                //{
                //    infoLedgerPosting.Debit = decOpeningBalance;
                //}
                //else
                //{
                //    infoLedgerPosting.Credit = decOpeningBalance;
                //}
                infoLedgerPosting.DetailsId = 0;
                infoLedgerPosting.YearId = SessionVariables._decCurrentFinancialYearId;
                //infoLedgerPosting.InvoiceNo = decLedgerId.ToString();
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
        private void btnPaymentList_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Transaction.List.PaymentVouchersList frmList = new Transaction.List.PaymentVouchersList();
            frmList.StartPosition = FormStartPosition.CenterScreen;
            frmList.ShowDialog();

            FillPaymentVoucher();        
        }
        private void FillPaymentVoucher()
        {
            if(Payid==0)
            {
                tbxVoucherSeries.Focus();
                lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                return;
            }

            List<PaymentVoucherModel> objPayment = objpaybl.GetPaymentbyId(Payid);

            tbxVoucherSeries.Text = objPayment.FirstOrDefault().Voucher_Series;
            dtDate.Text = objPayment.FirstOrDefault().Pay_Date.ToString();
            tbxVchNumber.Text = objPayment.FirstOrDefault().Voucher_Number.ToString();
            tbxType.Text = objPayment.FirstOrDefault().Type;
            cbxPayMode.Text = objPayment.FirstOrDefault().PaymentMode.ToString();
            dtPDCDate.Text = objPayment.FirstOrDefault().PDCDate.ToString();
            tbxLongNarration.Text = objPayment.FirstOrDefault().LongNarration;
            //colDebit.S= objPayment.FirstOrDefault().TotalDebitAmt.ToString();
            //objPayment.TotalCreditAmt = Convert.ToDecimal(dr["TotalCreditAmt"]);           
            dtAcc.Rows.Clear();
            DataRow drAcc;
            foreach(AccountModel objPay in objPayment.FirstOrDefault().PaymentAccountModel)
            {
                drAcc = dtAcc.NewRow();
                drAcc["DC"] = objPay.DC;
                drAcc["Account"] = objPay.Account;
                drAcc["Debit"] = objPay.Debit;
                drAcc["Credit"] = objPay.Credit;
                drAcc["Amount"] = objPay.Amount;
                drAcc["Narration"] = objPay.Narration;
                drAcc["ParentId"] = objPay.ParentId;
                drAcc["Ac_Id"] = objPay.AC_Id;
                dtAcc.Rows.Add(drAcc);
            }
            gdvMainPayment.DataSource = dtAcc;
            if(objPayment.FirstOrDefault().PaymentModeId==0)
            {
                DoubleEntryMode();
            }
            else
            {
                SingleEntryMode();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            PaymentVoucherModel objPayment = new PaymentVoucherModel();

            if (tbxVchNumber.Text.Trim() == "")
            {
                MessageBox.Show("Voucher Number Can Not Be Blank!");
                return;
            }
            objPayment.Voucher_Series = tbxVoucherSeries.Text.Trim();
            objPayment.Voucher_Number = Convert.ToInt32(tbxVchNumber.Text.Trim());
            objPayment.Pay_Date = Convert.ToDateTime(dtDate.Text);
            objPayment.Type = tbxType.Text.Trim() == null ? string.Empty : tbxType.Text.Trim();
            objPayment.PDCDate = Convert.ToDateTime(dtPDCDate.Text);
            objPayment.PaymentModeId = objAccBL.GetLedgerIdByAccountName(cbxPayMode.Text.Trim() ==null?string.Empty:cbxPayMode.Text.Trim());
            objPayment.LongNarration = tbxLongNarration.Text.Trim() == null ? string.Empty : tbxLongNarration.Text.Trim();
            if (objPayment.PaymentModeId == 0)
            {
                objPayment.TotalDebitAmt = Convert.ToDecimal(colDebit.SummaryItem.SummaryValue);
                objPayment.TotalCreditAmt = Convert.ToDecimal(colCredit.SummaryItem.SummaryValue);
            }
            else
            {
                objPayment.TotalCreditAmt = Convert.ToDecimal(colAmount.SummaryItem.SummaryValue);
            }
            //Payment details
            AccountModel objacc;
            List<AccountModel> lstAccounts = new List<AccountModel>();

            for (int i = 0; i < gdvPayment.DataRowCount; i++)
            {
                DataRow row = gdvPayment.GetDataRow(i);

                objacc = new AccountModel();
                objacc.DC = row["DC"].ToString();
                objacc.Account = row["Account"].ToString();
                objacc.LedgerId = objAccBL.GetLedgerIdByAccountName(row["Account"].ToString());
                if (objPayment.PaymentModeId == 0)
                {
                    objacc.Debit = Convert.ToDecimal(row["Debit"].ToString() == string.Empty ? "0.00" : row["Debit"].ToString());
                    objacc.Credit = Convert.ToDecimal(row["Credit"].ToString() == string.Empty ? "0.00" : row["Credit"].ToString());
                }
                else
                {
                    objacc.Debit = Convert.ToDecimal(row["Amount"].ToString() == string.Empty ? "0.00" : row["Amount"].ToString());
                }
                objacc.Narration = row["Narration"].ToString() == null ? string.Empty : row["Narration"].ToString();
                objacc.ParentId = Convert.ToInt32(row["ParentId"].ToString() == string.Empty ? "0" : row["ParentId"]);
                objacc.AC_Id = Convert.ToInt32(row["Ac_Id"].ToString() == string.Empty ? "0" : row["Ac_Id"]);
                lstAccounts.Add(objacc);
            }

            objPayment.PaymentAccountModel = lstAccounts;
            objPayment.Pay_Id = Payid;

            bool isSuccess = objpaybl.UpdatePaymentVoucher(objPayment);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
                Payid = 0;
                ClearFormValues();
                Transaction.List.PaymentVouchersList frmList = new Transaction.List.PaymentVouchersList();
                frmList.StartPosition = FormStartPosition.CenterScreen;
                frmList.ShowDialog();

                FillPaymentVoucher();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDelete = objpaybl.DeletPaymentVoucher(Payid);
            if (isDelete)
            {
                
                MessageBox.Show("Delete Successfully!");
                Payid = 0;
                ClearFormValues();
                Transaction.List.PaymentVouchersList frmList = new Transaction.List.PaymentVouchersList();
                frmList.StartPosition = FormStartPosition.CenterScreen;
                frmList.ShowDialog();

                FillPaymentVoucher();
            }
        }
       public void ClearFormValues()
        {
            tbxLongNarration.Text = string.Empty;
            tbxType.Text = string.Empty;
            tbxVchNumber.Text = string.Empty;
            dtDate.Text = string.Empty;
            dtPDCDate.Text = string.Empty;
            tbxVoucherSeries.Text = string.Empty;
            dtAcc.Rows.Clear();
        }

        private void btnNewEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Payid = 0;
            ClearFormValues();
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }

        private void btnSingleEntry_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            SingleEntryMode();
        }
        private void SingleEntryMode()
        {
            DC.Visible = false;
            Account.Visible = true;
            Account.VisibleIndex = 1;
            colDebit.Visible = false;
            colCredit.Visible = false;
            colAmount.Visible = true;
            colAmount.VisibleIndex = 2;
            colNarration.Visible = true;
            colNarration.VisibleIndex = 3;
            btnSingleEntry.Visible = false;
            btnDoubleEntery.Visible = true;
            lactrlPayMode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            //lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            tbxVoucherSeries.Focus();
        }
        private void DoubleEntryMode()
        {
            DC.VisibleIndex = -1;
            Account.VisibleIndex = -1;
            colDebit.VisibleIndex = -1;
            colCredit.VisibleIndex = -1;
            colNarration.VisibleIndex = -1;
            DC.Visible = true;
            DC.VisibleIndex = 1;
            Account.VisibleIndex = 2;
            colDebit.VisibleIndex = 3;
            colCredit.VisibleIndex = 4;
            colAmount.Visible = false;
            colNarration.VisibleIndex = 5;
            btnSingleEntry.Visible = true;
            btnDoubleEntery.Visible = false;
            lactrlPayMode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            //lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            //lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            tbxVoucherSeries.Focus();
        }

        private void btnDoubleEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DoubleEntryMode();
        }
    }
}
