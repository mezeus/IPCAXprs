using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eSunSpeedDomain;

namespace IPCAUI.Administration.PopupScreens
{
    public partial class CreditLimitforAccount : Form
    {
        public CreditLimitforAccount()
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            Account.objAccount.DefineCrLimit = cbxDefineCrLimit.SelectedItem.ToString() == "Y" ? true : false;
            if(Account.objAccount.DefineCrLimit)
            {
                Account.objAccount.MaxCredit = Convert.ToDecimal(tbxMaxCredit.Text.Trim() == string.Empty ? "0.00" : tbxMaxCredit.Text.Trim());
            }
            this.Close();
        }
    }
}
