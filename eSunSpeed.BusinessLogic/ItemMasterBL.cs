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

                paramCollection.Add(new DBParameter("@ITEM_OPSTOCKVALUE", objItem.OpStockQty));
                paramCollection.Add(new DBParameter("@ITEM_UNIT", objItem.Unit));
                paramCollection.Add(new DBParameter("@ITEM_RATE", objItem.Rate));
                paramCollection.Add(new DBParameter("@ITEM_PER", objItem.Per));
                paramCollection.Add(new DBParameter("@ITEM_VALUE", objItem.OpStockValue));

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
                if(objItem.DiscountInfo)
                {
                    paramCollection.Add(new DBParameter("@ITEM_SALEDISCOUNT", objItem.SaleDiscount, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_PURCHASEDISCOUNT", objItem.PurDiscount, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_SALEDISCOUNTCOMP", objItem.SaleCompoundDiscount, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_PURCHASEDISCOUNTCOMP", objItem.PurCompoundDiscount, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_SpecifySaleDiscStructure", objItem.SpecifySaleDiscStructure, System.Data.DbType.Boolean));
                    paramCollection.Add(new DBParameter("@ITEM_SpecifyPurDiscStructure", objItem.SpecifyPurDiscStructure, System.Data.DbType.Boolean));
                    paramCollection.Add(new DBParameter("@ITEM_SaleDiscStructure", objItem.SaleDiscStructure));
                    paramCollection.Add(new DBParameter("@ITEM_PurcDiscStructure", objItem.PurcDiscStructure));
                }
                else
                {
                    paramCollection.Add(new DBParameter("@ITEM_SALEDISCOUNT", "0.00"));
                    paramCollection.Add(new DBParameter("@ITEM_PURCHASEDISCOUNT", "0.00"));
                    paramCollection.Add(new DBParameter("@ITEM_SALEDISCOUNTCOMP", "0.00"));
                    paramCollection.Add(new DBParameter("@ITEM_PURCHASEDISCOUNTCOMP", "0.00"));
                    paramCollection.Add(new DBParameter("@ITEM_SpecifySaleDiscStructure", false, System.Data.DbType.Boolean));
                    paramCollection.Add(new DBParameter("@ITEM_SpecifyPurDiscStructure", false, System.Data.DbType.Boolean));
                    paramCollection.Add(new DBParameter("@ITEM_SaleDiscStructure",String.Empty));
                    paramCollection.Add(new DBParameter("@ITEM_PurcDiscStructure",String.Empty));
                }
                paramCollection.Add(new DBParameter("@ITEM_MARKUPINFO", objItem.MarkupInfo, System.Data.DbType.Boolean));
                if(objItem.MarkupInfo)
                {
                    paramCollection.Add(new DBParameter("@ITEM_SaleMarkup", objItem.SaleMarkup, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_PurMarkup", objItem.PurMarkup, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_SaleCompMarkup", objItem.SaleCompMarkup, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_PurCompMarkup", objItem.PurCompMarkup, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_SpecifySaleMarkupStruct", objItem.SpecifySaleMarkupStruct, System.Data.DbType.Boolean));
                    paramCollection.Add(new DBParameter("@ITEM_SpecifyPurMarkupStruct", objItem.SpecifyPurMarkupStruct, System.Data.DbType.Boolean));
                    paramCollection.Add(new DBParameter("@ITEM_SaleMarkupStructure", objItem.SaleMarkupStructure));
                    paramCollection.Add(new DBParameter("@ITEM_PurcMarkupStructure", objItem.PurcMarkupStructure));
                }
                else
                {
                    paramCollection.Add(new DBParameter("@ITEM_SaleMarkup","0.00"));
                    paramCollection.Add(new DBParameter("@ITEM_PurMarkup","0.00"));
                    paramCollection.Add(new DBParameter("@ITEM_SaleCompMarkup", "0.00"));
                    paramCollection.Add(new DBParameter("@ITEM_PurCompMarkup", "0.00"));
                    paramCollection.Add(new DBParameter("@ITEM_SpecifySaleMarkupStruct",false, System.Data.DbType.Boolean));
                    paramCollection.Add(new DBParameter("@ITEM_SpecifyPurMarkupStruct", false, System.Data.DbType.Boolean));
                    paramCollection.Add(new DBParameter("@ITEM_SaleMarkupStructure",String.Empty));
                    paramCollection.Add(new DBParameter("@ITEM_PurcMarkupStructure", String.Empty));
                }
                

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
                paramCollection.Add(new DBParameter("@ITEM_EXPDATEREQUIRED", objItem.ExpDateRequired));

                paramCollection.Add(new DBParameter("@ITEM_EXPIRYDAYS", objItem.ExpiryDays));
                paramCollection.Add(new DBParameter("@ITEM_SALESACCOUNT", objItem.SalesAccount));
                paramCollection.Add(new DBParameter("@ITEM_PURCACCOUNT", objItem.PurcAccount));
                paramCollection.Add(new DBParameter("@ITEM_MAINTAINSTOCKBAL", objItem.DontMaintainStockBal, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ITEM_SPECIFYDEFAULTMC", objItem.SpecifyDefaultMC, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ITEM_MATERIALCENTER", objItem.DefaultMaterialCenter));
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

                //SaveItemBarcodes(objItem.ItemBarcode,id);
                if(objItem.SpecifyDefaultMC)
                {
                    SaveItemMaterialCenterDetails(objItem.ItemMC, id);
                }
                if (objItem.ParameterizedDetails && objItem.OpStockValue.ToString() != "0.00")
                {
                    SaveItemParameterizedDetails(objItem.ItemParameterized, id);
                }
                if(objItem.BatchwiseDetails && objItem.OpStockValue.ToString() != "0.00")
                {
                    SaveItemBatchWiseDetails(objItem.ItemBatchWise, id);
                }
                if (objItem.SetCriticalLevel)
                {
                    SaveItemCriticalLevelDetails(objItem.ItemCriticalLevel, id);
                }
                if(objItem.MRPWiseDetails && objItem.OpStockValue.ToString() != "0.00")
                {
                    SaveItemMRPWiseDetails(objItem.ItemMRPWise, id);   
                }

                if (objItem.SerialNumberwiseDetails && objItem.OpStockValue.ToString() != "0.00")
                {
                    SaveItemSerialWiseDetails(objItem.ItemSerialNo, id);
                }
            }
            catch(Exception ex)
            {
                isSaved = false;
                //throw ex;
            }
            return isSaved;
        }

        //Save Item Barcodes
        public bool SaveItemBarcodes(List<ItemAliasModel> lstBarcodes,int id)
        {
            string Query = string.Empty;
            bool isSaved = true;
            foreach (ItemAliasModel item in lstBarcodes)
            {
                item.ParentId = id;
                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Item_Id",item.ParentId));
                    paramCollection.Add(new DBParameter("@Item_Barcode",item.Barcodes));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertItemBarcodes", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }

        //Update Item Barcodes
        public bool UpdateItemBarcodes(List<ItemAliasModel> lstBarcodes, int id)
        {
            string Query = string.Empty;
            bool isUpdate = true;
            foreach (ItemAliasModel item in lstBarcodes)
            {
                item.ParentId = id;
                if (item.BarcodeId > 0)
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();
                    paramCollection.Add(new DBParameter("@Item_Id", item.ParentId));
                    paramCollection.Add(new DBParameter("@SL_ID", item.BarcodeId));
                    paramCollection.Add(new DBParameter("@ITEM_Barcode", item.Barcodes));
                    paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                    Query = "UPDATE itembarcodes SET `ITEM_BARCODE`=@ITEM_Barcode," +
                           "`ModifiedBy`=@ModifiedBy " +
                           "WHERE `ITM_ID`=@Item_Id AND `SL_ID`=@SL_ID";
                    if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                    {
                        isUpdate = true;
                    }

                }
                else
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Item_Id", item.ParentId));
                    paramCollection.Add(new DBParameter("@Item_Barcode", item.Barcodes));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertItemBarcodes", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
            }
            return isUpdate = true;
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

        //UPDATE Item Serieal Number Wise Details From PopupWindow.
        public bool UpdateSerialNumberWiseDeatils(ItemMasterModel Serial, int id)
        {
            string Query = string.Empty;
            bool isUpdate = true;

            Serial.parent_Id = id;
            if (Serial.SL_ID > 0)
            {

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Item_Id", Serial.parent_Id));
                    paramCollection.Add(new DBParameter("@SL_NO", Serial.SL_ID));
                    paramCollection.Add(new DBParameter("@Item_ManulaNo", Serial.ManualNuber, System.Data.DbType.Boolean));
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
                    _dbHelper.ExecuteDataReader("spUpdateItemSerialNoDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    isUpdate = false;
                    throw ex;
                }
            }
            else
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Item_Id", Serial.parent_Id));
                paramCollection.Add(new DBParameter("@Item_ManulaNo", Serial.ManualNuber, System.Data.DbType.Boolean));
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
            return isUpdate;
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
                    paramCollection.Add(new DBParameter("@ITEM_UNIT", Parameter.Unit));
                    paramCollection.Add(new DBParameter("@ITEM_MRP", Parameter.MRP,System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_SALEPRICE", Parameter.SalePrice, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_COSTPRICE", Parameter.Costprice, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_BARCODE", Parameter.Barcode));

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

        //UPDATE Item Parmeterized Details From PopupWindow
        public bool UpdateItemParameterizedDetails(List<ItemParameterizedModel> lstParameter, int id)
        {
            string Query = string.Empty;
            bool isUpdate = true;
           
            foreach (ItemParameterizedModel Parameter in lstParameter)
            {
                Parameter.Parent_Id = id;
                if (Parameter.Param_Id > 0)
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();
                    paramCollection.Add(new DBParameter("@Item_Id", Parameter.Parent_Id));
                    paramCollection.Add(new DBParameter("@SL_NO", Parameter.Param_Id));
                    paramCollection.Add(new DBParameter("@ITEM_NAME", Parameter.ItemName));
                    paramCollection.Add(new DBParameter("@ITEM_QTY", Parameter.Qty));
                    paramCollection.Add(new DBParameter("@ITEM_UNIT", Parameter.Unit));
                    paramCollection.Add(new DBParameter("@ITEM_MRP", Parameter.MRP, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_SALEPRICE", Parameter.SalePrice, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_COSTPRICE", Parameter.Costprice, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_BARCODE", Parameter.Barcode));
                    paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));

                    Query = "UPDATE itemparameterizeddetails SET `ITEM_NAME`=@ITEM_NAME," +
                           "`ITEM_QTY`=@ITEM_QTY,`ITEM_UNIT`=@ITEM_UNIT,`ITEM_MRP`=@ITEM_MRP,`ITEM_SALEPRICE`=@ITEM_SALEPRICE,`ITEM_COSTPRICE`=@ITEM_COSTPRICE,`ITEM_BARCODE`=@ITEM_BARCODE,`ModifiedBy`=@ModifiedBy " +
                           "WHERE `ITM_ID`=@Item_Id AND `SL_NO`=@SL_NO";

                    if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                    {
                        isUpdate = true;
                    }

                }
                else
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Item_Id", Parameter.Parent_Id));
                    paramCollection.Add(new DBParameter("@ITEM_NAME", Parameter.ItemName));
                    paramCollection.Add(new DBParameter("@ITEM_QTY", Parameter.Qty));
                    paramCollection.Add(new DBParameter("@ITEM_UNIT", Parameter.Unit));
                    paramCollection.Add(new DBParameter("@ITEM_MRP", Parameter.MRP, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_SALEPRICE", Parameter.SalePrice, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_COSTPRICE", Parameter.Costprice, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_BARCODE", Parameter.Barcode));

                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertItemParameterized", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
            }
            return isUpdate=true;
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
                    paramCollection.Add(new DBParameter("@ITEM_QTY", Batchwise.Qty,System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_UNIT", Batchwise.Unit));
                    paramCollection.Add(new DBParameter("@ITEM_MRP", Batchwise.MRP, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_SALEPRICE", Batchwise.SalePrice, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_COSTPRICE", Batchwise.CostPrice, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_MFGDATE", Batchwise.MfgDate,System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@ITEM_EXPDATE", Batchwise.Expdate, System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@ITEM_BARCODE", Batchwise.Barcode));
                    paramCollection.Add(new DBParameter("@ITEM_NARRATION", Batchwise.Narration));
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
        //Update Batch Wise Details
        public bool UpdateItemBatchWiseDetails(List<ItemBatchWiseDetailsModel> lstBatch, int id)
        {
            string Query = string.Empty;
            bool isUpdate = true;
            foreach (ItemBatchWiseDetailsModel Batchwise in lstBatch)
            {
                Batchwise.Parent_Id = id;
                if (Batchwise.Batch_Id > 0)
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Item_Id", Batchwise.Parent_Id));
                    paramCollection.Add(new DBParameter("@Batch_Id", Batchwise.Batch_Id));
                    paramCollection.Add(new DBParameter("@ITEM_BATCHNO", Batchwise.BatchNo));
                    paramCollection.Add(new DBParameter("@ITEM_QTY", Batchwise.Qty));
                    paramCollection.Add(new DBParameter("@ITEM_UNIT", Batchwise.Unit));
                    paramCollection.Add(new DBParameter("@ITEM_MRP", Batchwise.MRP));
                    paramCollection.Add(new DBParameter("@ITEM_SALEPRICE", Batchwise.SalePrice));
                    paramCollection.Add(new DBParameter("@ITEM_COSTPRICE", Batchwise.CostPrice));
                    paramCollection.Add(new DBParameter("@ITEM_MFGDATE", Batchwise.MfgDate, System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@ITEM_EXPDATE", Batchwise.Expdate, System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@ITEM_NARRATION", Batchwise.Narration));
                    paramCollection.Add(new DBParameter("@ITEM_BARCODE", Batchwise.Barcode));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    Query = "UPDATE itembatchwisedetails SET `ITEM_BATCHNO`=@ITEM_BATCHNO," +
                           "`ITEM_QTY`=@ITEM_QTY,`ITEM_UNIT`=@ITEM_UNIT,`ITEM_MRP`=@ITEM_MRP,`ITEM_SALESPRICE`=@ITEM_SALEPRICE,`ITEM_COSTPRICE`=@ITEM_COSTPRICE,`ITEM_MFGDATE`=@ITEM_MFGDATE,`ITEM_EXPDATE`=@ITEM_EXPDATE,`ITEM_BARCODE`=@ITEM_BARCODE,`NARRATION`=@ITEM_NARRATION,`CreatedBy`=@CreatedBy " +
                           "WHERE `ITM_ID`=@Item_Id AND `SL_NO`=@Batch_Id";

                    if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                    {
                        isUpdate = true;
                    }

                }
                else
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Item_Id", Batchwise.Parent_Id));
                    paramCollection.Add(new DBParameter("@ITEM_BATCHNO", Batchwise.BatchNo));
                    paramCollection.Add(new DBParameter("@ITEM_QTY", Batchwise.Qty, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_UNIT", Batchwise.Unit));
                    paramCollection.Add(new DBParameter("@ITEM_MRP", Batchwise.MRP, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_SALEPRICE", Batchwise.SalePrice, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_COSTPRICE", Batchwise.CostPrice, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_MFGDATE", Batchwise.MfgDate, System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@ITEM_EXPDATE", Batchwise.Expdate, System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@ITEM_BARCODE", Batchwise.Barcode));
                    paramCollection.Add(new DBParameter("@ITEM_NARRATION", Batchwise.Narration));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertItemBatchWiseDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
            }
            return isUpdate = true;
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
                    paramCollection.Add(new DBParameter("@ITEM_QUANTITY", MRPwise.Quantity, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_UNIT", MRPwise.Unit));
                    paramCollection.Add(new DBParameter("@ITEM_MRP", MRPwise.MRP, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_SALESPRICE", MRPwise.SalesPrice, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_COSTPRICE", MRPwise.Costprice, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_BARCODE", MRPwise.Barcode));
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

        public bool SaveItemSerialWiseDetails(List<ItemSerialnoDetailsModel> lstSerial, int id)
        {
            string Query = string.Empty;
            bool isSaved = true;
            foreach (ItemSerialnoDetailsModel SerialWise in lstSerial)
            {
                SerialWise.parent_Id = id;
                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Item_Id", SerialWise.parent_Id));
                    paramCollection.Add(new DBParameter("@ITEM_SERIALNO", SerialWise.SerialNumber));
                    paramCollection.Add(new DBParameter("@ITEM_QUANTITY", SerialWise.Quantity, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_UNIT", SerialWise.Unit));
                    paramCollection.Add(new DBParameter("@ITEM_MRP", SerialWise.MRP, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_SALESPRICE", SerialWise.SalePrice, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_COSTPRICE", SerialWise.Costprice, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_BARCODE", SerialWise.Barcode));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertItemSerialNoWiseDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }

        public bool UpdateItemSerialNoWiseDetails(List<ItemSerialnoDetailsModel> lstSerial, int id)
        {
            string Query = string.Empty;
            bool isUpdate = true;
            foreach (ItemSerialnoDetailsModel SerialWise in lstSerial)
            {
                SerialWise.parent_Id = id;
                if (SerialWise.SL_ID > 0)
                {

                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Item_Id", SerialWise.parent_Id));
                    paramCollection.Add(new DBParameter("@SL_Id", SerialWise.SL_ID));
                    paramCollection.Add(new DBParameter("@ITEM_SERIALNO", SerialWise.SerialNumber));
                    paramCollection.Add(new DBParameter("@ITEM_QUANTITY", SerialWise.Quantity, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_UNIT", SerialWise.Unit));
                    paramCollection.Add(new DBParameter("@ITEM_MRP", SerialWise.MRP, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_SALESPRICE", SerialWise.SalePrice, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_COSTPRICE", SerialWise.Costprice, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_BARCODE", SerialWise.Barcode));
                    paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));

                    Query = "UPDATE itemserialnowisedetails SET `ITEM_SERIALNO`=@ITEM_SERIALNO,`ITEM_MRP`=@ITEM_MRP," +
                           "`ITEM_SALESPRICE`=@ITEM_SALESPRICE,`ITEM_QUANTITY`=@ITEM_QUANTITY,`ITEM_UNIT`=@ITEM_UNIT,`ITEM_COSTPRICE`=@ITEM_COSTPRICE,`ITEM_BARCODE`=@ITEM_BARCODE,`ModifiedBy`=@ModifiedBy " +
                           "WHERE `ITM_ID`=@Item_Id AND `SN_ID`=@SL_Id";

                    if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                    {
                        isUpdate = true;
                    }

                }
                else
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Item_Id", SerialWise.parent_Id));
                    paramCollection.Add(new DBParameter("@ITEM_SERIALNO", SerialWise.SerialNumber));
                    paramCollection.Add(new DBParameter("@ITEM_QUANTITY", SerialWise.Quantity, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_UNIT", SerialWise.Unit));
                    paramCollection.Add(new DBParameter("@ITEM_MRP", SerialWise.MRP, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_SALESPRICE", SerialWise.SalePrice, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_COSTPRICE", SerialWise.Costprice, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_BARCODE", SerialWise.Barcode));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertItemSerialNoWiseDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
            }
            return isUpdate = true;

        }
        //Update Item MRPWise Details From PopupWindow
        public bool UpdateItemMRPWiseDetails(List<ItemMRPWiseDetailsModel> lstMRPWISE, int id)
        {
            string Query = string.Empty;
            bool isUpdate = true;
            foreach (ItemMRPWiseDetailsModel MRPwise in lstMRPWISE)
            {
                MRPwise.ParentId = id;
                if (MRPwise.MRP_Id > 0)
                {


                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Item_Id", MRPwise.ParentId));
                    paramCollection.Add(new DBParameter("@MRP_Id", MRPwise.MRP_Id));
                    paramCollection.Add(new DBParameter("@ITEM_QUANTITY", MRPwise.Quantity, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_UNIT", MRPwise.Unit));
                    paramCollection.Add(new DBParameter("@ITEM_MRP", MRPwise.MRP, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_SALESPRICE", MRPwise.SalesPrice, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_COSTPRICE", MRPwise.Costprice, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_BARCODE", MRPwise.Barcode));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    Query = "UPDATE itemmrpwisedetails SET `ITEM_MRP`=@ITEM_MRP," +
                           "`ITEM_SALESPRICE`=@ITEM_SALESPRICE,`ITEM_QUANTITY`=@ITEM_QUANTITY,`ITEM_UNIT`=@ITEM_UNIT,`ITEM_COSTPRICE`=@ITEM_COSTPRICE,`ITEM_BARCODE`=@ITEM_BARCODE,`ModifiedBy`=@ModifiedBy " +
                           "WHERE `ITM_ID`=@Item_Id AND `SL_ID`=@MRP_Id";

                    if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                    {
                        isUpdate = true;
                    }

                }
                else
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Item_Id", MRPwise.ParentId));
                    paramCollection.Add(new DBParameter("@ITEM_QUANTITY", MRPwise.Quantity, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_UNIT", MRPwise.Unit));
                    paramCollection.Add(new DBParameter("@ITEM_MRP", MRPwise.MRP, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_SALESPRICE", MRPwise.SalesPrice, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_COSTPRICE", MRPwise.Costprice, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_BARCODE", MRPwise.Barcode));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertItemMRPWiseDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
            }
            return isUpdate = true;

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
                objItem.ItemId = Convert.ToInt32(dr["ITM_ID"].ToString());
                objItem.Name = dr["ITEM_Name"].ToString();
                objItem.PrintName = dr["ITEM_PRINTName"].ToString()==null?string.Empty: dr["ITEM_PRINTName"].ToString();
                objItem.Alias = dr["ITEM_ALIAS"].ToString();
                objItem.Group = dr["ITEM_GROUP"].ToString();
                objItem.Company = dr["ITEM_COMPANY"].ToString();
                objItem.MainUnit = dr["ITEM_MAINUNIT"].ToString();
                objItem.AltUnit = dr["ITEM_ALTUNIT"].ToString();
                objItem.ConAltUnit =Convert.ToDecimal(dr["ITEM_CONALTUNIT"].ToString());
                objItem.ConMainUnit = Convert.ToDecimal(dr["ITEM_CONMAINUNIT"].ToString());
                objItem.OpStockQty =Convert.ToDouble(dr["ITEM_OPSTOCK"].ToString());
                objItem.Unit = dr["ITEM_UNIT"].ToString();
                objItem.Rate =Convert.ToDouble(dr["ITEM_RATE"].ToString());
                objItem.Per = dr["ITEM_PER"].ToString();
                objItem.OpStockValue =Convert.ToDouble( dr["ITEM_VALUE"].ToString());
                objItem.ApplySalesPrice = dr["ITEM_SALEPRICETOAPPLY"].ToString();
                objItem.ApplyPurchPrice = dr["ITEM_PURCPRICETOAPPLY"].ToString();

                objItem.MainSalePrice = Convert.ToDecimal(dr["ITEM_SALEPRICEMAIN"].ToString() == null ? "0": dr["ITEM_SALEPRICEMAIN"].ToString());
                objItem.MainPurprice = Convert.ToDecimal(dr["ITEM_PURCHASEPRICEMAIN"].ToString());
                objItem.MainMRP = Convert.ToDecimal(dr["ITEM_MRPMAIN"].ToString());
                objItem.MainMinSalePrice = Convert.ToDecimal(dr["ITEM_MINSALEPRICEMAIN"].ToString());

                objItem.AltSalePrice = Convert.ToDecimal(dr["ITEM_SALESPRICEALT"].ToString() == null ? "0" : dr["ITEM_SALEPRICEMAIN"].ToString());
                objItem.AltPurprice = Convert.ToDecimal(dr["ITEM_PURCPRICEALT"].ToString());
                objItem.AltMRP = Convert.ToDecimal(dr["ITEM_MRPALT"].ToString());
                objItem.AltMinSalePrice = Convert.ToDecimal(dr["ITEM_MINSALEPRICEALT"].ToString());

                objItem.SelfValuePrice = Convert.ToDecimal(dr["ITEM_SELFVALUEPRICE"].ToString());
                objItem.DiscountInfo = Convert.ToBoolean(dr["ITEM_DISCOUNTINFO"].ToString());
                objItem.MarkupInfo = Convert.ToBoolean(dr["ITEM_MARKUPINFO"].ToString());
                objItem.SaleDiscount = Convert.ToDecimal(dr["ITEM_SALEDISCOUNT"].ToString());
                objItem.SaleCompoundDiscount = Convert.ToDecimal(dr["ITEM_SALECOMPDISCOUNT"].ToString());              
                objItem.PurDiscount = Convert.ToDecimal(dr["ITEM_PURCHASEDISCOUNT"].ToString());
                objItem.PurCompoundDiscount = Convert.ToDecimal(dr["ITEM_PURCHCOMPDISCOUNT"].ToString());
                objItem.SpecifySaleDiscStructure = Convert.ToBoolean(dr["ITEM_SPECIFYSALEDISCSTRUCT"]);
                objItem.SpecifyPurDiscStructure = Convert.ToBoolean(dr["ITEM_SPECIFYPURDISCSTRUCT"]);
                objItem.SaleDiscStructure = dr["ITEM_SALEDISCOUNTSTRUCT"].ToString();
                objItem.PurcDiscStructure = dr["ITEM_PURCDISCOUNTSTRUCT"].ToString();

                objItem.SaleMarkup = Convert.ToDecimal(dr["ITEM_SALEMARKUP"].ToString());
                objItem.SaleCompMarkup = Convert.ToDecimal(dr["ITEM_SALECOMPMARKUP"].ToString());
                objItem.PurMarkup = Convert.ToDecimal(dr["ITEM_PURMARKUP"].ToString());
                objItem.PurCompMarkup = Convert.ToDecimal(dr["ITEM_PURCCOMPMARKUP"].ToString());
                objItem.SpecifySaleMarkupStruct = Convert.ToBoolean(dr["ITEM_SPECIFYSALEMARKUPSTRUCT"]);
                objItem.SpecifyPurMarkupStruct = Convert.ToBoolean(dr["ITEM_SPECIFYPURCMARKUPSTRUCT"]);
                objItem.SaleMarkupStructure = dr["ITEM_SALEMARKUPSTRUCT"].ToString();
                objItem.PurcMarkupStructure = dr["ITEM_PURCMARKUPSTRUCT"].ToString();
                objItem.StockValMethod = dr["ITEM_STOCKVALMETHOD"].ToString();

                objItem.TaxCategory = dr["ITEM_TAXCATEGORY"].ToString();
                objItem.ItemDescription1 = dr["ITEM_DESCRIPTION1"].ToString();
                objItem.ItemDescription2 = dr["ITEM_DESCRIPTION2"].ToString();
                objItem.ItemDescription3 = dr["ITEM_DESCRIPTION3"].ToString();
                objItem.ItemDescription4 = dr["ITEM_DESCRIPTION4"].ToString();

                if(objItem.SetCriticalLevel = Convert.ToBoolean(dr["ITEM_SETCRITICALLEVEL"]))
                {
                    string itemQuery = "SELECT * FROM itemdefinecriticallevel WHERE ITM_ID=" + id;
                    System.Data.IDataReader drCr = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                    objItem.ItemCriticalLevel = new List<DefineCriticalLevelModel>();
                    DefineCriticalLevelModel objCritical;

                    while (drCr.Read())
                    {
                        objCritical = new DefineCriticalLevelModel();
                        objCritical.DC_Id = Convert.ToInt32(drCr["DC_ID"]);
                        objCritical.ParentId = Convert.ToInt32(drCr["ITM_ID"]);

                        objCritical.MinimumLevelQty = Convert.ToDecimal(drCr["ITEM_MINIMUMLVLQTY"]);
                        objCritical.RecordLevelQty = Convert.ToDecimal(drCr["ITEM_RECORDLVLQTY"]);
                        objCritical.MaximumLevelQty = Convert.ToDecimal(drCr["ITEM_MAXIMUMLVLQTY"]);
                        objCritical.MinimumLevelDays = Convert.ToDecimal(drCr["ITEM_MINIMUMLVLDAYS"]);
                        objCritical.RecordLevelDays = Convert.ToDecimal(drCr["ITEM_RECORDLVLDAYS"]);
                        objCritical.MaximumLevelDays = Convert.ToDecimal(drCr["ITEM_MAXIMUMLVLDAYS"]);

                        objItem.ItemCriticalLevel.Add(objCritical);
                    }
                }

                objItem.MaintainRG23D = Convert.ToBoolean(dr["ITEM_MAINTAINRG23D"]);
                objItem.TariffHeading = dr["ITEM_TARIFHEADING"].ToString();
                if(objItem.SerialNumberwiseDetails = Convert.ToBoolean(dr["ITEM_SERIALWISEDETAILS"]))
                {
                    string itemQuery = "SELECT * FROM itemserialnowisedetails WHERE ITM_ID=" + id;
                    System.Data.IDataReader drSer = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                    objItem.ItemSerialNo = new List<ItemSerialnoDetailsModel>();
                    ItemSerialnoDetailsModel objSerial;

                    while (drSer.Read())
                    {
                        objSerial = new ItemSerialnoDetailsModel();
                        objSerial.SL_ID = Convert.ToInt32(drSer["SN_ID"]);
                        objSerial.parent_Id = Convert.ToInt32(drSer["ITM_ID"]);
                        objSerial.SerialNumber = Convert.ToInt32(drSer["ITEM_SERIALNO"]);
                        objSerial.Quantity = Convert.ToDecimal(drSer["ITEM_QUANTITY"]);
                        objSerial.Unit = drSer["ITEM_UNIT"].ToString();
                        objSerial.MRP = Convert.ToDecimal(drSer["ITEM_MRP"]);
                        objSerial.SalePrice = Convert.ToDecimal(drSer["ITEM_SALESPRICE"]);
                        objSerial.Costprice = Convert.ToDecimal(drSer["ITEM_COSTPRICE"]);
                        objSerial.Barcode = drSer["ITEM_BARCODE"].ToString();
                        objItem.ItemSerialNo.Add(objSerial);
                    }
                }
                if(objItem.MRPWiseDetails = Convert.ToBoolean(dr["ITEM_MRPWISEDETAILS"]))
                {
                    string itemQuery = "SELECT * FROM itemmrpwisedetails WHERE ITM_ID=" + id;
                    System.Data.IDataReader drMRP = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                    objItem.ItemMRPWise = new List<ItemMRPWiseDetailsModel>();
                    ItemMRPWiseDetailsModel objMRPWise;

                    while (drMRP.Read())
                    {
                        objMRPWise = new ItemMRPWiseDetailsModel();
                        objMRPWise.MRP_Id = Convert.ToInt32(drMRP["SL_ID"]);
                        objMRPWise.ParentId = Convert.ToInt32(drMRP["ITM_ID"]);
                        objMRPWise.Quantity = Convert.ToDecimal(drMRP["ITEM_QUANTITY"]);
                        objMRPWise.Unit = drMRP["ITEM_UNIT"].ToString();
                        objMRPWise.MRP = Convert.ToDecimal(drMRP["ITEM_MRP"]);
                        objMRPWise.SalesPrice = Convert.ToDecimal(drMRP["ITEM_SALESPRICE"]);
                        objMRPWise.Costprice = Convert.ToDecimal(drMRP["ITEM_COSTPRICE"]);
                        objMRPWise.Barcode =drMRP["ITEM_BARCODE"].ToString();
                        objItem.ItemMRPWise.Add(objMRPWise);
                    }
                }
                if(objItem.ParameterizedDetails = Convert.ToBoolean(dr["ITEM_PARAMETERIZEDDETAILS"]))
                {
                    string itemQuery = "SELECT * FROM itemparameterizeddetails WHERE ITM_ID=" + id;
                    System.Data.IDataReader drParm = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                    objItem.ItemParameterized = new List<ItemParameterizedModel>();
                    ItemParameterizedModel objParam;

                    while (drParm.Read())
                    {
                        objParam = new ItemParameterizedModel();
                        objParam.Param_Id = Convert.ToInt32(drParm["SL_NO"]);
                        objParam.Parent_Id = Convert.ToInt32(drParm["ITM_ID"]);
                        objParam.ItemName = drParm["ITEM_NAME"].ToString()==null?string.Empty: drParm["ITEM_NAME"].ToString();
                        objParam.Qty = Convert.ToInt32(drParm["ITEM_QTY"]);
                        objParam.Unit = drParm["ITEM_UNIT"].ToString();
                        objParam.MRP = Convert.ToDecimal(drParm["ITEM_MRP"]);
                        objParam.SalePrice = Convert.ToDecimal(drParm["ITEM_SALEPRICE"]);
                        objParam.Costprice = Convert.ToDecimal(drParm["ITEM_COSTPRICE"]);
                        objParam.Barcode = drParm["ITEM_BARCODE"].ToString();

                        objItem.ItemParameterized.Add(objParam);
                    }
                }
                string itemBarCodeQuery = "SELECT * FROM itembarcodes WHERE ITM_ID=" + id;
                System.Data.IDataReader drBar = _dbHelper.ExecuteDataReader(itemBarCodeQuery, _dbHelper.GetConnObject());

                objItem.ItemBarcode = new List<ItemAliasModel>();
                ItemAliasModel objBarcode;

                while (drBar.Read())
                {
                    objBarcode = new ItemAliasModel();
                    objBarcode.BarcodeId = Convert.ToInt32(drBar["SL_ID"]);
                    objBarcode.ParentId = Convert.ToInt32(drBar["ITM_ID"]);
                    objBarcode.Barcodes = drBar["ITEM_BARCODE"].ToString() == null ? string.Empty : drBar["ITEM_BARCODE"].ToString();

                    objItem.ItemBarcode.Add(objBarcode);
                }

                if (objItem.BatchwiseDetails = Convert.ToBoolean(dr["ITEM_BATCHWISEDETAILS"]))
                {
                    string itemQuery = "SELECT * FROM itembatchwisedetails WHERE ITM_ID=" + id;
                    System.Data.IDataReader drBt = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                    objItem.ItemBatchWise = new List<ItemBatchWiseDetailsModel>();
                    ItemBatchWiseDetailsModel objBatch;

                    while (drBt.Read())
                    {
                        objBatch = new ItemBatchWiseDetailsModel();
                        objBatch.Batch_Id = Convert.ToInt32(drBt["SL_NO"]);
                        objBatch.Parent_Id = Convert.ToInt32(drBt["ITM_ID"]);
                        objBatch.BatchNo = Convert.ToInt32(drBt["ITEM_BATCHNO"]);
                        objBatch.Qty = Convert.ToInt32(drBt["ITEM_QTY"]);
                        objBatch.Unit = drBt["ITEM_UNIT"].ToString();
                        objBatch.MRP = Convert.ToDecimal(drBt["ITEM_MRP"]);
                        objBatch.SalePrice = Convert.ToDecimal(drBt["ITEM_SALESPRICE"]);
                        objBatch.CostPrice = Convert.ToDecimal(drBt["ITEM_COSTPRICE"]);
                        objBatch.MfgDate = Convert.ToDateTime(drBt["ITEM_MFGDATE"]);
                        objBatch.Expdate = Convert.ToDateTime(drBt["ITEM_EXPDATE"]);
                        objBatch.Barcode = drBt["ITEM_BARCODE"].ToString();
                        objBatch.Narration = drBt["NARRATION"].ToString();
                        objItem.ItemBatchWise.Add(objBatch);
                    }
                }
                if(objItem.SpecifyDefaultMC = Convert.ToBoolean(dr["ITEM_SPECIFYDEFAULTMC"]))
                {
                    objItem.DefaultMaterialCenter = dr["ITEM_MATERIALCENTER"].ToString();
                    string itemQuery = "SELECT * FROM itemmaterialcenterdetails WHERE ITM_ID=" + id;
                    System.Data.IDataReader drMC = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());
                    objItem.ItemMC = new List<ItemMaterialCenterModel>();
                    ItemMaterialCenterModel objMatreial;
                    while (drMC.Read())
                    {
                        objMatreial = new ItemMaterialCenterModel();
                        objMatreial.MCId = Convert.ToInt32(drMC["MC_ID"]);
                        objMatreial.ParentId = Convert.ToInt32(drMC["ITM_ID"]);
                        objMatreial.Materialcenter = drMC["ITEM_MATERIALCENTER"].ToString();
                        objMatreial.Qty = Convert.ToDecimal(drMC["ITEM_QUANTITY"]);
                        objItem.ItemMC.Add(objMatreial);
                    }
               }
                objItem.ExpDateRequired = dr["ITEM_EXPDATEREQUIRED"].ToString();
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
            bool issaved = false;

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

                paramCollection.Add(new DBParameter("@ITEM_OPSTOCKVALUE", objItem.OpStockQty));
                paramCollection.Add(new DBParameter("@ITEM_UNIT", objItem.Unit));
                paramCollection.Add(new DBParameter("@ITEM_RATE", objItem.Rate));
                paramCollection.Add(new DBParameter("@ITEM_PER", objItem.Per));
                paramCollection.Add(new DBParameter("@ITEM_VALUE", objItem.OpStockValue));

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
                if (objItem.DiscountInfo)
                {
                    paramCollection.Add(new DBParameter("@ITEM_SALEDISCOUNT", objItem.SaleDiscount, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_PURCHASEDISCOUNT", objItem.PurDiscount, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_SALEDISCOUNTCOMP", objItem.SaleCompoundDiscount, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_PURCHASEDISCOUNTCOMP", objItem.PurCompoundDiscount, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_SpecifySaleDiscStructure", objItem.SpecifySaleDiscStructure, System.Data.DbType.Boolean));
                    paramCollection.Add(new DBParameter("@ITEM_SpecifyPurDiscStructure", objItem.SpecifyPurDiscStructure, System.Data.DbType.Boolean));
                    paramCollection.Add(new DBParameter("@ITEM_SaleDiscStructure", objItem.SaleDiscStructure));
                    paramCollection.Add(new DBParameter("@ITEM_PurcDiscStructure", objItem.PurcDiscStructure));
                }
                else
                {
                    paramCollection.Add(new DBParameter("@ITEM_SALEDISCOUNT", "0.00"));
                    paramCollection.Add(new DBParameter("@ITEM_PURCHASEDISCOUNT", "0.00"));
                    paramCollection.Add(new DBParameter("@ITEM_SALEDISCOUNTCOMP", "0.00"));
                    paramCollection.Add(new DBParameter("@ITEM_PURCHASEDISCOUNTCOMP", "0.00"));
                    paramCollection.Add(new DBParameter("@ITEM_SpecifySaleDiscStructure", false, System.Data.DbType.Boolean));
                    paramCollection.Add(new DBParameter("@ITEM_SpecifyPurDiscStructure", false, System.Data.DbType.Boolean));
                    paramCollection.Add(new DBParameter("@ITEM_SaleDiscStructure", String.Empty));
                    paramCollection.Add(new DBParameter("@ITEM_PurcDiscStructure", String.Empty));
                }
                paramCollection.Add(new DBParameter("@ITEM_MARKUPINFO", objItem.MarkupInfo, System.Data.DbType.Boolean));
                if (objItem.MarkupInfo)
                {
                    paramCollection.Add(new DBParameter("@ITEM_SaleMarkup", objItem.SaleMarkup, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_PurMarkup", objItem.PurMarkup, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_SaleCompMarkup", objItem.SaleCompMarkup, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_PurCompMarkup", objItem.PurCompMarkup, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ITEM_SpecifySaleMarkupStruct", objItem.SpecifySaleMarkupStruct, System.Data.DbType.Boolean));
                    paramCollection.Add(new DBParameter("@ITEM_SpecifyPurMarkupStruct", objItem.SpecifyPurMarkupStruct, System.Data.DbType.Boolean));
                    paramCollection.Add(new DBParameter("@ITEM_SaleMarkupStructure", objItem.SaleMarkupStructure));
                    paramCollection.Add(new DBParameter("@ITEM_PurcMarkupStructure", objItem.PurcMarkupStructure));
                }
                else
                {
                    paramCollection.Add(new DBParameter("@ITEM_SaleMarkup", "0.00"));
                    paramCollection.Add(new DBParameter("@ITEM_PurMarkup", "0.00"));
                    paramCollection.Add(new DBParameter("@ITEM_SaleCompMarkup", "0.00"));
                    paramCollection.Add(new DBParameter("@ITEM_PurCompMarkup", "0.00"));
                    paramCollection.Add(new DBParameter("@ITEM_SpecifySaleMarkupStruct", false, System.Data.DbType.Boolean));
                    paramCollection.Add(new DBParameter("@ITEM_SpecifyPurMarkupStruct", false, System.Data.DbType.Boolean));
                    paramCollection.Add(new DBParameter("@ITEM_SaleMarkupStructure", String.Empty));
                    paramCollection.Add(new DBParameter("@ITEM_PurcMarkupStructure", String.Empty));
                }

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
                paramCollection.Add(new DBParameter("@ITEM_EXPDATEREQUIRED", objItem.ExpDateRequired));

                paramCollection.Add(new DBParameter("@ITEM_EXPIRYDAYS", objItem.ExpiryDays));
                paramCollection.Add(new DBParameter("@ITEM_SALESACCOUNT", objItem.SalesAccount));
                paramCollection.Add(new DBParameter("@ITEM_PURCACCOUNT", objItem.PurcAccount));
                paramCollection.Add(new DBParameter("@ITEM_MAINTAINSTOCKBAL", objItem.DontMaintainStockBal, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ITEM_SPECIFYDEFAULTMC", objItem.SpecifyDefaultMC, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ITEM_MATERIALCENTER", objItem.DefaultMaterialCenter));
                paramCollection.Add(new DBParameter("@ITEM_FREEZEMCFORITEM", objItem.FreezeMCforItem, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ITEM_TOTALNUMBEROFAUTHORS", objItem.TotalNumberofAuthors));

                paramCollection.Add(new DBParameter("@ITEM_PICKITEMSIZEFROMDESC", objItem.PickItemSizefromDescription, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ITEM_SPECIFYDEFAULTVENDOR", objItem.SpecifyDefaultVendor, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@CreatedBy", objItem.CreatedBy));

                paramCollection.Add(new DBParameter("@ITEM_ID", objItem.ItemId));

                System.Data.IDataReader dr =
                               _dbHelper.ExecuteDataReader("spUpdateItemMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);

                UpdateItemBarcodes(objItem.ItemBarcode, objItem.ItemId);
                if (objItem.SetCriticalLevel)
                {
                    UpdateItemCriticalLevelDetails(objItem.ItemCriticalLevel, objItem.ItemId);
                }
                if (objItem.SerialNumberwiseDetails && objItem.OpStockValue.ToString() != "0.00")
                {
                    UpdateItemSerialNoWiseDetails(objItem.ItemSerialNo, objItem.ItemId);
                }
                if (objItem.ParameterizedDetails && objItem.OpStockValue.ToString() != "0.00")
                {
                    UpdateItemParameterizedDetails(objItem.ItemParameterized, objItem.ItemId);
                }
                if (objItem.MRPWiseDetails && objItem.OpStockValue.ToString() != "0.00")
                {
                    UpdateItemMRPWiseDetails(objItem.ItemMRPWise, objItem.ItemId);
                }
                if (objItem.BatchwiseDetails && objItem.OpStockValue.ToString() != "0.00")
                {
                    UpdateItemBatchWiseDetails(objItem.ItemBatchWise, objItem.ItemId);
                }
                if(objItem.SpecifyDefaultMC)
                {
                    UpdateItemMaterialCenterDetails(objItem.ItemMC, objItem.ItemId);
                }
            }
            catch(Exception ex)
            {
                issaved = false;
                throw ex;
            }
            return issaved = true;
        }

        //Update Critical Level Details
        public bool UpdateItemCriticalLevelDetails(List<DefineCriticalLevelModel> lstCritical, int id)
        {
            string Query = string.Empty;
            bool isUpdate = true;
            foreach (DefineCriticalLevelModel objCriti in lstCritical)
            {
                objCriti.ParentId = id;
                if (objCriti.DC_Id > 0)
                {                
                        DBParameterCollection paramCollection = new DBParameterCollection();

                        paramCollection.Add(new DBParameter("@Item_Id", objCriti.ParentId));
                        paramCollection.Add(new DBParameter("@DC_Id", objCriti.DC_Id));
                        paramCollection.Add(new DBParameter("@ITEM_MINIMUMLVLQTY", objCriti.MinimumLevelQty, System.Data.DbType.Decimal));
                        paramCollection.Add(new DBParameter("@ITEM_RECORDLVLQTY", objCriti.RecordLevelQty, System.Data.DbType.Decimal));
                        paramCollection.Add(new DBParameter("@ITEM_MAXIMUMLVLQTY", objCriti.MaximumLevelQty, System.Data.DbType.Decimal));
                        paramCollection.Add(new DBParameter("@ITEM_MINIMUMLVLDAYS", objCriti.MinimumLevelDays, System.Data.DbType.Decimal));
                        paramCollection.Add(new DBParameter("@ITEM_RECORDLVLDAYS", objCriti.RecordLevelDays, System.Data.DbType.Decimal));
                        paramCollection.Add(new DBParameter("@ITEM_MAXIMUMLVLDAYS", objCriti.MaximumLevelDays, System.Data.DbType.Decimal));

                        paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                        Query = "UPDATE itemdefinecriticallevel SET `ITEM_MINIMUMLVLQTY`=@ITEM_MINIMUMLVLQTY,`ITEM_RECORDLVLQTY`=@ITEM_RECORDLVLQTY,`ITEM_MAXIMUMLVLQTY`=@ITEM_MAXIMUMLVLQTY," +
                              "`ITEM_MINIMUMLVLDAYS`=@ITEM_MINIMUMLVLDAYS,`ITEM_RECORDLVLDAYS`=@ITEM_RECORDLVLDAYS,`ITEM_MAXIMUMLVLDAYS`=@ITEM_MAXIMUMLVLDAYS,`CreatedBy`=@CreatedBy " +
                              "WHERE `ITM_ID`=@Item_Id AND `DC_ID`=@DC_Id";

                    if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                    {
                        isUpdate = true;
                    }                   
                  
                }
                else
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
            }
            return isUpdate;
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
              objItem.OpStockQty = Convert.ToDouble(dr["ITEM_OPSTOCK"].ToString());
              objItem.Unit = dr["ITEM_UNIT"].ToString();             
              lstItems.Add(objItem);
          
          }
          return lstItems;

      }

        //Get Item Details By Name
        public List<ItemMasterModel> GetItemsByName(string itemname)
        {
            List<ItemMasterModel> lstItems = new List<ItemMasterModel>();
            ItemMasterModel objItem;

            string Query = string.Empty;

            Query = "SELECT * FROM itemmaster WHERE ITEM_Name='" + itemname + "'";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objItem = new eSunSpeedDomain.ItemMasterModel();
                objItem.Name = dr["ITEM_Name"].ToString();
                objItem.Alias = dr["ITEM_ALIAS"].ToString();

                objItem.Unit = dr["ITEM_UNIT"].ToString();
                objItem.MainUnit = dr["ITEM_MAINUNIT"].ToString();
                objItem.AltUnit = dr["ITEM_ALTUNIT"].ToString();
                lstItems.Add(objItem);
            }
            return lstItems;

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
                if (DeleteDefineCriticalLevels(id))
                {
                    if(DeleteSerialNoWiseDetails(id))
                    {
                        if(DeleteParameterizedDetails(id))
                       {
                            if(DeleteMRPWiseDetails(id))
                            {
                                if(DeleteBatchWiseDetails(id))
                                {
                                    if(DeleteItemMaterialCenterDetails(id))
                                    {
                                        if(DeleteItemSerialNoWiseDetails(id))
                                        {
                                            string Query = "DELETE FROM itemmaster WHERE ITM_ID=" + id;
                                            int rowes = _dbHelper.ExecuteNonQuery(Query);
                                            if (rowes > 0)
                                                isDelete = true;
                                        }
                                      
                                    }
                                }
                              
                            }
                            
                        }
                       
                    }
                   
                }                              
            }
            catch (Exception ex)
            {
                isDelete = false;
                throw ex;
            }
            return isDelete;
        }

        //Delete Criticle Level Details
        public bool DeleteDefineCriticalLevels(int id)
        {
            bool isDelete = true;
            try
            {
                string Query = "DELETE FROM `itemdefinecriticallevel` WHERE ITM_ID=" + id;
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
        //Delete Serial No Wise Details
        public bool DeleteSerialNoWiseDetails(int id)
        {
            bool isDelete = true;
            try
            {
                string Query = "DELETE FROM `itemserialnodetails` WHERE ITM_ID=" + id;
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
        //Delete Parameterized Details
        public bool DeleteParameterizedDetails(int id)
        {
            bool isDelete = true;
            try
            {
                string Query = "DELETE FROM `itemparameterizeddetails` WHERE ITM_ID=" + id;
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
        //Delete MRPWise Details
        public bool DeleteMRPWiseDetails(int id)
        {
            bool isDelete = true;
            try
            {
                string Query = "DELETE FROM `itemmrpwisedetails` WHERE ITM_ID=" + id;
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
        //Delete Batch Wise Details
        public bool DeleteBatchWiseDetails(int id)
        {
            bool isDelete = true;
            try
            {
                string Query = "DELETE FROM `itembatchwisedetails` WHERE ITM_ID=" + id;
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
        //Delete Item Serial No wise Details Grid
        public bool DeleteItemSerialNoWiseDetails(int id)
        {
            bool isDelete = true;
            try
            {
                string Query = "DELETE FROM `itemserialnowisedetails` WHERE ITM_ID=" + id;
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
        //Get Item Name By Item Company
        public ItemMasterModel GetItemNameByCompanyname(string companyname)
        {
            ItemMasterModel objItem = new ItemMasterModel();

            string Query = string.Empty;

            Query = "SELECT ITEM_Name FROM itemmaster WHERE ITEM_COMPANY='" + companyname + "'";
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
        //Save Item Material Center Details
        public bool SaveItemMaterialCenterDetails(List<ItemMaterialCenterModel> lstMC, int id)
        {
            string Query = string.Empty;
            bool isSaved = true;
            foreach (ItemMaterialCenterModel Material in lstMC)
            {
                Material.ParentId = id;
                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Item_Id", Material.ParentId));
                    paramCollection.Add(new DBParameter("@ITEM_MATERIALCENTER", Material.Materialcenter));
                    paramCollection.Add(new DBParameter("@ITEM_QUANTITY", Material.Qty));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertItemMaterialCenterDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }

        //Update Item Material Center Details
        public bool UpdateItemMaterialCenterDetails(List<ItemMaterialCenterModel> lstMC, int id)
        {
            string Query = string.Empty;
            bool isUpdate = true;
            foreach (ItemMaterialCenterModel Material in lstMC)
            {
                Material.ParentId = id;
                if (Material.MCId > 0)
                {


                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Item_Id", Material.ParentId));
                    paramCollection.Add(new DBParameter("@MC_Id", Material.MCId));
                    paramCollection.Add(new DBParameter("@ITEM_MATERIALCENTER", Material.Materialcenter));
                    paramCollection.Add(new DBParameter("@ITEM_QUANTITY", Material.Qty));
                    paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));

                    Query = "UPDATE itemmaterialcenterdetails SET `ITEM_MATERIALCENTER`=@ITEM_MATERIALCENTER," +
                           "`ITEM_QUANTITY`=@ITEM_QUANTITY,`ModifiedBy`=@ModifiedBy " +
                           "WHERE `ITM_ID`=@Item_Id AND `MC_Id`=@MC_Id";

                    if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                    {
                        isUpdate = true;
                    }

                }
                else
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Item_Id", Material.ParentId));
                    paramCollection.Add(new DBParameter("@ITEM_MATERIALCENTER", Material.Materialcenter));
                    paramCollection.Add(new DBParameter("@ITEM_QUANTITY", Material.Qty));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertItemMaterialCenterDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
            }
            return isUpdate = true;

        }
        //Delete Item Material Center Details
        public bool DeleteItemMaterialCenterDetails(int id)
        {
            bool isDelete = true;
            try
            {
                string Query = "DELETE FROM `itemmaterialcenterdetails` WHERE ITM_ID=" + id;
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
    }
}
