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
            dtAcc.Columns.Add("Narration");
            dtAcc.Columns.Add("ParentId");
            dtAcc.Columns.Add("Ac_Id");
            gdvMainPayment.DataSource = dtAcc;
            Models.AccountLookup acc = new Models.AccountLookup();

            //gdvJournal.DataSource = DataSets.JournalDs.;
            // Create an in-place LookupEdit control.
            RepositoryItemLookUpEdit riLookup = new RepositoryItemLookUpEdit();

            acc.InitData();

            riLookup.DataSource = acc.Categories;
            riLookup.ValueMember = "ID";
            riLookup.DisplayMember = "CategoryName";

            // Enable the "best-fit" functionality mode in which columns have proportional widths and the popup window is resized to fit all the columns.
            riLookup.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            // Specify the dropdown height.
            riLookup.DropDownRows = acc.Categories.Count;

            // Enable the automatic completion feature. In this mode, when the dropdown is closed, 
            // the text in the edit box is automatically completed if it matches a DisplayMember field value of one of dropdown rows. 
            riLookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            // Specify the column against which an incremental search is performed in SearchMode.AutoComplete and SearchMode.OnlyInPopup modes
            riLookup.AutoSearchColumnIndex = 1;

            // Optionally hide the Description column in the dropdown.
            // riLookup.PopulateColumns();
            // riLookup.Columns["Description"].Visible = false;

            //Series Lookup Edit
            SeriesLookup objSeries = new SeriesLookup();
            tbxVoucherSeries.Properties.DataSource = objSeries.Series;

            // Assign the in-place LookupEdit control to the grid's CategoryID column.
            // Note that the data types of the "ID" and "CategoryID" fields match.
            gdvPayment.Columns["Account"].ColumnEdit = riLookup;
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

            objPayment.TotalDebitAmt = Convert.ToDecimal(colDebit.SummaryItem.SummaryValue);
            objPayment.TotalCreditAmt = Convert.ToDecimal(colCredit.SummaryItem.SummaryValue);

            //Payment details
            AccountModel objacc;
            List<AccountModel> lstAccounts = new List<AccountModel>();

            for (int i = 0; i < gdvPayment.DataRowCount; i++)
            {
                DataRow row = gdvPayment.GetDataRow(i);

                objacc = new AccountModel();
                objacc.DC = row["DC"].ToString();
                objacc.Account = row["Account"].ToString();
                objacc.LegderId = objAccBL.GetLedgerIdByAccountName(row["Account"].ToString());
                objacc.Debit = Convert.ToDecimal(row["Debit"].ToString()==string.Empty?"0.00": row["Debit"].ToString());
                objacc.Credit = Convert.ToDecimal(row["Credit"].ToString()==string.Empty?"0.00": row["Credit"].ToString());
                objacc.Narration = row["Narration"].ToString()==null?string.Empty: row["Narration"].ToString();
                lstAccounts.Add(objacc);
            }

            objPayment.PaymentAccountModel = lstAccounts;
           

            bool isSuccess = objpaybl.SavePaymentVoucher(objPayment);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }
        }

        private void btnPaymentList_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Transaction.List.PaymentVouchersList frmList = new Transaction.List.PaymentVouchersList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
            if(Payid!=0)
            {
                
                tbxVoucherSeries.Focus();
                FillPaymentVoucher();
            }
            
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
            dtPDCDate.Text = objPayment.FirstOrDefault().PDCDate.ToString();
            tbxLongNarration.Text = objPayment.FirstOrDefault().LongNarration;
            //colDebit.S= objPayment.FirstOrDefault().TotalDebitAmt.ToString();
            //objPayment.TotalCreditAmt = Convert.ToDecimal(dr["TotalCreditAmt"]);           


            //paymentVoucherDtBindingSource.DataSource = objPayment.FirstOrDefault().PaymentAccountModel;
           
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
            objPayment.LongNarration = tbxLongNarration.Text.Trim() == null ? string.Empty : tbxLongNarration.Text.Trim();

            objPayment.TotalDebitAmt = Convert.ToDecimal(colDebit.SummaryItem.SummaryValue);
            objPayment.TotalCreditAmt = Convert.ToDecimal(colCredit.SummaryItem.SummaryValue);

            //Payment details
            AccountModel objacc;
            List<AccountModel> lstAccounts = new List<AccountModel>();

            for (int i = 0; i < gdvPayment.DataRowCount; i++)
            {
                DataRow row = gdvPayment.GetDataRow(i);

                objacc = new AccountModel();
                objacc.DC = row["DC"].ToString();
                objacc.Account = row["Account"].ToString();
                objacc.LegderId = objAccBL.GetLedgerIdByAccountName(row["Account"].ToString());
                objacc.Debit = Convert.ToDecimal(row["Debit"].ToString() == string.Empty ? "0.00" : row["Debit"].ToString());
                objacc.Credit = Convert.ToDecimal(row["Credit"].ToString() == string.Empty ? "0.00" : row["Credit"].ToString());
                objacc.Narration = row["Narration"].ToString() == null ? string.Empty : row["Narration"].ToString();
                lstAccounts.Add(objacc);
            }

            objPayment.PaymentAccountModel = lstAccounts;
            objPayment.Pay_Id =Convert.ToInt32(Payid);

            bool isSuccess = objpaybl.UpdatePaymentVoucher(objPayment);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
                Transaction.List.PaymentVouchersList frmList = new Transaction.List.PaymentVouchersList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                if (Payid != 0)
                {
                    lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                    lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    tbxVoucherSeries.Focus();
                    FillPaymentVoucher();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDelete = objpaybl.DeletPaymentVoucher(Payid);
            if (isDelete)
            {
                
                MessageBox.Show("Delete Successfully!");
                ClearFormValues();
                Transaction.List.PaymentVouchersList frmList = new Transaction.List.PaymentVouchersList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                if (Payid != 0)
                {
                    lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                    lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    tbxVoucherSeries.Focus();
                    FillPaymentVoucher();
                }
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
        }

        private void btnNewEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ClearFormValues();
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }
    }
}
