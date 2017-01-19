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
    public partial class MarkupStructureMaster : Form
    {
        DataTable dtMarkup = new DataTable();
        MarkupStructureBL objMakBL = new MarkupStructureBL();
        public MarkupStructureMaster()
        {
            InitializeComponent();
        }

        private void MarkupStructureMaster_Load(object sender, EventArgs e)
        {
            tbxStrName.Focus();
            dtMarkup.Columns.Add("AccountPost");
            dtMarkup.Columns.Add("AccountHeadPost");
            dtMarkup.Columns.Add("AffectsGoods");

            dvgMarkupStr.DataSource = dtMarkup;

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
            MarkupStructureMasterModel objmarkup = new MarkupStructureMasterModel();

            objmarkup.StructureName = tbxStrName.Text.Trim() == null ? string.Empty : tbxStrName.Text.Trim();
            objmarkup.SimpleDiscount = false;
            objmarkup.CompoundMarkupwithSameNature = false;
            objmarkup.CompoundMarkupDifferentNature = false;
            if(rbnMarkupType.SelectedIndex==0)
            {
                objmarkup.SimpleDiscount = true;
            }
            if (rbnMarkupType.SelectedIndex == 1)
            {
                objmarkup.CompoundMarkupwithSameNature = true;
            }
            if (rbnMarkupType.SelectedIndex == 2)
            {
                objmarkup.CompoundMarkupDifferentNature = true;
            }
            objmarkup.NoOfMarkups =Convert.ToInt32(tbxNoDiscounts.Text.Trim() == null ?"0": tbxNoDiscounts.Text.Trim());
            objmarkup.AbsoluteDiscount = false;
            objmarkup.PerMainQty = false;
            objmarkup.Percentage = false;
            objmarkup.PerAltQty = false;
            if (rbnAccountMarkup.SelectedIndex == 0)
            {
                objmarkup.AbsoluteDiscount = true;
            }
            if (rbnAccountMarkup.SelectedIndex == 1)
            {
                objmarkup.PerMainQty = true;
            }
            if (rbnAccountMarkup.SelectedIndex == 2)
            {
                objmarkup.Percentage = true;
            }
            if (rbnAccountMarkup.SelectedIndex == 3)
            {
                objmarkup.PerAltQty = true;
            }
            objmarkup.ItemPrice = false;
            objmarkup.ItemMRP = false;
            objmarkup.ItemAmount = false;
            objmarkup.ItemPrice = false;
            if (rbnPercentage.SelectedIndex == 0)
            {
                objmarkup.ItemPrice = true;
            }
            if (rbnPercentage.SelectedIndex == 1)
            {
                objmarkup.ItemMRP = true;
            }
            if (rbnPercentage.SelectedIndex == 2)
            {
                objmarkup.ItemAmount = true;
            }
            if (rbnPercentage.SelectedIndex == 3)
            {
                objmarkup.ItemPrice = true;
            }
            objmarkup.SpecifyCaptionForMarkup = tbxCaptionMarkup.Text.Trim() == null ? string.Empty : tbxCaptionMarkup.Text.Trim();

            DSAccountPosting objdsAccount;
            List<DSAccountPosting> lstAccountPost = new List<DSAccountPosting>();
            for(int i=0;i < dvgMarkupStrDetails.DataRowCount;i++)
            {
                DataRow row = dvgMarkupStrDetails.GetDataRow(i);
                objdsAccount = new DSAccountPosting();
                objdsAccount.AccountPost = Convert.ToBoolean(row["AccountPost"].ToString()=="Y"?true:false);
                objdsAccount.AccountHeadPost = row["AccountHeadPost"].ToString() == null ? string.Empty : row["AccountHeadPost"].ToString();
                objdsAccount.AffectsGoods = Convert.ToBoolean(row["AffectsGoods"].ToString()=="Y"?true:false);

                lstAccountPost.Add(objdsAccount);
            }
            objmarkup.ListofAccountPosting =lstAccountPost;
            bool IsSaved = objMakBL.SaveMarkupStructure(objmarkup);
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
