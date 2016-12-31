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
    public partial class Employeegroup : Form
    {
        EmployeeGroupBL objbl = new EmployeeGroupBL();
        public static int Empid = 0;
        public Employeegroup()
        {
            InitializeComponent();
        }

        private void ListEmployeegrp_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.EmployeegrpList frmList = new Administration.List.EmployeegrpList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;

            tbxGroupName.Focus();

            FillAccountInfo();
        }

        private void FillAccountInfo()
        {
           EmployeeGroupModel EmployeeGroup = objbl.GetListofEmployeeGroupsById(Empid);

           tbxGroupName.Text= EmployeeGroup.GroupName;
           tbxAliasname.Text = EmployeeGroup.AliasName;
           cbxPrimarygroup.SelectedItem =Convert.ToString((EmployeeGroup.Primary)?"Y":"N");
           cbxUndergroup.SelectedItem= EmployeeGroup.UnderGroup;
            cbxNaturegroup.SelectedItem = EmployeeGroup.Primary;
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
            objempmodel.Primary = cbxPrimarygroup.SelectedItem.ToString() == "Y" ? true : false;
            objempmodel.UnderGroup = cbxUndergroup.SelectedItem.ToString();
            objempmodel.NatureGroup = cbxNaturegroup.SelectedItem.ToString();

            objempmodel.CreatedBy = "Admin";

            string message = string.Empty;

            bool isSuccess = objbl.SaveEmployeeGroup(objempmodel);

            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }


        }

        private void Employeegroup_Load(object sender, EventArgs e)
        {
            cbxNaturegroup.SelectedIndex = 0;
            cbxPrimarygroup.SelectedIndex = 1;
            cbxUndergroup.SelectedIndex = 0;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
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
            objempmodel.Primary = cbxPrimarygroup.SelectedItem.ToString() == "Y" ? true : false;
            objempmodel.UnderGroup = cbxUndergroup.SelectedItem.ToString();
            objempmodel.NatureGroup = cbxNaturegroup.SelectedItem.ToString();
            objempmodel.GroupId = Empid;

            objempmodel.CreatedBy = "Admin";

            string message = string.Empty;

            bool isSuccess = objbl.UpdateEmployeeGroup(objempmodel);

            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
            }
        }

        private void btnNew_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           
        }

        private void btnNewEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            tbxGroupName.Text = string.Empty;
            tbxAliasname.Text = string.Empty;
            cbxPrimarygroup.SelectedIndex = 1;
            cbxNaturegroup.SelectedItem = "";
            cbxUndergroup.SelectedItem = "";
        }

        private void tbxGroupName_TextChanged(object sender, EventArgs e)
        {
            tbxAliasname.Text = tbxGroupName.Text.Trim();
        }
    }
}
