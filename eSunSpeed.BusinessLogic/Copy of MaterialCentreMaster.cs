using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;

namespace eSunSpeed.BusinessLogic
{
   public class MaterialCentreMaster
    {
        private DBHelper _dbHelper = new DBHelper();
       
       public bool SaveMaterialMaster(eSunSpeedDomain.MaterialCentreMasterModel objMCM)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Name", objMCM.Name));
                paramCollection.Add(new DBParameter("@Alias", objMCM.Alias));
                paramCollection.Add(new DBParameter("@PrintName", objMCM.PrintName));
                paramCollection.Add(new DBParameter("@Group", objMCM.Group));
                paramCollection.Add(new DBParameter("@StockAccount", objMCM.StockAccount));
                paramCollection.Add(new DBParameter("@Reflect_StockBalSheet", objMCM.ReflectTheStockInBalanceSheet,System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@Group", objMCM.Group));
                paramCollection.Add(new DBParameter("@PurchaseAccount", objMCM.PurchaseAccount));
                paramCollection.Add(new DBParameter("@Acc_StockTransfer", objMCM.AccountinginStockTransfer));
                paramCollection.Add(new DBParameter("@Address", objMCM.Address));
                paramCollection.Add(new DBParameter("@CreatedBy","Admin"));

                Query = "INSERT INTO MaterialCentreMaster([Name],[Alias],[PrintName],[Group],[StockAccount],[Reflect_StockBalSheet],[PurchaseAccount]," +
                "[Acc_StockTransfer],[Address],[CreatedBy])" +
                 "VALUES(@Name,@Alias,@PrintName,@Group,@StockAccount,@Reflect_StockBalSheet,@PurchaseAccount,@Acc_StockTransfer,@Address,@CreatedBy)";

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

       public bool UpdateMaterialMaster(eSunSpeedDomain.MaterialCentreMasterModel objMCM)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                
                paramCollection.Add(new DBParameter("@Name", objMCM.Name));
                paramCollection.Add(new DBParameter("@Alias", objMCM.Alias));
                paramCollection.Add(new DBParameter("@PrintName", objMCM.PrintName));
                paramCollection.Add(new DBParameter("@Group", objMCM.Group));
                paramCollection.Add(new DBParameter("@StockAccount", objMCM.StockAccount));
                paramCollection.Add(new DBParameter("@Reflect_StockBalSheet", objMCM.ReflectTheStockInBalanceSheet, System.Data.DbType.Boolean));                
                paramCollection.Add(new DBParameter("@PurchaseAccount", objMCM.PurchaseAccount));
                paramCollection.Add(new DBParameter("@Acc_StockTransfer", objMCM.AccountinginStockTransfer));
                paramCollection.Add(new DBParameter("@Address", objMCM.Address));
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate",DateTime.Now.ToString()));
                paramCollection.Add(new DBParameter("@Id", objMCM.MatId));

                Query = "UPDATE MaterialCentreMaster SET [Name]=@Name,[Alias]=@Alias,[PrintName]=@PrintName,[Group]=@Group," +
                "[StockAccount]=@StockAccount,[Reflect_StockBalSheet]=@Reflect_StockBalSheet,[PurchaseAccount]=@PurchaseAccount," +
                "[Acc_StockTransfer]=@Acc_StockTransfer,[Address]=@Address,[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
                 "WHERE Id=@Id";

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

       public List<eSunSpeedDomain.MaterialCentreMasterModel> GetAllMaterials()
       {
           List<eSunSpeedDomain.MaterialCentreMasterModel> lstMaterials=new List<MaterialCentreMasterModel>();
           eSunSpeedDomain.MaterialCentreMasterModel objMat;

         string  Query = "SELECT * FROM MaterialCentreMaster";
          System.Data.IDataReader dr= _dbHelper.ExecuteDataReader(Query,_dbHelper.GetConnObject());

          while (dr.Read())
          {
              objMat = new MaterialCentreMasterModel();

              objMat.Name = dr["Name"].ToString();
              objMat.Alias = dr["Alias"].ToString();
              objMat.Group = dr["PrintName"].ToString();
              objMat.PrintName = dr["Group"].ToString();
              objMat.StockAccount = dr["StockAccount"].ToString();
              objMat.ReflectTheStockInBalanceSheet = Convert.ToBoolean(dr["Reflect_StockBalSheet"]);
              objMat.SalesAccount = dr["SalesAccount"].ToString();
              objMat.PurchaseAccount = dr["PurchaseAccount"].ToString();
              objMat.AccountinginStockTransfer = dr["Acc_StockTransfer"].ToString();
              objMat.Address = dr["Address"].ToString();

              lstMaterials.Add(objMat);
              
          }
          return lstMaterials;
       }

    }
}
