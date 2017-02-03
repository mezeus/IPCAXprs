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
using IPCAUI.Transactions;

namespace IPCAUI.Transaction.List
{
    public partial class SalesVouchersList : Form
    {
        SalesVoucherBL objSalebl = new SalesVoucherBL();
        public SalesVouchersList()
        {
          
            InitializeComponent();
        }

        private void SalesVouchersList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.TransListModel> lstSales = objSalebl.GetAllSalesVoucherMaster();
            dvgSalesVoucherList.DataSource = lstSales;

        }

        private void dvgSalesVchListDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue=='\r')
            {
                TransListModel lstSales;
                lstSales = (TransListModel)dvgSalesVchListDetails.GetRow(dvgSalesVchListDetails.FocusedRowHandle);
                SalesVoucher.SalesId= lstSales.trans_sales_id;

                this.Close();
            }
        }

        private void dvgSalesVchListDetails_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            TransListModel lstSales;
            lstSales = (TransListModel)dvgSalesVchListDetails.GetRow(dvgSalesVchListDetails.FocusedRowHandle);
            SalesVoucher.SalesId = lstSales.trans_sales_id;

            this.Close();
        }
    }
}
