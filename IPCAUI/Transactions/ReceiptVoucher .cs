using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using eSunSpeed.BusinessLogic;
using eSunSpeedDomain;
using IPCAUI.Models;

namespace IPCAUI.Transactions
{
    public partial class ReceiptVoucher : Form
    {
        RecieptVoucherBL objRecBL = new RecieptVoucherBL();
        AccountMasterBL objAccBL = new AccountMasterBL();
        DataTable dtAcc = new DataTable();
        DataTable dtLedger = new DataTable();
        public static long Recpt_Id = 0;
        public ReceiptVoucher()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReceiptVoucher_Load(object sender, EventArgs e)
        {
           
            dtAcc.Columns.Add("S.No");
            dtAcc.Columns.Add("DC");
            dtAcc.Columns.Add("Account");
            dtAcc.Columns.Add("Debit");
            dtAcc.Columns.Add("Credit");
            dtAcc.Columns.Add("Narration");
            dtAcc.Columns.Add("ParentId");
            dtAcc.Columns.Add("Ac_Id");
            gdvMainReceipt.DataSource = dtAcc;
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
            gdvReceipt.Columns["Account"].ColumnEdit = AccLookup;
            gdvReceipt.BestFitColumns();
           

            RepositoryItemLookUpEdit riDCLookup = new RepositoryItemLookUpEdit();
            riDCLookup.DataSource = new string[] { "D", "C" };
            gdvReceipt.Columns["DC"].ColumnEdit = riDCLookup;

            riDCLookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            riDCLookup.AutoSearchColumnIndex = 1;
        }

        private void gdvReceipt_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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

