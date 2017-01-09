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
    public partial class ParameterizedStock : Form
    {
        DataTable dt = new DataTable();
        public ParameterizedStock()
        {
            InitializeComponent();
        }

        private void ParameterizedStock_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("S.No");
            dt.Columns.Add("Item");
            dt.Columns.Add("Qty");
            dvgParamStock.DataSource = dt;
        }
    }
}
