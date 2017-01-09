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
    public partial class MRPwiseDetails : Form
    {
        DataTable dt = new DataTable();
        public MRPwiseDetails()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MRPwiseDetails_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("MRP");
            dt.Columns.Add("SalePrice");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Amount");

            dvgMrpwise.DataSource = dt;
        }
    }
}
