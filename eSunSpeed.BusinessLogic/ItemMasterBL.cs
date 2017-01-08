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
          string Query = string.Empty;

          DBParameterCollection paramCollection = new DBParameterCollection();
          
          paramCollection.Add(new DBParameter("@ITEM_Name", objItem.Name));
          paramCollection.Add(new DBParameter("@ITEM_PrintName", objItem.PrintName));
            paramCollection.Add(new DBParameter("@ITEM_ALIAS", objItem.Alias));
          paramCollection.Add(new DBParameter("@ITEM_GROUP", objItem.Group));
          paramCollection.Add(new DBParameter("@ITEM_COMPANY", objItem.Company));

          paramCollection.Add(new DBParameter("@ITEM_MAINUNIT", objItem.MainUnit));
          paramCollection.Add(new DBParameter("@ALT_UNIT", objItem.AltUnit));
          paramCollection.Add(new DBParameter("@ITEM_CONFACTOR", objItem.Confactor));
          paramCollection.Add(new DBParameter("@ITEM_OPSTOCKVALUE", objItem.OpStockValue));
            paramCollection.Add(new DBParameter("@ITEM_UNIT", objItem.Unit));
            paramCollection.Add(new DBParameter("@ITEM_RATE", objItem.Rate));
          paramCollection.Add(new DBParameter("@ITEM_PER",objItem.Per ));
          paramCollection.Add(new DBParameter("@ITEM_VALUE",objItem.Value ));

            paramCollection.Add(new DBParameter("@ITEM_APPLYSALEPRICE", objItem.ApplySalesPrice, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ITEM_APPLYPURCPRICE", objItem.ApplyPurchPrice, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ITEM_SALEPRICE", objItem.SalePrice));
            paramCollection.Add(new DBParameter("@ITEM_PURCEPRICE", objItem.Purprice));
            paramCollection.Add(new DBParameter("@ITEM_MRP", objItem.MRP));
            paramCollection.Add(new DBParameter("@ITEM_MINSALEPRICE", objItem.MinSalePrice));
            paramCollection.Add(new DBParameter("@ITEM_SELFVALUEPRICE", objItem.SelfValuePrice));
            paramCollection.Add(new DBParameter("@ITEM_SALEDISCOUNT", objItem.SaleDiscount));
            paramCollection.Add(new DBParameter("@ITEM_PURCHASEDISCOUNT", objItem.PurDiscount));
            paramCollection.Add(new DBParameter("@ITEM_SpecifySaleDiscStructure", objItem.SpecifySaleDiscStructure,System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ITEM_SpecifyPurDiscStructure", objItem.SpecifyPurDiscStructure, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ITEM_StockValMethod", objItem.StockValMethod ));

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

          //  paramCollection.Add(new DBParameter("@ITEM_SALECOMPMARKUP", objItem.SaleCompMarkup ));
          //paramCollection.Add(new DBParameter("@ITEM_PURCOMPMARKUP",objItem.PurCompMarkup ));
          //paramCollection.Add(new DBParameter("@ITEM_SPECIFYSALEMARKUPSTRUCT", objItem.SpecifySaleMarkupStruct, System.Data.DbType.Boolean));
           //paramCollection.Add(new DBParameter("@ITEM_SPECIFYPURMARKUPSTRUCT", objItem.SpecifyPurMarkupStruct, System.Data.DbType.Boolean));
          //paramCollection.Add(new DBParameter("@ITEM_TAXTYPE",objItem.TaxType ));
          //paramCollection.Add(new DBParameter("@ITEM_SERVICETAXRATE",objItem.ServiceTaxRate ));
          //paramCollection.Add(new DBParameter("@ITEM_LOCALTAX", objItem.RateofTax_Central ));
          //paramCollection.Add(new DBParameter("@ITEM_CENTRALTAX", objItem.RateofTax_Central ));
          //paramCollection.Add(new DBParameter("@ITEM_TAXONMRP", objItem.TaxonMRP, System.Data.DbType.Boolean));

          //paramCollection.Add(new DBParameter("@ITEM_HSNCODE", objItem.HSNCode));        
          
            Query =
                    "INSERT INTO itemmaster(`ITEM_Name`,`ITEM_PRINTName`,`ITEM_ALIAS`,`ITEM_GROUP`,`ITEM_COMPANY`," +
                    "`ITEM_MAINUNIT`,`ITEM_ALTUNIT`,`ITEM_CONFACTOR`,`ITEM_OPSTOCK`,`ITEM_UNIT`,`ITEM_RATE`,`ITEM_PER`,`ITEM_VALUE`,`ITEM_SALEPRICETOAPPLY`,`ITEM_PURCPRICETOAPPLY`,`ITEM_SALEPRICE`," +
                          "`ITEM_PURCHASEPRICE`,`ITEM_MRP`,`ITEM_MINSALEPRICE`,`ITEM_SELFVALUEPRICE`,`ITEM_SALEDISCOUNT`,`ITEM_PURCHASEDISCOUNT`," +
                          "`ITEM_SPECIFYSALEDISCSTRUCT`,`ITEM_SPECIFYPURDISCSTRUCT`,`ITEM_STOCKVALMETHOD`," +
                          "`ITEM_TAXCATEGORY`,`ITEM_DESCRIPTION1`,`ITEM_DESCRIPTION2`,`ITEM_DESCRIPTION3`,`ITEM_DESCRIPTION4`," +
                          "`ITEM_SETCRITICALLEVEL`,`ITEM_MAINTAINRG23D`,`ITEM_TARIFHEADING`,`ITEM_SERIALWISEDETAILS`,`ITEM_PARAMETERIZEDDETAILS`,`ITEM_MRPWISEDETAILS`," +
                          "`ITEM_BATCHWISEDETAILS`,`ITEM_EXPDATEREQUIRED`,`ITEM_EXPIRYDAYS`,`ITEM_SALESACCOUNT`,`ITEM_PURCACCOUNT`,`ITEM_MAINTAINSTOCKBAL`,`ITEM_SPECIFYDEFAULTMC`," +
                          "`ITEM_FREEZEMCFORITEM`,`ITEM_TOTALNUMBEROFAUTHORS`,`ITEM_PICKITEMSIZEFROMDESC`,`ITEM_SPECIFYDEFAULTVENDOR`,`CreatedBy`)" +
                          "VALUES"+
                          "(@ITEM_Name,@ITEM_PrintName,@ITEM_ALIAS,@ITEM_GROUP,@ITEM_COMPANY,@ITEM_MAINUNIT,@ALT_UNIT,@ITEM_CONFACTOR,@ITEM_OPSTOCKVALUE,@ITEM_UNIT,@ITEM_RATE,@ITEM_PER,@ITEM_VALUE,@ITEM_APPLYSALEPRICE,@ITEM_APPLYPURCPRICE,@ITEM_SALEPRICE," +
                          "@ITEM_PURCEPRICE,@ITEM_MRP," + 
                          "@ITEM_MINSALEPRICE,@ITEM_SELFVALUEPRICE,@ITEM_SALEDISCOUNT,@ITEM_PURCHASEDISCOUNT," +
                          "@ITEM_SpecifySaleDiscStructure,@ITEM_SpecifyPurDiscStructure,@ITEM_StockValMethod," +
                          "@ITEM_TAXCATEGORY,@ITEM_DESCRIPTION1," +
                          "@ITEM_DESCRIPTION2,@ITEM_DESCRIPTION3,@ITEM_DESCRIPTION4,@ITEM_SETCRITICALLEVEL,@ITEM_MAINTAINRG23D,@ITEM_TARIFHEADING,@ITEM_SERIALWISEDETAILS," +
                          "@ITEM_PARAMETERIZEDDETAILS,@ITEM_MRPWISEDETAILS,@ITEM_BATCHWISEDETAILS,@ITEM_EXPDATEREQUIRED,@ITEM_EXPIRYDAYS,@ITEM_SALESACCOUNT,@ITEM_PURCACCOUNT,@ITEM_MAINTAINSTOCKBAL,@ITEM_SPECIFYDEFAULTMC,@ITEM_FREEZEMCFORITEM,@ITEM_TOTALNUMBEROFAUTHORS,@ITEM_PICKITEMSIZEFROMDESC,@ITEM_SPECIFYDEFAULTVENDOR,@CreatedBy)";

          return _dbHelper.ExecuteNonQuery(Query, paramCollection) > 0;                    
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
                objItem.Confactor =Convert.ToInt32(dr["ITEM_CONFACTOR"].ToString());
                objItem.OpStockQty =Convert.ToDouble(dr["ITEM_OPSTOCK"].ToString());
                objItem.Unit = dr["ITEM_UNIT"].ToString();
                objItem.Rate =Convert.ToDouble(dr["ITEM_RATE"].ToString());
                objItem.Per = dr["ITEM_PER"].ToString();
                objItem.Value =Convert.ToDouble( dr["ITEM_VALUE"].ToString());
                objItem.ApplySalesPrice = Convert.ToBoolean(dr["ITEM_SALEPRICETOAPPLY"]);
                objItem.ApplyPurchPrice = Convert.ToBoolean(dr["ITEM_PURCPRICETOAPPLY"]);

                objItem.SalePrice =Convert.ToDouble(dr["ITEM_SALEPRICE"].ToString());
                objItem.Purprice = Convert.ToDouble(dr["ITEM_PURCHASEPRICE"].ToString());
                objItem.MRP = Convert.ToDouble(dr["ITEM_MRP"].ToString());
                objItem.MinSalePrice = Convert.ToDouble(dr["ITEM_MINSALEPRICE"].ToString());
                objItem.SelfValuePrice = Convert.ToDouble(dr["ITEM_SELFVALUEPRICE"].ToString());
                objItem.SaleDiscount = Convert.ToDouble(dr["ITEM_SALEDISCOUNT"].ToString());
                objItem.PurDiscount = Convert.ToDouble(dr["ITEM_PURCHASEDISCOUNT"].ToString());

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
            paramCollection.Add(new DBParameter("@ITEM_CONFACTOR", objItem.Confactor));
            paramCollection.Add(new DBParameter("@ITEM_OPSTOCKVALUE", objItem.OpStockValue));
            paramCollection.Add(new DBParameter("@ITEM_UNIT", objItem.Unit));
            paramCollection.Add(new DBParameter("@ITEM_RATE", objItem.Rate));
            paramCollection.Add(new DBParameter("@ITEM_PER", objItem.Per));
            paramCollection.Add(new DBParameter("@ITEM_VALUE", objItem.Value));

            paramCollection.Add(new DBParameter("@ITEM_APPLYSALEPRICE", objItem.ApplySalesPrice, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ITEM_APPLYPURCPRICE", objItem.ApplyPurchPrice, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ITEM_SALEPRICE", objItem.SalePrice));
            paramCollection.Add(new DBParameter("@ITEM_PURCEPRICE", objItem.Purprice));
            paramCollection.Add(new DBParameter("@ITEM_MRP", objItem.MRP));
            paramCollection.Add(new DBParameter("@ITEM_MINSALEPRICE", objItem.MinSalePrice));
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
                objItem.SalePrice = Convert.ToDouble(dr["ITEM_SALEPRICE"]);

                objItem.MRP = Convert.ToDouble(dr["ITEM_MRP"]);
                objItem.MinSalePrice = Convert.ToDouble(dr["ITEM_MINSALEPRICE"]);
                objItem.SelfValuePrice = Convert.ToDouble(dr["ITEM_SELFVALUEPRICE"]);
                objItem.SaleDiscount = Convert.ToDouble(dr["ITEM_SALEDISCOUNT"]);
                               
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
