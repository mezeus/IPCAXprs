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
    public partial class DebitNote : Form
    {
        DebitNoteBL objDNbl = new DebitNoteBL();
        DataTable dtAcc = new DataTable();
        DataTable dtLedger = new DataTable();
        AccountMasterBL objAccBL = new AccountMasterBL();
        public static long DNId=0;

        public DebitNote()
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
            gdvDebitMaster.DataSource = dtAcc;
            dtLedger.Columns.Add("Name");
            dtLedger.Columns.Add("Group");
            dtLedger.Columns.Add("Op.Bal");
            dtLedger.Columns.Add("Address");
            dtLedger.Columns.Add("Mobile");
        }
        private void DebitNote_Load(object sender, EventArgs e)
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
            gdvDebit.Columns["Account"].ColumnEdit = AccLookup;
            gdvDebit.BestFitColumns();

            RepositoryItemLookUpEdit riDCLookup = new RepositoryItemLookUpEdit();
            riDCLookup.DataSource = new string[] { "D", "C" };
            gdvDebit.Columns["DC"].ColumnEdit = riDCLookup;

            riDCLookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            riDCLookup.AutoSearchColumnIndex = 0;

            lactrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lactrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }
        private void gdvDebit_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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

        private void gdvDebit_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "Account")
            {
                gdvDebit.ShowEditor();
                ((LookUpEdit)gdvDebit.ActiveEditor).ShowPopup();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DebitNoteModel objdebit = new DebitNoteModel();

            if (tbxVchNumber.Text.Trim() == "")
            {
                MessageBox.Show("Voucher Number Can Not Be Blank!");
                return;
            }

            objdebit.Voucher_Number = Convert.ToInt32(tbxVchNumber.Text.Trim());
            objdebit.DN_Date = Convert.ToDateTime(dtDate.Text);
            objdebit.Voucher_Series = tbxVoucherSeries.Text.Trim();
            objdebit.Type = cbxType.SelectedItem.ToString();
            objdebit.PDC_Date= Convert.ToDateTime(dtPDC.Text);
            objdebit.LongNarration = tbxLongNarratin.Text.Trim() == null ? string.Empty : tbxLongNarratin.Text.Trim();
            objdebit.TotalCreditAmount = Convert.ToDecimal(colCredit.SummaryItem.SummaryValue);
            objdebit.TotalDebitAmount = Convert.ToDecimal(colDebit.SummaryItem.SummaryValue);
            //Debite Details
            AccountModel objDebit;

            List<AccountModel> lstDebitNotes = new List<AccountModel>();
            for (int i = 0; i < gdvDebit.DataRowCount; i++)
            {
                DataRow row = gdvDebit.GetDataRow(i);

                objDebit = new AccountModel();
                objDebit.DC = row["DC"].ToString();
                objDebit.Account = row["Account"].ToString();
                objDebit.LedgerId =objAccBL.GetLedgerIdByAccountName(row["Account"].ToString());
                objDebit.Debit = row["Debit"].ToString().Length > 0 ? Convert.ToDecimal(row["Debit"].ToString()) : 0;
                objDebit.Credit = row["Credit"].ToString().Length>0 ?  Convert.ToDecimal(row["Credit"].ToString()):0;
                objDebit.Narration = row["Narration"].ToString()==null?string.Empty: row["Narration"].ToString();

                lstDebitNotes.Add(objDebit);
            }

            objdebit.DebitAccountModel = lstDebitNotes;
           
            bool isSuccess = objDNbl.SaveDebitNote(objdebit);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                DNId = 0;
                ClearControls();            
            }
        }

        private void btnDebitList_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Transaction.List.DebitNotesList frmList = new Transaction.List.DebitNotesList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();

            FillDebitNote();
        }
        private void FillDebitNote()
        {
            if(DNId==0)
            {
                lactrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lactrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                tbxVoucherSeries.Focus();
                return;
            }

            List<DebitNoteModel> objMaster = objDNbl.GetDebitNotebyId(DNId);

            tbxVchNumber.Text = objMaster.FirstOrDefault().Voucher_Number.ToString();
            tbxVoucherSeries.Text = objMaster.FirstOrDefault().Voucher_Series.ToString();
            dtDate.Text = objMaster.FirstOrDefault().DN_Date.ToString();
            dtPDC.Text = objMaster.FirstOrDefault().PDC_Date.ToString();
            cbxType.SelectedItem= objMaster.FirstOrDefault().Type.ToString();
            tbxLongNarratin.Text = objMaster.FirstOrDefault().LongNarration.ToString();
            dtAcc.Rows.Clear();
            DataRow drAcc;
            foreach (AccountModel objAcc in objMaster.FirstOrDefault().DebitAccountModel)
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
            gdvDebitMaster.DataSource = dtAcc;
            lactrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lactrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            tbxVoucherSeries.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DebitNoteModel objdebit = new DebitNoteModel();

            if (tbxVchNumber.Text.Trim() == "")
            {
                MessageBox.Show("Voucher Number Can Not Be Blank!");
                return;
            }

            objdebit.Voucher_Number = Convert.ToInt32(tbxVchNumber.Text.Trim());
            objdebit.DN_Date = Convert.ToDateTime(dtDate.Text);
            objdebit.Voucher_Series = tbxVoucherSeries.Text.Trim();
            objdebit.Type = cbxType.SelectedItem.ToString();
            objdebit.PDC_Date = Convert.ToDateTime(dtPDC.Text);
            objdebit.LongNarration = tbxLongNarratin.Text.Trim() == null ? string.Empty : tbxLongNarratin.Text.Trim();
            objdebit.TotalCreditAmount = Convert.ToDecimal(colCredit.SummaryItem.SummaryValue);
            objdebit.TotalDebitAmount = Convert.ToDecimal(colDebit.SummaryItem.SummaryValue);
            //Debite Details
            AccountModel objDebit;

            List<AccountModel> lstDebitNotes = new List<AccountModel>();
            for (int i = 0; i < gdvDebit.DataRowCount; i++)
            {
                DataRow row = gdvDebit.GetDataRow(i);

                objDebit = new AccountModel();
                objDebit.DC = row["DC"].ToString();
                objDebit.Account = row["Account"].ToString();
                objDebit.LedgerId = objAccBL.GetLedgerIdByAccountName(row["Account"].ToString());
                objDebit.Debit = row["Debit"].ToString().Length > 0 ? Convert.ToDecimal(row["Debit"].ToString()) : 0;
                objDebit.Credit = row["Credit"].ToString().Length > 0 ? Convert.ToDecimal(row["Credit"].ToString()) : 0;
                objDebit.Narration = row["Narration"].ToString() == null ? string.Empty : row["Narration"].ToString();
                objDebit.AC_Id = Convert.ToInt32(row["Ac_Id"].ToString() == string.Empty ? "0" : row["Ac_Id"].ToString());
                objDebit.ParentId = Convert.ToInt32(row["ParentId"].ToString() == string.Empty ? "0" : row["ParentId"].ToString());
                lstDebitNotes.Add(objDebit);
            }

            objdebit.DebitAccountModel = lstDebitNotes;
            objdebit.DN_Id =Convert.ToInt32(DNId);
            bool isSuccess = objDNbl.UpdateDebitNote(objdebit);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
                DNId = 0;
                ClearControls();
                Transaction.List.DebitNotesList frmList = new Transaction.List.DebitNotesList();
                frmList.StartPosition = FormStartPosition.CenterScreen;
                frmList.ShowDialog();

                FillDebitNote();
            }
        }

        private void gdvDebitMaster_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            bool isDelete = objDNbl.DeletDebitNote(DNId);
            {
                MessageBox.Show("Delete Successfully!");
                DNId = 0;
                ClearControls();
                Transaction.List.DebitNotesList frmList = new Transaction.List.DebitNotesList();
                frmList.StartPosition = FormStartPosition.CenterScreen;
                frmList.ShowDialog();

                FillDebitNote();

            }
        }
        private void ClearControls()
        {
            tbxVchNumber.Text = string.Empty;
            tbxVoucherSeries.Text = string.Empty;
            cbxType.Text = string.Empty;
            dtDate.Text = string.Empty;
            dtPDC.Text = string.Empty;
            tbxLongNarratin.Text = string.Empty;
            dtAcc.Rows.Clear();
        }

        private void btnNewEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DNId = 0;
            ClearControls();
            lactrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lactrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            tbxVoucherSeries.Focus();
        }
    }
}
