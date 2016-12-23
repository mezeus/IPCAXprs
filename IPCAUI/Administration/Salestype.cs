using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eSunSpeed.BusinessLogic;
using eSunSpeedDomain;

namespace IPCAUI.Administration
{
    public partial class Salestype : DevExpress.XtraEditors.XtraForm
    {
        SaleTypeModel objstypemod = new SaleTypeModel();
       
        public Salestype()
        {
            InitializeComponent();
        }

        private void ListSaletype_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.SalestypeList frmList = new Administration.List.SalestypeList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
        }

      
        private void btnsave_ClientSizeChanged(object sender, EventArgs e)
        {
            SaleType objstype = new SaleType();

          objstypemod.SalesType= tbxsaletype.Text.Trim(); 
            
            


            bool isSuccess =objstype.SaveStype(objstypemod);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }
        }

        
    }
}
