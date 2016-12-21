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
    public partial class EmployeemasterList : Form
    {
        public EmployeemasterList()
        {
            InitializeComponent();
        }

        private void EmployeemasterList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataSets.EmployeemstList.EmployeemstListDtDataTable dt = new DataSets.EmployeemstList.EmployeemstListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.EmployeemstList.EmployeemstListDtRow dr = dt.NewEmployeemstListDtRow();

                dr[0] = "Raju" + i;
                dr[1] = "Raju D" +i ;
                dr[2] = "Bank group" +i;
                dr[3] = "16-08-2016" +i;
                //dr[4] = "10.45" +i;

                dt.AddEmployeemstListDtRow(dr);
            }
            DataSets.EmployeemstList ds = new DataSets.EmployeemstList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            employeemstListDtBindingSource.DataSource = src;
            
        }

        private void dvgEmployeemstList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
