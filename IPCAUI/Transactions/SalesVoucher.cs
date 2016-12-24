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
    public partial class SalesVoucher : Form
    {
        public SalesVoucher()
        {
            InitializeComponent();
        }

        private void navBarItem16_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Settings.AccountsDemo frm = new Settings.AccountsDemo();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog(this);
            //Settings.Accountsettings frm = new Settings.Accountsettings();
            //frm.StartPosition = FormStartPosition.CenterParent;
            //frm.ShowDialog(this);           
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

        private void SalesVoucher_Load(object sender, EventArgs e)
        {
            //this.tbxSeries.Enter += new System.EventHandler(this.tbxSeries_Enter);

            Models.AccountLookup acc = new Models.AccountLookup();


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
            //riLookup.PopulateColumns();
            // riLookup.Columns["Description"].Visible = false;

            // Assign the in-place LookupEdit control to the grid's CategoryID column.
            //// Note that the data types of the "ID" and "CategoryID" fields match.
            gdvItem.Columns["Item"].ColumnEdit = riLookup;
            gdvItem.BestFitColumns();

            ////Bill Sundry Lookup Edit
            gridBs.Columns["BillSundry"].ColumnEdit = riLookup;
            gridBs.BestFitColumns();

            //Series Lookup Edit
            SeriesLookup objSeries = new SeriesLookup();
            tbxSeries.Properties.DataSource = objSeries.Series;

            //Purchase Type Lookup Edit
            tbxSaleType.Properties.DataSource = objSeries.Series;

            //Party Lookup Edit
            tbxParty.Properties.DataSource = acc.Categories;
            tbxParty.Properties.DisplayMember = "CategoryName";
            tbxParty.Properties.ValueMember = "CategoryName";

            //Mat Centre Lookup Edit
            tbxMatcenter.Properties.DataSource = acc.Categories;
            tbxMatcenter.Properties.DisplayMember = "CategoryName";
            tbxMatcenter.Properties.ValueMember = "CategoryName";
        }
    }
}
