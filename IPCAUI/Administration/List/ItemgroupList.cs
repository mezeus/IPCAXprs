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
    public partial class ItemgroupList : Form
    {
        public ItemgroupList()
        {
            InitializeComponent();
        }

        private void ItemgroupList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataSets.ItemgroupList.ItemgroupListDtDataTable dt = new DataSets.ItemgroupList.ItemgroupListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.ItemgroupList.ItemgroupListDtRow dr = dt.NewItemgroupListDtRow();

                dr[0] = "Test Name" + i;
                dr[1] = "Alias Name" +i ;
                dr[2] = "Parent Group test data" +i;
                //dr[3] = "12.56" +i;
                //dr[4] = "10.45" +i;

                dt.AddItemgroupListDtRow(dr);
            }
            DataSets.ItemgroupList ds = new DataSets.ItemgroupList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            itemgroupListDtBindingSource.DataSource = src;
            
        }

        private void dvgItemgrpList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
