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
    public partial class PurchaseReturnVouchersList : Form
    {
        PurchaseReturnVoucherBL objPRBL = new PurchaseReturnVoucherBL();
        public PurchaseReturnVouchersList()
        {
          
            InitializeComponent();
        }

        private void PurchaseReturnVouchersList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.TransListModel> lstPurcRet = objPRBL.GetAllPurchaseReturnDetails();
            dvgPurcRetList.DataSource = lstPurcRet;

        }

        private void dvgPurcRetDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue=='\r')
            {
                TransListModel lstPurRet;

                lstPurRet = (TransListModel)dvgPurcRetDetails.GetRow(dvgPurcRetDetails.FocusedRowHandle);
                Transactions.PurhcaseReturnvoucher.PurcRetId = lstPurRet.PurcRetId;
                this.Close();
            }
        }

        private void dvgPurcRetDetails_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            TransListModel lstPurRet;

            lstPurRet = (TransListModel)dvgPurcRetDetails.GetRow(dvgPurcRetDetails.FocusedRowHandle);
            Transactions.PurhcaseReturnvoucher.PurcRetId = lstPurRet.PurcRetId;
            this.Close();
        }
    }
}
