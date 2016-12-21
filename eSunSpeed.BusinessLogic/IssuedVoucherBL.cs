using eSunSpeed.DataAccess;
using eSunSpeed.Formatting;
using eSunSpeedDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeed.BusinessLogic
{
    public class IssuedVoucherBL
    {
        private DBHelper _dbHelper = new DBHelper();

        #region SAVE RECIEPT VOUCHER
        public bool SaveIssuedVoucher(IssuedVoucherModel objIssued)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Date", objIssued.Date, System.Data.DbType.DateTime));             
                paramCollection.Add(new DBParameter("@From", objIssued.From));
                paramCollection.Add(new DBParameter("@Authourity", objIssued.Authourity,System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@FromNo", objIssued.fromNo));
                paramCollection.Add(new DBParameter("@Party", objIssued.party));
                paramCollection.Add(new DBParameter("@Narration", objIssued.Narration));
                
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                //paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));

                Query = "INSERT INTO Issued_Voucher ([Issued_Date],[From],[Rcvd Authourity],[FromNo],[Party]," +
                "[Narration],[CreatedBy]) VALUES " +
                "(@Date,@From,@Authourity,@FromNo,@Party,@Narration," +
                " @CreatedBy)";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                {
                    SaveIssuedAccount(objIssued.ReceviedModel);
                    isSaved = true;
                }
            }
            catch (Exception ex)
            {
                isSaved = false;
                throw ex;
            }

            return isSaved;
        }

        public bool SaveIssuedAccount(List<ReceviedModel> lstRec)
        {
            string Query = string.Empty;
            bool isSaved = true;

            int ParentId = GetIssuedId();

            foreach (ReceviedModel Rec in lstRec)
            {
                Rec.ParentId = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@ID", (Rec.ParentId)));
                    paramCollection.Add(new DBParameter("@VoucherNo", (Rec.VoucherNo)));
                    paramCollection.Add(new DBParameter("@Dated", Rec.Dated));
                    paramCollection.Add(new DBParameter("@amount", Rec.Amount));
                    paramCollection.Add(new DBParameter("@BillNo", Rec.BillNo));
                    paramCollection.Add(new DBParameter("@BillDate", Rec.BillDate));

                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    //paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));


                    Query = "INSERT INTO Issued_Amount_Voucher ([Issued_Id],[VoucherNo],[Dated],[Amount],[PurchaseBillNo],[PurchaseDate]," +
                    "[CreatedBy]) VALUES " +
                    "(@ID,@VoucherNo,@Dated,@amount,@BillNo,@BillDate,@CreatedBy)";

                    if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                        isSaved = true;
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }

      

        public int GetIssuedId()
        {
            string Query = "SELECT MAX(Issued_Id) FROM Issued_Voucher";

            int id = Convert.ToInt32(_dbHelper.ExecuteScalar(Query));

            return id;
        }


        #endregion

        //Udate Reciept Voucher
        public bool UpdateIssuedVoucher(IssuedVoucherModel objIssued)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                //UPDATE Issued Voucher - PARENT TABLE
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Date", objIssued.Date, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@From", objIssued.From));
                paramCollection.Add(new DBParameter("@Authourity", objIssued.Authourity, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@FromNo", objIssued.fromNo));
                paramCollection.Add(new DBParameter("@Party", objIssued.party));
                paramCollection.Add(new DBParameter("@Narration", objIssued.Narration));

                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@id", objIssued.IV_Id));

                //paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));


                Query = "UPDATE Issued_Voucher SET [Issued_Date]=@Date,[From]=@From,[Rcvd Authourity]=@Authourity," +
                         "[FromNo]=@FromNo,[Party]=@Party,[Narration]=@Narration," +
                        "[ModifiedBy]=@ModifiedBy " +
                        "WHERE Issued_Id=@id";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                {
                    List<ReceviedModel> lstAcct = new List<ReceviedModel>();

                    //UPDATE Issued Account -CHILD TABLE UPDATES
                    foreach (ReceviedModel iss in objIssued.ReceviedModel)
                    {
                        if (iss.id > 0)
                        {

                            paramCollection = new DBParameterCollection();

                            paramCollection.Add(new DBParameter("@VoucherNo", (iss.VoucherNo)));
                            paramCollection.Add(new DBParameter("@Dated", iss.Dated));
                            paramCollection.Add(new DBParameter("@Amount", iss.Amount));
                            paramCollection.Add(new DBParameter("@BillNo", iss.BillNo));
                            paramCollection.Add(new DBParameter("@BillDate", iss.BillDate));

                            paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                            //paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));
                            paramCollection.Add(new DBParameter("@ACT_ID", iss.id));

                            Query = "UPDATE Issued_Amount_Voucher SET [VoucherNo]=@VoucherNo," +
                            "[Dated]=@Dated,[Amount]=@Amount,[PurchaseBillNo]=@BillNo,[PurchaseDate]=@BillDate,[ModifiedBy]=@ModifiedBy " +
                            "WHERE [SNo]=@ACT_ID";

                            if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                            {
                                isUpdated = true;
                            }
                        }
                        else
                        {
                            paramCollection = new DBParameterCollection();

                            paramCollection.Add(new DBParameter("@ID", (objIssued.IV_Id)));
                            paramCollection.Add(new DBParameter("@VoucherNo", (iss.VoucherNo)));
                            paramCollection.Add(new DBParameter("@Dated", iss.Dated));
                            paramCollection.Add(new DBParameter("@amount", iss.Amount));
                            paramCollection.Add(new DBParameter("@BillNo", iss.BillNo));
                            paramCollection.Add(new DBParameter("@BillDate", iss.BillDate));

                            paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                            //paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));


                            Query = "INSERT INTO Issued_Amount_Voucher ([Issued_Id],[VoucherNo],[Dated],[Amount],[PurchaseBillNo],[PurchaseDate]," +
                            "[CreatedBy]) VALUES " +
                            "(@ID,@VoucherNo,@Dated,@amount,@BillNo,@BillDate,@CreatedBy)";

                            if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                                isUpdated = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                isUpdated = false;
                throw ex;
            }

            return isUpdated;
        }



        //public List<RecieptVoucherModel> GetAllRecieptVoucher()
        //{
        //    List<RecieptVoucherModel> lstReciept = new List<RecieptVoucherModel>();
        //    RecieptVoucherModel objRVoucher;

        //    string Query = "SELECT * FROM Reciept_Voucher";
        //    System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

        //    while (dr.Read())
        //    {
        //        objRVoucher = new RecieptVoucherModel();

        //        objRVoucher.RV_Id = DataFormat.GetInteger(dr["Reciept_Id"]);
        //        objRVoucher.Voucher_Series = dr["Series"].ToString();
        //        objRVoucher.RV_Date = DataFormat.GetDateTime(dr["Reciept_Date"]);
        //        objRVoucher.Voucher_Number = DataFormat.GetInteger(dr["VoucherNo"]);
        //        objRVoucher.Type = dr["Type"].ToString();
        //        objRVoucher.PDCDate = Convert.ToDateTime(dr["PDCDate"].ToString());

        //        //SELECT Reciept Voucher Accounts

        //        string itemQuery = "SELECT * FROM Reciept_Voucher_Accounts WHERE Reciept_Id=" + objRVoucher.RV_Id;
        //        System.Data.IDataReader drAcc = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

        //        objRVoucher.RecieptAccountModel = new List<AccountModel>();
        //        AccountModel objAcc;

        //        while (drAcc.Read())
        //        {
        //            objAcc = new AccountModel();

        //            objAcc.ParentId = DataFormat.GetInteger(drAcc["Reciept_Id"]);
        //            objAcc.AC_Id = DataFormat.GetInteger(drAcc["AC_Id"]);
        //            objAcc.DC = drAcc["DC"].ToString();
        //            objAcc.Account = drAcc["Account"].ToString();
        //            objAcc.Debit = Convert.ToDecimal(drAcc["Debit"]);
        //            objAcc.Credit = Convert.ToDecimal(drAcc["Credit"]);
        //            objAcc.Narration = drAcc["Narration"].ToString();


        //            objRVoucher.RecieptAccountModel.Add(objAcc);

        //        }

        //        lstReciept.Add(objRVoucher);

        //    }
        //    return lstReciept;
        //}

        //Delete RecieptVoucherModel
        public bool DeleteRecieptVoucher(int id)
        {
            bool isDelete = true;
            try
            {
                DeleteRecieptAccounts(id);
                string Query = "DELETE * FROM Reciept_Voucher WHERE Reciept_Id=" + id;

                if (_dbHelper.ExecuteNonQuery(Query) > 0)
                                  
                    isDelete = true;
            }
            catch (Exception ex)
            {
                isDelete = false;
                throw ex;
            }
            return isDelete;
        }

        public bool DeleteRecieptAccounts(int id)
        {
            bool isDelete = true;
            try
            {
                string Query = "DELETE * FROM Reciept_Voucher_Accounts WHERE Reciept_Id=" + id;

                if (_dbHelper.ExecuteNonQuery(Query) > 0)
                    isDelete = true;
            }
            catch (Exception ex)
            {
                isDelete = false;
                throw ex;
            }
            return isDelete;
        }

        public List<ListVoucherModel> GetAllIssuedVoucher()
        {
            List<ListVoucherModel> lstModel = new List<ListVoucherModel>();
            ListVoucherModel objList;

            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT C.Issued_Id, C.Issued_Date, C.Party, A.VoucherNo, A.Amount,A.PurchaseBillNo,A.PurchaseDate FROM Issued_Voucher C ");
            sbQuery.Append("INNER JOIN Issued_Amount_Voucher A ");
            sbQuery.Append("ON A.Issued_Id = C.Issued_Id;");

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(sbQuery.ToString(), _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objList = new ListVoucherModel();

                objList.Issued_Id = Convert.ToInt32(dr["Issued_ID"]);
                objList.Date = Convert.ToDateTime(dr["Issued_Date"]);
                objList.Party = Convert.ToString(dr["Party"]);
                objList.VoucherNo = Convert.ToInt32(dr["VoucherNo"]);
                objList.Amount = Convert.ToDecimal(dr["Amount"]);
                objList.BillNo = Convert.ToInt32(dr["PurchaseBillNo"]);
                objList.BillDate = (dr["PurchaseDate"].ToString());
                lstModel.Add(objList);

            }
            return lstModel;
        }

        public List<IssuedVoucherModel> GetIssuedVouchertbyId(int id)
        {
            List<IssuedVoucherModel> lstIssued = new List<IssuedVoucherModel>();
            IssuedVoucherModel objIssued;

            string Query = "SELECT * FROM Issued_Voucher WHERE Issued_Id=" + id;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objIssued = new IssuedVoucherModel();

                objIssued.IV_Id = DataFormat.GetInteger(dr["Issued_Id"]);
                objIssued.Date = DataFormat.GetDateTime(dr["Issued_Date"]);
                objIssued.From = dr["From"].ToString();
                objIssued.Authourity = dr["Rcvd Authourity"].ToString();
                objIssued.fromNo = DataFormat.GetInteger(dr["FromNo"]);
                objIssued.party = dr["Party"].ToString();
                objIssued.Narration = dr["Narration"].ToString();


                //SELECT Recevied Amount Voucher 

                string itemQuery = "SELECT * FROM Issued_Amount_Voucher WHERE Issued_Id=" + id;
                System.Data.IDataReader drRec = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                objIssued.ReceviedModel = new List<ReceviedModel>();
                ReceviedModel objiss;

                while (drRec.Read())
                {
                    objiss = new ReceviedModel();

                    objiss.id = DataFormat.GetInteger(drRec["SNo"]);
                    objiss.ParentId = DataFormat.GetInteger(drRec["Issued_ID"]);
                    objiss.VoucherNo = DataFormat.GetInteger(drRec["VoucherNo"]);
                    objiss.Dated = drRec["Dated"].ToString();
                    objiss.Amount = Convert.ToDecimal(drRec["Amount"]);
                    objiss.BillNo = DataFormat.GetInteger(drRec["PurchaseBillNo"]);
                    objiss.BillDate = drRec["PurchaseDate"].ToString();


                    objIssued.ReceviedModel.Add(objiss);

                }

                lstIssued.Add(objIssued);
            }
            return lstIssued;
        }

    }
}
