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
    public partial class MaterialCenter : Form
    {
        MaterialCentreMasterBL objmatcenbl = new MaterialCentreMasterBL();
        public MaterialCenter()
        {
            InitializeComponent();
        }

        private void ListMaterialcenter_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.MaterialcenterList frmList = new Administration.List.MaterialcenterList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MaterialCentreMasterModel objGroup = new MaterialCentreMasterModel();

            objGroup.Group = tbxGroupName.Text.TrimEnd();
            objGroup.Alias = tbxAliasname.Text.Trim();
            objGroup.StockAccount = cbxStockaccount.Text.Trim();
        //    objGroup.EnableStockinBal = cbxstockinbal.SelectedItem.ToString() == "Y" ? true : false;
          //  objGroup.SalesAccount = tbxSalesAccount.Text.Trim();
            //objGroup.PurchaseAccount = tbxPurcaccount.Text.Trim();
            objGroup.EnableAccinTransfer = tbxAccStocktransfer.Text.Trim() == "Y" ? true : false; 



           // objGroup.PrimaryGroup = cbxPrimarygroup.SelectedItem.ToString() == "Y" ? true : false;
           // objGroup.UnderGroup = cbxUndergroup.SelectedItem.ToString();
            objGroup.CreatedBy = "Admin";

            bool isSuccess = objmatcenbl.SaveMaterialMaster(objGroup);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }
        }
    }
}
