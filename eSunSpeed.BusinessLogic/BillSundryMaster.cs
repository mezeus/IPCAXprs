using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;
using eSunSpeed.BusinessLogic;
using eSunSpeedDomain;

namespace eSunSpeed.BusinessLogic
{
   public class BillSundryMaster
    {
        BillSundryMasterModel objbsmasmod = new BillSundryMasterModel();
        private DBHelper _dbHelper = new DBHelper();

        public bool SaveBSM(eSunSpeedDomain.BillSundryMasterModel objBSM)
        {
           
            string Query = string.Empty;
            bool isSaved = true;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Name", objBSM.Name));
                paramCollection.Add(new DBParameter("@Alias", objBSM.Alias));
                paramCollection.Add(new DBParameter("@PrintName", objBSM.PrintName));
                paramCollection.Add(new DBParameter("@BillSundryType", objBSM.BillSundryType));
                paramCollection.Add(new DBParameter("@BillSundryNature", objBSM.BillSundryNature));
                paramCollection.Add(new DBParameter("@DefaultValue", objBSM.DefaultValue));
                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinSale", objBSM. AffectstheCostofGoodsinSale, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinPurchase", objBSM.AffectstheCostofGoodsinPurchase, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinMaterialIssue", objBSM.AffectstheCostofGoodsinMaterialIssue, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinMaterialReceipt", objBSM.AffectstheCostofGoodsinMaterialReceipt, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinStockTransfer", objBSM.AffectstheCostofGoodsinStockTransfer, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AffectsAccounting", objBSM.AffectsAccounting, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AdjustInSaleAmount", objBSM.AdjustInSaleAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AccounttoHeadPost", objBSM.AccounttoHeadPost));
                paramCollection.Add(new DBParameter("@AdjustInPartyAmount", objBSM.AdjustInPartyAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@PostOverandAbove", objBSM.PostOverandAbove));
                paramCollection.Add(new DBParameter("@AdjustInPurchaseAmount", objBSM.AdjustInPurchaseAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeMaterialIssue", objBSM.typeMaterialIssue,System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeMaterialReceipt", objBSM.typeMaterialReceipt));
                paramCollection.Add(new DBParameter("@StockTransfer", objBSM.StockTransfer));
                paramCollection.Add(new DBParameter("@AffectAccounting", objBSM.AffectAccounting));
                paramCollection.Add(new DBParameter("@OtherSide", objBSM.OtherSide));
                paramCollection.Add(new DBParameter("@AdjustinMC", objBSM.AdjustinMC));
               // paramCollection.Add(new DBParameter("@typeAbsoluteAmount", objBSM.typeAbsoluteAmount));
                paramCollection.Add(new DBParameter("@typePercentage", objBSM.typePercentage));
                paramCollection.Add(new DBParameter("@typePerMainQty", objBSM.typePerMainQty));
                paramCollection.Add(new DBParameter("@Percentoff", objBSM.Percentoff));
                paramCollection.Add(new DBParameter("@typeNetBillAmount", objBSM.typeNetBillAmount));
                paramCollection.Add(new DBParameter("@SelectiveCalculation", objBSM.SelectiveCalculation, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@tyeItemsBasicAmt", objBSM.tyeItemsBasicAmt));
                paramCollection.Add(new DBParameter("@typeTotalMRPofItems", objBSM.typeTotalMRPofItems));
                paramCollection.Add(new DBParameter("@typeTaxableAmount", objBSM.typeTaxableAmount));
                paramCollection.Add(new DBParameter("@typePreviousBillSundryAmount", objBSM.typePreviousBillSundryAmount));
                paramCollection.Add(new DBParameter("@typeOtherBillsundry", objBSM.typeOtherBillsundry));
                paramCollection.Add(new DBParameter("@RBSAmt", objBSM.RBSAmt, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@BSAmt", objBSM.BSAmt));
                paramCollection.Add(new DBParameter("@BSAppOn ", objBSM.BSAmt));
                paramCollection.Add(new DBParameter("@TextBox", objBSM.TextBox));
                paramCollection.Add(new DBParameter("@NoOfBillSundrys", objBSM.NoOfBillSundry));
                paramCollection.Add(new DBParameter("@ConsolidateBillSundriesAmount", objBSM.ConsolidateBillSundriesAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                paramCollection.Add(new DBParameter("@subtotalheading", objBSM.subtotalheading));

                Query = "INSERT INTO billsundrymaster(`Name`,`Alias`,`PrintName`,`BillSundryType`,`BillSundryNature`,`DefaultValue`," +
                    "`AffectstheCostofGoodsinSale`,`AffectstheCostofGoodsinPurchase`,`AffectstheCostofGoodsinMaterialIssue`,`AffectstheCostofGoodsinMaterialReceipt`," +
                    "`AffectstheCostofGoodsinStockTransfer`,`AffectsAccounting`,`AdjustInSaleAmount`,`AccountHeadtoPost`,`AdjustInPartyAmount`,`PostOverandAbove`," +
                    "`AdjustInPurchaseAmount`,`typeMaterialIssue`,`typeMaterialReceipt`,`StockTransfer`," +
                   " `AffectAccounting`,`OtherSide`,`AdjustinMC`,`typePercentage`,`typePerMainQty`,`Percentoff`,`typeNetBillAmount`," +
                    "`SelectiveCalculation`,`tyeItemsBasicAmt`,`typeTotalMRPofItems`,`typeTaxableAmount`,`typePreviousBillSundryAmount`,`typeOtherBillsundry`," +
                    "`RBSAmt`,`BSAmt`,`BSAppon`,`TextBox`,`NoOfBillSundrys`,`ConsolidateBillSundriesAmount`,`CreatedBy`,`subtotalheading`) " +
                    "VALUES(@Name,@Alias,@PrintName,@BillSundryType,@BillSundryNature,@DefaultValue,@AffectstheCostofGoodsinSale,@AffectstheCostofGoodsinPurchase," +
                    "@AffectstheCostofGoodsinMaterialIssue,@AffectstheCostofGoodsinMaterialReceipt,@AffectstheCostofGoodsinStockTransfer,@AffectsAccounting, " +
                    "@AdjustInSaleAmount,@AccountHeadtoPost,@AdjustInPartyAmount,@PostOverandAbove,@AdjustInPurchaseAmount,@typeMaterialIssue,@typeMaterialReceipt," +
                    "@StockTransfer,@AffectAccounting,@OtherSide,@AdjustinMC,@typePercentage,@typePerMainQty,@Percentoff,@typeNetBillAmount," +
                    "@SelectiveCalculation,@tyeItemsBasicAmt,@typeTotalMRPofItems,@typeTaxableAmount,@typePreviousBillSundryAmount,@typeOtherBillsundry," +
                    "@RoundoffBillSundryAmount,@typeBillSundryAmount,@typeBillSundryAppliedOn,@TextBox,@NoOfBillSundrys,@ConsolidateBillSundriesAmount,@CreatedBy,@subtotalheading)";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                    isSaved = true;
            }
            catch (Exception ex)
            {
                isSaved = false;
                throw ex;
            }

            return isSaved;
        }

        //UPDATE
        public bool UpdateBSM(eSunSpeedDomain.BillSundryMasterModel objBSM)
        {
            string Query = string.Empty;
            bool isUpdated = true;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Name", objBSM.Name));
                paramCollection.Add(new DBParameter("@Alias", objBSM.Alias));
                paramCollection.Add(new DBParameter("@PrintName", objBSM.PrintName));
                paramCollection.Add(new DBParameter("@BillSundryType", objBSM.BillSundryType));
                paramCollection.Add(new DBParameter("@BillSundryNature", objBSM.BillSundryNature));
                paramCollection.Add(new DBParameter("@DefaultValue", objBSM.DefaultValue));
                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinSale", objBSM.AffectstheCostofGoodsinSale, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinPurchase", objBSM.AffectstheCostofGoodsinPurchase, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinMaterialIssue", objBSM.AffectstheCostofGoodsinMaterialIssue, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinMaterialReceipt", objBSM.AffectstheCostofGoodsinMaterialReceipt, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinStockTransfer", objBSM.AffectstheCostofGoodsinStockTransfer, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AffectsAccounting", objBSM.AffectsAccounting, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AdjustInSaleAmount", objBSM.AdjustInSaleAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AccountHeadtoPost", objBSM.AccounttoHeadPost));
                paramCollection.Add(new DBParameter("@AdjustInPartyAmount", objBSM.AdjustInPartyAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@PostOverandAbove", objBSM.PostOverandAbove));
                paramCollection.Add(new DBParameter("@AdjustInPurchaseAmount", objBSM.AdjustInPurchaseAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeMaterialIssue", objBSM.typeMaterialIssue));
                paramCollection.Add(new DBParameter("@typeMaterialReceipt", objBSM.typeMaterialReceipt));
                paramCollection.Add(new DBParameter("@StockTransfer", objBSM.StockTransfer));
                paramCollection.Add(new DBParameter("@AffectAccounting", objBSM.AffectAccounting));
                paramCollection.Add(new DBParameter("@OtherSide", objBSM.OtherSide));
                paramCollection.Add(new DBParameter("@AdjustinMC", objBSM.AdjustinMC));
                paramCollection.Add(new DBParameter("@typeAbsoluteAmunt", objBSM.typeAbsoluteAmount));
                paramCollection.Add(new DBParameter("@typePercentage", objBSM.typePercentage));
                paramCollection.Add(new DBParameter("@typePerMainQty", objBSM.typePerMainQty));
                paramCollection.Add(new DBParameter("@Percentoff", objBSM.Percentoff));
                paramCollection.Add(new DBParameter("@typeNetBillAmount", objBSM.typeNetBillAmount));
                paramCollection.Add(new DBParameter("@SelectiveCalculation", objBSM.SelectiveCalculation, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@tyeItemsBasicAmt", objBSM.tyeItemsBasicAmt));
                paramCollection.Add(new DBParameter("@typeTotalMRPofItems", objBSM.typeTotalMRPofItems));
                paramCollection.Add(new DBParameter("@typeTaxableAmount", objBSM.typeTaxableAmount));
                paramCollection.Add(new DBParameter("@typePreviousBillSundryAmount", objBSM.typePreviousBillSundryAmount));
                paramCollection.Add(new DBParameter("@typeOtherBillsundry", objBSM.typeOtherBillsundry));
                paramCollection.Add(new DBParameter("@RoundoffBillSundryAmount", objBSM.RBSAmt, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeBillSundryAmount", objBSM.BSAmt));
                paramCollection.Add(new DBParameter("@typeBillSundryAppliedOn", objBSM.BSAppOn));
                paramCollection.Add(new DBParameter("@TextBox", objBSM.TextBox));
                paramCollection.Add(new DBParameter("@NoOfBillSundrys", objBSM.NoOfBillSundry));
                paramCollection.Add(new DBParameter("@ConsolidateBillSundriesAmount", objBSM.ConsolidateBillSundriesAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@Id", objBSM.BS_Id));


                Query = "UPDATE BillSundryMaster SET [Name]=@Name,[Alias]=@Alias,[PrintName]=@PrintName,[BillSundryType]=@BillSundryType,[BillSundryNature]=@BillSundryNature,[DefaultValue]=@DefaultValue," +
                   "[AffectstheCostofGoodsinSale]=@AffectstheCostofGoodsinSale,[AffectstheCostofGoodsinPurchase]=@AffectstheCostofGoodsinPurchase,[AffectstheCostofGoodsinMaterialIssue]=@AffectstheCostofGoodsinMaterialIssue,[AffectstheCostofGoodsinMaterialReceipt]=@AffectstheCostofGoodsinMaterialReceipt," +
                   "[AffectstheCostofGoodsinStockTransfer]=@AffectstheCostofGoodsinStockTransfer,[AffectsAccounting]=@AffectsAccounting,[AdjustInSaleAccount]=@AdjustInSaleAccount,[AccountHeadtoPost]=@AccountHeadtoPost,[AdjustInPartyAmount]=@AdjustInPartyAmount,[PostOverandAbove]=@PostOverandAbove," +
                   "[AdjustInPurchaseAccount]=@AdjustInPurchaseAccount,[typeMaterialIssue]=@typeMaterialIssue,[typeMaterialReceipt]=@typeMaterialReceipt,[StockTransfer]=@StockTransfer," +
                   "[AffectAccounting]=@AffectAccounting,[OtherSide]=@OtherSide,[AdjustinMC]=@AdjustinMC,[typeAbsoluteAmunt]=@typeAbsoluteAmunt,[typePercentage]=@typePercentage,[typePerMainQty]=@typePerMainQty,[Percentoff]=@Percentoff,[typeNetBillAmount]=@typeNetBillAmount," +
                   "[SelectiveCalculation]=@SelectiveCalculation,[tyeItemsBasicAmt]=@tyeItemsBasicAmt,[typeTotalMRPofItems]=@typeTotalMRPofItems,[typeTaxableAmount]=@typeTaxableAmount,[typePreviousBillSundryAmount]=@typePreviousBillSundryAmount,[typeOtherBillsundry]=@typeOtherBillsundry," +
                   "[RoundoffBillSundryAmount]=@RoundoffBillSundryAmount,[typeBillSundryAmount]=@typeBillSundryAmount,[typeBillSundryAppliedOn]=@typeBillSundryAppliedOn,[TextBox]=@TextBox,[NoOfBillSundrys]=@NoOfBillSundrys,[ConsolidateBillSundriesAmount]=@ConsolidateBillSundriesAmount,[ModifiedBy]=@ModifiedBy  " +
                   "WHERE BS_Id=@BS_Id";



                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                    isUpdated = true;
            }
            catch (Exception ex)
            {
                isUpdated = false;
                throw ex;
            }

            return isUpdated;
        }

        //Delete
        
        public bool DeletBillSundry(List<int> lstIds)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection;

                foreach (int id in lstIds)
                {
                    paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@acountid", id));
                    Query = "Delete from BillSundryMaster WHERE [BS_Id]=@id";

                    if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                        isUpdated = true;
                }

            }
            catch (Exception ex)
            {
                isUpdated = false;
                throw ex;
            }

            return isUpdated;
        }

        //List
        public List<BillSundryMasterModel> GetAllBillSundry()
        {
            List<eSunSpeedDomain.BillSundryMasterModel> lstBsm = new List<BillSundryMasterModel>();
            eSunSpeedDomain.BillSundryMasterModel objBsm;
           

            string Query = "SELECT * FROM BillSundryMaster";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {

                objBsm = new BillSundryMasterModel();
                objBsm.BS_Id = Convert.ToInt32(dr["BS_iD"]);
                objBsm.Name = dr["Name"].ToString();
                objBsm.Alias = dr["Alias"].ToString();
                objBsm.PrintName = dr["PrintName"].ToString();
                objBsm.BillSundryType = dr["BillSundryType"].ToString();
                objBsm.BillSundryNature = dr["BillSundryNature"].ToString();
                objBsm.DefaultValue = Convert.ToDecimal("DefaultValue".ToString());
                objBsm.AffectstheCostofGoodsinSale= Convert.ToBoolean(dr["AffectstheCostofGoodsinSale"]);
                objBsm.AffectstheCostofGoodsinPurchase = Convert.ToBoolean(dr["AffectstheCostofGoodsinPurchase"]);
                objBsm.AffectstheCostofGoodsinMaterialIssue = Convert.ToBoolean(dr["AffectstheCostofGoodsinMaterialIssue"]);
                objBsm.AffectstheCostofGoodsinMaterialReceipt = Convert.ToBoolean(dr["AffectstheCostofGoodsinMaterialReceipt"]);
                objBsm.AffectstheCostofGoodsinStockTransfer = Convert.ToBoolean(dr["AffectstheCostofGoodsinStockTransfer"]);
                objBsm.AffectsAccounting = Convert.ToBoolean(dr["AffectsAccounting"]);
                objBsm.AdjustInSaleAmount = Convert.ToBoolean(dr["AdjustInSaleAmount"]);
                objBsm.AccounttoHeadPost = dr["AccounttoHeadPost"].ToString();
                objBsm.AdjustInPartyAmount = Convert.ToBoolean(dr["AdjustInPartyAmount"]);
                objBsm.PostOverandAbove = dr["PostOverandAbove"].ToString();
                objBsm.AdjustInPurchaseAmount = Convert.ToBoolean(dr["AdjustInPurchaseAmount"]);
                //objBsm.typeMaterialIssue = dr["typeMaterialIssue"].ToString();
                objBsm.typeMaterialReceipt = dr["typeMaterialReceipt"].ToString();
                objBsm.StockTransfer = dr["StockTransfer"].ToString();
                objBsm.AffectAccounting =Convert.ToBoolean("AffectAccounting".ToString());
                objBsm.OtherSide = dr["OtherSide"].ToString();
                objBsm.AdjustinMC = dr["AdjustinMC"].ToString();
                objBsm.typeAbsoluteAmount = dr["typeAbsoluteAmunt"].ToString();
                objBsm.typePercentage = dr["typePercentage"].ToString();
                objBsm.typePerMainQty = dr["typePerMainQty"].ToString();
                objBsm.Percentoff = dr["Percentoff"].ToString();
                objBsm.typeNetBillAmount = dr["typeNetBillAmount"].ToString();
                objBsm.SelectiveCalculation = Convert.ToBoolean(dr["SelectiveCalculation"]);
                objBsm.tyeItemsBasicAmt = dr["tyeItemsBasicAmt"].ToString();
                objBsm.typeTotalMRPofItems = dr["typeTotalMRPofItems"].ToString();
                objBsm.typeTaxableAmount = dr["typeTaxableAmount"].ToString();
                objBsm.typePreviousBillSundryAmount= dr["typePreviousBillSundryAmount"].ToString();
                objBsm.typeOtherBillsundry = dr["typeotherBillsundry"].ToString();
                objBsm.RBSAmt = Convert.ToBoolean(dr["RBSAmt"]);
                objBsm.BSAmt = dr["BSAmt"].ToString();
                objBsm.BSAppOn = dr["BSAppOn"].ToString();
                objBsm.TextBox = dr["TextBox"].ToString();
                objBsm.NoOfBillSundry = dr["NoOfBillSundrys"].ToString();
                objBsm.ConsolidateBillSundriesAmount = Convert.ToBoolean(dr["ConsolidateBillSundriesAmount"]);
                objBsm.ModifiedBy = dr["ModifiedBy"].ToString();


               lstBsm.Add(objBsm);



            }

            return lstBsm;
        }

    }
}
