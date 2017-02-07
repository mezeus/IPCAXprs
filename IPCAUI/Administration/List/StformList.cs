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
    public partial class StformList : Form
    {
        STFormMasterBL objStbl = new STFormMasterBL();
        public StformList()
        {
            InitializeComponent();
        }

        private void StformList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.STFormMasterModel> lstStforms = objStbl.GetAllSTF();
            dvgStformList.DataSource = lstStforms;
        }

        

        private void dvgStformList_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void dvgStformDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == '\r')
            {
                STFormMasterModel lstStform;

                lstStform = (STFormMasterModel)dvgStformDetails.GetRow(dvgStformDetails.FocusedRowHandle);
                Stformmaster.ST_Id = lstStform.STF_Id;

                this.Close();
            }
        }

        private void dvgStformDetails_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            STFormMasterModel lstStform;

            lstStform = (STFormMasterModel)dvgStformDetails.GetRow(dvgStformDetails.FocusedRowHandle);
            Stformmaster.ST_Id = lstStform.STF_Id;

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
