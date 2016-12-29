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
    public partial class Author : Form
    {
        AuthorMaster objaut = new AuthorMaster();
        public static int AuthorId = 0;
        public Author()
        {
            InitializeComponent();
        }

        private void tbxQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AuthorList_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.AuthorList frmList = new Administration.List.AuthorList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();

            btnSave.Visible = false;
            lblupdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            FillAccountInfo();
        }

        private void FillAccountInfo()
        {
            AuthorModel objAuthor = objaut.GetAllAuthorsById(AuthorId);

            tbxName.Text = objAuthor.Name;
            tbxAlias.Text = objAuthor.Alias;
            tbxPrintname.Text = objAuthor.PrintName;
            cbxContactwithAccount.SelectedItem = objAuthor.ConnectAcc;
            tbxAddress.Text = objAuthor.Address;
            cbxState.SelectedItem = objAuthor.State;
            tbxTelnumber.Text = objAuthor.Telephone;
            tbxMobileno.Text = objAuthor.MobileNo;
            tbxEmail.Text = objAuthor.Email;
        }

        private void tbxSave_Click(object sender, EventArgs e)
        {
            //if (accObj.IsGroupExists(tbxGroupName.Text.Trim()))
            //{
            //    MessageBox.Show("Group Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
            //    cbxUnderGrp.Focus();
            //    return;
            //}

            AuthorModel objModel = new AuthorModel();

            if (tbxName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Author Name can not be blank!");
                return;
            }

            objModel.Name = tbxName.Text.Trim();
            objModel.Alias = tbxAlias.Text.Trim();
            objModel.PrintName = tbxPrintname.Text.Trim();
            objModel.ConnectAcc = cbxContactwithAccount.SelectedItem.ToString() == "Y" ? true : false;

            objModel.Address = tbxAddress.Text.Trim();
            //objModel.Street = tbxStreet.Text.Trim();
            //objModel.PinCode = tbxPincode.Text.Trim();

            //CityModel objCity = (CityModel)cbxCity.SelectedItem;
            //objModel.City = objCity.City_Name;
            objModel.Street = cbxState.SelectedItem.ToString();
            //StateModel objState = (StateModel)cbxState.SelectedItem;
            //objModel.State = objState.State_Name;
            //objModel.Country = cbxCountry.SelectedItem.ToString();
            objModel.Telephone = tbxTelnumber.Text.Trim();
            objModel.MobileNo = tbxMobileno.Text.Trim();
            
            objModel.Email = tbxEmail.Text.Trim();
            objModel.State = cbxState.SelectedItem.ToString();

            objModel.CreatedBy = "Admin";

            bool isSuccess = objaut.SaveAuthorMaster(objModel);
            {
                MessageBox.Show("Saved Successfully!");
            }
            //List<AuthorModel> lstAuthors = accObj.GetAllAuthors();
            //dgvList.DataSource = lstAuthors;

            //Dialogs.PopUPDialog d = new Dialogs.PopUPDialog("Saved Successfully!");
            //d.ShowDialog();
        }

        private void Author_Load(object sender, EventArgs e)
        {
            cbxContactwithAccount.SelectedIndex = 0;
            cbxState.SelectedIndex = 0;
        }

        private void tbxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                //if (accObj.IsGroupExists(tbxGroupName.Text.Trim()))
                //{
                //    MessageBox.Show("Group Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
                //    tbxGroupName.Focus();
                //    return;
                //}
                if (this.ActiveControl == null)
                {
                    MessageBox.Show("Author Name Can Not Be Blank!");
                    return;
                    this.ActiveControl = tbxName;

                }
                //e.Handled = true; // Mark the event as handled
            }
        }

        private void tbxName_Leave(object sender, EventArgs e)
        {
            //if (tbxName.Text.Equals(string.Empty))
            //{
            //    MessageBox.Show("Author Name can not be blank!");
            //    tbxName.Focus();
            //    return;
            //}
        }

        private void tbxName_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            AuthorModel objModel = new AuthorModel();

            if (tbxName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Author Name can not be blank!");
                return;
            }
            objModel.Name = tbxName.Text.Trim();
            objModel.Alias = tbxAlias.Text.Trim();
            objModel.PrintName = tbxPrintname.Text.Trim();
            objModel.ConnectAcc = cbxContactwithAccount.SelectedItem.ToString() == "Y" ? true : false;

            objModel.Address = tbxAddress.Text.Trim();
            //objModel.Street = tbxStreet.Text.Trim();
            //objModel.PinCode = tbxPincode.Text.Trim();

            //CityModel objCity = (CityModel)cbxCity.SelectedItem;
            //objModel.City = objCity.City_Name;
            objModel.Street = cbxState.SelectedItem.ToString();
            //StateModel objState = (StateModel)cbxState.SelectedItem;
            //objModel.State = objState.State_Name;
            //objModel.Country = cbxCountry.SelectedItem.ToString();
            objModel.Telephone = tbxTelnumber.Text.Trim();
            objModel.MobileNo = tbxMobileno.Text.Trim();

            objModel.Email = tbxEmail.Text.Trim();
            objModel.State = cbxState.SelectedItem.ToString();
            objModel.Author_Id = AuthorId;

            objModel.CreatedBy = "Admin";

            bool isSuccess = objaut.UpdateAuthorMaster(objModel);
            {
                MessageBox.Show("Update Successfully!");
            }
        }
    }
}
