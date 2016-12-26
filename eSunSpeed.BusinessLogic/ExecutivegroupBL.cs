using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;
using System.Data;


namespace eSunSpeed.BusinessLogic
{
    public class ExecutivegroupBL
    {
        ExecutiveModel objexemod = new ExecutiveModel();
        private DBHelper _dbHelper = new DBHelper();

        #region Save Executive Group
        /// <summary>
        /// Save Contact Group
        /// </summary>
        /// <param name="objexegrp"></param>
        /// <returns>True/False</returns>
        public bool SaveExecutiveGroup(eSunSpeedDomain.ExecutiveModel objexegrp)
        {
            try
            {
                string Query = string.Empty;

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Name", objexegrp.GroupName));
                paramCollection.Add(new DBParameter("@Alias", objexegrp.AliasName));
                paramCollection.Add(new DBParameter("@PrintName", objexegrp.PrintName));
                paramCollection.Add(new DBParameter("@HandlesCallType", objexegrp.Handlescalltype));
                paramCollection.Add(new DBParameter("@Area", objexegrp.Area));
                paramCollection.Add(new DBParameter("@Address", objexegrp.Address));
                paramCollection.Add(new DBParameter("@Address1", objexegrp.Address1));
                paramCollection.Add(new DBParameter("@Address2", objexegrp.Address2));
                paramCollection.Add(new DBParameter("@Address3", objexegrp.Address3));
                paramCollection.Add(new DBParameter("@Telephone", objexegrp.Telephone));
                paramCollection.Add(new DBParameter("@MobileNo", objexegrp.MobileNo));
                paramCollection.Add(new DBParameter("@Email", objexegrp.Email));

                Query = "INSERT INTO executivegroup(`Name`,`Alias`,`PrintName`,`HandlesCallType`,`Area`,`Address`,`Address1`,`Address2`,`Address3`,`Telephone`,`MobileNo`,`E-Mail`,`CreatedBy`) VALUES (@Name,@Alias,@PrintName,@HandlesCallType,@Area,@Address,@Address1,@Address2,@Address3,@Telephone,@MobileNo,@Email,@CreatedBy)";

                return _dbHelper.ExecuteNonQuery(Query, paramCollection) > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

    }
    #endregion
}

