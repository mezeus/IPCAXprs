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

namespace IPCAUI.Administration.List
{
    public partial class CurrencyList : Form
    {
        CurrencyBL objcurrbl = new CurrencyBL();
        public CurrencyList()
        {
            InitializeComponent();
        }

        private void CurrencyList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.CurrencyMasterModel> lstCurrency = objcurrbl.GetAllCurrency();
            dvgCurrencyList.DataSource = lstCurrency;
        }

        private void dvgCurrencyList_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void dvgCurrencyDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void dvgCurrencyDetails_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            CurrencyMasterModel lstCurrency;

            lstCurrency = (CurrencyMasterModel)dvgCurrencyDetails.GetRow(dvgCurrencyDetails.FocusedRowHandle);
            Currencyadd.CurrecyId = lstCurrency.CM_ID;

            this.Close();
        }

        private void dvgCurrencyDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == '\r')
            {
                CurrencyMasterModel lstCurrency;

                lstCurrency = (CurrencyMasterModel)dvgCurrencyDetails.GetRow(dvgCurrencyDetails.FocusedRowHandle);
                Currencyadd.CurrecyId = lstCurrency.CM_ID;

                this.Close();
            }
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
