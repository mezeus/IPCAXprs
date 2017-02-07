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
    public partial class ItemgroupList : Form
    {
        ItemGroupMasterBL objgroupbl = new ItemGroupMasterBL();
        public ItemgroupList()
        {
            InitializeComponent();
        }

        private void ItemgroupList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.ItemGroupMasterModel> lstGroups = objgroupbl.GetAllItemGroup();
            dvgItemgrpList.DataSource = lstGroups;
        }
        
        private void dvgItemgrpList_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void dvgItemgrpDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void dvgItemgrpDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue=='\r')
            {
                ItemGroupMasterModel lstItemsGroups;

                lstItemsGroups = (ItemGroupMasterModel)dvgItemgrpDetails.GetRow(dvgItemgrpDetails.FocusedRowHandle);
                Itemgroup.ItemgrpId = lstItemsGroups.IGM_id;

                this.Close();
            }          
        }

        private void dvgItemgrpDetails_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            ItemGroupMasterModel lstItemsGroups;

            lstItemsGroups = (ItemGroupMasterModel)dvgItemgrpDetails.GetRow(dvgItemgrpDetails.FocusedRowHandle);
            Itemgroup.ItemgrpId = lstItemsGroups.IGM_id;

            this.Close();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
