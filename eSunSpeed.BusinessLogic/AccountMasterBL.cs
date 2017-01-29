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
        AccountModel objaccmod = new AccountModel();
        private DBHelper _dbHelper = new DBHelper();
        private CommandType paramCollection;

        public string Query { get; private set; }

        #region Save Account Group
        /// <summary>
        /// Save Account Group
        /// </summary>
        /// <param name="objAccountGrp"></param>
        /// <returns>True/False</returns>
        public bool SaveAccountGroup(AccountGroupModel objAccountGrp)
        {
            AccountMasterBL objaccbl = new AccountMasterBL();
            string Query = string.Empty;           

            DBParameterCollection paramCollection = new DBParameterCollection();
            
            paramCollection.Add(new DBParameter("@GroupName", objAccountGrp.GroupName));
            paramCollection.Add(new DBParameter("@AliasName", objAccountGrp.AliasName));
            paramCollection.Add(new DBParameter("@Primary", objAccountGrp.Primary,System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@UnderGroupId", objAccountGrp.UnderGroupId));
            paramCollection.Add(new DBParameter("@UnderGroup", objAccountGrp.UnderGroup));
            paramCollection.Add(new DBParameter("@NatureGroup", objAccountGrp.NatureGroup));
            paramCollection.Add(new DBParameter("@IsAffectGrossProfit", objAccountGrp.IsAffectGrossProfit,System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@CreatedBy", objAccountGrp.CreatedBy));
                       
            Query = "INSERT INTO accountgroups(`GroupName`,`AliasName`,`Primary`,`UndergroupID`,`UnderGroup`,`NatureGroup`,`IsAffectGrossProfit`,`CreatedBy`) VALUES (@GroupName,@AliasName,@Primary,@UnderGroupId,@UnderGroup,@NatureGroup,@IsAffectGrossProfit,@CreatedBy)";

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
            bool isUpdate = false;
            DBParameterCollection paramCollection = new DBParameterCollection();
            paramCollection.Add(new DBParameter("@ACC_ID", objAcctMaster.AccountId));
            paramCollection.Add(new DBParameter("@ACC_NAME", objAcctMaster.AccountName));
            paramCollection.Add(new DBParameter("@ACC_SHORTNAME", objAcctMaster.ShortName));
            paramCollection.Add(new DBParameter("@ACC_PRINTNAME", objAcctMaster.PrintName));
            paramCollection.Add(new DBParameter("@ACC_LedgerType", objAcctMaster.LedgerType));

            paramCollection.Add(new DBParameter("@ACC_MultiCurr", objAcctMaster.MultiCurrency ? 1 : 0, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ACC_Group", objAcctMaster.Group));
            paramCollection.Add(new DBParameter("@ACC_OpBal", objAcctMaster.OPBal, DbType.Decimal));
            paramCollection.Add(new DBParameter("@ACC_PrevYearBal", objAcctMaster.PrevYearBal, DbType.Decimal));
            paramCollection.Add(new DBParameter("@ACC_DrCrOpenBal", objAcctMaster.DrCrOpeningBal));
            paramCollection.Add(new DBParameter("@ACC_DrCrPrevBal", objAcctMaster.DrCrPrevBal));
            paramCollection.Add(new DBParameter("@ACC_DefineCreditLimit", objAcctMaster.DefineCrLimit, DbType.Boolean));
            paramCollection.Add(new DBParameter("@ACC_CreditLimit", objAcctMaster.MaxCredit));

            paramCollection.Add(new DBParameter("@ACC_MaintainBitwise", objAcctMaster.MaintainBillwiseAccounts ? 1 : 0));
            paramCollection.Add(new DBParameter("@ACC_AllocateAmountItems", objAcctMaster.AllocateAmountItems, System.Data.DbType.Boolean));
            paramCollection.Add(new DBParameter("@ACC_ActivateInterestCal", objAcctMaster.ActivateInterestCal ? 1 : 0));
            paramCollection.Add(new DBParameter("@ACC_CreditDays_ForSale", objAcctMaster.CreditDaysforSale));
            paramCollection.Add(new DBParameter("@ACC_CreditDays_ForPurch", objAcctMaster.CreditDaysforPurchase));

            //paramCollection.Add(new DBParameter("@ACC_TypeofBuissness", objAcctMaster.TypeofBuissness));
            paramCollection.Add(new DBParameter("@ACC_Transport", objAcctMaster.Transport));
            paramCollection.Add(new DBParameter("@ACC_Station", objAcctMaster.Station));
            paramCollection.Add(new DBParameter("@ACC_SpecifyDefaultSaleType", objAcctMaster.specifyDefaultSaleType ? 1 : 0));
            paramCollection.Add(new DBParameter("@ACC_DefaultSaleType", objAcctMaster.DefaultSaleType));
            paramCollection.Add(new DBParameter("@ACC_FreezeSaleType", objAcctMaster.FreezeSaleType ? 1 : 0));

            paramCollection.Add(new DBParameter("@ACC_SpecifyDefaultPurType", objAcctMaster.SpecifyDefaultPurType ? 1 : 0));
            paramCollection.Add(new DBParameter("@ACC_DefaultPurcType", objAcctMaster.DefaultPurcType));
            paramCollection.Add(new DBParameter("@ACC_FreezePurcType", objAcctMaster.FreezePurcType, System.Data.DbType.Boolean));

            paramCollection.Add(new DBParameter("@ACC_LockSalesType", objAcctMaster.LockSalesType ? 1 : 0));
            paramCollection.Add(new DBParameter("@ACC_LockPurcType", objAcctMaster.LockPurchaseType ? 1 : 0));

            paramCollection.Add(new DBParameter("@ACC_InterestRatePayable", objAcctMaster.InterestRatePayable, DbType.Decimal));
            paramCollection.Add(new DBParameter("@ACC_InterestRateReceivable", objAcctMaster.InterestRateReceivable, DbType.Decimal));

            paramCollection.Add(new DBParameter("@ACC_SpecifyDefaultSM", objAcctMaster.SpecifyDefaultSM, DbType.Boolean));
            paramCollection.Add(new DBParameter("@ACC_SalesMan", objAcctMaster.SalesMan));
            paramCollection.Add(new DBParameter("@ACC_freezeSalesMan", objAcctMaster.freezeSalesMan, DbType.Boolean));
            paramCollection.Add(new DBParameter("@ACC_DefaultCommission", objAcctMaster.DefaultCommission, DbType.Boolean));
            paramCollection.Add(new DBParameter("@ACC_CommissionMode", objAcctMaster.CommissionMode));
            paramCollection.Add(new DBParameter("@ACC_CommissionPercentage", objAcctMaster.CommissionPercentage, DbType.Decimal));
            paramCollection.Add(new DBParameter("@ACC_FreezeCommission", objAcctMaster.FreezeCommission, DbType.Boolean));

            paramCollection.Add(new DBParameter("@ACC_address1", objAcctMaster.address));
            paramCollection.Add(new DBParameter("@ACC_address2", objAcctMaster.address1));
            paramCollection.Add(new DBParameter("@ACC_Address3", objAcctMaster.address2));
            paramCollection.Add(new DBParameter("@ACC_Address4", objAcctMaster.address3));
            paramCollection.Add(new DBParameter("@ACC_Area", objAcctMaster.area));
            paramCollection.Add(new DBParameter("@ACC_State", objAcctMaster.State));
            paramCollection.Add(new DBParameter("@ACC_TelephoneNumber", objAcctMaster.TelephoneNumber));
            paramCollection.Add(new DBParameter("@ACC_Fax", objAcctMaster.Fax));
            paramCollection.Add(new DBParameter("@ACC_MobileNumber", objAcctMaster.MobileNumber));
            paramCollection.Add(new DBParameter("@ACC_email", objAcctMaster.email));
            paramCollection.Add(new DBParameter("@ACC_Website", objAcctMaster.WebSite));

            paramCollection.Add(new DBParameter("@ACC_enablemailquery", objAcctMaster.enablemailquery ? 1 : 0));
            paramCollection.Add(new DBParameter("@ACC_enableSMSquery", objAcctMaster.enableSMSquery ? 1 : 0));
            paramCollection.Add(new DBParameter("@ACC_contactperson", objAcctMaster.contactperson));
            paramCollection.Add(new DBParameter("@ACC_ITPanNumber", objAcctMaster.ITPanNumber));
            paramCollection.Add(new DBParameter("@ACC_Ward", objAcctMaster.Ward));
            paramCollection.Add(new DBParameter("@ACC_LstNumber", objAcctMaster.LstNumber));
            paramCollection.Add(new DBParameter("@ACC_CSTNumber", objAcctMaster.CSTNumber));
            paramCollection.Add(new DBParameter("@ACC_TIN", objAcctMaster.TIN));
            paramCollection.Add(new DBParameter("@ACC_LBTNumber", objAcctMaster.LBTNumber));
            paramCollection.Add(new DBParameter("@ACC_ServiceTax", objAcctMaster.ServiceTaxNumber));
            paramCollection.Add(new DBParameter("@ACC_IECode", objAcctMaster.IECode));
            paramCollection.Add(new DBParameter("@ACC_DLNo", objAcctMaster.DLNO1));
            paramCollection.Add(new DBParameter("@ACC_DLNo1", objAcctMaster.No1));
            paramCollection.Add(new DBParameter("@ACC_BankAccountNumber", objAcctMaster.BankAccountNumber));
            paramCollection.Add(new DBParameter("@ACC_Cheque_PrintName", objAcctMaster.ChequePrintName));

            paramCollection.Add(new DBParameter("@ACC_DefineBudgets", objAcctMaster.DefineBudgets, DbType.Boolean));
            paramCollection.Add(new DBParameter("@ACC_AnnualBudgets", objAcctMaster.AnnualBudgets, DbType.Decimal));
            paramCollection.Add(new DBParameter("@ACC_JanuaryBd", objAcctMaster.JanuaryBd, DbType.Decimal));
            paramCollection.Add(new DBParameter("@ACC_FebruaryBd", objAcctMaster.FebruaryBd, DbType.Decimal));
            paramCollection.Add(new DBParameter("@ACC_MarchBd", objAcctMaster.MarchBd, DbType.Decimal));
            paramCollection.Add(new DBParameter("@ACC_AprilBd", objAcctMaster.AprilBd, DbType.Decimal));
            paramCollection.Add(new DBParameter("@ACC_MayBd", objAcctMaster.MayBd, DbType.Decimal));
            paramCollection.Add(new DBParameter("@ACC_JuneBd", objAcctMaster.JuneBd, DbType.Decimal));
            paramCollection.Add(new DBParameter("@ACC_JulyBd", objAcctMaster.JulyBd, DbType.Decimal));
            paramCollection.Add(new DBParameter("@ACC_AugustBd", objAcctMaster.AugustBd, DbType.Decimal));
            paramCollection.Add(new DBParameter("@ACC_SeptemberBd", objAcctMaster.SeptemberBd, DbType.Decimal));
            paramCollection.Add(new DBParameter("@ACC_OctoberBd", objAcctMaster.OctoberBd, DbType.Decimal));
            paramCollection.Add(new DBParameter("@ACC_NovemberBd", objAcctMaster.NovemberBd, DbType.Decimal));
            paramCollection.Add(new DBParameter("@ACC_DecemberBd", objAcctMaster.DecemberBd, DbType.Decimal));

            paramCollection.Add(new DBParameter("@ACC_ModifiedBy", "admin"));
            paramCollection.Add(new DBParameter("@ACC_ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));

            System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spUpdateAccountMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
            isUpdate = true;
            //UPDATE Cost Center Popup Grid
            List<CostcenterPopupModel> lstCost = new List<CostcenterPopupModel>();   
            foreach (CostcenterPopupModel objCost in objAcctMaster.CostcenterDetails)
            {
                objCost.ParentId = objAcctMaster.AccountId;
                if (objCost.CCId > 0)
                {
                    paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@ParentId", (objCost.ParentId)));
                    paramCollection.Add(new DBParameter("@CostCentre", objCost.Costcenter));
                    paramCollection.Add(new DBParameter("@Amount", objCost.Amount, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@DC", objCost.DC));
                    paramCollection.Add(new DBParameter("@ShortNarration", objCost.Shortnarration));
                    paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                    paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@CostcenterId", objCost.CCId));
                    System.Data.IDataReader drcurr =
               _dbHelper.ExecuteDataReader("spUpdateAccountCostCentreDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    isUpdate = true;
                }
                else
                {
                    paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@AccountId", objCost.ParentId));
                    paramCollection.Add(new DBParameter("@CostCentre", objCost.Costcenter));
                    paramCollection.Add(new DBParameter("@Amount", objCost.Amount, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@DC", objCost.DC));
                    paramCollection.Add(new DBParameter("@ShortNarration", objCost.Shortnarration));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));

                    System.Data.IDataReader drcurr =
                   _dbHelper.ExecuteDataReader("spinsertAccountCostCentreDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    isUpdate = true;
                }
            }
            //Update Bill By Bill Details Popup Grid
            List<MaintainBillbyBillModel> lstBill = new List<MaintainBillbyBillModel>();
            foreach (MaintainBillbyBillModel BillbyBill in objAcctMaster.BillbyBillDetails)
            {
                BillbyBill.ParentId = objAcctMaster.AccountId;
                if (BillbyBill.BillId > 0)
                {
                    paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Parent_Id",BillbyBill.ParentId));
                    paramCollection.Add(new DBParameter("@BillbybillId", BillbyBill.BillId));
                    paramCollection.Add(new DBParameter("@Reference", BillbyBill.Reference));
                    paramCollection.Add(new DBParameter("@Salesman", BillbyBill.Salesman));
                    paramCollection.Add(new DBParameter("@Date", BillbyBill.Dated, System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@Amount", BillbyBill.Amount, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@DC", BillbyBill.DC));
                    paramCollection.Add(new DBParameter("@Duedate", BillbyBill.Duedate, System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@GroupName", BillbyBill.Group));
                    paramCollection.Add(new DBParameter("@Narration", BillbyBill.Narration));
                    paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                    paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));
                    
                        System.Data.IDataReader drBill =
               _dbHelper.ExecuteDataReader("spUpdateBillbybilldetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    isUpdate = true;
                }
                else
                {
                    paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Parent_Id", BillbyBill.ParentId));
                    paramCollection.Add(new DBParameter("@Reference", BillbyBill.Reference));
                    paramCollection.Add(new DBParameter("@Salesman", BillbyBill.Salesman));
                    paramCollection.Add(new DBParameter("@Date", BillbyBill.Dated, System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@Amount", BillbyBill.Amount, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@DC", BillbyBill.DC));
                    paramCollection.Add(new DBParameter("@Duedate", BillbyBill.Duedate, System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@GroupName", BillbyBill.Group));
                    paramCollection.Add(new DBParameter("@Narration", BillbyBill.Narration));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));

                    System.Data.IDataReader drbill =
                    _dbHelper.ExecuteDataReader("spinsertbillbybilldetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    isUpdate = true;
                }
            }
            //Update Cheque Deposite Details popup Grid
            List<UnclearedChecqueDetailsModel> lstDeposite = new List<UnclearedChecqueDetailsModel>();
            foreach (UnclearedChecqueDetailsModel objDeposites in objAcctMaster.ChequesDeposites)
            {
                objDeposites.ParentId = objAcctMaster.AccountId;
                if (objDeposites.id > 0)
                {
                    paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@ParentId", objDeposites.ParentId));
                    paramCollection.Add(new DBParameter("@DepositId", objDeposites.id));
                    paramCollection.Add(new DBParameter("@Date", objDeposites.Date, System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@VchNo", objDeposites.Vchno));
                    paramCollection.Add(new DBParameter("@Account", objDeposites.Account));
                    paramCollection.Add(new DBParameter("@Amount", objDeposites.Amount, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ShortNarration", objDeposites.Shortnarration));
                    paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                    paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));
                    System.Data.IDataReader drDP =
                    _dbHelper.ExecuteDataReader("spUpdateAcccheqDeposited", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    isUpdate = true;
                }
                else
                {
                    paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@ParentId", objDeposites.ParentId));
                    paramCollection.Add(new DBParameter("@Date", objDeposites.Date, System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@VchNo", objDeposites.Vchno));
                    paramCollection.Add(new DBParameter("@Account", objDeposites.Account));
                    paramCollection.Add(new DBParameter("@Amount", objDeposites.Amount, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ShortNarration", objDeposites.Shortnarration));
                    paramCollection.Add(new DBParameter("@Createdby", "Admin"));
                    paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));

                    System.Data.IDataReader drdp =
                    _dbHelper.ExecuteDataReader("spinsertAcccheqDeposited", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    isUpdate = true;
                }
            }
            //Update Cheque Issued Details popup Grid
            List<UnclearedChecqueDetailsModel> lstIssued = new List<UnclearedChecqueDetailsModel>();
            foreach (UnclearedChecqueDetailsModel objIssued in objAcctMaster.ChequesIssued)
            {
                objIssued.ParentId = objAcctMaster.AccountId;
                if (objIssued.id > 0)
                {
                    paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@ParentId", objIssued.ParentId));
                    paramCollection.Add(new DBParameter("@AccIssuedId", objIssued.id));
                    paramCollection.Add(new DBParameter("@Date", objIssued.Date, System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@VchNo", objIssued.Vchno));
                    paramCollection.Add(new DBParameter("@Account", objIssued.Account));
                    paramCollection.Add(new DBParameter("@Amount", objIssued.Amount, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ShortNarration", objIssued.Shortnarration));
                    paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                    paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));
                    System.Data.IDataReader drCI =
                    _dbHelper.ExecuteDataReader("spUpdateAcccheqIssued", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    isUpdate = true;
                }
                else
                {
                    paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@ParentId", objIssued.ParentId));
                    paramCollection.Add(new DBParameter("@Date", objIssued.Date, System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@VchNo", objIssued.Vchno));
                    paramCollection.Add(new DBParameter("@Account", objIssued.Account));
                    paramCollection.Add(new DBParameter("@Amount", objIssued.Amount, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@Shortnarration", objIssued.Shortnarration));
                    paramCollection.Add(new DBParameter("@Createdby", "Admin"));
                    paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));

                    System.Data.IDataReader drCI =
                    _dbHelper.ExecuteDataReader("spinsertUnclearedChequeissued", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    isUpdate = true;
                }
            }
            return isUpdate;
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
            try
            {
                string Query = string.Empty;
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ACC_NAME", objAcctMaster.AccountName));
                paramCollection.Add(new DBParameter("@ACC_SHORTNAME", objAcctMaster.ShortName));
                paramCollection.Add(new DBParameter("@ACC_PRINTNAME", objAcctMaster.PrintName));
                paramCollection.Add(new DBParameter("@ACC_LedgerType", objAcctMaster.LedgerType));

                paramCollection.Add(new DBParameter("@ACC_MultiCurr", objAcctMaster.MultiCurrency?1:0, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ACC_Group", objAcctMaster.Group));
                paramCollection.Add(new DBParameter("@ACC_OpBal", objAcctMaster.OPBal, DbType.Decimal));
                paramCollection.Add(new DBParameter("@ACC_PrevYearBal", objAcctMaster.PrevYearBal, DbType.Decimal));
                paramCollection.Add(new DBParameter("@ACC_DrCrOpenBal", objAcctMaster.DrCrOpeningBal));
                paramCollection.Add(new DBParameter("@ACC_DrCrPrevBal", objAcctMaster.DrCrPrevBal));
                paramCollection.Add(new DBParameter("@ACC_DefineCreditLimit", objAcctMaster.DefineCrLimit,DbType.Boolean));
                paramCollection.Add(new DBParameter("@ACC_CreditLimit", objAcctMaster.MaxCredit));

                paramCollection.Add(new DBParameter("@ACC_MaintainBitwise", objAcctMaster.MaintainBillwiseAccounts ? 1 : 0));
                paramCollection.Add(new DBParameter("@ACC_AllocateAmountItems", objAcctMaster.AllocateAmountItems,System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ACC_ActivateInterestCal", objAcctMaster.ActivateInterestCal ? 1 : 0));
                paramCollection.Add(new DBParameter("@ACC_CreditDays_ForSale", objAcctMaster.CreditDaysforSale));
                paramCollection.Add(new DBParameter("@ACC_CreditDays_ForPurch", objAcctMaster.CreditDaysforPurchase));

                //paramCollection.Add(new DBParameter("@ACC_TypeofBuissness", objAcctMaster.TypeofBuissness));
                paramCollection.Add(new DBParameter("@ACC_Transport", objAcctMaster.Transport));
                paramCollection.Add(new DBParameter("@ACC_Station", objAcctMaster.Station));
                paramCollection.Add(new DBParameter("@ACC_SpecifyDefaultSaleType", objAcctMaster.specifyDefaultSaleType ? 1 : 0));
                paramCollection.Add(new DBParameter("@ACC_DefaultSaleType", objAcctMaster.DefaultSaleType));
                paramCollection.Add(new DBParameter("@ACC_FreezeSaleType", objAcctMaster.FreezeSaleType ? 1 : 0));

                paramCollection.Add(new DBParameter("@ACC_SpecifyDefaultPurType", objAcctMaster.SpecifyDefaultPurType ? 1 : 0));
                paramCollection.Add(new DBParameter("@ACC_DefaultPurcType", objAcctMaster.DefaultPurcType));
                paramCollection.Add(new DBParameter("@ACC_FreezePurcType", objAcctMaster.FreezePurcType,System.Data.DbType.Boolean));
        
                paramCollection.Add(new DBParameter("@ACC_LockSalesType", objAcctMaster.LockSalesType ? 1 : 0));
                paramCollection.Add(new DBParameter("@ACC_LockPurcType", objAcctMaster.LockPurchaseType ? 1 : 0));

                paramCollection.Add(new DBParameter("@ACC_InterestRatePayable", objAcctMaster.InterestRatePayable, DbType.Decimal));
                paramCollection.Add(new DBParameter("@ACC_InterestRateReceivable", objAcctMaster.InterestRateReceivable, DbType.Decimal));

                paramCollection.Add(new DBParameter("@ACC_SpecifyDefaultSM", objAcctMaster.SpecifyDefaultSM,DbType.Boolean));
                paramCollection.Add(new DBParameter("@ACC_SalesMan", objAcctMaster.SalesMan));
                paramCollection.Add(new DBParameter("@ACC_freezeSalesMan", objAcctMaster.freezeSalesMan, DbType.Boolean));
                paramCollection.Add(new DBParameter("@ACC_DefaultCommission", objAcctMaster.DefaultCommission,DbType.Boolean));
                paramCollection.Add(new DBParameter("@ACC_CommissionMode", objAcctMaster.CommissionMode));
                paramCollection.Add(new DBParameter("@ACC_CommissionPercentage", objAcctMaster.CommissionPercentage, DbType.Decimal));
                paramCollection.Add(new DBParameter("@ACC_FreezeCommission", objAcctMaster.FreezeCommission, DbType.Boolean));

                paramCollection.Add(new DBParameter("@ACC_address1", objAcctMaster.address));
                paramCollection.Add(new DBParameter("@ACC_address2", objAcctMaster.address1));
                paramCollection.Add(new DBParameter("@ACC_Address3", objAcctMaster.address2));
                paramCollection.Add(new DBParameter("@ACC_Address4", objAcctMaster.address3));
                paramCollection.Add(new DBParameter("@ACC_Area", objAcctMaster.area));
                paramCollection.Add(new DBParameter("@ACC_State", objAcctMaster.State));
                paramCollection.Add(new DBParameter("@ACC_TelephoneNumber", objAcctMaster.TelephoneNumber));
                paramCollection.Add(new DBParameter("@ACC_Fax", objAcctMaster.Fax));
                paramCollection.Add(new DBParameter("@ACC_MobileNumber", objAcctMaster.MobileNumber));
                paramCollection.Add(new DBParameter("@ACC_email", objAcctMaster.email));
                paramCollection.Add(new DBParameter("@ACC_Website", objAcctMaster.WebSite));

                paramCollection.Add(new DBParameter("@ACC_enablemailquery", objAcctMaster.enablemailquery ? 1 : 0));
                paramCollection.Add(new DBParameter("@ACC_enableSMSquery", objAcctMaster.enableSMSquery ? 1 : 0));
                paramCollection.Add(new DBParameter("@ACC_contactperson", objAcctMaster.contactperson));
                paramCollection.Add(new DBParameter("@ACC_ITPanNumber", objAcctMaster.ITPanNumber));
                paramCollection.Add(new DBParameter("@ACC_Ward", objAcctMaster.Ward));
                paramCollection.Add(new DBParameter("@ACC_LstNumber", objAcctMaster.LstNumber));
                paramCollection.Add(new DBParameter("@ACC_CSTNumber", objAcctMaster.CSTNumber));
                paramCollection.Add(new DBParameter("@ACC_TIN", objAcctMaster.TIN));
                paramCollection.Add(new DBParameter("@ACC_LBTNumber", objAcctMaster.LBTNumber));
                paramCollection.Add(new DBParameter("@ACC_ServiceTax", objAcctMaster.ServiceTaxNumber));
                paramCollection.Add(new DBParameter("@ACC_IECode", objAcctMaster.IECode));
                paramCollection.Add(new DBParameter("@ACC_DLNo", objAcctMaster.DLNO1));
                paramCollection.Add(new DBParameter("@ACC_DLNo1", objAcctMaster.No1));
                paramCollection.Add(new DBParameter("@ACC_BankAccountNumber", objAcctMaster.BankAccountNumber));
                paramCollection.Add(new DBParameter("@ACC_Cheque_PrintName", objAcctMaster.ChequePrintName));

                paramCollection.Add(new DBParameter("@ACC_DefineBudgets", objAcctMaster.DefineBudgets, DbType.Boolean));
                paramCollection.Add(new DBParameter("@ACC_AnnualBudgets", objAcctMaster.AnnualBudgets, DbType.Decimal));
                paramCollection.Add(new DBParameter("@ACC_JanuaryBd", objAcctMaster.JanuaryBd, DbType.Decimal));
                paramCollection.Add(new DBParameter("@ACC_FebruaryBd", objAcctMaster.FebruaryBd, DbType.Decimal));
                paramCollection.Add(new DBParameter("@ACC_MarchBd", objAcctMaster.MarchBd, DbType.Decimal));
                paramCollection.Add(new DBParameter("@ACC_AprilBd", objAcctMaster.AprilBd, DbType.Decimal));
                paramCollection.Add(new DBParameter("@ACC_MayBd", objAcctMaster.MayBd, DbType.Decimal));
                paramCollection.Add(new DBParameter("@ACC_JuneBd", objAcctMaster.JuneBd, DbType.Decimal));
                paramCollection.Add(new DBParameter("@ACC_JulyBd", objAcctMaster.JulyBd, DbType.Decimal));
                paramCollection.Add(new DBParameter("@ACC_AugustBd", objAcctMaster.AugustBd, DbType.Decimal));
                paramCollection.Add(new DBParameter("@ACC_SeptemberBd", objAcctMaster.SeptemberBd, DbType.Decimal));
                paramCollection.Add(new DBParameter("@ACC_OctoberBd", objAcctMaster.OctoberBd, DbType.Decimal));
                paramCollection.Add(new DBParameter("@ACC_NovemberBd", objAcctMaster.NovemberBd, DbType.Decimal));
                paramCollection.Add(new DBParameter("@ACC_DecemberBd", objAcctMaster.DecemberBd, DbType.Decimal));

                paramCollection.Add(new DBParameter("@ACC_CreatedBy", "admin"));
                paramCollection.Add(new DBParameter("@ACC_CreatedDate",DateTime.Now,System.Data.DbType.DateTime));

                System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertAccountMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                int id = 0;
                dr.Read();
                id = Convert.ToInt32(dr[0]);
                SaveBillByBillDetails(objAcctMaster.BillbyBillDetails,id);
                SaveCostCenterDetails(objAcctMaster.CostcenterDetails,id);
                SaveChequeDepositeDetails(objAcctMaster.ChequesDeposites, id);
                SaveChequeIssuedDetails(objAcctMaster.ChequesIssued, id);
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return true;
            }

        //Save Maintain Bill By Details
        public bool SaveBillByBillDetails(List<MaintainBillbyBillModel> lstBillbyBill, int id)
        {
            string Query = string.Empty;
            bool isSaved = true;
            foreach (MaintainBillbyBillModel BillbyBill in lstBillbyBill)
            {
                BillbyBill.ParentId=id;
                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Parent_Id", BillbyBill.ParentId));
                    paramCollection.Add(new DBParameter("@Reference", BillbyBill.Reference));
                    paramCollection.Add(new DBParameter("@Salesman", BillbyBill.Salesman));
                    paramCollection.Add(new DBParameter("@Date", BillbyBill.Dated, System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@Amount", BillbyBill.Amount, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@DC", BillbyBill.DC));
                    paramCollection.Add(new DBParameter("@Duedate", BillbyBill.Duedate, System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@GroupName", BillbyBill.Group));
                    paramCollection.Add(new DBParameter("@Narration", BillbyBill.Narration));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    paramCollection.Add(new DBParameter("@CreatedDate",DateTime.Now,System.Data.DbType.DateTime));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spinsertbillbybilldetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }
        //Update Maintain Bill By Bill Details
        //Save Costcenter Details
        public bool SaveCostCenterDetails(List<CostcenterPopupModel> lstCostCenter, int id)
        {
            string Query = string.Empty;
            bool isSaved = true;
            foreach (CostcenterPopupModel objCost in lstCostCenter)
            {
                objCost.ParentId = id;
                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@AccountId", objCost.ParentId));
                    paramCollection.Add(new DBParameter("@CostCentre", objCost.Costcenter));
                    paramCollection.Add(new DBParameter("@Amount", objCost.Amount, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@DC", objCost.DC));
                    paramCollection.Add(new DBParameter("@ShortNarration", objCost.Shortnarration));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spinsertAccountCostCentreDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }
        //Save Cheque Deposites
        public bool SaveChequeDepositeDetails(List<UnclearedChecqueDetailsModel> lstDeposites, int id)
        {
            string Query = string.Empty;
            bool isSaved = true;
            foreach (UnclearedChecqueDetailsModel objDeposites in lstDeposites)
            {
                objDeposites.ParentId = id;
                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@ParentId", objDeposites.ParentId));
                    paramCollection.Add(new DBParameter("@Date", objDeposites.Date, System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@VchNo", objDeposites.Vchno));
                    paramCollection.Add(new DBParameter("@Account", objDeposites.Account));
                    paramCollection.Add(new DBParameter("@Amount", objDeposites.Amount,System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@ShortNarration", objDeposites.Shortnarration));
                    paramCollection.Add(new DBParameter("@Createdby", "Admin"));
                    paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spinsertAcccheqDeposited", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }

        //Save Cheque Issued
        public bool SaveChequeIssuedDetails(List<UnclearedChecqueDetailsModel> lstIssued, int id)
        {
            string Query = string.Empty;
            bool isSaved = true;
            foreach (UnclearedChecqueDetailsModel objIssued in lstIssued)
            {
                objIssued.ParentId = id;
                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@ParentId", objIssued.ParentId));
                    paramCollection.Add(new DBParameter("@Date", objIssued.Date, System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@VchNo", objIssued.Vchno));
                    paramCollection.Add(new DBParameter("@Account", objIssued.Account));
                    paramCollection.Add(new DBParameter("@Amount", objIssued.Amount, System.Data.DbType.Decimal));
                    paramCollection.Add(new DBParameter("@Shortnarration", objIssued.Shortnarration));
                    paramCollection.Add(new DBParameter("@Createdby", "Admin"));
                    paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spinsertUnclearedChequeissued", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
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
                accountGroup.Primary =Convert.ToBoolean(dr["Primary"].ToString());

                lstAccountGroups.Add(accountGroup);

            }
              
            return lstAccountGroups;

        }
        public List<eSunSpeedDomain.AccountGroupModel> GetUnderGroupIdByGroupName(string groupname)
        {
            List<eSunSpeedDomain.AccountGroupModel> lstAccountGroups = new List<eSunSpeedDomain.AccountGroupModel>();
            eSunSpeedDomain.AccountGroupModel accountGroup;

            //StringBuilder _sbQuery = new StringBuilder();
            //_sbQuery.AppendFormat("SELECT AG_ID FROM `AccountGroups` WHERE Groupname='{0}'", groupname);
            string Query = "SELECT * FROM `accountgroups` WHERE `GroupName`='"+groupname+"'";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());
            while (dr.Read())
            {
                accountGroup = new eSunSpeedDomain.AccountGroupModel();

                accountGroup.GroupId = Convert.ToInt32(dr["AG_ID"]);
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
        public bool IsAccountExists(string Name)
        {
            StringBuilder _sbQuery = new StringBuilder();
            _sbQuery.AppendFormat("SELECT COUNT(*) FROM accountmaster1 WHERE ACC_NAME='{0}'",Name);

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
                paramCollection.Add(new DBParameter("@Primary", objAccountGrp.Primary,System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@UnderGroup", objAccountGrp.UnderGroup));
                paramCollection.Add(new DBParameter("@NatureGroup", objAccountGrp.NatureGroup));
                paramCollection.Add(new DBParameter("@IsAffectGrossProfit", objAccountGrp.IsAffectGrossProfit,System.Data.DbType.Boolean));
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

        public bool DeleteAccountGroupById(int id)
        {
            bool isDelete = false;
            try
            {
                string Query = "DELETE FROM `accountgroups` WHERE `AG_ID`='"+id+"'";
                int rowes = _dbHelper.ExecuteNonQuery(Query);
                if (rowes > 0)
                isDelete = true;          
               
            }
            catch (Exception ex)
            {
                isDelete = false;
                throw ex;
            }
            return isDelete;
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
                string Query = "SELECT DISTINCT Ac_ID,ACC_NAME,ACC_SHORTNAME,`ACC_Group`,ACC_OpBal,ACC_DrCrOpenBal FROM `accountmaster1`";
                System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

                while (dr.Read())
                {
                    //Initialize/reset account master object
                    _acctMaster = new AccountMasterModel();

                    _acctMaster.AccountId = Convert.ToInt32(dr["Ac_ID"]);
                    _acctMaster.AccountName = dr["ACC_NAME"].ToString();
                    _acctMaster.ShortName = dr["ACC_SHORTNAME"].ToString();
                    //_acctMaster.LedgerType = dr["ACC_LedgerType"].ToString();
                    _acctMaster.Group = dr["ACC_Group"].ToString();
                    _acctMaster.OPBal = dr["ACC_OpBal"].ToString() == "" ? 0 : Convert.ToDecimal(dr["ACC_OpBal"].ToString());
                    // _acctMaster.PrevYearBal = dr["ACC_PrevYearBal"].ToString();
                    //_acctMaster.DrCrOpeningBal = dr["ACC_DrCrOpenBal"].ToString();
                    //_acctMaster.DrCrPrevBal = dr["ACC_DrCrPrevBal"].ToString();
                    //_acctMaster.MaintainBillwiseAccounts = Convert.ToBoolean(dr["ACC_MaintainBitwise"])? true : false;

                 //   _acctMaster.ActivateInterestCal = Convert.ToBoolean(dr["ACC_ActivateInterestCal"]) == false ? false : true;
                 //   _acctMaster.CreditDays = dr["ACC_CreditDays"].ToString();
                 //   _acctMaster.CreditLimit = dr["ACC_CreditLimit"].ToString();
                 //   _acctMaster.TypeofDealer = dr["ACC_TypeofDealer"].ToString();
                 //   _acctMaster.TypeofBuissness = dr["ACC_TypeofBuissness"].ToString();
                 //   _acctMaster.Transport = dr["ACC_Transport"].ToString();
                 //   _acctMaster.Station = dr["ACC_Station"].ToString();
                 //   _acctMaster.specifyDefaultSaleType = Convert.ToBoolean(dr["ACC_SpecifyDefaultSaleType"]) == false ? false : true;
                 //   _acctMaster.DefaultSaleType = dr["ACC_DefaultSaleType"].ToString();
                 //  // _acctMaster.FreezeSaleType = dr["ACC_FreezeSaleType"].ToString();
                 //   _acctMaster.SpecifyDefaultPurType = Convert.ToBoolean(dr["ACC_SpecifyDefaultPurType"]) == false ? false : true;

                 //   _acctMaster.LockSalesType = Convert.ToBoolean(dr["ACC_LockSalesType"]) == false ? false : true;
                 //   _acctMaster.LockPurchaseType = Convert.ToBoolean(dr["ACC_LockPurcType"]) == false ? false : true;
                 //   _acctMaster.address1 = dr["ACC_address1"].ToString();
                 //   _acctMaster.address2 = dr["ACC_address2"].ToString();
                 //   _acctMaster.address3 = dr["ACC_Address3"].ToString();
                 //   _acctMaster.Transport = dr["ACC_Address4"].ToString();
                 //   _acctMaster.Station = dr["ACC_State"].ToString();
                 //   _acctMaster.TelephoneNumber = dr["ACC_TelephoneNumber"].ToString();
                 //   _acctMaster.Fax = dr["ACC_Fax"].ToString();
                 ////   _acctMaster.FreezeSaleType = dr["ACC_MobileNumber"].ToString();
                 //   _acctMaster.email = dr["ACC_email"].ToString();

                 //   _acctMaster.WebSite = dr["ACC_Website"].ToString();
                 //   _acctMaster.enablemailquery = Convert.ToBoolean(dr["ACC_enablemailquery"]) == false ? false : true;
                 //   _acctMaster.enableSMSquery = Convert.ToBoolean(dr["ACC_enableSMSquery"]) == false ? false : true;
                 //  // _acctMaster.address2 = dr["ACC_address2"].ToString();
                 //   //_acctMaster.address3 = dr["ACC_Address3"].ToString();
                 //   //_acctMaster.address4 = dr["ACC_Address4"].ToString();
                 //   _acctMaster.State = dr["ACC_State"].ToString();
                 //   _acctMaster.TelephoneNumber = dr["ACC_TelephoneNumber"].ToString();
                 //   _acctMaster.Fax = dr["ACC_Fax"].ToString();
                 //   _acctMaster.MobileNumber = dr["ACC_MobileNumber"].ToString();
                 //   _acctMaster.email = dr["ACC_email"].ToString();

                 //   _acctMaster.contactperson = dr["ACC_contactperson"].ToString();
                 //   _acctMaster.ITPanNumber = dr["ACC_ITPanNumber"].ToString();
                 //   _acctMaster.LstNumber = dr["ACC_LSTNumber"].ToString();
                 //   _acctMaster.CSTNumber = dr["ACC_CSTNumber"].ToString();
                 //   _acctMaster.TIN = dr["ACC_TIN"].ToString();
                 //   _acctMaster.ServiceTaxNumber = dr["ACC_ServiceTax"].ToString();
                 //   _acctMaster.LBTNumber = dr["ACC_LBTNumber"].ToString();
                 //   _acctMaster.BankAccountNumber = dr["ACC_BankAccountNumber"].ToString();
                 //   _acctMaster.IECode = dr["ACC_IECode"].ToString();

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
        public AccountMasterModel GetListofAccountByAccountId(int id)
        {
            AccountMasterModel _acctMaster = new AccountMasterModel();

            try
            {

                string Query = "SELECT * from accountmaster1 WHERE Ac_ID='" + id + "'";
                System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

                while (dr.Read())
                {

                    _acctMaster.AccountId = Convert.ToInt32(dr["Ac_ID"]);
                    _acctMaster.AccountName = dr["ACC_NAME"].ToString();
                    _acctMaster.ShortName = dr["ACC_SHORTNAME"].ToString();
                    _acctMaster.PrintName = dr["ACC_PRINTNAME"].ToString();
                    _acctMaster.LedgerType = dr["ACC_LedgerType"].ToString();
                    _acctMaster.MultiCurrency = Convert.ToBoolean(dr["ACC_MultiCurr"]);
                    _acctMaster.Group = dr["ACC_Group"].ToString();
                    _acctMaster.OPBal = dr["ACC_OpBal"].ToString() == "" ? 0 : Convert.ToDecimal(dr["ACC_OpBal"].ToString());
                    _acctMaster.PrevYearBal = dr["ACC_PrevYearBal"].ToString() == "" ? 0 : Convert.ToDecimal(dr["ACC_PrevYearBal"].ToString());
                    _acctMaster.DrCrOpeningBal = dr["ACC_DrCrOpenBal"].ToString();
                    _acctMaster.DrCrPrevBal = dr["ACC_DrCrPrevBal"].ToString();
                    _acctMaster.MaintainBillwiseAccounts = Convert.ToBoolean(dr["ACC_MaintainBitwise"]);
                    _acctMaster.ActivateInterestCal = Convert.ToBoolean(dr["ACC_ActivateInterestCal"]);
                    _acctMaster.AllocateAmountItems = Convert.ToBoolean(dr["ACC_AllocateAmountItems"]);
                    _acctMaster.CreditDaysforSale =Convert.ToInt32(dr["ACC_CreditDays_ForSale"].ToString());
                    _acctMaster.CreditDaysforPurchase = Convert.ToInt32(dr["ACC_CreditDays_ForPurch"].ToString());
                    _acctMaster.DefineCrLimit = Convert.ToBoolean(dr["ACC_DefineCreditLimit"]);
                    _acctMaster.MaxCredit =Convert.ToDecimal(dr["ACC_CreditLimit"].ToString());
                    _acctMaster.TypeofDealer = dr["ACC_TypeofDealer"].ToString();
                    _acctMaster.TypeofBuissness = dr["ACC_TypeofBuissness"].ToString();
                    _acctMaster.Transport = dr["ACC_Transport"].ToString();
                    _acctMaster.Station = dr["ACC_Station"].ToString();
                    _acctMaster.specifyDefaultSaleType = Convert.ToBoolean(dr["ACC_SpecifyDefaultSaleType"]);
                    _acctMaster.DefaultSaleType = dr["ACC_DefaultSaleType"].ToString();
                    _acctMaster.FreezeSaleType = Convert.ToBoolean(dr["ACC_FreezeSaleType"]);
                    _acctMaster.SpecifyDefaultPurType = Convert.ToBoolean(dr["ACC_SpecifyDefaultPurType"]);
                    _acctMaster.DefaultPurcType = dr["ACC_DefaultSaleType"].ToString();
                    _acctMaster.FreezePurcType = Convert.ToBoolean(dr["ACC_FreezeSaleType"]);

                    _acctMaster.LockSalesType = Convert.ToBoolean(dr["ACC_LockSalesType"]);
                    _acctMaster.LockPurchaseType = Convert.ToBoolean(dr["ACC_LockPurcType"]);
                    _acctMaster.address = dr["ACC_address1"].ToString();
                    _acctMaster.address1 = dr["ACC_address2"].ToString();
                    _acctMaster.address2 = dr["ACC_Address3"].ToString();
                    _acctMaster.address3 = dr["ACC_Address4"].ToString();
                    _acctMaster.TelephoneNumber = dr["ACC_TelephoneNumber"].ToString();
                    _acctMaster.Fax = dr["ACC_Fax"].ToString();
                    _acctMaster.State = dr["ACC_State"].ToString();
                    _acctMaster.area = dr["ACC_Area"].ToString()==null?string.Empty: dr["ACC_Area"].ToString();
                    _acctMaster.MobileNumber = dr["ACC_MobileNumber"].ToString();
                    _acctMaster.email = dr["ACC_email"].ToString();
                    _acctMaster.WebSite = dr["ACC_Website"].ToString();
                    _acctMaster.enablemailquery = Convert.ToBoolean(dr["ACC_enablemailquery"]);
                    _acctMaster.enableSMSquery = Convert.ToBoolean(dr["ACC_enableSMSquery"]);
                    _acctMaster.contactperson = dr["ACC_contactperson"].ToString();
                    _acctMaster.ITPanNumber = dr["ACC_ITPanNumber"].ToString();
                    _acctMaster.LstNumber = dr["ACC_LSTNumber"].ToString();
                    _acctMaster.CSTNumber = dr["ACC_CSTNumber"].ToString();
                    _acctMaster.TIN = dr["ACC_TIN"].ToString();
                    _acctMaster.ServiceTaxNumber = dr["ACC_ServiceTax"].ToString();
                    _acctMaster.LBTNumber = dr["ACC_LBTNumber"].ToString();
                    _acctMaster.BankAccountNumber = dr["ACC_BankAccountNumber"].ToString();
                    _acctMaster.IECode = dr["ACC_IECode"].ToString();
                    _acctMaster.Ward = dr["ACC_Ward"].ToString();
                    _acctMaster.ChequePrintName = dr["ACC_Cheque_PrintName"].ToString();
                    _acctMaster.DLNO1 = dr["ACC_DLNo"].ToString()==null?string.Empty: dr["ACC_DLNo"].ToString();
                    _acctMaster.No1 = dr["ACC_DLNo1"].ToString()==null?string.Empty: dr["ACC_DLNo1"].ToString();
                    _acctMaster.InterestRatePayable =Convert.ToDecimal(dr["ACC_InterestRatePayable"].ToString());
                    _acctMaster.InterestRateReceivable = Convert.ToDecimal(dr["ACC_InterestRateReceivable"].ToString());
                    _acctMaster.SpecifyDefaultSM = Convert.ToBoolean(dr["ACC_SpecifyDefaultSM"]);
                    _acctMaster.SalesMan =dr["ACC_SalesMan"].ToString()==null?string.Empty: dr["ACC_SalesMan"].ToString();
                    _acctMaster.freezeSalesMan =Convert.ToBoolean(dr["ACC_freezeSalesMan"]);
                    _acctMaster.DefaultCommission = Convert.ToBoolean(dr["ACC_DefaultCommission"]);
                    _acctMaster.CommissionMode = dr["ACC_CommissionMode"].ToString();
                    _acctMaster.CommissionPercentage =Convert.ToDecimal(dr["ACC_CommissionPercentage"]);
                    _acctMaster.FreezeCommission = Convert.ToBoolean(dr["ACC_FreezeCommission"]);
                    _acctMaster.DefineBudgets = Convert.ToBoolean(dr["ACC_DefineBudgets"]);
                    _acctMaster.AnnualBudgets = Convert.ToDecimal(dr["ACC_AnnualBudgets"]);
                    _acctMaster.JanuaryBd = Convert.ToDecimal(dr["ACC_JanuaryBd"]);
                    _acctMaster.FebruaryBd = Convert.ToDecimal(dr["ACC_FebruaryBd"]);
                    _acctMaster.MarchBd = Convert.ToDecimal(dr["ACC_MarchBd"]);
                    _acctMaster.AprilBd = Convert.ToDecimal(dr["ACC_AprilBd"]);
                    _acctMaster.MayBd = Convert.ToDecimal(dr["ACC_MayBd"]);
                    _acctMaster.JuneBd = Convert.ToDecimal(dr["ACC_JuneBd"]);
                    _acctMaster.JulyBd = Convert.ToDecimal(dr["ACC_JulyBd"]);
                    _acctMaster.AugustBd = Convert.ToDecimal(dr["ACC_AugustBd"]);
                    _acctMaster.SeptemberBd = Convert.ToDecimal(dr["ACC_SeptemberBd"]);
                    _acctMaster.OctoberBd = Convert.ToDecimal(dr["ACC_OctoberBd"]);
                    _acctMaster.NovemberBd = Convert.ToDecimal(dr["ACC_NovemberBd"]);
                    _acctMaster.DecemberBd = Convert.ToDecimal(dr["ACC_DecemberBd"]);

                    string CostQuery = "SELECT * FROM accountcostcentredetails WHERE Ac_ID=" + id;
                    System.Data.IDataReader drCC = _dbHelper.ExecuteDataReader(CostQuery, _dbHelper.GetConnObject());

                    _acctMaster.CostcenterDetails = new List<CostcenterPopupModel>();
                    CostcenterPopupModel objCost;

                    while (drCC.Read())
                    {
                        objCost = new CostcenterPopupModel();
                        objCost.CCId = Convert.ToInt32(drCC["CCID"]);
                        objCost.ParentId = Convert.ToInt32(drCC["Ac_ID"]);
                        objCost.Costcenter = drCC["CostCentre"].ToString();
                        objCost.Amount = Convert.ToDecimal(drCC["Amount"]);
                        objCost.DC = drCC["DC"].ToString();
                        objCost.Shortnarration = drCC["ShortNarration"].ToString();

                        _acctMaster.CostcenterDetails.Add(objCost);
                    }
                    string BillQuery = "SELECT * FROM billbybilldetails WHERE Ac_ID=" + id;
                    System.Data.IDataReader drBB = _dbHelper.ExecuteDataReader(BillQuery, _dbHelper.GetConnObject());

                    _acctMaster.BillbyBillDetails = new List<MaintainBillbyBillModel>();
                    MaintainBillbyBillModel objBills;
                    while (drBB.Read())
                    {
                        objBills = new MaintainBillbyBillModel();
                        objBills.BillId = Convert.ToInt32(drBB["BillID"]);
                        objBills.ParentId = Convert.ToInt32(drBB["Ac_ID"]);
                        objBills.Reference = drBB["Reference"].ToString();
                        objBills.Dated = Convert.ToDateTime(drBB["Date"]);
                        objBills.Amount = Convert.ToDecimal(drBB["Amount"]);
                        objBills.DC= drBB["DC"].ToString();
                        objBills.Duedate = Convert.ToDateTime(drBB["Duedate"]);
                        objBills.Group = drBB["GroupName"].ToString();
                        objBills.Narration = drBB["Narration"].ToString();

                        _acctMaster.BillbyBillDetails.Add(objBills);
                    }
                    string DepositQuery = "SELECT * FROM accchquesdeposited WHERE Ac_ID=" + id;
                    System.Data.IDataReader drDP = _dbHelper.ExecuteDataReader(DepositQuery, _dbHelper.GetConnObject());

                    _acctMaster.ChequesDeposites = new List<UnclearedChecqueDetailsModel>();
                    UnclearedChecqueDetailsModel objDeposit;
                    while (drDP.Read())
                    {
                        objDeposit = new UnclearedChecqueDetailsModel();
                        objDeposit.id = Convert.ToInt32(drDP["AccDepositedID"]);
                        objDeposit.ParentId = Convert.ToInt32(drDP["Ac_ID"]);
                        objDeposit.Date = Convert.ToDateTime(drDP["Date"]);
                        objDeposit.Vchno = Convert.ToInt64(drDP["VchNo"]);
                        objDeposit.Account = drDP["Account"].ToString();                        
                        objDeposit.Amount = Convert.ToDecimal(drDP["Amount"]);
                        objDeposit.Shortnarration = drDP["ShortNarration"].ToString();

                        _acctMaster.ChequesDeposites.Add(objDeposit);
                    }
                    string IssueQuery = "SELECT * FROM accchequeissued WHERE Ac_ID=" + id;
                    System.Data.IDataReader drCI = _dbHelper.ExecuteDataReader(IssueQuery, _dbHelper.GetConnObject());

                    _acctMaster.ChequesIssued = new List<UnclearedChecqueDetailsModel>();
                    UnclearedChecqueDetailsModel objIssued;
                    while (drCI.Read())
                    {
                        objIssued = new UnclearedChecqueDetailsModel();
                        objIssued.id = Convert.ToInt32(drCI["IssuedId"]);
                        objIssued.ParentId = Convert.ToInt32(drCI["Ac_ID"]);
                        objIssued.Date = Convert.ToDateTime(drCI["Date"]);
                        objIssued.Vchno = Convert.ToInt64(drCI["VchNo"]);
                        objIssued.Account = drCI["Account"].ToString();
                        objIssued.Amount = Convert.ToDecimal(drCI["Amount"]);
                        objIssued.Shortnarration = drCI["ShortNarration"].ToString();

                        _acctMaster.ChequesIssued.Add(objIssued);
                    }
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
                accountGroup.Primary = Convert.ToBoolean(dr["Primary"].ToString());
                accountGroup.NatureGroup = dr["NatureGroup"].ToString();
                accountGroup.IsAffectGrossProfit = dr["IsAffectGrossProfit"].ToString()==""?false:Convert.ToBoolean( dr["IsAffectGrossProfit"]);

            }

            return accountGroup;

        }

        public AccountGroupModel GetAccountGroupIdByGroupName(string groupname)
        {
            AccountGroupModel accountGroup = new AccountGroupModel();

            string Query = "SELECT  AG_ID FROM `accountgroups` where GroupName='"+groupname+"'";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                accountGroup.GroupId = Convert.ToInt32(dr["AG_ID"]);
            }

            return accountGroup;

        }
        #endregion  

        //Delete Single Account By Id
        public bool DeleteAccountMasterById(int id)
        {
            bool isDelete = false;
            try
            {
                if (DeleteCostCenterDetails(id))
                {
                    if (DeleteBillbyBillDetails(id))
                    {
                        if (DeleteChequeDepositDetails(id))
                        {
                            if (DeleteChequeIssuedDetails(id))
                            {                        
                              string Query = "DELETE FROM accountmaster1 WHERE Ac_ID=" + id;
                              int rowes = _dbHelper.ExecuteNonQuery(Query);
                              if (rowes > 0)
                              isDelete = true;
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                isDelete = false;
                throw ex;
            }
            return isDelete;
        }

        //Delete CostCenter Popup Details
        public bool DeleteCostCenterDetails(int id)
        {
            bool isDelete = true;
            try
            {
                string Query = "DELETE FROM `accountcostcentredetails` WHERE Ac_ID=" + id;
                int rowes = _dbHelper.ExecuteNonQuery(Query);
                if (rowes > 0)
                    isDelete = true;
            }
            catch (Exception ex)
            {
                isDelete = false;
                throw ex;
            }
            return isDelete;
        }
        //Delete BillbyBill Popup Details
        public bool DeleteBillbyBillDetails(int id)
        {
            bool isDelete = true;
            try
            {
                string Query = "DELETE FROM `billbybilldetails` WHERE Ac_ID=" + id;
                int rowes = _dbHelper.ExecuteNonQuery(Query);
                if (rowes > 0)
                    isDelete = true;
            }
            catch (Exception ex)
            {
                isDelete = false;
                throw ex;
            }
            return isDelete;
        }
        //Delete ChequeDeposit Popup Details
        public bool DeleteChequeDepositDetails(int id)
        {
            bool isDelete = true;
            try
            {
                string Query = "DELETE FROM `accchquesdeposited` WHERE Ac_ID=" + id;
                int rowes = _dbHelper.ExecuteNonQuery(Query);
                if (rowes > 0)
                    isDelete = true;
            }
            catch (Exception ex)
            {
                isDelete = false;
                throw ex;
            }
            return isDelete;
        }
        //Delete ChequeIssued Popup Details
        public bool DeleteChequeIssuedDetails(int id)
        {
            bool isDelete = true;
            try
            {
                string Query = "DELETE FROM `accchequeissued` WHERE Ac_ID=" + id;
                int rowes = _dbHelper.ExecuteNonQuery(Query);
                if (rowes > 0)
                    isDelete = true;
            }
            catch (Exception ex)
            {
                isDelete = false;
                throw ex;
            }
            return isDelete;
        }
    }

}
