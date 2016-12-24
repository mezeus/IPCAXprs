using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;
using System.Data;

namespace eSunSpeed.BusinessLogic
{
    public class AccountMasterBL
    {
        private DBHelper _dbHelper = new DBHelper();

        #region Save Account Group
        /// <summary>
        /// Save Account Group
        /// </summary>
        /// <param name="objAccountGrp"></param>
        /// <returns>True/False</returns>
        public bool SaveAccountGroup(AccountGroupModel objAccountGrp)
        {
            string Query = string.Empty;           

            DBParameterCollection paramCollection = new DBParameterCollection();
            
            paramCollection.Add(new DBParameter("@GroupName", objAccountGrp.GroupName));
            paramCollection.Add(new DBParameter("@AliasName", objAccountGrp.AliasName));
            paramCollection.Add(new DBParameter("@Primary", objAccountGrp.Primary=="Yes"?1:0));
            paramCollection.Add(new DBParameter("@UnderGroup", objAccountGrp.UnderGroup));
            paramCollection.Add(new DBParameter("@NatureGroup", objAccountGrp.NatureGroup));
            paramCollection.Add(new DBParameter("@IsAffectGrossProfit", objAccountGrp.IsAffectGrossProfit?1:0,DbType.Int16));
            paramCollection.Add(new DBParameter("@CreatedBy", objAccountGrp.CreatedBy));
                       
            Query = "INSERT INTO AccountGroups(GroupName,AliasName,`Primary`,UnderGroup,NatureGroup,IsAffectGrossProfit,CreatedBy) VALUES (@GroupName,@AliasName,@Primary,@UnderGroup,@NatureGroup,@IsAffectGrossProfit,@CreatedBy)";

            return _dbHelper.ExecuteNonQuery(Query,paramCollection) > 0;                  
        }
        #endregion

