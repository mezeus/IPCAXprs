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
    public partial class CompanyMenu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        XtraForm1 frm;
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
    }
}