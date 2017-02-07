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
    public partial class Stformmaster : Form
    {
        STFormMasterBL objStform = new STFormMasterBL();
        public static int ST_Id = 0;
        public Stformmaster()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxName.Text.Equals(string.Empty))
            {
                MessageBox.Show("ST Name can not be blank!");
                return;
            }
            STFormMasterModel objModel = new STFormMasterModel();

            objModel.Name = tbxName.Text.Trim();
            objModel.PrintName = tbxPrintname.Text.Trim();
            objModel.STRegType = cbxStregtype.SelectedItem.ToString();
            objModel.CreatedBy = "Admin";

            bool isSuccess = objStform.SaveSTF(objModel);
            if(isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                ClearControls();
                tbxName.Focus();
            }
        }

        private void ListStform_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.StformList frmList = new Administration.List.StformList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
            FillSTFormInfo();
        }
        private void FillSTFormInfo()
        {
            if(ST_Id==0)
            {
                tbxName.Focus();
                lactrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lactrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lactrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                return;
            }
            STFormMasterModel objModel = objStform.GetAllSTFById(ST_Id);
            tbxName.Text= objModel.Name.ToString();
            tbxPrintname.Text=objModel.PrintName.ToString();
            cbxStregtype.SelectedItem = objModel.STRegType.ToString();
            tbxName.Focus();
            lactrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lactrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }
        private void Stformmaster_Load(object sender, EventArgs e)
        {
            tbxName.Focus();
            cbxStregtype.SelectedIndex = 0;
            lactrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lactrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            tbxPrintname.Text = tbxName.Text.Trim();
        }

        private void tbxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar=='\r')
            {
                if(tbxName.Text.Trim()==string.Empty)
                {
                    MessageBox.Show("ST Name Can Not be Blank!");
                    tbxName.Focus();
                    return;
                }
                if(ST_Id==0)
                {
                    if (objStform.IsSTNameExists(tbxName.Text.Trim()))
                    {
                        MessageBox.Show("ST Name already Exists!");
                        tbxName.Focus();
                        return;
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            STFormMasterModel objModel = new STFormMasterModel();

            objModel.Name = tbxName.Text.Trim();
            objModel.PrintName = tbxPrintname.Text.Trim();
            objModel.STRegType = cbxStregtype.SelectedItem.ToString();

            objModel.STF_Id = ST_Id;

            bool isSuccess = objStform.UpdateSTF(objModel);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
                ST_Id = 0;
                ClearControls();
                Administration.List.StformList frmList = new Administration.List.StformList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                FillSTFormInfo();
            }
        }
        private void ClearControls()
        {
            tbxName.Text = string.Empty;
            tbxPrintname.Text = string.Empty;
            cbxStregtype.Text = string.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDelete = objStform.DeleteSTById(ST_Id);
            if(isDelete)
            {
                MessageBox.Show("Delete Successfully!");
                ST_Id = 0;
                ClearControls();
                Administration.List.StformList frmList = new Administration.List.StformList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                FillSTFormInfo();
            }
        }

        private void btnNewEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ClearControls();
            ST_Id = 0;
            lactrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lactrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lactrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }

        private void btnQuit_Click(object sender, EventArgs e)
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

        private void cbxStregtype_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar!='\r')
            {
                cbxStregtype.ShowPopup();
            }
        }
    }
}
