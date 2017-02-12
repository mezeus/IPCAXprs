using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System;
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
    public partial class CreditNote : Form
    {
        CreditNoteBL objBl = new CreditNoteBL();
        DataTable dtAcc = new DataTable();
        DataTable dtLedger = new DataTable();
        AccountMasterBL objAccBL = new AccountMasterBL();
        public static long CNId=0;

        public CreditNote()
        {
            InitializeComponent();
        }
        private void Loadtables()
        {
            dtAcc.Columns.Add("S.No");
            dtAcc.Columns.Add("DC");
            dtAcc.Columns.Add("Account");
            dtAcc.Columns.Add("Debit");
            dtAcc.Columns.Add("Credit");
            dtAcc.Columns.Add("Narration");
            dtAcc.Columns.Add("ParentId");
            dtAcc.Columns.Add("Ac_Id");
            gvdAccounts.DataSource = dtAcc;
            dtLedger.Columns.Add("Name");
            dtLedger.Columns.Add("Group");
            dtLedger.Columns.Add("Op.Bal");
            dtLedger.Columns.Add("Address");
            dtLedger.Columns.Add("Mobile");       
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

        private void CreditNote_Load(object sender, EventArgs e)
        {
            Loadtables();
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
            AccLookup.AutoSearchColumnIndex = 0;
            gdvCredit.Columns["Account"].ColumnEdit = AccLookup;
            gdvCredit.BestFitColumns();

            RepositoryItemLookUpEdit riDCLookup = new RepositoryItemLookUpEdit();
            riDCLookup.DataSource = new string[] { "D", "C" };
            gdvCredit.Columns["DC"].ColumnEdit = riDCLookup;

            riDCLookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            riDCLookup.AutoSearchColumnIndex = 0;

            lactrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lactrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }

        private void gdvCredit_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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
            if(e.Column.Caption=="D/C")
            {
                GridView gridView = (GridView)sender;
                //e.DisplayText =(gridView.GetRowHandle(e.)             
            }
        }

        private void gdvCredit_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "Account")
            {
                gdvCredit.ShowEditor();
                ((LookUpEdit)gdvCredit.ActiveEditor).ShowPopup();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CreditNoteModel objcredit = new CreditNoteModel();

            if (tbxVoucherNumber.Text.Trim() == "")
            {
                MessageBox.Show("Voucher Number Can Not Be Blank!");
                return;
            }
            objcredit.Voucher_Series = tbxVoucherSeries.Text.Trim() == null ? string.Empty : tbxVoucherSeries.Text.Trim();
            objcredit.Voucher_Number = Convert.ToInt32(tbxVoucherNumber.Text.Trim());
            objcredit.CN_Date = Convert.ToDateTime(dtDate.Text);
            objcredit.Type = tbxType.Text.Trim();
            objcredit.PDCDate = Convert.ToDateTime(dtPDCDate.Text);
            objcredit.Narration = tbxLogNarration.Text.Trim();

            objcredit.TotalCreditAmt = Convert.ToDecimal(colCredit.SummaryItem.SummaryValue);
            objcredit.TotalDebitAmt= Convert.ToDecimal(colDebit.SummaryItem.SummaryValue);

            //Credit Note Account details
            AccountModel objacc;
            List<AccountModel> lstAccounts = new List<AccountModel>();

            for (int i = 0; i < gdvCredit.DataRowCount; i++)
            {
                DataRow row = gdvCredit.GetDataRow(i);

                objacc = new AccountModel();
                objacc.DC = row["DC"].ToString();
                objacc.Account = row["Account"].ToString()==null?string.Empty: row["Account"].ToString();
                objacc.LedgerId = objAccBL.GetLedgerIdByAccountName(row["Account"].ToString() == null ? string.Empty : row["Account"].ToString());
                objacc.Debit = row["Debit"].ToString().Length > 0 ? Convert.ToDecimal(row["Debit"].ToString()) : 0;
                objacc.Credit = row["Credit"].ToString().Length > 0 ? Convert.ToDecimal(row["Credit"].ToString()) : 0;
                objacc.Narration = row["Narration"].ToString()==null?string.Empty: row["Narration"].ToString();
                lstAccounts.Add(objacc);
            }

            objcredit.CreditAccountModel = lstAccounts;
            bool isSuccess = objBl.SaveCreditNote(objcredit);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                CNId = 0;
                ClearControls();              
            }
        }

        private void btnList_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Transaction.List.CreditNotesList frmList = new Transaction.List.CreditNotesList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();

            FillCreditNote();
        }
        private void ClearControls()
        {
            tbxVoucherNumber.Text = string.Empty;
            tbxVoucherSeries.Text = string.Empty;
            tbxType.Text = string.Empty;
            dtDate.Text = string.Empty;
            dtPDCDate.Text = string.Empty;
            tbxLogNarration.Text = string.Empty;
            dtAcc.Rows.Clear();
        }
        private void FillCreditNote()
        {
            if(CNId==0)
            {
                ClearControls();
                lactrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lactrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                tbxVoucherSeries.Focus();
                return;
            }
            List<CreditNoteModel> objMaster = objBl.GetCreditNotebyId(CNId);
            tbxVoucherNumber.Text = objMaster.FirstOrDefault().Voucher_Number.ToString();
            tbxVoucherSeries.Text = objMaster.FirstOrDefault().Voucher_Series.ToString();
            tbxType.Text = objMaster.FirstOrDefault().Type.ToString();
            dtDate.Text= objMaster.FirstOrDefault().CN_Date.ToString();
            dtPDCDate.Text= objMaster.FirstOrDefault().PDCDate.ToString();
            tbxLogNarration.Text = objMaster.FirstOrDefault().Narration.ToString();
            dtAcc.Rows.Clear();
            DataRow drAcc;
            foreach(AccountModel objAcc in objMaster.FirstOrDefault().CreditAccountModel)
            {
                drAcc = dtAcc.NewRow();
                drAcc["DC"] = objAcc.DC;
                drAcc["Account"] = objAcc.Account;
                drAcc["Debit"] = objAcc.Debit;
                drAcc["Credit"] = objAcc.Credit;
                drAcc["Narration"] = objAcc.Narration;
                drAcc["ParentId"] = objAcc.ParentId;
                drAcc["Ac_Id"] = objAcc.AC_Id;
                dtAcc.Rows.Add(drAcc);
            }
            gvdAccounts.DataSource = dtAcc;
            lactrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lactrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            tbxVoucherSeries.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CreditNoteModel objcredit = new CreditNoteModel();

            if (tbxVoucherNumber.Text.Trim() == "")
            {
                MessageBox.Show("Voucher Number Can Not Be Blank!");
                return;
            }
            objcredit.Voucher_Series = tbxVoucherSeries.Text.Trim() == null ? string.Empty : tbxVoucherSeries.Text.Trim();
            objcredit.Voucher_Number = Convert.ToInt32(tbxVoucherNumber.Text.Trim());
            objcredit.CN_Date = Convert.ToDateTime(dtDate.Text);
            objcredit.Type = tbxType.Text.Trim();
            objcredit.PDCDate = Convert.ToDateTime(dtPDCDate.Text);
            objcredit.Narration = tbxLogNarration.Text.Trim();

            objcredit.TotalCreditAmt = Convert.ToDecimal(colCredit.SummaryItem.SummaryValue);
            objcredit.TotalDebitAmt = Convert.ToDecimal(colDebit.SummaryItem.SummaryValue);

            //Credit Note Account details
            AccountModel objacc;
            List<AccountModel> lstAccounts = new List<AccountModel>();

            for (int i = 0; i < gdvCredit.DataRowCount; i++)
            {
                DataRow row = gdvCredit.GetDataRow(i);

                objacc = new AccountModel();
                objacc.DC = row["DC"].ToString();
                objacc.Account = row["Account"].ToString() == null ? string.Empty : row["Account"].ToString();
                objacc.LedgerId = objAccBL.GetLedgerIdByAccountName(row["Account"].ToString() == null ? string.Empty : row["Account"].ToString());
                objacc.Debit = row["Debit"].ToString().Length > 0 ? Convert.ToDecimal(row["Debit"].ToString()) : 0;
                objacc.Credit = row["Credit"].ToString().Length > 0 ? Convert.ToDecimal(row["Credit"].ToString()) : 0;
                objacc.Narration = row["Narration"].ToString() == null ? string.Empty : row["Narration"].ToString();
                objacc.AC_Id =row["AC_Id"].ToString().Length > 0 ? Convert.ToInt32(row["AC_Id"].ToString()) : 0;
                objacc.ParentId = row["ParentId"].ToString().Length > 0 ? Convert.ToInt32(row["ParentId"].ToString()) : 0;
                lstAccounts.Add(objacc);
            }

            objcredit.CreditAccountModel = lstAccounts;
            objcredit.CN_Id = CNId;

            bool isSuccess = objBl.UpdateCreditNote(objcredit);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
                CNId = 0;
                ClearControls();
                Transaction.List.CreditNotesList frmList = new Transaction.List.CreditNotesList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();

                FillCreditNote();
            }
        }

        private void gvdAccounts_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDelete = objBl.DeleteCreditNote(CNId);
            if (isDelete)
            {
                MessageBox.Show("Delete Successfully!");
                CNId = 0;
                ClearControls();
                Transaction.List.CreditNotesList frmList = new Transaction.List.CreditNotesList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();

                FillCreditNote();
            }
        }

        private void btnNewEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            CNId = 0;
            ClearControls();
            lactrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lactrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }
    }
}
