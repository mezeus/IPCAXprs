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
            }
            //List<CurrencyMasterModel> lstCurr = objCurr.GetAllCurrency();
            //dgvList.DataSource = lstCurr;

            //Dialogs.PopUPDialog d = new Dialogs.PopUPDialog("Saved Successfully!");
            //d.ShowDialog();
        }

        private void ListCurrency_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.CurrencyList frmList = new Administration.List.CurrencyList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
        }

        private void tbxCurrencysymbol_KeyPress(object sender, KeyPressEventArgs e)
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
                    MessageBox.Show("Master Name Can Not Be Blank!");
                    return;
                    this.ActiveControl = tbxCurrencysymbol;

                }
                //e.Handled = true; // Mark the event as handled
            }
        }

        private void tbxCurrencysymbol_Leave(object sender, EventArgs e)
        {
            if (tbxCurrencysymbol.Text.Equals(string.Empty))
            {
                MessageBox.Show("Master Name can not be blank!");
                tbxCurrencysymbol.Focus();
                return;
            }
        }

        private void Currencyadd_Load(object sender, EventArgs e)
        {
            cbxCurrencyconvMode.SelectedIndex = 0;
        }
    }
}
