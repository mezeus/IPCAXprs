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

namespace IPCAUI.Transaction.List
{
    public partial class ContraVouchersList : Form
    {
        ContraVoucherBL objCVBL = new ContraVoucherBL();
        public ContraVouchersList()
        {
          
            InitializeComponent();
        }

        private void ContraVouchersList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.ListModel> lstContra = objCVBL.GetAllContraVoucher();
            dvgContraList.DataSource = lstContra;

        }

        private void dvgContraDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue=='\r')
            {
                ListModel lstContra;

                lstContra = (ListModel)dvgContraDetails.GetRow(dvgContraDetails.FocusedRowHandle);
                Transactions.ContraVoucher.Contra_Id = lstContra.Id;

                this.Close();
            }           
        }

        private void dvgContraDetails_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            ListModel lstContra;

            lstContra = (ListModel)dvgContraDetails.GetRow(dvgContraDetails.FocusedRowHandle);
            Transactions.ContraVoucher.Contra_Id = lstContra.Id;

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
