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
    public partial class SalestypeList : Form
    {
        public SalestypeList()
        {
            InitializeComponent();
        }

        private void SalestypeList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataSets.SalestypeList.SalestypeListDtDataTable dt = new DataSets.SalestypeList.SalestypeListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.SalestypeList.SalestypeListDtRow dr = dt.NewSalestypeListDtRow();

                dr[0] = "Test Name" + i;
                dr[1] = "Centeral";
                //dr[2] = "Parent Group test data" +i;
                //dr[3] = "12.56" +i;
                //dr[4] = "10.45" +i;

                dt.AddSalestypeListDtRow(dr);
            }
            DataSets.SalestypeList ds = new DataSets.SalestypeList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            salestypeListDtBindingSource.DataSource = src;
            
        }

        private void dvgSaletypeList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
