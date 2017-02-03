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
using System.IO;
using System.Configuration;

namespace IPCAUI.Administration
{
    public partial class BillSundaryMaster : Form
    {
        BillSundryMaster objbsBL = new BillSundryMaster();
        AccountMasterBL objAccBl = new AccountMasterBL();
        public static BillSundryMasterModel objbsmod = new BillSundryMasterModel();
        public static int BillsId = 0;
        public static string FormName = "";
        public BillSundaryMaster()
        {
            InitializeComponent();
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
            if(keyData==Keys.F3)
            {
                if(cbxSaleAccHeadpost.ContainsFocus)
                {
                    FormName = "AccountMaster";
                }
                if(cbxSaleAccHeadpost.Focused|| cbxSaleAccHeadpostParty.Focused|| cbxPurcHeadPost.Focused|| cbxPurcAccountHeadPostParty.Focused|| cbxAccountHeadPost.Focused|| cbxAccountPost.Focused)
                {
                    FormName = "AccountMaster";
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            objbsmod.Name = tbxName.Text;
            objbsmod.Alias = tbxAlias.Text == null ? string.Empty : tbxAlias.Text.Trim();
            objbsmod.PrintName = tbxPrintName.Text == null ? string.Empty : tbxPrintName.Text.Trim();
            objbsmod.BillSundryType = cbxBillsundrytype.SelectedItem.ToString();
            objbsmod.BillSundryNature = cbxBillsundrynature.SelectedItem.ToString();
            objbsmod.DefaultValue = Convert.ToDecimal(tbxdefaultvalue.Text == string.Empty ? "0.00" : tbxdefaultvalue.Text);
            objbsmod.subtotalheading = cbxSubtotalheading.SelectedItem.ToString();

            objbsmod.AffectstheCostofGoodsinSale = Convert.ToBoolean(cbxAffectsthecostofgoodsinsale.Text.ToString() == "Y" ? true : false);
            objbsmod.AffectstheCostofGoodsinPurchase = Convert.ToBoolean(cbxaffectsthecostofgoodsinpurchase.Text.ToString() == "Y" ? true : false);
            objbsmod.AffectstheCostofGoodsinMaterialIssue = Convert.ToBoolean(cbxAffecsthecostofgoodsinMaterialissue.Text.ToString() == "Y" ? true : false);
            objbsmod.AffectstheCostofGoodsinMaterialReceipt = Convert.ToBoolean(cbxAffectsthecostofgoodsinmaterialreceipt.Text.ToString() == "Y" ? true : false);
            objbsmod.AffectstheCostofGoodsinStockTransfer = Convert.ToBoolean(cbxAffectsthecostofgoodsinstockTransfer.Text.ToString() == "Y" ? true : false);

            //Accounting In Sales
            objbsmod.SaleAffectsAccounting = Convert.ToBoolean(cbxSaleaffectsAcc.Text.ToString() == "Y" ? true : false);
            objbsmod.SaleAdjustInSaleAmount = Convert.ToBoolean(cbxSaleAdjustsaleamount.Text.ToString() == "Y" ? true : false);
            objbsmod.SaleSpecifyAccountHere = cbxSaleAccountLedgerSpecify.SelectedItem.ToString();
            objbsmod.SaleAccounttoHeadPost = cbxSaleAccHeadpost.SelectedItem.ToString();
            objbsmod.SaleAdjustInPartyAmount = Convert.ToBoolean(cbxSaleAdjustinpartyAmount.Text.ToString() == "Y" ? true : false);
            objbsmod.SalePartSpecifyAccountHere = cbxPartysaleAccountLedgerSpecify.Text.ToString();
            objbsmod.SaleAccounttoHeadPostParty = cbxSaleAccHeadpostParty.SelectedItem.ToString();
            if (objbsmod.SaleAdjustInSaleAmount)
            {
                objbsmod.SalePostOverandAbove = cbxSalePostoverandAbove.SelectedItem.ToString()=="Y" ? true : false;
            }


            //Accounting In Purchase
            objbsmod.PurcAffectsAccounting = Convert.ToBoolean(cbxPurcAftAccount.Text.ToString() == "Y" ? true : false);
            objbsmod.PurcAdjustInPurcAmount = Convert.ToBoolean(cbxPurcPurchaseAmount.Text.ToString() == "Y" ? true : false);
            objbsmod.PurcSpecifyAccountHere = cbxPurcAccountLedgerSpecify.SelectedItem.ToString();
            objbsmod.PurcAccounttoHeadPost = cbxPurcHeadPost.SelectedItem.ToString();
            objbsmod.PurcAdjustInPartyAmount = Convert.ToBoolean(cbxPurcPartyAmount.Text.ToString() == "Y" ? true : false);
            objbsmod.PurcParySpecifyAccountHere = cbxPartyPurcAccountLedgerSpecify.SelectedItem.ToString();
            objbsmod.PurcAccounttoHeadPostParty = cbxPurcAccountHeadPostParty.Text.ToString();
            if (objbsmod.PurcAdjustInPurcAmount)
            {
                objbsmod.PurcPostOverandAbove = cbxPurcPostOverAbove.SelectedItem.ToString() == "Y" ? true : false;
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

            objbsmod.AffectAccounting = Convert.ToBoolean(cbxAffectAccounting.Text.ToString() == "Y" ? true : false);
            objbsmod.OtherSide = cbxotherside.SelectedItem == null ? string.Empty : cbxotherside.SelectedItem.ToString();
            objbsmod.Accountheadtopost = cbxAccountHeadPost.Text.Trim();
            objbsmod.AdjustinMC = cbxAdjustinmc.SelectedItem.ToString().Equals("Y") ? true : false;
            objbsmod.AdjustSpecifyAccountLedger = cbxAccountAdjustinParty.SelectedItem.ToString();
            objbsmod.AccountheadtopostParty = cbxAccountPost.SelectedItem.ToString() == null ? string.Empty : cbxAccountPost.SelectedItem.ToString();
            objbsmod.postoverandabove = Convert.ToBoolean(cbxPostoverabove.Text.ToString() == "Y" ? true : false);
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
            objbsmod.NoOfBillSundry = Convert.ToInt32(tbxNofbillsundrys.Text == null ? "0" : tbxNofbillsundrys.Text.Trim());
            objbsmod.ConsolidateBillSundriesAmount = Convert.ToBoolean(cbxConsoilatedbillsundariesamt.SelectedItem.ToString() == "Y" ? true : false);
            objbsmod.BillSundaryName = cbxBillSundary.SelectedItem.ToString();
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
            objbsmod.roundoffBillsundry = Convert.ToBoolean(cbxRoundoffBillsundryamount.SelectedItem.ToString() == "Y" ? true : false);
            if(objbsmod.roundoffBillsundry)
            {
                objbsmod.RoundoffValues = cbxRoundofValues.SelectedItem.ToString();
            }          
            bool isSuccess = objbsBL.SaveBSM(objbsmod);
            if (isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
                tbxName.Focus();
                cbxBillSundary.Properties.Items.Clear();
                List<BillSundryMasterModel> lstBillSundary = objbsBL.GetAllBillSundry();
                foreach (BillSundryMasterModel objBill in lstBillSundary)
                {
                    cbxBillSundary.Properties.Items.Add(objBill.Name);
                }
            }

        }

        private void ListBillSundry_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.BillsundaryList frmBSList = new Administration.List.BillsundaryList();
            frmBSList.StartPosition = FormStartPosition.CenterScreen;
            frmBSList.ShowDialog();
            FillBillSundryInfo();
        }
        private void FillBillSundryInfo()
        {
            objbsmod = new BillSundryMasterModel();
            if (BillsId==0)
            {
                tbxName.Focus();
                laCtrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                laCtrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                laCtrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                return;
            }
            
            objbsmod = objbsBL.GetAllBillSundryById(BillsId);

            tbxName.Text = objbsmod.Name;
            tbxAlias.Text = objbsmod.Alias;
            tbxPrintName.Text = objbsmod.PrintName;
            cbxBillsundrytype.SelectedItem = objbsmod.BillSundryType;
            cbxBillsundrynature.SelectedItem = objbsmod.BillSundryNature;
            tbxdefaultvalue.Text = objbsmod.DefaultValue.ToString();
            cbxSubtotalheading.SelectedItem = objbsmod.subtotalheading;

            cbxAffectsthecostofgoodsinsale.SelectedItem = (objbsmod.AffectstheCostofGoodsinSale) ? "Y" : "N";
            cbxaffectsthecostofgoodsinpurchase.SelectedItem = objbsmod.AffectstheCostofGoodsinPurchase ? "Y" : "N";
            cbxAffecsthecostofgoodsinMaterialissue.SelectedItem = objbsmod.AffectstheCostofGoodsinMaterialIssue ? "Y" : "N";
            cbxAffectsthecostofgoodsinmaterialreceipt.SelectedItem = objbsmod.AffectstheCostofGoodsinMaterialReceipt ? "Y" : "N";
            cbxAffectsthecostofgoodsinstockTransfer.SelectedItem = objbsmod.AffectstheCostofGoodsinStockTransfer ? "Y" : "N";

            //Accountin In Sale
            cbxSaleaffectsAcc.SelectedItem = objbsmod.SaleAffectsAccounting ? "Y" : "N";
            cbxSaleAdjustsaleamount.SelectedItem = objbsmod.SaleAdjustInSaleAmount ? "Y" : "N";
            cbxSaleAccountLedgerSpecify.SelectedItem = objbsmod.SaleSpecifyAccountHere.ToString();
            cbxSaleAccHeadpost.SelectedItem = objbsmod.SaleAccounttoHeadPost;
            cbxSaleAdjustinpartyAmount.SelectedItem = objbsmod.SaleAdjustInPartyAmount?"Y":"N";
            cbxPartysaleAccountLedgerSpecify.SelectedItem = objbsmod.SalePartSpecifyAccountHere.ToString();
            cbxSaleAccHeadpostParty.SelectedItem = objbsmod.SaleAccounttoHeadPostParty;
            cbxSalePostoverandAbove.SelectedItem = objbsmod.SalePostOverandAbove?"Y":"N";

            // Accountin In Purc
            cbxPurcAftAccount.SelectedItem = objbsmod.PurcAffectsAccounting ? "Y" : "N";
            cbxPurcPurchaseAmount.SelectedItem = objbsmod.PurcAdjustInPurcAmount ? "Y" : "N";
            cbxPurcAccountLedgerSpecify.SelectedItem = objbsmod.PurcSpecifyAccountHere.ToString();
            cbxPurcHeadPost.SelectedItem = objbsmod.PurcAccounttoHeadPost;
            cbxPurcPartyAmount.SelectedItem = objbsmod.PurcAdjustInPartyAmount ? "Y" : "N";
            cbxPartyPurcAccountLedgerSpecify.SelectedItem = objbsmod.PurcParySpecifyAccountHere.ToString();
            cbxPurcAccountHeadPostParty.SelectedItem = objbsmod.PurcAccounttoHeadPostParty;
            cbxPurcPostOverAbove.SelectedItem = objbsmod.PurcPostOverandAbove ? "Y" : "N";

            if(objbsmod.typeMaterialIssue)
            {
                rbnMaterial.SelectedIndex = 0;
            }
            if(objbsmod.typeMaterialReceipt)
            {
                rbnMaterial.SelectedIndex = 1;
            }
            if(objbsmod.StockTransfer)
            {
                rbnMaterial.SelectedIndex = 2;
            }

            cbxAffectAccounting.SelectedItem = objbsmod.AffectAccounting ? "Y" : "N";
            cbxotherside.SelectedItem = objbsmod.OtherSide.ToString();
            cbxAccountHeadPost.SelectedItem = objbsmod.Accountheadtopost;
            cbxAdjustinmc.SelectedItem = objbsmod.AdjustinMC ? "Y" : "N";
            cbxAccountAdjustinParty.SelectedItem = objbsmod.AdjustSpecifyAccountLedger.ToString();
            cbxAccountPost.SelectedItem = objbsmod.AccountheadtopostParty;
            cbxPostoverabove.SelectedItem = objbsmod.postoverandabove ? "Y" : "N";

            if(objbsmod.typeAbsoluteAmount)
            {
                rbnAmtBillsundary.SelectedIndex = 0;
            }
            if(objbsmod.typePercentage)
            {
                rbnAmtBillsundary.SelectedIndex = 2;
            }
            if(objbsmod.typePerMainQty)
            {
                rbnAmtBillsundary.SelectedIndex = 1;
            }
            if(objbsmod.PerAltQty)
            {
                rbnAmtBillsundary.SelectedIndex = 3;
            }
            tbxPersentage.Text = objbsmod.Percentoff.ToString();
            if(objbsmod.typeNetBillAmount)
            {
                rbnbillsOf.SelectedIndex = 0;
            }
            cbxselectivecalculation.SelectedItem = objbsmod.SelectiveCalculation ? "Y" : "N";
            if(objbsmod.tyeItemsBasicAmt)
            {
                rbnbillsOf.SelectedIndex = 1;
            }
            chkIncludefreequantity.Checked = objbsmod.IncludeFreeQty;
            if(objbsmod.typeTotalMRPofItems)
            {
                rbnbillsOf.SelectedIndex = 2;
            }
            if(objbsmod.typeOtherBillsundry)
            {
                rbnbillsOf.SelectedIndex = 5;
            }
            if(objbsmod.typePreviousBillSundryAmount)
            {
                rbnbillsOf.SelectedIndex = 4;
            }
            if (objbsmod.typeTaxableAmount)
            {
                rbnbillsOf.SelectedIndex = 3;
            }
            if(objbsmod.BSAmt)
            {
                rbnBillsundaryCal.SelectedIndex = 0;
            }
            if(objbsmod.BSAppOn)
            {
                rbnBillsundaryCal.SelectedIndex = 1;
            }
            cbxBillSundary.SelectedItem = objbsmod.BillSundaryName.ToString();
            tbxNofbillsundrys.Text = objbsmod.NoOfBillSundry.ToString();
            cbxConsoilatedbillsundariesamt.SelectedItem = objbsmod.ConsolidateBillSundriesAmount ? "Y" : "N";
            cbxRoundoffBillsundryamount.SelectedItem = objbsmod.roundoffBillsundry ? "Y" : "N";
            cbxRoundofValues.SelectedItem = objbsmod.RoundoffValues.ToString();
            laCtrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            laCtrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            laCtrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            tbxName.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            objbsmod = new BillSundryMasterModel();
            objbsmod.Name = tbxName.Text;
            objbsmod.Alias = tbxAlias.Text == null ? string.Empty : tbxAlias.Text.Trim();
            objbsmod.PrintName = tbxPrintName.Text == null ? string.Empty : tbxPrintName.Text.Trim();
            objbsmod.BillSundryType = cbxBillsundrytype.SelectedItem.ToString();
            objbsmod.BillSundryNature = cbxBillsundrynature.SelectedItem.ToString();
            objbsmod.DefaultValue = Convert.ToDecimal(tbxdefaultvalue.Text == string.Empty ? "0.00" : tbxdefaultvalue.Text);
            objbsmod.subtotalheading = cbxSubtotalheading.SelectedItem.ToString();

            objbsmod.AffectstheCostofGoodsinSale = Convert.ToBoolean(cbxAffectsthecostofgoodsinsale.Text.ToString() == "Y" ? true : false);
            objbsmod.AffectstheCostofGoodsinPurchase = Convert.ToBoolean(cbxaffectsthecostofgoodsinpurchase.Text.ToString() == "Y" ? true : false);
            objbsmod.AffectstheCostofGoodsinMaterialIssue = Convert.ToBoolean(cbxAffecsthecostofgoodsinMaterialissue.Text.ToString() == "Y" ? true : false);
            objbsmod.AffectstheCostofGoodsinMaterialReceipt = Convert.ToBoolean(cbxAffectsthecostofgoodsinmaterialreceipt.Text.ToString() == "Y" ? true : false);
            objbsmod.AffectstheCostofGoodsinStockTransfer = Convert.ToBoolean(cbxAffectsthecostofgoodsinstockTransfer.Text.ToString() == "Y" ? true : false);

            //Accounting In Sales
            objbsmod.SaleAffectsAccounting = Convert.ToBoolean(cbxSaleaffectsAcc.Text.ToString() == "Y" ? true : false);
            objbsmod.SaleAdjustInSaleAmount = Convert.ToBoolean(cbxSaleAdjustsaleamount.Text.ToString() == "Y" ? true : false);
            objbsmod.SaleSpecifyAccountHere = cbxSaleAccountLedgerSpecify.Text.ToString();
            objbsmod.SaleAccounttoHeadPost = cbxSaleAccHeadpost.Text.ToString();
            objbsmod.SaleAdjustInPartyAmount = Convert.ToBoolean(cbxSaleAdjustinpartyAmount.Text.ToString() == "Y" ? true : false);
            objbsmod.SalePartSpecifyAccountHere = cbxPartysaleAccountLedgerSpecify.Text.ToString();
            objbsmod.SaleAccounttoHeadPostParty = cbxSaleAccHeadpostParty.Text.ToString();
            if (objbsmod.SaleAdjustInSaleAmount)
            {
                objbsmod.SalePostOverandAbove = cbxSalePostoverandAbove.SelectedItem.ToString() == "Y" ? true : false;
            }


            //Accounting In Purchase
            objbsmod.PurcAffectsAccounting = Convert.ToBoolean(cbxPurcAftAccount.Text.ToString() == "Y" ? true : false);
            objbsmod.PurcAdjustInPurcAmount = Convert.ToBoolean(cbxPurcPurchaseAmount.Text.ToString() == "Y" ? true : false);
            objbsmod.PurcSpecifyAccountHere = cbxPurcAccountLedgerSpecify.SelectedItem.ToString();
            objbsmod.PurcAccounttoHeadPost = cbxPurcHeadPost.Text.ToString();
            objbsmod.PurcAdjustInPartyAmount = Convert.ToBoolean(cbxPurcPartyAmount.Text.ToString() == "Y" ? true : false);
            objbsmod.PurcParySpecifyAccountHere = cbxPartyPurcAccountLedgerSpecify.SelectedItem.ToString();
            objbsmod.PurcAccounttoHeadPostParty = cbxPurcAccountHeadPostParty.SelectedItem.ToString();
            if (objbsmod.PurcAdjustInPurcAmount)
            {
                objbsmod.PurcPostOverandAbove = cbxPurcPostOverAbove.SelectedItem.ToString() == "Y" ? true : false;
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

            objbsmod.AffectAccounting = Convert.ToBoolean(cbxAffectAccounting.Text.ToString() == "Y" ? true : false);
            objbsmod.OtherSide = cbxotherside.SelectedItem == null ? string.Empty : cbxotherside.SelectedItem.ToString();
            objbsmod.Accountheadtopost = cbxAccountHeadPost.Text.Trim();
            objbsmod.AdjustinMC = cbxAdjustinmc.SelectedItem.ToString().Equals("Y") ? true : false;
            objbsmod.AdjustSpecifyAccountLedger = cbxAccountAdjustinParty.SelectedItem.ToString();
            objbsmod.AccountheadtopostParty = cbxAccountPost.SelectedItem.ToString() == null ? string.Empty : cbxAccountPost.SelectedItem.ToString();
            objbsmod.postoverandabove = Convert.ToBoolean(cbxPostoverabove.Text.ToString() == "Y" ? true : false);
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
            objbsmod.NoOfBillSundry = Convert.ToInt32(tbxNofbillsundrys.Text == null ? "0" : tbxNofbillsundrys.Text.Trim());
            objbsmod.ConsolidateBillSundriesAmount = Convert.ToBoolean(cbxConsoilatedbillsundariesamt.SelectedItem.ToString() == "Y" ? true : false);
            objbsmod.BillSundaryName = cbxBillSundary.SelectedItem.ToString();
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
            objbsmod.roundoffBillsundry = Convert.ToBoolean(cbxRoundoffBillsundryamount.SelectedItem.ToString() == "Y" ? true : false);
            if (objbsmod.roundoffBillsundry)
            {
                objbsmod.RoundoffValues = cbxRoundofValues.SelectedItem.ToString();
            }
            objbsmod.BS_Id = BillsId;
            bool isSuccess = objbsBL.UpdateBSM(objbsmod);
            if (isSuccess)
            {
                MessageBox.Show("Update Successfully!");
                Administration.List.BillsundaryList frmBSList = new Administration.List.BillsundaryList();
                frmBSList.StartPosition = FormStartPosition.CenterScreen;
                frmBSList.ShowDialog();
                FillBillSundryInfo();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDelete = objbsBL.DeleteBillSundryById(BillsId);
            if(isDelete)
            {
                MessageBox.Show("Delete Successfully!");
                Administration.List.BillsundaryList frmBSList = new Administration.List.BillsundaryList();
                frmBSList.StartPosition = FormStartPosition.CenterScreen;
                frmBSList.ShowDialog();
                FillBillSundryInfo();
            }
        }

        private void BillSundaryMaster_Load(object sender, EventArgs e)
        {
            tbxName.Focus();
            DefaultValuesofForm();
            LoadAccountLedger();
            laCtrlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            laCtrlUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            laCtrlDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }
        private void DefaultValuesofForm()
        {
            cbxSubtotalheading.SelectedIndex = 0;
            cbxAffectsthecostofgoodsinsale.SelectedIndex = 1;
            cbxaffectsthecostofgoodsinpurchase.SelectedIndex = 1;
            cbxAffecsthecostofgoodsinMaterialissue.SelectedIndex = 1;
            cbxAffectsthecostofgoodsinmaterialreceipt.SelectedIndex = 1;
            cbxAffectsthecostofgoodsinstockTransfer.SelectedIndex = 1;
            cbxSaleaffectsAcc.SelectedIndex = 0;
            cbxPurcAftAccount.SelectedIndex = 0;
            lactrlgrpMaterialIssRec.Enabled = true;
            lactrlgrpPreviousBillSundary.Enabled = false;
            lactrlgrpBillSundaryCalcu.Enabled = false;
            cbxAffectAccounting.SelectedIndex = 1;
        }
        private void LoadAccountLedger()
        {
            cbxSaleAccHeadpost.Properties.Items.Clear();
            cbxSaleAccHeadpostParty.Properties.Items.Clear();
            cbxPurcHeadPost.Properties.Items.Clear();
            cbxPurcAccountHeadPostParty.Properties.Items.Clear();
            cbxAccountHeadPost.Properties.Items.Clear();
            cbxAccountPost.Properties.Items.Clear();
            cbxBillSundary.Properties.Items.Clear();
            List<AccountMasterModel> lstAccounts = objAccBl.GetListofAccount();
            foreach(AccountMasterModel objAccounts in lstAccounts)
            {
                cbxSaleAccHeadpost.Properties.Items.Add(objAccounts.AccountName);
                cbxSaleAccHeadpostParty.Properties.Items.Add(objAccounts.AccountName);
                cbxPurcHeadPost.Properties.Items.Add(objAccounts.AccountName);
                cbxPurcAccountHeadPostParty.Properties.Items.Add(objAccounts.AccountName);
                cbxAccountHeadPost.Properties.Items.Add(objAccounts.AccountName);
                cbxAccountPost.Properties.Items.Add(objAccounts.AccountName);
                cbxAccountHeadPost.Properties.Items.Add(objAccounts.AccountName);
            }

            List<BillSundryMasterModel> lstBillSundary = objbsBL.GetAllBillSundry();
            foreach(BillSundryMasterModel objBill in lstBillSundary)
            {
                cbxBillSundary.Properties.Items.Add(objBill.Name);
            }
        }

        private void cbxSaleaffectsAcc_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cbxPurcAftAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbxSaleaffectsAcc.SelectedItem.ToString() == "Y")
            {
                lactrlPAdjinPurcAmount.Enabled = true;
                lactrlPAdjinPartyAmount.Enabled = true;
                cbxPurcPurchaseAmount.SelectedIndex = 0;
                cbxPurcPartyAmount.SelectedIndex = 0;
            }
            else
            {
                cbxPurcPurchaseAmount.Text = "";
                cbxPurcPartyAmount.Text = "";
                cbxPurcPostOverAbove.Text = "";
                lactrlPAdjinPurcAmount.Enabled = false;
                lactrlSpyAdjPurcAmount.Enabled = false;
                lactrlPurcAccHeadtoPost.Enabled = false;
                lactrlPAdjinPartyAmount.Enabled = false;
                lactrlAdjSpyPartyAmount.Enabled = false;
                lactrlPAccPartyHeadtoPost.Enabled = false;
                lactrlPurcPostOverAbove.Enabled = false;
            }
        }

        private void cbxSaleaffectsAcc_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void cbxSaleAdjustsaleamount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxSaleAdjustsaleamount.SelectedItem.ToString()=="Y")
            {
                lactrlSaleAccountSale.Enabled = false;
                lactrlAccountHeadtoPostSale.Enabled = false;
                lactrlPostOverandAboveSale.Enabled = false;
                cbxSalePostoverandAbove.SelectedIndex = -1;
                cbxSaleAccountLedgerSpecify.Text = "";
                cbxSaleAccHeadpost.Text = "";
            }
            else
            {
                lactrlSaleAccountSale.Enabled = true;
                lactrlAccountHeadtoPostSale.Enabled = false;
                lactrlPostOverandAboveSale.Enabled = true;              
                cbxSalePostoverandAbove.SelectedIndex = 1;
            }
        }