        private void gdvReceipt_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "Account")
            {
                gdvReceipt.ShowEditor();
                ((LookUpEdit)gdvReceipt.ActiveEditor).ShowPopup();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            RecieptVoucherModel objRecipt = new RecieptVoucherModel();

            if (tbxVchNumber.Text.Trim() == "")
            {
                MessageBox.Show("Voucher Number Can Not Be Blank!");
                return;
            }
            objRecipt.Voucher_Series = tbxVoucherSeries.Text.Trim();
            objRecipt.Voucher_Number = Convert.ToInt32(tbxVchNumber.Text.Trim());
            objRecipt.RV_Date = Convert.ToDateTime(dtDate.Text);
            objRecipt.Type = tbxType.Text.Trim();
            objRecipt.PDCDate = Convert.ToDateTime(dtPDCDate.Text);
            objRecipt.LongNarration = tbxLongNarration.Text.Trim()==string.Empty?string.Empty:tbxLongNarration.Text.Trim();
            objRecipt.TotalDebitAmt = Convert.ToDecimal(colDebit.SummaryItem.SummaryValue);
            objRecipt.TotalCreditAmt = Convert.ToDecimal(colCredit.SummaryItem.SummaryValue);

            //Receipt Account Details
            AccountModel objacc;
            List<AccountModel> lstAccounts = new List<AccountModel>();

            for (int i = 0; i < gdvReceipt.DataRowCount; i++)
            {
                DataRow row = gdvReceipt.GetDataRow(i);

                objacc = new AccountModel();
                objacc.DC = row["DC"].ToString();
                objacc.Account = row["Account"].ToString();
                objacc.LegderId = objAccBL.GetLedgerIdByAccountName(row["Account"].ToString());
                objacc.Debit = Convert.ToDecimal(row["Debit"].ToString() == string.Empty ? "0.00" : row["Debit"]);
                objacc.Credit = Convert.ToDecimal(row["Credit"].ToString() == string.Empty ? "0.00" : row["Credit"]);
                objacc.Narration = row["Narration"].ToString() == string.Empty ? string.Empty : row["Narration"].ToString();
                lstAccounts.Add(objacc);
            }
            objRecipt.RecieptAccountModel = lstAccounts;
   
            bool isSuccess = objRecBL.SaveRecieptVoucher(objRecipt);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                Recpt_Id = 0;
                ClearFormValues();
            }
        }

        private void gdvMainReceipt_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            RecieptVoucherModel objRecipt = new RecieptVoucherModel();

            if (tbxVchNumber.Text.Trim() == "")
            {
                MessageBox.Show("Voucher Number Can Not Be Blank!");
                return;
            }
            objRecipt.Voucher_Series = tbxVoucherSeries.Text.Trim();
            objRecipt.Voucher_Number = Convert.ToInt32(tbxVchNumber.Text.Trim());
            objRecipt.RV_Date = Convert.ToDateTime(dtDate.Text);
            objRecipt.Type = tbxType.Text.Trim();
            objRecipt.PDCDate = Convert.ToDateTime(dtPDCDate.Text);
            objRecipt.LongNarration = tbxLongNarration.Text.Trim() == null ? string.Empty : tbxLongNarration.Text.Trim();
            objRecipt.TotalDebitAmt = Convert.ToDecimal(colDebit.SummaryItem.SummaryValue);
            objRecipt.TotalCreditAmt = Convert.ToDecimal(colCredit.SummaryItem.SummaryValue);

            //Receipt Account Details
            AccountModel objacc;
            List<AccountModel> lstAccounts = new List<AccountModel>();

            for (int i = 0; i < gdvReceipt.DataRowCount; i++)
            {
                DataRow row = gdvReceipt.GetDataRow(i);

                objacc = new AccountModel();
                objacc.ParentId = Convert.ToInt32(row["ParentId"].ToString()==string.Empty?"0": row["ParentId"]);
                objacc.AC_Id = Convert.ToInt32(row["Ac_Id"].ToString() == string.Empty ? "0" : row["Ac_Id"]);
                objacc.DC = row["DC"].ToString();
                objacc.Account = row["Account"].ToString();
                objacc.LegderId = objAccBL.GetLedgerIdByAccountName(row["Account"].ToString());
                objacc.Debit = Convert.ToDecimal(row["Debit"].ToString()== string.Empty ? "0" : row["Debit"]);
                objacc.Credit = Convert.ToDecimal(row["Credit"].ToString() == string.Empty ? "0" : row["Credit"]);
                objacc.Narration = row["Narration"].ToString() == string.Empty ?string.Empty : row["Narration"].ToString();
                lstAccounts.Add(objacc);
            }
            objRecipt.RecieptAccountModel = lstAccounts;
            objRecipt.RV_Id = Recpt_Id;
            bool isSuccess = objRecBL.UpdateRecieptVoucher(objRecipt);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
                Recpt_Id = 0;
                ClearFormValues();
                Transaction.List.ReceiptVouchersList frmList = new Transaction.List.ReceiptVouchersList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();             
                FillRecieptVoucherInfo();
            }
        }

        private void btnReceiptList_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Transaction.List.ReceiptVouchersList frmList = new Transaction.List.ReceiptVouchersList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
            FillRecieptVoucherInfo();
        }
        public void FillRecieptVoucherInfo()
        {
            if (Recpt_Id == 0)
            {
                ClearFormValues();
                lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                tbxVoucherSeries.Focus();
                return;
            }
            List<RecieptVoucherModel> objReciept = objRecBL.GetRecieptbyId(Recpt_Id);

            tbxVoucherSeries.Text = objReciept.FirstOrDefault().Voucher_Series.ToString();
            dtDate.Text = objReciept.FirstOrDefault().RV_Date.ToString();
            tbxVchNumber.Text = objReciept.FirstOrDefault().Voucher_Number.ToString();
            tbxType.Text = objReciept.FirstOrDefault().Type.ToString();
            dtPDCDate.Text = objReciept.FirstOrDefault().PDCDate.ToString();
            tbxLongNarration.Text = objReciept.FirstOrDefault().LongNarration.ToString();
            //objReciept.TotalCreditAmt = Convert.ToDecimal(dr["TotalCreditAmt"]);
            //objReciept.TotalDebitAmt = Convert.ToDecimal(dr["TotalDebitAmt"]);
            dtAcc.Rows.Clear();

            DataRow dr;

             foreach(AccountModel objmod in objReciept.FirstOrDefault().RecieptAccountModel)
            {
                 dr = dtAcc.NewRow();

                dr["DC"] = objmod.DC;
                dr["Account"] = objmod.Account;
                dr["Debit"] = objmod.Debit;
                dr["Credit"] = objmod.Credit;
                dr["Narration"] = objmod.Narration;
                dr["ParentId"]= objmod.ParentId;
                dr["Ac_Id"] = objmod.AC_Id;
                dtAcc.Rows.Add(dr);
            }
            gdvMainReceipt.DataSource = dtAcc;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            tbxVoucherSeries.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDelete = objRecBL.DeleteRecieptVoucher(Recpt_Id);
            if (isDelete)
            {
                MessageBox.Show("Delete Successfully!");
                ClearFormValues();
                Recpt_Id = 0;
                Transaction.List.PaymentVouchersList frmList = new Transaction.List.PaymentVouchersList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                FillRecieptVoucherInfo();
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
            Recpt_Id = 0;
            dtAcc.Rows.Clear();
        }

        private void btnNewEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Recpt_Id = 0;
            ClearFormValues();
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            tbxVoucherSeries.Focus();
        }

        private void gdvReceipt_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column.Caption=="D/C")
            {
                if(e.Value.ToString()=="D")
                {
                    colCredit.OptionsColumn.ReadOnly= true;
                    colDebit.OptionsColumn.ReadOnly = false;
                }
                else
                {
                    colCredit.OptionsColumn.ReadOnly = false;
                    colDebit.OptionsColumn.ReadOnly = true;
                }
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
