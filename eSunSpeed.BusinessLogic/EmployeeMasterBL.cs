using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;
using System.Data;

namespace eSunSpeed.BusinessLogic
{
    public class EmployeeMasterBL
    {
        private DBHelper _dbHelper = new DBHelper();

        
        #region Save Employee Master
        /// <summary>
        /// Save Employee
        /// </summary>
        /// <param name="objEmpMaster"></param>
        /// <returns>True/False</returns>
        public bool SaveEmployeeMaster(EmployeeMasterModel objEmpMaster)
        {
            string Query = string.Empty;

            DBParameterCollection paramCollection = new DBParameterCollection();

            //paramCollection.Add(new DBParameter("@Acc_DbName", "SunSpped"));
            paramCollection.Add(new DBParameter("@Emp_NAME", objEmpMaster.EmployeeName));
            paramCollection.Add(new DBParameter("@Emp_CODE", objEmpMaster.EmployeeCode));
            paramCollection.Add(new DBParameter("@Emp_SHORTNAME", objEmpMaster.ShortName));
            paramCollection.Add(new DBParameter("@Emp_PRINTNAME", objEmpMaster.PrintName));
            paramCollection.Add(new DBParameter("@Emp_Group", objEmpMaster.Group));

            paramCollection.Add(new DBParameter("@Emp_Dest", objEmpMaster.Designation));
            paramCollection.Add(new DBParameter("@Emp_Fname", objEmpMaster.FatherName));
            paramCollection.Add(new DBParameter("@Emo_Sname", objEmpMaster.SpouseName));
            paramCollection.Add(new DBParameter("@Emp_address", objEmpMaster.Address));
            paramCollection.Add(new DBParameter("@Emp_address1", objEmpMaster.Address1));
            paramCollection.Add(new DBParameter("@Emp_address2", objEmpMaster.Address2));
            paramCollection.Add(new DBParameter("@Emp_Address3", objEmpMaster.Address3));
            paramCollection.Add(new DBParameter("@Emp_Dob", objEmpMaster.DateofBirth,System.Data.DbType.DateTime));
            paramCollection.Add(new DBParameter("@Emp_Gender", objEmpMaster.Gender));
            paramCollection.Add(new DBParameter("@Emp_MobileNumber", objEmpMaster.MobileNumber));
            paramCollection.Add(new DBParameter("@Emp_TelephoneNumber", objEmpMaster.TelephoneNumber));
            paramCollection.Add(new DBParameter("@Emp_email", objEmpMaster.email));
            paramCollection.Add(new DBParameter("@Emp_ITPanNumber", objEmpMaster.ITpan));
            paramCollection.Add(new DBParameter("@Emp_doj", objEmpMaster.DateofJoining, System.Data.DbType.DateTime));
            paramCollection.Add(new DBParameter("@Emp_curstatus", objEmpMaster.CurrentStatus));
            paramCollection.Add(new DBParameter("@Emp_lastdate", objEmpMaster.LastWorkingDate, System.Data.DbType.DateTime));
            paramCollection.Add(new DBParameter("@Emp_pf",objEmpMaster.PFNo));
            paramCollection.Add(new DBParameter("@Emp_esi", objEmpMaster.ESIInsurance));
            paramCollection.Add(new DBParameter("@Emp_Bonus", objEmpMaster.BonusApplicable));
            paramCollection.Add(new DBParameter("@Emp_emailquery", objEmpMaster.EmailQuery));
            paramCollection.Add(new DBParameter("@Emp_smsquery", objEmpMaster.SMSQuery));
            paramCollection.Add(new DBParameter("@Emp_conta", objEmpMaster.Contactperson));
            paramCollection.Add(new DBParameter("@Emp_ward", objEmpMaster.Ward));
            paramCollection.Add(new DBParameter("@Emp_lst", objEmpMaster.LSTNo));
            paramCollection.Add(new DBParameter("@Emp_cst", objEmpMaster.CSTNo));
            paramCollection.Add(new DBParameter("@Emp_tin", objEmpMaster.TIN));
            paramCollection.Add(new DBParameter("@Emp_lbt", objEmpMaster.LBTNo));
            paramCollection.Add(new DBParameter("@Emp_servicetax", objEmpMaster.ServiceTaxNo));
            paramCollection.Add(new DBParameter("@Emp_iecode", objEmpMaster.IECode));
            paramCollection.Add(new DBParameter("@Emp_dlno", objEmpMaster.DLNo1));
            paramCollection.Add(new DBParameter("@Emp_chPrintname", objEmpMaster.PrintName));




            Query =
            "INSERT INTO employeemaster (`EmployeeCode`,`Name`,`ShortName`,`PrintName`,`Group`,`Destination`,`FatherName`,`SpouseName`," +
                            "`Address`,`Address1`,`Address2`,`Address3`,`DateofBirth`,`Gender`,`Mobile`," +
                            "`Phone`,`Email`,`ITPAN`,`DateofJoin`,`CurrentStatus`,`LastworkingDate`,`PFNo`," +
                            "`ESINo`,`BonusApplication`,`EmailQuery`,`SMSQuery`,`ContactPerson`,`Ward`,`LSTNo.`,`CSTNo`,`TIN`,`LBTNo`," +
                            "`ServiceTaxNo`,`IECode`,`DLNo`,`ChequePrintName`)" +
                            "VALUES(@Emp_CODE,@Emp_NAME,@Emp_SHORTNAME,@Emp_PRINTNAME,@Emp_Group,@Emp_Dest,@Emp_Fname,@Emo_Sname,@Emp_address," +
                            "@Emp_address1,@Emp_address2,@Emp_address3,@Emp_Dob,@Emp_Gender,@Emp_MobileNumber," +
                            "@Emp_TelephoneNumber,@Emp_email,@Emp_ITPanNumber,@Emp_doj,@Emp_curstatus,@Emp_lastdate,@Emp_pf," +
                            "@Emp_esi,@Emp_Bonus,@Emp_emailquery,@Emp_smsquery,@Emp_conta,@Emp_ward,@Emp_lst,@Emp_cst,@Emp_tin,@Emp_lbt," +
                            "@Emp_servicetax,@Emp_iecode,@Emp_dlno,@Emp_chPrintname)";
                            


            return _dbHelper.ExecuteNonQuery(Query, paramCollection) > 0;

        }
        #endregion

