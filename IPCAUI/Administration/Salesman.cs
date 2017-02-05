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
    public partial class Salesman : Form
    {
        SalesManBL objbl = new SalesManBL();
        AccountMasterBL objAccBL = new AccountMasterBL();
        public static int SMId = 0;
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

        private void ListSalesman_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.SalesmanList frmList = new Administration.List.SalesmanList();
            frmList.StartPosition = FormStartPosition.CenterScreen;
            SMId = 0;
            frmList.ShowDialog();
            FillSalesManInfo();
        }
        private void FillSalesManInfo()
        {
            if (SMId == 0)
            {
                tbxName.Focus();
                ClearControls();
                lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                return;
            }
            SalesManModel objModel = objbl.GetAllSalesManById(SMId);

            tbxName.Text = objModel.SM_Name.ToString();
            tbxAlias.Text = objModel.SM_Alias.ToString();
            tbxPrintName.Text = objModel.SM_PrintName.ToString();
            cbxEnableDefComm.SelectedItem = (objModel.EnableDefCommision) ? "Y" : "N";
            cbxDefCommMode.SelectedItem = objModel.Commision_Mode.ToString();
            tbxDefComm.Text = objModel.DefCommision.ToString();
            cbxDefFreeze.SelectedItem = objModel.FreezeCommision ? "Y" : "N";
            cbxSaleDebitMode.SelectedItem = objModel.Sales_DebitMode.ToString();
            //objModel.Sales_ACCredited = dr["Sales_ACCredited"].ToString();
            cbxSalesDebited.SelectedItem = objModel.Sales_AccDebited.ToString();
            cbxSalesAccountCredited.SelectedItem = objModel.SM_AccounttobeCredited.ToString();
            cbxPurchaseDebitMode.SelectedItem = objModel.Purchase_DebitMode.ToString();
            ////objModel.Purchase_AccCredited = dr["Purchase_DebitMode"].ToString();
            cbxPurchaseDebitMode.SelectedItem = objModel.Purchase_AccDebited.ToString();
            tbxAddress.Text = objModel.Address.ToString();
            tbxAddress1.Text = objModel.Address1.ToString();
            tbxAddress2.Text = objModel.Address2.ToString();
            tbxAddress3.Text = objModel.Address3.ToString();
            tbxTelephone.Text = objModel.Telephone.ToString();
            tbxMobile.Text = objModel.Mobile.ToString();
            tbxEmail.Text = objModel.Email.ToString();
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            tbxName.Focus();
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

            objsalesmman.SM_Alias = tbxAlias.Text.Trim() == string.Empty ? string.Empty : tbxAlias.Text.Trim();
            objsalesmman.SM_PrintName = tbxPrintName.Text.Trim() == string.Empty ? string.Empty : tbxPrintName.Text.Trim();
            objsalesmman.EnableDefCommision = cbxEnableDefComm.SelectedItem.ToString() == "Y" ? true : false;
            objsalesmman.Commision_Mode = cbxDefCommMode.SelectedItem.ToString();
            objsalesmman.DefCommision = Convert.ToDecimal(tbxDefComm.Text.Trim() == string.Empty ? "0.00" : tbxDefComm.Text.Trim());
            objsalesmman.FreezeCommision = cbxDefFreeze.SelectedItem.ToString() == "Y" ? true : false;

            objsalesmman.SM_AccounttobeCredited = cbxSalesAccountCredited.SelectedItem.ToString() == string.Empty ? string.Empty : cbxSalesAccountCredited.SelectedItem.ToString();
            objsalesmman.Sales_DebitMode = cbxSaleDebitMode.SelectedItem.ToString();
            objsalesmman.Sales_AccDebited = cbxSalesDebited.SelectedItem.ToString();
            objsalesmman.Purchase_DebitMode = cbxPurchaseDebitMode.SelectedItem.ToString();
            objsalesmman.Purchase_AccDebited = cbxPurchaseDebited.SelectedItem.ToString();

            objsalesmman.Address = tbxAddress.Text.Trim();
            objsalesmman.Address1 = tbxAddress1.Text.Trim();
            objsalesmman.Address2 = tbxAddress2.Text.Trim();
            objsalesmman.Address3 = tbxAddress3.Text.Trim();
            objsalesmman.Telephone = Convert.ToInt64(tbxTelephone.Text.Trim() == string.Empty ? "0" : tbxTelephone.Text.Trim());
            objsalesmman.Mobile = Convert.ToInt64(tbxMobile.Text.Trim() == string.Empty ? "0" : tbxMobile.Text.Trim());
            objsalesmman.Email = tbxEmail.Text.Trim();

            string message = string.Empty;

            bool isSuccess = objbl.SaveSalesMan(objsalesmman);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                ClearControls();
            }
        }

        private void Salesman_Load(object sender, EventArgs e)
        {
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            cbxDefCommMode.SelectedIndex = 0;
            cbxDefFreeze.SelectedIndex = 1;
            cbxEnableDefComm.SelectedIndex = 0;
            cbxPurchaseDebited.SelectedIndex = 0;
            cbxPurchaseDebitMode.SelectedIndex = 0;
            cbxSaleDebitMode.SelectedIndex = 0;
            cbxSalesDebited.SelectedIndex = 0;
            List<AccountMasterModel> lstaccounts = objAccBL.GetListofAccount();
            foreach(AccountMasterModel objaccount in lstaccounts)
            {
                cbxSalesAccountCredited.Properties.Items.Add(objaccount.AccountName);
                cbxSalesDebited.Properties.Items.Add(objaccount.AccountName);
                cbxPurchaseDebited.Properties.Items.Add(objaccount.AccountName);
            }
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
                if (SMId == 0)
                {
                    if (objbl.IsSalesManExists(tbxName.Text.Trim()))
                    {
                        MessageBox.Show("SalesMan Name already Exists!");
                        tbxName.Focus();
                        return;
                    }
                }
                e.Handled = true; // Mark the event as handled
            }
        }

        private void cbxSalesAccountCredited_Enter(object sender, EventArgs e)
        {
            cbxSalesAccountCredited.ShowPopup();
        }

        private void tbxDefComm_Enter(object sender, EventArgs e)
        {
            if(tbxDefComm.Text==string.Empty)
            {
                tbxDefComm.Text = "0.00";
            }   
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            tbxAlias.Text = tbxName.Text.Trim();
            tbxPrintName.Text = tbxName.Text.Trim();
        }

        private void btnQuit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tbxName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Group Name can not be blank!");
                return;
            }
            eSunSpeedDomain.SalesManModel objsalesmman = new eSunSpeedDomain.SalesManModel();

            objsalesmman.SM_Name = tbxName.Text;

            objsalesmman.SM_Alias = tbxAlias.Text.Trim() == string.Empty ? string.Empty : tbxAlias.Text.Trim();
            objsalesmman.SM_PrintName = tbxPrintName.Text.Trim() == string.Empty ? string.Empty : tbxPrintName.Text.Trim();
            objsalesmman.EnableDefCommision = cbxEnableDefComm.SelectedItem.ToString() == "Y" ? true : false;
            objsalesmman.Commision_Mode = cbxDefCommMode.SelectedItem.ToString();
            objsalesmman.DefCommision = Convert.ToDecimal(tbxDefComm.Text.Trim() == string.Empty ? "0.00" : tbxDefComm.Text.Trim());
            objsalesmman.FreezeCommision = cbxDefFreeze.SelectedItem.ToString() == "Y" ? true : false;

            objsalesmman.SM_AccounttobeCredited = cbxSalesAccountCredited.SelectedItem.ToString() == string.Empty ? string.Empty : cbxSalesAccountCredited.SelectedItem.ToString();
            objsalesmman.Sales_DebitMode = cbxSaleDebitMode.SelectedItem.ToString();
            objsalesmman.Sales_AccDebited = cbxSalesDebited.SelectedItem.ToString();
            objsalesmman.Purchase_DebitMode = cbxPurchaseDebitMode.SelectedItem.ToString();
            objsalesmman.Purchase_AccDebited = cbxPurchaseDebited.SelectedItem.ToString();

            objsalesmman.Address = tbxAddress.Text.Trim();
            objsalesmman.Address1 = tbxAddress1.Text.Trim();
            objsalesmman.Address2 = tbxAddress2.Text.Trim();
            objsalesmman.Address3 = tbxAddress3.Text.Trim();
            objsalesmman.Telephone = Convert.ToInt64(tbxTelephone.Text.Trim() == string.Empty ? "0" : tbxTelephone.Text.Trim());
            objsalesmman.Mobile = Convert.ToInt64(tbxMobile.Text.Trim() == string.Empty ? "0" : tbxMobile.Text.Trim());
            objsalesmman.Email = tbxEmail.Text.Trim();
            objsalesmman.SalesMan_Id = SMId;
            string message = string.Empty;

            bool isSuccess = objbl.UpdateSalesMan(objsalesmman);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
                ClearControls();
                SMId = 0;
                Administration.List.SalesmanList frmList = new Administration.List.SalesmanList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                FillSalesManInfo();
                tbxName.Focus();
            }
        }
        private void ClearControls()
        {
            tbxName.Text = string.Empty;
            tbxPrintName.Text = string.Empty;
            tbxAlias.Text = string.Empty;
            tbxAddress.Text= string.Empty;
            tbxAddress1.Text = string.Empty;
            tbxAddress2.Text = string.Empty;
            tbxAddress3.Text = string.Empty;
            tbxTelephone.Text = string.Empty;
            tbxMobile.Text = string.Empty;
            tbxEmail.Text = string.Empty;
            cbxEnableDefComm.SelectedIndex = 1;
            cbxDefCommMode.Text = string.Empty;
            tbxDefComm.Text = "0.00";
            cbxDefFreeze.Text = string.Empty;
            cbxSalesAccountCredited.Text = string.Empty;
            cbxSaleDebitMode.Text = string.Empty;
            cbxSalesDebited.Text = string.Empty;
            cbxPurchaseDebitMode.Text = string.Empty;
            cbxPurchaseDebited.Text = string.Empty;
            //foreach (Control ctrl in this.Controls)
            //{
            //    if (ctrl is DevExpress.XtraEditors.TextEdit)
            //    {
            //        DevExpress.XtraEditors.TextEdit tb = (DevExpress.XtraEditors.TextEdit)ctrl;
            //        if (tb != null)
            //        {
            //            tb.Text = string.Empty;
            //        }
            //    }
            //}
        }
    
        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDelete = objbl.DeleteSalesManDetails(SMId);
            if (isDelete)
            {
                MessageBox.Show("Delete Successfully!");
                //ClearControls();
                SMId = 0;
                Administration.List.SalesmanList frmList = new Administration.List.SalesmanList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                FillSalesManInfo();
                tbxName.Focus();
            }
        }

        private void btnNewEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ClearControls();
        }

        private void cbxSalesDebited_Enter(object sender, EventArgs e)
        {
            cbxSalesDebited.ShowPopup();
        }

        private void cbxPurchaseDebited_Enter(object sender, EventArgs e)
        {
            cbxPurchaseDebited.ShowPopup();
        }

        private void cbxSalesDebited_Leave(object sender, EventArgs e)
        {
            if(cbxSalesDebited.Text=="")
            {
                cbxSalesDebited.SelectedIndex = 0;
            }
        }

        private void cbxPurchaseDebited_Leave(object sender, EventArgs e)
        {
            if (cbxPurchaseDebited.Text == "")
            {
                cbxPurchaseDebited.SelectedIndex = 0;
            }
        }

        private void cbxSalesAccountCredited_Leave(object sender, EventArgs e)
        {
            if(cbxSalesAccountCredited.Text=="")
            {
                cbxSalesAccountCredited.SelectedIndex = 0;
            }
        }
    }
}
