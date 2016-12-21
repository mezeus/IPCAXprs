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
    public partial class ReferencegroupList : Form
    {
        public ReferencegroupList()
        {
            InitializeComponent();
        }

        private void ReferencegroupList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataSets.ReferencegroupList.ReferencegroupListDtDataTable dt = new DataSets.ReferencegroupList.ReferencegroupListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.ReferencegroupList.ReferencegroupListDtRow dr = dt.NewReferencegroupListDtRow();

                dr[0] = "Reference Name" + i;
                //dr[1] = "Alias Name" +i ;
                //dr[2] = "Parent Group test data" +i;
                //dr[3] = "12.56" +i;
                //dr[4] = "10.45" +i;

                dt.AddReferencegroupListDtRow(dr);
            }
            DataSets.ReferencegroupList ds = new DataSets.ReferencegroupList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            referencegroupListDtBindingSource.DataSource = src;
            
        }

        private void dvgReferencegroupList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
