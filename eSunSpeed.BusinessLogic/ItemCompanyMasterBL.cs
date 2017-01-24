using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;

namespace eSunSpeed.BusinessLogic
{
  public  class ItemCompanyMasterBL
    {
        private DBHelper _dbHelper = new DBHelper();

        //Save Item Company
        public bool SaveItemCompany(ItemCompanyMasterModel objCompany)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ItemCompany", objCompany.ItemCompany));
                paramCollection.Add(new DBParameter("@StockAccount", objCompany.StockAccount));
                paramCollection.Add(new DBParameter("@SalesAccount", objCompany.SalesAccount));
                paramCollection.Add(new DBParameter("@PurchaseAccount", objCompany.PurchaseAccount));
                paramCollection.Add(new DBParameter("@CreatedBy","Admin"));
                System.Data.IDataReader dr =
                         _dbHelper.ExecuteDataReader("spInsertItemCompany", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                isSaved = false;
                throw ex;
            }

            return isSaved;
        }

        //Update
        public bool UpdateItemCompany(ItemCompanyMasterModel objCompany)
        {
            string Query = string.Empty;
            bool isUpdate = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ItemCompany", objCompany.ItemCompany));
                paramCollection.Add(new DBParameter("@StockAccount", objCompany.StockAccount));
                paramCollection.Add(new DBParameter("@SalesAccount", objCompany.SalesAccount));
                paramCollection.Add(new DBParameter("@PurchaseAccount", objCompany.PurchaseAccount));
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ICompany_Id", objCompany.ICM_id));

                System.Data.IDataReader dr =
                         _dbHelper.ExecuteDataReader("spUpdateItemCompany", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                isUpdate = false;
                throw ex;
            }

            return isUpdate;
        }

        //List Item Company
        public List<ItemCompanyMasterModel> GetAllItemCompany()
        {
            List<ItemCompanyMasterModel> lstIC = new List<ItemCompanyMasterModel>();
            ItemCompanyMasterModel objICM;

            string Query = "SELECT DISTINCT ICM_ID,ItemCompany FROM `itemcompanymaster`";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {

                objICM = new ItemCompanyMasterModel();

                objICM.ICM_id = Convert.ToInt32(dr["ICM_Id"]);
                objICM.ItemCompany = dr["ItemCompany"].ToString();

                lstIC.Add(objICM);
            }

            return lstIC;
        }
        //Get List Of Groups By Id
        public ItemCompanyMasterModel GetAllItemCompanyById(int id)
        {
            ItemCompanyMasterModel objICM = new ItemCompanyMasterModel();

            string Query = "SELECT * FROM `itemcompanymaster` WHERE ICM_ID=" + id+"";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objICM.ICM_id = Convert.ToInt32(dr["ICM_ID"]);
                objICM.ItemCompany = dr["ItemCompany"].ToString();
                objICM.StockAccount = dr["StockAccount"].ToString();
                objICM.SalesAccount = dr["SalesAccount"].ToString();
                objICM.PurchaseAccount = dr["PurchaseAccount"].ToString();
            }

            return objICM;
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
        //Delete Single Item Company
        public bool DeleteItemCompanyById(int id)
        {
            bool isDelete = false;
            try
            {
                string Query = "DELETE FROM itemcompanymaster WHERE ICM_Id=" + id;
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
        public bool IsItemCompanyExists(string ComapnyName)
    {
            StringBuilder _sbQuery = new StringBuilder();
            _sbQuery.AppendFormat("SELECT COUNT(*) FROM itemcompanymaster WHERE ItemCompany='{0}'", ComapnyName);

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(_sbQuery.ToString(), _dbHelper.GetConnObject());
            dr.Read();
            if (Convert.ToInt32(dr[0]) > 0)
                return true;
            else
                return false;

        }
    }
}
