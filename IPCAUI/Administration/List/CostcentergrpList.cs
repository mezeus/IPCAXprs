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
    public partial class CostcentergrpList : Form
    {
        CostCentreGroupBL objCGbl = new CostCentreGroupBL();
        public CostcentergrpList()
        {
            InitializeComponent();
        }

        private void CostcentergrpList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.CostCentreGroupModel> lstGroups = objCGbl.GetAllCostCentreGroups();
            dvgCCgrpList.DataSource = lstGroups;
        }

        private void dvgCCgrpList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
