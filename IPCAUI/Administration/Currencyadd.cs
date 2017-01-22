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
    public partial class Currencyadd : Form
    {
        CurrencyBL objCurr = new CurrencyBL();
        public static int CurrecyId = 0;
        public Currencyadd()
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

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (tbxCurrencystring.Equals(string.Empty))
            {
                MessageBox.Show("Currency Symbol can not be blank!");
                return;
            }

            //if (accObj.IsGroupExists(tbxGroupName.Text.Trim()))
            //{
            //    MessageBox.Show("Group Name already Exists!", "SunSpeed", MessageBoxButtons.RetryCancel);
            //    cbxUnderGrp.Focus();
            //    return;
            //}

            CurrencyMasterModel objMaster = new CurrencyMasterModel();

            objMaster.Symbol = tbxCurrencysymbol.Text.Trim();
            objMaster.CString = tbxCurrencystring.Text.Trim();
            objMaster.ConvertionMode = cbxCurrencyconvMode.Text.Trim();
            objMaster.SubString = tbxCurrencySubstring.Text.Trim();
            objMaster.CreatedBy = "Admin";

         
            bool isSuccess = objCurr.SaveCurrency(objMaster);
            if(isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                ClearControls();
            }
            //List<CurrencyMasterModel> lstCurr = objCurr.GetAllCurrency();
            //dgvList.DataSource = lstCurr;

            //Dialogs.PopUPDialog d = new Dialogs.PopUPDialog("Saved Successfully!");
            //d.ShowDialog();
        }
        private void ClearControls()
        {
            tbxCurrencysymbol.Text = string.Empty;
            tbxCurrencystring.Text = string.Empty;
            tbxCurrencySubstring.Text = string.Empty;
            cbxCurrencyconvMode.Text = string.Empty;
            CurrecyId = 0;
        }
        private void ListCurrency_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.CurrencyList frmList = new Administration.List.CurrencyList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
            tbxCurrencysymbol.Focus();

            FillCurrencyInfo();
        }

        private void FillCurrencyInfo()
        {
            if(CurrecyId==0)
            {
                tbxCurrencysymbol.Focus();
                return;
            }
            CurrencyMasterModel objCurrecy = objCurr.GetAllCurrencyById(CurrecyId);

            tbxCurrencysymbol.Text = objCurrecy.Symbol;
            tbxCurrencystring.Text = objCurrecy.CString;
            tbxCurrencySubstring.Text = objCurrecy.SubString;
            cbxCurrencyconvMode.Text = objCurrecy.ConvertionMode;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tbxCurrencystring.Equals(string.Empty))
            {
                MessageBox.Show("Currency Symbol can not be blank!");
                return;
            }
            CurrencyMasterModel objMaster = new CurrencyMasterModel();

            objMaster.Symbol = tbxCurrencysymbol.Text.Trim();
            objMaster.CString = tbxCurrencystring.Text.Trim();
            objMaster.ConvertionMode = cbxCurrencyconvMode.Text.Trim();
            objMaster.SubString = tbxCurrencySubstring.Text.Trim();
            objMaster.CM_ID = CurrecyId;
            objMaster.ModifiedBy = "Admin";


            bool isSuccess = objCurr.UpdateCurrency(objMaster);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
                ClearControls();
                CurrecyId = 0;
                Administration.List.CurrencyList frmList = new Administration.List.CurrencyList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
            }
        }

        private void Currencyadd_Load(object sender, EventArgs e)
        {
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }

        private void tbxCurrencysymbol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (tbxCurrencysymbol.Text.Trim() == "")
                {
                    MessageBox.Show("Master Name Can Not Be Blank!");
                    tbxCurrencysymbol.Focus();
                    return;
                }
                if(CurrecyId==0)
                {
                    if (objCurr.IsCurrencyExists(tbxCurrencysymbol.Text.Trim()))
                    {
                        MessageBox.Show("Master Name already Exists!");
                        tbxCurrencysymbol.Focus();
                        return;
                    }
                }
            }
        }

        private void tbxCurrencystring_Enter(object sender, EventArgs e)
        {
            tbxCurrencystring.Text = tbxCurrencysymbol.Text.Trim();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDelete = objCurr.DeletCurrency(CurrecyId);
            if (isDelete)
            {
                MessageBox.Show("Delete Successfully!");
                ClearControls();
                CurrecyId = 0;
                Administration.List.CurrencyList frmList = new Administration.List.CurrencyList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                FillCurrencyInfo();
                tbxCurrencysymbol.Focus();
            }
        }

        private void btnNewEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ClearControls();
            CurrecyId = 0;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }
    }
}
