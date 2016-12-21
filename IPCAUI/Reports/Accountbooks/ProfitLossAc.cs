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
    public partial class ProfitLossAc : Form
    {
        string FilterOption = string.Empty;
        string Category = string.Empty;

        public ProfitLossAc(string Option,string category)
        {
            InitializeComponent();
            this.FilterOption = Option;
            this.Category = category;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProfitLossAc_Load(object sender, EventArgs e)
        {
            ShowHideFields();
        }

        private void ShowHideFields()
        {
            if (Category.Equals("Horizontal"))
            {
                PLShowsecondlevel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                PLShowGrps.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                PLSpecifyRatio.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                PLSpecifyScaleFactor.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                PLCurString.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;                
            }
            else if (Category.Equals("Vertical"))
            {
                PLShowPrevYear.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                PLShowAccountDetails.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                PLSpecifyRatio.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                PLSpecifyScaleFactor.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                PLCurString.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;                
            }
            else if(Category.Equals("Summary"))
            {
                PLShowSummary.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }

            if (FilterOption.Equals("Month"))
            {
                PLStartMonth.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                PLEndMonth.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;                
            }
            else if (FilterOption.Equals("Date"))
            {
                PLStartingDt.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                PLEndingDt.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;                
            }
            
        }
    }
}
