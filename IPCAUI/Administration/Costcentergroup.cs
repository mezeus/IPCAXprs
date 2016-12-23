﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eSunSpeed;
using eSunSpeedDomain;
using eSunSpeed.BusinessLogic;

namespace IPCAUI.Administration
{
    public partial class Costcentergroup : Form
    {
        CostCentreGroupBL objCG = new CostCentreGroupBL();
        public Costcentergroup()
        {
            InitializeComponent();
            
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
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

            CostCentreGroupModel objModel = new CostCentreGroupModel();
            
            objModel.GroupName = tbxGroupName.Text.Trim();
            objModel.Alias = tbxAlias.Text.Trim();
            objModel.underGroup = cbxUndergroup.SelectedItem.ToString();
            objModel.PrimaryGroup = cbxPrimarygroup.SelectedItem.ToString() == "Y" ? true : false;
            objModel.CreatedBy = "Admin";

            bool isSuccess = objCG.SaveCCG(objModel);
            if(isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }

            //List<CostCentreGroupModel> lstGroups = objCG.GetAllCostCentreGroups();
            //dgvList.DataSource = lstGroups;

            //Dialogs.PopUPDialog d = new Dialogs.PopUPDialog("Saved Successfully!");
            //d.ShowDialog();
        }

        private void Listccgroup_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.CostcentergrpList frmList = new Administration.List.CostcentergrpList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
        }

        private void Costcentergroup_Load(object sender, EventArgs e)
        {
            cbxPrimarygroup.SelectedIndex = 1;
            cbxUndergroup.SelectedIndex = 0;
        }

        private void tbxGroupName_KeyPress(object sender, KeyPressEventArgs e)
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
                    MessageBox.Show("Account Name Can Not Be Blank!");
                    return;
                    this.ActiveControl = tbxGroupName;

                }
                //e.Handled = true; // Mark the event as handled
            }
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
        private void tbxGroupName_Leave(object sender, EventArgs e)
        {
            if (tbxGroupName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Group Name can not be blank!");
                tbxGroupName.Focus();
                return;
            }
        }
    }
}