using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;
using System.Data;


namespace eSunSpeed.BusinessLogic
{
    public class ContactgroupBL
    {
        private DBHelper _dbHelper = new DBHelper();

        #region Save Contact Group
        /// <summary>
        /// Save Contact Group
        /// </summary>
        /// <param name="objContactGrp"></param>
        /// <returns>True/False</returns>
        public bool SaveContactGroup(eSunSpeedDomain.ContactModel objContactGrp)
        {   
            string Query = string.Empty;           

            DBParameterCollection paramCollection = new DBParameterCollection();
           paramCollection.Add(new DBParameter("@ContactName", objContactGrp.ContactName));
            paramCollection.Add(new DBParameter("@Alias", objContactGrp.AliasName));
            paramCollection.Add(new DBParameter("@Primary", objContactGrp.Primary));
            paramCollection.Add(new DBParameter("@UnderGroup", objContactGrp.UnderGroup));
            paramCollection.Add(new DBParameter("@CreatedBy", objContactGrp.CreatedBy));
                       
            Query = "INSERT INTO contactgroup (`ContactName`,`Alias`,`Primarygroup`,`UnderGroup`,`CreatedBy`) VALUES (@contactName,@Alias,@Primarygroup,@UnderGroup,@CreatedBy)";

            return _dbHelper.ExecuteNonQuery(Query,paramCollection) > 0;                  
        }
        #endregion
        
    }
}
