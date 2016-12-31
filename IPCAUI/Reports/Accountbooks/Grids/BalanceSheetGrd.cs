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
using eSunSpeed.BusinessLogic;
using static eSunSpeed.BusinessLogic.BalanceSheetBL;

namespace IPCAUI.Reports.Accountbooks.Grids
{
    public partial class BalanceSheetGrd : DevExpress.XtraEditors.XtraForm
    {

        BalanceSheetBL objBL = new BalanceSheetBL();
        int inCurrenRowIndex = 0;
        int inCurentcolIndex = 0;
        string calculationMethod = string.Empty;
        decimal decPrintOrNot = 0;
        decimal decPrintOrNot1 = 0;

        public BalanceSheetGrd()
        {
            InitializeComponent();
        }

   

        private void btnFilters_Click(object sender, EventArgs e)
        {
            Reports.Accountbooks.Daybook frmdayBook = new Daybook();
            frmdayBook.ShowDialog();                       
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

        
        private void BalanceSheetGrd_Load(object sender, EventArgs e)
        {
            FillGrid();
        }
      
        public void FillGrid()
        {
            DataSet DsetBalanceSheet = new DataSet();
            CurrencyInfo InfoCurrency = new CurrencyInfo();
            DataTable dtbl = new DataTable();
            Font newFont = new Font(dgvReport.Font, FontStyle.Bold);
            int inDecimalPlaces = InfoCurrency.NoOfDecimalPlaces;

            DsetBalanceSheet = objBL.BalanceSheet(DateTime.Parse("01-01-2016"), DateTime.Parse("12-02-2017"));
            //------------------- Asset -------------------------------// 
            dtbl = DsetBalanceSheet.Tables[0];
            decimal dcTotalAsset = 0;
            if (dtbl.Rows.Count == 0)
            {
                dgvReport.Rows.Add();
                dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["dgvtxtAsset"].Value = "Current Assets";
                dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["Amount1"].Value = "0.00";
                dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["GroupId1"].Value = 0;
            }
            else
            {
                foreach (DataRow rw in dtbl.Rows)
                {
                    dgvReport.Rows.Add();
                    dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["dgvtxtAsset"].Value = rw["Name"].ToString();
                    dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["Amount1"].Value = rw["Balance"].ToString();
                    dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["GroupId1"].Value = rw["ID"].ToString();
                }

                dcTotalAsset = decimal.Parse(dtbl.Compute("Sum(Balance)", string.Empty).ToString());
            }
            //------------------------ Liability ---------------------//
            dtbl = new DataTable();
            dtbl = DsetBalanceSheet.Tables[1];
            int index = 0;
            decimal dcTotalLiability = 0;
            if (dtbl.Rows.Count == 0)
            {
                dgvReport.Rows.Add();
                dgvReport.Rows[index].Cells["dgvtxtLiability"].Value = "Current Liabilities";
                dgvReport.Rows[index].Cells["Amount2"].Value = "0.00";
                dgvReport.Rows[index].Cells["GroupId2"].Value = 0;
                dcTotalLiability = decimal.Parse("0.00");
            }
            else
            {
                foreach (DataRow rw in dtbl.Rows)
                {
                    if (index < dgvReport.Rows.Count)
                    {
                        dgvReport.Rows[index].Cells["dgvtxtLiability"].Value = rw["Name"].ToString();
                        dgvReport.Rows[index].Cells["Amount2"].Value = rw["Balance"].ToString();
                        dgvReport.Rows[index].Cells["GroupId2"].Value = rw["ID"].ToString();
                    }
                    else
                    {
                        dgvReport.Rows.Add();
                        dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["dgvtxtLiability"].Value = rw["Name"].ToString();
                        dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["Amount2"].Value = rw["Balance"].ToString();
                        dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["GroupId2"].Value = rw["ID"].ToString();
                    }
                    index++;
                }
                dcTotalLiability = decimal.Parse(dtbl.Compute("Sum(Balance)", string.Empty).ToString());
            }
            decimal dcClosingStock = objBL.StockValueGetOnDate(Convert.ToDateTime("01-01-2016"), calculationMethod, false, false);
            dcClosingStock = Math.Round(dcClosingStock, inDecimalPlaces);
            //---------------------Opening Stock---------------------------------------------------------------------------------------------------------------
            decimal dcOpeninggStock = objBL.StockValueGetOnDate(DateTime.Parse("01-01-2016"), calculationMethod, true, true);
            decimal dcProfit = 0;
            DataSet dsetProfitAndLoss = new DataSet();
            dsetProfitAndLoss = objBL.ProfitAndLossAnalysisUpToaDateForBalansheet(DateTime.Parse("01-01-2016"), DateTime.Parse("12-12-2016"));
            DataTable dtblProfit = new DataTable();
            dtblProfit = dsetProfitAndLoss.Tables[0];
            for (int i = 0; i < dsetProfitAndLoss.Tables.Count; ++i)
            {
                dtbl = dsetProfitAndLoss.Tables[i];
                decimal dcSum = 0;
                if (i == 0 || (i % 2) == 0)
                {
                    if (dtbl.Rows.Count > 0)
                    {
                        dcSum = decimal.Parse(dtbl.Compute("Sum(Debit)", string.Empty).ToString());
                        dcProfit = dcProfit - dcSum;
                    }
                }
                else
                {
                    if (dtbl.Rows.Count > 0)
                    {
                        dcSum = decimal.Parse(dtbl.Compute("Sum(Credit)", string.Empty).ToString());
                        dcProfit = dcProfit + dcSum;
                    }
                }
            }
            decimal decCurrentProfitLoss = 0;
            decCurrentProfitLoss = dcProfit + (dcClosingStock - dcOpeninggStock);
            decimal dcProfitOpening = 0;
            DataSet dsetProfitAndLossOpening = new DataSet();
            dsetProfitAndLossOpening =objBL.ProfitAndLossAnalysisUpToaDateForPreviousYears(DateTime.Parse("01-01-2016"));
            DataTable dtblProfitOpening = new DataTable();
            dtblProfitOpening = dsetProfitAndLossOpening.Tables[0];
            for (int i = 0; i < dsetProfitAndLossOpening.Tables.Count; ++i)
            {
                dtbl = dsetProfitAndLossOpening.Tables[i];
                decimal dcSum = 0;
                if (i == 0 || (i % 2) == 0)
                {
                    if (dtbl.Rows.Count > 0)
                    {
                        dcSum = decimal.Parse(dtbl.Compute("Sum(Debit)", string.Empty).ToString());
                        dcProfitOpening = dcProfitOpening - dcSum;
                    }
                }
                else
                {
                    if (dtbl.Rows.Count > 0)
                    {
                        dcSum = decimal.Parse(dtbl.Compute("Sum(Credit)", string.Empty).ToString());
                        dcProfitOpening = dcProfitOpening + dcSum;
                    }
                }
            }
            DataTable dtblProfitLedgerOpening = new DataTable();
            dtblProfitLedgerOpening = DsetBalanceSheet.Tables[3];
            decimal decProfitLedgerOpening = 0;
            foreach (DataRow dRow in dtblProfitLedgerOpening.Rows)
            {
                decProfitLedgerOpening += decimal.Parse(dRow["Balance"].ToString());
            }
            DataTable dtblProf = new DataTable();
            dtblProf = DsetBalanceSheet.Tables[2];
            decimal decProfitLedger = 0;
            if (dtblProf.Rows.Count > 0)
            {
                decProfitLedger = decimal.Parse(dtblProf.Compute("Sum(Balance)", string.Empty).ToString());
            }
            decimal decTotalProfitAndLoss = 0;
            if (dcProfitOpening >= 0)
            {
                decTotalProfitAndLoss = decProfitLedger;
            }
            else if (dcProfitOpening < 0)
            {
                decTotalProfitAndLoss = decProfitLedger;
            }
            index = 0;
            if (dcClosingStock >= 0)
            {
                //---------- Asset ----------//
                dgvReport.Rows.Add();
                dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["dgvtxtAsset"].Value = "Closing Stock";
                dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["Amount1"].Value = Math.Round(dcClosingStock, inDecimalPlaces);
                dcTotalAsset += dcClosingStock;
            }
            else
            {
                //--------- Liability ---------//
                dgvReport.Rows.Add();
                dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["dgvtxtLiability"].Value = "Closing Stock";
                dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["Amount2"].Value = -(Math.Round(dcClosingStock, inDecimalPlaces));
                dcTotalLiability += -dcClosingStock;
            }
            dgvReport.Rows.Add();
            decimal decOpeningOfProfitAndLoss = decProfitLedgerOpening + dcProfitOpening;
            decimal decTotalProfitAndLossOverAll = decTotalProfitAndLoss + decOpeningOfProfitAndLoss + decCurrentProfitLoss;
            if (decTotalProfitAndLossOverAll <= 0)
            {
                dgvReport.Rows.Add();
                dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["dgvtxtAsset"].Value = "----------------------------------------";
                dgvReport.Rows[dgvReport.Rows.Count - 1].DefaultCellStyle.Font = newFont;
                foreach (DataRow dRow in dtblProf.Rows)
                {
                    if (dRow["Name"].ToString() == "Profit And Loss Account")
                    {
                        dgvReport.Rows.Add();
                        dgvReport.Rows[dgvReport.Rows.Count - 1].DefaultCellStyle.Font = newFont;
                        dgvReport.Rows[dgvReport.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.DarkSlateGray;
                        dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["dgvtxtAsset"].Value = dRow["Name"].ToString();
                        if (decCurrentProfitLoss < 0)
                        {
                            decCurrentProfitLoss = decCurrentProfitLoss * -1;
                        }
                        dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["Amount1"].Value = Math.Round(decTotalProfitAndLoss + decCurrentProfitLoss, 2);
                        dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["GroupId1"].Value = dRow["ID"].ToString();
                    }
                }
                //-------------- Asset ---------------//
                dgvReport.Rows.Add();
                dgvReport.Rows[dgvReport.Rows.Count - 1].DefaultCellStyle.Font = newFont;
                dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["dgvtxtAsset"].Value = "Profit And Loss (Opening)";
                dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["Amount1"].Value = Math.Round(decTotalProfitAndLoss, 2);
                dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["Amount1"].Style.ForeColor = Color.DarkSlateGray;
                dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["dgvtxtAsset"].Style.ForeColor = Color.DarkSlateGray;
                //-------------- Asset ---------------//
                dgvReport.Rows.Add();
                dgvReport.Rows[dgvReport.Rows.Count - 1].DefaultCellStyle.Font = newFont;
                dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["dgvtxtAsset"].Value = "Current Period";
                dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["Amount1"].Value = Math.Round(decCurrentProfitLoss, 2);
                dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["Amount1"].Style.ForeColor = Color.DarkSlateGray;
                dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["dgvtxtAsset"].Style.ForeColor = Color.DarkSlateGray;
                dcTotalAsset = dcTotalAsset + (decCurrentProfitLoss + decTotalProfitAndLoss);
                dgvReport.Rows.Add();
                dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["dgvtxtAsset"].Value = "----------------------------------------";
                dgvReport.Rows[dgvReport.Rows.Count - 1].DefaultCellStyle.Font = newFont;
            }
            else if (decTotalProfitAndLossOverAll > 0)
            {
                dgvReport.Rows.Add();
                dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["dgvtxtLiability"].Value = "----------------------------------------";
                dgvReport.Rows[dgvReport.Rows.Count - 1].DefaultCellStyle.Font = newFont;
                foreach (DataRow dRow in dtblProf.Rows)
                {
                    if (dRow["Name"].ToString() == "Profit And Loss Account")
                    {
                        dgvReport.Rows.Add();
                        dgvReport.Rows[dgvReport.Rows.Count - 1].DefaultCellStyle.Font = newFont;
                        dgvReport.Rows[dgvReport.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.DarkSlateGray;
                        dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["dgvtxtLiability"].Value = dRow[1].ToString();
                        dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["Amount2"].Value = Math.Round(decTotalProfitAndLoss + decCurrentProfitLoss, 2);
                        dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["GroupId2"].Value = dRow[0].ToString();
                    }
                }
                //------------ Liability ------------//
                dgvReport.Rows.Add();
                dgvReport.Rows[dgvReport.Rows.Count - 1].DefaultCellStyle.Font = newFont;
                dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["dgvtxtLiability"].Value = "Profit And Loss (Opening)";
                dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["Amount2"].Value = Math.Round(decTotalProfitAndLoss, inDecimalPlaces);
                dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["Amount2"].Style.ForeColor = Color.DarkSlateGray;
                dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["dgvtxtLiability"].Style.ForeColor = Color.DarkSlateGray;
                dcTotalLiability += decOpeningOfProfitAndLoss;
                //------------ Liability ------------//
                dgvReport.Rows.Add();
                dgvReport.Rows[dgvReport.Rows.Count - 1].DefaultCellStyle.Font = newFont;
                dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["dgvtxtLiability"].Value = "Current Period";
                dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["Amount2"].Value = Math.Round(decCurrentProfitLoss, inDecimalPlaces);
                dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["Amount2"].Style.ForeColor = Color.DarkSlateGray;
                dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["dgvtxtLiability"].Style.ForeColor = Color.DarkSlateGray;
                dcTotalLiability = dcTotalLiability + (decCurrentProfitLoss + decTotalProfitAndLoss); //dcProfit;
                dgvReport.Rows.Add();
                dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["dgvtxtLiability"].Value = "----------------------------------------";
                dgvReport.Rows[dgvReport.Rows.Count - 1].DefaultCellStyle.Font = newFont;
            }
            dgvReport.Rows.Add();
            decimal dcDiffAsset = 0;
            decimal dcDiffLiability = 0;
            decimal dcTotalValue = dcTotalAsset;
            if (dcTotalAsset != dcTotalLiability)
            {
                if (dcTotalAsset > dcTotalLiability)
                {
                    //--------------- Liability exceeds so in asset side ----------------//
                    dgvReport.Rows.Add();
                    dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["dgvtxtLiability"].Value = "Difference";
                    dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["Amount2"].Value = Math.Round((dcTotalAsset - dcTotalLiability), inDecimalPlaces);
                    dgvReport.Rows[dgvReport.Rows.Count - 1].DefaultCellStyle.Font = newFont;
                    dgvReport.Rows[dgvReport.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.DarkRed;
                    dcDiffLiability = dcTotalAsset - dcTotalLiability;
                }
                else
                {
                    //--------------- Asset exceeds so in liability side ----------------//
                    dgvReport.Rows.Add();
                    dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["dgvtxtAsset"].Value = "Difference";
                    dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["Amount1"].Value = Math.Round((dcTotalLiability - dcTotalAsset), inDecimalPlaces); ;
                    dgvReport.Rows[dgvReport.Rows.Count - 1].DefaultCellStyle.Font = newFont;
                    dgvReport.Rows[dgvReport.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.DarkRed;
                    dcDiffAsset = dcTotalLiability - dcTotalAsset;
                }
            }
            dgvReport.Rows.Add();
            dgvReport.Rows.Add();
            dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["Amount1"].Value = "__________________________";
            dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["Amount2"].Value = "__________________________";
            dgvReport.Rows.Add();
            dgvReport.Rows[dgvReport.Rows.Count - 1].DefaultCellStyle.Font = newFont;
            dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["dgvtxtLiability"].Value = "Total";
            dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["dgvtxtAsset"].Value = "Total";
            dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["Amount1"].Value = Math.Round((dcTotalAsset + dcDiffAsset), inDecimalPlaces);
            dgvReport.Rows[dgvReport.Rows.Count - 1].Cells["Amount2"].Value = Math.Round((dcTotalLiability + dcDiffLiability), inDecimalPlaces);
            if (dgvReport.Columns.Count > 0)
            {
                dgvReport.Columns["Amount1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvReport.Columns["Amount2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            decPrintOrNot = dcTotalAsset + dcDiffAsset;
            decPrintOrNot1 = dcTotalLiability + dcDiffLiability;
            if (inCurrenRowIndex >= 0 && dgvReport.Rows.Count > 0 && inCurrenRowIndex < dgvReport.Rows.Count)
            {
                if (dgvReport.Rows[inCurrenRowIndex].Cells[inCurentcolIndex].Visible)
                {
                    dgvReport.CurrentCell = dgvReport.Rows[inCurrenRowIndex].Cells[inCurentcolIndex];
                }
                if (dgvReport.CurrentCell != null && dgvReport.CurrentCell.Visible)
                    dgvReport.CurrentCell.Selected = true;
            }
            inCurrenRowIndex = 0;
        }
                       
    }

}