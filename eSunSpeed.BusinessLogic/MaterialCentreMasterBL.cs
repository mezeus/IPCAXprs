using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;

namespace eSunSpeed.BusinessLogic
{
   public class MaterialCentreMasterBL
       {
        MaterialCentreGroupMasterModel objmatceng = new MaterialCentreGroupMasterModel();

        private DBHelper _dbHelper = new DBHelper();
       
       public bool SaveMaterialMaster(MaterialCentreMasterModel objMCM)
        {
            string Query = string.Empty;
            bool isSaved = true;

            //TODO: NEED TO INCLUDE MISSING PARAMETERS
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@GroupName", objMCM.GroupName));
                paramCollection.Add(new DBParameter("@Alias", objMCM.Alias));
                paramCollection.Add(new DBParameter("@PrintName", objMCM.PrintName));
                paramCollection.Add(new DBParameter("@Group", objMCM.Group));
                paramCollection.Add(new DBParameter("@StockAccount", objMCM.StockAccount));
                paramCollection.Add(new DBParameter("@EnableStockinBal", objMCM.EnableStockinBal,System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@SalesAccount", objMCM.SalesAccount));
                paramCollection.Add(new DBParameter("@PurchaseAccount", objMCM.PurchaseAccount));
                paramCollection.Add(new DBParameter("@EnableAccinTransfer", objMCM.EnableAccinTransfer,System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@Address", objMCM.Address));
                paramCollection.Add(new DBParameter("@Street", objMCM.Street));
                paramCollection.Add(new DBParameter("@City", objMCM.City));
                paramCollection.Add(new DBParameter("@State", objMCM.State));

                paramCollection.Add(new DBParameter("@Country", objMCM.Country));
                paramCollection.Add(new DBParameter("@PinCode", objMCM.PinCode));
                paramCollection.Add(new DBParameter("@Mobile", objMCM.Mobile));

                paramCollection.Add(new DBParameter("@CreatedBy","Admin"));

                Query = "INSERT INTO materialcentremaster(`Name`,`Alias`,`PrintName`,`Group`,`StockAccount`,`EnableStockinBal`,`SalesAccount`,`PurchaseAccount`," +
                "`EnableAccinTransfer`,`Address`,`Street`,`City`,`State`,`Country`,`PinCode`,`Mobile`,`CreatedBy`)" +
                 "VALUES(@GroupName,@Alias,@PrintName,@Group,@StockAccount,@EnableStockinBal,@SalesAccount,@PurchaseAccount,@EnableAccinTransfer,@Address,@Street,@City," +
                 "@State,@Counry,@PinCode,@Mobile,@CreatedBy)";

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

       public bool UpdateMaterialMaster(MaterialCentreMasterModel objMCM)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@GroupName", objMCM.GroupName));
                paramCollection.Add(new DBParameter("@Alias", objMCM.Alias));
                paramCollection.Add(new DBParameter("@PrintName", objMCM.PrintName));
                paramCollection.Add(new DBParameter("@Group", objMCM.Group));
                paramCollection.Add(new DBParameter("@StockAccount", objMCM.StockAccount));
                paramCollection.Add(new DBParameter("@EnableStockinBal", objMCM.EnableStockinBal, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@SalesAccount", objMCM.SalesAccount));
                paramCollection.Add(new DBParameter("@PurchaseAccount", objMCM.PurchaseAccount));
                paramCollection.Add(new DBParameter("@EnableAccinTransfer", objMCM.EnableAccinTransfer, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@Address", objMCM.Address));
                paramCollection.Add(new DBParameter("@MC_Id", objMCM.MC_Id));

                Query = "UPDATE `materialcentremaster` SET `Name`=@GroupName,`Alias`=@Alias,`PrintName`=@PrintName,`Group`=@Group," +
                "`StockAccount`=@StockAccount,`EnableStockinBal`=@EnableStockinBal,`SalesAccount`=@SalesAccount,`PurchaseAccount`=@PurchaseAccount," +
                "`EnableAccinTransfer`=@EnableAccinTransfer,`Address`=@Address " +
                 " WHERE `MC_Id`=@MC_Id";

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

       public List<MaterialCentreMasterModel> GetAllMaterials()
       {
           List<MaterialCentreMasterModel> lstMaterials=new List<MaterialCentreMasterModel>();
           MaterialCentreMasterModel objMat;

         string  Query = "SELECT * FROM `materialcentremaster`";
          System.Data.IDataReader dr= _dbHelper.ExecuteDataReader(Query,_dbHelper.GetConnObject());

            while (dr.Read())
            {
                objMat = new MaterialCentreMasterModel();

                objMat.MC_Id = Convert.ToInt32(dr["MC_Id"]);
                objMat.GroupName = dr["Name"].ToString();
                objMat.Alias = dr["Alias"].ToString();
                objMat.Group = dr["Group"].ToString();
 
                lstMaterials.Add(objMat);

            }
          return lstMaterials;
       }
        //List of Material Centermaster By Id
        public MaterialCentreMasterModel GetAllMaterialsById(int id)
        {
            MaterialCentreMasterModel objMat = new MaterialCentreMasterModel();
           
            string Query = "SELECT * FROM `materialcentremaster` WHERE MC_Id="+id+"";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objMat = new MaterialCentreMasterModel();

                objMat.MC_Id = Convert.ToInt32(dr["MC_Id"]);
                objMat.GroupName = dr["Name"].ToString();
                objMat.Alias = dr["Alias"].ToString();
                objMat.PrintName = dr["PrintName"].ToString();
                objMat.Group = dr["Group"].ToString();
                objMat.StockAccount = dr["StockAccount"].ToString();
                objMat.EnableStockinBal = Convert.ToBoolean(dr["EnableStockinBal"]);
                objMat.SalesAccount = dr["SalesAccount"].ToString();
                objMat.PurchaseAccount = dr["PurchaseAccount"].ToString();
                objMat.EnableAccinTransfer= Convert.ToBoolean(dr["EnableAccinTransfer"]);
                objMat.Address = dr["Address"].ToString();

            }
            return objMat;
        }
        #region Delete MaterialCenter       
        public bool DeleteMaterialCenter(List<int> lstIds)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection;

                foreach (int id in lstIds)
                {
                    paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@id", id));
                    Query = "Delete from MaterialCentreMaster WHERE [MC_id]=@id";

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
        #endregion

    }
}
