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
        public static int Bill_Id = 0;
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

            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            tbxName.Focus();
            FillBillSundryInfo();
        }

        private void FillBillSundryInfo()
        {
            BillSundryMasterModel objBsm = objbsmas.GetAllBillSundryById(Bill_Id);

            tbxName.Text=objBsm.Name;
            tbxAlias.Text= objBsm.Alias;
            tbxPrintName.Text= objBsm.PrintName;
            cbxBillsundrytype.SelectedItem=objBsm.BillSundryType;
            cbxBillsundrynature.SelectedItem= objBsm.BillSundryNature;
            tbxdefaultvalue.Text=objBsm.DefaultValue.ToString();
            cbxsubtotalheading.SelectedItem = objBsm.subtotalheading;

            cbxAffectsthecostofgoodsinsale.SelectedItem=(objBsm.AffectstheCostofGoodsinSale)?"Y":"N";
            cbxaffectsthecostofgoodsinpurchase.SelectedItem = objBsm.AffectstheCostofGoodsinPurchase ? "Y" : "N";
            cbxaffecsthecostofgoodsinmaterialissue.SelectedItem = objBsm.AffectstheCostofGoodsinMaterialIssue?"Y":"N";
            cbxaffectsthecostofgoodsinmaterialreceipt.SelectedItem = objBsm.AffectstheCostofGoodsinMaterialReceipt?"Y":"N";
            cbxaffectsthecostofgoodsinstocktransfer.SelectedItem = objBsm.AffectstheCostofGoodsinStockTransfer?"Y":"N";

            //Accountin In Sale
            cbxSaleaffectsAcc.SelectedItem= objBsm.SaleAffectsAccounting?"Y":"N";
            cbxSaleAdjustsaleamount.SelectedItem = objBsm.SaleAdjustInSaleAmount?"Y":"N";
            cbxSaleAccHeadpost.SelectedItem = objBsm.SaleAccounttoHeadPost;
            cbxSaleAdjustinpartyAmount.SelectedItem = objBsm.SaleAdjustInPartyAmount;
            cbxSaleAccountHeadpost.SelectedItem = objBsm.SaleAccounttoHeadPostParty;
            cbxSalePostoverandAbove.SelectedItem=objBsm.SalePostOverandAbove;

            // Accountin In Purc
            cbxPurcAftAccount.SelectedItem= objBsm.PurcAffectsAccounting?"Y":"N";
            cbxPurcPurchaseAmount.SelectedItem= objBsm.PurcAdjustInPurcAmount ? "Y" : "N";
            cbxPurcHeadPost.SelectedItem = objBsm.PurcAccounttoHeadPost;
            cbxPurcPartyAmount.SelectedItem = objBsm.PurcAdjustInPartyAmount ? "Y" : "N";
            cbxPurcAccountHeadPost.SelectedItem = objBsm.PurcAccounttoHeadPostParty;
            cbxPurcPostOverAbove.SelectedItem = objBsm.PurcPostOverandAbove;

            //objBsm.typeMaterialIssue = Convert.ToBoolean(dr["typeMaterialIssue"]);
            //objBsm.typeMaterialReceipt = Convert.ToBoolean(dr["typeMaterialReceipt"]);
            //objBsm.StockTransfer = Convert.ToBoolean(dr["StockTransfer"]);

            cbxAffectAccounting.SelectedItem= objBsm.AffectAccounting?"Y":"N";
            cbxotherside.SelectedItem = objBsm.OtherSide;
            cbxAccountHeadPost.SelectedItem = objBsm.Accountheadtopost;
            cbxAdjustinmc.SelectedItem = objBsm.AdjustinMC;
            cbxAccountPost.SelectedItem = objBsm.AccountheadtopostParty;
            cbxPostoverabove.SelectedItem = objBsm.postoverandabove;

            //objBsm.typeAbsoluteAmount = Convert.ToBoolean(dr["typeAbsoluteAmount"]);
            //objBsm.typePercentage = Convert.ToBoolean(dr["typePercentage"]);
            //objBsm.typePerMainQty = Convert.ToBoolean(dr["typePerMainQty"]);
            //objBsm.PerAltQty = Convert.ToBoolean(dr["PerAltQty"]);
            tbxPersentage.Text = objBsm.Percentoff.ToString();
            //objBsm.typeNetBillAmount = Convert.ToBoolean(dr["typeNetBillAmount"]);
            cbxselectivecalculation.SelectedItem = objBsm.SelectiveCalculation?"Y":"N";
            //objBsm.tyeItemsBasicAmt = Convert.ToBoolean(dr["tyeItemsBasicAmt"]);
            chkIncludefreequantity.Checked= objBsm.IncludeFreeQty;
            //objBsm.typeTotalMRPofItems = Convert.ToBoolean(dr["typeTotalMRPofItems"]);
            //objBsm.typeOtherBillsundry = Convert.ToBoolean(dr["typeOtherBillsundry"]);
            //objBsm.typePreviousBillSundryAmount = Convert.ToBoolean(dr["typePreviousBillSundryAmount"]);
            //tbx objBsm.BSAmt = Convert.ToBoolean(dr["BSAmt"]);
            //objBsm.BSAppOn =Convert.ToBoolean(dr["BSAppOn"]);
            tbxNofbillsundrys.Text = objBsm.NoOfBillSundry.ToString();
           cbxConsoilatedbillsundariesamt.SelectedItem = objBsm.ConsolidateBillSundriesAmount?"Y":"N";
            cbxroundoffbillsundryamount.SelectedItem=objBsm.roundoffBillsundry ? "Y" : "N";
        }


        private void btnsave_Click(object sender, EventArgs e)
        {
            BillSundryMasterModel objbsmod = new BillSundryMasterModel();

            objbsmod.Name = tbxName.Text;
            objbsmod.Alias = tbxAlias.Text == null ? string.Empty : tbxAlias.Text.Trim();
            objbsmod.PrintName = tbxPrintName.Text == null ? string.Empty : tbxPrintName.Text.Trim();
            objbsmod.BillSundryType = cbxBillsundrytype.SelectedItem.ToString();
            objbsmod.BillSundryNature = cbxBillsundrynature.SelectedItem.ToString();
            objbsmod.DefaultValue = Convert.ToDecimal(tbxdefaultvalue.Text == null ? "0" : tbxdefaultvalue.Text);
            objbsmod.subtotalheading = cbxsubtotalheading.SelectedItem.ToString();

            objbsmod.AffectstheCostofGoodsinSale = Convert.ToBoolean(cbxAffectsthecostofgoodsinsale.Text.ToString() == "Y" ? true : false);
            objbsmod.AffectstheCostofGoodsinPurchase = Convert.ToBoolean(cbxaffectsthecostofgoodsinpurchase.Text.ToString() == "Y" ? true : false);
            objbsmod.AffectstheCostofGoodsinMaterialIssue = Convert.ToBoolean(cbxaffecsthecostofgoodsinmaterialissue.Text.ToString() == "Y" ? true : false);
            objbsmod.AffectstheCostofGoodsinMaterialReceipt = Convert.ToBoolean(cbxaffectsthecostofgoodsinmaterialreceipt.Text.ToString() == "Y" ? true : false);
            objbsmod.AffectstheCostofGoodsinStockTransfer = Convert.ToBoolean(cbxaffectsthecostofgoodsinstocktransfer.Text.ToString() == "Y" ? true : false);

            //Accounting In Sales
            objbsmod.SaleAffectsAccounting = Convert.ToBoolean(cbxSaleaffectsAcc.Text.ToString() == "Y" ? true : false);
            objbsmod.SaleAdjustInSaleAmount = Convert.ToBoolean(cbxSaleAdjustsaleamount.Text.ToString() == "Y" ? true : false);           
            //objbsmod.SaleAccounttoHeadPost = cbxSaleAccHeadpost.Text.ToString();
            objbsmod.SaleAdjustInPartyAmount = Convert.ToBoolean(cbxSaleAdjustinpartyAmount.Text.ToString() == "Y" ? true : false);
            //objbsmod.SaleAccounttoHeadPostParty = cbxSaleAccountHeadpost.Text.ToString();
            if (objbsmod.SaleAdjustInSaleAmount)
            {
                //objbsmod.SalePostOverandAbove = cbxSalePostoverandAbove.SelectedItem.ToString() == "" ? string.Empty : cbxSalePostoverandAbove.SelectedItem.ToString();
            }
            

            //Accounting In Purchase
            objbsmod.PurcAffectsAccounting = Convert.ToBoolean(cbxPurcAftAccount.Text.ToString() == "Y" ? true : false);
            objbsmod.PurcAdjustInPurcAmount = Convert.ToBoolean(cbxPurcPurchaseAmount.Text.ToString() == "Y" ? true : false);
            //objbsmod.PurcAccounttoHeadPost = cbxPurcHeadPost.Text.ToString();
            objbsmod.PurcAdjustInPartyAmount = Convert.ToBoolean(cbxPurcPartyAmount.Text.ToString() == "Y" ? true : false);
            //objbsmod.PurcAccounttoHeadPostParty = cbxPurcAccountHeadPost.Text.ToString();
            if(objbsmod.PurcAdjustInPurcAmount)
            {
                //objbsmod.PurcPostOverandAbove = cbxPurcPostOverAbove.SelectedItem.ToString() == "" ? string.Empty : cbxSalePostoverandAbove.SelectedItem.ToString();
            }
            
            objbsmod.typeMaterialIssue = false;
            objbsmod.typeMaterialReceipt = false;
            objbsmod.StockTransfer = false;
            if (rbnMaterial.SelectedIndex == 0)
            {
                objbsmod.typeMaterialIssue = true;
            }
            if (rbnMaterial.SelectedIndex == 1)
            {
                objbsmod.typeMaterialReceipt = true;
            }
            if (rbnMaterial.SelectedIndex == 2)
            {
                objbsmod.StockTransfer = true;
            }

            //objbsmod.AffectAccounting = Convert.ToBoolean(cbxAffectAccounting.Text.ToString() == "Y" ? true : false);
            //objbsmod.OtherSide = cbxotherside.SelectedItem == null ? string.Empty : cbxotherside.SelectedItem.ToString();
            //objbsmod.Accountheadtopost = cbxAccountHeadPost.Text;
            //objbsmod.AdjustinMC = cbxAdjustinmc.SelectedItem.ToString() == null ? string.Empty : cbxAdjustinmc.SelectedItem.ToString();
            //objbsmod.Accountheadtopost = cbxAccountPost.SelectedItem.ToString() == null ? string.Empty : cbxAccountPost.SelectedItem.ToString();
            //objbsmod.postoverandabove = Convert.ToBoolean(cbxPostoverabove.Text.ToString() == "Y" ? true : false);
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
            objbsmod.SelectiveCalculation = Convert.ToBoolean(cbxselectivecalculation.SelectedItem.ToString() == "Y" ? true : false);
            objbsmod.IncludeFreeQty = Convert.ToBoolean(chkIncludefreequantity.Checked ? true : false);
            //objbsmod.NoOfBillSundry = Convert.ToInt32(tbxNofbillsundrys.Text == null ? "0" : tbxNofbillsundrys.Text.Trim());
            //objbsmod.ConsolidateBillSundriesAmount = Convert.ToBoolean(cbxConsoilatedbillsundariesamt.SelectedItem.ToString() == "Y" ? true : false);

            objbsmod.BSAmt = false;
            objbsmod.BSAppOn = false;
            if (rbnBillsundaryCal.SelectedIndex == 0)
            {
                objbsmod.BSAmt = true;
            }
            if (rbnBillsundaryCal.SelectedIndex == 1)
            {
                objbsmod.BSAppOn = true;
            }
            objbsmod.roundoffBillsundry = Convert.ToBoolean(cbxroundoffbillsundryamount.SelectedItem.ToString() == "Y" ? true : false);

            bool isSuccess = objbsmas.SaveBSM(objbsmod);
            if (isSuccess)
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
            tbxName.Focus();
            cbxsubtotalheading.SelectedIndex = 0;
            cbxAffectsthecostofgoodsinsale.SelectedIndex = 1;
            cbxaffectsthecostofgoodsinpurchase.SelectedIndex = 1;
            cbxaffecsthecostofgoodsinmaterialissue.SelectedIndex = 1;
            cbxaffectsthecostofgoodsinmaterialreceipt.SelectedIndex = 1;
            cbxaffectsthecostofgoodsinstocktransfer.SelectedIndex = 1;

            cbxSaleaffectsAcc.SelectedIndex = 0;
            cbxSaleAdjustsaleamount.SelectedIndex = 0;
            cbxSaleAccHeadpost.SelectedIndex = 0;
            cbxSaleAdjustinpartyAmount.SelectedIndex = 0;
            cbxSaleAccountHeadpost.SelectedIndex = 0;
            cbxSalePostoverandAbove.SelectedIndex = 0;

            cbxPurcAftAccount.SelectedIndex = 0;
            cbxPurcPurchaseAmount.SelectedIndex = 0;
            cbxPurcHeadPost.SelectedIndex = 0;
            cbxPurcPartyAmount.SelectedIndex = 0;
            cbxPurcAccountHeadPost.SelectedIndex = 0;
            cbxPurcPostOverAbove.SelectedIndex = 0;
            cbxselectivecalculation.SelectedIndex = 1;
            cbxroundoffbillsundryamount.SelectedIndex = 1;
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            lblDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;

        }

        private void rbnGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            tbxAlias.Text = tbxName.Text.Trim();
            tbxPrintName.Text = tbxName.Text.Trim();
        }

        private void tbxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (tbxName.Text.Trim() == "")
                {
                    MessageBox.Show("Name Can Not Be Blank!");
                    tbxName.Focus();
                    return;
                }
            }
        }

        private void cbxBillsundrytype_Enter(object sender, EventArgs e)
        {
            cbxBillsundrytype.ShowPopup();
        }

        private void cbxBillsundrynature_Enter(object sender, EventArgs e)
        {
            cbxBillsundrynature.ShowPopup();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            BillSundryMasterModel objbsmod = new BillSundryMasterModel();

            objbsmod.Name = tbxName.Text;
            objbsmod.Alias = tbxAlias.Text == null ? string.Empty : tbxAlias.Text.Trim();
            objbsmod.PrintName = tbxPrintName.Text == null ? string.Empty : tbxPrintName.Text.Trim();
            objbsmod.BillSundryType = cbxBillsundrytype.SelectedItem.ToString();
            objbsmod.BillSundryNature = cbxBillsundrynature.SelectedItem.ToString();
            objbsmod.DefaultValue = Convert.ToDecimal(tbxdefaultvalue.Text == null ? "0" : tbxdefaultvalue.Text);

            objbsmod.AffectstheCostofGoodsinSale = Convert.ToBoolean(cbxAffectsthecostofgoodsinsale.Text.ToString() == "Y" ? true : false);
            objbsmod.AffectstheCostofGoodsinPurchase = Convert.ToBoolean(cbxaffectsthecostofgoodsinpurchase.Text.ToString() == "Y" ? true : false);
            objbsmod.AffectstheCostofGoodsinMaterialIssue = Convert.ToBoolean(cbxaffecsthecostofgoodsinmaterialissue.Text.ToString() == "Y" ? true : false);
            objbsmod.AffectstheCostofGoodsinMaterialReceipt = Convert.ToBoolean(cbxaffectsthecostofgoodsinmaterialreceipt.Text.ToString() == "Y" ? true : false);
            objbsmod.AffectstheCostofGoodsinStockTransfer = Convert.ToBoolean(cbxaffectsthecostofgoodsinstocktransfer.Text.ToString() == "Y" ? true : false);

            //Accounting In Sales
            objbsmod.SaleAffectsAccounting = Convert.ToBoolean(cbxSaleaffectsAcc.Text.ToString() == "Y" ? true : false);
            objbsmod.SaleAdjustInSaleAmount = Convert.ToBoolean(cbxSaleAdjustsaleamount.Text.ToString() == "Y" ? true : false);
            //objbsmod.SaleAccounttoHeadPost = cbxSaleAccHeadpost.Text.ToString();
            objbsmod.SaleAdjustInPartyAmount = Convert.ToBoolean(cbxSaleAdjustinpartyAmount.Text.ToString() == "Y" ? true : false);
            //objbsmod.SaleAccounttoHeadPostParty = cbxSaleAccountHeadpost.Text.ToString();
            if (objbsmod.SaleAdjustInSaleAmount)
            {
                //objbsmod.SalePostOverandAbove = cbxSalePostoverandAbove.SelectedItem.ToString() == "" ? string.Empty : cbxSalePostoverandAbove.SelectedItem.ToString();
            }


            //Accounting In Purchase
            objbsmod.PurcAffectsAccounting = Convert.ToBoolean(cbxPurcAftAccount.Text.ToString() == "Y" ? true : false);
            objbsmod.PurcAdjustInPurcAmount = Convert.ToBoolean(cbxPurcPurchaseAmount.Text.ToString() == "Y" ? true : false);
            //objbsmod.PurcAccounttoHeadPost = cbxPurcHeadPost.Text.ToString();
            objbsmod.PurcAdjustInPartyAmount = Convert.ToBoolean(cbxPurcPartyAmount.Text.ToString() == "Y" ? true : false);
            //objbsmod.PurcAccounttoHeadPostParty = cbxPurcAccountHeadPost.Text.ToString();
            if (objbsmod.PurcAdjustInPurcAmount)
            {
                //objbsmod.PurcPostOverandAbove = cbxPurcPostOverAbove.SelectedItem.ToString() == "" ? string.Empty : cbxSalePostoverandAbove.SelectedItem.ToString();
            }

            objbsmod.typeMaterialIssue = false;
            objbsmod.typeMaterialReceipt = false;
            objbsmod.StockTransfer = false;
            if (rbnMaterial.SelectedIndex == 0)
            {
                objbsmod.typeMaterialIssue = true;
            }
            if (rbnMaterial.SelectedIndex == 1)
            {
                objbsmod.typeMaterialReceipt = true;
            }
            if (rbnMaterial.SelectedIndex == 2)
            {
                objbsmod.StockTransfer = true;
            }

            //objbsmod.AffectAccounting = Convert.ToBoolean(cbxAffectAccounting.Text.ToString() == "Y" ? true : false);
            //objbsmod.OtherSide = cbxotherside.SelectedItem == null ? string.Empty : cbxotherside.SelectedItem.ToString();
            //objbsmod.Accountheadtopost = cbxAccountHeadPost.Text;
            //objbsmod.AdjustinMC = cbxAdjustinmc.SelectedItem.ToString() == null ? string.Empty : cbxAdjustinmc.SelectedItem.ToString();
            //objbsmod.Accountheadtopost = cbxAccountPost.SelectedItem.ToString() == null ? string.Empty : cbxAccountPost.SelectedItem.ToString();
            //objbsmod.postoverandabove = Convert.ToBoolean(cbxPostoverabove.Text.ToString() == "Y" ? true : false);
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
            objbsmod.SelectiveCalculation = Convert.ToBoolean(cbxselectivecalculation.SelectedItem.ToString() == "Y" ? true : false);
            objbsmod.IncludeFreeQty = Convert.ToBoolean(chkIncludefreequantity.Checked ? true : false);
            //objbsmod.NoOfBillSundry = Convert.ToInt32(tbxNofbillsundrys.Text == null ? "0" : tbxNofbillsundrys.Text.Trim());
            //objbsmod.ConsolidateBillSundriesAmount = Convert.ToBoolean(cbxConsoilatedbillsundariesamt.SelectedItem.ToString() == "Y" ? true : false);

            objbsmod.BSAmt = false;
            objbsmod.BSAppOn = false;
            if (rbnBillsundaryCal.SelectedIndex == 0)
            {
                objbsmod.BSAmt = true;
            }
            if (rbnBillsundaryCal.SelectedIndex == 1)
            {
                objbsmod.BSAppOn = true;
            }
            objbsmod.roundoffBillsundry = Convert.ToBoolean(cbxroundoffbillsundryamount.SelectedItem.ToString() == "Y" ? true : false);
            objbsmod.BS_Id = Bill_Id;

            bool isSuccess = objbsmas.UpdateBSM(objbsmod);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
            }

        }
        public void ClearControls()
        {
            tbxName.Text = string.Empty;
            tbxAlias.Text = string.Empty;
            tbxPrintName.Text = string.Empty;
            tbxdefaultvalue.Text = string.Empty;
            tbxPersentage.Text = string.Empty;

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDelete = objbsmas.DeleteBillSundryById(Bill_Id);
            if (isDelete)
            {
                MessageBox.Show("Delete Successfully!");
                ClearControls();
            }
        }

        private void cbxSaleaffectsAcc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxSaleaffectsAcc.SelectedItem.ToString().Equals("N"))
            {
                lblAccountHeadtoPostSale.Enabled = false;
                lblPostOverandAboveSale.Enabled = false;
                lblAccounttoHeadtoPostSle.Enabled = false;
                lblAdjustSaleAmountSale.Enabled = false;
                lblAdjustinPartyAmountSale.Enabled = false;
            }
            else
            {
                lblAccountHeadtoPostSale.Enabled = true;
                lblAccounttoHeadtoPostSle.Enabled = true;
                lblPostOverandAboveSale.Enabled = true;
                lblAdjustSaleAmountSale.Enabled = true;
                lblAdjustinPartyAmountSale.Enabled = true;
            }
        }

        private void cbxBillsundrytype_Leave(object sender, EventArgs e)
        {
            cbxBillsundrytype.SelectedIndex = 0;
        }

        private void cbxBillsundrynature_Leave(object sender, EventArgs e)
        {
            cbxBillsundrynature.SelectedIndex = 0;
        }
    }
}