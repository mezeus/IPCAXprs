using eSunSpeed.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;

namespace eSunSpeed.BusinessLogic
{
  public class ItemMasterBL
    {
      private DBHelper _dbHelper = new DBHelper();
        //Save Item Master
      public bool SaveItemMaster(ItemMasterModel objItem)
      {
            bool isSaved = true;
            string Query = string.Empty;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ITEM_Name", objItem.Name));
                paramCollection.Add(new DBParameter("@ITEM_PrintName", objItem.PrintName));
                paramCollection.Add(new DBParameter("@ITEM_ALIAS", objItem.Alias));
                paramCollection.Add(new DBParameter("@ITEM_GROUP", objItem.Group));
                paramCollection.Add(new DBParameter("@ITEM_COMPANY", objItem.Company));

                paramCollection.Add(new DBParameter("@ITEM_MAINUNIT", objItem.MainUnit));
                paramCollection.Add(new DBParameter("@ALT_UNIT", objItem.AltUnit));
                paramCollection.Add(new DBParameter("@ITEM_CONAlt", objItem.ConAltUnit, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@ITEM_CONMain", objItem.ConMainUnit, System.Data.DbType.Decimal));

                paramCollection.Add(new DBParameter("@ITEM_OPSTOCKVALUE", objItem.OpStockValue));
                paramCollection.Add(new DBParameter("@ITEM_UNIT", objItem.Unit));
                paramCollection.Add(new DBParameter("@ITEM_RATE", objItem.Rate));
                paramCollection.Add(new DBParameter("@ITEM_PER", objItem.Per));
                paramCollection.Add(new DBParameter("@ITEM_VALUE", objItem.Value));

                paramCollection.Add(new DBParameter("@ITEM_APPLYSALEPRICE", objItem.ApplySalesPrice));
                paramCollection.Add(new DBParameter("@ITEM_APPLYPURCPRICE", objItem.ApplyPurchPrice));
                paramCollection.Add(new DBParameter("@ITEM_SALEPRICE", objItem.MainSalePrice, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@ITEM_ALTSALEPRICE", objItem.AltSalePrice, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@ITEM_PURCEPRICE", objItem.MainPurprice, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@ITEM_ALTPURCEPRICE", objItem.AltPurprice, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@ITEM_MRP", objItem.MainMRP, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@ITEM_ALTMRP", objItem.AltMRP, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@ITEM_MINSALEPRICE", objItem.MainMinSalePrice, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@ITEM_ALTMINSALEPRICE", objItem.AltMinSalePrice, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@ITEM_SELFVALUEPRICE", objItem.SelfValuePrice, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@ITEM_DISSCOUNTINFO", objItem.DiscountInfo, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ITEM_MARKUPINFO", objItem.MarkupInfo, System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@ITEM_SALEDISCOUNT", objItem.SaleDiscount, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@ITEM_PURCHASEDISCOUNT", objItem.PurDiscount, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@ITEM_SALEDISCOUNTCOMP", objItem.SaleCompoundDiscount, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@ITEM_PURCHASEDISCOUNTCOMP", objItem.PurDiscount, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@ITEM_SpecifySaleDiscStructure", objItem.SpecifySaleDiscStructure, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ITEM_SpecifyPurDiscStructure", objItem.SpecifyPurDiscStructure, System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@ITEM_SaleMarkup", objItem.SaleMarkup));
                paramCollection.Add(new DBParameter("@ITEM_PurMarkup", objItem.PurMarkup));
                paramCollection.Add(new DBParameter("@ITEM_SaleCompMarkup", objItem.SaleCompMarkup));
                paramCollection.Add(new DBParameter("@ITEM_PurCompMarkup", objItem.PurCompMarkup));
                paramCollection.Add(new DBParameter("@ITEM_SpecifySaleMarkupStruct", objItem.SpecifySaleMarkupStruct, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ITEM_SpecifyPurMarkupStruct", objItem.SpecifyPurMarkupStruct, System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@ITEM_StockValMethod", objItem.StockValMethod));

                paramCollection.Add(new DBParameter("@ITEM_TAXCATEGORY", objItem.TaxCategory));
                paramCollection.Add(new DBParameter("@ITEM_DESCRIPTION1", objItem.ItemDescription1));
                paramCollection.Add(new DBParameter("@ITEM_DESCRIPTION2", objItem.ItemDescription2));
                paramCollection.Add(new DBParameter("@ITEM_DESCRIPTION3", objItem.ItemDescription3));
                paramCollection.Add(new DBParameter("@ITEM_DESCRIPTION4", objItem.ItemDescription4));

                paramCollection.Add(new DBParameter("@ITEM_SETCRITICALLEVEL", objItem.SetCriticalLevel, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ITEM_MAINTAINRG23D", objItem.MaintainRG23D, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ITEM_TARIFHEADING", objItem.TariffHeading));
                paramCollection.Add(new DBParameter("@ITEM_SERIALWISEDETAILS", objItem.SerialNumberwiseDetails, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ITEM_PARAMETERIZEDDETAILS", objItem.ParameterizedDetails, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ITEM_MRPWISEDETAILS", objItem.MRPWiseDetails, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ITEM_BATCHWISEDETAILS", objItem.BatchwiseDetails, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ITEM_EXPDATEREQUIRED", objItem.ExpDateRequired, System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@ITEM_EXPIRYDAYS", objItem.ExpiryDays));
                paramCollection.Add(new DBParameter("@ITEM_SALESACCOUNT", objItem.SalesAccount));
                paramCollection.Add(new DBParameter("@ITEM_PURCACCOUNT", objItem.PurcAccount));
                paramCollection.Add(new DBParameter("@ITEM_MAINTAINSTOCKBAL", objItem.DontMaintainStockBal, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ITEM_SPECIFYDEFAULTMC", objItem.SpecifyDefaultMC, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ITEM_FREEZEMCFORITEM", objItem.FreezeMCforItem, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ITEM_TOTALNUMBEROFAUTHORS", objItem.TotalNumberofAuthors));

                paramCollection.Add(new DBParameter("@ITEM_PICKITEMSIZEFROMDESC", objItem.PickItemSizefromDescription, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ITEM_SPECIFYDEFAULTVENDOR", objItem.SpecifyDefaultVendor, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@CreatedBy", objItem.CreatedBy));

                System.Data.IDataReader dr =
                        _dbHelper.ExecuteDataReader("spInsertItemMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                int id = 0;
                dr.Read();
                id = Convert.ToInt32(dr[0]);
                SaveItemBarcodes(objItem.BarCodes,id);
                
                SaveSerialNumberWiseDeatils(objItem, id);
                SaveItemParameterizedDetails(objItem.ItemParameterized, id);
                SaveItemBatchWiseDetails(objItem.ItemBatchWise, id);
                SaveItemMRPWiseDetails(objItem.ItemMRPWise, id);
                SaveItemCriticalLevelDetails(objItem.ItemCriticalLevel, id);
            }
            catch(Exception ex)
            {
                isSaved = false;
                throw ex;
            }
            return isSaved;
        }

        //Save Item Barcodes
        public bool SaveItemBarcodes(List<string> lstItems,int id)
        {
            string Query = string.Empty;
            bool isSaved = true;
            foreach (string item in lstItems)
            {
               

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Item_Id",id));
                    paramCollection.Add(new DBParameter("@Item_Barcode", item));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertItemBarcodes", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);

                    //if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                    //    isSaved = true;
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }

        //Save Item Serieal Number Wise Details From PopupWindow.
        public bool SaveSerialNumberWiseDeatils(ItemMasterModel Serial, int id)
        {
            string Query = string.Empty;
            bool isSaved = true;

                Serial.parent_Id = id;
                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Item_Id",Serial.parent_Id));
                    paramCollection.Add(new DBParameter("@Item_ManulaNo",Serial.ManualNuber,System.Data.DbType.Boolean));
                    paramCollection.Add(new DBParameter("@Item_AutoNo", Serial.AutoNumber, System.Data.DbType.Boolean));
                    paramCollection.Add(new DBParameter("@Item_StartingAuto", Serial.StaringAutoNo));
                    paramCollection.Add(new DBParameter("@Item_NumberingFreq", Serial.NumberingFreq));
                    paramCollection.Add(new DBParameter("@Item_Structure", Serial.StructureName));
                    paramCollection.Add(new DBParameter("@Item_RegenerateAuto", Serial.RegenarateAutoNo, System.Data.DbType.Boolean));
                    paramCollection.Add(new DBParameter("@Item_PurchaseWarranty", Serial.TrackPurcWaranty, System.Data.DbType.Boolean));
                    paramCollection.Add(new DBParameter("@Item_SaleWarranty", Serial.TrackSaleWaranty, System.Data.DbType.Boolean));
                    paramCollection.Add(new DBParameter("@Item_InstallWaranty", Serial.TrackInstallationWaranty, System.Data.DbType.Boolean));

                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertItemSerialNoDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            return isSaved;
        }

        //Save Item Parmeterized Details From PopupWindow
        public bool SaveItemParameterizedDetails(List<ItemParameterizedModel> lstParameter, int id)
        {
            string Query = string.Empty;
            bool isSaved = true;
            foreach (ItemParameterizedModel Parameter in lstParameter)
            {
                Parameter.Parent_Id = id;
                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Item_Id", Parameter.Parent_Id));
                    paramCollection.Add(new DBParameter("@ITEM_NAME", Parameter.ItemName));
                    paramCollection.Add(new DBParameter("@ITEM_QTY", Parameter.Qty));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertItemParameterized", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }

        //Save Item BatchWise Details From PopupWindow
        public bool SaveItemBatchWiseDetails(List<ItemBatchWiseDetailsModel> lstBatch, int id)
        {
            string Query = string.Empty;
            bool isSaved = true;
            foreach (ItemBatchWiseDetailsModel Batchwise in lstBatch)
            {
                Batchwise.Parent_Id = id;
                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Item_Id", Batchwise.Parent_Id));
                    paramCollection.Add(new DBParameter("@ITEM_BATCHNO", Batchwise.BatchNo));
                    paramCollection.Add(new DBParameter("@ITEM_QTY", Batchwise.Qty));
                    paramCollection.Add(new DBParameter("@ITEM_MFGDATE", Batchwise.MfgDate,System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@ITEM_EXPDATE", Batchwise.Expdate, System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertItemBatchWiseDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }

        //Save Item MRPWise Details From PopupWindow
        public bool SaveItemMRPWiseDetails(List<ItemMRPWiseDetailsModel> lstMRPWISE, int id)
        {
            string Query = string.Empty;
            bool isSaved = true;
            foreach (ItemMRPWiseDetailsModel MRPwise in lstMRPWISE)
            {
                MRPwise.ParentId = id;
                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Item_Id", MRPwise.ParentId));
                    paramCollection.Add(new DBParameter("@ITEM_MRP", MRPwise.MRP, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_SALESPRICE", MRPwise.SalesPrice, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_QUANTITY", MRPwise.Quantity, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_AMOUNT", MRPwise.Amount, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertItemMRPWiseDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }

        //Save Item Define Critical Level From PopupWindow
        public bool SaveItemCriticalLevelDetails(List<DefineCriticalLevelModel> lstCritical, int id)
        {
            string Query = string.Empty;
            bool isSaved = true;
            foreach (DefineCriticalLevelModel objCriti in lstCritical)
            {
                objCriti.ParentId = id;
                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Item_Id", objCriti.ParentId));
                    paramCollection.Add(new DBParameter("@ITEM_MINIMUMLVLQTY", objCriti.MinimumLevelQty, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_RECORDLVLQTY", objCriti.RecordLevelQty, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_MAXIMUMLVLQTY", objCriti.MaximumLevelQty, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_MINIMUMLVLDAYS", objCriti.MinimumLevelDays, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_RECORDLVLDAYS", objCriti.RecordLevelDays, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_MAXIMUMLVLDAYS", objCriti.MaximumLevelDays, System.Data.DbType.Decimal));

                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertItemCriticalLvlDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }
        //Get All Items By Id
        public ItemMasterModel GetAllItemsById(int id)
        {
            ItemMasterModel objItem = new ItemMasterModel();
            string Query = string.Empty;

            Query = "SELECT * FROM itemmaster WHERE ITM_ID="+id;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            { 
                objItem.Name = dr["ITEM_Name"].ToString();
                objItem.PrintName = dr["ITEM_PRINTName"].ToString()==null?string.Empty: dr["ITEM_PRINTName"].ToString();
                objItem.Alias = dr["ITEM_ALIAS"].ToString();
                objItem.Group = dr["ITEM_GROUP"].ToString();
                objItem.Company = dr["ITEM_COMPANY"].ToString();
                objItem.MainUnit = dr["ITEM_MAINUNIT"].ToString();
                objItem.AltUnit = dr["ITEM_ALTUNIT"].ToString();
                //objItem.Confactor =Convert.ToInt32(dr["ITEM_CONFACTOR"].ToString());
                objItem.OpStockQty =Convert.ToDouble(dr["ITEM_OPSTOCK"].ToString());
                objItem.Unit = dr["ITEM_UNIT"].ToString();
                objItem.Rate =Convert.ToDouble(dr["ITEM_RATE"].ToString());
                objItem.Per = dr["ITEM_PER"].ToString();
                objItem.Value =Convert.ToDouble( dr["ITEM_VALUE"].ToString());
                objItem.ApplySalesPrice = dr["ITEM_SALEPRICETOAPPLY"].ToString();
                objItem.ApplyPurchPrice = dr["ITEM_PURCPRICETOAPPLY"].ToString();

                objItem.MainSalePrice =Convert.ToDecimal(dr["ITEM_SALEPRICE"].ToString());
                objItem.MainPurprice = Convert.ToDecimal(dr["ITEM_PURCHASEPRICE"].ToString());
                objItem.MainMRP = Convert.ToDecimal(dr["ITEM_MRP"].ToString());
                objItem.MainMinSalePrice = Convert.ToDecimal(dr["ITEM_MINSALEPRICE"].ToString());
                objItem.SelfValuePrice = Convert.ToDecimal(dr["ITEM_SELFVALUEPRICE"].ToString());
                objItem.SaleDiscount = Convert.ToDecimal(dr["ITEM_SALEDISCOUNT"].ToString());
                objItem.PurDiscount = Convert.ToDecimal(dr["ITEM_PURCHASEDISCOUNT"].ToString());

                objItem.SpecifySaleDiscStructure = Convert.ToBoolean(dr["ITEM_SPECIFYSALEDISCSTRUCT"]);
                objItem.SpecifyPurDiscStructure = Convert.ToBoolean(dr["ITEM_SPECIFYPURDISCSTRUCT"]);
                objItem.StockValMethod = dr["ITEM_STOCKVALMETHOD"].ToString();

                objItem.TaxCategory = dr["ITEM_TAXCATEGORY"].ToString();
                objItem.ItemDescription1 = dr["ITEM_DESCRIPTION1"].ToString();
                objItem.ItemDescription2 = dr["ITEM_DESCRIPTION2"].ToString();
                objItem.ItemDescription3 = dr["ITEM_DESCRIPTION3"].ToString();
                objItem.ItemDescription4 = dr["ITEM_DESCRIPTION4"].ToString();

                objItem.SetCriticalLevel = Convert.ToBoolean(dr["ITEM_SETCRITICALLEVEL"]);

                objItem.MaintainRG23D = Convert.ToBoolean(dr["ITEM_MAINTAINRG23D"]);
                objItem.TariffHeading = dr["ITEM_TARIFHEADING"].ToString();
                objItem.SerialNumberwiseDetails = Convert.ToBoolean(dr["ITEM_SERIALWISEDETAILS"]);
                objItem.MRPWiseDetails = Convert.ToBoolean(dr["ITEM_MRPWISEDETAILS"]);
                objItem.ParameterizedDetails = Convert.ToBoolean(dr["ITEM_PARAMETERIZEDDETAILS"]);
                objItem.BatchwiseDetails = Convert.ToBoolean(dr["ITEM_BATCHWISEDETAILS"]);
                objItem.ExpDateRequired = Convert.ToBoolean(dr["ITEM_EXPDATEREQUIRED"]);
                objItem.ExpiryDays = Convert.ToInt32(dr["ITEM_EXPIRYDAYS"]);
                objItem.SalesAccount = dr["ITEM_SALESACCOUNT"].ToString();
                objItem.PurcAccount = dr["ITEM_PURCACCOUNT"].ToString();
                objItem.SpecifyDefaultMC = Convert.ToBoolean(dr["ITEM_SPECIFYDEFAULTMC"]);
                objItem.FreezeMCforItem = Convert.ToBoolean(dr["ITEM_FREEZEMCFORITEM"]);
                objItem.TotalNumberofAuthors = Convert.ToInt32(dr["ITEM_TOTALNUMBEROFAUTHORS"]);
                objItem.DontMaintainStockBal = Convert.ToBoolean(dr["ITEM_MAINTAINSTOCKBAL"]);
                objItem.PickItemSizefromDescription = Convert.ToBoolean(dr["ITEM_PICKITEMSIZEFROMDESC"]);
                objItem.SpecifyDefaultVendor = Convert.ToBoolean(dr["ITEM_SPECIFYDEFAULTVENDOR"]);              

            }
            return objItem;

        }

        //Update Item Master
        public bool UpdateItemMaster(eSunSpeedDomain.ItemMasterModel objItem)
      {
          string Query = string.Empty;

          DBParameterCollection paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@ITEM_Name", objItem.Name));
            paramCollection.Add(new DBParameter("@ITEM_PrintName", objItem.PrintName));
            paramCollection.Add(new DBParameter("@ITEM_ALIAS", objItem.Alias));
            paramCollection.Add(new DBParameter("@ITEM_GROUP", objItem.Group));
            paramCollection.Add(new DBParameter("@ITEM_COMPANY", objItem.Company));

            paramCollection.Add(new DBParameter("@ITEM_MAINUNIT", objItem.MainUnit));
            paramCollection.Add(new DBParameter("@ALT_UNIT", objItem.AltUnit));
            //paramCollection.Add(new DBParameter("@ITEM_CONFACTOR", objItem.Confactor));
            paramCollection.Add(new DBParameter("@ITEM_OPSTOCKVALUE", objItem.OpStockValue));
            paramCollection.Add(new DBParameter("@ITEM_UNIT", objItem.Unit));
            paramCollection.Add(new DBParameter("@ITEM_RATE", objItem.Rate));
            paramCollection.Add(new DBParameter("@ITEM_PER", objItem.Per));
            paramCollection.Add(new DBParameter("@ITEM_VALUE", objItem.Value));

            paramCollection.Add(new DBParameter("@ITEM_APPLYSALEPRICE", objItem.ApplySalesPrice, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ITEM_APPLYPURCPRICE", objItem.ApplyPurchPrice, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ITEM_SALEPRICE", objItem.MainSalePrice));
            paramCollection.Add(new DBParameter("@ITEM_PURCEPRICE", objItem.MainPurprice));
            paramCollection.Add(new DBParameter("@ITEM_MRP", objItem.MainMRP));
            paramCollection.Add(new DBParameter("@ITEM_MINSALEPRICE", objItem.MainSalePrice));
            paramCollection.Add(new DBParameter("@ITEM_SELFVALUEPRICE", objItem.SelfValuePrice));
            paramCollection.Add(new DBParameter("@ITEM_SALEDISCOUNT", objItem.SaleDiscount));
            paramCollection.Add(new DBParameter("@ITEM_PURCHASEDISCOUNT", objItem.PurDiscount));
            paramCollection.Add(new DBParameter("@ITEM_SpecifySaleDiscStructure", objItem.SpecifySaleDiscStructure, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ITEM_SpecifyPurDiscStructure", objItem.SpecifyPurDiscStructure, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ITEM_StockValMethod", objItem.StockValMethod));

            //paramCollection.Add(new DBParameter("@ITEM_SALECOMPDISCOUNT", objItem.SaleCompoundDiscount ));
            //paramCollection.Add(new DBParameter("@ITEM_PURCHCOMPDISCOUNT", objItem.PurCompoundDiscount));
            //paramCollection.Add(new DBParameter("@ITEM_SALEMARKUP",objItem.SaleMarkup ));
            //paramCollection.Add(new DBParameter("@ITEM_PURMARKUP",objItem.PurMarkup ));
            paramCollection.Add(new DBParameter("@ITEM_TAXCATEGORY", objItem.TaxCategory));
            paramCollection.Add(new DBParameter("@ITEM_DESCRIPTION1", objItem.ItemDescription1));
            paramCollection.Add(new DBParameter("@ITEM_DESCRIPTION2", objItem.ItemDescription2));
            paramCollection.Add(new DBParameter("@ITEM_DESCRIPTION3", objItem.ItemDescription3));
            paramCollection.Add(new DBParameter("@ITEM_DESCRIPTION4", objItem.ItemDescription4));

            paramCollection.Add(new DBParameter("@ITEM_SETCRITICALLEVEL", objItem.SetCriticalLevel, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ITEM_MAINTAINRG23D", objItem.MaintainRG23D, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ITEM_TARIFHEADING", objItem.TariffHeading));
            paramCollection.Add(new DBParameter("@ITEM_SERIALWISEDETAILS", objItem.SerialNumberwiseDetails, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ITEM_PARAMETERIZEDDETAILS", objItem.ParameterizedDetails, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ITEM_MRPWISEDETAILS", objItem.MRPWiseDetails, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ITEM_BATCHWISEDETAILS", objItem.BatchwiseDetails, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ITEM_EXPDATEREQUIRED", objItem.ExpDateRequired, System.Data.DbType.Boolean));

            paramCollection.Add(new DBParameter("@ITEM_EXPIRYDAYS", objItem.ExpiryDays));
            paramCollection.Add(new DBParameter("@ITEM_SALESACCOUNT", objItem.SalesAccount));
            paramCollection.Add(new DBParameter("@ITEM_PURCACCOUNT", objItem.PurcAccount));
            paramCollection.Add(new DBParameter("@ITEM_MAINTAINSTOCKBAL", objItem.DontMaintainStockBal, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ITEM_SPECIFYDEFAULTMC", objItem.SpecifyDefaultMC, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ITEM_FREEZEMCFORITEM", objItem.FreezeMCforItem, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ITEM_TOTALNUMBEROFAUTHORS", objItem.TotalNumberofAuthors));

            paramCollection.Add(new DBParameter("@ITEM_PICKITEMSIZEFROMDESC", objItem.PickItemSizefromDescription, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ITEM_SPECIFYDEFAULTVENDOR", objItem.SpecifyDefaultVendor, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@CreatedBy", objItem.CreatedBy));
            paramCollection.Add(new DBParameter("@ITEM_ID", objItem.ItemId));

          Query = "UPDATE itemmaster SET `ITEM_Name`=@ITEM_Name,`ITEM_PRINTName`=@ITEM_PrintName,`ITEM_ALIAS`=@ITEM_ALIAS,`ITEM_GROUP`=@ITEM_GROUP," +
              "`ITEM_MAINUNIT`=@ITEM_MAINUNIT,`ITEM_ALTUNIT`=@ALT_UNIT,`ITEM_CONFACTOR`=@ITEM_CONFACTOR,`ITEM_OPSTOCK`=@ITEM_OPSTOCKVALUE,`ITEM_UNIT`=@ITEM_UNIT,`ITEM_RATE`=@ITEM_RATE,`ITEM_PER`=@ITEM_PER,`ITEM_VALUE`=@ITEM_VALUE," +
              "`ITEM_SALEPRICETOAPPLY`=@ITEM_APPLYSALEPRICE,`ITEM_PURCPRICETOAPPLY`=@ITEM_APPLYPURCPRICE," +
              "`ITEM_SALEPRICE`=@ITEM_SALEPRICE,`ITEM_PURCHASEPRICE`=@ITEM_PURCEPRICE,`ITEM_MRP`=@ITEM_MRP,`ITEM_MINSALEPRICE`=@ITEM_MINSALEPRICE," +
              "`ITEM_SELFVALUEPRICE`=@ITEM_SELFVALUEPRICE,`ITEM_SALEDISCOUNT`=@ITEM_SALEDISCOUNT,`ITEM_PURCHASEDISCOUNT`=@ITEM_PURCHASEDISCOUNT," +
              "`ITEM_SPECIFYSALEDISCSTRUCT`=@ITEM_SpecifySaleDiscStructure,`ITEM_SPECIFYPURDISCSTRUCT`=@ITEM_SpecifyPurDiscStructure," +
              "`ITEM_STOCKVALMETHOD`=@ITEM_StockValMethod,`ITEM_TAXCATEGORY`=@ITEM_TAXCATEGORY," +
              "`ITEM_DESCRIPTION1`=@ITEM_DESCRIPTION1,`ITEM_DESCRIPTION2`=@ITEM_DESCRIPTION2," +
              "`ITEM_DESCRIPTION3`=@ITEM_DESCRIPTION3,`ITEM_DESCRIPTION4`=@ITEM_DESCRIPTION4,"+
              "`ITEM_SETCRITICALLEVEL`=@ITEM_SETCRITICALLEVEL,`ITEM_MAINTAINRG23D`=@ITEM_MAINTAINRG23D,`ITEM_TARIFHEADING`=@ITEM_TARIFHEADING," +
              "`ITEM_SERIALWISEDETAILS`=@ITEM_SERIALWISEDETAILS,`ITEM_MRPWISEDETAILS`=@ITEM_MRPWISEDETAILS," +
              "`ITEM_PARAMETERIZEDDETAILS`=@ITEM_PARAMETERIZEDDETAILS,`ITEM_BATCHWISEDETAILS`=@ITEM_BATCHWISEDETAILS,`ITEM_EXPDATEREQUIRED`=@ITEM_EXPDATEREQUIRED,"+
              "`ITEM_EXPIRYDAYS`=@ITEM_EXPIRYDAYS,`ITEM_SALESACCOUNT`=@ITEM_SALESACCOUNT,`ITEM_PURCACCOUNT`=@ITEM_PURCACCOUNT,`ITEM_SPECIFYDEFAULTMC`=@ITEM_SPECIFYDEFAULTMC," +
              "`ITEM_FREEZEMCFORITEM`=@ITEM_FREEZEMCFORITEM,`ITEM_TOTALNUMBEROFAUTHORS`=@ITEM_TOTALNUMBEROFAUTHORS,`ITEM_MAINTAINSTOCKBAL`=@ITEM_MAINTAINSTOCKBAL," +
              "`ITEM_PICKITEMSIZEFROMDESC`=@ITEM_PICKITEMSIZEFROMDESC,`ITEM_SPECIFYDEFAULTVENDOR`=@ITEM_SPECIFYDEFAULTVENDOR,`CREATEDBY`=@CreatedBy " +
              "WHERE `ITM_ID`=@ITEM_ID";        

          return _dbHelper.ExecuteNonQuery(Query, paramCollection) > 0;

      }

        //List All Item Master
      public List<ItemMasterModel> GetAllItems()
      {
          List<ItemMasterModel> lstItems = new List<ItemMasterModel>();
          ItemMasterModel objItem;

          string Query = string.Empty;

          Query = "SELECT * FROM itemmaster";
          System.Data.IDataReader dr= _dbHelper.ExecuteDataReader(Query,_dbHelper.GetConnObject());

          while (dr.Read())
          {
              objItem = new eSunSpeedDomain.ItemMasterModel();
                objItem.ItemId = Convert.ToInt32(dr["ITM_ID"]);
              objItem.Name = dr["ITEM_Name"].ToString();
              objItem.Alias = dr["ITEM_ALIAS"].ToString();
              objItem.Group = dr["ITEM_GROUP"].ToString();
              objItem.OpStockValue = Convert.ToDouble(dr["ITEM_OPSTOCK"].ToString());
              objItem.Unit = dr["ITEM_UNIT"].ToString();             
              lstItems.Add(objItem);
          
          }
          return lstItems;

      }

        //Get Item Details By Name
        public ItemMasterModel GetItemsByName(string itemname)
        {
            ItemMasterModel objItem = new ItemMasterModel();

            string Query = string.Empty;

            Query = "SELECT * FROM ITEM_MASTER WHERE ITEM_Name='" + itemname + "'" ;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objItem = new eSunSpeedDomain.ItemMasterModel();
                objItem.Name = dr["ITEM_Name"].ToString();
                objItem.Alias = dr["ITEM_ALIAS"].ToString();
                
                objItem.Unit = dr["ITEM_UNIT"].ToString();
                objItem.OpStockQty = Convert.ToDouble(dr["ITEM_OPSTOCKQTY"]);
                objItem.OpStockValue = Convert.ToDouble(dr["ITEM_OPSTOCKVALUE"]);
                objItem.MainSalePrice = Convert.ToDecimal(dr["ITEM_SALEPRICE"]);

                objItem.MainMRP = Convert.ToDecimal(dr["ITEM_MRP"]);
                objItem.MainMinSalePrice = Convert.ToDecimal(dr["ITEM_MINSALEPRICE"]);
                objItem.SelfValuePrice = Convert.ToDecimal(dr["ITEM_SELFVALUEPRICE"]);
                objItem.SaleDiscount = Convert.ToDecimal(dr["ITEM_SALEDISCOUNT"]);
                               
            }
            return objItem;

        }

        //Delete Multiple Items
        public bool DeleteItemMaster(List<int> lstIds)
        {
            string Query = string.Empty;
            bool isDeleted = true;

            try
            {
                DBParameterCollection paramCollection;

                foreach (int id in lstIds)
                {
                    paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@ITM_ID", id));
                    Query = "Delete from ITEM_MASTER WHERE [ITEM_ID]=@ITM_ID";

                    if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                        isDeleted = true;
                }

            }
            catch (Exception ex)
            {
                isDeleted = false;
                throw ex;
            }

            return isDeleted;
        }

        //Delete Single Item
        public bool DeleteItemMasterById(int id)
        {
            bool isDelete = false;
            try
            {                                
                string Query = "DELETE FROM itemmaster WHERE ITM_ID=" + id;
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

        //Is Item Master Exists Or Not
        public bool IsItemMasterExists(string ItemName)
        {
            StringBuilder _sbQuery = new StringBuilder();
            _sbQuery.AppendFormat("SELECT COUNT(*) FROM `itemmaster` WHERE `ITEM_Name`='{0}'", ItemName);

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(_sbQuery.ToString(), _dbHelper.GetConnObject());
            dr.Read();
            if (Convert.ToInt32(dr[0]) > 0)
                return true;
            else
                return false;

        }
        //Get Item Name By Item Group
        public ItemMasterModel GetItemNameByGroupname(string groupname)
        {
            ItemMasterModel objItem = new ItemMasterModel();

            string Query = string.Empty;

            Query = "SELECT ITEM_Name FROM itemmaster WHERE ITEM_GROUP='" + groupname + "'";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objItem = new eSunSpeedDomain.ItemMasterModel();
              
                objItem.Name = dr["ITEM_Name"].ToString();
            }
            return objItem;

        }

        //Get Item Name By TaxCategory Name
        public ItemMasterModel GetItemNameByTaxCategoryname(string TaxName)
        {
            ItemMasterModel objItem = new ItemMasterModel();

            string Query = string.Empty;

            Query = "SELECT ITEM_Name FROM `itemmaster` WHERE `ITEM_TAXCATEGORY` ='" + TaxName + "'";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objItem = new eSunSpeedDomain.ItemMasterModel();

                objItem.Name = dr["ITEM_Name"].ToString();
            }
            return objItem;

        }
    }
}
