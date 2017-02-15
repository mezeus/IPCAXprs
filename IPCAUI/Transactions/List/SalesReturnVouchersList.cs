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
    public partial class SalesReturnVouchersList : Form
    {
        SalesReturnVoucherBL objSRBL = new SalesReturnVoucherBL();
        public SalesReturnVouchersList()
        {
          
            InitializeComponent();
        }

        private void SalesReturnVouchersList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.TransListModel> lstSaleRet = objSRBL.GetAllSalesReturnMaster();
            dvgSaleRetList.DataSource = lstSaleRet;
        }

        private void dvgSaleRetListDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == '\r')
            {
                TransListModel lstSaleRet;

                lstSaleRet = (TransListModel)dvgSaleRetListDetails.GetRow(dvgSaleRetListDetails.FocusedRowHandle);
                Transactions.SalesReturn.SalesRetId = lstSaleRet.trans_sales_id;
                this.Close();
            }   
        }

        private void dvgSaleRetListDetails_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            TransListModel lstSaleRet;

            lstSaleRet = (TransListModel)dvgSaleRetListDetails.GetRow(dvgSaleRetListDetails.FocusedRowHandle);
            Transactions.SalesReturn.SalesRetId = lstSaleRet.trans_sales_id;
            this.Close();
        }
    }
}
