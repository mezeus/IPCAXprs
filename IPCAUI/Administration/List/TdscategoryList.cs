﻿using System;
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
    public partial class TdscategoryList : Form
    {
        TdsModelBL objtdsbl = new TdsModelBL();
        public TdscategoryList()
        {
            InitializeComponent();
        }

        private void TdscategoryList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.TdsModel> lstTDS = objtdsbl.GetListofTDS();
            dvgTdscategoryList.DataSource = lstTDS;
        }

        private void dvgTaxcategoryList_Click(object sender, EventArgs e)
        {

        }

        private void dvgTaxcategoryList_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void dvgTdscategoryList_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void dvgTdsCatDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            TdsModel lstTds;

            lstTds = (TdsModel)dvgTdsCatDetails.GetRow(dvgTdsCatDetails.FocusedRowHandle);
            TDSCategory.TdsId = lstTds.Tds_Id;

            this.Close();
        }
    }
}
