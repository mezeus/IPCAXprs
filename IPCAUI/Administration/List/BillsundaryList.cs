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
    public partial class BillsundaryList : Form
    {
        BillSundryMaster objbillbl = new BillSundryMaster();
        public BillsundaryList()
        {
            InitializeComponent();
        }

        private void BillsundaryList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.BillSundryMasterModel> lstbillsundary = objbillbl.GetAllBillSundry();
            dvgBillSundryList.DataSource = lstbillsundary;
        }

        private void dvgBillSunadtList_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void dvgBillSundryDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue=='\r')
            {
                BillSundryMasterModel lstBillsundry;

                lstBillsundry = (BillSundryMasterModel)dvgBillSundryDetails.GetRow(dvgBillSundryDetails.FocusedRowHandle);
                BillSundaryMaster.BillsId = lstBillsundry.BS_Id;

                this.Close();
            }
            
        }

        private void dvgBillSundryDetails_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            BillSundryMasterModel lstBillsundry;

            lstBillsundry = (BillSundryMasterModel)dvgBillSundryDetails.GetRow(dvgBillSundryDetails.FocusedRowHandle);
            BillSundaryMaster.BillsId = lstBillsundry.BS_Id;

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
