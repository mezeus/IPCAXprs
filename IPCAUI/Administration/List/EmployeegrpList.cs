using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPCAUI.Administration.List
{
    public partial class EmployeegrpList : Form
    {
        public EmployeegrpList()
        {
            InitializeComponent();
        }

        private void EmployeegrpList_Load(object sender, EventArgs e)
        {
           
        }


        private void dvgEmployeeList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
