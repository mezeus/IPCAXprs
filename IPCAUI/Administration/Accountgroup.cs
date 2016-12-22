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
        AccountMaster accObj = new AccountMaster();
        public Accountgroup()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
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

            if (accObj.IsGroupExists(tbxGroupName.Text.Trim()))
            {
                MessageBox.Show("Group Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
               // cbxUnderGrp.Focus();
                return;
            }

            eSunSpeedDomain.AccountGroupModel objAccGroup = new eSunSpeedDomain.AccountGroupModel();

            objAccGroup.GroupName = tbxGroupName.Text;

            objAccGroup.AliasName = tbxAliasname.Text;
            objAccGroup.Primary = cbxPrimarygroup.SelectedItem.ToString();

            objAccGroup.UnderGroup = cbxPrimarygroup.SelectedItem.ToString().Equals("Yes") ? "" : cbxUndergroup.SelectedItem.ToString();

            objAccGroup.CreatedBy = "Admin";

            string message = string.Empty;

            bool isSuccess = accObj.SaveAccountGroup(objAccGroup);

            if (isSuccess)
                MessageBox.Show("Saved Successfully!");

            //List<eSunSpeedDomain.AccountGroupModel> lstGroups = accObj.GetListofAccountsGroups();
            //dgvList.DataSource = lstGroups;

            //Dialogs.PopUPDialog d = new Dialogs.PopUPDialog("Saved Successfully!");
            //d.ShowDialog();
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
                if (this.ActiveControl != null)
                {
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);

                }
                if (accObj.IsGroupExists(tbxGroupName.Text.Trim()))
                {
                    MessageBox.Show("Group Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
                    tbxGroupName.Focus();
                    return;
                }
                e.Handled = true; // Mark the event as handled
            }
        }

        private void cbxPrimarygroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPrimarygroup.SelectedItem.ToString().Equals("Y"))
            {
                
            }

        }

        private void ListAccountgroup_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.AccountgroupList frmList = new Administration.List.AccountgroupList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
        }

        private void Accountgroup_Load(object sender, EventArgs e)
        {
            cbxPrimarygroup.SelectedIndex = 0;
            cbxUndergroup.SelectedIndex = 0;
            cbxNaturegroup.SelectedIndex = 0;
        }
    }
}
