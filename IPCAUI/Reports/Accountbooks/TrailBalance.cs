using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPCAUI.Reports.Accountbooks
{
    public partial class TrailBalance : Form
    {
        string FilterOption = string.Empty;
        string Category = string.Empty;

        public TrailBalance(string Option,string category)
        {
            InitializeComponent();
            this.FilterOption = Option;
            this.Category = category;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void ShowHideFields()
        {
            if (FilterOption.Equals("AllAccounts") && Category.Equals("Level1"))
            {
                ReportDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                ShowAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                ShowZeroBalanceAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                ShowParentGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                                           
            }
            else if (FilterOption.Equals("GroupofAccounts") && Category.Equals("Level1"))
            {
                ShowGroupName.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                ReportDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                ShowAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                ShowZeroBalanceAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                ShowParentGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
           else if (FilterOption.Equals("AllAccounts") && Category.Equals("Level2"))
            {
                StartingDt.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                EndingDt.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                ShowAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                MastertobePicked.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                SplitCrDrOpeningclosingBal.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                ShowParentGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            }
            else if (FilterOption.Equals("GroupofAccounts") && Category.Equals("Level2"))
            {
                ShowGroupName.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                StartingDt.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                EndingDt.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                ShowAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                MastertobePicked.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                SplitCrDrOpeningclosingBal.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                ShowParentGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else if (FilterOption.Equals("MonthEnd") && Category.Equals("Level4"))
            {
                EndingDt.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                Showzerobalancegroups.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                ShowSubGroupBalances.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else if (FilterOption.Equals("AsonDate") && Category.Equals("Level4"))
            {
                EndingDt.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                Showzerobalancegroups.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                ShowSubGroupBalances.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }           

        }
        
        private void TrailBalance_Load(object sender, EventArgs e)
        {
            ShowHideFields();
        }
    }
}
