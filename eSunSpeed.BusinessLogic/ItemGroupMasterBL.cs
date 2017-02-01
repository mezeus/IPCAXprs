using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;
using System.Data;

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
                paramCollection.Add(new DBParameter("@SpecifyBillReferencegrp", objIGM.SpecifyBillReferencegrp, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@BillReferencegrp", objIGM.BillReferencegrp));
                paramCollection.Add(new DBParameter("@CrDaysforSale", objIGM.CrDaysforSale, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@CrDaysforPurc", objIGM.CrDaysforPurc, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@CreatedBy","Admin"));
                
                Query = "INSERT INTO itemgroupmaster (`ItemGroup`,`Alias`,`PrimaryGroup`,`UnderGroup`,`StockAccount`,`SalesAccount`,`PurchaseAccount`,`DefaultConfig`,`SeparateConfig`,"+
                    "`Parameters`,`SpecifyBillReferencegrp`,`BillReferencegrp`,`CrDaysforSale`,`CrDaysforPurc`,`CreatedBy`) " +
                    "VALUES(@ItemGroup,@Alias,@PrimaryGroup,@UnderGroup,@StockAccount,@SalesAccount,@PurchaseAccount,@DefaultConfig,@SeparateConfig,@Parameters,"+
                    "@SpecifyBillReferencegrp,@BillReferencegrp,@CrDaysforSale,@CrDaysforPurc,@CreatedBy)";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                    SaveIGMasterSeriesGroup(objIGM.IGMasterSeries);
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
                paramCollection.Add(new DBParameter("@SpecifyBillReferencegrp", objIGM.SpecifyBillReferencegrp, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@BillReferencegrp", objIGM.BillReferencegrp));
                paramCollection.Add(new DBParameter("@CrDaysforSale", objIGM.CrDaysforSale, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@CrDaysforPurc", objIGM.CrDaysforPurc, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@IGM_Id",objIGM.IGM_id));

                Query = "UPDATE ItemGroupMaster SET ItemGroup=@ItemGroup,Alias=@Alias,`PrimaryGroup`=@PrimaryGroup,UnderGroup=@UnderGroup,StockAccount=@StockAccount,SalesAccount=@SalesAccount," +
                   "PurchaseAccount=@PurchaseAccount,`DefaultConfig`=@DefaultConfig,`SeparateConfig`=@SeparateConfig,Parameters=@Parameters,ModifiedBy=@ModifiedBy," +
                   "SpecifyBillReferencegrp=@SpecifyBillReferencegrp,BillReferencegrp=@BillReferencegrp,CrDaysforSale=@CrDaysforSale,CrDaysforPurc=@CrDaysforPurc " +
                   "WHERE IGM_Id=@IGM_Id";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                {
                    List<MasterseriesModel> lstSeries = new List<MasterseriesModel>();
                    foreach (MasterseriesModel objMaster in objIGM.IGMasterSeries)
                    {
                        objMaster.ParentId = objIGM.IGM_id;
                        if (objMaster.MasterId > 0)
                        {
                            paramCollection = new DBParameterCollection();

                            paramCollection.Add(new DBParameter("@ParentId", objMaster.ParentId));
                            paramCollection.Add(new DBParameter("@SeriesId", objMaster.MasterId));
                            paramCollection.Add(new DBParameter("@MasterName", objMaster.MasterName));
                            paramCollection.Add(new DBParameter("@CreatedBy", ""));
                            paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));
                            paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                            paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));

                            System.Data.IDataReader drmg =
                            _dbHelper.ExecuteDataReader("spUpdateIGMasterSeriesGroup", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                            isUpdate = true;
                        }
                        else
                        {
                            paramCollection = new DBParameterCollection();
                            paramCollection.Add(new DBParameter("@AccountId", "0", DbType.Int32));
                            paramCollection.Add(new DBParameter("@AccountGroupId", "0", DbType.Int32));
                            paramCollection.Add(new DBParameter("@ItemId", "0", DbType.Int32));
                            paramCollection.Add(new DBParameter("@ItemGroupId", objMaster.ParentId));
                            paramCollection.Add(new DBParameter("@MaterialCenterId", "0", DbType.Int32));
                            paramCollection.Add(new DBParameter("@MaterialCenterGroupId", "0", DbType.Int32));
                            paramCollection.Add(new DBParameter("@CostCenterId", "0", DbType.Int32));
                            paramCollection.Add(new DBParameter("@CostCenterGroupId", "0", DbType.Int32));
                            paramCollection.Add(new DBParameter("@BillSundaryId", "0", DbType.Int32));
                            paramCollection.Add(new DBParameter("@SaleId", "0", DbType.Int32));
                            paramCollection.Add(new DBParameter("@PurcId", "0", DbType.Int32));
                            paramCollection.Add(new DBParameter("@MasterName", objMaster.MasterName));
                            paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                            paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));
                            paramCollection.Add(new DBParameter("@ModifiedBy", string.Empty));
                            paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));

                            System.Data.IDataReader dr =
                            _dbHelper.ExecuteDataReader("spInsertMasterSeriesGroupDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                            isUpdate = true;
                        }
                    }
                    isUpdate = true;
                }
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
                objIGM.SpecifyBillReferencegrp = Convert.ToBoolean(dr["SpecifyBillReferencegrp"].ToString());
                objIGM.BillReferencegrp = dr["BillReferencegrp"].ToString();
                objIGM.CrDaysforSale = Convert.ToInt32(dr["CrDaysforSale"].ToString());
                objIGM.CrDaysforPurc = Convert.ToInt32(dr["CrDaysforPurc"].ToString());

                string MasterQuery = "SELECT * FROM masterseriesgrpdetails WHERE IGM_ID=" +id;
                System.Data.IDataReader drms = _dbHelper.ExecuteDataReader(MasterQuery, _dbHelper.GetConnObject());

                objIGM.IGMasterSeries = new List<MasterseriesModel>();
                MasterseriesModel objMaster;
                while (drms.Read())
                {
                    objMaster = new MasterseriesModel();
                    objMaster.MasterId = Convert.ToInt32(drms["MasterId"]);
                    objMaster.ParentId = Convert.ToInt32(drms["IGM_ID"]);
                    objMaster.MasterName = drms["MasterName"].ToString();

                    objIGM.IGMasterSeries.Add(objMaster);
                }
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
        //Delete Single Item Group
        public bool DeleteItemGroupById(int id)
        {
            bool isDelete = false;
            try
            {
                if(DeleteIGMasterSeriesGroup(id))
                {
                    string Query = "DELETE FROM itemgroupmaster WHERE IGM_Id=" + id;
                    int rowes = _dbHelper.ExecuteNonQuery(Query);
                    if (rowes > 0)
                        isDelete = true;
                }               
            }
            catch (Exception ex)
            {
                isDelete = false;
                throw ex;
            }
            return isDelete;
        }
        //Delete ItemGroup MasterSeries Details
        public bool DeleteIGMasterSeriesGroup(int id)
        {
            bool isDelete = true;
            try
            {
                string Query = "DELETE FROM `masterseriesgrpdetails` WHERE IGM_ID=" + id;
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
        //Is ItemGroup Master Exist or Not
        public bool IsItemGroupExists(string groupName)
        {
            StringBuilder _sbQuery = new StringBuilder();
            _sbQuery.AppendFormat("SELECT COUNT(*) FROM itemgroupmaster WHERE ItemGroup='{0}'", groupName);

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(_sbQuery.ToString(), _dbHelper.GetConnObject());
            dr.Read();
            if (Convert.ToInt32(dr[0]) > 0)
                return true;
            else
                return false;

        }
        //Get Item Group Id After Item Group Save
        public int GetItemGroupAfterSaveId()
        {
            string Query = "SELECT MAX(IGM_ID) FROM ItemGroupMaster";
            int id = Convert.ToInt32(_dbHelper.ExecuteScalar(Query));
            return id;
        }
        //Save Item Group Master Series Group Details
        public bool SaveIGMasterSeriesGroup(List<MasterseriesModel> lstMaster)
        {
            string Query = string.Empty;
            bool isSaved = true;
            foreach (MasterseriesModel objMaster in lstMaster)
            {
                objMaster.ParentId = GetItemGroupAfterSaveId();
                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@AccountId", "0", DbType.Int32));
                    paramCollection.Add(new DBParameter("@AccountGroupId","0",DbType.Int32));
                    paramCollection.Add(new DBParameter("@ItemId", "0", DbType.Int32));
                    paramCollection.Add(new DBParameter("@ItemGroupId",objMaster.ParentId));
                    paramCollection.Add(new DBParameter("@MaterialCenterId", "0", DbType.Int32));
                    paramCollection.Add(new DBParameter("@MaterialCenterGroupId", "0", DbType.Int32));
                    paramCollection.Add(new DBParameter("@CostCenterId", "0", DbType.Int32));
                    paramCollection.Add(new DBParameter("@CostCenterGroupId", "0", DbType.Int32));
                    paramCollection.Add(new DBParameter("@BillSundaryId", "0", DbType.Int32));
                    paramCollection.Add(new DBParameter("@SaleId", "0", DbType.Int32));
                    paramCollection.Add(new DBParameter("@PurcId", "0", DbType.Int32));
                    paramCollection.Add(new DBParameter("@MasterName", objMaster.MasterName));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@ModifiedBy", string.Empty));
                    paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertMasterSeriesGroupDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }
    }
}
