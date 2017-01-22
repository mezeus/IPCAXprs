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
    public partial class Salesman : Form
    {
        SalesManBL objbl = new SalesManBL();
        public Salesman()
        {
            InitializeComponent();
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

        private void navBarControl1_Click(object sender, EventArgs e)
        {

        }

        private void ListSalesman_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.SalesmanList frmList = new Administration.List.SalesmanList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {         
            if (tbxName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Group Name can not be blank!");
                return;
            }
            eSunSpeedDomain.SalesManModel objsalesmman = new eSunSpeedDomain.SalesManModel();

            objsalesmman.SM_Name = tbxName.Text;

            objsalesmman.SM_Alias = tbxAlias.Text.Trim()==string.Empty?string.Empty: tbxAlias.Text.Trim();
            objsalesmman.SM_PrintName = tbxPrintName.Text.Trim() == string.Empty ? string.Empty : tbxPrintName.Text.Trim();
            objsalesmman.EnableDefCommision = cbxEnableDefComm.SelectedItem.ToString()=="Y"? true : false;
            objsalesmman.Commision_Mode = cbxDefCommMode.SelectedItem.ToString();
            objsalesmman.DefCommision = Convert.ToDecimal(tbxDefComm.Text.Trim());
            objsalesmman.FreezeCommision = cbxDefFreeze.SelectedItem.ToString().Equals("Yes") ? true : false;

            objsalesmman.SM_AccounttobeCredited = cbxSalesAccountCredited.SelectedItem.ToString() == string.Empty ? string.Empty : cbxSalesAccountCredited.SelectedItem.ToString();
            objsalesmman.Sales_DebitMode = cbxSaleDebitMode.SelectedItem.ToString();
            objsalesmman.Sales_AccDebited = cbxSalesDebited.SelectedItem.ToString();
            //objsalesmman.FreezeCommision = cbxDefFreeze.SelectedItem.ToString().Equals("Yes") ? true : false;

            objsalesmman.Purchase_DebitMode = cbxPurchaseDebitMode.SelectedItem.ToString();
            objsalesmman.Purchase_AccDebited = cbxPurchaseDebited.SelectedItem.ToString();
            //objsalesmman.FreezeCommision = cbxDefFreeze.SelectedItem.ToString().Equals("Yes") ? true : false;

            objsalesmman.Address = tbxAddress.Text.Trim();
            objsalesmman.Mobile = tbxMobile.Text.Trim();
            objsalesmman.Email = tbxEmail.Text.Trim();

            //objAccGroup.CreatedBy = "Admin";

            string message = string.Empty;

            bool isSuccess = objbl.SaveSalesMan(objsalesmman);
            if(isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }
            //List<eSunSpeedDomain.AccountGroupModel> lstGroups = accObj.GetListofAccountsGroups();
            //dgvList.DataSource = lstGroups;            

            //Dialogs.PopUPDialog d = new Dialogs.PopUPDialog("Saved Successfully!");
            //d.ShowDialog();
            //*/
        }

        private void Salesman_Load(object sender, EventArgs e)
        {
            cbxDefCommMode.SelectedIndex = 0;
            cbxDefFreeze.SelectedIndex = 1;
            cbxEnableDefComm.SelectedIndex = 0;
            cbxPurchaseDebited.SelectedIndex = 0;
            cbxPurchaseDebitMode.SelectedIndex = 0;
            cbxSaleDebitMode.SelectedIndex = 0;
            cbxSalesDebited.SelectedIndex = 0;

        }

        private void cbxEnableDefComm_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Salesman_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData == Keys.Enter))
            {
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void tbxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (tbxName.Text.Trim() == "")
                {
                    MessageBox.Show("Name Can Not Be Blank!");
                    tbxName.Focus();
                    return;
                }
                //if (objbl.IsGroupExists(tbxGroupName.Text.Trim()))
                //{
                //    MessageBox.Show("Group Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
                //    tbxGroupName.Focus();
                //    return;
                //}

                if (this.ActiveControl != null)
                {
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);

                }
                e.Handled = true; // Mark the event as handled
            }
        }

        private void cbxSalesAccountCredited_Enter(object sender, EventArgs e)
        {
            cbxSalesAccountCredited.ShowPopup();
        }
    }
}
