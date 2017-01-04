using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eSunSpeed.BusinessLogic;
using eSunSpeedDomain;


namespace IPCAUI.Administration.List
{
    public partial class ItemmasterList : Form
    {
        eSunSpeed.BusinessLogic.ItemMasterBL objitembl = new ItemMasterBL();
        public ItemmasterList()
        {
            InitializeComponent();
        }

        private void ItemmasterList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.ItemMasterModel> lstmasters = objitembl.GetAllItems();
            dvgItemmasterList.DataSource = lstmasters;
        }

        private void dvgItemmasterList_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void dvgItemDetails_KeyDown(object sender, KeyEventArgs e)
        {
            ItemMasterModel lstItems;

            lstItems = (ItemMasterModel)dvgItemDetails.GetRow(dvgItemDetails.FocusedRowHandle);
            ItemMasterNew.Item_Id = lstItems.ItemId;
            this.Close();
        }
    }
}
