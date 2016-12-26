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
    public partial class Executivegroup : Form
    {
        ExecutivegroupBL objexebl = new ExecutivegroupBL();
        public Executivegroup()
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

            if (tbxName.Text.Equals(string.Empty))
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

            
           

            eSunSpeedDomain.ExecutiveModel objexe = new ExecutiveModel();

            objexe.GroupName = tbxName.Text;
            objexe.AliasName = tbxAliasname.Text;
            objexe.PrintName=tbxPrintname.Text;
            objexe.Handlescalltype = tbxhandlescalltype.Text;
            objexe.Area = cbxArea.SelectedItem.ToString();
            objexe.Address = tbxAddress.Text;
            objexe.Address1 = tbxAddress1.Text;
            objexe.Address2 = tbxAddress2.Text;
            objexe.Address3 = tbxAddress3.Text;
            objexe.Telephone = Convert.ToInt32(tbxTelnumber.Text.Trim());
            objexe.MobileNo= Convert.ToInt32(tbxMobileno.Text.Trim());
            objexe.Email= tbxEmail.Text;

            string message = string.Empty;

            bool isSuccess = objexebl.SaveExecutiveGroup(objexe);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }
           

        }

        private void ListExecutivemaster_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.ExecutivemasterList frmList = new Administration.List.ExecutivemasterList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
        }
    }
}