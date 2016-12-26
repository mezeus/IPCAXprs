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
        //Save
      public bool SaveItemMaster(ItemMasterModel objItem)
      {
          string Query = string.Empty;

          DBParameterCollection paramCollection = new DBParameterCollection();
          
          paramCollection.Add(new DBParameter("@ITEM_Name", objItem.Name));
          paramCollection.Add(new DBParameter("@ITEM_ALIAS", objItem.Alias));
          paramCollection.Add(new DBParameter("@ITEM_GROUP", objItem.Group));          
          paramCollection.Add(new DBParameter("@ITEM_UNIT", objItem.Unit));

          paramCollection.Add(new DBParameter("@ITEM_OPSTOCKQTY", objItem.OpStockQty));
          paramCollection.Add(new DBParameter("@ITEM_OPSTOCKVALUE", objItem.OpStockValue));
          paramCollection.Add(new DBParameter("@ITEM_SALEPRICE", objItem.SalePrice));
          paramCollection.Add(new DBParameter("@ITEM_PURCHASEPRICE",objItem.Purprice ));
          paramCollection.Add(new DBParameter("@ITEM_MRP",objItem.MRP ));


          paramCollection.Add(new DBParameter("@ITEM_MINSALEPRICE",objItem.MinSalePrice ));
          paramCollection.Add(new DBParameter("@ITEM_SELFVALUEPRICE",objItem.SelfValuePrice ));
          paramCollection.Add(new DBParameter("@ITEM_SALEDISCOUNT",objItem.SaleDiscount ));
          paramCollection.Add(new DBParameter("@ITEM_PURCHASEDISCOUNT",objItem.PurDiscount ));
          paramCollection.Add(new DBParameter("@ITEM_SALECOMPDISCOUNT", objItem.SaleCompoundDiscount ));

          paramCollection.Add(new DBParameter("@ITEM_PURCHCOMPDISCOUNT", objItem.PurCompoundDiscount ));
          paramCollection.Add(new DBParameter("@ITEM_SPECIFYSALEDISCSTRUCT", objItem.SpecifySaleDiscStructure,System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@ITEM_SPECIFYPURDISCSTRUCT", objItem.SpecifyPurDiscStructure, System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@ITEM_SALEMARKUP",objItem.SaleMarkup ));
          paramCollection.Add(new DBParameter("@ITEM_PURMARKUP",objItem.PurMarkup ));

          paramCollection.Add(new DBParameter("@ITEM_SALECOMPMARKUP", objItem.SaleCompMarkup ));
          paramCollection.Add(new DBParameter("@ITEM_PURCOMPMARKUP",objItem.PurCompMarkup ));
          paramCollection.Add(new DBParameter("@ITEM_SPECIFYSALEMARKUPSTRUCT", objItem.SpecifySaleMarkupStruct, System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@ITEM_SPECIFYPURMARKUPSTRUCT", objItem.SpecifyPurMarkupStruct, System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@ITEM_TAXCATEGORY",objItem.TaxCategory ));

          paramCollection.Add(new DBParameter("@ITEM_TAXTYPE",objItem.TaxType ));
          paramCollection.Add(new DBParameter("@ITEM_SERVICETAXRATE",objItem.ServiceTaxRate ));
          paramCollection.Add(new DBParameter("@ITEM_LOCALTAX", objItem.RateofTax_Central ));
          paramCollection.Add(new DBParameter("@ITEM_CENTRALTAX", objItem.RateofTax_Central ));
          paramCollection.Add(new DBParameter("@ITEM_TAXONMRP", objItem.TaxonMRP, System.Data.DbType.Boolean));

          paramCollection.Add(new DBParameter("@ITEM_HSNCODE", objItem.HSNCode));
          paramCollection.Add(new DBParameter("@ITEM_DESCRIPTION1",objItem.ItemDescription1 ));
          paramCollection.Add(new DBParameter("@ITEM_DESCRIPTION2",objItem.ItemDescription2 ));
          paramCollection.Add(new DBParameter("@ITEM_DESCRIPTION3",objItem.ItemDescription3 ));
          
          paramCollection.Add(new DBParameter("@ITEM_SETCRITICALLEVEL", objItem.SetCriticalLevel, System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@ITEM_MAINTAINRG23D", objItem.MaintainRG23D, System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@ITEM_TARIFHEADING", objItem.TariffHeading ));

          paramCollection.Add(new DBParameter("@ITEM_SERIALWISEDETAILS", objItem.SerialNumberwiseDetails, System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@ITEM_MRPWISEDETAILS", objItem.MRPWiseDetails, System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@ITEM_PARAMETERIZEDDETAILS", objItem.ParameterizedDetails, System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@ITEM_BATCHWISEDETAILS", objItem.BatchwiseDetails, System.Data.DbType.Boolean));

          paramCollection.Add(new DBParameter("@ITEM_EXPDATEREQUIRED", objItem.ExpDateRequired, System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@ITEM_EXPIRYDAYS",objItem.ExpiryDays));
          paramCollection.Add(new DBParameter("@ITEM_SALESACCOUNT",objItem.SalesAccount));
          paramCollection.Add(new DBParameter("@ITEM_PURCACCOUNT", objItem.PurcAccount));

          paramCollection.Add(new DBParameter("@ITEM_SPECIFYDEFAULTMC", objItem.SpecifyDefaultMC, System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@ITEM_FREEZEMCFORITEM", objItem.FreezeMCforItem, System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@ITEM_TOTALNUMBEROFAUTHORS",objItem.TotalNumberofAuthors ));
          paramCollection.Add(new DBParameter("@ITEM_MAINTAINSTOCKBAL", objItem.DontMaintainStockBal, System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@ITEM_PICKITEMSIZEFROMDESC", objItem.PickItemSizefromDescription, System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@ITEM_SPECIFYDEFAULTVENDOR", objItem.SpecifyDefaultVendor, System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@CreatedBy", objItem.CreatedBy));

            Query =
                    "INSERT INTO ITEM_MASTER(`ITEM_Name`,`ITEM_ALIAS`,`ITEM_GROUP`,`ITEM_UNIT`,`ITEM_OPSTOCKQTY`,`ITEM_OPSTOCKVALUE`,`ITEM_SALEPRICE`," +
                          "`ITEM_PURCHASEPRICE`,`ITEM_MRP`,`ITEM_MINSALEPRICE`,`ITEM_SELFVALUEPRICE`,`ITEM_SALEDISCOUNT`,`ITEM_PURCHASEDISCOUNT`,`ITEM_SALECOMPDISCOUNT`,`ITEM_PURCHCOMPDISCOUNT`," +
                          "`ITEM_SPECIFYSALEDISCSTRUCT`,`ITEM_SPECIFYPURDISCSTRUCT`,`ITEM_SALEMARKUP`,`ITEM_PURMARKUP`,`ITEM_SALECOMPMARKUP`,`ITEM_PURCOMPMARKUP`,`ITEM_SPECIFYSALEMARKUPSTRUCT`," +
                          "`ITEM_SPECIFYPURMARKUPSTRUCT`,`ITEM_TAXCATEGORY`,`ITEM_TAXTYPE`,`ITEM_SERVICETAXRATE`,`ITEM_LOCALTAX`,`ITEM_CENTRALTAX`,`ITEM_TAXONMRP`,`ITEM_HSNCODE`,`ITEM_DESCRIPTION1`,`ITEM_DESCRIPTION2`," +
                          "`ITEM_DESCRIPTION3`,`ITEM_SETCRITICALLEVEL`,`ITEM_MAINTAINRG23D`,`ITEM_TARIFHEADING`,`ITEM_SERIALWISEDETAILS`,`ITEM_MRPWISEDETAILS`," +
                          "`ITEM_PARAMETERIZEDDETAILS`,`ITEM_BATCHWISEDETAILS`,`ITEM_EXPDATEREQUIRED`,`ITEM_EXPIRYDAYS`,`ITEM_SALESACCOUNT`,`ITEM_PURCACCOUNT`,`ITEM_SPECIFYDEFAULTMC`," +
                          "`ITEM_FREEZEMCFORITEM`,`ITEM_TOTALNUMBEROFAUTHORS`,`ITEM_MAINTAINSTOCKBAL`,`ITEM_PICKITEMSIZEFROMDESC`,`ITEM_SPECIFYDEFAULTVENDOR`,`CreatedBy`)" +
                          "VALUES"+
                          "(@ITEM_Name,@ITEM_ALIAS,@ITEM_GROUP,@ITEM_UNIT,@ITEM_OPSTOCKQTY,@ITEM_OPSTOCKVALUE,@ITEM_SALEPRICE,@ITEM_PURCHASEPRICE,@ITEM_MRP," +
                          "@ITEM_MINSALEPRICE,@ITEM_SELFVALUEPRICE,@ITEM_SALEDISCOUNT,@ITEM_PURCHASEDISCOUNT,@ITEM_SALECOMPDISCOUNT,@ITEM_PURCHCOMPDISCOUNT," +
                          "@ITEM_SPECIFYSALEDISCSTRUCTURE,@ITEM_SPECIFYPURDISCSTRUCTURE,@ITEM_SALEMARKUP,@ITEM_PURMARKUP,@ITEM_SALECOMPMARKUP,@ITEM_PURCOMPMARKUP,@ITEM_SPECIFYSALEMARKUPSTRUCT," +
                          "@ITEM_SPECIFYPURMARKUPSTRUCT,@ITEM_TAXCATEGORY,@ITEM_TAXTYPE,@ITEM_SERVICETAXRATE,@ITEM_LOCALTAX,@ITEM_CENTRALTAX,@ITEM_TAXONMRP,@ITEM_HSNCODE,@ITEM_DESCRIPTION1," +
                          "@ITEM_DESCRIPTION2,@ITEM_DESCRIPTION3,@ITEM_SETCRITICALLEVEL,@ITEM_MAINTAINRG23D,@ITEM_TARIFHEADING,@ITEM_SERIALNUMBERWISEDETAILS," +
                          "@ITEM_MRPWISEDETAILS,@ITEM_PARAMETERIZEDDETAILS,@ITEM_BATCHWISEDETAILS,@ITEM_EXPDATEREQUIRED,@ITEM_EXPIRYDAYS,@ITEM_SALESACCOUNT,@ITEM_PURCACCOUNT,@ITEM_SPECIFYDEFAULTMC,@ITEM_FREEZEMCFORITEM,@ITEM_TOTALNUMBEROFAUTHORS,@ITEM_MAINTAINSTOCKBAL,@ITEM_PICKITEMSIZEFROMDESC,@ITEM_SPECIFYDEFAULTVENDOR,@CreatedBy)";

          return _dbHelper.ExecuteNonQuery(Query, paramCollection) > 0;
                    
      }
        //Update
      public bool UpdateItemMaster(eSunSpeedDomain.ItemMasterModel objItem)
      {
          string Query = string.Empty;

          DBParameterCollection paramCollection = new DBParameterCollection();

          paramCollection.Add(new DBParameter("@ITEM_Name", objItem.Name));
          paramCollection.Add(new DBParameter("@ITEM_ALIAS", objItem.Alias));
          paramCollection.Add(new DBParameter("@ITEM_GROUP", objItem.Group));
          paramCollection.Add(new DBParameter("@ITEM_PRINTNAME", objItem.PrintName));
          paramCollection.Add(new DBParameter("@ITEM_UNIT", objItem.Unit));

          paramCollection.Add(new DBParameter("@ITEM_OPENINGSTOCKQTY", objItem.OpStockQty));
          paramCollection.Add(new DBParameter("@ITEM_OPENINGSTOCKVALUE", objItem.OpStockValue));
          paramCollection.Add(new DBParameter("@ITEM_SALEPRICE", objItem.SalePrice));
          paramCollection.Add(new DBParameter("@ITEM_PURCHASEPRICE", objItem.Purprice));
          paramCollection.Add(new DBParameter("@ITEM_MRP", objItem.MRP));


          paramCollection.Add(new DBParameter("@ITEM_MINSALEPRICE", objItem.MinSalePrice));
          paramCollection.Add(new DBParameter("@ITEM_SELFVALUEPRICE", objItem.SelfValuePrice));
          paramCollection.Add(new DBParameter("@ITEM_SALEDISCOUNT", objItem.SaleDiscount));
          paramCollection.Add(new DBParameter("@ITEM_PURCHASEDISCOUNT", objItem.PurDiscount));
          paramCollection.Add(new DBParameter("@ITEM_SALECOMPOUNDDISCOUNT", objItem.SaleCompoundDiscount));

          paramCollection.Add(new DBParameter("@ITEM_PURCHASECOMPOUNDDISCOUNT", objItem.PurCompoundDiscount));
          paramCollection.Add(new DBParameter("@ITEM_SPECIFYSALEDISCSTRUCTURE", objItem.SpecifySaleDiscStructure, System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@ITEM_SPECIFYPURDISCSTRUCTURE", objItem.SpecifyPurDiscStructure, System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@ITEM_SALEMARKUP", objItem.SaleMarkup));
          paramCollection.Add(new DBParameter("@ITEM_PURMARKUP", objItem.PurMarkup));

          paramCollection.Add(new DBParameter("@ITEM_SALECOMPMARKUP", objItem.SaleCompMarkup));
          paramCollection.Add(new DBParameter("@ITEM_PURCOMPMARKUP", objItem.PurCompMarkup));
          paramCollection.Add(new DBParameter("@ITEM_SPECIFYSALEMARKUPPSTRUCTURE", objItem.SpecifySaleMarkupStruct, System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@ITEM_SPECIFYPURMPARKUPSTRUCTURE", objItem.SpecifyPurMarkupStruct, System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@ITEM_TAXCATEGORY", objItem.TaxCategory));

          paramCollection.Add(new DBParameter("@ITEM_TAXTYPE", objItem.TaxType));
          paramCollection.Add(new DBParameter("@ITEM_SERVICETAXRATE", objItem.ServiceTaxRate));
          paramCollection.Add(new DBParameter("@ITEM_RATEOFTAX_LOCAL", objItem.RateofTax_Central));
          paramCollection.Add(new DBParameter("@ITEM_RETEOFTAX_CENTRAL", objItem.RateofTax_Central));
          paramCollection.Add(new DBParameter("@ITEM_TAXONMRP", objItem.TaxonMRP, System.Data.DbType.Boolean));

          paramCollection.Add(new DBParameter("@ITEM_HSNCODE", objItem.HSNCode));
          paramCollection.Add(new DBParameter("@ITEM_DESCRIPTION1", objItem.ItemDescription1));
          paramCollection.Add(new DBParameter("@ITEM_DESCRIPTION2", objItem.ItemDescription2));
          paramCollection.Add(new DBParameter("@ITEM_DESCRIPTION3", objItem.ItemDescription3));
          paramCollection.Add(new DBParameter("@ITEM_DESCRIPTION4", objItem.ItemDescription4));

          paramCollection.Add(new DBParameter("@ITEM_DESCRIPTION5", objItem.ItemDescription5));
          paramCollection.Add(new DBParameter("@ITEM_DESCRIPTION6", objItem.ItemDescription6));
          paramCollection.Add(new DBParameter("@ITEM_SETCRITICALLEVEL", objItem.SetCriticalLevel, System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@ITEM_MAINTAINRG23D", objItem.MaintainRG23D, System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@ITEM_TARIFHEDING", objItem.TariffHeading));

          paramCollection.Add(new DBParameter("@ITEM_SERIALNUMBERWISEDETAILS", objItem.SerialNumberwiseDetails, System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@ITEM_MRPWISEDETAILS", objItem.MRPWiseDetails, System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@ITEM_PARAMETERIZEDDETAILS", objItem.ParameterizedDetails, System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@ITEM_BATCHWISEDETAILS", objItem.BatchwiseDetails, System.Data.DbType.Boolean));

          paramCollection.Add(new DBParameter("@ITEM_EXPDATEREQUIRED", objItem.ExpDateRequired, System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@ITEM_EXPIRYDAYS", objItem.ExpiryDays));
          paramCollection.Add(new DBParameter("@ITEM_SALESACCOUNT", objItem.SalesAccount));
          paramCollection.Add(new DBParameter("@ITEM_PURCACCOUNT", objItem.PurcAccount));

          paramCollection.Add(new DBParameter("@ITEM_SPECIFYDEFULTMC", objItem.SpecifyDefaultMC, System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@ITEM_FREEZEMCFORITEM", objItem.FreezeMCforItem, System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@ITEM_TOTALNUMBEROFAUTHORS", objItem.TotalNumberofAuthors));
          paramCollection.Add(new DBParameter("@ITEM_DONTMAINTAINSTOCKBAL", objItem.DontMaintainStockBal, System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@ITEM_PICKITEMSIZEFROMDESCRIPTION", objItem.PickItemSizefromDescription, System.Data.DbType.Boolean));
          paramCollection.Add(new DBParameter("@ITEM_SPECIFYDEFAULTVENDOR", objItem.SpecifyDefaultVendor, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
          paramCollection.Add(new DBParameter("@ITEM_ID", objItem.ItemId));

          Query = "UPDATE ITEM_MASTER SET [ITEM_NAME]=@ITEM_Name,[ITEM_ALIAS]=@ITEM_ALIAS,[ITEM_GROUP]=@ITEM_GROUP,[ITEM_PRINTNAME]=@ITEM_PRINTNAME," +
              "[ITEM_UNIT]=@ITEM_UNIT,[ITEM_OPENINGSTOCKQTY]=@ITEM_OPENINGSTOCKQTY,[ITEM_OPENINGSTOCKVALUE]=@ITEM_OPENINGSTOCKVALUE, " +
              "[ITEM_SALEPRICE]=@ITEM_SALEPRICE,[ITEM_PURCHASEPRICE]=@ITEM_PURCHASEPRICE,[ITEM_MRP]=@ITEM_MRP,[ITEM_MINSALEPRICE]=@ITEM_MINSALEPRICE,"+
              "[ITEM_SELFVALUEPRICE]=@ITEM_SELFVALUEPRICE,[ITEM_SALEDISCOUNT]=@ITEM_SALEDISCOUNT,[ITEM_PURCHASEDISCOUNT]=@ITEM_PURCHASEDISCOUNT,"+
              "[ITEM_SALECOMPOUNDDISCOUNT]=@ITEM_SALECOMPOUNDDISCOUNT,[ITEM_PURCHASECOMPOUNDDISCOUNT]=@ITEM_PURCHASECOMPOUNDDISCOUNT," +
              "[ITEM_SPECIFYSALEDISCSTRUCTURE]=@ITEM_SPECIFYSALEDISCSTRUCTURE,[ITEM_SPECIFYPURDISCSTRUCTURE]=@ITEM_SPECIFYPURDISCSTRUCTURE,"+
              "[ITEM_SALEMARKUP]=@ITEM_SALEMARKUP,[ITEM_PURMARKUP]=@ITEM_PURMARKUP,[ITEM_SALECOMPMARKUP]=@ITEM_SALECOMPMARKUP,"+
              "[ITEM_PURCOMPMARKUP]=@ITEM_PURCOMPMARKUP,[ITEM_SPECIFYSALEMARKUPPSTRUCTURE]=@ITEM_SPECIFYSALEMARKUPPSTRUCTURE," +
              "[ITEM_SPECIFYPURMPARKUPSTRUCTURE]=@ITEM_SPECIFYPURMPARKUPSTRUCTURE,[ITEM_TAXCATEGORY]=@ITEM_TAXCATEGORY,[ITEM_TAXTYPE]=@ITEM_TAXTYPE,"+
              "[ITEM_SERVICETAXRATE]=@ITEM_SERVICETAXRATE,[ITEM_RATEOFTAX_LOCAL]=@ITEM_RATEOFTAX_LOCAL,[ITEM_RETEOFTAX_CENTRAL]=@ITEM_RETEOFTAX_CENTRAL,"+
              "[ITEM_TAXONMRP]=@ITEM_TAXONMRP,[ITEM_HSNCODE]=@ITEM_HSNCODE,[ITEM_DESCRIPTION1]=@ITEM_DESCRIPTION1,[ITEM_DESCRIPTION2]=@ITEM_DESCRIPTION2," +
              "[ITEM_DESCRIPTION3]=@ITEM_DESCRIPTION3,[ITEM_DESCRIPTION4]=@ITEM_DESCRIPTION4,[ITEM_DESCRIPTION5]=@ITEM_DESCRIPTION5,[ITEM_DESCRIPTION6]=@ITEM_DESCRIPTION6,"+
              "[ITEM_SETCRITICALLEVEL]=@ITEM_SETCRITICALLEVEL,[ITEM_MAINTAINRG23D]=@ITEM_MAINTAINRG23D,[ITEM_TARIFHEDING]=@ITEM_TARIFHEDING,"+
              "[ITEM_SERIALNUMBERWISEDETAILS]=@ITEM_SERIALNUMBERWISEDETAILS,[ITEM_MRPWISEDETAILS]=@ITEM_MRPWISEDETAILS," +
              "[ITEM_PARAMETERIZEDDETAILS]=@ITEM_PARAMETERIZEDDETAILS,[ITEM_BATCHWISEDETAILS]=@ITEM_BATCHWISEDETAILS,[ITEM_EXPDATEREQUIRED]=@ITEM_EXPDATEREQUIRED,"+
              "[ITEM_EXPIRYDAYS]=@ITEM_EXPIRYDAYS,[ITEM_SALESACCOUNT]=@ITEM_SALESACCOUNT,[ITEM_PURCACCOUNT]=@ITEM_PURCACCOUNT,[ITEM_SPECIFYDEFULTMC]=@ITEM_SPECIFYDEFULTMC," +
              "[ITEM_FREEZEMCFORITEM]=@ITEM_FREEZEMCFORITEM,[ITEM_TOTALNUMBEROFAUTHORS]=@ITEM_TOTALNUMBEROFAUTHORS,[ITEM_DONTMAINTAINSTOCKBAL]=@ITEM_DONTMAINTAINSTOCKBAL,"+
              "[ITEM_PICKITEMSIZEFROMDESCRIPTION]=@ITEM_PICKITEMSIZEFROMDESCRIPTION,[ITEM_SPECIFYDEFAULTVENDOR]=@ITEM_SPECIFYDEFAULTVENDOR,[CREATEDBY]=@CreatedBy " +
              "WHERE [ITM_ID]=@ITEM_ID";        

          return _dbHelper.ExecuteNonQuery(Query, paramCollection) > 0;

      }
        //List
      public List<ItemMasterModel> GetAllItems()
      {
          List<ItemMasterModel> lstItems = new List<ItemMasterModel>();
          ItemMasterModel objItem;

          string Query = string.Empty;

          Query = "SELECT * FROM ITEM_MASTER";
          System.Data.IDataReader dr= _dbHelper.ExecuteDataReader(Query,_dbHelper.GetConnObject());

          while (dr.Read())
          {
              objItem = new eSunSpeedDomain.ItemMasterModel();
                objItem.ItemId = Convert.ToInt32(dr["ITM_ID"]);
              objItem.Name = dr["ITEM_Name"].ToString();
              objItem.Alias = dr["ITEM_ALIAS"].ToString();

              objItem.Group = dr["ITEM_GROUP"].ToString();
              objItem.PrintName = dr["ITEM_PRINTNAME"].ToString();
              objItem.Unit = dr["ITEM_UNIT"].ToString();
              objItem.OpStockQty = Convert.ToDouble(dr["ITEM_OPSTOCKQTY"]);
              objItem.OpStockValue = Convert.ToDouble(dr["ITEM_OPSTOCKVALUE"]);
              objItem.SalePrice = Convert.ToDouble(dr["ITEM_SALEPRICE"]);
              objItem.Purprice = Convert.ToDouble(dr["ITEM_PURCHASEPRICE"]);
              objItem.MRP = Convert.ToDouble(dr["ITEM_MRP"]);
              objItem.MinSalePrice = Convert.ToDouble(dr["ITEM_MINSALEPRICE"]);
              objItem.SelfValuePrice = Convert.ToDouble(dr["ITEM_SELFVALUEPRICE"]);
              objItem.SaleDiscount = Convert.ToDouble(dr["ITEM_SALEDISCOUNT"]);
              objItem.PurDiscount = Convert.ToDouble(dr["ITEM_PURCHASEDISCOUNT"]);
              objItem.SaleCompoundDiscount = Convert.ToDouble(dr["ITEM_SALECOMPDISCOUNT"]);
              objItem.PurCompoundDiscount = Convert.ToDouble(dr["ITEM_PURCHCOMPDISCOUNT"]);
              objItem.SpecifySaleDiscStructure = Convert.ToBoolean(dr["ITEM_SPECIFYSALEDISCSTRUCT"]);
              objItem.SpecifyPurDiscStructure = Convert.ToBoolean(dr["ITEM_SPECIFYPURDISCSTRUCT"]);
              objItem.SaleMarkup = dr["ITEM_SALEMARKUP"].ToString();
              objItem.PurMarkup = dr["ITEM_PURMARKUP"].ToString();
              objItem.SaleCompMarkup = dr["ITEM_SALECOMPMARKUP"].ToString();
              objItem.PurCompMarkup = dr["ITEM_PURCOMPMARKUP"].ToString();
              objItem.SpecifySaleMarkupStruct = Convert.ToBoolean(dr["ITEM_SPECIFYSALEMARKUPSTRUCT"]);
              objItem.SpecifyPurMarkupStruct = Convert.ToBoolean(dr["ITEM_SPECIFYPURMARKUPSTRUCT"]);
              objItem.TaxCategory = dr["ITEM_TAXCATEGORY"].ToString();
              objItem.TaxType = dr["ITEM_TAXTYPE"].ToString();
              objItem.ServiceTaxRate = Convert.ToDouble(dr["ITEM_SERVICETAXRATE"]);
              objItem.RateofTax_Local = Convert.ToDouble(dr["ITEM_LOCALTAX"]);
              objItem.RateofTax_Central = Convert.ToDouble(dr["ITEM_CENTRALTAX"]);
              objItem.TaxonMRP = Convert.ToBoolean(dr["ITEM_TAXONMRP"]);
              objItem.HSNCode = dr["ITEM_HSNCODE"].ToString();
              objItem.ItemDescription1 = dr["ITEM_DESCRIPTION1"].ToString();
              objItem.ItemDescription2 = dr["ITEM_DESCRIPTION2"].ToString();
              objItem.ItemDescription3 = dr["ITEM_DESCRIPTION3"].ToString();
              objItem.ItemDescription4 = dr["ITEM_DESCRIPTION4"].ToString();
              objItem.ItemDescription5 = dr["ITEM_DESCRIPTION5"].ToString();
              objItem.ItemDescription6 = dr["ITEM_DESCRIPTION6"].ToString();
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

              lstItems.Add(objItem);
          
          }
          return lstItems;

      }

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

        public bool DeletItemMaster(List<int> lstIds)
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

    }
}
