﻿using System;
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
        DataTable dt = new DataTable();
        public static int Recpt_Id = 0;
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
           
            dt.Columns.Add("S.No");
            dt.Columns.Add("DC");
            dt.Columns.Add("Account");
            dt.Columns.Add("Debit");
            dt.Columns.Add("Credit");
            dt.Columns.Add("Narration");
            dt.Columns.Add("ParentId");
            dt.Columns.Add("Ac_Id");
            gdvMainReceipt.DataSource = dt;
            InitData();
            Models.AccountLookup acc = new Models.AccountLookup();

            // Create an in-place LookupEdit control.
            RepositoryItemLookUpEdit riLookup = new RepositoryItemLookUpEdit();
            riLookup.DataSource = Categories;
            riLookup.ValueMember = "ID";
            riLookup.DisplayMember = "CategoryName";

            // Enable the "best-fit" functionality mode in which columns have proportional widths and the popup window is resized to fit all the columns.
            riLookup.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            // Specify the dropdown height.
            riLookup.DropDownRows = Categories.Count;

            // Enable the automatic completion feature. In this mode, when the dropdown is closed, 
            // the text in the edit box is automatically completed if it matches a DisplayMember field value of one of dropdown rows. 
            riLookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            // Specify the column against which an incremental search is performed in SearchMode.AutoComplete and SearchMode.OnlyInPopup modes
            riLookup.AutoSearchColumnIndex = 1;

            // Optionally hide the Description column in the dropdown.
            // riLookup.PopulateColumns();
            // riLookup.Columns["Description"].Visible = false;

            // Assign the in-place LookupEdit control to the grid's CategoryID column.
            // Note that the data types of the "ID" and "CategoryID" fields match.
            gdvReceipt.Columns["Account"].ColumnEdit = riLookup;
            gdvReceipt.BestFitColumns();

            RepositoryItemLookUpEdit riDCLookup = new RepositoryItemLookUpEdit();
            riDCLookup.DataSource = new string[] { "D", "C" };
            gdvReceipt.Columns["DC"].ColumnEdit = riDCLookup;

            riDCLookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            riDCLookup.AutoSearchColumnIndex = 1;

            //Series Lookup Edit
            SeriesLookup objSeries = new SeriesLookup();
            tbxVoucherSeries.Properties.DataSource = objSeries.Series;

            //Party Lookup Edit
            tbxType.Properties.DataSource = acc.Categories;
            tbxType.Properties.DisplayMember = "CategoryName";
            tbxType.Properties.ValueMember = "CategoryName";
            riDCLookup.DropDownRows = 0;

            //riDCLookup.ValueMember = "ID";
            //riDCLookup.DisplayMember = "CategoryName";
        }

        List<Product> Products = new List<Product>();
        List<Category> Categories = new List<Category>();

        private void InitData()
        {
            Products.Add(new Product() { ProductName = "Sir Rodney's Scones", CategoryID = 3, UnitPrice = 10 });
            Products.Add(new Product() { ProductName = "Gustaf's Knäckebröd", CategoryID = 5, UnitPrice = 21 });
            Products.Add(new Product() { ProductName = "Tunnbröd", CategoryID = 5, UnitPrice = 9 });
            Products.Add(new Product() { ProductName = "Guaraná Fantástica", CategoryID = 1, UnitPrice = 4.5m });
            Products.Add(new Product() { ProductName = "NuNuCa Nuß-Nougat-Creme", CategoryID = 3, UnitPrice = 14 });
            Products.Add(new Product() { ProductName = "Gumbär Gummibärchen", CategoryID = 3, UnitPrice = 31.23m });
            Products.Add(new Product() { ProductName = "Rössle Sauerkraut", CategoryID = 7, UnitPrice = 45.6m });
            Products.Add(new Product() { ProductName = "Thüringer Rostbratwurst", CategoryID = 6, UnitPrice = 123.79m });
            Products.Add(new Product() { ProductName = "Nord-Ost Matjeshering", CategoryID = 8, UnitPrice = 25.89m });
            Products.Add(new Product() { ProductName = "Gorgonzola Telino", CategoryID = 4, UnitPrice = 12.5m });

            Categories.Add(new Category() { ID = 1, CategoryName = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales" });
            Categories.Add(new Category() { ID = 2, CategoryName = "Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings" });
            Categories.Add(new Category() { ID = 3, CategoryName = "Confections", Description = "Desserts, candies, and sweet breads" });
            Categories.Add(new Category() { ID = 4, CategoryName = "Dairy Products", Description = "Cheeses" });
            Categories.Add(new Category() { ID = 5, CategoryName = "Grains/Cereals", Description = "Breads, crackers, pasta, and cereal" });
            Categories.Add(new Category() { ID = 6, CategoryName = "Meat/Poultry", Description = "Prepared meats" });
            Categories.Add(new Category() { ID = 7, CategoryName = "Produce", Description = "Dried fruit and bean curd" });
            Categories.Add(new Category() { ID = 8, CategoryName = "Seafood", Description = "Seaweed and fish" });
        }


        public class Product
        {
            public string ProductName { get; set; }
            public decimal UnitPrice { get; set; }
            public int CategoryID { get; set; }
        }

        public class Category
        {
            public int ID { get; set; }
            public string CategoryName { get; set; }
            public string Description { get; set; }
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
                objacc.Debit = Convert.ToDecimal(row["Debit"].ToString() == string.Empty ? "0" : row["Debit"]);
                objacc.Credit = Convert.ToDecimal(row["Credit"].ToString() == string.Empty ? "0" : row["Credit"]);
                objacc.Narration = row["Narration"].ToString() == string.Empty ? string.Empty : row["Narration"].ToString();
                lstAccounts.Add(objacc);
            }
            objRecipt.RecieptAccountModel = lstAccounts;
   
            bool isSuccess = objRecBL.SaveRecieptVoucher(objRecipt);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
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
                Transaction.List.ReceiptVouchersList frmList = new Transaction.List.ReceiptVouchersList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();

                if (Recpt_Id != 0)
                {
                    lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                    lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    tbxVoucherSeries.Focus();
                    FillRecieptVoucherInfo();
                }
            }
        }

        private void btnReceiptList_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Transaction.List.ReceiptVouchersList frmList = new Transaction.List.ReceiptVouchersList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();

            if (Recpt_Id != 0)
            {
                lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                tbxVoucherSeries.Focus();
                FillRecieptVoucherInfo();
            }
        }
        public void FillRecieptVoucherInfo()
        {
            List<RecieptVoucherModel> objReciept = objRecBL.GetRecieptbyId(Recpt_Id);

            tbxVoucherSeries.Text = objReciept.FirstOrDefault().Voucher_Series.ToString();
            dtDate.Text = objReciept.FirstOrDefault().RV_Date.ToString();
            tbxVchNumber.Text = objReciept.FirstOrDefault().Voucher_Number.ToString();
            tbxType.Text = objReciept.FirstOrDefault().Type.ToString();
            dtPDCDate.Text = objReciept.FirstOrDefault().PDCDate.ToString();
            tbxLongNarration.Text = objReciept.FirstOrDefault().LongNarration.ToString();
            //objReciept.TotalCreditAmt = Convert.ToDecimal(dr["TotalCreditAmt"]);
            //objReciept.TotalDebitAmt = Convert.ToDecimal(dr["TotalDebitAmt"]);

            dt.Rows.Clear();

            DataRow dr;

             foreach(AccountModel objmod in objReciept.FirstOrDefault().RecieptAccountModel)
            {
                 dr = dt.NewRow();

                dr["DC"] = objmod.DC;
                dr["Account"] = objmod.Account;
                dr["Debit"] = objmod.Debit;
                dr["Credit"] = objmod.Credit;
                dr["Narration"] = objmod.Narration;
                dr["ParentId"]= objmod.ParentId;
                dr["Ac_Id"] = objmod.AC_Id;
                dt.Rows.Add(dr);
            }

            gdvMainReceipt.DataSource = dt;
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDelete = objRecBL.DeleteRecieptVoucher(Recpt_Id);
            if (isDelete)
            {
                MessageBox.Show("Delete Successfully!");
                ClearFormValues();
                Transaction.List.PaymentVouchersList frmList = new Transaction.List.PaymentVouchersList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                if (Recpt_Id != 0)
                {
                    lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                    lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    tbxVoucherSeries.Focus();
                    FillRecieptVoucherInfo();
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
            Recpt_Id = 0;
            dt.Rows.Clear();
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
