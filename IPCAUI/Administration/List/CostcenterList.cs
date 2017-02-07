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
    public partial class CostcenterList : Form
    {
        CostCentreMasterBL objccBL = new CostCentreMasterBL(); 
        public CostcenterList()
        {
            InitializeComponent();
        }

        private void CostcenterList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.CostCentreMasterModel> lstccmaster = objccBL.GetAllCostCentreMaster();
            dvgCostcenter.DataSource = lstccmaster;
        }

        private void dvgCostcenter_KeyDown(object sender, KeyEventArgs e)
        {
            //this.Close();
        }

        private void dvgCostcenterDetails_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void dvgCostcenterDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void dvgCostcenterDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue=='\r')
            {
                CostCentreMasterModel lstItems;

                lstItems = (CostCentreMasterModel)dvgCostcenterDetails.GetRow(dvgCostcenterDetails.FocusedRowHandle);
                Costcenter.costId = lstItems.CCM_ID;

                this.Close();
            }       
        }

        private void dvgCostcenterDetails_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            CostCentreMasterModel lstItems;

            lstItems = (CostCentreMasterModel)dvgCostcenterDetails.GetRow(dvgCostcenterDetails.FocusedRowHandle);
            Costcenter.costId = lstItems.CCM_ID;

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
