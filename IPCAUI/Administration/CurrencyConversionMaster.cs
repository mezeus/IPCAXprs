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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;

namespace IPCAUI.Administration
{
    public partial class CurrencyConversionMaster : DevExpress.XtraEditors.XtraForm
    {
        CurrencyConversionBL objConBal = new CurrencyConversionBL();
        CurrencyBL objCurrencyBL = new CurrencyBL();
        public static int Con_Id = 0;
        DataTable dt = new DataTable();
        public CurrencyConversionMaster()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dtDate.Text.Equals(string.Empty))
            {
                MessageBox.Show("Date can not be blank!");
                return;
            }
            CurrencyConversionModel objcurconv = new CurrencyConversionModel();
            objcurconv.Date = Convert.ToDateTime(dtDate.Text.Trim());
            CurrencyConversionDetailsModel objCurrency;
            List<CurrencyConversionDetailsModel> lstCurrency = new List<CurrencyConversionDetailsModel>();

            for (int i = 0; i < dvgCurrencyConvDetails.DataRowCount; i++)
            {
                DataRow row = dvgCurrencyConvDetails.GetDataRow(i);

                objCurrency = new CurrencyConversionDetailsModel();
                objCurrency.Currency = row["Currency"].ToString();
                objCurrency.StandardRate =Convert.ToDecimal(row["TandardRate"].ToString());
                objCurrency.SellingRate = Convert.ToDecimal(row["SellingRate"].ToString());
                objCurrency.BuyingRate = Convert.ToDecimal(row["BuyingRate"].ToString());
                lstCurrency.Add(objCurrency);
            }
            objcurconv.CurrenyDetails = lstCurrency;

            bool isSuccess = objConBal.SaveCurrencyconversion(objcurconv);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                ClearFormValues();
                Con_Id = 0;
            }
        }
        private void CurrencyConversionMaster_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Currency");
            dt.Columns.Add("TandardRate");
            dt.Columns.Add("SellingRate");
            dt.Columns.Add("BuyingRate");
            dt.Columns.Add("id");
            dt.Columns.Add("ParentId");
            dvgCurrencyConver.DataSource = dt;
            dtDate.Focus();
            RepositoryItemLookUpEdit CurrencyLookup = new RepositoryItemLookUpEdit();
            List<CurrencyMasterModel> lstCurrency = objCurrencyBL.GetAllCurrency();
            List<string> lstSymbols = new List<string>();
            foreach(CurrencyMasterModel objcurrency in lstCurrency)
            {
                lstSymbols.Add(objcurrency.Symbol);
            }
            CurrencyLookup.DataSource = lstSymbols;
            CurrencyLookup.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            CurrencyLookup.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            CurrencyLookup.AutoSearchColumnIndex = 1;
            dvgCurrencyConvDetails.Columns["Currency"].ColumnEdit = CurrencyLookup;
            dvgCurrencyConvDetails.BestFitColumns();

            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }

        private void dvgCurrencyConvDetails_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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

        private void ListCurrencyCon_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.CurrencyconversionList frmList = new Administration.List.CurrencyconversionList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
            FillCurrencyConversionInfo();
        }
        private void FillCurrencyConversionInfo()
        {
            if(Con_Id==0)
            {
                dtDate.Focus();
                lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                return;
            }
            List<CurrencyConversionModel> objcurrency = objConBal.GetCurrencyConversionbyId(Con_Id);

            dtDate.Text = objcurrency.FirstOrDefault().Date.ToString();

            dt.Rows.Clear();
            DataRow dr;

            foreach (CurrencyConversionDetailsModel objmod in objcurrency.FirstOrDefault().CurrenyDetails)
            {
                dr = dt.NewRow();

                dr["Currency"] = objmod.Currency;
                dr["TandardRate"] = objmod.StandardRate;
                dr["SellingRate"] = objmod.SellingRate;
                dr["BuyingRate"] = objmod.BuyingRate;
                dr["ParentId"] = objmod.ParentId;
                dr["id"] = objmod.id;
                dt.Rows.Add(dr);
            }
            dvgCurrencyConver.DataSource = dt;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            dtDate.Focus();
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CurrencyConversionModel objcurconv = new CurrencyConversionModel();
            objcurconv.Date = Convert.ToDateTime(dtDate.Text.Trim());
            CurrencyConversionDetailsModel objCurrency;
            List<CurrencyConversionDetailsModel> lstCurrency = new List<CurrencyConversionDetailsModel>();

            for (int i = 0; i < dvgCurrencyConvDetails.DataRowCount; i++)
            {
                DataRow row = dvgCurrencyConvDetails.GetDataRow(i);

                objCurrency = new CurrencyConversionDetailsModel();
                objCurrency.Currency = row["Currency"].ToString();
                objCurrency.StandardRate = Convert.ToDecimal(row["TandardRate"].ToString());
                objCurrency.SellingRate = Convert.ToDecimal(row["SellingRate"].ToString());
                objCurrency.BuyingRate = Convert.ToDecimal(row["BuyingRate"].ToString());
                if(Con_Id!=0)
                {
                    objCurrency.id=Convert.ToInt32(row["id"].ToString()==string.Empty?"0":row["id"].ToString());
                    objCurrency.ParentId = Convert.ToInt32(row["ParentId"].ToString()==string.Empty?"0": row["ParentId"].ToString());
                }
                lstCurrency.Add(objCurrency);
            }
            objcurconv.CurrenyDetails = lstCurrency;
            objcurconv.CcID = Con_Id;
            bool isSuccess = objConBal.UpdateCurrencyconversion(objcurconv);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
                ClearFormValues();
                Con_Id = 0;
                Administration.List.CurrencyconversionList frmList = new Administration.List.CurrencyconversionList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                FillCurrencyConversionInfo();
            }
        }
        private void ClearFormValues()
        {
            dtDate.Text = string.Empty;
            dt.Rows.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDelete = objConBal.DeleteCurrencyConversion(Con_Id);
            if (isDelete)
            {
                MessageBox.Show("Delete Successfully!");
                ClearFormValues();
                Con_Id = 0;
                Administration.List.CurrencyconversionList frmList = new Administration.List.CurrencyconversionList();
                frmList.StartPosition = FormStartPosition.CenterScreen;

                frmList.ShowDialog();
                FillCurrencyConversionInfo();
            }
        }

        private void btnNewEntery_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ClearFormValues();
            Con_Id = 0;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }

        private void dvgCurrencyConvDetails_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (e.FocusedColumn.FieldName == "Currency")
            {
                dvgCurrencyConvDetails.ShowEditor();
                ((LookUpEdit)dvgCurrencyConvDetails.ActiveEditor).ShowPopup();

            }
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
