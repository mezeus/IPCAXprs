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
    public partial class BudgetsforAccount : Form
    {
        public BudgetsforAccount()
        {
            InitializeComponent();
        }

        private void BudgetsforAccount_Load(object sender, EventArgs e)
        {
            cbxDefineBudgets.Focus();
            if(Account.objAccount.AccountId!=0)
            {
                cbxDefineBudgets.SelectedItem=Account.objAccount.DefineBudgets?"Y":"N";
                tbxAnnualBudget.Text=Account.objAccount.AnnualBudgets.ToString();
                tbxJanuaryBd.Text=Account.objAccount.JanuaryBd.ToString();
                tbxFebruaryBd.Text= Account.objAccount.FebruaryBd.ToString();
                tbxMarchBd.Text= Account.objAccount.MarchBd.ToString();
                tbxAprilBd.Text=Account.objAccount.AprilBd.ToString();
                tbxMayBd.Text= Account.objAccount.MayBd.ToString();
                tbxJuneBd.Text= Account.objAccount.JuneBd.ToString();
                tbxJulyBd.Text= Account.objAccount.JulyBd.ToString();
                tbxAugustBd.Text= Account.objAccount.AugustBd.ToString();
                tbxSeptemberBd.Text= Account.objAccount.SeptemberBd.ToString();
                tbxOctoberBd.Text= Account.objAccount.OctoberBd.ToString();
                tbxNovemberBd.Text= Account.objAccount.NovemberBd.ToString();
                tbxDecemberBd.Text= Account.objAccount.DecemberBd.ToString();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Account.objAccount.DefineBudgets = cbxDefineBudgets.SelectedItem.ToString() == "Y" ? true : false;
            Account.objAccount.AnnualBudgets = Convert.ToDecimal(tbxAnnualBudget.Text.Trim()==string.Empty?"0.00": tbxAnnualBudget.Text.Trim());
            Account.objAccount.JanuaryBd = Convert.ToDecimal(tbxJanuaryBd.Text.Trim());
            Account.objAccount.FebruaryBd = Convert.ToDecimal(tbxFebruaryBd.Text.Trim());
            Account.objAccount.MarchBd = Convert.ToDecimal(tbxMarchBd.Text.Trim());
            Account.objAccount.AprilBd = Convert.ToDecimal(tbxAprilBd.Text.Trim());
            Account.objAccount.MayBd = Convert.ToDecimal(tbxMayBd.Text.Trim());
            Account.objAccount.JuneBd = Convert.ToDecimal(tbxJuneBd.Text.Trim());
            Account.objAccount.JulyBd = Convert.ToDecimal(tbxJulyBd.Text.Trim());
            Account.objAccount.AugustBd = Convert.ToDecimal(tbxAugustBd.Text.Trim());
            Account.objAccount.SeptemberBd = Convert.ToDecimal(tbxSeptemberBd.Text.Trim());
            Account.objAccount.OctoberBd = Convert.ToDecimal(tbxOctoberBd.Text.Trim());
            Account.objAccount.NovemberBd = Convert.ToDecimal(tbxNovemberBd.Text.Trim());
            Account.objAccount.DecemberBd = Convert.ToDecimal(tbxDecemberBd.Text.Trim());
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
    }
}
