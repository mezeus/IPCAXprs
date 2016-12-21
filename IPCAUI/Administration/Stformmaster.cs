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
        public Stformmaster()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Name can not be blank!");
                return;
            }

            //if (accObj.IsGroupExists(tbxGroupName.Text.Trim()))
            //{
            //    MessageBox.Show("Group Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
            //    cbxUnderGrp.Focus();
            //    return;
            //}

            STFormMasterModel objModel = new STFormMasterModel();

            objModel.Name = tbxName.Text.Trim();
            objModel.PrintName = tbxPrintname.Text.Trim();
            objModel.STRegType = cbxStregtype.SelectedItem.ToString();
            objModel.CreatedBy = "Admin";

            bool isSuccess = objStform.SaveSTF(objModel);
            if(isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
      
            }
            //List<STFormMasterModel> lstST = objMaster.GetAllSTF();
            //dgvList.DataSource = lstST;

            //Dialogs.PopUPDialog d = new Dialogs.PopUPDialog("Saved Successfully!");
            //d.ShowDialog();
        }

        private void ListStform_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.StformList frmList = new Administration.List.StformList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
        }
    }
}
