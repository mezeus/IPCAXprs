using eSunSpeed.DataAccess;
using eSunSpeed.Formatting;
using eSunSpeedDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeed.BusinessLogic
{
    public class PhysicalStockVoucherBL
    {
        private DBHelper _dbHelper = new DBHelper();

        #region SAVE CREDIT NOTE
        public bool SavePhysicalStock(PhysicalStockModel objphysical)
        {
            string Query = string.Empty;
            bool isSaved = true;          

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();


                paramCollection.Add(new DBParameter("@VoucherNo", objphysical.Voucher_Number));             
                paramCollection.Add(new DBParameter("@Date", objphysical.PSDate,System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@Matcenter", objphysical.MatCenter));
                paramCollection.Add(new DBParameter("@Narration", objphysical.Narration));
                paramCollection.Add(new DBParameter("@Series", objphysical.SVSeries));
                paramCollection.Add(new DBParameter("@JournalVoucher", objphysical.StockJournalVoucher, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@InputSub", objphysical.InputSubDetails, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@UpdateVoucher", objphysical.UpdateVoucher, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ScannBarCode", objphysical.ScannBarcode, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@Items", objphysical.Items,System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@BSN", objphysical.BCN, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@SerialNo", objphysical.SerialNo, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@Batch", objphysical.Batch, System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                //paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));

                Query = "INSERT INTO Physical_Stock_Voucher ([VoucherNo],[Physical_Date],[MatCenter],[Narration],[Journal Series]," +
                "[Journal Voucher],[Input Sub],[Scann Barcode],[Update Journal Narration],[Items],[BCN],[SerialNo],[Batch],[CreatedBy]) VALUES " +
                "(@VoucherNo,@Date,@Matcenter,@Narration,@Series,@JournalVoucher,@InputSub,@UpdateVoucher,@ScannBarCode,@Items," +
                " @BSN,@SerialNo,@Batch,@CreatedBy)";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                {
                    SavePhysicalStockItems(objphysical.StockItemsModel);
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

        public bool SavePhysicalStockItems(List<StockItemsModel> lststock)
        {
            string Query = string.Empty;
            bool isSaved = true;

            int ParentId = GetPhysicalStockId();

            foreach (StockItemsModel stock in lststock)
            {
                stock.Parent_Id = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@PS_ID", (stock.Parent_Id)));
                    paramCollection.Add(new DBParameter("@Item", (stock.item)));
                    paramCollection.Add(new DBParameter("@Pstock", stock.Pstock));
                    paramCollection.Add(new DBParameter("@Bstock", stock.Bstock));
                    paramCollection.Add(new DBParameter("@Difference", stock.Difference));
                            
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    //paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));


                    Query = "INSERT INTO Physical_Stock_Items([Physical_Id],[Item],[Physical Stock],[Book Stock],[Difference],[CreatedBy])" +
                    " VALUES " +
                    "(@PS_ID,@Item,@Pstock,@Bstock,@Difference,@CreatedBy)";

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

        public List<int> GetAccountId(int creditId)
        {
            List<int> lstAccIds = new List<int>();

            string Query = "SELECT AC_ID FROM Credit_Note_Accounts WHERE CREDIT_ID="+creditId;

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                lstAccIds.Add(Convert.ToInt32(dr["AC_ID"]));                
            }
                return lstAccIds;
        }


        public int GetPhysicalStockId()
        {
            string Query = "SELECT MAX(Physical_Id) FROM Physical_Stock_Voucher";

            int id = Convert.ToInt32(_dbHelper.ExecuteScalar(Query));

            return id;
        }


        #endregion
        
        //UPDATE Physical Stock Voucher
        public bool UpdatePhysicalStock(PhysicalStockModel objphysical)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                //UPDATE CREDIT NOTE TABLE - PARENT TABLE

                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@VoucherNo", objphysical.Voucher_Number));
                paramCollection.Add(new DBParameter("@Date", objphysical.PSDate, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@Matcenter", objphysical.MatCenter));
                paramCollection.Add(new DBParameter("@Narration", objphysical.Narration));
                paramCollection.Add(new DBParameter("@Series", objphysical.SVSeries));
                paramCollection.Add(new DBParameter("@JournalVoucher", objphysical.StockJournalVoucher, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@InputSub", objphysical.InputSubDetails, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ScannBarCode", objphysical.ScannBarcode, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@UpdateVoucher", objphysical.UpdateVoucher, System.Data.DbType.Boolean));
                
                paramCollection.Add(new DBParameter("@Items", objphysical.Items, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@BSN", objphysical.BCN, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@SerialNo", objphysical.SerialNo, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@Batch", objphysical.Batch, System.Data.DbType.Boolean));

                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                paramCollection.Add(new DBParameter("@id", objphysical.Phycial_Id));

                Query = "UPDATE Physical_Stock_Voucher SET [VoucherNo]=@VoucherNo,[Physical_Date]=@Date,[MatCenter]=@Matcenter," +
                         "[Narration]=@Narration,[Journal Series]=@Series,[Journal Voucher]=@JournalVoucher,[Input Sub]=@InputSub,[Scann Barcode]=@ScannBarCode," +
                        "[Update Journal Narration]=@UpdateVoucher,[Items]=@Items,[BCN]=@BSN,[SerialNo]=@SerialNo,[Batch]=@Batch,[CreatedBy]=@CreatedBy " +
                        "WHERE Physical_Id=@id";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                {
                    List<StockItemsModel> lstAcct = new List<StockItemsModel>();

                    //UPDATE CREDIT NOTE ACCOUNT -CHILD TABLE UPDATES
                    foreach (StockItemsModel stock in objphysical.StockItemsModel)
                    {
                        if (stock.item_Id > 0)
                        {

                            paramCollection = new DBParameterCollection();

                            paramCollection.Add(new DBParameter("@Item", (stock.item)));
                            paramCollection.Add(new DBParameter("@Pstock", stock.Pstock));
                            paramCollection.Add(new DBParameter("@Bstock", stock.Bstock));
                            paramCollection.Add(new DBParameter("@Difference", stock.Difference));

                            paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));

                            paramCollection.Add(new DBParameter("@Item_ID", (stock.item_Id)));

                            Query = "UPDATE Physical_Stock_Items SET [Item]=@Item,[Physical Stock]=@Pstock,[Book Stock]=@Bstock,[Difference]=@Difference,[ModifiedBy]=@ModifiedBy " +
                                    "WHERE [Item_Id]=Item_ID";

                            if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                            {
                                isUpdated = true;
                            }
                        }
                    
                        else
                        {
                            paramCollection = new DBParameterCollection();

                            paramCollection.Add(new DBParameter("@PS_ID", (objphysical.Phycial_Id)));
                            paramCollection.Add(new DBParameter("@Item", (stock.item)));
                            paramCollection.Add(new DBParameter("@Pstock", stock.Pstock));
                            paramCollection.Add(new DBParameter("@Bstock", stock.Bstock));
                            paramCollection.Add(new DBParameter("@Difference", stock.Difference));

                            paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                            //paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));


                            Query = "INSERT INTO Physical_Stock_Items ([Physical_Id],[Item],[Physical Stock],[Book Stock],[Difference],[CreatedBy])" +
                            " VALUES " +
                            "(@PS_ID,@Item,@Pstock,@Bstock,@Difference,@CreatedBy)";

                            if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0) { };                                
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

        //public bool UpdateCreditAccounts(List<Accoun)
        //{

        //    string Query = string.Empty;
        //    bool isUpdate = true;
        //    int ParentId;
        //    foreach (AccountModel Acc in lstacc)
        //    {
        //         Acc.ParentId=  
        //        try
        //        {
        //            DBParameterCollection paramCollection = new DBParameterCollection();

        //            paramCollection.Add(new DBParameter("@AC_ID", (objacc.AC_Id)));
        //            paramCollection.Add(new DBParameter("@CN_ID", (objacc.ParentId)));
        //            paramCollection.Add(new DBParameter("@DC", (objacc.DC)));
        //            paramCollection.Add(new DBParameter("@Account", objacc.Account));
        //            paramCollection.Add(new DBParameter("@Debit", objacc.Debit));
        //            paramCollection.Add(new DBParameter("@Credit", objacc.Credit));
        //            paramCollection.Add(new DBParameter("@Narration", objacc.Narration));

        //            paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
        //            paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));



        //            Query = "UPDATE Credit_Note_Accounts SET [DC]=@DC," +
        //            "[Account]=@Account,[Debit]=@Debit,[Credit]=@Credit,[Narration]=@Narration,[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
        //            "WHERE [AC_Id]=@AC_ID AND [Credit_Id]=@CN_ID";

        //            if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
        //                isUpdate = true;
        //        }

        //        catch (Exception ex)
        //        {
        //            isUpdate = false;
        //            throw ex;
        //        }
        //    }
        //    return isUpdate;
        //}

        public List<ListModel> GetAllPhysicalStock()
        {
            List<ListModel> lstModel = new List<ListModel>();
            ListModel objList;

            StringBuilder sbQuery = new StringBuilder();
            string whereClause = string.Empty;

            sbQuery.Append("SELECT C.PHYSICAL_ID, C.VOUCHERNO, C.PHYSICAL_DATE, A.ITEM, A.[PHYSICAL STOCK],A.Difference FROM PHYSICAL_STOCK_VOUCHER C ");
            sbQuery.Append("INNER JOIN PHYSICAL_STOCK_ITEMS A ");
            sbQuery.Append("ON A.PHYSICAL_ID = C.PHYSICAL_ID");
            
                                    
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(sbQuery.ToString(), _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objList = new ListModel();

                objList.Physical_Id = Convert.ToInt32(dr["PHYSICAL_ID"]);
                objList.VoucherNo = Convert.ToInt32(dr["VOUCHERNO"]);
                objList.Date = Convert.ToDateTime( dr["PHYSICAL_Date"]);
                objList.Item = Convert.ToString(dr["ITEM"]);
                objList.Physical_Stock = Convert.ToDecimal (dr["Physical Stock"]);
                objList.Difference= Convert.ToDecimal (dr["Difference"]);

                lstModel.Add(objList);

            }
            return lstModel;
        }

        public List<PhysicalStockModel> GetPhysicalStockbyId(int id)
        {
            List<PhysicalStockModel> lstStock = new List<PhysicalStockModel>();
            PhysicalStockModel objstock;

            string Query = "SELECT * FROM Physical_Stock_Voucher WHERE Physical_Id=" + id;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objstock = new PhysicalStockModel();

                objstock.Phycial_Id = DataFormat.GetInteger(dr["Physical_ID"]);
                objstock.Voucher_Number =DataFormat.GetInteger(dr["VoucherNo"]);
                objstock.PSDate = DataFormat.GetDateTime(dr["Physical_Date"]);
                objstock.MatCenter =dr["MatCenter"].ToString();
                objstock.Narration = dr["Narration"].ToString();
                objstock.SVSeries =DataFormat.GetInteger(dr["Journal Series"]);
                objstock.StockJournalVoucher = DataFormat.GetBoolean(dr["Journal Voucher"]);
                objstock.InputSubDetails = DataFormat.GetBoolean(dr["Input Sub"]);
                objstock.ScannBarcode = DataFormat.GetBoolean(dr["Scann Barcode"]);
                objstock.UpdateVoucher = DataFormat.GetBoolean(dr["Update Journal Narration"]);
                objstock.Items = DataFormat.GetBoolean(dr["Items"]);
                objstock.BCN = DataFormat.GetBoolean(dr["BCN"]);
                objstock.SerialNo = DataFormat.GetBoolean(dr["SerialNo"]);
                objstock.Batch = DataFormat.GetBoolean(dr["Batch"]);
                

                string itemQuery = "SELECT * FROM Physical_Stock_Items WHERE Physical_Id=" + objstock.Phycial_Id;
                System.Data.IDataReader drAcc = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                objstock.StockItemsModel = new List<StockItemsModel>();
                StockItemsModel obphy;

                while (drAcc.Read())
                {
                    obphy = new StockItemsModel();

                    obphy.item_Id = Convert.ToInt32(drAcc["Item_Id"]);
                    obphy.Parent_Id = DataFormat.GetInteger(drAcc["Physical_Id"]);
                    obphy.item = drAcc["Item"].ToString();
                    obphy.Pstock =Convert.ToDecimal(drAcc["Physical Stock"]);
                    obphy.Bstock = Convert.ToDecimal(drAcc["Book Stock"]);
                    obphy.Difference= Convert.ToDecimal(drAcc["Difference"]);


                    objstock.StockItemsModel.Add(obphy);

                }

                lstStock.Add(objstock);

            }
            return lstStock;
        }


        /*
        public List<CreditNoteModel> GetAllCreditNote()
        {
            List<CreditNoteModel> lstCredit = new List<CreditNoteModel>();
            CreditNoteModel objcredit;

            string Query = "SELECT * FROM Credit_Note";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objcredit = new CreditNoteModel();

                objcredit.CN_Id = DataFormat.GetInteger(dr["CN_Id"]);
                objcredit.Voucher_Series = dr["Series"].ToString();
                objcredit.CN_Date = DataFormat.GetDateTime(dr["CN_Date"]);
                objcredit.Voucher_Number = DataFormat.GetInteger(dr["VoucherNo"]);
                objcredit.Type = dr["Type"].ToString();
                objcredit.PDCDate = Convert.ToDateTime(dr["PDCDate"].ToString());

                //SELECT Contra Voucher Accounts

                string itemQuery = "SELECT * FROM Credit_Note_Accounts WHERE Debit_Id=" + objcredit.CN_Id;
                System.Data.IDataReader drAcc = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                objcredit.CreditAccountModel = new List<AccountModel>();
                AccountModel objAcc;

                while (drAcc.Read())
                {
                    objAcc = new AccountModel();

                    objAcc.AC_Id = DataFormat.GetInteger(drAcc["AC_Id"]);
                    objAcc.ParentId = DataFormat.GetInteger(drAcc["Credit_Id"]);
                    objAcc.DC = drAcc["DC"].ToString();
                    objAcc.Account = drAcc["Account"].ToString();
                    objAcc.Debit = Convert.ToDecimal(drAcc["Debit"]);
                    objAcc.Credit = Convert.ToDecimal(drAcc["Credit"]);
                    objAcc.Narration = drAcc["Narration"].ToString();


                    objcredit.CreditAccountModel.Add(objAcc);

                }

                lstCredit.Add(objcredit);

            }
            return lstCredit;
        }

        //        SELECT C.CN_DATE, C.VOUCHERNO, C.TYPE, A.ACCOUNT, A.CREDIT FROM CREDIT_NOTE C
        //INNER JOIN CREDIT_NOTE_ACCOUNTS A
        //ON A.CREDIT_ID= C.CREDIT_ID WHERE A.DC= 'C';
        */

        public bool DeletePhysicalStock(int id)
        {            
            bool isDelete = false;
            try
            {
                if(DeletePhysicalStockItems(id))
                { 
                     string Query = "DELETE * FROM Physical_Stock_Voucher WHERE Physical_Id=" + id;
                    int rowes = _dbHelper.ExecuteNonQuery(Query);
                     if(rowes>0)
                    isDelete= true;                  
                }
            }
            catch(Exception ex)
            {
                isDelete = false;             
            }
            return isDelete;
        }

        public bool DeletePhysicalStockItems(int id)
        {
            bool isDelete =false;
            try
            {
                string Query = "DELETE * FROM Physical_Stock_Items WHERE Physical_Id=" + id;
                int rowes = _dbHelper.ExecuteNonQuery(Query);
                if(rowes>0)
                    isDelete = true;                
            }
            catch (Exception ex)
            {
                isDelete = false;           
            }
            return isDelete;
        }

       
    }
}
