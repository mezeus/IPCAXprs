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
    public partial class BillMaterialList : Form
    {
        BillsofMaterialBL objbal = new BillsofMaterialBL();
        public BillMaterialList()
        {
            InitializeComponent();
        }

        private void BillMaterialList_Load(object sender, EventArgs e)
        {

            List<eSunSpeedDomain.BillofMaterialModel> lstBillMaterials = objbal.GetAllBillofMaterial();
            dvgBillList.DataSource = lstBillMaterials;
            
        }

        private void dvgBillmaterialDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            BillofMaterialModel lstBillmaterials;

            lstBillmaterials = (BillofMaterialModel)dvgBillmaterialDetails.GetRow(dvgBillmaterialDetails.FocusedRowHandle);
            BillsofMaterial.BMId = lstBillmaterials.Bom_Id;

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
