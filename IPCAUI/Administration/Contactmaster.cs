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
    public partial class Contactmaster : Form
    {
        ContactmasterBL objconmaster = new ContactmasterBL();

        public Contactmaster()
        {
            InitializeComponent();
        }

        private void tbxQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListContactmast_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.ContactmasterList frmList = new Administration.List.ContactmasterList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
        }

        private void tbxSave_Click(object sender, EventArgs e)
        {
            //TODO: 1. Check whether the group name exists or not
            //2. if exist then do not allow to save with the same group name
            //3. Prompt user to change the group name as it already exists

            if (tbxName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Group Name can not be blank!");
                return;
            }

            //if (objconmtr.IsGroupExists(tbxGName.Text.Trim()))
            //{ 
            //    MessageBox.Show("Group Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
            //    cbxUnderGrp.Focus();
            //    return;
            eSunSpeedDomain.ContactmasterModel objconmas = new eSunSpeedDomain.ContactmasterModel();
            objconmas.Name = tbxName.Text.Trim();
            objconmas.AliasName = tbxAlias.Text.Trim();
            objconmas.PrintName = tbxPrintname.Text.Trim();
           objconmas.Connectwithledger = cbxConnectledger.SelectedItem.ToString() == "Y" ? true : false;
            objconmas.Organisation = tbxOrgination.Text.Trim();
            objconmas.MobileNo = tbxMobileno.Text.Trim();
            objconmas.Email = tbxEmail.Text.Trim();
            objconmas.TypeofTrade = cbxTrade.SelectedItem.ToString();
            objconmas.Group = cbxGroup.Text.Trim();
            objconmas.Area = tbxArea.Text.Trim();
            objconmas.Department = tbxDepartment.Text.Trim();
            objconmas.SpecifyDateofBirth = cbxSpecifyDateofBirth.SelectedItem.ToString() == "Y" ? true : false; ;
            objconmas.SpecifyDateofAnniversary = cbxDateAnnversary.SelectedItem.ToString() == "Y" ? true : false;
            objconmas.Address = tbxAddress.Text.Trim();
            objconmas.Address1 = tbxAddress1.Text.Trim();
            objconmas.Address2 = tbxAddress2.Text.Trim();
            objconmas.Address3 = tbxAddress3.Text.Trim();
            objconmas.PhoneNo = tbxPhoneNo.Text.Trim();
            objconmas.FaxNo = tbxFaxNo.Text.Trim();



            string message = string.Empty;


            bool isSuccess = objconmaster.Savecontactmaster(objconmas);
            {
                if (isSuccess)
                    MessageBox.Show("Saved Successfully!");
            }

        }

        private void navBarControl1_Click(object sender, EventArgs e)
        {

        }

        private void tbxName_EditValueChanged(object sender, EventArgs e)
        {


        }
    }
}
