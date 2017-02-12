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
    public partial class ContraVoucher : Form
    {
        ContraVoucherBL objconBL = new ContraVoucherBL();
        AccountMasterBL objAccBL = new AccountMasterBL();
        DataTable dt = new DataTable();
        DataTable dtLedger = new DataTable();
        public static long Contra_Id = 0;
        public ContraVoucher()
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
        private void ContraVoucher_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("S.No");
            dt.Columns.Add("DC");
            dt.Columns.Add("Account");
            dt.Columns.Add("Debit");
            dt.Columns.Add("Credit");
            dt.Columns.Add("Narration");
            dt.Columns.Add("ParentId");
            dt.Columns.Add("Ac_Id");
            dvgMainContra.DataSource = dt;
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
            dvgContraDetails.Columns["Account"].ColumnEdit = AccLookup;
            dvgContraDetails.BestFitMaxRowCount = 5;
            AccLookup.AutoSearchColumnIndex = 1;
            AccLookup.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.None;

            lactrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lactrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            tbxVoucherSeries.Focus();
            RepositoryItemLookUpEdit riDCLookup = new RepositoryItemLookUpEdit();
            riDCLookup.DataSource = new string[] { "D", "C" };
            dvgContraDetails.Columns["DC"].ColumnEdit = riDCLookup;
            riDCLookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            riDCLookup.AutoSearchColumnIndex = 1;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gdvContra_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            dvgContraDetails.ShowEditForm();
        }

        private void gdvContra_KeyPress(object sender, KeyPressEventArgs e)
        {
            dvgContraDetails.ShowEditForm();
        }

        private void gdvContra_ShownEditor(object sender, EventArgs e)
        {

            TextEdit currentEditor = (sender as GridView).ActiveEditor as TextEdit;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            if (dvgContraDetails.FocusedColumn.Caption.ToString() == "D/C")
            {
                collection.Add("YES");
                collection.Add("NO");

                if (currentEditor != null)
                {
                    currentEditor.MaskBox.AutoCompleteMode = AutoCompleteMode.Append;
                    currentEditor.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    currentEditor.MaskBox.AutoCompleteCustomSource = collection;
                }
            }          
        }  
        
        private void gdvContra_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {

            
        }

        private void gdvContra_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
             
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ContraVoucherModel objcontra = new ContraVoucherModel();

            if (tbxVoucherNo.Text.Trim() == "")
            {
                MessageBox.Show("Voucher Number Can Not Be Blank!");
                return;
            }
            objcontra.Voucher_Series = tbxVoucherSeries.SelectedItem.ToString();
            objcontra.Voucher_Number = Convert.ToInt64(tbxVoucherNo.Text.Trim());
            objcontra.CV_Date = Convert.ToDateTime(dtDate.Text.Trim());
            objcontra.PDCDate = Convert.ToDateTime(dtPdc.Text.Trim());
            objcontra.Type = cbxType.SelectedItem.ToString();
            objcontra.LongNarration = tbxLongNarration.Text.Trim();
            objcontra.TotalCreditAmount= Convert.ToDecimal(colCredit.SummaryItem.SummaryValue);
            objcontra.TotalDebitAmount= Convert.ToDecimal(colDebit.SummaryItem.SummaryValue);
            //Contra Account Details
            AccountModel objacc;
            List<AccountModel> lstAccounts = new List<AccountModel>();
            for (int i = 0; i < dvgContraDetails.DataRowCount; i++)
            {
                DataRow row = dvgContraDetails.GetDataRow(i);

                objacc = new AccountModel();
                objacc.DC = row["DC"].ToString();
                objacc.Account = row["Account"].ToString();
                objacc.LedgerId = objAccBL.GetLedgerIdByAccountName(row["Account"].ToString());          
                objacc.Debit = Convert.ToDecimal(row["Debit"].ToString()==string.Empty?"0.00": row["Debit"].ToString());
                objacc.Credit = Convert.ToDecimal(row["Credit"].ToString()==string.Empty?"0.00": row["Credit"].ToString());
                objacc.Narration = row["Narration"].ToString()==null?string.Empty: row["Narration"].ToString();
                lstAccounts.Add(objacc);
            }

            objcontra.ContraAccountModel = lstAccounts;

            bool isSuccess = objconBL.SaveContraVoucher(objcontra);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                ClearFormValues();
            }
        }

        private void btnContraList_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Transaction.List.ContraVouchersList frmList = new Transaction.List.ContraVouchersList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();

            FillContraVoucherInfo();
        }
        public void FillContraVoucherInfo()
        {
            if (Contra_Id == 0)
            {
                ClearFormValues();
                lactrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lactrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                tbxVoucherSeries.Focus();
                return;
            }
            List<ContraVoucherModel> lstContra = objconBL.GetContraVoucherbyId(Contra_Id);
            tbxVoucherSeries.SelectedItem = lstContra.FirstOrDefault().Voucher_Series.ToString();
            dtDate.Text = lstContra.FirstOrDefault().CV_Date.ToString();
            tbxVoucherNo.Text = lstContra.FirstOrDefault().Voucher_Number.ToString();
            cbxType.Text = lstContra.FirstOrDefault().Type.ToString();
            dtPdc.Text = lstContra.FirstOrDefault().PDCDate.ToString();
            tbxLongNarration.Text = lstContra.FirstOrDefault().LongNarration.ToString() == null ? String.Empty : lstContra.FirstOrDefault().LongNarration.ToString();

            dt.Rows.Clear();
            DataRow drAcc;
            foreach (AccountModel objAcc in lstContra.FirstOrDefault().ContraAccountModel)
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
            dvgMainContra.DataSource = dt;
            lactrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lactrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            tbxVoucherSeries.Focus();
        }
        private void dvgContraDetails_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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

        private void dvgContraDetails_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "Account")
            {
                dvgContraDetails.ShowEditor();
                ((LookUpEdit)dvgContraDetails.ActiveEditor).ShowPopup();
            }
        }

        private void dvgMainContra_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ContraVoucherModel objcontra = new ContraVoucherModel();

            if (tbxVoucherNo.Text.Trim() == "")
            {
                MessageBox.Show("Voucher Number Can Not Be Blank!");
                return;
            }
            objcontra.Voucher_Series = tbxVoucherSeries.SelectedItem.ToString();
            objcontra.Voucher_Number = Convert.ToInt64(tbxVoucherNo.Text.Trim());
            objcontra.CV_Date = Convert.ToDateTime(dtDate.Text.Trim());
            objcontra.PDCDate = Convert.ToDateTime(dtPdc.Text.Trim());
            objcontra.Type = cbxType.SelectedItem.ToString();
            objcontra.LongNarration = tbxLongNarration.Text.Trim();
            objcontra.TotalCreditAmount = Convert.ToDecimal(colCredit.SummaryItem.SummaryValue);
            objcontra.TotalDebitAmount = Convert.ToDecimal(colDebit.SummaryItem.SummaryValue);
            //Contra Account Details
            AccountModel objacc;
            List<AccountModel> lstAccounts = new List<AccountModel>();
            for (int i = 0; i < dvgContraDetails.DataRowCount; i++)
            {
                DataRow row = dvgContraDetails.GetDataRow(i);

                objacc = new AccountModel();
                objacc.DC = row["DC"].ToString();
                objacc.Account = row["Account"].ToString();
                objacc.LedgerId = objAccBL.GetLedgerIdByAccountName(row["Account"].ToString());
                objacc.Debit = Convert.ToDecimal(row["Debit"].ToString() == string.Empty ? "0.00" : row["Debit"].ToString());
                objacc.Credit = Convert.ToDecimal(row["Credit"].ToString() == string.Empty ? "0.00" : row["Credit"].ToString());
                objacc.Narration = row["Narration"].ToString() == null ? string.Empty : row["Narration"].ToString();
                objacc.ParentId = Convert.ToInt32(row["ParentId"].ToString() == string.Empty ? "0" : row["ParentId"].ToString());
                objacc.AC_Id = Convert.ToInt32(row["AC_Id"].ToString() == string.Empty ? "0" : row["AC_Id"].ToString());
                lstAccounts.Add(objacc);
            }

            objcontra.ContraAccountModel = lstAccounts;
            objcontra.CV_Id = Contra_Id;

            bool isSuccess = objconBL.UpdateContraVoucher(objcontra);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
                Contra_Id = 0;
                ClearFormValues();
                Transaction.List.ContraVouchersList frmList = new Transaction.List.ContraVouchersList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();

                FillContraVoucherInfo();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDelete = objconBL.DeleteContraVoucher(Contra_Id);
            {
                MessageBox.Show("Delete Successfully!");
                Contra_Id = 0;
                ClearFormValues();
                Transaction.List.ContraVouchersList frmList = new Transaction.List.ContraVouchersList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();

                FillContraVoucherInfo();
            }
        }
        public void ClearFormValues()
        {
            tbxLongNarration.Text = string.Empty;
            cbxType.Text = string.Empty;
            dtDate.Text = string.Empty;
            dtPdc.Text = string.Empty;
            tbxVoucherSeries.Text = string.Empty;
            dt.Rows.Clear();
        }

        private void btnNewEntry_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Contra_Id = 0;
            ClearFormValues();
            lactrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lactrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            tbxVoucherSeries.Focus();
        }
    }
}
