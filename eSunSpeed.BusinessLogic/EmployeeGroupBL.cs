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
            paramCollection.Add(new DBParameter("@Primary", objEmpModel.Primary));
            paramCollection.Add(new DBParameter("@UnderGroup", objEmpModel.UnderGroup));
            paramCollection.Add(new DBParameter("@CreatedBy", objEmpModel.CreatedBy));
                       
            Query = "INSERT INTO employeegroup (`GroupName`,`AliasName`,`Primary`,`Undergroup`,`CreatedBy`) VALUES (@GroupName,@AliasName,@Primary,@UnderGroup,@CreatedBy)";

            return _dbHelper.ExecuteNonQuery(Query,paramCollection) > 0;                  
        }
        #endregion
        
    }

}
