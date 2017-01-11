using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eSunSpeedDomain;
using eSunSpeed.BusinessLogic;

namespace IPCAUI.Administration
{
    public partial class DiscountStructureMaster : Form
    {
        DataTable dtDiscount = new DataTable();
        DiscountStructure objDisBL = new DiscountStructure();
        public DiscountStructureMaster()
        {
            InitializeComponent();
        }

        private void DiscountStructureMaster_Load(object sender, EventArgs e)
        {
            tbxStrName.Focus();
            dtDiscount.Columns.Add("AccountPost");
            dtDiscount.Columns.Add("AccountHeadPost");
            dtDiscount.Columns.Add("AffectsGoods");

            dvgDisscountStr.DataSource = dtDiscount;

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
        private void btnSave_Click(object sender, EventArgs e)
        {
            DiscountStructureMasterModel objdiscount = new DiscountStructureMasterModel();

            objdiscount.StructureName = tbxStrName.Text.Trim() == null ? string.Empty : tbxStrName.Text.Trim();
            objdiscount.SimpleDiscount = false;
            objdiscount.CompoundDiscountwithSameNature = false;
            objdiscount.CompoundDiscountDifferentNature = false;
            if(rbnDiscountType.SelectedIndex==0)
            {
                objdiscount.SimpleDiscount = true;
            }
            if (rbnDiscountType.SelectedIndex == 1)
            {
                objdiscount.CompoundDiscountwithSameNature = true;
            }
            if (rbnDiscountType.SelectedIndex == 2)
            {
                objdiscount.CompoundDiscountDifferentNature = true;
            }
            objdiscount.NoOfDiscounts =Convert.ToInt32(tbxNoDiscounts.Text.Trim() == null ?"0": tbxNoDiscounts.Text.Trim());
            objdiscount.AbsoluteDiscount = false;
            objdiscount.PerMainQty = false;
            objdiscount.Percentage = false;
            objdiscount.PerAltQty = false;
            if (rbnAccountDiscount.SelectedIndex == 0)
            {
                objdiscount.AbsoluteDiscount = true;
            }
            if (rbnAccountDiscount.SelectedIndex == 1)
            {
                objdiscount.PerMainQty = true;
            }
            if (rbnAccountDiscount.SelectedIndex == 2)
            {
                objdiscount.Percentage = true;
            }
            if (rbnAccountDiscount.SelectedIndex == 3)
            {
                objdiscount.PerAltQty = true;
            }
            objdiscount.ItemPrice = false;
            objdiscount.ItemMRP = false;
            objdiscount.ItemAmount = false;
            objdiscount.ItemPrice = false;
            if (rbnPercentage.SelectedIndex == 0)
            {
                objdiscount.ItemPrice = true;
            }
            if (rbnPercentage.SelectedIndex == 1)
            {
                objdiscount.ItemMRP = true;
            }
            if (rbnPercentage.SelectedIndex == 2)
            {
                objdiscount.ItemAmount = true;
            }
            if (rbnPercentage.SelectedIndex == 3)
            {
                objdiscount.ItemPrice = true;
            }
            objdiscount.SpecifyCaptionForDiscount = tbxCaptionDiscount.Text.Trim() == null ? string.Empty : tbxCaptionDiscount.Text.Trim();

            DSAccountPosting objdsAccount;
            List<DSAccountPosting> lstAccountPost = new List<DSAccountPosting>();
            for(int i=0;i < dvgDisscountStrDetails.DataRowCount;i++)
            {
                DataRow row = dvgDisscountStrDetails.GetDataRow(i);
                objdsAccount = new DSAccountPosting();
                objdsAccount.AccountPost = Convert.ToBoolean(row["AccountPost"].ToString()=="Y"?true:false);
                objdsAccount.AccountHeadPost = row["AccountHeadPost"].ToString() == null ? string.Empty : row["AccountHeadPost"].ToString();
                objdsAccount.AffectsGoods = Convert.ToBoolean(row["AffectsGoods"].ToString()=="Y"?true:false);

                lstAccountPost.Add(objdsAccount);
            }
            objdiscount.ListofAccountPosting =lstAccountPost;
            bool IsSaved = objDisBL.SaveStructure(objdiscount);
            if(IsSaved)
            {
                MessageBox.Show("Saved Sussfully");
            }
         
            }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
