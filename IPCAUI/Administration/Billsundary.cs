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
            objbsmod.Alias = tbxAlias.Text;
            objbsmod.PrintName = tbxPrintName.Text;
            objbsmod.BillSundryType = cbxBillsundrytype.Text;
            objbsmod.BillSundryNature = cbxBillsundrynature.Text;
            objbsmod.DefaultValue = Convert.ToDecimal(cbxdefaultvalue.Text.ToString());
          
            objbsmod.AffectstheCostofGoodsinSale = Convert.ToBoolean(cbxAffectsthecostofgoodsinsale.Text.ToString()=="Y"? true:false);
            objbsmod.AffectstheCostofGoodsinPurchase = Convert.ToBoolean(cbxaffectsthecostofgoodsinpurchase.Text.ToString() == "Y" ? true : false);
            objbsmod.AffectstheCostofGoodsinMaterialIssue = Convert.ToBoolean(cbxaffecsthecostofgoodsinmaterialissue.Text.ToString() == "Y" ? true : false);
            objbsmod.AffectstheCostofGoodsinMaterialReceipt = Convert.ToBoolean(cbxaffectsthecostofgoodsinmaterialreceipt.Text.ToString() == "Y" ? true : false);
            objbsmod.AffectstheCostofGoodsinStockTransfer = Convert.ToBoolean(cbxaffectsthecostofgoodsinstocktransfer.Text.ToString() == "Y" ? true : false);
            objbsmod.AffectAccounting = Convert.ToBoolean(cbxaffectsaccounting.Text.ToString() == "Y" ? true : false);
            objbsmod.AdjustInSaleAmount= Convert.ToBoolean(cbxadjustsaleamount.Text.ToString() == "Y" ? true : false);
            objbsmod.AccounttoHeadPost =cbxaccounttoheadpost.Text.ToString();
            objbsmod.AdjustInPartyAmount = Convert.ToBoolean(cbxadjustinpartyamount.Text.ToString() == "Y" ? true : false);
            objbsmod.AccounttoHeadPost = cbxaccounttoheadpost.Text.ToString();
            objbsmod.AdjustInPartyAmount = Convert.ToBoolean(cbxadjustinpartyamount.Text.ToString() == "Y" ? true : false);
            objbsmod.AccounttoHeadPost = cbxaccounttoheadpost.Text.ToString();
            objbsmod.postoverandabove= Convert.ToBoolean(cbxpostoverandabove.Text.ToString() == "Y" ? true : false);
            objbsmod.AffectAccounting = Convert.ToBoolean(cbxaffectsaccounting.Text.ToString() == "Y" ? true : false);
            objbsmod.AdjustInPurchaseAmount = Convert.ToBoolean(cbxadjustinpurchaseamount.Text.ToString() == "Y" ? true : false);
            objbsmod.AccounttoHeadPost = cbxaccounttoheadpost.Text.ToString();
            objbsmod.AdjustInPartyAmount = Convert.ToBoolean(cbxadjustinpartyamount.Text.ToString() == "Y" ? true : false);
            objbsmod.AccounttoHeadPost = cbxaccounttoheadpost.Text.ToString();
            objbsmod.postoverandabove = Convert.ToBoolean(cbxpostoverandabove.Text.ToString() == "Y" ? true : false);
           // objbsmod.typeMaterialIssue = "true";
            objbsmod.AffectAccounting = Convert.ToBoolean(cbxpostoverandabove.Text.ToString() == "Y" ? true : false);
            objbsmod.OtherSide = cbxotherside.Text;
            objbsmod.Accountheadtopost = cbxaccounttoheadpost.Text;
            objbsmod.AdjustinMC = cbxadjustinmc.Text;
            objbsmod.Accountheadtopost = cbxaccounttoheadpost.Text;
            objbsmod.postoverandabove =  Convert.ToBoolean(cbxpostoverandabove.Text.ToString() == "Y" ? true : false );
          //  objbsmod.typeAbsoluteAmount = rbabsoluteamount.ToString();
            objbsmod.typePerMainQty = rbpermainquantity.ToString();
            objbsmod.typePercentage = rbpercentage.ToString();
            objbsmod.PerAltQty = rbperaltquantity.ToString();
            objbsmod.typeNetBillAmount = rbnetbillamount.ToString();
            objbsmod.tyeItemsBasicAmt = rbitembasicamount.ToString();
            objbsmod.typeTotalMRPofItems = rbtotalmrpofitems.ToString();
            objbsmod.typeTaxableAmount = rbtaxableamount.ToString();
            objbsmod.typePreviousBillSundryAmount = rbbillsundryamount.ToString();
            objbsmod.typeOtherBillsundry = rbotherbillsundry.ToString();
            objbsmod.roundoffBillsundry = cbxroundoffbillsundryamount.ToString();
            objbsmod.NoOfBillSundry = cbnoofbillsundrys.ToString();
            objbsmod.ConsolidateBillSundriesAmount = Convert.ToBoolean(cbconsoilatedbillsundariesamt.ToString() == "Y" ? true : false);
            objbsmod.BSAmt = rbbillsundryamount.ToString();
            objbsmod.subtotalheading = cbxsubtotalheading.Text;



            //objGroup.Group = tbxGroupName.Text.TrimEnd();
            //objGroup.Alias = tbxAliasname.Text.Trim();
            //objGroup.PrimaryGroup = cbxPrimarygroup.SelectedItem.ToString() == "Y" ? true : false;
            //objGroup.UnderGroup = cbxUndergroup.SelectedItem.ToString();
            //objGroup.CreatedBy = "Admin";

            bool isSuccess = objbsmas.SaveBSM(objbsmod);
            if(isSuccess)
            {
                MessageBox.Show("Saved Successfully!");
            }
            //List<MaterialCentreGroupMasterModel> lstGroups = MatObj.GetAllMaterialGroups();
            //dgvList.DataSource = lstGroups;
            //Dialogs.PopUPDialog d = new Dialogs.PopUPDialog("Saved Successfully!");
            //d.ShowDialog();
            //btnSave.Visible = true;

        }
    }
}