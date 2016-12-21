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
    public partial class SalaraycomponentList : Form
    {
        public SalaraycomponentList()
        {
            InitializeComponent();
        }

        private void SalaraycomponentList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataSets.SalaraycomponentList.SalaraycomponentListDtDataTable dt = new DataSets.SalaraycomponentList.SalaraycomponentListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.SalaraycomponentList.SalaraycomponentListDtRow dr = dt.NewSalaraycomponentListDtRow();

                dr[0] = "Test Name" + i;
                dr[1] = "Alias Name" +i ;
                dr[2] = "Parent Group test data" +i;
                //dr[3] = "12.56" +i;
                //dr[4] = "10.45" +i;

                dt.AddSalaraycomponentListDtRow(dr);
            }
            DataSets.SalaraycomponentList ds = new DataSets.SalaraycomponentList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            salaraycomponentListDtBindingSource.DataSource = src;
            
        }

        private void dvgSalaraycomponentList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
