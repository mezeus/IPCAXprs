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
    public partial class PurchaseList : Form
    {
        PurchaseTypeBL objpurcbl = new PurchaseTypeBL();
        public PurchaseList()
        {
            InitializeComponent();
        }

        private void PurchaseList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.PurchaseTypeModel> lstptype = objpurcbl.GetAllPurchaseType();
            dvgPurchaseList.DataSource = lstptype;
        }


        private void dvgPurchaseList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == '\r')
            {
                PurchaseTypeModel lstPurch;

                lstPurch = (PurchaseTypeModel)dvgPurchaseListDetails.GetRow(dvgPurchaseListDetails.FocusedRowHandle);
                PurchaseType.PurcId = lstPurch.Purch_Id;

                this.Close();
            }
        }

        private void dvgPurchaseListDetails_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            PurchaseTypeModel lstPurch;

            lstPurch = (PurchaseTypeModel)dvgPurchaseListDetails.GetRow(dvgPurchaseListDetails.FocusedRowHandle);
            PurchaseType.PurcId = lstPurch.Purch_Id;

            this.Close();
        }
    }
}
