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
    public partial class Materialcentergroup : Form
    {
        MaterialCentreGroupMaster MatObj = new MaterialCentreGroupMaster();
        MaterialCentreMasterBL objMatMasterBl = new MaterialCentreMasterBL();
        public static int MCGId = 0;
        public Materialcentergroup()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxGroupName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Group Name can not be blank!");
                return;
            }
            MaterialCentreGroupMasterModel objGroup = new MaterialCentreGroupMasterModel();

            objGroup.Group = tbxGroupName.Text.TrimEnd();
            objGroup.Alias = tbxAliasname.Text==null?string.Empty:tbxAliasname.Text;
            objGroup.PrimaryGroup = cbxPrimarygroup.SelectedItem.ToString() == "Y" ? true : false;
            if(cbxPrimarygroup.SelectedItem.ToString()=="N")
            {
                objGroup.UnderGroup = cbxUndergroup.SelectedItem.ToString();
            }
                      
            objGroup.CreatedBy = "Admin";

            bool isSuccess = MatObj.SaveMCG(objGroup);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                ClearControls();

            }
        }
        private void ListMaterialCengrp_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.MaterialcentergrpList frmList = new Administration.List.MaterialcentergrpList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
            FillMaterialGroupInfo();  
        }
        private void FillMaterialGroupInfo()
        {
            if(MCGId==0)
            {
                tbxGroupName.Focus();
                ClearControls();
                lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                return;
            }
            MaterialCentreGroupMasterModel objMaster = MatObj.GetAllMaterialGroupsById(MCGId);

            tbxGroupName.Text = objMaster.Group;
            tbxAliasname.Text = objMaster.Alias;
            cbxPrimarygroup.SelectedItem = Convert.ToString((objMaster.PrimaryGroup) ? "Y" : "N");
            cbxUndergroup.SelectedItem = objMaster.UnderGroup;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            tbxGroupName.Focus();

        }

        private void Materialcentergroup_Load(object sender, EventArgs e)
        {
            cbxPrimarygroup.SelectedIndex = 1;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
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

        private void tbxGroupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {              
                if (tbxGroupName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Group Name Can Not Be Blank!");
                    tbxGroupName.Focus();
                    return;
                }
                if (MatObj.IsMaterialGroupExists(tbxGroupName.Text.Trim()))
                {
                    MessageBox.Show("Group Name already Exists!");
                    tbxGroupName.Focus();
                    return;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MaterialCentreGroupMasterModel objGroup = new MaterialCentreGroupMasterModel();

            objGroup.Group = tbxGroupName.Text.TrimEnd();
            objGroup.Alias = tbxAliasname.Text == null ? string.Empty : tbxAliasname.Text;
            objGroup.PrimaryGroup = cbxPrimarygroup.SelectedItem.ToString() == "Y" ? true : false;
            if (cbxPrimarygroup.SelectedItem.ToString() == "N")
            {
                objGroup.UnderGroup = cbxUndergroup.SelectedItem.ToString();
            }

            objGroup.CreatedBy = "Admin";
            objGroup.MCG_ID = MCGId;

            bool isSuccess = MatObj.UpdateMCG(objGroup);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
                MCGId = 0;
                ClearControls();
                Administration.List.MaterialcentergrpList frmList = new Administration.List.MaterialcentergrpList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                FillMaterialGroupInfo();
            }
        }

        private void cbxPrimarygroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPrimarygroup.SelectedItem.ToString()=="N")
            {
                lblUndergroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                lblUndergroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            }
        }

        private void cbxUndergroup_Enter(object sender, EventArgs e)
        {
            cbxUndergroup.SelectedIndex = 0;
        }

        private void tbxGroupName_TextChanged(object sender, EventArgs e)
        {
            tbxAliasname.Text = tbxGroupName.Text;
        }
        public void ClearControls()
        {
            tbxGroupName.Text = string.Empty;
            tbxAliasname.Text = string.Empty;
            cbxPrimarygroup.SelectedIndex = 1;
            MCGId = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MaterialCentreMasterModel objmodel = objMatMasterBl.GetMaterialCenterByGroupname(tbxGroupName.Text.Trim());
            if (objmodel.GroupName != null)
            {
                MessageBox.Show("Can Not Delete Group Name Under Tag With Item Name.." + objmodel.GroupName);
                tbxGroupName.Focus();
            }
            if(objmodel.GroupName==null)
            {
                bool isDelete = MatObj.DeleteMaterialGroupById(MCGId);
                if (isDelete)
                {
                    MessageBox.Show("Delete Successfully!");
                    MCGId = 0;
                    ClearControls();
                    Administration.List.MaterialcentergrpList frmList = new Administration.List.MaterialcentergrpList();
                    frmList.StartPosition = FormStartPosition.CenterScreen;

                    frmList.ShowDialog();
                    FillMaterialGroupInfo();
                }
            }
           
        }

        private void btnNewEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ClearControls();
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }

        private void tbxGroupName_Leave(object sender, EventArgs e)
        {
            //if (MatObj.IsMaterialGroupExists(tbxGroupName.Text.Trim()))
            //{
            //    MessageBox.Show("Group Name already Exists!");
            //    tbxGroupName.Focus();
            //    return;
            //}
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
