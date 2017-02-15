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
    public partial class ReceiptVouchersList : Form
    {
        RecieptVoucherBL objRecbl = new RecieptVoucherBL();
        public ReceiptVouchersList()
        {
          
            InitializeComponent();
        }

        private void ReceiptVouchersList_Load(object sender, EventArgs e)
        {
            List<ListModel> lstReceipt = objRecbl.GetAllRecieptVoucher();
            dvgReceiptMain.DataSource = lstReceipt;

        }
               

        private void dvgReceiptDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue=='\r')
            {
                ListModel lstReceipt;

                lstReceipt = (ListModel)dvgReceiptDetails.GetRow(dvgReceiptDetails.FocusedRowHandle);
                Transactions.ReceiptVoucher.Recpt_Id = lstReceipt.Id;

                this.Close();
            }
        }

        private void dvgReceiptDetails_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            ListModel lstReceipt;

            lstReceipt = (ListModel)dvgReceiptDetails.GetRow(dvgReceiptDetails.FocusedRowHandle);
            Transactions.ReceiptVoucher.Recpt_Id = lstReceipt.Id;

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