        private void cbxSaleAdjustsaleamount_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void cbxSaleAccountLedgerSpecify_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxSaleAccountLedgerSpecify.SelectedItem.ToString()== "Specify Acc. Here")
            {
                lactrlAccountHeadtoPostSale.Enabled = true;

            }
            else
            {
                lactrlAccountHeadtoPostSale.Enabled = false;
                cbxSaleAccHeadpost.Text = "";
            }
        }

        private void cbxSaleAdjustinpartyAmount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSaleAdjustinpartyAmount.SelectedItem.ToString() == "Y")
            {
                lactrlAccounttoHeadtoPostSle.Enabled = false;
                lactrlSaleParty.Enabled = false;
                cbxPartysaleAccountLedgerSpecify.Text = "";
                cbxSaleAccHeadpostParty.Text = "";
            }
            else
            {
                lactrlSaleParty.Enabled = true;
                lactrlAccounttoHeadtoPostSle.Enabled = false;
               
            }
        }

        private void cbxPartysaleAccountLedgerSpecify_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPartysaleAccountLedgerSpecify.SelectedItem.ToString() =="Specify Acc. Here")
            {
                lactrlAccounttoHeadtoPostSle.Enabled = true;
            }
            else
            {
                lactrlAccounttoHeadtoPostSle.Enabled = false;
                cbxSaleAccHeadpostParty.Text = "";
            }
        }

        private void cbxSaleaffectsAcc_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbxSaleaffectsAcc.SelectedItem.ToString() == "Y")
            {
                lactrlSaleAmountSale.Enabled = true;
                lactrlAdjustinPartyAmountSale.Enabled = true;
                cbxSaleAdjustsaleamount.SelectedIndex = 0;
                cbxSaleAdjustinpartyAmount.SelectedIndex = 0;
            }
            else
            {
                cbxSaleAdjustsaleamount.Text = "";
                cbxSaleAdjustinpartyAmount.Text ="";
                cbxSalePostoverandAbove.Text = "";
                lactrlSaleAmountSale.Enabled = false;
                lactrlSaleAccountSale.Enabled = false;
                lactrlAccountHeadtoPostSale.Enabled = false;
                lactrlAdjustinPartyAmountSale.Enabled = false;
                lactrlSaleParty.Enabled = false;
                lactrlAccounttoHeadtoPostSle.Enabled = false;
                lactrlPostOverandAboveSale.Enabled = false;
            }
        }

        private void cbxPurcAftAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbxPurcAftAccount_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbxPurcAftAccount.SelectedItem.ToString() == "Y")
            {
                lactrlPAdjinPurcAmount.Enabled = true;
                lactrlPAdjinPartyAmount.Enabled = true;
                cbxPurcPurchaseAmount.SelectedIndex = 0;
                cbxPurcPartyAmount.SelectedIndex = 0;
            }
            else
            {
                cbxPurcPurchaseAmount.Text = "";
                cbxPurcPartyAmount.Text = "";
                cbxPurcPostOverAbove.Text = "";
                lactrlPAdjinPurcAmount.Enabled = false;
                lactrlSpyAdjPurcAmount.Enabled = false;
                lactrlPurcAccHeadtoPost.Enabled = false;
                lactrlPAdjinPartyAmount.Enabled = false;
                lactrlAdjSpyPartyAmount.Enabled = false;
                lactrlPAccPartyHeadtoPost.Enabled = false;
                lactrlPurcPostOverAbove.Enabled = false;
            }
        }

        private void cbxPurcPurchaseAmount_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbxPurcPurchaseAmount.SelectedItem.ToString() == "Y")
            {
                lactrlSpyAdjPurcAmount.Enabled = false;
                lactrlPurcAccHeadtoPost.Enabled = false;
                lactrlPurcPostOverAbove.Enabled = false;
                cbxPurcPostOverAbove.SelectedIndex = -1;
                cbxPurcAccountLedgerSpecify.Text = "";
                cbxPurcHeadPost.Text = "";
            }
            else
            {
                lactrlSpyAdjPurcAmount.Enabled = true;
                lactrlPurcAccHeadtoPost.Enabled = false;
                lactrlPurcPostOverAbove.Enabled = true;
                cbxPurcPostOverAbove.SelectedIndex = 1;
            }
        }

        private void cbxPartyPurcAccountLedgerSpecify_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbxPartyPurcAccountLedgerSpecify.SelectedItem.ToString() == "Specify Acc. Here")
            {
                lactrlPAccPartyHeadtoPost.Enabled = true;
            }
            else
            {
                lactrlPAccPartyHeadtoPost.Enabled = false;
                cbxPurcAccountHeadPostParty.Text = "";
            }
        }

        private void cbxPurcAccountLedgerSpecify_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbxPurcAccountLedgerSpecify.SelectedItem.ToString() == "Specify Acc. Here")
            {
                lactrlPurcAccHeadtoPost.Enabled = true;
            }
            else
            {
                lactrlPurcAccHeadtoPost.Enabled = false;
                cbxPurcHeadPost.Text = "";
            }
        }

        private void cbxPurcPartyAmount_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbxPurcPartyAmount.SelectedItem.ToString() == "Y")
            {
                lactrlAdjSpyPartyAmount.Enabled = false;
                lactrlPAccPartyHeadtoPost.Enabled = false;
                cbxPartyPurcAccountLedgerSpecify.Text = "";
                cbxPurcAccountHeadPostParty.Text = "";
            }
            else
            {
                lactrlAdjSpyPartyAmount.Enabled = true;
                lactrlPAccPartyHeadtoPost.Enabled = false;

            }
        }

        private void cbxAffectAccounting_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cbxAffectAccounting.SelectedItem.ToString()=="N")
            {
                lactrlOtherSide.Enabled = false;
                lactrlAccounttoHeadPost.Enabled = false;
                lactrlAdjinParty.Enabled = false;
                lactrlSpecifyAccParty.Enabled = false;
                lactrlPartyAcctoHeadPost.Enabled = false;
                lactrlPostoverAbove.Enabled = false;
                cbxAdjustinmc.Text = "";
                cbxPostoverabove.Text ="";
            }
            else
            {
                lactrlOtherSide.Enabled = true;
                lactrlAccounttoHeadPost.Enabled = true;
                lactrlAdjinParty.Enabled = true;
                lactrlSpecifyAccParty.Enabled = true;
                lactrlPartyAcctoHeadPost.Enabled =  true;
                lactrlPostoverAbove.Enabled = true;
                cbxAdjustinmc.SelectedIndex = 1;
                cbxPostoverabove.SelectedIndex = 1;
            }
        }

        private void cbxAffectAccounting_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbxAffectAccounting.SelectedItem.ToString() == "N")
            {
                lactrlOtherSide.Enabled = false;
                lactrlAccounttoHeadPost.Enabled = false;
                lactrlAdjinParty.Enabled = false;
                lactrlSpecifyAccParty.Enabled = false;
                lactrlPartyAcctoHeadPost.Enabled = false;
                lactrlPostoverAbove.Enabled = false;
                cbxAdjustinmc.Text = "";
                cbxPostoverabove.Text = "";
            }
            else
            {
                lactrlOtherSide.Enabled = true;
                lactrlAccounttoHeadPost.Enabled = true;
                lactrlAdjinParty.Enabled = true;
                lactrlSpecifyAccParty.Enabled = true;
                lactrlPartyAcctoHeadPost.Enabled = true;
                lactrlPostoverAbove.Enabled = true;
                cbxAdjustinmc.SelectedIndex = 1;
                cbxPostoverabove.SelectedIndex = 1;
            }
        }

        private void cbxotherside_Enter(object sender, EventArgs e)
        {
            cbxotherside.ShowPopup();
        }

        private void cbxAccountHeadPost_Enter(object sender, EventArgs e)
        {
            cbxAccountHeadPost.ShowPopup();
        }

        private void cbxAccountAdjustinParty_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cbxAccountAdjustinParty.SelectedItem.ToString()== "Specify Acc. Here")
            {
                lactrlPartyAcctoHeadPost.Enabled = true;
            }
            else
            {
                lactrlPartyAcctoHeadPost.Enabled = false;
                cbxAccountPost.Text = "";
            }
        }

        private void cbxAdjustinmc_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cbxAdjustinmc.SelectedItem.ToString()=="Y")
            {
                lactrlSpecifyAccParty.Enabled = false;
                lactrlPartyAcctoHeadPost.Enabled = false;
                cbxAccountAdjustinParty.Text = "";
                cbxAccountPost.Text = "";
            }
            else
            {
                lactrlSpecifyAccParty.Enabled = true;
                lactrlPartyAcctoHeadPost.Enabled = false;
            }
        }
    }
}
