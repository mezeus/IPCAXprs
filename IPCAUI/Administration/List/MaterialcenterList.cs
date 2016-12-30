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

        private void dvgMaterialcentList_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void dvgMaterialcentList_KeyDown_1(object sender, KeyEventArgs e)
        {
            
        }

        private void dvgMaterialcentList_KeyPress(object sender, KeyPressEventArgs e)
        {
            MaterialCentreMasterModel lstMaterial;

            lstMaterial = (MaterialCentreMasterModel)dvgMaterialcenterDet.GetRow(dvgMaterialcenterDet.FocusedRowHandle);
            MaterialCenter.MCId = lstMaterial.MC_Id;
            this.Close();
        }
    }
}
