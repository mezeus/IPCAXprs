using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using eSunSpeedDomain;
using eSunSpeed.BusinessLogic;

namespace IPCAUI.Administration
{
    public partial class Accountgroup : Form
    {
        AccountMasterBL objaccbl= new AccountMasterBL();
        public static int groupId = 0;

        public Accountgroup()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void CallFromAccountGroupList(List.AccountgroupList objGrpList,int groupid)
        {
            //this.groupId = groupid;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //TODO: 1. Check whether the group name exists or not
            //2. if exist then do not allow to save with the same group name
            //3. Prompt user to change the group name as it already exists

            if (tbxGroupName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Group Name can not be blank!");
                return;
            }

            //if (accobj.IsGroupExist(tbxGroupName.Text.Trim()))
            //{
            //    MessageBox.Show("Group Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
            //   // cbxUnderGrp.Focus();
            //    return;
            //}

            eSunSpeedDomain.AccountGroupModel objAccGroup = new eSunSpeedDomain.AccountGroupModel();

            objAccGroup.GroupName = tbxGroupName.Text;

            objAccGroup.AliasName = tbxAliasname.Text;
           
            objAccGroup.Primary = cbxPrimarygroup.SelectedItem.ToString();

            objAccGroup.UnderGroup = cbxUndergroup.SelectedItem.ToString();
            objAccGroup.NatureGroup = cbxNaturegroup.SelectedItem.ToString();
            objAccGroup.IsAffectGrossProfit = chkGrossProfit.Checked ? true : false;

            objAccGroup.CreatedBy = "Admin";

            string message = string.Empty;

            bool isSuccess = objaccbl.SaveAccountGroup(objAccGroup);

            if (isSuccess)
                MessageBox.Show("Saved Successfully!");           
        }

        private void tbxGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void tbxGroupName_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void tbxGroupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (tbxGroupName.Text.Trim()=="")
                {
                    MessageBox.Show("Group Name Can Not Be Blank!");
                    tbxGroupName.Focus();
                    return;
                }
                if (objaccbl.IsGroupExists(tbxGroupName.Text.Trim()))
                {
                    MessageBox.Show("Group Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
                    tbxGroupName.Focus();
                    return;
                }

                if (this.ActiveControl != null)
                {
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);

                }
                e.Handled = true; // Mark the event as handled
            }
        }

        private void cbxPrimarygroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPrimarygroup.SelectedItem.ToString().Equals("N"))
            {
                
            }
        }

        private void ListAccountgroup_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.AccountgroupList frmList = new Administration.List.AccountgroupList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();

            layoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            btnSave.Visible = false;
            btnUpdateCtrl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            tbxGroupName.Focus();
            tbxGroupName.ReadOnly = true;

            FillAccountInfo();

        }

        private void FillAccountInfo()
        {
            AccountGroupModel objMaster = objaccbl.GetAccountGroupByGroupId(groupId);

            tbxGroupName.Text = objMaster.GroupName;
            tbxAliasname.Text = objMaster.AliasName;    
            cbxPrimarygroup.SelectedItem = objMaster.Primary == "True" ? "Yes" : "No";
            cbxUndergroup.SelectedItem = objMaster.UnderGroup;
            cbxNaturegroup.SelectedItem = objMaster.NatureGroup;

            chkGrossProfit.Checked = objMaster.IsAffectGrossProfit ? true : false;


        }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (tbxGroupName.Text.Equals(string.Empty))
        {
            MessageBox.Show("Group Name can not be blank!");
            return;
        }

        if (objaccbl.IsGroupExists(tbxGroupName.Text.Trim()))
        {
            MessageBox.Show("Group Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
            // cbxUnderGrp.Focus();
            return;
        }

        eSunSpeedDomain.AccountGroupModel objAccGroup = new eSunSpeedDomain.AccountGroupModel();

        objAccGroup.GroupName = tbxGroupName.Text;

        objAccGroup.AliasName = tbxAliasname.Text;
        objAccGroup.Primary = cbxPrimarygroup.SelectedItem.ToString();

        objAccGroup.UnderGroup = cbxUndergroup.SelectedItem.ToString();
        objAccGroup.NatureGroup = cbxNaturegroup.SelectedItem.ToString();
        objAccGroup.IsAffectGrossProfit = chkGrossProfit.Checked ? true : false;

        objAccGroup.CreatedBy = "Admin";

        objAccGroup.GroupId = groupId;

        string message = string.Empty;

        bool isSuccess = objaccbl.UpdateAccountGroup(objAccGroup);

        if (isSuccess)
            MessageBox.Show("Updated Successfully!");

    }

        private void Accountgroup_Load(object sender, EventArgs e)
        {
            cbxPrimarygroup.SelectedIndex = 1;
        }
    }
}
