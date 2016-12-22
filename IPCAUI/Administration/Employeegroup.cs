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
    public partial class Employeegroup : Form
    {
        EmployeeGroupBL objbl = new EmployeeGroupBL();
        public Employeegroup()
        {
            InitializeComponent();
        }

        private void ListEmployeegrp_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.EmployeegrpList frmList = new Administration.List.EmployeegrpList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
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
            //if (accObj.IsGroupExists(tbxGroupName.Text.Trim()))
            //{
            //    MessageBox.Show("Group Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
            //    // cbxUnderGrp.Focus();
            //    return;
            //}

            eSunSpeedDomain.EmployeeGroupModel objempmodel = new eSunSpeedDomain.EmployeeGroupModel();

            objempmodel.GroupName = tbxGroupName.Text;

            objempmodel.AliasName = tbxAliasname.Text;
            objempmodel.Primary = cbxPrimarygroup.SelectedItem.ToString();

            objempmodel.UnderGroup = cbxPrimarygroup.SelectedItem.ToString().Equals("Yes") ? "" : cbxUndergroup.SelectedItem.ToString();

            objempmodel.CreatedBy = "Admin";

            string message = string.Empty;

            bool isSuccess = objbl.SaveEmployeeGroup(objempmodel);

            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }
                

            //List<eSunSpeedDomain.AccountGroupModel> lstGroups = accObj.GetListofAccountsGroups();
            //dgvList.DataSource = lstGroups;

            //Dialogs.PopUPDialog d = new Dialogs.PopUPDialog("Saved Successfully!");
            //d.ShowDialog();
        }
    }
}
