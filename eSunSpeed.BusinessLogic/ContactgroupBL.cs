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
           paramCollection.Add(new DBParameter("@GroupName", objContactGrp.GroupName));
            paramCollection.Add(new DBParameter("@Alias", objContactGrp.AliasName));
            paramCollection.Add(new DBParameter("@Primarygroup", objContactGrp.Primary?1:0));
            paramCollection.Add(new DBParameter("@Natureofgroup", objContactGrp.Natureofgroup));
            paramCollection.Add(new DBParameter("@Affectgrossprofit", objContactGrp.Affectgrossprofit?1:0));
            paramCollection.Add(new DBParameter("@UnderGroup", objContactGrp.UnderGroup));
            paramCollection.Add(new DBParameter("@CreatedBy", objContactGrp.CreatedBy));
                       
            Query = "INSERT INTO contactgroup (`Group`,`Alias`,`Primarygroup`,`Undergroup`,`Natureofgroup`,`Affectgrossprofit`,`CreatedBy`) VALUES (@GroupName,@Alias,@Primarygroup,@UnderGroup,@Natureofgroup,@Affectgrossprofit,@CreatedBy)";

            return _dbHelper.ExecuteNonQuery(Query,paramCollection) > 0;                  
        }
        #endregion
        
    }
}
