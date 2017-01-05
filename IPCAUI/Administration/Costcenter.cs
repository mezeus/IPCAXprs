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
    public partial class Costcenter : Form
    {
        CostCentreMasterBL objccm = new CostCentreMasterBL();
        public static int costId = 0;
        public Costcenter()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void navBarList_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // Administration.Accountgroup frm;
            //frm = new Administration.Accountgroup(); //generate new instance 
            //frm.Owner = this;
            //frm.TopLevel = false;

            //sptCtrlMastermenu.Panel2.Controls.Add(frm);
            //frm.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Name can not be blank!");
                return;
            }

            CostCentreMasterModel objModel = new CostCentreMasterModel();

            objModel.Name = tbxName.Text.Trim();
            objModel.Alias = tbxAliasname.Text.Trim();
            objModel.Group = cbxPrimarygroup.SelectedItem.ToString();
            objModel.opBal = Convert.ToDecimal(tbxOpbal.Text.Trim());
            objModel.DrCr = cbxDrCr.SelectedItem.ToString();
            objModel.CreatedBy = "Admin";

            bool isSuccess = objccm.SaveCCM(objModel);
            if(isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }
        }

        private void ListCostcenter_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.CostcenterList frmList = new Administration.List.CostcenterList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            tbxName.Focus();

            FillCostCenterInfo();
        }

        private void FillCostCenterInfo()
        {
            CostCentreMasterModel objMaster = objccm.GetAllCostCentreMasterById(costId);

            //lblCC.Text = row.Cells["CCM_ID"].Value != null ? row.Cells["CCM_ID"].Value.ToString() : string.Empty;
            tbxName.Text = objMaster.Name;
            tbxAliasname.Text = objMaster.Alias;
            cbxPrimarygroup.SelectedItem = objMaster.Group;
            tbxOpbal.Text = Convert.ToString(objMaster.opBal);
            cbxDrCr.SelectedItem = objMaster.DrCr;

        }
        public void ClearControls()
        {
            tbxName.Text = string.Empty;
            tbxAliasname.Text = string.Empty;
            tbxOpbal.Text = "0.00";
        }
        private void Costcenter_Load(object sender, EventArgs e)
        {
            cbxDrCr.SelectedIndex = 0;
            cbxPrimarygroup.SelectedIndex = 0;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {        
            CostCentreMasterModel objModel = new CostCentreMasterModel();

            objModel.Name = tbxName.Text.Trim();
            objModel.Alias = tbxAliasname.Text.Trim();
            objModel.Group = cbxPrimarygroup.SelectedItem.ToString();
            objModel.opBal = Convert.ToDecimal(tbxOpbal.Text.Trim());
            objModel.DrCr = cbxDrCr.SelectedItem.ToString();
            objModel.ModifiedBy = "Admin";
            objModel.CCM_ID = costId;

            bool isSuccess = objccm.UpdateCCM(objModel);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //bool isDelete = objccm.DeletCostCentre(costId);
            //if (isDelete)
            //{
            //    MessageBox.Show("Delete Successfully!");
            //    ClearControls();
            //    costId = 0;
            //}
        }
    }
}
