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
    public partial class ItemmasterList : Form
    {
        public ItemmasterList()
        {
            InitializeComponent();
        }

        private void ItemmasterList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataSets.ItemmasterList.ItemmsaterListDtDataTable dt = new DataSets.ItemmasterList.ItemmsaterListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.ItemmasterList.ItemmsaterListDtRow dr = dt.NewItemmsaterListDtRow();

                dr[0] = "Test Name" + i;
                dr[1] = "Alias Name" +i ;
                dr[2] = "Parent Group test data" +i;
                dr[3] = "200" +i;
                dr[4] = "Pics";

                dt.AddItemmsaterListDtRow(dr);
            }
            DataSets.ItemmasterList ds = new DataSets.ItemmasterList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            itemmsaterListDtBindingSource.DataSource = src;
            
        }

        private void dvgItemmasterList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
