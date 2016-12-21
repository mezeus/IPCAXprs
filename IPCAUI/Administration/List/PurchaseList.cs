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
    public partial class PurchaseList : Form
    {
        public PurchaseList()
        {
            InitializeComponent();
        }

        private void PurchaseList_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            DataSets.PurchaseList.PurchaseListDtDataTable dt = new DataSets.PurchaseList.PurchaseListDtDataTable();

            for (int i = 0; i <= 50; i++)
            {
                DataSets.PurchaseList.PurchaseListDtRow dr = dt.NewPurchaseListDtRow();

                dr[0] = "Test Name" + i;
                dr[1] = "Alias Name" +i ;
                dr[2] = "Purchase Type List";
                //dr[3] = "12.56" +i;
                //dr[4] = "10.45" +i;

                dt.AddPurchaseListDtRow(dr);
            }
            DataSets.PurchaseList ds = new DataSets.PurchaseList();
            ds.Tables.Clear();

            ds.Tables.Add(dt);

            BindingSource src = new BindingSource();
            src.DataSource = ds.Tables[0];

            purchaseListDtBindingSource.DataSource = src;
            
        }

        private void dvgPurchaseList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
