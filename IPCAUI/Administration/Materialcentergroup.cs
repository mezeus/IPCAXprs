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
    public partial class Materialcentergroup : Form
    {
        MaterialCentreGroupMaster MatObj = new MaterialCentreGroupMaster();
        public Materialcentergroup()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MaterialCentreGroupMasterModel objGroup = new MaterialCentreGroupMasterModel();

            objGroup.Group = tbxGroupName.Text.TrimEnd();
            objGroup.Alias = tbxAliasname.Text.Trim();
            objGroup.PrimaryGroup = cbxPrimarygroup.SelectedItem.ToString() == "Y" ? true : false;
            objGroup.UnderGroup = cbxUndergroup.SelectedItem.ToString();
            objGroup.CreatedBy = "Admin";

            bool isSuccess = MatObj.SaveMCG(objGroup);
            if(isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }
            //List<MaterialCentreGroupMasterModel> lstGroups = MatObj.GetAllMaterialGroups();
            //dgvList.DataSource = lstGroups;
            //Dialogs.PopUPDialog d = new Dialogs.PopUPDialog("Saved Successfully!");
            //d.ShowDialog();
            //btnSave.Visible = true;
        }

        private void ListMaterialCengrp_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.MaterialcentergrpList frmList = new Administration.List.MaterialcentergrpList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
        }
    }
}
