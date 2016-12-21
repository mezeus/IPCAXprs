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
    public partial class ReceiptRegister : DevExpress.XtraEditors.XtraForm
    {
        public ReceiptRegister()
        {
            InitializeComponent();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

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
            Reports.Accountbooks.RecepitRegister frmreceipitregister = new RecepitRegister();
            frmreceipitregister.ShowDialog();
             //frmdayBook.ShowDialog();
            //frmdayBook(this);                  
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void repositoryItemTextEdit1_Click(object sender, EventArgs e)
        {

        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

            string selectedNode = (sender as TreeList).FocusedNode.GetValue(0).ToString();
            switch (selectedNode)
            {
                case "Daily Balances":
                    break;
                case "Daily Summary":
                    break;
                case "Monthly Summary":
                    Reports.AccountSummary.DailySummary frmDaily = new AccountSummary.DailySummary();
                    frmDaily.ShowDialog();             
                    break;
                case "Account-Wise":
                    break;
                case "Merged Accounts":
                    break;
                case "Single Column":
                    break;
                case "Multiple Column":
                    break;
                case "Bank Book(As per Clr.Date)":
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
    }
}