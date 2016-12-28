using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;
using System.Data;
using eSunSpeed.BusinessLogic;
using eSunSpeedDomain;

namespace eSunSpeed.BusinessLogic
{
    public class EmployeeGroupBL
    {
        private DBHelper _dbHelper = new DBHelper();

        #region Save Employee Group
        /// <summary>
        /// Save Employee Group
        /// </summary>
        /// <param name="objEmpModel"></param>
        /// <returns>True/False</returns>
        public bool SaveEmployeeGroup(eSunSpeedDomain.EmployeeGroupModel objEmpModel)
        {
            string Query = string.Empty;           

            DBParameterCollection paramCollection = new DBParameterCollection();
            
            paramCollection.Add(new DBParameter("@GroupName", objEmpModel.GroupName));
            paramCollection.Add(new DBParameter("@AliasName", objEmpModel.AliasName));
            paramCollection.Add(new DBParameter("@Primary", objEmpModel.Primary,System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@UnderGroup", objEmpModel.UnderGroup));
            paramCollection.Add(new DBParameter("@NatureGroup", objEmpModel.NatureGroup));
            paramCollection.Add(new DBParameter("@CreatedBy", objEmpModel.CreatedBy));
                       
            Query = "INSERT INTO employeegroup (`GroupName`,`AliasName`,`Primary`,`Undergroup`,`Natureofgroup`,`CreatedBy`) VALUES (@GroupName,@AliasName,@Primary,@UnderGroup,@NatureGroup,@CreatedBy)";

            return _dbHelper.ExecuteNonQuery(Query,paramCollection) > 0;                  
        }
        #endregion

        public List<eSunSpeedDomain.EmployeeGroupModel> GetListofEmployeeGroups()
        {
            List<eSunSpeedDomain.EmployeeGroupModel> lstEmployeeGroups = new List<eSunSpeedDomain.EmployeeGroupModel>();
            eSunSpeedDomain.EmployeeGroupModel EmployeeGroup;

            string Query = "SELECT DISTINCT EG_ID,GroupName,AliasName,`Primary`,Undergroup FROM `employeegroup`";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                EmployeeGroup = new eSunSpeedDomain.EmployeeGroupModel();

                EmployeeGroup.GroupId = Convert.ToInt32(dr["EG_ID"]);
                //accountGroup.CanDelete = Convert.ToBoolean(dr["CanDelete"]); 
                EmployeeGroup.GroupName = dr["GroupName"].ToString();
                EmployeeGroup.AliasName = dr["AliasName"].ToString();
                EmployeeGroup.Primary =Convert.ToBoolean(dr["Primary"].ToString() =="1"? true : false);
                EmployeeGroup.UnderGroup = dr["UnderGroup"].ToString();
                

                lstEmployeeGroups.Add(EmployeeGroup);

            }

            return lstEmployeeGroups;

        }

    }

}
