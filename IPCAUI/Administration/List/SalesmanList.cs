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
    }
}
