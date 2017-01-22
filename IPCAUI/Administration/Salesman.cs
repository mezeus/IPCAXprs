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

        private void navBarControl1_Click(object sender, EventArgs e)
        {

        }

        private void ListSalesman_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.SalesmanList frmList = new Administration.List.SalesmanList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();

        }
        private void FillSalesManInfo()
        {
            if (SMId == 0)
            {
                tbxName.Focus();
                lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                return;
            }
            SalesManModel objModel = objbl.GetAllSalesManById(SMId);
      
            tbxName.Text= objModel.SM_Name.ToString();
            tbxAlias.Text= objModel.SM_Alias.ToString();
            tbxPrintName.Text= objModel.SM_PrintName.ToString();
            cbxEnableDefComm.SelectedItem = (objModel.EnableDefCommision) ? "Y" : "N";
            cbxDefCommMode.SelectedItem=objModel.Commision_Mode.ToString();
            //objModel.DefCommision = Convert.ToDecimal(dr["DefCommision"]);
            //objModel.FreezeCommision = Convert.ToBoolean(dr["FreezeCommision"]);
            //objModel.Sales_DebitMode = dr["Sales_DebitMode"].ToString();
            ////objModel.Sales_ACCredited = dr["Sales_ACCredited"].ToString();
            //objModel.Sales_AccDebited = dr["Sales_AccDebited"].ToString();
            //objModel.SM_AccounttobeCredited = dr["Salesman_AccountToCredit"].ToString();
            //objModel.Purchase_DebitMode = dr["Purchase_DebitMode"].ToString();
            ////objModel.Purchase_AccCredited = dr["Purchase_DebitMode"].ToString();
            //objModel.Purchase_AccDebited = dr["Purchase_AccDebited"].ToString();
            //objModel.Address = dr["Address"].ToString();
            //objModel.Address1 = dr["Address1"].ToString();
            //objModel.Address2 = dr["Address2"].ToString();
            //objModel.Address3 = dr["Address3"].ToString();
            //objModel.Telephone = Convert.ToInt64(dr["Tel.No"].ToString() == string.Empty ? "0" : dr["Tel.No"].ToString());
            //objModel.Mobile = Convert.ToInt64(dr["Mobile"].ToString() == string.Empty ? "0" : dr["Mobile"].ToString());
            //objModel.Email = dr["E-Mail"].ToString();
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
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
            objsalesmman.DefCommision = Convert.ToDecimal(tbxDefComm.Text.Trim()==string.Empty?"0.00": tbxDefComm.Text.Trim());
            objsalesmman.FreezeCommision = cbxDefFreeze.SelectedItem.ToString()=="Y"? true : false;

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
            objsalesmman.Mobile = Convert.ToInt64(tbxMobile.Text.Trim()==string.Empty?"0": tbxMobile.Text.Trim());
            objsalesmman.Email = tbxEmail.Text.Trim();

            string message = string.Empty;

            bool isSuccess = objbl.SaveSalesMan(objsalesmman);
            if(isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }
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

        private void tbxDefComm_Enter(object sender, EventArgs e)
        {
            tbxDefComm.Text = "0.00";
        }
    }
}
