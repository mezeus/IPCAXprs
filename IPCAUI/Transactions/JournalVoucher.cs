using System;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class JournalVoucher : Form
    {
        JournalVoucherModelBL objJVbal = new JournalVoucherModelBL();
        AccountMasterBL objAccBL = new AccountMasterBL();
        DataTable dt = new DataTable();
        DataTable dtLedger = new DataTable();
        public static long Journl_Id = 0; 
        public JournalVoucher()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
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
        
        private void JournalVoucher_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("S.No");
            dt.Columns.Add("DC");
            dt.Columns.Add("Account");
            dt.Columns.Add("Debit");
            dt.Columns.Add("Credit");
            dt.Columns.Add("Narration");
            dt.Columns.Add("ParentId");
            dt.Columns.Add("Ac_Id");
            dvgJournalMain.DataSource = dt;
            dtLedger.Columns.Add("Name");
            dtLedger.Columns.Add("Group");
            dtLedger.Columns.Add("Op.Bal");
            dtLedger.Columns.Add("Address");
            dtLedger.Columns.Add("Mobile");
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
            gdvJournalDetails.Columns["Account"].ColumnEdit = AccLookup;
            gdvJournalDetails.BestFitMaxRowCount = 5;
            AccLookup.AutoSearchColumnIndex = 1;
            AccLookup.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.None;

            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;

            RepositoryItemLookUpEdit riDCLookup = new RepositoryItemLookUpEdit();
            riDCLookup.DataSource = new string[] { "D", "C" };
            gdvJournalDetails.Columns["DC"].ColumnEdit = riDCLookup;
            riDCLookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            riDCLookup.AutoSearchColumnIndex = 1;

            riDCLookup.DropDownRows = 0;

        }              

        private void gdvJournal_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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

        private void gdvJournal_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "Account")
            {
                gdvJournalDetails.ShowEditor();
                ((LookUpEdit)gdvJournalDetails.ActiveEditor).ShowPopup();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            JournalVoucherModel objJVmodel = new JournalVoucherModel();

            if (tbxVchNo.Text.Trim() == "")
            {
                MessageBox.Show("Voucher Number Can Not Be Blank!");
                return;
            }
            objJVmodel.Voucher_Series = tbxVoucherSeries.Text.Trim();
            objJVmodel.JV_Date = Convert.ToDateTime(dtDate.Text);
            objJVmodel.Type = tbxType.Text.Trim()==null?string.Empty:tbxType.Text.Trim();
            objJVmodel.Voucher_Number = Convert.ToInt32(tbxVchNo.Text.Trim());
            objJVmodel.PDCDate = Convert.ToDateTime(dtPDCDate.Text);
            objJVmodel.LongNarration = tbxLongNarration.Text.Trim() == null ? string.Empty : tbxLongNarration.Text.Trim();
            objJVmodel.TotalCreditAmt= Convert.ToDecimal(colCredit.SummaryItem.SummaryValue);
            objJVmodel.TotalDebitAmt = Convert.ToDecimal(colDebit.SummaryItem.SummaryValue);

            //Journal details
            AccountModel objacc;
            List<AccountModel> lstAccounts = new List<AccountModel>();

            for (int i = 0; i < gdvJournalDetails.DataRowCount; i++)
            {
                DataRow row = gdvJournalDetails.GetDataRow(i);

                objacc = new AccountModel();
                objacc.DC = row["DC"].ToString();
                objacc.LedgerId = objAccBL.GetLedgerIdByAccountName(row["Account"].ToString());
                objacc.Account = row["Account"].ToString(); 
                objacc.Debit = Convert.ToDecimal(row["Debit"].ToString()==string.Empty?"0":row["Debit"].ToString());
                objacc.Credit = Convert.ToDecimal(row["Credit"].ToString() == string.Empty ? "0" : row["Credit"].ToString());
                objacc.Narration = row["Narration"].ToString() == string.Empty ? string.Empty : row["Narration"].ToString();
                lstAccounts.Add(objacc);
            }

            objJVmodel.JournalAccountModel = lstAccounts;

            bool isSuccess = objJVbal.SaveJournalVoucher(objJVmodel);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                ClearFormValues();
            }
        }

        private void btnJournalList_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Transaction.List.JournalVouchersList frmList = new Transaction.List.JournalVouchersList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
            FillJournalVoucherInfo();

    }
        public void FillJournalVoucherInfo()
        {
            if(Journl_Id==0)
            {
                lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                tbxVoucherSeries.Focus();
                return;
            }
            List<JournalVoucherModel> lstJournal = objJVbal.GetJournalbyId(Journl_Id);
            tbxVoucherSeries.SelectedItem = lstJournal.FirstOrDefault().Voucher_Series.ToString();
            dtDate.Text= lstJournal.FirstOrDefault().JV_Date.ToString();
            tbxVchNo.Text= lstJournal.FirstOrDefault().Voucher_Number.ToString();
            tbxType.Text= lstJournal.FirstOrDefault().Type.ToString();
            dtPDCDate.Text= lstJournal.FirstOrDefault().PDCDate.ToString();
            tbxLongNarration.Text= lstJournal.FirstOrDefault().LongNarration.ToString()==null?String.Empty: lstJournal.FirstOrDefault().LongNarration.ToString();

            dt.Rows.Clear();
            DataRow drAcc;
            foreach(AccountModel objAcc in lstJournal.FirstOrDefault().JournalAccountModel)
            {
                drAcc = dt.NewRow();
                drAcc["DC"] = objAcc.DC;
                drAcc["Account"] = objAcc.Account;
                drAcc["Debit"] = objAcc.Debit;
                drAcc["Credit"] = objAcc.Credit;
                drAcc["Narration"] = objAcc.Narration;
                drAcc["ParentId"] = objAcc.ParentId;
                drAcc["Ac_Id"] = objAcc.AC_Id;
                dt.Rows.Add(drAcc);
            }
            dvgJournalMain.DataSource = dt;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            tbxVoucherSeries.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            JournalVoucherModel objJVmodel = new JournalVoucherModel();

            if (tbxVchNo.Text.Trim() == "")
            {
                MessageBox.Show("Voucher Number Can Not Be Blank!");
                return;
            }
            objJVmodel.Voucher_Series = tbxVoucherSeries.Text.Trim();
            objJVmodel.JV_Date = Convert.ToDateTime(dtDate.Text);
            objJVmodel.Type = tbxType.Text.Trim() == null ? string.Empty : tbxType.Text.Trim();
            objJVmodel.Voucher_Number = Convert.ToInt32(tbxVchNo.Text.Trim());
            objJVmodel.PDCDate = Convert.ToDateTime(dtPDCDate.Text);
            objJVmodel.LongNarration = tbxLongNarration.Text.Trim() == null ? string.Empty : tbxLongNarration.Text.Trim();
            objJVmodel.TotalCreditAmt = Convert.ToDecimal(colCredit.SummaryItem.SummaryValue);
            objJVmodel.TotalDebitAmt = Convert.ToDecimal(colDebit.SummaryItem.SummaryValue);

            //Journal details
            AccountModel objacc;
            List<AccountModel> lstAccounts = new List<AccountModel>();

            for (int i = 0; i < gdvJournalDetails.DataRowCount; i++)
            {
                DataRow row = gdvJournalDetails.GetDataRow(i);

                objacc = new AccountModel();
                objacc.DC = row["DC"].ToString();
                objacc.LedgerId = objAccBL.GetLedgerIdByAccountName(row["Account"].ToString());
                objacc.Account = row["Account"].ToString();
                objacc.Debit = Convert.ToDecimal(row["Debit"].ToString() == string.Empty ? "0" : row["Debit"].ToString());
                objacc.Credit = Convert.ToDecimal(row["Credit"].ToString() == string.Empty ? "0" : row["Credit"].ToString());
                objacc.Narration = row["Narration"].ToString() == string.Empty ? string.Empty : row["Narration"].ToString();
                objacc.AC_Id = Convert.ToInt32(row["AC_Id"].ToString() == string.Empty ? "0" : row["AC_Id"].ToString());
                objacc.ParentId = Convert.ToInt32(row["ParentId"].ToString() == string.Empty ? "0" : row["ParentId"].ToString());
                lstAccounts.Add(objacc);
            }

            objJVmodel.JournalAccountModel = lstAccounts;
            objJVmodel.JV_Id =Convert.ToInt32(Journl_Id);

            bool isSuccess = objJVbal.UpdateJournalVoucher(objJVmodel);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
                Journl_Id = 0;
                ClearFormValues();
                Transaction.List.JournalVouchersList frmList = new Transaction.List.JournalVouchersList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                FillJournalVoucherInfo();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDelete = objJVbal.DeletJournalVoucher(Journl_Id);
            {
                MessageBox.Show("Delete Successfully!");
                Journl_Id = 0;
                ClearFormValues();
                Transaction.List.JournalVouchersList frmList = new Transaction.List.JournalVouchersList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                FillJournalVoucherInfo();
            }
        }
        public void ClearFormValues()
        {
            tbxLongNarration.Text = string.Empty;
            tbxType.Text = string.Empty;
            dtDate.Text = string.Empty;
            dtPDCDate.Text = string.Empty;
            tbxVoucherSeries.Text = string.Empty;
            dt.Rows.Clear();
        }

        private void btnNewEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Journl_Id = 0;
            ClearFormValues();
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            tbxVoucherSeries.Focus();
        }
    }
}
