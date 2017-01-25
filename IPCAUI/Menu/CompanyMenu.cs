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
using DevExpress.XtraBars.Ribbon;

namespace IPCAUI.Menu
{
    public partial class CompanyMenu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        XtraForm1 frm;
        public static CompanyMenu MDIObj;
        private int childFormNumber = 0;
        public static string DBConnectionType;
        public static bool isEstimateDB = false;
        public static string strEstimateCompanyPath = string.Empty;
        public static bool demoProject = false;
        public static string strVouchertype;

        public CompanyMenu(XtraForm1 frm)
        {
            InitializeComponent();
            this.frm = frm;                   
        }             

      
        private void btnCreateComp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Company.NewCompany frm = new Company.NewCompany();

            frm.Owner = this;
            frm.TopLevel = false;
            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void CompanyMenu_Click(object sender, EventArgs e)
        {
            
        }

        private void CompanyMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm.Visible = true;
        }

        private void CompanyMenu_Load(object sender, EventArgs e)
        {
            Company.NewCompany frm = new Company.NewCompany();

            frm.Owner = this;
            frm.TopLevel = false;
            splitContainerControl1.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void rbCtrlCompany_Click(object sender, EventArgs e)
        {
            string selectedPage = (sender as RibbonControl).SelectedPage.Name.ToString();

            switch (selectedPage)
            {
                case "CreateCompany":
                    Company.NewCompany frm = new Company.NewCompany();

                    frm.Owner = this;
                    frm.TopLevel = false;
                    splitContainerControl1.Panel2.Controls.Add(frm);
                    frm.Show();
                    break;
                default:
                    break;
            }
        }
    }
}