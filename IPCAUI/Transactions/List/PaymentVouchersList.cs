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
    public partial class PaymentVouchersList : Form
    {
        PaymentVoucherBL objPayBl = new PaymentVoucherBL();
        public PaymentVouchersList()
        {
          
            InitializeComponent();
        }

        private void PaymentVouchersList_Load(object sender, EventArgs e)
        {
            List<ListModel> lstPayment = objPayBl.GetAllPaymentVoucher();
            dvgPaymentList.DataSource = lstPayment;

        }      
        private void dvgPaymentListDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue=='\r')
            {
                ListModel lstPaymet;

                lstPaymet = (ListModel)dvgPaymentListDetails.GetRow(dvgPaymentListDetails.FocusedRowHandle);
                Transactions.PaymentVoucher.Payid = lstPaymet.Id;

                this.Close();
            }           
        }

        private void dvgPaymentListDetails_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            ListModel lstPaymet;

            lstPaymet = (ListModel)dvgPaymentListDetails.GetRow(dvgPaymentListDetails.FocusedRowHandle);
            Transactions.PaymentVoucher.Payid = lstPaymet.Id;

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
