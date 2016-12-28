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
            dvgBillSunadtList.DataSource = lstbillsundary;
        }

        private void dvgBillSunadtList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
