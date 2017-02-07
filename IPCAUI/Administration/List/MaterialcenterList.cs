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
    public partial class MaterialcenterList : Form
    {
        MaterialCentreMasterBL objmatbl = new MaterialCentreMasterBL();
        public MaterialcenterList()
        {
            InitializeComponent();
        }

        private void MaterialcenterList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.MaterialCentreMasterModel> lstMaterial = objmatbl.GetAllMaterials();
            dvgMaterialcentList.DataSource = lstMaterial;
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

        private void dvgMaterialcenterDet_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue=='\r')
            {
                MaterialCentreMasterModel lstMaterial;

                lstMaterial = (MaterialCentreMasterModel)dvgMaterialcenterDet.GetRow(dvgMaterialcenterDet.FocusedRowHandle);
                MaterialCenter.MCId = lstMaterial.MC_Id;
                this.Close();
            }  
        }

        private void dvgMaterialcenterDet_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            MaterialCentreMasterModel lstMaterial;

            lstMaterial = (MaterialCentreMasterModel)dvgMaterialcenterDet.GetRow(dvgMaterialcenterDet.FocusedRowHandle);
            MaterialCenter.MCId = lstMaterial.MC_Id;
            this.Close();
        }
    }
}