        #region Update Account Master
        /// <summary>
        /// Update Account
        /// </summary>
        /// <param name="objAcctMaster"></param>
        /// <returns>True/False</returns>
        public bool UpdateAccount(AccountMasterModel objAcctMaster)
        {
            string Query = string.Empty;

            DBParameterCollection paramCollection = new DBParameterCollection();
            
            paramCollection.Add(new DBParameter("@Acc_DbName", "zAKIR"));
            paramCollection.Add(new DBParameter("@ACC_NAME", objAcctMaster.AccountName));
            paramCollection.Add(new DBParameter("@ACC_SHORTNAME",objAcctMaster.ShortName));
            paramCollection.Add(new DBParameter("@ACC_PRINTNAME", objAcctMaster.PrintName));
            paramCollection.Add(new DBParameter("@ACC_LedgerType", objAcctMaster.LedgerType));

            paramCollection.Add(new DBParameter("@ACC_MultiCurr", objAcctMaster.MultiCurrency,System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ACC_Group", objAcctMaster.Group));
            paramCollection.Add(new DBParameter("@ACC_OpBal", objAcctMaster.OPBal,System.Data.DbType.Int32));
            paramCollection.Add(new DBParameter("@ACC_PrevYearBal", objAcctMaster.PrevYearBal));
            paramCollection.Add(new DBParameter("@ACC_DrCrOpenBal", objAcctMaster.DrCrOpeningBal));


            paramCollection.Add(new DBParameter("@ACC_DrCrPrevBal", objAcctMaster.DrCrOpeningBal));
            paramCollection.Add(new DBParameter("@ACC_MaintainBitwise", objAcctMaster.MaintainBillwiseAccounts,System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ACC_ActivateInterestCal", objAcctMaster.ActivateInterestCal,System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ACC_CreditDays", objAcctMaster.CreditDays));
            paramCollection.Add(new DBParameter("@ACC_CreditLimit", objAcctMaster.CreditLimit));

            paramCollection.Add(new DBParameter("@ACC_TypeofBuissness", objAcctMaster.TypeofBuissness));
            paramCollection.Add(new DBParameter("@ACC_Transport", objAcctMaster.Transport));
            paramCollection.Add(new DBParameter("@ACC_Station", objAcctMaster.Station));
            paramCollection.Add(new DBParameter("@ACC_SpecifyDefaultSaleType", objAcctMaster.specifyDefaultSaleType,System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ACC_DefaultSaleType", objAcctMaster.DefaultSaleType));

            paramCollection.Add(new DBParameter("@ACC_FreezeSaleType", objAcctMaster.FreezeSaleType));
            paramCollection.Add(new DBParameter("@ACC_SpecifyDefaultPurType", objAcctMaster.SpecifyDefaultPurType,System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ACC_DefaultPurcType", objAcctMaster.DefaultPurcType));
            paramCollection.Add(new DBParameter("@ACC_LockSalesType", objAcctMaster.LockSalesType,System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ACC_LockPurcType", objAcctMaster.LockPurchaseType,System.Data.DbType.Boolean));

            paramCollection.Add(new DBParameter("@ACC_address1", objAcctMaster.address1));
            paramCollection.Add(new DBParameter("@ACC_address2", objAcctMaster.address2));
            paramCollection.Add(new DBParameter("@ACC_Address3", objAcctMaster.address3));

            paramCollection.Add(new DBParameter("@ACC_Address4", objAcctMaster.address4));
            paramCollection.Add(new DBParameter("@ACC_State", objAcctMaster.State));

            paramCollection.Add(new DBParameter("@ACC_TelephoneNumber", objAcctMaster.TelephoneNumber));
            paramCollection.Add(new DBParameter("@ACC_Fax", objAcctMaster.Fax));
            paramCollection.Add(new DBParameter("@ACC_MobileNumber", objAcctMaster.MobileNumber));
            paramCollection.Add(new DBParameter("@ACC_email", objAcctMaster.email));
            paramCollection.Add(new DBParameter("@ACC_Website", objAcctMaster.WebSite));

            paramCollection.Add(new DBParameter("@ACC_enablemailquery", objAcctMaster.enablemailquery,System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ACC_enableSMSquery", objAcctMaster.enableSMSquery,System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ACC_contactperson", objAcctMaster.contactperson));
            paramCollection.Add(new DBParameter("@ACC_ITPanNumber", objAcctMaster.ITPanNumber));
            paramCollection.Add(new DBParameter("@ACC_LSTNumber", objAcctMaster.LstNumber));

            paramCollection.Add(new DBParameter("@ACC_CSTNumber", objAcctMaster.CSTNumber));
            paramCollection.Add(new DBParameter("@ACC_TIN", objAcctMaster.TIN));
            paramCollection.Add(new DBParameter("@ACC_ServiceTax", objAcctMaster.ServiceTaxNumber));
            paramCollection.Add(new DBParameter("@ACC_BankAccountNumber", objAcctMaster.BankAccountNumber));
            paramCollection.Add(new DBParameter("@ACC_IECode", objAcctMaster.IECode));

            paramCollection.Add(new DBParameter("@ACC_CreatedBy", "admin"));
            paramCollection.Add(new DBParameter("@ACC_DEFAULT_CHEQUE_FORMAT", ""));
            paramCollection.Add(new DBParameter("@ENABLE_CHEQUE_PRINTING", true,System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ACC_Cheque_PrintName", objAcctMaster.ChequePrintName));
            paramCollection.Add(new DBParameter("@AC_Id", objAcctMaster.AccountId));

            //todo: NEED TO FIX UPDATE
            Query =
            "UPDATE AccountMaster SET [Acc_DbName]=@Acc_DbName,[ACC_NAME]=@ACC_NAME,[ACC_SHORTNAME]=@ACC_SHORTNAME,[ACC_PRINTNAME]=@ACC_PRINTNAME,[ACC_LedgerType]=@ACC_LedgerType,[ACC_MultiCurr]=@ACC_MultiCurr,[ACC_Group]=@ACC_Group,[ACC_OpBal]=@ACC_OpBal," +
                            "[ACC_PrevYearBal]=@ACC_PrevYearBal,[ACC_DrCrOpenBal]=@ACC_DrCrOpenBal,[ACC_DrCrPrevBal]=@ACC_DrCrPrevBal,[ACC_MaintainBitwise]=@ACC_MaintainBitwise,[ACC_ActivateInterestCal]=@ACC_ActivateInterestCal,[ACC_CreditDays]=@ACC_CreditDays, " +
                            "[ACC_CreditLimit]=@ACC_CreditLimit,[ACC_TypeofBuissness]=@ACC_TypeofBuissness,[ACC_Transport]=@ACC_Transport,[ACC_Station]=@ACC_Station,[ACC_SpecifyDefaultSaleType]=@ACC_SpecifyDefaultSaleType,[ACC_DefaultSaleType]=@ACC_DefaultSaleType,"+
                            "[ACC_FreezeSaleType]=@ACC_FreezeSaleType,[ACC_SpecifyDefaultPurType]=@ACC_SpecifyDefaultPurType,[ACC_DefaultPurcType]=@ACC_DefaultPurcType,[ACC_LockSalesType]=@ACC_LockSalesType,[ACC_LockPurcType]=@ACC_LockPurcType,[ACC_address1]=@ACC_address1," +
                            "[ACC_address2]=@ACC_address2,[ACC_Address3]=@ACC_Address3,[ACC_Address4]=@ACC_Address4,[ACC_State]=@ACC_State,[ACC_TelephoneNumber]=@ACC_TelephoneNumber,[ACC_Fax]=@ACC_Fax,[ACC_MobileNumber]=@ACC_MobileNumber,[ACC_email]=@ACC_email,[ACC_Website]=@ACC_Website,"+
                            "[ACC_enablemailquery]=@ACC_enablemailquery,[ACC_enableSMSquery]=@ACC_enableSMSquery,[ACC_contactperson]=@ACC_contactperson,[ACC_ITPanNumber]=@ACC_ITPanNumber,[ACC_LSTNumber]=@ACC_LSTNumber,[ACC_CSTNumber]=@ACC_CSTNumber,[ACC_TIN]=@ACC_TIN," +
                            "[ACC_ServiceTax]=@ACC_ServiceTax,[ACC_BankAccountNumber]=@ACC_BankAccountNumber,[ACC_IECode]=@ACC_IECode,[ACC_CreatedBy]=@ACC_CreatedBy,[ACC_DEFAULT_CHEQUE_FORMAT]=@ACC_DEFAULT_CHEQUE_FORMAT,[ENABLE_CHEQUE_PRINTING]=@ENABLE_CHEQUE_PRINTING,[ACC_Cheque_PrintName]=@ACC_Cheque_PrintName " +
                            " WHERE [AC_Id]=@Ac_Id";
            

            return _dbHelper.ExecuteNonQuery(Query, paramCollection) > 0;

         }
        #endregion

        #region Save Account Master
        /// <summary>
        /// Save Account
        /// </summary>
        /// <param name="objAcctMaster"></param>
        /// <returns>True/False</returns>
        public bool SaveAccount(AccountMasterModel objAcctMaster)
        {
            string Query = string.Empty;

            DBParameterCollection paramCollection = new DBParameterCollection();

            paramCollection.Add(new DBParameter("@Acc_DbName", "SunSpped"));
            paramCollection.Add(new DBParameter("@ACC_NAME", objAcctMaster.AccountName));
            paramCollection.Add(new DBParameter("@ACC_SHORTNAME", objAcctMaster.ShortName));
            paramCollection.Add(new DBParameter("@ACC_PRINTNAME", objAcctMaster.PrintName));
            paramCollection.Add(new DBParameter("@ACC_LedgerType", objAcctMaster.LedgerType));

            paramCollection.Add(new DBParameter("@ACC_MultiCurr", objAcctMaster.MultiCurrency, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ACC_Group", objAcctMaster.Group));
            paramCollection.Add(new DBParameter("@ACC_OpBal", objAcctMaster.OPBal, System.Data.DbType.Int32));
            paramCollection.Add(new DBParameter("@ACC_PrevYearBal", objAcctMaster.PrevYearBal));
            paramCollection.Add(new DBParameter("@ACC_DrCrOpenBal", objAcctMaster.DrCrOpeningBal));


            paramCollection.Add(new DBParameter("@ACC_DrCrPrevBal", objAcctMaster.DrCrOpeningBal));
            paramCollection.Add(new DBParameter("@ACC_MaintainBitwise", objAcctMaster.MaintainBillwiseAccounts, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ACC_ActivateInterestCal", objAcctMaster.ActivateInterestCal, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ACC_CreditDays", objAcctMaster.CreditDays));
            paramCollection.Add(new DBParameter("@ACC_CreditLimit", objAcctMaster.CreditLimit));

            paramCollection.Add(new DBParameter("@ACC_TypeofBuissness", objAcctMaster.TypeofBuissness));
            paramCollection.Add(new DBParameter("@ACC_Transport", objAcctMaster.Transport));
            paramCollection.Add(new DBParameter("@ACC_Station", objAcctMaster.Station));
            paramCollection.Add(new DBParameter("@ACC_SpecifyDefaultSaleType", objAcctMaster.specifyDefaultSaleType, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ACC_DefaultSaleType", objAcctMaster.DefaultSaleType));

            paramCollection.Add(new DBParameter("@ACC_FreezeSaleType", objAcctMaster.FreezeSaleType));
            paramCollection.Add(new DBParameter("@ACC_SpecifyDefaultPurType", objAcctMaster.SpecifyDefaultPurType, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ACC_DefaultPurcType", objAcctMaster.DefaultPurcType));
            paramCollection.Add(new DBParameter("@ACC_LockSalesType", objAcctMaster.LockSalesType, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ACC_LockPurcType", objAcctMaster.LockPurchaseType, System.Data.DbType.Boolean));

            paramCollection.Add(new DBParameter("@ACC_address1", objAcctMaster.address1));
            paramCollection.Add(new DBParameter("@ACC_address2", objAcctMaster.address2));
            paramCollection.Add(new DBParameter("@ACC_Address3", objAcctMaster.address3));
            paramCollection.Add(new DBParameter("@ACC_Address4", objAcctMaster.address4));
            paramCollection.Add(new DBParameter("@ACC_State", objAcctMaster.State));

            paramCollection.Add(new DBParameter("@ACC_TelephoneNumber", objAcctMaster.TelephoneNumber));
            paramCollection.Add(new DBParameter("@ACC_Fax", objAcctMaster.Fax));
            paramCollection.Add(new DBParameter("@ACC_MobileNumber", objAcctMaster.MobileNumber));
            paramCollection.Add(new DBParameter("@ACC_email", objAcctMaster.email));
            paramCollection.Add(new DBParameter("@ACC_Website", objAcctMaster.WebSite));

            paramCollection.Add(new DBParameter("@ACC_enablemailquery", objAcctMaster.enablemailquery, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ACC_enableSMSquery", objAcctMaster.enableSMSquery, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ACC_contactperson", objAcctMaster.contactperson));
            paramCollection.Add(new DBParameter("@ACC_ITPanNumber", objAcctMaster.ITPanNumber));
            paramCollection.Add(new DBParameter("@ACC_LSTNumber", objAcctMaster.LstNumber));

            paramCollection.Add(new DBParameter("@ACC_CSTNumber", objAcctMaster.CSTNumber));
            paramCollection.Add(new DBParameter("@ACC_TIN", objAcctMaster.TIN));
            paramCollection.Add(new DBParameter("@ACC_ServiceTax", objAcctMaster.ServiceTaxNumber));
            paramCollection.Add(new DBParameter("@ACC_BankAccountNumber", objAcctMaster.BankAccountNumber));
            paramCollection.Add(new DBParameter("@ACC_IECode", objAcctMaster.IECode));

            paramCollection.Add(new DBParameter("@ACC_CreatedBy", "admin"));
            paramCollection.Add(new DBParameter("@ACC_DEFAULT_CHEQUE_FORMAT", ""));
            paramCollection.Add(new DBParameter("@ENABLE_CHEQUE_PRINTING", true, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ACC_Cheque_PrintName", objAcctMaster.ChequePrintName));


            Query =
            "INSERT INTO accountmaster (`Acc_DbName`,`ACC_NAME`,`ACC_SHORTNAME`,`ACC_PRINTNAME`,`ACC_LedgerType`,`ACC_MultiCurr`,`ACC_Group`,`ACC_OpBal`," +
                            "`ACC_PrevYearBal`,`ACC_DrCrOpenBal`,`ACC_DrCrPrevBal`,`ACC_MaintainBitwise`,`ACC_ActivateInterestCal`,`ACC_CreditDays`,`ACC_CreditLimit`,`ACC_TypeofBuissness`," +
                            "`ACC_Transport`,`ACC_Station`,`ACC_SpecifyDefaultSaleType`,`ACC_DefaultSaleType`,`ACC_FreezeSaleType`,`ACC_SpecifyDefaultPurType`,`ACC_DefaultPurcType`," +
                            "`ACC_LockSalesType`,`ACC_LockPurcType`,`ACC_address1`,`ACC_address2`,`ACC_Address3`,`ACC_Address4`,`ACC_State`,`ACC_TelephoneNumber,`ACC_Fax`,`ACC_MobileNumber`," +
                            "`ACC_email`,`ACC_Website`,`ACC_enablemailquery`,`ACC_enableSMSquery`,`ACC_contactperson`,`ACC_ITPanNumber`,`ACC_LSTNumber`,`ACC_CSTNumber`,`ACC_TIN`," +
                            "`ACC_ServiceTax`,`ACC_BankAccountNumber`,`ACC_IECode`,`ACC_CreatedBy`,`ACC_DEFAULT_CHEQUE_FORMAT`,`ENABLE_CHEQUE_PRINTING`,`ACC_Cheque_PrintName`)" +
                            "VALUES(@Acc_DbName,@ACC_NAME,@ACC_SHORTNAME,@ACC_PRINTNAME,@ACC_LedgerType,@ACC_MultiCurr,@ACC_Group,@ACC_OpBal,@ACC_PrevYearBal,@ACC_DrCrOpenBal," +
                            "@ACC_DrCrPrevBal,@ACC_MaintainBitwise,@ACC_ActivateInterestCal,@ACC_CreditDays,@ACC_CreditLimit,@ACC_TypeofBuissness," +
                            "@ACC_Transport,@ACC_Station,@ACC_SpecifyDefaultSaleType,@ACC_DefaultSaleType,@ACC_FreezeSaleType,@ACC_SpecifyDefaultPurType,@ACC_DefaultPurcType," +
                            "@ACC_LockSalesType,@ACC_LockPurcType,@ACC_address1,@ACC_address2,@ACC_Address3,@ACC_Address4,@ACC_State,@ACC_TelephoneNumber,@ACC_Fax,@ACC_MobileNumber," +
                            "@ACC_email,@ACC_Website,@ACC_enablemailquery,@ACC_enableSMSquery,@ACC_contactperson,@ACC_ITPanNumber,@ACC_LSTNumber,@ACC_CSTNumber,@ACC_TIN," +
                            "@ACC_ServiceTax,@ACC_BankAccountNumber,@ACC_IECode,@ACC_CreatedBy,@ACC_DEFAULT_CHEQUE_FORMAT,@ENABLE_CHEQUE_PRINTING,@ACC_Cheque_PrintName)";


            return _dbHelper.ExecuteNonQuery(Query, paramCollection) > 0;

        }
        #endregion

        #region Get List of Account Groups
        /// <summary>
        /// List of Account Groups
        /// </summary>
        /// <returns>List of Groups</returns>
        public List<eSunSpeedDomain.AccountGroupModel> GetListofAccountsGroups()
        {
            List<eSunSpeedDomain.AccountGroupModel> lstAccountGroups = new List<eSunSpeedDomain.AccountGroupModel>();
            eSunSpeedDomain.AccountGroupModel accountGroup;

            string Query = "SELECT DISTINCT AG_ID,GroupName,AliasName,`primary`, UnderGroup FROM `AccountGroups`";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                accountGroup = new eSunSpeedDomain.AccountGroupModel();

                accountGroup.GroupId = Convert.ToInt32(dr["AG_ID"]);
                //accountGroup.CanDelete = Convert.ToBoolean(dr["CanDelete"]); 
                accountGroup.GroupName = dr["GroupName"].ToString();
                accountGroup.AliasName = dr["AliasName"].ToString();
                accountGroup.UnderGroup = dr["UnderGroup"].ToString();
                accountGroup.Primary = dr["Primary"].ToString();

                lstAccountGroups.Add(accountGroup);

            }
              
            return lstAccountGroups;

        }

        #endregion  

        #region Verify Account Group Exists
        /// <summary>
        /// Verify Group Exists
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns>True/False</returns>
        public bool IsGroupExists(string groupName)
        {
            StringBuilder _sbQuery = new StringBuilder();
            _sbQuery.AppendFormat("SELECT COUNT(*) FROM AccountGroups WHERE Groupname='{0}'", groupName);

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(_sbQuery.ToString(), _dbHelper.GetConnObject());
            dr.Read();
            if (Convert.ToInt32(dr[0]) > 0)
                return true;
            else
                return false;

        }
        #endregion

        #region Verify Account already Exists
        /// <summary>
        /// Verify Group Exists
        /// </summary>
        /// <param name="Account Name"></param>
        /// <returns>True/False</returns>
        public bool IsAccountExists(string Saletype)
        {
            StringBuilder _sbQuery = new StringBuilder();
            _sbQuery.AppendFormat("SELECT COUNT(*) FROM AccountMaster WHERE ACC_NAME='{0}'", Saletype);

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(_sbQuery.ToString(), _dbHelper.GetConnObject());
            dr.Read();
            if (Convert.ToInt32(dr[0]) > 0)
                return true;
            else
                return false;

        }
        #endregion

        #region Modify Account Group
        /// <summary>
        /// Modified Account Group
        /// </summary>
        /// <param name="objAccountGroup"></param>
        /// <returns>True/False</returns>
        public bool UpdateAccountGroup(eSunSpeedDomain.AccountGroupModel objAccountGrp)
        {
            string Query = string.Empty;
            bool isUpdated = true;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();


                paramCollection.Add(new DBParameter("@GroupName", objAccountGrp.GroupName));
                paramCollection.Add(new DBParameter("@AliasName", objAccountGrp.AliasName));
                paramCollection.Add(new DBParameter("@Primary", objAccountGrp.Primary == "Yes" ? 1 : 0));
                paramCollection.Add(new DBParameter("@UnderGroup", objAccountGrp.UnderGroup));
                paramCollection.Add(new DBParameter("@NatureGroup", objAccountGrp.NatureGroup));
                paramCollection.Add(new DBParameter("@IsAffectGrossProfit", objAccountGrp.IsAffectGrossProfit ? 1 : 0, DbType.Int16));
                paramCollection.Add(new DBParameter("@ModifiedBy", objAccountGrp.ModifiedBy));

                paramCollection.Add(new DBParameter("@GroupId", objAccountGrp.GroupId));

                Query = "UPDATE AccountGroups SET GroupName=@GroupName,AliasName=@AliasName,`Primary`=@Primary,UnderGroup=@UnderGroup,NatureGroup=@NatureGroup,IsAffectGrossProfit=@IsAffectGrossProfit,ModifiedBy=@ModifiedBy " +
                        "WHERE AG_ID=@GroupId";



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
        #endregion

        #region Delete Account Group/s
        /// <summary>
        /// Modified Account Group
        /// </summary>
        /// <param name="objAccountGroup"></param>
        /// <returns>True/False</returns>
        public bool DeletAccountGroup(List<int> groupdIds)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection;

                foreach (int groupid in groupdIds)
                {
                    paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@GroupId",groupid));
                    Query = "Delete from AccountGroups WHERE [AG_ID]=@GroupId";

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

        #region Delete Account/s
        /// <summary>
        /// Modified Account Group
        /// </summary>
        /// <param name="objAccountGroup"></param>
        /// <returns>True/False</returns>
        public bool DeletAccount(List<int> accountIds)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection;

                foreach (int accountid in accountIds)
                {
                    paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@acountid", accountid));
                    Query = "Delete from AccountMaster WHERE [Ac_ID]=@accountid";

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

        #region Get List of Accounts
 
        //public DataTable GetAccounts()
        //{
        //    try
        //    {
        //        string Query = "SELECT * from ACCOUNTMaster";
        //        System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());
        //        DataTable dt = new DataTable();
              
        //    }
        //    catch
        //    {

        //    }
                
        //    return dr;
        //}
        public List<eSunSpeedDomain.AccountMasterModel> GetListofAccount()
        {
            List<AccountMasterModel> lstAccountMaster = new List<AccountMasterModel>();
            AccountMasterModel _acctMaster;

            try {
                string Query = "SELECT * from ACCOUNTMaster";
                System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

                while (dr.Read())
                {
                    //Initialize/reset account master object
                    _acctMaster = new AccountMasterModel();

                    _acctMaster.AccountId = Convert.ToInt32(dr["Ac_ID"]);
                    _acctMaster.AccountName = dr["ACC_NAME"].ToString();
                    _acctMaster.ShortName = dr["ACC_SHORTNAME"].ToString();
                    _acctMaster.PrintName = dr["ACC_PRINTNAME"].ToString();
                    _acctMaster.LedgerType = dr["ACC_LedgerType"].ToString();
                    _acctMaster.MultiCurrency = Convert.ToBoolean(dr["ACC_MultiCurr"])?true:false;
                    _acctMaster.Group = dr["ACC_Group"].ToString();
                    _acctMaster.OPBal = dr["ACC_OpBal"].ToString() == "" ? 0 : Convert.ToInt32(dr["ACC_OpBal"].ToString());
                   // _acctMaster.PrevYearBal = dr["ACC_PrevYearBal"].ToString();
                    _acctMaster.DrCrOpeningBal = dr["ACC_DrCrOpenBal"].ToString();
                    _acctMaster.DrCrPrevBal = dr["ACC_DrCrPrevBal"].ToString();
                    _acctMaster.MaintainBillwiseAccounts = Convert.ToBoolean(dr["ACC_MaintainBitwise"])? true : false;

                    _acctMaster.ActivateInterestCal = Convert.ToBoolean(dr["ACC_ActivateInterestCal"]) == false ? false : true;
                    _acctMaster.CreditDays = dr["ACC_CreditDays"].ToString();
                    _acctMaster.CreditLimit = dr["ACC_CreditLimit"].ToString();
                    _acctMaster.TypeofDealer = dr["ACC_TypeofDealer"].ToString();
                    _acctMaster.TypeofBuissness = dr["ACC_TypeofBuissness"].ToString();
                    _acctMaster.Transport = dr["ACC_Transport"].ToString();
                    _acctMaster.Station = dr["ACC_Station"].ToString();
                    _acctMaster.specifyDefaultSaleType = Convert.ToBoolean(dr["ACC_SpecifyDefaultSaleType"]) == false ? false : true;
                    _acctMaster.DefaultSaleType = dr["ACC_DefaultSaleType"].ToString();
                   // _acctMaster.FreezeSaleType = dr["ACC_FreezeSaleType"].ToString();
                    _acctMaster.SpecifyDefaultPurType = Convert.ToBoolean(dr["ACC_SpecifyDefaultPurType"]) == false ? false : true;

                    _acctMaster.LockSalesType = Convert.ToBoolean(dr["ACC_LockSalesType"]) == false ? false : true;
                    _acctMaster.LockPurchaseType = Convert.ToBoolean(dr["ACC_LockPurcType"]) == false ? false : true;
                    _acctMaster.address1 = dr["ACC_address1"].ToString();
                    _acctMaster.address2 = dr["ACC_address2"].ToString();
                    _acctMaster.address3 = dr["ACC_Address3"].ToString();
                    _acctMaster.Transport = dr["ACC_Address4"].ToString();
                    _acctMaster.Station = dr["ACC_State"].ToString();
                    _acctMaster.TelephoneNumber = dr["ACC_TelephoneNumber"].ToString();
                    _acctMaster.Fax = dr["ACC_Fax"].ToString();
                 //   _acctMaster.FreezeSaleType = dr["ACC_MobileNumber"].ToString();
                    _acctMaster.email = dr["ACC_email"].ToString();

                    _acctMaster.WebSite = dr["ACC_Website"].ToString();
                    _acctMaster.enablemailquery = Convert.ToBoolean(dr["ACC_enablemailquery"]) == false ? false : true;
                    _acctMaster.enableSMSquery = Convert.ToBoolean(dr["ACC_enableSMSquery"]) == false ? false : true;
                   // _acctMaster.address2 = dr["ACC_address2"].ToString();
                    //_acctMaster.address3 = dr["ACC_Address3"].ToString();
                    //_acctMaster.address4 = dr["ACC_Address4"].ToString();
                    _acctMaster.State = dr["ACC_State"].ToString();
                    _acctMaster.TelephoneNumber = dr["ACC_TelephoneNumber"].ToString();
                    _acctMaster.Fax = dr["ACC_Fax"].ToString();
                    _acctMaster.MobileNumber = dr["ACC_MobileNumber"].ToString();
                    _acctMaster.email = dr["ACC_email"].ToString();

                    _acctMaster.contactperson = dr["ACC_contactperson"].ToString();
                    _acctMaster.ITPanNumber = dr["ACC_ITPanNumber"].ToString();
                    _acctMaster.LstNumber = dr["ACC_LSTNumber"].ToString();
                    _acctMaster.CSTNumber = dr["ACC_CSTNumber"].ToString();
                    _acctMaster.TIN = dr["ACC_TIN"].ToString();
                    _acctMaster.ServiceTaxNumber = dr["ACC_ServiceTax"].ToString();
                    _acctMaster.LBTNumber = dr["ACC_LBTNumber"].ToString();
                    _acctMaster.BankAccountNumber = dr["ACC_BankAccountNumber"].ToString();
                    _acctMaster.IECode = dr["ACC_IECode"].ToString();

                    lstAccountMaster.Add(_acctMaster);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return lstAccountMaster;
        }
        #endregion
        public AccountMasterModel GetListofAccountByAccountName(string accountname)
        {           
            AccountMasterModel _acctMaster=new AccountMasterModel();
            
            try
            {
                
                string Query = "SELECT * from ACCOUNTMaster WHERE ACC_NAME='" + accountname +"'";
                System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());
               
                while (dr.Read())
                {
                                      
                    _acctMaster.AccountId = Convert.ToInt32(dr["Ac_ID"]);
                    _acctMaster.AccountName = dr["ACC_NAME"].ToString();
                    _acctMaster.ShortName = dr["ACC_SHORTNAME"].ToString();
                    _acctMaster.PrintName = dr["ACC_PRINTNAME"].ToString();
                    _acctMaster.LedgerType = dr["ACC_LedgerType"].ToString();
                    _acctMaster.MultiCurrency = Convert.ToBoolean(dr["ACC_MultiCurr"]) ? true : false;
                    _acctMaster.Group = dr["ACC_Group"].ToString();
                    _acctMaster.OPBal = dr["ACC_OpBal"].ToString() == "" ? 0 : Convert.ToInt32(dr["ACC_OpBal"].ToString());
                    // _acctMaster.PrevYearBal = dr["ACC_PrevYearBal"].ToString();
                    _acctMaster.DrCrOpeningBal = dr["ACC_DrCrOpenBal"].ToString();
                    _acctMaster.DrCrPrevBal = dr["ACC_DrCrPrevBal"].ToString();
                    _acctMaster.MaintainBillwiseAccounts = Convert.ToBoolean(dr["ACC_MaintainBitwise"]) ? true : false;

                    _acctMaster.ActivateInterestCal = Convert.ToBoolean(dr["ACC_ActivateInterestCal"]) == false ? false : true;
                    _acctMaster.CreditDays = dr["ACC_CreditDays"].ToString();
                    _acctMaster.CreditLimit = dr["ACC_CreditLimit"].ToString();
                    _acctMaster.TypeofDealer = dr["ACC_TypeofDealer"].ToString();
                    _acctMaster.TypeofBuissness = dr["ACC_TypeofBuissness"].ToString();
                    _acctMaster.Transport = dr["ACC_Transport"].ToString();
                    _acctMaster.Station = dr["ACC_Station"].ToString();
                    _acctMaster.specifyDefaultSaleType = Convert.ToBoolean(dr["ACC_SpecifyDefaultSaleType"]) == false ? false : true;
                    _acctMaster.DefaultSaleType = dr["ACC_DefaultSaleType"].ToString();
                   // _acctMaster.FreezeSaleType = dr["ACC_FreezeSaleType"].ToString();
                    _acctMaster.SpecifyDefaultPurType = Convert.ToBoolean(dr["ACC_SpecifyDefaultPurType"]) == false ? false : true;

                    _acctMaster.LockSalesType = Convert.ToBoolean(dr["ACC_LockSalesType"]) == false ? false : true;
                    _acctMaster.LockPurchaseType = Convert.ToBoolean(dr["ACC_LockPurcType"]) == false ? false : true;
                    _acctMaster.address1 = dr["ACC_address1"].ToString();
                    _acctMaster.address2 = dr["ACC_address2"].ToString();
                    _acctMaster.address3 = dr["ACC_Address3"].ToString();
                    _acctMaster.Transport = dr["ACC_Address4"].ToString();
                    _acctMaster.Station = dr["ACC_State"].ToString();
                    _acctMaster.TelephoneNumber = dr["ACC_TelephoneNumber"].ToString();
                    _acctMaster.Fax = dr["ACC_Fax"].ToString();
                   // _acctMaster.FreezeSaleType = dr["ACC_MobileNumber"].ToString();
                    _acctMaster.email = dr["ACC_email"].ToString();

                    _acctMaster.WebSite = dr["ACC_Website"].ToString();
                    _acctMaster.enablemailquery = Convert.ToBoolean(dr["ACC_enablemailquery"]) == false ? false : true;
                    _acctMaster.enableSMSquery = Convert.ToBoolean(dr["ACC_enableSMSquery"]) == false ? false : true;
                    // _acctMaster.address2 = dr["ACC_address2"].ToString();
                    //_acctMaster.address3 = dr["ACC_Address3"].ToString();
                    //_acctMaster.address4 = dr["ACC_Address4"].ToString();
                    _acctMaster.State = dr["ACC_State"].ToString();
                    _acctMaster.TelephoneNumber = dr["ACC_TelephoneNumber"].ToString();
                    _acctMaster.Fax = dr["ACC_Fax"].ToString();
                    _acctMaster.MobileNumber = dr["ACC_MobileNumber"].ToString();
                    _acctMaster.email = dr["ACC_email"].ToString();

                    _acctMaster.contactperson = dr["ACC_contactperson"].ToString();
                    _acctMaster.ITPanNumber = dr["ACC_ITPanNumber"].ToString();
                    _acctMaster.LstNumber = dr["ACC_LSTNumber"].ToString();
                    _acctMaster.CSTNumber = dr["ACC_CSTNumber"].ToString();
                    _acctMaster.TIN = dr["ACC_TIN"].ToString();
                    _acctMaster.ServiceTaxNumber = dr["ACC_ServiceTax"].ToString();
                    _acctMaster.LBTNumber = dr["ACC_LBTNumber"].ToString();
                    _acctMaster.BankAccountNumber = dr["ACC_BankAccountNumber"].ToString();
                    _acctMaster.IECode = dr["ACC_IECode"].ToString();                 
                }
            }
            catch (Exception ex)
            { 
                throw ex;
            }

            return _acctMaster;
        }

        #region Get Account Group by Group Id
        /// <summary>
        /// Get Account Groups
        /// </summary>
        /// <returns>Get Groups</returns>
        public AccountGroupModel GetAccountGroupByGroupId(int groupId)
        {
            AccountGroupModel accountGroup = new AccountGroupModel();

            string Query = "SELECT  AG_ID,GroupName,AliasName,`primary`, UnderGroup,NatureGroup,IsAffectGrossProfit FROM `AccountGroups` where AG_Id="+groupId;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {               
                accountGroup.GroupId = Convert.ToInt32(dr["AG_ID"]);
                //accountGroup.CanDelete = Convert.ToBoolean(dr["CanDelete"]); 
                accountGroup.GroupName = dr["GroupName"].ToString();
                accountGroup.AliasName = dr["AliasName"].ToString();
                accountGroup.UnderGroup = dr["UnderGroup"].ToString();
                accountGroup.Primary = dr["Primary"].ToString();
                accountGroup.NatureGroup = dr["NatureGroup"].ToString();
                accountGroup.IsAffectGrossProfit = Convert.ToBoolean( dr["IsAffectGrossProfit"]);

            }

            return accountGroup;

        }

        #endregion  
    }

}
