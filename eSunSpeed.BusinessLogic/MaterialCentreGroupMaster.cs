using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;
using eSunSpeedDomain;

namespace eSunSpeed.BusinessLogic
{
  public  class MaterialCentreGroupMaster
    {
        private DBHelper _dbHelper = new DBHelper();
        public bool SaveMCG(MaterialCentreGroupMasterModel objMCG)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Group", objMCG.Group));
                paramCollection.Add(new DBParameter("@Alias", objMCG.Alias));
                paramCollection.Add(new DBParameter("@PrimaryGroup", objMCG.PrimaryGroup,System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@UnderGroup", objMCG.UnderGroup));
                paramCollection.Add(new DBParameter("@CreatedBy", objMCG.CreatedBy));
                
                Query = "INSERT INTO MaterialCentreGroupMaster(`Group`,`Alias`,`PrimaryGroup`,`UnderGroup`,`CreatedBy`) " +
                    "VALUES(@Group,@Alias,@PrimaryGroup,@UnderGroup,@CreatedBy)";

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

        //update
        public bool UpdateMCG(MaterialCentreGroupMasterModel objMCG)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Group", objMCG.Group));
                paramCollection.Add(new DBParameter("@Alias", objMCG.Alias));
                paramCollection.Add(new DBParameter("@PrimaryGroup", objMCG.PrimaryGroup,System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@UnderGroup", objMCG.UnderGroup));
                paramCollection.Add(new DBParameter("@MCG_ID", objMCG.MCG_ID));


                Query = "UPDATE `materialcentregroupmaster` SET `Group`=@Group,Alias=@Alias,`PrimaryGroup`=@PrimaryGroup,UnderGroup=@UnderGroup " +
                        "WHERE MCG_ID=@MCG_ID";


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

        //List

        public List<MaterialCentreGroupMasterModel> GetAllMaterialGroups()
        {
            List<MaterialCentreGroupMasterModel> lstMCG = new List<MaterialCentreGroupMasterModel>();
            MaterialCentreGroupMasterModel objMCG;

            string Query = "SELECT * FROM `materialcentregroupmaster`";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {

                objMCG = new MaterialCentreGroupMasterModel();

                objMCG.MCG_ID = Convert.ToInt32(dr["MCG_ID"]);
                objMCG.Group = dr["Group"].ToString();
                objMCG.PrimaryGroup = Convert.ToBoolean(dr["PrimaryGroup"]);
                objMCG.UnderGroup = dr["UnderGroup"].ToString();              

                lstMCG.Add(objMCG);               
            }

            return lstMCG;
        }

        //Get List To Update By Id
        public MaterialCentreGroupMasterModel GetAllMaterialGroupsById(int id)
        {
            MaterialCentreGroupMasterModel objMCG = new MaterialCentreGroupMasterModel();

            string Query = "SELECT * FROM `materialcentregroupmaster` WHERE MCG_ID="+id+"";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objMCG.MCG_ID = Convert.ToInt32(dr["MCG_ID"]);
                objMCG.Group = dr["Group"].ToString();
                objMCG.Alias = dr["Alias"].ToString();
                objMCG.PrimaryGroup = Convert.ToBoolean(dr["PrimaryGroup"]);
                objMCG.UnderGroup = dr["UnderGroup"].ToString();

            }

            return objMCG;
        }

        #region Delete Material Group

        public bool DeleteMaterialGroup(List<int> lstIds)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection;

                foreach (int uid in lstIds)
                {
                    paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@id", uid));
                    Query = "Delete from MaterialCentreGroupMaster WHERE [MCG_id]=@id";

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
