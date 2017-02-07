﻿using System;
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
    public partial class Unitmaster : Form
    {
        UnitMaster objunm = new UnitMaster();
        UnitConversion objunitConBl = new UnitConversion();
        public static int UMId = 0;
        public Unitmaster()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxUnitName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Unit Name can not be blank!");
                return;
            }
            UnitMasterModel objModel = new UnitMasterModel();

            objModel.UnitName = tbxUnitName.Text.Trim();
            objModel.PrintName = tbxPrintname.Text == null?string.Empty:tbxPrintname.Text.Trim();
            objModel.ExciseReturn = tbxUnitnameExcise.Text.Trim() == null ? string.Empty : tbxUnitnameExcise.Text.Trim();
            objModel.CreatedBy = "Admin";

            bool isSuccess = objunm.SaveUM(objModel);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfuly!");
                ClearControls();
                tbxUnitName.Focus();
            }
        }

        private void dvgUnitmaster_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.UnitmasterList frmList = new Administration.List.UnitmasterList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
            FillUnitMasterInfo();
        }

        private void FillUnitMasterInfo()
        {
            if(UMId == 0)
            {
                tbxUnitName.Focus();
                lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                return;
            }
            UnitMasterModel objunit = objunm.GetListofUnitsById(UMId);

            tbxUnitName.Text = objunit.UnitName;
            tbxPrintname.Text = objunit.PrintName;
            tbxUnitnameExcise.Text = objunit.ExciseReturn;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            tbxUnitName.Focus();
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
        private void tbxUnitName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (tbxUnitName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Unit Name Can Not Be Blank!");
                    this.ActiveControl = tbxUnitName;
                    return;
                }
                if (objunm.IsUnitMasterExists(tbxUnitName.Text.Trim()))
                {
                   MessageBox.Show("Unit Name already Exists!");
                    tbxUnitName.Focus();
                    return;
                }
            }
        }

        private void Unitmaster_Load(object sender, EventArgs e)
        {
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tbxUnitName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Unit Name can not be blank!");
                return;
            }
            UnitMasterModel objModel = new UnitMasterModel();

            objModel.UnitName = tbxUnitName.Text.Trim();
            objModel.PrintName = tbxPrintname.Text.Trim() == null ? string.Empty : tbxPrintname.Text.Trim(); ;
            objModel.ExciseReturn = tbxUnitnameExcise.Text.Trim() == null ? string.Empty : tbxUnitnameExcise.Text.Trim(); ;
            objModel.UM_ID = UMId;
            objModel.CreatedBy = "Admin";

            bool isSuccess = objunm.UpdateUM(objModel);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfuly!");
                ClearControls();
                UMId = 0;
                Administration.List.UnitmasterList frmList = new Administration.List.UnitmasterList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                FillUnitMasterInfo();
            }
        }

        private void tbxUnitName_TextChanged(object sender, EventArgs e)
        {
            tbxPrintname.Text = tbxUnitName.Text.Trim();
        }

        private void btnNewEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ClearControls();
            UMId = 0;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }
        public void ClearControls()
        {
            tbxUnitName.Text = string.Empty;
            tbxPrintname.Text = string.Empty;
            tbxUnitnameExcise.Text = string.Empty;
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            UnitConversionModel objmodel = objunitConBl.GetUnitConversionByUnitname(tbxUnitName.Text.Trim());
            if (objmodel.SubUnit != null)
            {
                MessageBox.Show("Can Not Delete Unit Under Tag With Unit Name.." + objmodel.SubUnit);
                tbxUnitName.Focus();
            }
            if(objmodel.SubUnit ==null)
            {
                bool isDelete = objunm.DeleteUnitMasterById(UMId);
                if (isDelete)
                {
                    MessageBox.Show("Delete Successfully!");
                    ClearControls();
                    UMId = 0;
                    Administration.List.UnitmasterList frmList = new Administration.List.UnitmasterList();
                    frmList.StartPosition = FormStartPosition.CenterScreen;

                    frmList.ShowDialog();
                    FillUnitMasterInfo();
                }
            }
            
        }
    }
}
