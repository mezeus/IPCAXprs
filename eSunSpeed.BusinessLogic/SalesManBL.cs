
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;
using System.Data;
using eSunSpeedDomain;

namespace eSunSpeed.BusinessLogic
{
    public class SalesManBL
    {
        private DBHelper _dbHelper = new DBHelper();

        /*
        //Save
        public bool SaveSalesMan(SalesManModel objModel)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@BOMName", objModel.BOMName));
                paramCollection.Add(new DBParameter("@ItemProduct", objModel.ItemProduct));
                paramCollection.Add(new DBParameter("@Quantity", objModel.Quantity, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@ItemUnit", objModel.ItemUnit));
                paramCollection.Add(new DBParameter("@Expenses", objModel.Expenses, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@SpecifyMCGenerated", objModel.SpecifyMCGenerated, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@SpecifyDefaultMCforItemConsumed", objModel.SpecifyDefaultMCforItemConsumed, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AppMc", objModel.AppMc));
                paramCollection.Add(new DBParameter("@SNo", objModel.SNo));
                paramCollection.Add(new DBParameter("@ItemName", objModel.ItemName));
                paramCollection.Add(new DBParameter("@Qty", objModel.Qty, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@Unit", objModel.Unit, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalofConsumedqtyUnit", objModel.TotalofConsumedqtyUnit, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                Query = "INSERT INTO BillsofMaterial([BomName],[ItemProduct],[Quantity],[ItemUnit],[Expenses],[SpecifyMCGenerated],[SpecifyDefaultMCforItemConsumed],[AppMc],[SNo],[ItemName],[Qty],[Unit],[TotalofConsumedqtyUnit],[CreatedBy]) " +
                    "VALUES(@BOMName,@ItemProduct,@Quantity,@ItemUnit,@Expenses,@SpecifyMCGenerated,@SpecifyDefaultMCforItemConsumed,@AppMc,@SNo,@ItemName,@Qty,@Unit,@TotalofConsumedqtyUnit,@CreatedBy)";

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
        //updatebom
        public bool UpdateSalesMan(SalesManModel objModel)
        {
            string Query = string.Empty;
            bool isUpdated = true;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();


                paramCollection.Add(new DBParameter("@BOMName", objModel.SM_Name));
                paramCollection.Add(new DBParameter("@ItemProduct", objModel.ItemProduct));
                paramCollection.Add(new DBParameter("@Quantity", objModel.Quantity, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@ItemUnit", objModel.ItemUnit));
                paramCollection.Add(new DBParameter("@Expenses", objModel.Expenses, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@SpecifyMCGenerated", objModel.SpecifyMCGenerated, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@SpecifyDefaultMCforItemConsumed", objModel.SpecifyDefaultMCforItemConsumed, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AppMc", objModel.AppMc));
                paramCollection.Add(new DBParameter("@SNo", objModel.SNo));
                paramCollection.Add(new DBParameter("@ItemName", objModel.ItemName));
                paramCollection.Add(new DBParameter("@Qty", objModel.Qty, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@Unit", objModel.Unit, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalofConsumedqtyUnit", objModel.TotalofConsumedqtyUnit, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@Bom_Id", objModel.Bom_Id));


                Query = "UPDATE BillsofMaterial SET [BOMName]=@BOMName,[ItemProduct]=@ItemProduct,[Quantity]=@Quantity,[ItemUnit]=@ItemUnit,[Expenses]=@Expenses,[SpecifyMCGenerated]=@SpecifyMCGenerated, " +
                   "[SpecifyDefaultMCforItemConsumed]=@SpecifyDefaultMCforItemConsumed,[AppMc]=@AppMc,[SNo]=@SNo,[ItemName]=@ItemName, " +
                   "[Qty]=@Qty,[Unit]=@Unit,[TotalofConsumedqtyUnit]=@TotalofConsumedqtyUnit,[ModifiedBy]=@ModifiedBy " +
                   "WHERE BOM_Id=@BOM_Id";



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

    */
        //Delete
        public bool DeleteSalesMan(List<int> lstIds)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection;

                foreach (int id in lstIds)
                {
                    paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@SM_Id", id));
                    Query = "Delete from SalesManMaster WHERE [SalesMan_Id]=@SM_ID";

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

        public List<SalesManModel> GetAllSalesMan()
        {
            List<SalesManModel> lstSaleMan = new List<SalesManModel>();
            SalesManModel objModel;

            string Query = "SELECT * FROM SalesManMaster";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {

                objModel = new SalesManModel();

                objModel.SalesMan_Id = Convert.ToInt32(dr["SalesMan_Id"]);
                objModel.SM_Name = dr["SM_Name"].ToString();
                objModel.SM_Alias = dr["SM_Alias"].ToString();
                objModel.SM_PrintName = dr["SM_PrintName"].ToString();
                objModel.EnableDefCommision = Convert.ToBoolean(dr["EnableDefCommision"]);
                objModel.Commision_Mode = dr["Commision_Mode"].ToString();

                objModel.DefCommision = Convert.ToDecimal(dr["DefCommision"]);
                objModel.FreezeCommision = Convert.ToBoolean(dr["FreezeCommision"]);
                objModel.Sales_DebitMode = dr["Sales_DebitMode"].ToString();
                objModel.Sales_ACCredited = dr["Sales_ACCredited"].ToString();
                objModel.Sales_AccDebited = dr["Sales_AccDebited"].ToString();
                objModel.Purchase_DebitMode = dr["Purchase_DebitMode"].ToString();
                objModel.Purchase_AccCredited = dr["Purchase_DebitMode"].ToString();
                objModel.Purchase_AccDebited = dr["Purchase_AccDebited"].ToString();
                objModel.Address = dr["Address"].ToString();

                objModel.City = dr["City"].ToString();
                objModel.State = dr["State"].ToString();
                objModel.Country = dr["Country"].ToString();
                objModel.State = dr["State"].ToString();
                objModel.Mobile = dr["Mobile"].ToString();


                lstSaleMan.Add(objModel);
            }

            return lstSaleMan;
        }
        
    }
}
    
        




    