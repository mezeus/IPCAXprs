using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;
using System.Data;


namespace eSunSpeed.BusinessLogic
{
    public class ContactmasterBL
    {
        ContactmasterModel objconmas = new ContactmasterModel();
        private DBHelper _dbHelper = new DBHelper();

        #region Save Contact Master
        /// <summary>
        /// Save Contact Master
        /// </summary>
        /// <param name="objconmaster"></param>
        /// <returns>True/False</returns>
        public bool Savecontactmaster(eSunSpeedDomain.ContactmasterModel objconmaster)
        {   
            string Query = string.Empty;
            int connectwithledger = 0;
            int specifydob = 0;
            int specifydateofanniversary = 0;

            if (objconmaster.Connectwithledger)
                connectwithledger = 1;

            if (objconmaster.SpecifyDateofAnniversary)
                specifydateofanniversary = 1;

            if (objconmaster.SpecifyDateofBirth)
                specifydob = 1;


            DBParameterCollection paramCollection = new DBParameterCollection();
           paramCollection.Add(new DBParameter("@Name", objconmaster.Name));
            paramCollection.Add(new DBParameter("@Alias", objconmaster.AliasName));
            paramCollection.Add(new DBParameter("@PrintName", objconmaster.PrintName));
            // paramCollection.Add(new DBParameter("@Primary", objconmaster.Primary));
            paramCollection.Add(new DBParameter("@Connectwithledger", connectwithledger));
            paramCollection.Add(new DBParameter("@Organisation", objconmaster.Organisation));
            paramCollection.Add(new DBParameter("@MobileNo", objconmaster.MobileNo));
            paramCollection.Add(new DBParameter("@Email", objconmaster.Email));
            paramCollection.Add(new DBParameter("@TypeofTrade", objconmaster.TypeofTrade));
            paramCollection.Add(new DBParameter("@Group", objconmaster.Group));
            paramCollection.Add(new DBParameter("@Area", objconmaster.Area));
            paramCollection.Add(new DBParameter("@Department", objconmaster.Department));
            paramCollection.Add(new DBParameter("@SpecifyDateofBirth", specifydob));
            paramCollection.Add(new DBParameter("@SpecifyDateofAnniversary", specifydateofanniversary));
            paramCollection.Add(new DBParameter("@CreatedBy", objconmaster.CreatedBy));
            paramCollection.Add(new DBParameter("@Address", objconmaster.Address));
            paramCollection.Add(new DBParameter("@Address1", objconmaster.Address1));
            paramCollection.Add(new DBParameter("@Address2", objconmaster.Address2));
            paramCollection.Add(new DBParameter("@Address3", objconmaster.Address3));
            paramCollection.Add(new DBParameter("@PhoneNo", objconmaster.PhoneNo));
            paramCollection.Add(new DBParameter("@AFaxNo", objconmaster.FaxNo));


            Query = "INSERT INTO CONTACTMASTER (`Name`,`Alias`,`PrintName`,`Connectwithledger`,`Organisation`,`MobileNo`,`Email`,`TypeofTrade`,`Group`,"+
                "`Area`,`Department`,`SpecifyDateofBirth`,`SpecifyDateofAnniversary`,`Address`,`Address1`,`Address2`,`Address3`,`PhoneNo`,`FaxNo`) "+
                "VALUES (@Name,@Alias,@PrintName,@Connectwithledger,@Organisation,@MobileNo,@Email,@TypeofTrade,@Group,@Area,@Department,@SpecifyDateofBirth,"+
                "@SpecifyDateofAnniversary,@Address,@Address1,@Address2,@Address3,@PhoneNo,@FaxNo)";
          
            return _dbHelper.ExecuteNonQuery(Query,paramCollection) > 0;                  
        }
        #endregion
        
    }

}
