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
    public partial class Contactgroup : Form
    {
        ContactgroupBL objcont = new ContactgroupBL();
        public Contactgroup()
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

            //if (accObj.IsGroupExists(tbxGroupName.Text.Trim()))
            //{
            //    MessageBox.Show("Group Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
            //    cbxUnderGrp.Focus();
            //    return;
            //}

            eSunSpeedDomain.ContactModel objContGroup = new eSunSpeedDomain.ContactModel();

            objContGroup.GroupName = tbxGroupName.Text;

            objContGroup.AliasName = tbxAliasname.Text;



            objContGroup.Primary = cbxPrimarygroup.SelectedItem.ToString();

            objContGroup.UnderGroup = cbxUndergroup.SelectedItem.ToString();

            objContGroup.CreatedBy = "Admin";

            string message = string.Empty;

            bool isSuccess = objcont.SaveContactGroup(objContGroup);
            if(isSuccess)
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
