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
    
    public partial class TDSCategory : Form
    {
        TdsModelBL objtdsmodbl = new TdsModelBL();
        public TDSCategory()
        {
            InitializeComponent();
        }

        private void ListTdscategory_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.TdscategoryList frmList = new Administration.List.TdscategoryList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            TdsModel objtds = new TdsModel();

            objtds.TdsCategoryName = tbxTdsName.Text.Trim();
            objtds.Selectcode = tbxSelectcode.Text.Trim();


            bool isSuccess = objtdsmodbl.SaveTdsModel(objtds);
                if (isSuccess)
            {
               MessageBox.Show("Saved Successfully!");
            }
           
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            TdsModel objtds = new TdsModel();

            objtds.TdsCategoryName = tbxTdsName.Text.Trim();
            objtds.Selectcode = tbxSelectcode.Text.Trim();


            bool isSuccess = objtdsmodbl.SaveTdsModel(objtds);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }
        }
    }
}
