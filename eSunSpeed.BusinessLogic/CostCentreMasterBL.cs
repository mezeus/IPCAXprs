using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;

namespace eSunSpeed.BusinessLogic
{
   public class CostCentreMasterBL
    {
        CostCentreMasterModel objccmod = new CostCentreMasterModel();
        private DBHelper _dbHelper = new DBHelper();

        public object ParamCollection { get; private set; }

        //Save

        public bool SaveCCM(CostCentreMasterModel objCCM)
        {
            string Query = string.Empty;
            bool isSaved = true;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                
                paramCollection.Add(new DBParameter("@Name", objCCM.Name));
                paramCollection.Add(new DBParameter("@Alias", objCCM.Alias));
                paramCollection.Add(new DBParameter("@Group", objCCM.Group));
                paramCollection.Add(new DBParameter("@opBal", objCCM.opBal,System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@DrCr", objCCM.DrCr));
                paramCollection.Add(new DBParameter("@CreatedBy", objCCM.CreatedBy));

                Query = "INSERT INTO CostCentreMaster(`Name`,`Alias`,`Group`,`opBal`,`DrCr`,`CreatedBy`)" +
                        "VALUES(@Name,@Alias,@Group,@opBal,@DrCr,@CreatedBy)";


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

        //UPDATE
        public bool UpdateCCM(CostCentreMasterModel objCCM)
        {
            string Query = string.Empty;
            bool isUpdated = true;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                
                paramCollection.Add(new DBParameter("@Name", objCCM.Name));
                paramCollection.Add(new DBParameter("@Alias", objCCM.Alias));
                paramCollection.Add(new DBParameter("@Group", objCCM.Group));
                paramCollection.Add(new DBParameter("@opBal", objCCM.opBal,System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@DrCr", objCCM.DrCr));
                paramCollection.Add(new DBParameter("@ModifiedBy", objCCM.ModifiedBy));
                paramCollection.Add(new DBParameter("@CCM_ID", objCCM.CCM_ID));

                Query = "UPDATE CostCentreMaster SET Name=@Name,Alias=@Alias,`Group`=@Group,opBal=@opBal,DrCr=@DrCr,ModifiedBy=@ModifiedBy " +
                        "WHERE CCM_ID=@CCM_ID";

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

        //Delete CostCenter
        
        public bool DeletCostCentre(List<int> lstIds)
        {
            string Query = string.Empty;
            bool isDeleted = true;

            try
            {
                DBParameterCollection paramCollection;

                foreach (int id in lstIds)
                {
                    paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@CCG_ID", id));
                    Query = "Delete from CostCentreMaster WHERE [CCM_ID]=@CCM_ID";

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
        //Delete Cost Center master By Id
        public bool DeleteCostCenterMasterById(int id)
        {
            bool isDelete = false;
            try
            {
                string Query = "DELETE FROM CostCentreMaster WHERE CCM_ID=" + id;
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
        //List
        public List<CostCentreMasterModel> GetAllCostCentreMaster()
        {
            List<eSunSpeedDomain.CostCentreMasterModel> lstCCM = new List<CostCentreMasterModel>();
            eSunSpeedDomain.CostCentreMasterModel objCCM;
           

            string Query = "SELECT * FROM CostCentreMaster";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {

                objCCM = new CostCentreMasterModel();
                objCCM.CCM_ID = Convert.ToInt32(dr["CCM_ID"]);
                objCCM.Name = dr["Name"].ToString();
                objCCM.Alias = dr["Alias"].ToString();
                objCCM.Group = dr["Group"].ToString();
                objCCM.opBal = Convert.ToDecimal( dr["opBal"]);
                objCCM.DrCr = dr["DrCr"].ToString();
                //objCCM.ModifiedBy = dr["ModifiedBy"].ToString();


               lstCCM.Add(objCCM);



            }

            return lstCCM;
        }

        public CostCentreMasterModel GetAllCostCentreMasterById(int id)
        {
            CostCentreMasterModel objCCM = new CostCentreMasterModel();
            string Query = "SELECT * FROM CostCentreMaster WHERE CCM_ID="+id+"";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {

                objCCM = new CostCentreMasterModel();
                objCCM.CCM_ID = Convert.ToInt32(dr["CCM_ID"]);
                objCCM.Name = dr["Name"].ToString();
                objCCM.Alias = dr["Alias"].ToString();
                objCCM.Group = dr["Group"].ToString();
                objCCM.opBal = Convert.ToDecimal(dr["opBal"]);
                objCCM.DrCr = dr["DrCr"].ToString();
                //objCCM.ModifiedBy = dr["ModifiedBy"].ToString();

             
            }

            return objCCM;
        }

        //Master Name Exist or Not
        public bool IsCostMasterExists(string MasterName)
        {
            StringBuilder _sbQuery = new StringBuilder();
            _sbQuery.AppendFormat("SELECT COUNT(*) FROM CostCentreMaster WHERE Name='{0}'", MasterName);

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(_sbQuery.ToString(), _dbHelper.GetConnObject());
            dr.Read();
            if (Convert.ToInt32(dr[0]) > 0)
                return true;
            else
                return false;

        }

        //Get CostCenterMasterName By CostGroup Name
        public CostCentreMasterModel GetCostNameByGroupname(string groupname)
        {
            CostCentreMasterModel objcostModel = new CostCentreMasterModel();

            string Query = string.Empty;

            Query = "SELECT Name FROM `CostCentreMaster` WHERE `Group`='" + groupname + "'";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objcostModel = new eSunSpeedDomain.CostCentreMasterModel();

                objcostModel.Name = dr["Name"].ToString();
            }
            return objcostModel;

        }

    }
}
