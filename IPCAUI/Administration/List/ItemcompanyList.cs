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
    public partial class ItemcompanyList : Form
    {
        ItemCompanyMasterBL objcompanybl = new ItemCompanyMasterBL();
        public ItemcompanyList()
        {
            InitializeComponent();
        }

        private void ItemcompanyList_Load(object sender, EventArgs e)
        {
            
            List<ItemCompanyMasterModel> lstCompanys = objcompanybl.GetAllItemCompany();
            dvgItemCompList.DataSource = lstCompanys;
        }
        
        private void dvgItemcompDetails_KeyDown(object sender, KeyEventArgs e)
        {
            ItemCompanyMasterModel lstItemsCompanys;

            lstItemsCompanys = (ItemCompanyMasterModel)dvgItemcompDetails.GetRow(dvgItemcompDetails.FocusedRowHandle);
            ItemCompany.ItemcompId = lstItemsCompanys.ICM_id;

            this.Close();
        }
    }
}
