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
        public static int TdsId = 0;
        public TDSCategory()
        {
            InitializeComponent();
        }

        private void ListTdscategory_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.TdscategoryList frmList = new Administration.List.TdscategoryList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;

            btnSave.Visible = false;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            tbxTdsName.Focus();

            FillAccountInfo();

        }

        private void FillAccountInfo()
        {
            TdsModel objTds = objtdsmodbl.GetListofTDSById(TdsId);

            tbxTdsName.Text = objTds.TdsCategoryName;
            tbxSelectcode.Text= objTds.Selectcode;
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

        private void TDSCategory_Load(object sender, EventArgs e)
        {
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            TdsModel objtds = new TdsModel();

            objtds.TdsCategoryName = tbxTdsName.Text.Trim();
            objtds.Selectcode = tbxSelectcode.Text.Trim();
            objtds.Tds_Id = TdsId;

            bool isSuccess = objtdsmodbl.UpdateTdsModel(objtds);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
            }
        }
    }
}
