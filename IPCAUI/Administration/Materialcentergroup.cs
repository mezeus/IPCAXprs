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
        public Materialcentergroup()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MaterialCentreGroupMasterModel objGroup = new MaterialCentreGroupMasterModel();

            objGroup.Group = tbxGroupName.Text.TrimEnd();
            objGroup.Alias = tbxAliasname.Text.Trim();
            objGroup.PrimaryGroup = cbxPrimarygroup.SelectedItem.ToString() == "Y" ? true : false;
            objGroup.UnderGroup = cbxUndergroup.SelectedItem.ToString();
            objGroup.CreatedBy = "Admin";

            bool isSuccess = MatObj.SaveMCG(objGroup);
            if(isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
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
        }

        private void Materialcentergroup_Load(object sender, EventArgs e)
        {
            cbxPrimarygroup.SelectedIndex = 0;
            cbxUndergroup.SelectedIndex = 0;
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
    }
}
