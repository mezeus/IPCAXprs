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
        AccountMasterBL objAccBL = new AccountMasterBL();
        private DBHelper _dbHelper = new DBHelper();
        //Save Bill Sundry
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
                paramCollection.Add(new DBParameter("@DefaultValue", objBSM.DefaultValue,System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@Subtotalheading", objBSM.subtotalheading));
                
                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinSale", objBSM. AffectstheCostofGoodsinSale, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinPurchase", objBSM.AffectstheCostofGoodsinPurchase, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinMaterialIssue", objBSM.AffectstheCostofGoodsinMaterialIssue, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinMaterialReceipt", objBSM.AffectstheCostofGoodsinMaterialReceipt, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinStockTransfer", objBSM.AffectstheCostofGoodsinStockTransfer, System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@SaleAffectsAccounting", objBSM.SaleAffectsAccounting, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@SaleAdjustInSaleAmount", objBSM.SaleAdjustInSaleAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@SaleSpecifyAccountHere", objBSM.SaleSpecifyAccountHere));
                paramCollection.Add(new DBParameter("@SaleAccounttoHeadPost", objBSM.SaleAccounttoHeadPost));
                paramCollection.Add(new DBParameter("@SaleAdjustInPartyAmount", objBSM.SaleAdjustInPartyAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@SalePartSpecifyAccountHere", objBSM.SalePartSpecifyAccountHere));
                paramCollection.Add(new DBParameter("@SaleAccounttoHeadPostParty", objBSM.SaleAccounttoHeadPostParty));
                paramCollection.Add(new DBParameter("@SalePostOverandAbove", objBSM.SalePostOverandAbove, System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@PurcAffectsAccounting", objBSM.PurcAffectsAccounting, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@PurcAdjustInPurcAmount", objBSM.PurcAdjustInPurcAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@PurcSpecifyAccountHere", objBSM.PurcSpecifyAccountHere));
                paramCollection.Add(new DBParameter("@PurcAccounttoHeadPost", objBSM.PurcAccounttoHeadPost));
                paramCollection.Add(new DBParameter("@PurcParySpecifyAccountHere", objBSM.PurcParySpecifyAccountHere));
                paramCollection.Add(new DBParameter("@PurcAdjustInPartyAmount", objBSM.PurcAdjustInPartyAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@PurcAccounttoHeadPostParty", objBSM.PurcAccounttoHeadPostParty));
                paramCollection.Add(new DBParameter("@PurcPostOverandAbove", objBSM.PurcPostOverandAbove,System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@typeMaterialIssue", objBSM.typeMaterialIssue,System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeMaterialReceipt", objBSM.typeMaterialReceipt, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@StockTransfer", objBSM.StockTransfer, System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@AffectAccounting", objBSM.AffectAccounting, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@OtherSide", objBSM.OtherSide));
                paramCollection.Add(new DBParameter("@Accountheadtopost", objBSM.Accountheadtopost));
                paramCollection.Add(new DBParameter("@AdjustinMC", objBSM.AdjustinMC,System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@Accountheadtopostparty", objBSM.AccountheadtopostParty));
                paramCollection.Add(new DBParameter("@Postoverandabove", objBSM.postoverandabove, System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@typeAbsoluteamount", objBSM.typeAbsoluteAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typePercentage", objBSM.typePercentage, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typePerMainQty", objBSM.typePerMainQty,System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@PerAltQty", objBSM.PerAltQty,System.Data.DbType.Boolean));

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
               
                paramCollection.Add(new DBParameter("@NoOfBillSundry", objBSM.NoOfBillSundry));
                paramCollection.Add(new DBParameter("@ConsolidateBillSundriesAmount", objBSM.ConsolidateBillSundriesAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@BillSundaryName", objBSM.BillSundaryName));
                paramCollection.Add(new DBParameter("@AdjustSpecifyAccountLedger", objBSM.AdjustSpecifyAccountLedger));
                paramCollection.Add(new DBParameter("@roundoffBillsundry", objBSM.roundoffBillsundry, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@RoundoffValues", objBSM.RoundoffValues));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                paramCollection.Add(new DBParameter("@Createddate", DateTime.Now,System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));


                System.Data.IDataReader dr =
                        _dbHelper.ExecuteDataReader("spInsertBillsundaryMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                isSaved = false;
                throw ex;
            }

            return isSaved;
        }

        //UPDATE Bill Sundary
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
                paramCollection.Add(new DBParameter("@DefaultValue", objBSM.DefaultValue, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@Subtotalheading", objBSM.subtotalheading));

                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinSale", objBSM.AffectstheCostofGoodsinSale, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinPurchase", objBSM.AffectstheCostofGoodsinPurchase, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinMaterialIssue", objBSM.AffectstheCostofGoodsinMaterialIssue, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinMaterialReceipt", objBSM.AffectstheCostofGoodsinMaterialReceipt, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AffectstheCostofGoodsinStockTransfer", objBSM.AffectstheCostofGoodsinStockTransfer, System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@SaleAffectsAccounting", objBSM.SaleAffectsAccounting, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@SaleAdjustInSaleAmount", objBSM.SaleAdjustInSaleAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@SaleSpecifyAccountHere", objBSM.SaleSpecifyAccountHere));
                paramCollection.Add(new DBParameter("@SaleAccounttoHeadPost", objBSM.SaleAccounttoHeadPost));
                paramCollection.Add(new DBParameter("@SaleAdjustInPartyAmount", objBSM.SaleAdjustInPartyAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@SalePartSpecifyAccountHere", objBSM.SalePartSpecifyAccountHere));
                paramCollection.Add(new DBParameter("@SaleAccounttoHeadPostParty", objBSM.SaleAccounttoHeadPostParty));
                paramCollection.Add(new DBParameter("@SalePostOverandAbove", objBSM.SalePostOverandAbove, System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@PurcAffectsAccounting", objBSM.PurcAffectsAccounting, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@PurcAdjustInPurcAmount", objBSM.PurcAdjustInPurcAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@PurcSpecifyAccountHere", objBSM.PurcSpecifyAccountHere));
                paramCollection.Add(new DBParameter("@PurcAccounttoHeadPost", objBSM.PurcAccounttoHeadPost));
                paramCollection.Add(new DBParameter("@PurcParySpecifyAccountHere", objBSM.PurcParySpecifyAccountHere));
                paramCollection.Add(new DBParameter("@PurcAdjustInPartyAmount", objBSM.PurcAdjustInPartyAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@PurcAccounttoHeadPostParty", objBSM.PurcAccounttoHeadPostParty));
                paramCollection.Add(new DBParameter("@PurcPostOverandAbove", objBSM.PurcPostOverandAbove, System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@typeMaterialIssue", objBSM.typeMaterialIssue, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typeMaterialReceipt", objBSM.typeMaterialReceipt, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@StockTransfer", objBSM.StockTransfer, System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@AffectAccounting", objBSM.AffectAccounting, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@OtherSide", objBSM.OtherSide));
                paramCollection.Add(new DBParameter("@Accountheadtopost", objBSM.Accountheadtopost));
                paramCollection.Add(new DBParameter("@AdjustinMC", objBSM.AdjustinMC, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@Accountheadtopostparty", objBSM.AccountheadtopostParty));
                paramCollection.Add(new DBParameter("@Postoverandabove", objBSM.postoverandabove, System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@typeAbsoluteamount", objBSM.typeAbsoluteAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typePercentage", objBSM.typePercentage, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@typePerMainQty", objBSM.typePerMainQty, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@PerAltQty", objBSM.PerAltQty, System.Data.DbType.Boolean));

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

                paramCollection.Add(new DBParameter("@NoOfBillSundry", objBSM.NoOfBillSundry));
                paramCollection.Add(new DBParameter("@ConsolidateBillSundriesAmount", objBSM.ConsolidateBillSundriesAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@BillSundaryName", objBSM.BillSundaryName));
                paramCollection.Add(new DBParameter("@AdjustSpecifyAccountLedger", objBSM.AdjustSpecifyAccountLedger));
                paramCollection.Add(new DBParameter("@roundoffBillsundry", objBSM.roundoffBillsundry, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@RoundoffValues", objBSM.RoundoffValues));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                paramCollection.Add(new DBParameter("@Createddate", DateTime.Now, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@BillSundryId", objBSM.BS_Id));


                System.Data.IDataReader dr =
                        _dbHelper.ExecuteDataReader("spUpdateBillsundaryMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
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

        //Delete BillSundry By Id
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
            BillSundryMasterModel objbsmod = new BillSundryMasterModel();

            string Query = "SELECT * FROM billsundarymaster WHERE BS_Id=" +id;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objbsmod.Name = dr["Name"].ToString();
                objbsmod.Alias = dr["Alias"].ToString();
                objbsmod.PrintName = dr["PrintName"].ToString();
                objbsmod.BillSundryType = dr["BillSundryType"].ToString();
                objbsmod.BillSundryNature = dr["BillSundryNature"].ToString();
                objbsmod.DefaultValue = Convert.ToDecimal(dr["DefaultValue"]);
                objbsmod.subtotalheading = dr["subtotalheading"].ToString();

                objbsmod.AffectstheCostofGoodsinSale= Convert.ToBoolean(dr["AffectstheCostofGoodsinSale"]);
                objbsmod.AffectstheCostofGoodsinPurchase = Convert.ToBoolean(dr["AffectstheCostofGoodsinPurchase"]);
                objbsmod.AffectstheCostofGoodsinMaterialIssue = Convert.ToBoolean(dr["AffectstheCostofGoodsinMaterialIssue"]);
                objbsmod.AffectstheCostofGoodsinMaterialReceipt = Convert.ToBoolean(dr["AffectstheCostofGoodsinMaterialReceipt"]);
                objbsmod.AffectstheCostofGoodsinStockTransfer = Convert.ToBoolean(dr["AffectstheCostofGoodsinStockTransfer"]);

                //Accountin In Sale
                objbsmod.SaleAffectsAccounting = Convert.ToBoolean(dr["SaleAffectsAccounting"]);
                objbsmod.SaleAdjustInSaleAmount = Convert.ToBoolean(dr["SaleAdjustInSaleAmount"]);
                objbsmod.SaleSpecifyAccountHere = dr["SaleSpecifyAccountHere"].ToString();
                objbsmod.SaleAccounttoHeadPost = dr["SaleAccounttoHeadPost"].ToString();
                objbsmod.SaleAdjustInPartyAmount = Convert.ToBoolean(dr["SaleAdjustInPartyAmount"]);
                objbsmod.SalePartSpecifyAccountHere= dr["SalePartSpecifyAccountHere"].ToString();
                objbsmod.SaleAccounttoHeadPostParty = dr["SaleAccounttoHeadPostParty"].ToString();
                objbsmod.SalePostOverandAbove =Convert.ToBoolean(dr["SalePostOverandAbove"].ToString());

                // Accountin In Purc
                objbsmod.PurcAffectsAccounting = Convert.ToBoolean(dr["PurcAffectsAccounting"]);
                objbsmod.PurcAdjustInPurcAmount = Convert.ToBoolean(dr["PurcAdjustInPurcAmount"]);
                objbsmod.PurcSpecifyAccountHere = dr["PurcSpecifyAccountHere"].ToString();
                objbsmod.PurcAccounttoHeadPost = dr["PurcAccounttoHeadPost"].ToString();
                objbsmod.PurcAdjustInPartyAmount = Convert.ToBoolean(dr["PurcAdjustInPartyAmount"]);
                objbsmod.PurcParySpecifyAccountHere= dr["PurcParySpecifyAccountHere"].ToString();
                objbsmod.PurcAccounttoHeadPostParty = dr["PurcAccounttoHeadPostParty"].ToString();
                objbsmod.PurcPostOverandAbove =Convert.ToBoolean(dr["PurcPostOverandAbove"].ToString());

                objbsmod.typeMaterialIssue =Convert.ToBoolean(dr["typeMaterialIssue"]);
                objbsmod.typeMaterialReceipt = Convert.ToBoolean(dr["typeMaterialReceipt"]);
                objbsmod.StockTransfer = Convert.ToBoolean(dr["StockTransfer"]);

                objbsmod.AffectAccounting =Convert.ToBoolean(dr["AffectAccounting"]);
                objbsmod.OtherSide = dr["OtherSide"].ToString();
                objbsmod.Accountheadtopost = dr["Accountheadtopost"].ToString();
                objbsmod.AdjustinMC =Convert.ToBoolean(dr["AdjustinMC"].ToString());
                objbsmod.AdjustSpecifyAccountLedger = dr["AdjustSpecifyAccountLedger"].ToString();
                objbsmod.AccountheadtopostParty = dr["AccountheadtopostParty"].ToString();
                objbsmod.postoverandabove =Convert.ToBoolean(dr["postoverandabove"].ToString());

                objbsmod.typeAbsoluteAmount =Convert.ToBoolean(dr["typeAbsoluteAmount"]);
                objbsmod.typePercentage = Convert.ToBoolean(dr["typePercentage"]);
                objbsmod.typePerMainQty = Convert.ToBoolean(dr["typePerMainQty"]);
                objbsmod.PerAltQty = Convert.ToBoolean(dr["PerAltQty"]);
                objbsmod.Percentoff =Convert.ToDecimal(dr["Percentoff"]);
                objbsmod.typeNetBillAmount = Convert.ToBoolean(dr["typeNetBillAmount"]);
                objbsmod.SelectiveCalculation = Convert.ToBoolean(dr["SelectiveCalculation"]);
                objbsmod.typeTaxableAmount = Convert.ToBoolean(dr["typeTaxableAmount"]);
                objbsmod.tyeItemsBasicAmt = Convert.ToBoolean(dr["tyeItemsBasicAmt"]);
                objbsmod.IncludeFreeQty =Convert.ToBoolean(dr["IncludeFreeQty"]);
                objbsmod.typeTotalMRPofItems = Convert.ToBoolean(dr["typeTotalMRPofItems"]);
                objbsmod.typeOtherBillsundry =Convert.ToBoolean(dr["typeOtherBillsundry"]);
                objbsmod.typePreviousBillSundryAmount = Convert.ToBoolean(dr["typePreviousBillSundryAmount"]);
                objbsmod.BSAmt =Convert.ToBoolean(dr["BSAmt"]);
                objbsmod.BSAppOn =Convert.ToBoolean(dr["BSAppOn"]);
                objbsmod.BillSundaryName = dr["BillSundaryName"].ToString();
                objbsmod.NoOfBillSundry =Convert.ToInt32(dr["NoOfBillSundry"]);
                objbsmod.ConsolidateBillSundriesAmount = Convert.ToBoolean(dr["ConsolidateBillSundriesAmount"]);
                objbsmod.roundoffBillsundry =Convert.ToBoolean(dr["roundoffBillsundry"]);
                objbsmod.RoundoffValues = dr["RoundoffValues"].ToString();
            }

            return objbsmod;
        }
        //Get Bill Sundary Id By Bill Sundary Name
        public long GetBSIdByBSName(string BSname)
        {
            long id = 0;
            try
            {
                string Query = "SELECT BS_Id FROM `billsundarymaster` WHERE `Name`='" + BSname + "'";
                System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());
                while (dr.Read())
                {
                    id = Convert.ToInt64(dr["BS_Id"]);
                }
            }
            catch (Exception ex)
            {
                id = 0;
                //throw ex;
            }
            return id;
        }
        //Get LedgerId By BillSundary
        public long GetBSLedgerId(string BSName)
        {
            long id = 0;
            string AccName;
            try
            {
                string Query = "SELECT * FROM `billsundarymaster` WHERE `Name`='" + BSName + "'";
                System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());
                while (dr.Read())
                {
                    AccName = dr["SaleAccounttoHeadPost"].ToString();
                    id = objAccBL.GetLedgerIdByAccountName(AccName);
                }
            }
            catch (Exception ex)
            {

            }
            return id;
        }
        //Get BillSundry Details By Name
        public BillSundryMasterModel GetAllBillSundryByName(string Name)
        {
            BillSundryMasterModel objbsmod = new BillSundryMasterModel();

            string Query = "SELECT * FROM `billsundarymaster` WHERE `Name`=" + Name;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objbsmod.Name = dr["Name"].ToString();
                objbsmod.Alias = dr["Alias"].ToString();
                objbsmod.PrintName = dr["PrintName"].ToString();
                objbsmod.BillSundryType = dr["BillSundryType"].ToString();
                objbsmod.BillSundryNature = dr["BillSundryNature"].ToString();
                objbsmod.DefaultValue = Convert.ToDecimal(dr["DefaultValue"]);
                objbsmod.subtotalheading = dr["subtotalheading"].ToString();

                objbsmod.AffectstheCostofGoodsinSale = Convert.ToBoolean(dr["AffectstheCostofGoodsinSale"]);
                objbsmod.AffectstheCostofGoodsinPurchase = Convert.ToBoolean(dr["AffectstheCostofGoodsinPurchase"]);
                objbsmod.AffectstheCostofGoodsinMaterialIssue = Convert.ToBoolean(dr["AffectstheCostofGoodsinMaterialIssue"]);
                objbsmod.AffectstheCostofGoodsinMaterialReceipt = Convert.ToBoolean(dr["AffectstheCostofGoodsinMaterialReceipt"]);
                objbsmod.AffectstheCostofGoodsinStockTransfer = Convert.ToBoolean(dr["AffectstheCostofGoodsinStockTransfer"]);

                //Accountin In Sale
                objbsmod.SaleAffectsAccounting = Convert.ToBoolean(dr["SaleAffectsAccounting"]);
                objbsmod.SaleAdjustInSaleAmount = Convert.ToBoolean(dr["SaleAdjustInSaleAmount"]);
                objbsmod.SaleSpecifyAccountHere = dr["SaleSpecifyAccountHere"].ToString();
                objbsmod.SaleAccounttoHeadPost = dr["SaleAccounttoHeadPost"].ToString();
                objbsmod.SaleAdjustInPartyAmount = Convert.ToBoolean(dr["SaleAdjustInPartyAmount"]);
                objbsmod.SalePartSpecifyAccountHere = dr["SalePartSpecifyAccountHere"].ToString();
                objbsmod.SaleAccounttoHeadPostParty = dr["SaleAccounttoHeadPostParty"].ToString();
                objbsmod.SalePostOverandAbove = Convert.ToBoolean(dr["SalePostOverandAbove"].ToString());

                // Accountin In Purc
                objbsmod.PurcAffectsAccounting = Convert.ToBoolean(dr["PurcAffectsAccounting"]);
                objbsmod.PurcAdjustInPurcAmount = Convert.ToBoolean(dr["PurcAdjustInPurcAmount"]);
                objbsmod.PurcSpecifyAccountHere = dr["PurcSpecifyAccountHere"].ToString();
                objbsmod.PurcAccounttoHeadPost = dr["PurcAccounttoHeadPost"].ToString();
                objbsmod.PurcAdjustInPartyAmount = Convert.ToBoolean(dr["PurcAdjustInPartyAmount"]);
                objbsmod.PurcParySpecifyAccountHere = dr["PurcParySpecifyAccountHere"].ToString();
                objbsmod.PurcAccounttoHeadPostParty = dr["PurcAccounttoHeadPostParty"].ToString();
                objbsmod.PurcPostOverandAbove = Convert.ToBoolean(dr["PurcPostOverandAbove"].ToString());

                objbsmod.typeMaterialIssue = Convert.ToBoolean(dr["typeMaterialIssue"]);
                objbsmod.typeMaterialReceipt = Convert.ToBoolean(dr["typeMaterialReceipt"]);
                objbsmod.StockTransfer = Convert.ToBoolean(dr["StockTransfer"]);

                objbsmod.AffectAccounting = Convert.ToBoolean(dr["AffectAccounting"]);
                objbsmod.OtherSide = dr["OtherSide"].ToString();
                objbsmod.Accountheadtopost = dr["Accountheadtopost"].ToString();
                objbsmod.AdjustinMC = Convert.ToBoolean(dr["AdjustinMC"].ToString());
                objbsmod.AdjustSpecifyAccountLedger = dr["AdjustSpecifyAccountLedger"].ToString();
                objbsmod.AccountheadtopostParty = dr["AccountheadtopostParty"].ToString();
                objbsmod.postoverandabove = Convert.ToBoolean(dr["postoverandabove"].ToString());

                objbsmod.typeAbsoluteAmount = Convert.ToBoolean(dr["typeAbsoluteAmount"]);
                objbsmod.typePercentage = Convert.ToBoolean(dr["typePercentage"]);
                objbsmod.typePerMainQty = Convert.ToBoolean(dr["typePerMainQty"]);
                objbsmod.PerAltQty = Convert.ToBoolean(dr["PerAltQty"]);
                objbsmod.Percentoff = Convert.ToDecimal(dr["Percentoff"]);
                objbsmod.typeNetBillAmount = Convert.ToBoolean(dr["typeNetBillAmount"]);
                objbsmod.SelectiveCalculation = Convert.ToBoolean(dr["SelectiveCalculation"]);
                objbsmod.typeTaxableAmount = Convert.ToBoolean(dr["typeTaxableAmount"]);
                objbsmod.tyeItemsBasicAmt = Convert.ToBoolean(dr["tyeItemsBasicAmt"]);
                objbsmod.IncludeFreeQty = Convert.ToBoolean(dr["IncludeFreeQty"]);
                objbsmod.typeTotalMRPofItems = Convert.ToBoolean(dr["typeTotalMRPofItems"]);
                objbsmod.typeOtherBillsundry = Convert.ToBoolean(dr["typeOtherBillsundry"]);
                objbsmod.typePreviousBillSundryAmount = Convert.ToBoolean(dr["typePreviousBillSundryAmount"]);
                objbsmod.BSAmt = Convert.ToBoolean(dr["BSAmt"]);
                objbsmod.BSAppOn = Convert.ToBoolean(dr["BSAppOn"]);
                objbsmod.BillSundaryName = dr["BillSundaryName"].ToString();
                objbsmod.NoOfBillSundry = Convert.ToInt32(dr["NoOfBillSundry"]);
                objbsmod.ConsolidateBillSundriesAmount = Convert.ToBoolean(dr["ConsolidateBillSundriesAmount"]);
                objbsmod.roundoffBillsundry = Convert.ToBoolean(dr["roundoffBillsundry"]);
                objbsmod.RoundoffValues = dr["RoundoffValues"].ToString();
            }

            return objbsmod;
        }
    }
}
