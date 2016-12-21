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
    public partial class TrailBalanceGrd : DevExpress.XtraEditors.XtraForm
    {
        public TrailBalanceGrd()
        {
            InitializeComponent();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void Fill()
        {

            DataSets.TrialBalance.TrialBalanceDtDataTable dt = new DataSets.TrialBalance.TrialBalanceDtDataTable();

              DataSets.TrialBalance.TrialBalanceDtRow dr = dt.NewTrialBalanceDtRow();

            dr[0] = "ITEM1";
            dr[1] = "Paste";
            
            dt.AddTrialBalanceDtRow(dr);

            DataSets.TrialBalance ds = new DataSets.TrialBalance();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            trialBalanceDtBindingSource.DataSource = src;
           
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
            //In treeList the following hierarchy is maintained
            //Level 0- Closing Trial-Alphabetical
            //Level 1- Balances Only
            //Case2- All Account only
            //Case3- Group of Account
            //case

            int selectedNodeId = (sender as TreeList).FocusedNode.Id;
            int selectedLevel = (sender as TreeList).FocusedNode.Level;

            Reports.Accountbooks.TrailBalance frmTB;

            switch (selectedNodeId)
            {
                case 2:
                    frmTB = new TrailBalance("AllAccounts", "Level"+selectedLevel);
                    frmTB.ShowDialog();
                    break;
                case 3:
                    frmTB = new TrailBalance("GroupofAccounts", "Level"+selectedLevel);
                    frmTB.ShowDialog();
                    break;
                case 4:
                    frmTB = new TrailBalance("SelectedAccounts", "Level"+selectedLevel);
                    frmTB.ShowDialog();
                    break;
                case 6:
                    frmTB = new TrailBalance("AllAccounts", "Level"+selectedLevel);
                    frmTB.ShowDialog();
                    break;
                case 7:
                    frmTB = new TrailBalance("GroupofAccounts", "Level"+selectedLevel);
                    frmTB.ShowDialog();
                    break;
                case 8:
                    frmTB = new TrailBalance("SelectedAccounts", "Level"+selectedLevel);
                    frmTB.ShowDialog();
                    break;
                case 9:
                    frmTB = new TrailBalance("MonthEnd", "Level"+selectedLevel);
                    frmTB.ShowDialog();
                    break;
                case 10:
                    frmTB = new TrailBalance("AsonDate", "Level"+selectedLevel);
                    frmTB.ShowDialog();
                    break;
                case 11:
                    frmTB = new TrailBalance("Month-Wise", "Level"+selectedNodeId);
                    frmTB.ShowDialog();
                    break;
                case 12:
                    frmTB = new TrailBalance("Date-Wise", "Level" + selectedNodeId);
                    frmTB.ShowDialog();
                    break;
                case 13:
                    frmTB = new TrailBalance("", "Summary");
                    frmTB.ShowDialog();
                    break;
                case 14:
                    frmTB = new TrailBalance("", "Summary");
                    frmTB.ShowDialog();
                    break;
                case 15:
                    frmTB = new TrailBalance("", "Summary");
                    frmTB.ShowDialog();
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