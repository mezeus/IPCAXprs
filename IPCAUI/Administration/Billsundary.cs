using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using eSunSpeed.BusinessLogic;
using eSunSpeedDomain;

namespace IPCAUI.Administration
{
    public partial class Billsundary : DevExpress.XtraEditors.XtraForm
    {
        BillSundryMaster objbsmas = new BillSundryMaster();
        public Billsundary()
        {
            InitializeComponent();
        }

        private void Billsundary_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {

        }

        private void ListBillsundary_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.BillsundaryList frmList = new Administration.List.BillsundaryList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            BillSundryMasterModel objbsmod = new BillSundryMasterModel();
            
            objbsmod.Name = tbxName.Text;
            if (tbxName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Master Name Can Not Be Blank!");
                tbxName.Focus();
                return;
            }
            objbsmod.Alias = tbxAlias.Text;
            objbsmod.PrintName = tbxPrintName.Text;
            objbsmod.BillSundryType = cbxBillsundrytype.SelectedItem.ToString();
            objbsmod.BillSundryNature = cbxBillsundrynature.SelectedItem.ToString();
            objbsmod.DefaultValue = Convert.ToDecimal(tbxdefaultvalue.Text==null?"0":tbxdefaultvalue.Text);

            objbsmod.AffectstheCostofGoodsinSale = Convert.ToBoolean(cbxAffectsthecostofgoodsinsale.Text.ToString()=="Y"? true:false);
            objbsmod.AffectstheCostofGoodsinPurchase = Convert.ToBoolean(cbxaffectsthecostofgoodsinpurchase.Text.ToString() == "Y" ? true : false);
            objbsmod.AffectstheCostofGoodsinMaterialIssue = Convert.ToBoolean(cbxaffecsthecostofgoodsinmaterialissue.Text.ToString() == "Y" ? true : false);
            objbsmod.AffectstheCostofGoodsinMaterialReceipt = Convert.ToBoolean(cbxaffectsthecostofgoodsinmaterialreceipt.Text.ToString() == "Y" ? true : false);
            objbsmod.AffectstheCostofGoodsinStockTransfer = Convert.ToBoolean(cbxaffectsthecostofgoodsinstocktransfer.Text.ToString() == "Y" ? true : false);

            //Accounting In Sales
            objbsmod.SaleAffectsAccounting = Convert.ToBoolean(cbxSaleaffectsAcc.Text.ToString() == "Y" ? true : false);
            objbsmod.SaleAdjustInSaleAmount= Convert.ToBoolean(cbxSaleAdjustsaleamount.Text.ToString() == "Y" ? true : false);
            objbsmod.SaleAccounttoHeadPost =cbxSaleAccHeadpost.Text.ToString();
            objbsmod.SaleAdjustInPartyAmount = Convert.ToBoolean(cbxSaleAdjustinpartyAmount.Text.ToString() == "Y" ? true : false);
            objbsmod.SaleAccounttoHeadPostParty = cbxSaleAccountHeadpost.Text.ToString();
            objbsmod.SalePostOverandAbove = cbxSalePostoverandAbove.SelectedItem.ToString()==""?string.Empty:cbxSalePostoverandAbove.SelectedItem.ToString();

            //Accounting In Purchase
            objbsmod.PurcAffectsAccounting = Convert.ToBoolean(cbxPurcAftAccount.Text.ToString() == "Y" ? true : false);
            objbsmod.PurcAdjustInPurcAmount = Convert.ToBoolean(cbxPurcPurchaseAmount.Text.ToString() == "Y" ? true : false);
            objbsmod.PurcAccounttoHeadPost = cbxPurcHeadPost.Text.ToString();
            objbsmod.PurcAdjustInPartyAmount = Convert.ToBoolean(cbxPurcPartyAmount.Text.ToString() == "Y" ? true : false);
            objbsmod.PurcAccounttoHeadPostParty = cbxPurcAccountHeadPost.Text.ToString();
            objbsmod.PurcPostOverandAbove = cbxPurcPostOverAbove.SelectedItem.ToString() == "" ? string.Empty : cbxSalePostoverandAbove.SelectedItem.ToString();

            // objbsmod.typeMaterialIssue = "true";
            if (rbnMaterial.SelectedIndex == 0)
            {
                objbsmod.typeMaterialIssue = true;
                objbsmod.typeMaterialReceipt = false;
                objbsmod.StockTransfer = false;
            }
            if (rbnMaterial.SelectedIndex == 1)
            {
                objbsmod.typeMaterialIssue = false;
                objbsmod.typeMaterialReceipt = true;
                objbsmod.StockTransfer = false;
            }
            if (rbnMaterial.SelectedIndex == 2)
            {
                objbsmod.typeMaterialIssue = false;
                objbsmod.typeMaterialReceipt = false;
                objbsmod.StockTransfer = true;
            }
           
