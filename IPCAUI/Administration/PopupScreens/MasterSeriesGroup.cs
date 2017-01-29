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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using eSunSpeed.BusinessLogic;
using DevExpress.XtraEditors;

namespace IPCAUI.Administration.PopupScreens
{
    public partial class MasterSeriesGroup : Form
    {
        DataTable dt = new DataTable();
        MasterseriesBL objMSbl = new MasterseriesBL();
        public static string FormName =string.Empty;
        public MasterSeriesGroup()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            MasterseriesModel objSeries;
            Account.objAccount.MasterSeries = new List<MasterseriesModel>();
            Accountgroup.objAccGroup.AGMasterSeries = new List<MasterseriesModel>();
            //Loop through the grid and get the values
            for (int i = 0; i < dvgmasterSGDetails.DataRowCount; i++)
            {
                DataRow row = dvgmasterSGDetails.GetDataRow(i);
                objSeries = new MasterseriesModel();
                objSeries.MasterName =row["MasterName"].ToString() == null? string.Empty : row["MasterName"].ToString();
                if (Account.objAccount.AccountId != 0 ||Accountgroup.objAccGroup.GroupId!=0)
                {
                    objSeries.MasterId = Convert.ToInt32(row["MasterId"].ToString() == string.Empty ? "0" : row["MasterId"]);
                    objSeries.ParentId = Convert.ToInt32(row["ParentId"].ToString() == string.Empty ? "0" : row["ParentId"]);
                }
                Account.objAccount.MasterSeries.Add(objSeries);
                Accountgroup.objAccGroup.AGMasterSeries.Add(objSeries);
            }
            this.Close();
        }

        private void MasterSeriesGroup_Load(object sender, EventArgs e)
        {
            dvgmasterSG.Focus();
            dt.Columns.Add("MasterName");
            dt.Columns.Add("MasterId");
            dt.Columns.Add("ParentId");
            dvgmasterSG.DataSource = dt;
            LoadMasterSeriesColumns();
            LoadMasterSeriesDetails();
        }
        private void LoadMasterSeriesDetails()
        {
            if (Account.groupId != 0)
            {
                dt.Rows.Clear();
                DataRow dr;
                foreach (MasterseriesModel objMaster in Account.objAccount.MasterSeries)
                {
                    dr = dt.NewRow();

                    dr["MasterName"] = objMaster.MasterName;
                    dr["MasterId"] = objMaster.MasterId;
                    dr["ParentId"] = objMaster.ParentId;
                    dt.Rows.Add(dr);
                }
                dvgmasterSG.DataSource = dt;
            }
            if(Accountgroup.groupId != 0)
            {
                dt.Rows.Clear();
                DataRow dr;
                foreach (MasterseriesModel objMaster in Accountgroup.objAccGroup.AGMasterSeries)
                {
                    dr = dt.NewRow();

                    dr["MasterName"] = objMaster.MasterName;
                    dr["MasterId"] = objMaster.MasterId;
                    dr["ParentId"] = objMaster.ParentId;
                    dt.Rows.Add(dr);
                }
                dvgmasterSG.DataSource = dt;
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            if(keyData==Keys.F3)
            {
                if(dvgmasterSGDetails.FocusedColumn.FieldName=="MasterName")
                {
                    FormName = "MasterSeriesGroup";
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void LoadMasterSeriesColumns()
        {
            RepositoryItemLookUpEdit MasterLookup = new RepositoryItemLookUpEdit();
            List<MasterseriesModel> lstMasters = objMSbl.GetListofMasterSeries();
            List<string> lstSeries = new List<string>();
            foreach (MasterseriesModel objMaster in lstMasters)
            {
                lstSeries.Add(objMaster.MasterName);
            }
            MasterLookup.DataSource = lstSeries;
            MasterLookup.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            MasterLookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            MasterLookup.AutoSearchColumnIndex = 1;
            dvgmasterSGDetails.Columns["MasterName"].ColumnEdit = MasterLookup;
            dvgmasterSGDetails.BestFitColumns();
        }

        private void dvgmasterSGDetails_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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

        private void dvgmasterSGDetails_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "MasterName")
            {
                dvgmasterSGDetails.ShowEditor();
                ((LookUpEdit)dvgmasterSGDetails.ActiveEditor).ShowPopup();

            }
        }
    }
}
