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
    public partial class Currencyconversion : Form
    {
        CurrencyConversionBL objCurcov = new CurrencyConversionBL();
        public Currencyconversion()
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

        private void ListCurrencyCon_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.AccountList frmList = new Administration.List.AccountList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
        }

        private void btnsave(object sender, EventArgs e)
        {
            if (Date.Text.Equals(string.Empty))
            {
                MessageBox.Show("Date can not be blank!");
                return;
            }

            CurrencyConversionModel  objcurconv = new CurrencyConversionModel();

            objcurconv.Date = Convert.ToDateTime(Date.Text.Trim());

            bool isSuccess = objCurcov.SaveCurrencyconversion(objcurconv);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (Date.Text.Equals(string.Empty))
            {
                MessageBox.Show("Date can not be blank!");
                return;
            }

            CurrencyConversionModel objcurconv = new CurrencyConversionModel();

            objcurconv.Date = Convert.ToDateTime(Date.Text.Trim());

            bool isSuccess = objCurcov.SaveCurrencyconversion(objcurconv);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }
        }
    }
}
