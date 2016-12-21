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
using DevExpress.XtraTreeList;

namespace IPCAUI.Reports.Accountbooks.Grids
{
    public partial class BalanceSheetGrd : DevExpress.XtraEditors.XtraForm
    {
        public BalanceSheetGrd()
        {
            InitializeComponent();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void Fill()
        {
            
            DataSets.BalanceSheet.BalSheetDtDataTable dt = new DataSets.BalanceSheet.BalSheetDtDataTable();

            //DataRow dr = dt.NewRow();

            //dr[0] = "ITEM1";
            //dr[1] = "Paste";
            //dr[2] = "0.0";
            //dr[3] = "dozen";

            DataSets.BalanceSheet.BalSheetDtRow dr = dt.NewBalSheetDtRow();

            dr[0] = "ITEM1";
            dr[1] = "Paste";
            
            dt.AddBalSheetDtRow(dr);

            DataSets.BalanceSheet ds = new DataSets.BalanceSheet();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            balSheetDtBindingSource.DataSource = src;
           // repositoryItemLookUpEdit1.DataSource = src;
        }

        private void DayBook_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'iPCADataSet.Approvers' table. You can move, or remove it, as needed.
            

        }

        private void dockPanel3_Click(object sender, EventArgs e)
        {

        }

        private void officeNavigationBar1_Click(object sender, EventArgs e)
        {

        }

        private void officeNavigationBar1_QueryPeekFormContent(object sender, DevExpress.XtraBars.Navigation.QueryPeekFormContentEventArgs e)
        {
            
            
    }

        private void btnFilters_Click(object sender, EventArgs e)
        {
            Reports.Accountbooks.Daybook frmdayBook = new Daybook();
            frmdayBook.ShowDialog();                       
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void repositoryItemTextEdit1_Click(object sender, EventArgs e)
        {

        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

            int selectedNodeId = (sender as TreeList).FocusedNode.Id;
            Reports.Accountbooks.BalanceSheet frmPL;

            switch (selectedNodeId)
            {
                case 1:
                    frmPL = new BalanceSheet("Month", "Horizontal");
                    frmPL.ShowDialog();
                    break;
                case 2:
                    frmPL = new BalanceSheet("Date", "Horizontal");
                    frmPL.ShowDialog();
                    break;
                case 4:
                    frmPL = new BalanceSheet("Month", "Vertical");
                    frmPL.ShowDialog();
                    break;
                case 5:
                    frmPL = new BalanceSheet("Date", "Vertical");
                    frmPL.ShowDialog();
                    break;
                case 7:
                    //Reports.AccountSummary.DailySummary frmDaily = new AccountSummary.DailySummary();
                    //frmDaily.ShowDialog();
                    break;
                case 8:
                    //Reports.AccountSummary.DailySummary frmDaily = new AccountSummary.DailySummary();
                    //frmDaily.ShowDialog();
                    break;
                case 9:
                    frmPL = new BalanceSheet("", "Summary");
                    frmPL.ShowDialog();
                    break;
                default:
                    break;
            }
        }

        private void treeList1_Click(object sender, EventArgs e)
        {
           // string s = (sender as TreeList).FocusedNode.GetValue(0);
        }

        private void treeList1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void tlistAccountbook_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            //string selectedNode = (sender as TreeList).FocusedNode.GetValue(0).ToString();
            //switch (selectedNode)
            //{
            //    case "Account Group Ledger":
            //        Reports.Accountbooks.AccountGroupLedger frmAccGrp = new Reports.Accountbooks.AccountGroupLedger();
            //        frmAccGrp.ShowDialog();
            //        break;
            //    case "Account Ledger":
            //        Reports.Accountbooks.AccountLedger frmAccLed = new Reports.Accountbooks.AccountLedger();
            //        frmAccLed.ShowDialog();
            //        break;
            //    case "Monthly Summary":
            //        break;
            //    case "Account-Wise":
            //        break;
            //    case "Merged Accounts":
            //        break;
            //    case "Single Column":
            //        break;
            //    case "Multiple Column":
            //        break;
            //    case "Bank Book(As per Clr.Date)":
            //        break;
            //    default:
            //        break;
            //}

        }

        private void tlistAccountbook_MouseEnter(object sender, EventArgs e)
        {
            //DevExpress.XtraTreeList.TreeListHitInfo hi = treeList1.CalcHitInfo(e.);

            //if (hi.HitInfoType == DevExpress.XtraTreeList.HitInfoType.Cell)
            //    //MessageBox.Show(hi.Node[treeListColumn1].ToString());
            //    if (hi.Node[treeListColumn1].ToString().Equals("Balance Sheet"))
            //    {
            //        Balancesheet frm = new Balancesheet();
            //        frm.Show();
            //    }
        }

        private void tlistAccountbook_MouseDown(object sender, MouseEventArgs e)
        {
            /*
            DevExpress.XtraTreeList.TreeListHitInfo hi = tlistAccountbook.CalcHitInfo(e.Location);
            if(hi.HitInfoType == DevExpress.XtraTreeList.HitInfoType.Cell)
            {
                string selectedNode = hi.Node[Accountbooks].ToString();
                switch (selectedNode)
                {
                    case "Account Group Ledger":
                        Reports.Accountbooks.AccountGroupLedger frmAccGrp = new Reports.Accountbooks.AccountGroupLedger();
                        frmAccGrp.StartPosition = FormStartPosition.CenterParent;
                        frmAccGrp.ShowDialog();
                        break;
                    case "Account Ledger":
                        Reports.Accountbooks.AccountLedger frmAccLed = new Reports.Accountbooks.AccountLedger();
                        frmAccLed.ShowDialog();
                        break;
                    case "Bank Book":
                       Bankbook frmBook = new Bankbook();
                        frmBook.ShowDialog();
                        break;
                    case "Cash Book Single":
                        CashbookSingle frmCashbook = new CashbookSingle();
                        frmCashbook.ShowDialog();
                        break;
                    case "Day Book":
                        Daybook frmday = new Daybook();
                        frmday.ShowDialog();
                        break;
                    case "Payment Register":
                        PaymentRegister frmpay = new PaymentRegister();
                        frmpay.ShowDialog();
                        break;
                    case "Purchase Register":
                        PurchaseRegister frmpurc = new PurchaseRegister();
                        frmpurc.ShowDialog();
                        break;
                    case "Purchase Return Register":
                        PurchaseReturnRegister frmPurcre = new PurchaseReturnRegister();
                        frmPurcre.ShowDialog();
                        break;
                    case "Receipt Register":
                        RecepitRegister frmRece = new RecepitRegister();
                        frmRece.ShowDialog();
                        break;
                    case "Sales Register":
                        Saleregister frmsale = new Saleregister();
                        frmsale.ShowDialog();
                        break;
                    case "Sales Return Register":
                        SalesReturnRegister frmsaleret = new SalesReturnRegister();
                        frmsaleret.ShowDialog();
                        break;
                    case "Sub Ledger":
                        SubLedger frmsub = new SubLedger();
                        frmsub.ShowDialog();
                        break;
                    default:
                        break;
                }

            }
            */

            //string selectedNode = (sender as TreeList).FocusedNode.GetValue(0).ToString();
        }

        private void treeList1_FocusedNodeChanged_1(object sender, FocusedNodeChangedEventArgs e)
        {

        }

        private void BalanceSheetGrd_Load(object sender, EventArgs e)
        {
            Fill();
        }
    }

}