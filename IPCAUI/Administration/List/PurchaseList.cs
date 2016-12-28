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
    public partial class PurchaseList : Form
    {
        PurchaseTypeBL objpbl = new PurchaseTypeBL();
        public PurchaseList()
        {
            InitializeComponent();
        }

        private void PurchaseList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.PurchaseTypeModel> lstptype = objpbl.GetAllPurchaseType();
            dvgPurchaseList.DataSource = lstptype;
        }


        private void dvgPurchaseList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
