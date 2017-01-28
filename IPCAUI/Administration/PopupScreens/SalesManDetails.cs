using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPCAUI.Administration.PopupScreens
{
    public partial class SalesManDetails : Form
    {
        public SalesManDetails()
        {
            InitializeComponent();
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

        private void SalesManDetails_Load(object sender, EventArgs e)
        {
            cbxDefaultSM.Focus();
            if(Account.objAccount.AccountId!=0)
            {
                cbxDefaultSM.SelectedItem = Account.objAccount.SpecifyDefaultSM ? "Y" : "N";
                cbxSalesMan.SelectedItem = Account.objAccount.SalesMan;
                cbxFreezeSM.SelectedItem = Account.objAccount.freezeSalesMan ? "Y" : "N";
                cbxDefaultCommission.SelectedItem = Account.objAccount.DefaultCommission ? "Y" : "N";
                if(Account.objAccount.DefaultCommission)
                {
                    cbxMode.SelectedItem = Account.objAccount.CommissionMode;
                    tbxCommissionPer.Text = Account.objAccount.CommissionPercentage.ToString();
                    cbxFreezeCommission.SelectedItem = Account.objAccount.FreezeCommission ? "Y" : "N";
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Account.objAccount.SpecifyDefaultSM = cbxDefaultSM.SelectedItem.ToString() == "Y" ? true : false;
            Account.objAccount.SalesMan = cbxSalesMan.SelectedItem.ToString();
            Account.objAccount.freezeSalesMan = cbxFreezeSM.SelectedItem.ToString() == "Y" ? true : false;
            Account.objAccount.DefaultCommission = cbxDefaultCommission.SelectedItem.ToString() == "Y" ? true : false;
            if(Account.objAccount.DefaultCommission)
            {
                Account.objAccount.CommissionMode = cbxMode.SelectedItem.ToString();
                Account.objAccount.CommissionPercentage = Convert.ToDecimal(tbxCommissionPer.Text.Trim()==string.Empty?"0.00": tbxCommissionPer.Text.Trim());
                Account.objAccount.FreezeCommission = cbxFreezeCommission.SelectedItem.ToString() == "Y" ? true : false;
            }
            this.Close();
        }
    }
}