        public List<eSunSpeedDomain.EmployeeMasterModel> GetListofallEmployees()
        {
            List<eSunSpeedDomain.EmployeeMasterModel> lstallemployees = new List<eSunSpeedDomain.EmployeeMasterModel>();
            eSunSpeedDomain.EmployeeMasterModel objemployees;

            string Query = "SELECT * FROM `employeemaster`";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objemployees = new eSunSpeedDomain.EmployeeMasterModel();

                objemployees.EmployeeId = Convert.ToInt32(dr["Em_ID"]);
                objemployees.EmployeeCode = Convert.ToInt32(dr["EmployeeCode"] == "" ? "0" : dr["EmployeeCode"]);
                objemployees.EmployeeName = dr["Name"].ToString();               
                objemployees.Group = dr["Group"].ToString();
                objemployees.DateofJoining = Convert.ToDateTime(dr["DateofJoin"]);

                lstallemployees.Add(objemployees);

            }
            return lstallemployees;
        }

        public EmployeeMasterModel GetListofallEmployeesById(int id)
        {
            EmployeeMasterModel objemployees = new EmployeeMasterModel();

            string Query = "SELECT * FROM `employeemaster` WHERE Em_ID="+id+"";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objemployees.EmployeeId = Convert.ToInt32(dr["Em_ID"]);
                objemployees.EmployeeCode = Convert.ToInt32(dr["EmployeeCode"].ToString() == "" ? "0" : dr["EmployeeCode"]);
                objemployees.EmployeeName = dr["Name"].ToString();
                objemployees.PrintName = dr["PrintName"].ToString();
                objemployees.Group = dr["Group"].ToString();
                objemployees.Designation = dr["Destination"].ToString();
                objemployees.FatherName = dr["FatherName"].ToString();
                objemployees.SpouseName = dr["SpouseName"].ToString();
                objemployees.Address = dr["Address"].ToString();
                objemployees.DateofBirth = Convert.ToDateTime(dr["DateofBirth"]);
                objemployees.Gender = dr["Gender"].ToString();
                objemployees.MobileNumber =Convert.ToInt32(dr["Mobile"].ToString()==""?"0":dr["Mobile"].ToString());
                objemployees.TelephoneNumber = Convert.ToInt32(dr["Phone"].ToString() == "" ? "0" : dr["Phone"].ToString());
                objemployees.email = dr["Email"].ToString()==""?string.Empty:dr["Email"].ToString();
                objemployees.ITpan = dr["ITPAN"].ToString() == "" ? string.Empty : dr["ITPAN"].ToString();
                objemployees.DateofJoining = Convert.ToDateTime(dr["DateofJoin"]);
                objemployees.CurrentStatus = dr["CurrentStatus"].ToString();
                objemployees.LastWorkingDate = Convert.ToDateTime(dr["LastworkingDate"]);
                objemployees.PFNo = dr["PFNo"].ToString();
                objemployees.ESIInsurance = dr["ESINo"].ToString();
                objemployees.BonusApplicable = dr["BonusApplication"].ToString();
                objemployees.EmailQuery = dr["EmailQuery"].ToString();
                objemployees.SMSQuery = dr["SMSQuery"].ToString();
                objemployees.Contactperson = dr["ContactPerson"].ToString();
                objemployees.Ward = dr["Ward"].ToString();
                objemployees.LSTNo = dr["LSTNo."].ToString();
                objemployees.CSTNo = dr["CSTNo"].ToString();
                objemployees.TIN = dr["TIN"].ToString();
                objemployees.LBTNo = dr["LBTNo"].ToString();
                objemployees.ServiceTaxNo = dr["ServiceTaxNo"].ToString();
                objemployees.IECode = dr["IECode"].ToString();
                objemployees.DLNo1 = dr["DLNo"].ToString();
                objemployees.ChequePrintName = dr["ChequePrintName"].ToString();

            }
            return objemployees;
        }
    }

}
