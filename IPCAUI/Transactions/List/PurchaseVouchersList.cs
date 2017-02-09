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
    public partial class PurchaseVouchersList : Form
    {
        PurchaseVoucherBL objPurcBL = new PurchaseVoucherBL();
        public PurchaseVouchersList()
        {
          
            InitializeComponent();
        }

        private void PurchaseVouchersList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.TransListModel> lstPurchase = objPurcBL.GetAllPurchaseVoucherMaster();
            dvgPurcList.DataSource = lstPurchase;

        }

        private void dvgPurcListDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue=='\r')
            {
                TransListModel lstPurchase;

                lstPurchase = (TransListModel)dvgPurcListDetails.GetRow(dvgPurcListDetails.FocusedRowHandle);
                Transactions.Purhcasevoucher.PurcId = lstPurchase.PurcVchId;
                this.Close();
            }
            
        }

        private void dvgPurcListDetails_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            TransListModel lstPurchase;

            lstPurchase = (TransListModel)dvgPurcListDetails.GetRow(dvgPurcListDetails.FocusedRowHandle);
            Transactions.Purhcasevoucher.PurcId = lstPurchase.PurcVchId;
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
