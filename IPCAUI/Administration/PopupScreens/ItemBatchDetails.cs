using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPCAUI.Administration.PopupScreens
{
    public partial class ItemBatchDetails : Form
    {
        DataTable dt = new DataTable();
        public ItemBatchDetails()
        {
            InitializeComponent();
        }

        private void ItemBatchDetails_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("BatchNo");
            dt.Columns.Add("Qty");
            dt.Columns.Add("MgfDate");
            dt.Columns.Add("ExpDate");

            dvgMrpwise.DataSource = dt;
        }
    }
}
