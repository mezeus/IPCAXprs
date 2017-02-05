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
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void AuthorList_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.AuthorList frmList = new Administration.List.AuthorList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
            FillAuthorInfo();
            
        }

        private void FillAuthorInfo()
        {
            if(AuthorId==0)
            {
                tbxName.Focus();
                lblupdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                ClearControls();
                return;
            }
            AuthorModel objAuthor = objaut.GetAllAuthorsById(AuthorId);

            tbxName.Text = objAuthor.Name;
            tbxAlias.Text = objAuthor.Alias;
            tbxPrintname.Text = objAuthor.PrintName;
            cbxContactwithAccount.SelectedItem = (objAuthor.ConnectAcc) ? "Y" : "N";
            tbxAddress.Text = objAuthor.Address;
            tbxAddress1.Text = objAuthor.Address1;
            tbxAddress2.Text = objAuthor.Address2;
            tbxAddress3.Text = objAuthor.Address3;
            cbxState.SelectedItem = objAuthor.State;
            tbxTelnumber.Text = objAuthor.Telephone.ToString();
            tbxMobileno.Text = objAuthor.MobileNo.ToString();
            tbxEmail.Text = objAuthor.Email;
            lblupdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            tbxName.Focus();
        }

        private void Author_Load(object sender, EventArgs e)
        {
            tbxName.Focus();
            AuthorId = 0;
            cbxContactwithAccount.SelectedIndex = 1;
            cbxState.SelectedIndex = 0;
            lblupdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;

        }

        private void tbxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (tbxName.Text.Trim()==string.Empty)
                {
                    MessageBox.Show("Author Name Can Not Be Blank!");
                    tbxName.Focus();
                    return;
                }
                if(AuthorId==0)
                {
                    if (objaut.IsAuthorMasterExists(tbxName.Text.Trim()))
                    {
                        MessageBox.Show("Author Name already Exists!");
                        tbxName.Focus();
                        return;
                    }
                }
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
            objModel.Alias = tbxAlias.Text.Trim() == null ? string.Empty : tbxAlias.Text.Trim();
            objModel.PrintName = tbxPrintname.Text.Trim() == null ? string.Empty : tbxPrintname.Text.Trim();
            objModel.ConnectAcc = cbxContactwithAccount.SelectedItem.ToString() == "Y" ? true : false;

            objModel.Address = tbxAddress.Text.Trim() == null ? string.Empty : tbxAddress.Text.Trim();
            objModel.Address1 = tbxAddress1.Text.Trim() == null ? string.Empty : tbxAddress1.Text.Trim();
            objModel.Address2 = tbxAddress2.Text.Trim() == null ? string.Empty : tbxAddress2.Text.Trim();
            objModel.Address3 = tbxAddress3.Text.Trim() == null ? string.Empty : tbxAddress3.Text.Trim();
            objModel.State = cbxState.SelectedItem.ToString();
            objModel.Telephone = Convert.ToInt64(tbxTelnumber.Text.Trim() == string.Empty ? "0" : tbxTelnumber.Text.Trim());
            objModel.MobileNo = Convert.ToInt64(tbxMobileno.Text.Trim() == string.Empty ? "0" : tbxMobileno.Text.Trim());
            objModel.Email = tbxEmail.Text.Trim() == null ? string.Empty : tbxEmail.Text.Trim();
            objModel.Author_Id = AuthorId;

            objModel.CreatedBy = "Admin";

            bool isSuccess = objaut.UpdateAuthorMaster(objModel);
            {
                MessageBox.Show("Update Successfully!");
                ClearControls();
                AuthorId = 0;
                Administration.List.AuthorList frmList = new Administration.List.AuthorList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                FillAuthorInfo();
                tbxName.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AuthorModel objModel = new AuthorModel();

            if (tbxName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Author Name can not be blank!");
                return;
            }

            objModel.Name = tbxName.Text.Trim();
            objModel.Alias = tbxAlias.Text.Trim() == null ? string.Empty : tbxAlias.Text.Trim();
            objModel.PrintName = tbxPrintname.Text.Trim() == null ? string.Empty : tbxPrintname.Text.Trim();
            objModel.ConnectAcc = cbxContactwithAccount.SelectedItem.ToString() == "Y" ? true : false;

            objModel.Address = tbxAddress.Text.Trim() == null ? string.Empty : tbxAddress.Text.Trim();
            objModel.Address1 = tbxAddress1.Text.Trim() == null ? string.Empty : tbxAddress1.Text.Trim();
            objModel.Address2 = tbxAddress2.Text.Trim() == null ? string.Empty : tbxAddress2.Text.Trim();
            objModel.Address3 = tbxAddress3.Text.Trim() == null ? string.Empty : tbxAddress3.Text.Trim();
            objModel.State = cbxState.SelectedItem.ToString();
            objModel.Telephone = Convert.ToInt64(tbxTelnumber.Text.Trim() == string.Empty ? "0" : tbxTelnumber.Text.Trim());
            objModel.MobileNo = Convert.ToInt64(tbxMobileno.Text.Trim() == string.Empty ? "0" : tbxMobileno.Text.Trim());
            objModel.Email = tbxEmail.Text.Trim() == null ? string.Empty : tbxEmail.Text.Trim();

            objModel.CreatedBy = "Admin";
            bool isSuccess = objaut.SaveAuthorMaster(objModel);
            {
                MessageBox.Show("Saved Successfully!");
                ClearControls();
                AuthorId = 0;
            }
        }
        private void ClearControls()
        {
            tbxName.Text = string.Empty;
            tbxAlias.Text = string.Empty;
            tbxPrintname.Text = string.Empty;
            cbxContactwithAccount.SelectedIndex = 1;
            tbxAddress.Text = string.Empty;
            tbxAddress1.Text = string.Empty;
            tbxAddress2.Text = string.Empty;
            tbxAddress3.Text = string.Empty;
            cbxState.Text = string.Empty;
            tbxTelnumber.Text = string.Empty;
            tbxMobileno.Text = string.Empty;
            tbxTelnumber.Text = string.Empty;
            tbxEmail.Text = string.Empty;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ClearControls();
        }

        private void cbxState_Enter(object sender, EventArgs e)
        {
            cbxState.ShowPopup();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDelete = objaut.DeleteAuthorMasterDetails(AuthorId);
            if (isDelete)
            {
                MessageBox.Show("Delete Successfully!");
                ClearControls();
                AuthorId = 0;
                Administration.List.AuthorList frmList = new Administration.List.AuthorList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                FillAuthorInfo();
                tbxName.Focus();
            }
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            tbxAlias.Text = tbxName.Text.Trim();
            tbxPrintname.Text = tbxName.Text.Trim();
        }
    }
}
