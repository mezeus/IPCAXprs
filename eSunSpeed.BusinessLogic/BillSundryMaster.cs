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
                paramCollection.Add(new DBParameter("@Subtotalheading", objBSM.subtotalheading));
                
                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinSale", objBSM. AffectstheCostofGoodsinSale, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinPurchase", objBSM.AffectstheCostofGoodsinPurchase, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinMaterialIssue", objBSM.AffectstheCostofGoodsinMaterialIssue, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinMaterialReceipt", objBSM.AffectstheCostofGoodsinMaterialReceipt, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinStockTransfer", objBSM.AffectstheCostofGoodsinStockTransfer, System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@AffectsAccountingsale", objBSM.SaleAffectsAccounting, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AdjustInSaleAmountsale", objBSM.SaleAdjustInSaleAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AccounttoHeadPostsale", objBSM.SaleAccounttoHeadPost));
                paramCollection.Add(new DBParameter("@AdjustInPartyAmountsale", objBSM.SaleAdjustInPartyAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AccounttoHeadPostpartysale", objBSM.SaleAccounttoHeadPostParty));
                paramCollection.Add(new DBParameter("@PostOverandAbovesale", objBSM.SalePostOverandAbove));

                paramCollection.Add(new DBParameter("@AffectsAccountingpurc", objBSM.PurcAffectsAccounting, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AdjustInSaleAmountpurc", objBSM.PurcAdjustInPurcAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AccounttoHeadPostpurc", objBSM.PurcAccounttoHeadPost));
                paramCollection.Add(new DBParameter("@AdjustInPartyAmountpurc", objBSM.PurcAdjustInPartyAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AccounttoHeadPostpartypurc", objBSM.PurcAccounttoHeadPostParty));
                paramCollection.Add(new DBParameter("@PostOverandAbovepurc", objBSM.PurcPostOverandAbove));

                paramCollection.Add(new DBParameter("@typeMaterialIssue", objBSM.typeMaterialIssue,System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeMaterialReceipt", objBSM.typeMaterialReceipt, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@StockTransfer", objBSM.StockTransfer, System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@AffectAccounting", objBSM.AffectAccounting, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@OtherSide", objBSM.OtherSide));
                paramCollection.Add(new DBParameter("@Accountheadtopost", objBSM.Accountheadtopost));
                paramCollection.Add(new DBParameter("@AdjustinMC", objBSM.AdjustinMC));
                paramCollection.Add(new DBParameter("@Accountheadtopostparty", objBSM.AccountheadtopostParty));
                paramCollection.Add(new DBParameter("@Postoverandabove", objBSM.postoverandabove, System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@typeAbsoluteamount", objBSM.typeAbsoluteAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typePercentage", objBSM.typePercentage, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typePerMainQty", objBSM.typePerMainQty,System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typePeraltQty", objBSM.PerAltQty,System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@Percentoff", objBSM.Percentoff));
                paramCollection.Add(new DBParameter("@typeNetBillAmount", objBSM.typeNetBillAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@SelectiveCalculation", objBSM.SelectiveCalculation, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@tyeItemsBasicAmt", objBSM.tyeItemsBasicAmt, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@IncludeFreeqty", objBSM.IncludeFreeQty, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeTotalMRPofItems", objBSM.typeTotalMRPofItems, System.Data.DbType.Boolean)); 
                paramCollection.Add(new DBParameter("@typeTaxableAmount", objBSM.typeTaxableAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typePreviousBillSundryAmount", objBSM.typePreviousBillSundryAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeOtherBillsundry", objBSM.typeOtherBillsundry, System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@BSAmt", objBSM.BSAmt, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@BSAppOn", objBSM.BSAppOn, System.Data.DbType.Boolean));
               
                paramCollection.Add(new DBParameter("@NoOfBillSundrys", objBSM.NoOfBillSundry));
                paramCollection.Add(new DBParameter("@ConsolidateBillSundriesAmount", objBSM.ConsolidateBillSundriesAmount, System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@Roundoffbillsundary", objBSM.roundoffBillsundry, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                // paramCollection.Add(new DBParameter("@subtotalheading", objBSM.subtotalheading));

                Query = "INSERT INTO billsundarymaster(`Name`,`Alias`,`PrintName`,`BillSundryType`,`BillSundryNature`,`DefaultValue`,`subtotalheading`," +
                    "`AffectstheCostofGoodsinSale`,`AffectstheCostofGoodsinPurchase`,`AffectstheCostofGoodsinMaterialIssue`,`AffectstheCostofGoodsinMaterialReceipt`," +
                    "`AffectstheCostofGoodsinStockTransfer`,`SaleAffectsAccounting`,`SaleAdjustInSaleAmount`,`SaleAccounttoHeadPost`,`SaleAdjustInPartyAmount`,`SaleAccounttoHeadPostParty`,`SalePostOverandAbove`," +
                    "`PurcAffectsAccounting`,`PurcAdjustInPurcAmount`,`PurcAccounttoHeadPost`,`PurcAdjustInPartyAmount`,`PurcAccounttoHeadPostParty`,`PurcPostOverandAbove`," +
                    "`typeMaterialIssue`,`typeMaterialReceipt`,`StockTransfer`," +
                   " `AffectAccounting`,`OtherSide`,`Accountheadtopost`,`AdjustinMC`,`AccountheadtopostParty`,`postoverandabove`,`typeAbsoluteAmount`,`typePercentage`,`typePerMainQty`,`PerAltQty`,`Percentoff`,`typeNetBillAmount`," +
                   "`SelectiveCalculation`,`tyeItemsBasicAmt`,`IncludeFreeQty`,`typeTotalMRPofItems`,`typeTaxableAmount`,`typePreviousBillSundryAmount`," +
                    "`typeOtherBillsundry`," +
                    "`BSAmt`,`BSAppOn`,`NoOfBillSundry`,`ConsolidateBillSundriesAmount`,`roundoffBillsundry`,`CreatedBy`) " +
                    "VALUES(@Name,@Alias,@PrintName,@BillSundryType,@BillSundryNature,@DefaultValue,@Subtotalheading,"+
                    "@AffectstheCostofGoodsinSale,@AffectstheCostofGoodsinPurchase,@AffectstheCostofGoodsinMaterialIssue,@AffectstheCostofGoodsinMaterialReceipt," +
                    "@AffectstheCostofGoodsinStockTransfer,@AffectsAccountingsale,@AdjustInSaleAmountsale,@AccounttoHeadPostsale,@AdjustInPartyAmountsale,@AccounttoHeadPostpartysale,@PostOverandAbovesale," +
                    "@AffectsAccountingpurc,@AdjustInSaleAmountpurc,@AccounttoHeadPostpurc,@AdjustInPartyAmountsale,@AdjustInPurchaseAmount,@AccounttoHeadPostpartypurc,"+
                    "@typeMaterialIssue,@typeMaterialReceipt,@StockTransfer," +
                    "@AffectAccounting,@OtherSide,@Accountheadtopostparty,@AdjustinMC,@Accountheadtopostparty,@Postoverandabove,@typeAbsoluteamount,@typePercentage,@typePerMainQty,@typePeraltQty,@Percentoff,@typeNetBillAmount," +
                    "@SelectiveCalculation,@tyeItemsBasicAmt,@IncludeFreeqty,@typeTotalMRPofItems,@typeTaxableAmount,@typePreviousBillSundryAmount,@typeOtherBillsundry," +
                    "@BSAmt,@BSAppOn,@NoOfBillSundrys,@ConsolidateBillSundriesAmount,@Roundoffbillsundary,@CreatedBy)";

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
                paramCollection.Add(new DBParameter("@Subtotalheading", objBSM.subtotalheading));

                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinSale", objBSM.AffectstheCostofGoodsinSale, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinPurchase", objBSM.AffectstheCostofGoodsinPurchase, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinMaterialIssue", objBSM.AffectstheCostofGoodsinMaterialIssue, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinMaterialReceipt", objBSM.AffectstheCostofGoodsinMaterialReceipt, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinStockTransfer", objBSM.AffectstheCostofGoodsinStockTransfer, System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@AffectsAccountingsale", objBSM.SaleAffectsAccounting, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AdjustInSaleAmountsale", objBSM.SaleAdjustInSaleAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AccounttoHeadPostsale", objBSM.SaleAccounttoHeadPost));
                paramCollection.Add(new DBParameter("@AdjustInPartyAmountsale", objBSM.SaleAdjustInPartyAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AccounttoHeadPostpartysale", objBSM.SaleAccounttoHeadPostParty));
                paramCollection.Add(new DBParameter("@PostOverandAbovesale", objBSM.SalePostOverandAbove));

                paramCollection.Add(new DBParameter("@AffectsAccountingpurc", objBSM.PurcAffectsAccounting, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AdjustInSaleAmountpurc", objBSM.PurcAdjustInPurcAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AccounttoHeadPostpurc", objBSM.PurcAccounttoHeadPost));
                paramCollection.Add(new DBParameter("@AdjustInPartyAmountpurc", objBSM.PurcAdjustInPartyAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AccounttoHeadPostpartypurc", objBSM.PurcAccounttoHeadPostParty));
                paramCollection.Add(new DBParameter("@PostOverandAbovepurc", objBSM.PurcPostOverandAbove));

                paramCollection.Add(new DBParameter("@typeMaterialIssue", objBSM.typeMaterialIssue, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeMaterialReceipt", objBSM.typeMaterialReceipt, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@StockTransfer", objBSM.StockTransfer, System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@AffectAccounting", objBSM.AffectAccounting, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@OtherSide", objBSM.OtherSide));
                paramCollection.Add(new DBParameter("@Accountheadtopost", objBSM.Accountheadtopost));
                paramCollection.Add(new DBParameter("@AdjustinMC", objBSM.AdjustinMC));
                paramCollection.Add(new DBParameter("@Accountheadtopostparty", objBSM.AccountheadtopostParty));
                paramCollection.Add(new DBParameter("@Postoverandabove", objBSM.postoverandabove, System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@typeAbsoluteamount", objBSM.typeAbsoluteAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typePercentage", objBSM.typePercentage, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typePerMainQty", objBSM.typePerMainQty, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typePeraltQty", objBSM.PerAltQty, System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@Percentoff", objBSM.Percentoff));
                paramCollection.Add(new DBParameter("@typeNetBillAmount", objBSM.typeNetBillAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@SelectiveCalculation", objBSM.SelectiveCalculation, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@tyeItemsBasicAmt", objBSM.tyeItemsBasicAmt, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@IncludeFreeqty", objBSM.IncludeFreeQty, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeTotalMRPofItems", objBSM.typeTotalMRPofItems, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeTaxableAmount", objBSM.typeTaxableAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typePreviousBillSundryAmount", objBSM.typePreviousBillSundryAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeOtherBillsundry", objBSM.typeOtherBillsundry, System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@BSAmt", objBSM.BSAmt, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@BSAppOn ", objBSM.BSAppOn, System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@NoOfBillSundrys", objBSM.NoOfBillSundry));
                paramCollection.Add(new DBParameter("@ConsolidateBillSundriesAmount", objBSM.ConsolidateBillSundriesAmount, System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@Roundoffbillsundary", objBSM.roundoffBillsundry, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@BS_Id", objBSM.BS_Id));


                Query = "UPDATE billsundarymaster SET `Name`=@Name,`Alias`=@Alias,`PrintName`=@PrintName,`BillSundryType`=@BillSundryType,`BillSundryNature`=@BillSundryNature,`DefaultValue`=@DefaultValue,`subtotalheading`=@Subtotalheading," +
                   "`AffectstheCostofGoodsinSale`=@AffectstheCostofGoodsinSale,`AffectstheCostofGoodsinPurchase`=@AffectstheCostofGoodsinPurchase,`AffectstheCostofGoodsinMaterialIssue`=@AffectstheCostofGoodsinMaterialIssue,`AffectstheCostofGoodsinMaterialReceipt`=@AffectstheCostofGoodsinMaterialReceipt," +
                   "`AffectstheCostofGoodsinStockTransfer`=@AffectstheCostofGoodsinStockTransfer,"+
                   "`SaleAffectsAccounting`=@AffectsAccountingsale,`SaleAdjustInSaleAmount`=@AdjustInSaleAmountsale,`SaleAccounttoHeadPost`=@AccounttoHeadPostsale,`SaleAdjustInPartyAmount`=@AdjustInPartyAmountsale,`SaleAccounttoHeadPostParty`=@AccounttoHeadPostpartysale,`SalePostOverandAbove`=@PostOverandAbovesale," +
                   "`PurcAffectsAccounting`=@AffectsAccountingpurc,`PurcAdjustInPurcAmount`=@AdjustInSaleAmountpurc,`PurcAccounttoHeadPost`=@AccounttoHeadPostpurc,`PurcAdjustInPartyAmount`=@AdjustInPartyAmountpurc,`PurcAccounttoHeadPostParty`=@AccounttoHeadPostpartypurc,`PurcPostOverandAbove`=@PostOverandAbovepurc," +
                   "`typeMaterialIssue`=@typeMaterialIssue,`typeMaterialReceipt`=@typeMaterialReceipt,`StockTransfer`=@StockTransfer," +
                   "`AffectAccounting`=@AffectAccounting,`OtherSide`=@OtherSide,`Accountheadtopost`=@Accountheadtopost,`AdjustinMC`=@AdjustinMC,`AccountheadtopostParty`=@Accountheadtopostparty,`postoverandabove`=@Postoverandabove," +
                   "`typeAbsoluteAmount`=@typeAbsoluteamount,`typePercentage`=@typePercentage,`typePerMainQty`=@typePerMainQty,`PerAltQty`=@typePeraltQty,`Percentoff`=@Percentoff,`typeNetBillAmount`=@typeNetBillAmount," +
                   "`SelectiveCalculation`=@SelectiveCalculation,`tyeItemsBasicAmt`=@tyeItemsBasicAmt,`IncludeFreeQty`=@IncludeFreeqty,`typeTotalMRPofItems`=@typeTotalMRPofItems,`typeTaxableAmount`=@typeTaxableAmount,`typePreviousBillSundryAmount`=@typePreviousBillSundryAmount,`typeOtherBillsundry`=@typeOtherBillsundry," +
                   "`roundoffBillsundry`=@Roundoffbillsundary,`BSAmt`=@BSAmt,`BSAppOn`=@BSAppOn,`NoOfBillSundry`=@NoOfBillSundrys,`ConsolidateBillSundriesAmount`=@ConsolidateBillSundriesAmount " +
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

        //Delet BillSundry By Id
        public bool DeleteBillSundryById(int id)
        {
            bool isDelete = false;
            try
            {
                string Query = "DELETE FROM billsundarymaster WHERE BS_Id=" + id;
                int rowes = _dbHelper.ExecuteNonQuery(Query);
                if (rowes > 0)
                    isDelete = true;
            }
            catch (Exception ex)
            {
                isDelete = false;
                throw ex;
            }
            return isDelete;
        }

        //List
        public List<BillSundryMasterModel> GetAllBillSundry()
        {
            List<eSunSpeedDomain.BillSundryMasterModel> lstBsm = new List<BillSundryMasterModel>();
            eSunSpeedDomain.BillSundryMasterModel objBsm;
           

            string Query = "SELECT * FROM billsundarymaster";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {

                objBsm = new BillSundryMasterModel();
                objBsm.BS_Id = Convert.ToInt32(dr["BS_Id"]);
                objBsm.Name = dr["Name"].ToString();
                objBsm.Alias = dr["Alias"].ToString();

                lstBsm.Add(objBsm);

            }

            return lstBsm;
        }

        //Get All Bill Sundary By Id
        public BillSundryMasterModel GetAllBillSundryById(int id)
        {
            BillSundryMasterModel objBsm = new BillSundryMasterModel();

            string Query = "SELECT * FROM billsundarymaster WHERE BS_Id=" +id;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objBsm.Name = dr["Name"].ToString();
                objBsm.Alias = dr["Alias"].ToString();
                objBsm.PrintName = dr["PrintName"].ToString();
                objBsm.BillSundryType = dr["BillSundryType"].ToString();
                objBsm.BillSundryNature = dr["BillSundryNature"].ToString();
                objBsm.DefaultValue = Convert.ToDecimal(dr["DefaultValue"]);
                objBsm.subtotalheading = dr["subtotalheading"].ToString();

                objBsm.AffectstheCostofGoodsinSale= Convert.ToBoolean(dr["AffectstheCostofGoodsinSale"]);
                objBsm.AffectstheCostofGoodsinPurchase = Convert.ToBoolean(dr["AffectstheCostofGoodsinPurchase"]);
                objBsm.AffectstheCostofGoodsinMaterialIssue = Convert.ToBoolean(dr["AffectstheCostofGoodsinMaterialIssue"]);
                objBsm.AffectstheCostofGoodsinMaterialReceipt = Convert.ToBoolean(dr["AffectstheCostofGoodsinMaterialReceipt"]);
                objBsm.AffectstheCostofGoodsinStockTransfer = Convert.ToBoolean(dr["AffectstheCostofGoodsinStockTransfer"]);
                
                //Accountin In Sale
                objBsm.SaleAffectsAccounting = Convert.ToBoolean(dr["SaleAffectsAccounting"]);
                objBsm.SaleAdjustInSaleAmount = Convert.ToBoolean(dr["SaleAdjustInSaleAmount"]);
                objBsm.SaleAccounttoHeadPost = dr["SaleAccounttoHeadPost"].ToString();
                objBsm.SaleAdjustInPartyAmount = Convert.ToBoolean(dr["SaleAdjustInPartyAmount"]);
                objBsm.SaleAccounttoHeadPostParty = dr["SaleAccounttoHeadPostParty"].ToString();
                objBsm.SalePostOverandAbove = dr["SalePostOverandAbove"].ToString();

                // Accountin In Purc
                objBsm.PurcAffectsAccounting = Convert.ToBoolean(dr["PurcAffectsAccounting"]);
                objBsm.PurcAdjustInPurcAmount = Convert.ToBoolean(dr["PurcAdjustInPurcAmount"]);
                objBsm.PurcAccounttoHeadPost = dr["PurcAccounttoHeadPost"].ToString();
                objBsm.PurcAdjustInPartyAmount = Convert.ToBoolean(dr["PurcAdjustInPartyAmount"]);
                objBsm.PurcAccounttoHeadPostParty = dr["PurcAccounttoHeadPostParty"].ToString();
                objBsm.PurcPostOverandAbove = dr["PurcPostOverandAbove"].ToString();

                objBsm.typeMaterialIssue =Convert.ToBoolean(dr["typeMaterialIssue"]);
                objBsm.typeMaterialReceipt = Convert.ToBoolean(dr["typeMaterialReceipt"]);
                objBsm.StockTransfer = Convert.ToBoolean(dr["StockTransfer"]);
                
                objBsm.AffectAccounting =Convert.ToBoolean(dr["AffectAccounting"]);
                objBsm.OtherSide = dr["OtherSide"].ToString();
                objBsm.Accountheadtopost = dr["Accountheadtopost"].ToString();
                objBsm.AdjustinMC = dr["AdjustinMC"].ToString();
                objBsm.AccountheadtopostParty = dr["AccountheadtopostParty"].ToString();
                objBsm.postoverandabove =Convert.ToBoolean(dr["postoverandabove"].ToString());

                objBsm.typeAbsoluteAmount =Convert.ToBoolean(dr["typeAbsoluteAmount"]);
                objBsm.typePercentage = Convert.ToBoolean(dr["typePercentage"]);
                objBsm.typePerMainQty = Convert.ToBoolean(dr["typePerMainQty"]);
                objBsm.PerAltQty = Convert.ToBoolean(dr["PerAltQty"]);
                objBsm.Percentoff =Convert.ToDecimal(dr["Percentoff"]);
                objBsm.typeNetBillAmount = Convert.ToBoolean(dr["typeNetBillAmount"]);
                objBsm.SelectiveCalculation = Convert.ToBoolean(dr["SelectiveCalculation"]);
                objBsm.tyeItemsBasicAmt = Convert.ToBoolean(dr["tyeItemsBasicAmt"]);
                objBsm.IncludeFreeQty =Convert.ToBoolean(dr["IncludeFreeQty"]);
                objBsm.typeTotalMRPofItems = Convert.ToBoolean(dr["typeTotalMRPofItems"]);
                objBsm.typeOtherBillsundry =Convert.ToBoolean(dr["typeOtherBillsundry"]);
                objBsm.typePreviousBillSundryAmount = Convert.ToBoolean(dr["typePreviousBillSundryAmount"]);
                objBsm.BSAmt =Convert.ToBoolean(dr["BSAmt"]);
                //objBsm.BSAppOn =Convert.ToBoolean(dr["BSAppOn"]);
                objBsm.NoOfBillSundry =Convert.ToInt32(dr["NoOfBillSundry"]);
                objBsm.ConsolidateBillSundriesAmount = Convert.ToBoolean(dr["ConsolidateBillSundriesAmount"]);
                objBsm.roundoffBillsundry =Convert.ToBoolean(dr["roundoffBillsundry"]);
            }

            return objBsm;
        }
    }
}
