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
    public partial class AuthorList : Form
    {
        public AuthorList()
        {
            InitializeComponent();
        }

        private void AuthorList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataSets.AuthorList.AuthorListDtDataTable dt = new DataSets.AuthorList.AuthorListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.AuthorList.AuthorListDtRow dr = dt.NewAuthorListDtRow();

                dr[0] = "Test Name" + i;
                dr[1] = "Alias Name" +i ;
                dr[2] = "Parent Group test data" +i;
                //dr[3] = "12.56" +i;
                //dr[4] = "10.45" +i;

                dt.AddAuthorListDtRow(dr);
            }
            DataSets.AuthorList ds = new DataSets.AuthorList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            authorListDtBindingSource.DataSource = src;
            
        }
    }
}
