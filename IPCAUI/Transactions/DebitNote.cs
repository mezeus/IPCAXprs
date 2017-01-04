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
        public static int DNId;

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

        private void DebitNote_Load(object sender, EventArgs e)
        {
            InitData();

            int dn = DNId;
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
            gdvDebit.Columns["Account"].ColumnEdit = riLookup;
            gdvDebit.BestFitColumns();

            RepositoryItemLookUpEdit riDCLookup = new RepositoryItemLookUpEdit();
            riDCLookup.DataSource = new string[] { "D", "C" };
            gdvDebit.Columns["DC"].ColumnEdit = riDCLookup;

            riDCLookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoFilter;
            riDCLookup.AutoSearchColumnIndex = 1;
            //Series Lookup Edit
            SeriesLookup objSeries = new SeriesLookup();
            tbxVoucherSeries.Properties.DataSource = objSeries.Series;

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
            objdebit.TotalCreditAmount = Convert.ToDecimal(colCredit.SummaryItem.SummaryValue);
            objdebit.TotalDebitAmount = Convert.ToDecimal(colDebit.SummaryItem.SummaryValue);

            //Items
            AccountModel objDebit;

            List<AccountModel> lstDebitNotes = new List<AccountModel>();

            for (int i = 0; i < gdvDebit.DataRowCount; i++)
            {
                DataRow row = gdvDebit.GetDataRow(i);

                objDebit = new AccountModel();

                objDebit.DC = row["DC"].ToString();

                objDebit.Account = row["Account"].ToString(); /*Convert.ToDecimal(row["Qty"]);*/

                objDebit.Debit = row["Debit"].ToString().Length > 0 ? Convert.ToDecimal(row["Debit"].ToString()) : 0;
                objDebit.Credit = row["Credit"].ToString().Length>0 ?  Convert.ToDecimal(row["Credit"].ToString()):0;

                objDebit.Narration = row["Narration"].ToString();

                lstDebitNotes.Add(objDebit);
            }

            objdebit.DebitAccountModel = lstDebitNotes;
           
            bool isSuccess = objDNbl.SaveDebitNote(objdebit);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");             
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
            btnUpdate.Visible = true;
            btnSave.Visible = false;

            List<DebitNoteModel> objMaster = objDNbl.GetDebitNotebyId(DNId);

            tbxVchNumber.Text = objMaster.FirstOrDefault().Voucher_Number.ToString();
            tbxVoucherSeries.Text = objMaster.FirstOrDefault().Voucher_Series.ToString();

            //Need to map the correct values
           // tbxLongNarratin.Text = objMaster.FirstOrDefault().LongNarration.ToString();
            dtDate.Text = objMaster.FirstOrDefault().DN_Date.ToString();

            debitDtBindingSource.DataSource= objMaster.FirstOrDefault().DebitAccountModel;
            //gdvDebitMaster.DataSource = objMaster.FirstOrDefault().DebitAccountModel;
                       
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DebitNoteModel objdebit = new DebitNoteModel();

            if (tbxVchNumber.Text.Trim() == "")
            {
                MessageBox.Show("Voucher Number Can Not Be Blank!");
                return;
            }

            objdebit.DN_Id = DNId;
            objdebit.Voucher_Number = Convert.ToInt32(tbxVchNumber.Text.Trim());
            objdebit.DN_Date = Convert.ToDateTime(dtDate.Text);
            objdebit.Voucher_Series = tbxVoucherSeries.Text.Trim();
            objdebit.TotalCreditAmount = Convert.ToDecimal(colCredit.SummaryItem.SummaryValue);
            objdebit.TotalDebitAmount = Convert.ToDecimal(colDebit.SummaryItem.SummaryValue);

            //Items
            AccountModel objDebit;

            List<AccountModel> lstDebitNotes = new List<AccountModel>();

            for (int i = 0; i < gdvDebit.DataRowCount; i++)
            {
                AccountModel row;
                row = gdvDebit.GetRow(i) as AccountModel;
             
                objDebit = new AccountModel();

                objDebit.ParentId= Convert.ToInt32(row.ParentId);
                objDebit.AC_Id = Convert.ToInt32(row.AC_Id);
                
                objDebit.DC = row.DC.ToString();

                objDebit.Account = row.Account.ToString(); /*Convert.ToDecimal(row["Qty"]);*/

                objDebit.Debit = row.Debit.ToString().Length > 0 ? Convert.ToDecimal(row.Debit.ToString()) : 0;
                objDebit.Credit = row.Credit.ToString().Length > 0 ? Convert.ToDecimal(row.Credit.ToString()) : 0;

                //objDebit.Narration = row.Narration.ToString();

                lstDebitNotes.Add(objDebit);
            }

            objdebit.DebitAccountModel = lstDebitNotes;

            bool isSuccess = objDNbl.UpdateDebitNote(objdebit);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }
        }
    }
}
