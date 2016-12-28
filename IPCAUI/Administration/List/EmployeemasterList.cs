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

namespace IPCAUI.Administration.List
{
    public partial class EmployeemasterList : Form
    {
        EmployeeMasterBL objmasterbl = new EmployeeMasterBL();
        public EmployeemasterList()
        {
            InitializeComponent();
        }

        private void EmployeemasterList_Load(object sender, EventArgs e)
        {
            //List<eSunSpeedDomain.EmployeeMasterModel> lstemployeemaster = objmasterbl.grt();
            //dvgAccList.DataSource = lstGroups;
        }

        private void dvgEmployeemstList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
