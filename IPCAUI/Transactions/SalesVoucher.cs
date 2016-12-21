using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPCAUI.Transactions
{
    public partial class SalesVoucher : Form
    {
        public SalesVoucher()
        {
            InitializeComponent();
        }

        private void navBarItem16_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Settings.AccountsDemo frm = new Settings.AccountsDemo();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog(this);
            //Settings.Accountsettings frm = new Settings.Accountsettings();
            //frm.StartPosition = FormStartPosition.CenterParent;
            //frm.ShowDialog(this);           
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
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
