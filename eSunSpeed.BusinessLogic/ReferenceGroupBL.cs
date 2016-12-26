using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;
using System.Data;

namespace eSunSpeed.BusinessLogic
{
    public class ReferenceGroupBL
    {
        private DBHelper _dbHelper = new DBHelper();

        #region Save Reference Group
        /// <summary>
        /// Save Reference Group
        /// </summary>
        /// <param name="objReferenceGroup"></param>
        /// <returns>True/False</returns>
        public bool SaveReferenceGroup(eSunSpeedDomain.ReferenceGroupModel objrefGrp)
        {
            string Query = string.Empty;           

            DBParameterCollection paramCollection = new DBParameterCollection();
            
            paramCollection.Add(new DBParameter("@Name", objrefGrp.Name));
            //paramCollection.Add(new DBParameter("@AliasName", objAccountGrp.AliasName));
            //paramCollection.Add(new DBParameter("@Primary", objAccountGrp.Primary));
            //paramCollection.Add(new DBParameter("@UnderGroup", objAccountGrp.UnderGroup));
            paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                       
            Query = "INSERT INTO Referencegroup(`Name`,`CreatedBy`) VALUES (@Name,@CreatedBy)";

            return _dbHelper.ExecuteNonQuery(Query,paramCollection) > 0;                  
        }
        #endregion                      
    }
}
