﻿using System;
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
            if(isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                tbxGroupName.Text = string.Empty;
                tbxAliasname.Text = string.Empty;
                cbxPrimarygroup.SelectedIndex = 1;
            }
            //List<MaterialCentreGroupMasterModel> lstGroups = MatObj.GetAllMaterialGroups();
            //dgvList.DataSource = lstGroups;
            //Dialogs.PopUPDialog d = new Dialogs.PopUPDialog("Saved Successfully!");
            //d.ShowDialog();
            //btnSave.Visible = true;
        }

        private void ListMaterialCengrp_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.MaterialcentergrpList frmList = new Administration.List.MaterialcentergrpList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();

            btnSave.Visible = false;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;

            FillAccountInfo();
        }
        private void FillAccountInfo()
        {
            MaterialCentreGroupMasterModel objMaster = MatObj.GetAllMaterialGroupsById(MCGId);

            tbxGroupName.Text = objMaster.Group;
            tbxAliasname.Text = objMaster.Alias;
            cbxPrimarygroup.SelectedItem = Convert.ToString((objMaster.PrimaryGroup) ? "Y" : "N");
            cbxUndergroup.SelectedItem = objMaster.UnderGroup;

        }

        private void Materialcentergroup_Load(object sender, EventArgs e)
        {
            cbxPrimarygroup.SelectedIndex = 1;
            
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
                //if (accObj.IsGroupExists(tbxGroupName.Text.Trim()))
                //{
                //    MessageBox.Show("Group Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
                //    tbxGroupName.Focus();
                //    return;
                //}
                if (tbxGroupName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Group Name Can Not Be Blank!");
                    this.ActiveControl = tbxGroupName;
                    return;
                    

                }
                //e.Handled = true; // Mark the event as handled
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
                tbxGroupName.Text = string.Empty;
                tbxAliasname.Text = string.Empty;
                cbxPrimarygroup.SelectedIndex = 1;
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
    }
}
