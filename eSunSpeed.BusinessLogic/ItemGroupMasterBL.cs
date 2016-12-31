using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;

namespace eSunSpeed.BusinessLogic
{
  public  class ItemGroupMasterBL
    {
        ItemGroupMasterModel objitmmod = new ItemGroupMasterModel();
        private DBHelper _dbHelper = new DBHelper();

        //Save
        public bool SaveIGM(ItemGroupMasterModel objIGM)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ItemGroup", objIGM.ItemGroup));
                paramCollection.Add(new DBParameter("@Alias", objIGM.Alias));
                paramCollection.Add(new DBParameter("@PrimaryGroup", objIGM.PrimaryGroup,System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@UnderGroup", objIGM.UnderGroup));
                paramCollection.Add(new DBParameter("@StockAccount", objIGM.StockAccount));
                paramCollection.Add(new DBParameter("@SalesAccount", objIGM.SalesAccount));
                paramCollection.Add(new DBParameter("@PurchaseAccount", objIGM.PurchaseAccount));
                paramCollection.Add(new DBParameter("@DefaultConfig", objIGM.DefaultConfig, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@SeparateConfig", objIGM.SeparateConfig, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@Parameters", objIGM.Parameters));
                paramCollection.Add(new DBParameter("@CreatedBy","Admin"));
                
                Query = "INSERT INTO itemgroupmaster (`ItemGroup`,`Alias`,`PrimaryGroup`,`UnderGroup`,`StockAccount`,`SalesAccount`,`PurchaseAccount`,`DefaultConfig`,`SeparateConfig`,`Parameters`,`CreatedBy`) " +
                    "VALUES(@ItemGroup,@Alias,@PrimaryGroup,@UnderGroup,@StockAccount,@SalesAccount,@PurchaseAccount,@DefaultConfig,@SeparateConfig,@Parameters,@CreatedBy)";

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

        //Update
        public bool UpdateIGM(ItemGroupMasterModel objIGM)
        {
            string Query = string.Empty;
            bool isUpdate = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ItemGroup", objIGM.ItemGroup));
                paramCollection.Add(new DBParameter("@Alias", objIGM.Alias));
                paramCollection.Add(new DBParameter("@PrimaryGroup", objIGM.PrimaryGroup, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@UnderGroup", objIGM.UnderGroup));
                paramCollection.Add(new DBParameter("@StockAccount", objIGM.StockAccount));
                paramCollection.Add(new DBParameter("@SalesAccount", objIGM.SalesAccount));
                paramCollection.Add(new DBParameter("@PurchaseAccount", objIGM.PurchaseAccount));
                paramCollection.Add(new DBParameter("@DefaultConfig", objIGM.DefaultConfig, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@SeparateConfig", objIGM.SeparateConfig, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@Parameters", objIGM.Parameters));
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@IGM_Id",objIGM.IGM_id));

                Query = "UPDATE ItemGroupMaster SET ItemGroup=@ItemGroup,Alias=@Alias,`PrimaryGroup`=@PrimaryGroup,UnderGroup=@UnderGroup,StockAccount=@StockAccount,SalesAccount=@SalesAccount," +
                   "PurchaseAccount=@PurchaseAccount,`DefaultConfig`=@DefaultConfig,`SeparateConfig`=@SeparateConfig,Parameters=@Parameters,ModifiedBy=@ModifiedBy " +
                   "WHERE IGM_Id=@IGM_Id";
                
                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                    isUpdate = true;
            }
            catch (Exception ex)
            {
                isUpdate = false;
                throw ex;
            }

            return isUpdate;
        }

        //List
        public List<ItemGroupMasterModel> GetAllItemGroup()
        {
            List<eSunSpeedDomain.ItemGroupMasterModel> lstIGM = new List<ItemGroupMasterModel>();
            eSunSpeedDomain.ItemGroupMasterModel objIGM;

            string Query = "SELECT DISTINCT IGM_ID,ItemGroup,PrimaryGroup,UnderGroup FROM `ItemGroupMaster`";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {

                objIGM = new ItemGroupMasterModel();

                objIGM.IGM_id = Convert.ToInt32(dr["IGM_ID"]);
                objIGM.ItemGroup = dr["ItemGroup"].ToString();
                objIGM.PrimaryGroup = Convert.ToBoolean(dr["PrimaryGroup"]);
                objIGM.UnderGroup = dr["UnderGroup"].ToString();

                lstIGM.Add(objIGM);
            }

            return lstIGM;
        }
        //Get List Of Groups By Id
        public ItemGroupMasterModel GetAllItemGroupById(int id)
        {
            ItemGroupMasterModel objIGM = new ItemGroupMasterModel();

            string Query = "SELECT * FROM `ItemGroupMaster` WHERE IGM_ID="+id+"";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objIGM.IGM_id = Convert.ToInt32(dr["IGM_ID"]);
                objIGM.ItemGroup = dr["ItemGroup"].ToString();
                objIGM.Alias = dr["Alias"].ToString();
                objIGM.PrimaryGroup = Convert.ToBoolean(dr["PrimaryGroup"]);
                objIGM.UnderGroup = dr["UnderGroup"].ToString();
                objIGM.StockAccount = dr["StockAccount"].ToString();
                objIGM.SalesAccount = dr["SalesAccount"].ToString();
                objIGM.PurchaseAccount = dr["PurchaseAccount"].ToString();
                objIGM.DefaultConfig =Convert.ToBoolean(dr["DefaultConfig"]);
                objIGM.SeparateConfig = Convert.ToBoolean(dr["SeparateConfig"]);
                objIGM.Parameters =Convert.ToInt32(dr["Parameters"].ToString());
            }

            return objIGM;
        }

        public bool DeletITG(List<int> lstIds)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection;

                foreach (int id in lstIds)
                {
                    paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@IGM_ID", id));
                    Query = "Delete from ItemGroupMaster WHERE [IGM_ID]=@IGM_ID";

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
    }
}
