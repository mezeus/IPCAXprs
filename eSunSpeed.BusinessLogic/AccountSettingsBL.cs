using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;
using System.Data;

namespace eSunSpeed.BusinessLogic
{
    public class AccountSettingsBL
    {
        private DBHelper _dbHelper = new DBHelper();

        #region Save Account Settings
        /// <summary>
        /// </summary>
        /// <param name="objAccountGrp"></param>
        /// <returns>True/False</returns>
        public bool SaveAccountingSetting(eSunSpeedDomain.AccountSettingsModel objAccountSett)
        {
            string Query = string.Empty;           

            DBParameterCollection paramCollection = new DBParameterCollection();
            
            paramCollection.Add(new DBParameter("@Billbybill", objAccountSett.Billbybilldetails, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@creditlimits", objAccountSett.creditlimits, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@targets", objAccountSett.targets, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@costcenters", objAccountSett.costcenters, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@fbtreport", objAccountSett.fbtreporting, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@bankrecon", objAccountSett.bankreconcilations, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@postdated", objAccountSett.postdatedcheques, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@salesman", objAccountSett.saleswisemanbrokerwisereporting, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@budgets", objAccountSett.budgets, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@royalatycal", objAccountSett.royaltycalculation, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@companyact", objAccountSett.companyactdepreciation, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@multicurrency", objAccountSett.multicurrency, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@decimalplac",objAccountSett.currencycondecimalplaces ));
            paramCollection.Add(new DBParameter("@maitainsubled", objAccountSett.maintainsubledgers, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@postingaccounts", objAccountSett.postingaccountssalespurchasereturn, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@doubleentery", objAccountSett.doubleentrysystemforpaymentreceiptvoucher, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@showaccountbal", objAccountSett.showaccountscurrentbalduringvoucher, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@maintainimages", objAccountSett.maintainimagenotes, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@balancesheet", objAccountSett.balancesheetstockupdate));
            paramCollection.Add(new DBParameter("@ledgerrecon", objAccountSett.ledgerreconciliation, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@chekprinting", objAccountSett.chequeprinting, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@interestrate", objAccountSett.accountwiseinterstrate, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@enableparty", objAccountSett.enablepartydashboard, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@showparydashbord", objAccountSett.showpartydashboardselectingpartyvoucher, System.Data.DbType.Boolean));
            //paramCollection.Add(new DBParameter("@companyact", objAccountSett.CreatedBy));


            Query = "INSERT INTO accountsettings (`billbybilldetails`,`creditlimits`,`targets`,`costcenters`,`fbtreporting`,`bankreconcilations`,"+
                "`postdatedcheques`,`saleswisemanbrokerwisereporting`,`budgets`,`royaltycalculation`,`companyactdepreciation`,"+
                "`multicurrency`,`currencycondecimalplaces`,`maintainsubledgers`,`postingaccountssalespurchasereturn`,`doubleentrysystemforpaymentreceiptvoucher`,"+
                "`showaccountscurrentbalduringvoucher`,`maintainimagenotes`,`balancesheetstockupdate`,`ledgerreconciliation`,`chequeprinting`,`accountwiseinterstrate`,"+
                "`enablepartydashboard`,`showpartydashboardselectingpartyvoucher`) " +
                "VALUES (@Billbybill,@creditlimits,@targets,@costcenters,@fbtreport,@bankrecon,@postdated,@salesman,@budgets,@royalatycal,@companyact,@multicurrency,"+
                "@decimalplac,@maitainsubled,@postingaccounts,@doubleentery,@showaccountbal,@maintainimages,@balancesheet,@ledgerrecon,@chekprinting,@interestrate,@enableparty,@showparydashbord)";

            return _dbHelper.ExecuteNonQuery(Query,paramCollection) > 0;                  
        }
        #endregion
        
    }

}