            objbsmod.AffectAccounting = Convert.ToBoolean(cbxAffectAccounting.Text.ToString() == "Y" ? true : false);
            objbsmod.OtherSide = cbxotherside.SelectedItem==null?string.Empty: cbxotherside.SelectedItem.ToString();
            objbsmod.Accountheadtopost = cbxAccountHeadPost.Text;
            objbsmod.AdjustinMC = cbxAdjustinmc.SelectedItem.ToString()==null?string.Empty:cbxAdjustinmc.SelectedItem.ToString();
            objbsmod.Accountheadtopost = cbxAccountPost.SelectedItem.ToString() == null ? string.Empty : cbxAccountPost.SelectedItem.ToString();
            objbsmod.postoverandabove =  Convert.ToBoolean(cbxPostoverabove.Text.ToString() == "Y" ? true : false );
            //  objbsmod.typeAbsoluteAmount = rbabsoluteamount.ToString();
            //Amount Of Bill Sundary
            objbsmod.typeAbsoluteAmount = false;
            objbsmod.typePercentage = false;
            objbsmod.typePerMainQty = false;
            objbsmod.PerAltQty = false;
            if (rbnAmtBillsundary.SelectedIndex == 0)
            {
                objbsmod.typeAbsoluteAmount = true;
            }
            if (rbnAmtBillsundary.SelectedIndex == 1)
            {
                objbsmod.typePercentage = true;
            }
            if (rbnAmtBillsundary.SelectedIndex == 2)
            {
                objbsmod.typePerMainQty = true;
            }
            if (rbnAmtBillsundary.SelectedIndex == 3)
            {
                objbsmod.PerAltQty = true;
            }
            objbsmod.typeNetBillAmount = false;
            objbsmod.tyeItemsBasicAmt = false;
            objbsmod.typeTotalMRPofItems = false;
            objbsmod.typeTaxableAmount = false;
            objbsmod.typePreviousBillSundryAmount = false;
            objbsmod.typeOtherBillsundry = false;
            if (rbnbillsOf.SelectedIndex == 0)
            {
                objbsmod.typeNetBillAmount = true;
            }
            if (rbnbillsOf.SelectedIndex == 1)
            {
                objbsmod.tyeItemsBasicAmt = true;
            }
            if (rbnbillsOf.SelectedIndex == 2)
            {
                objbsmod.typeTotalMRPofItems = true;
            }
            if (rbnbillsOf.SelectedIndex == 3)
            {
                objbsmod.typeTaxableAmount = true;
            }
            if (rbnbillsOf.SelectedIndex == 4)
            {
                objbsmod.typePreviousBillSundryAmount = true;
            }
            if (rbnbillsOf.SelectedIndex == 5)
            {
                objbsmod.typeOtherBillsundry = true;
            }
            objbsmod.Percentoff = Convert.ToDecimal(tbxPersentage.Text.ToString());
            objbsmod.SelectiveCalculation =Convert.ToBoolean(cbxselectivecalculation.SelectedItem.ToString() == "Y" ? true : false);
            objbsmod.IncludeFreeQty = Convert.ToBoolean(chkIncludefreequantity.Checked ? true : false);
            objbsmod.NoOfBillSundry = Convert.ToInt32(tbxNofbillsundrys.Text == null ? "0" : tbxNofbillsundrys.Text.Trim());
            objbsmod.ConsolidateBillSundriesAmount=Convert.ToBoolean(cbxConsoilatedbillsundariesamt.SelectedItem.ToString() == "Y" ? true : false);

            objbsmod.BSAmt = false;
            if (rbnBillsundaryCal.SelectedIndex == 0)
            {
                objbsmod.BSAmt = true;
            }
            if (rbnBillsundaryCal.SelectedIndex == 1)
            {
                objbsmod.BSAppOn = true;
            }
            objbsmod.roundoffBillsundry = Convert.ToBoolean(cbxConsoilatedbillsundariesamt.SelectedItem.ToString() == "Y" ? true : false);

            bool isSuccess = objbsmas.SaveBSM(objbsmod);
            if(isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
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

        private void Billsundary_Load(object sender, EventArgs e)
        {
            cbxAffectsthecostofgoodsinsale.SelectedIndex = 0;
            cbxAffectsthecostofgoodsinsale.SelectedIndex = 0;
        }

        private void rbnGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            tbxAlias.Text = tbxName.Text.Trim();
            tbxPrintName.Text = tbxName.Text.Trim();
        }
    }
}