using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace IPCAUI.Menu
{
    public partial class ReportMenu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        XtraForm1 frm;
        public ReportMenu(XtraForm1 frm)
        {
            InitializeComponent();
            this.frm = frm;                   
        }

        private void rptDayBook_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Reports.Accountbooks.Grids.BalanceSheetGrd frm;
            frm = new Reports.Accountbooks.Grids.BalanceSheetGrd(); //generate new instance
            frm.Owner = this;
            frm.TopLevel = false;
            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
           // Reports.Accountbooks.Grids.DayBook frmDayBook = new Reports.Accountbooks.Grids.DayBook();
           //frmDayBook.MdiParent = this;
           // frmDayBook.Show();
           // splitContainerControl1.Panel2.Controls.Add(frmDayBook);           
        }

        private void dockPanel1_Click(object sender, EventArgs e)
        {

        }

        private void btnFilters_Click(object sender, EventArgs e)
        {
            Reports.Accountbooks.Daybook frmdayBook = new Reports.Accountbooks.Daybook();
            frmdayBook.ShowDialog();
        }

        private void rptLedger_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           // dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            //dockPanel2.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;

            Reports.Accountbooks.Daybook frmdayBook = new Reports.Accountbooks.Daybook();
            frmdayBook.ShowDialog();
        }

        private void rbtnAccountWise_CheckedChanged(object sender, EventArgs e)
        {
            //if (rbtnAccountWise.Checked)
            //{
            //    Reports.Accountbooks.Daybook frmdayBook = new Reports.Accountbooks.Daybook();
            //    frmdayBook.ShowDialog();
            //}
        }
        private void treeList1_SelectionChanged(object sender, EventArgs e)
        {
            //string s = (sender as TreeList).Selection.Count.ToString() + " node(s) selected";
            //barStaticItem1.Caption = s;
        }

        private void navBarItem1_ItemChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Clicked");
        }

        private void ReportMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.frm.Visible = true;

        }

      
        private void rbtnProfitLoss_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Reports.Accountbooks.Grids.ProfitLossGrd frm;
            frm = new Reports.Accountbooks.Grids.ProfitLossGrd(); //generate new instance
            frm.Owner = this;
            frm.TopLevel = false;
            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void rptBalanceSheet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Reports.Accountbooks.Grids.BalanceSheetGrd frm;
            frm = new Reports.Accountbooks.Grids.BalanceSheetGrd(); //generate new instance
            frm.Owner = this;
            frm.TopLevel = false;
            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void rptTrailBalance_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Reports.Accountbooks.Grids.TrailBalanceGrd frm;
            //frm = new Reports.Accountbooks.Grids.TrailBalanceGrd(); //generate new instance
            //frm.Owner = this;
            //frm.TopLevel = false;
            //splitContainerControl1.Panel2.Controls.Add(frm);
            //frm.Show();
        }

        private void rptAccountRegister_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void rptPartyDayBook_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem35_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barbtnAccountBooks_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Reports.Accountbooks.Grids.DayBook frm;
            frm = new Reports.Accountbooks.Grids.DayBook(); //generate new instance
            frm.Owner = this;
            frm.TopLevel = false;
            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }
    }
}