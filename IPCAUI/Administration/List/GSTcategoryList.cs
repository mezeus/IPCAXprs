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
using DevExpress.XtraGrid.Views.Grid;

namespace IPCAUI.Administration.List
{
    public partial class GSTcategoryList : Form
    {
        TaxCategory objtaxbl = new TaxCategory();
        public GSTcategoryList()
        {
            InitializeComponent();
        }

        private void GSTcategoryList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.TaxCategoryModel> lstGSTcategorys = objtaxbl.GetAllGSTCategories();
            dvgGSTcategoryList.DataSource = lstGSTcategorys;
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

        private void dvgGSTcatDetails_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "SNo")
            {
                GridView gridView = (GridView)sender;
                e.DisplayText = (gridView.GetRowHandle(e.ListSourceRowIndex) + 1).ToString();

                if (Convert.ToInt32(e.DisplayText) < 0)
                {
                    e.DisplayText = "";
                }
            }
        }

        private void dvgGSTcatDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == '\r')
            {
                TaxCategoryModel lstGSTcategory;

                lstGSTcategory = (TaxCategoryModel)dvgGSTcatDetails.GetRow(dvgGSTcatDetails.FocusedRowHandle);
                GSTDetails.GST_Id = lstGSTcategory.GST_ID;

                this.Close();
            }
        }

        private void dvgGSTcatDetails_RowClick(object sender, RowClickEventArgs e)
        {
            TaxCategoryModel lstGSTcategory;

            lstGSTcategory = (TaxCategoryModel)dvgGSTcatDetails.GetRow(dvgGSTcatDetails.FocusedRowHandle);
            GSTDetails.GST_Id = lstGSTcategory.GST_ID;

            this.Close();
        }
    }
}
