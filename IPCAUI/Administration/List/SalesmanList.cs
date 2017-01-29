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
    public partial class SalesmanList : Form
    {
        SalesManBL objSalebl = new SalesManBL();
        public SalesmanList()
        {
            InitializeComponent();
        }

        private void SalesmanList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.SalesManModel> lstsaleman = objSalebl.GetAllSalesMan();
            dvgSalesmanList.DataSource = lstsaleman;
        }

        private void dvgSalesmanList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }

        private void dvgSalesManDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == '\r')
            {
                SalesManModel lstSalesMan;

                lstSalesMan = (SalesManModel)dvgSalesManDetails.GetRow(dvgSalesManDetails.FocusedRowHandle);
                Salesman.SMId = lstSalesMan.SalesMan_Id;
                this.Close();
            }
            return;
        }

        private void dvgSalesManDetails_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            SalesManModel lstSalesMan;

            lstSalesMan = (SalesManModel)dvgSalesManDetails.GetRow(dvgSalesManDetails.FocusedRowHandle);
            Salesman.SMId = lstSalesMan.SalesMan_Id;

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
