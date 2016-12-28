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
    public partial class TaxcategoryList : Form
    {
        TaxCategory objtaxbl = new TaxCategory();
        public TaxcategoryList()
        {
            InitializeComponent();
        }

        private void TaxcategoryList_Load(object sender, EventArgs e)
        {
            List<eSunSpeedDomain.TaxCategoryModel> lsttaxcategorys = objtaxbl.GetAllTaxCategories();
            dvgTaxcategoryList.DataSource = lsttaxcategorys;
        }

        private void dvgTaxcategoryList_Click(object sender, EventArgs e)
        {

        }

        private void dvgTaxcategoryList_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
