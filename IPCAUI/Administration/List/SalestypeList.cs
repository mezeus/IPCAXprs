using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eSunSpeedDomain;
using eSunSpeed.BusinessLogic;

namespace IPCAUI.Administration.List
{
    public partial class SalestypeList : Form
    {
        SaleTypeBL objSaleBL = new SaleTypeBL();
        public SalestypeList()
        {
            InitializeComponent();
        }

        private void SalestypeList_Load(object sender, EventArgs e)
        {
            List<SaleTypeModel> lstSales = objSaleBL.GetAllSaleType();
            dvgSaletypeList.DataSource = lstSales;
        }

        private void dvgSaletypeList_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void dvgSaletypeDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == '\r')
            {
                SaleTypeModel lstSales;

                lstSales = (SaleTypeModel)dvgSaletypeDetails.GetRow(dvgSaletypeDetails.FocusedRowHandle);
                SaleType.SalesId = lstSales.Sale_Id;

                this.Close();
            }
        }

        private void dvgSaletypeDetails_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            SaleTypeModel lstSales;

            lstSales = (SaleTypeModel)dvgSaletypeDetails.GetRow(dvgSaletypeDetails.FocusedRowHandle);
            SaleType.SalesId = lstSales.Sale_Id;

            this.Close();
        }
    }
}
