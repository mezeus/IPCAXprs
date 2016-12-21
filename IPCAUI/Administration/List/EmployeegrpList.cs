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
            Fill();
        }

        private void Fill()
        {
            DataSets.EmployeeList.EmployeeListDtDataTable dt = new DataSets.EmployeeList.EmployeeListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.EmployeeList.EmployeeListDtRow dr = dt.NewEmployeeListDtRow();

                dr[0] = "Test Name" + i;
                dr[1] = "Alias Name" +i ;
                dr[2] = "Parent Group test data" +i;
                dr[3] = "16-08-2015" +i;
                //dr[4] = "10.45" +i;

                dt.AddEmployeeListDtRow(dr);
            }
            DataSets.AccountList ds = new DataSets.AccountList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            employeeListDtBindingSource.DataSource = src;
            
        }

        private void dvgEmployeeList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
