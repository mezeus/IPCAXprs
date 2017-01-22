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
        CostCentreGroupBL objCgroupBl = new CostCentreGroupBL();
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
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                ClearControls();
                tbxName.Focus();
            }
        }

        private void ListCostcenter_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.CostcenterList frmList = new Administration.List.CostcenterList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
            if (costId != 0)
            {
                lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                tbxName.Focus();
                FillCostCenterInfo();
            }
        }

        private void FillCostCenterInfo()
        {
            CostCentreMasterModel objMaster = objccm.GetAllCostCentreMasterById(costId);
            if(costId==0)
            {
                tbxName.Focus();
                return;
            }

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
            cbxDrCr.SelectedIndex = 1;
        }
        private void Costcenter_Load(object sender, EventArgs e)
        {
            costId = 0;
            List<CostCentreGroupModel> lstCostGroups = objCgroupBl.GetAllCostCentreGroups();
            foreach(CostCentreGroupModel objmodel in lstCostGroups)
            {
                cbxPrimarygroup.Properties.Items.Add(objmodel.GroupName);
            }
            cbxDrCr.SelectedIndex = 1;
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
                ClearControls();
                Administration.List.CostcenterList frmList = new Administration.List.CostcenterList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                FillCostCenterInfo();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDelete = objccm.DeleteCostCenterMasterById(costId);
            if (isDelete)
            {
                MessageBox.Show("Delete Successfully!");
                ClearControls();
                Administration.List.CostcenterList frmList = new Administration.List.CostcenterList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                FillCostCenterInfo();
                //tbxName.Focus();
                //lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                //lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                //lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void cbxDrCr_Enter(object sender, EventArgs e)
        {

        }

        private void cbxPrimarygroup_Enter(object sender, EventArgs e)
        {
            cbxPrimarygroup.SelectedIndex = 0;
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            tbxAliasname.Text = tbxName.Text.Trim();
        }

        private void btnNewEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ClearControls();
            costId = 0;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            tbxName.Focus();
        }

        private void tbxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (tbxName.Text.Trim() == "")
                {
                    MessageBox.Show("Master Name Can Not Be Blank!");
                    tbxName.Focus();
                    return;
                }
                if(costId==0)
                {
                    if (objccm.IsCostMasterExists(tbxName.Text.Trim()))
                    {
                        MessageBox.Show("Master Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
                        tbxName.Focus();
                        return;
                    }
                } 
            }
        }
    }
}
