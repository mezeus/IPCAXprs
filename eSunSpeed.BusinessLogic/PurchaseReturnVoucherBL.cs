using eSunSpeed.DataAccess;
using eSunSpeed.Formatting;
using eSunSpeedDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeed.BusinessLogic
{
    public class PurchaseReturnVoucherBL
    {
        private DBHelper _dbHelper = new DBHelper();

        #region SAVE SALE PURCHASE VOUCHER
        public bool SavePRVoucher(PurchaseReturnVoucherModel objPRRet)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();


                paramCollection.Add(new DBParameter("@PRSeries", objPRRet.Series));
                paramCollection.Add(new DBParameter("@PRType", objPRRet.PurchaseType));
                paramCollection.Add(new DBParameter("@PR_Date", objPRRet.PR_Date,System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@Voucher_Number", objPRRet.Voucher_Number));
                paramCollection.Add(new DBParameter("@PRBillNo", objPRRet.BillNo));
                paramCollection.Add(new DBParameter("@PRDueDate", objPRRet.DueDate,System.Data.DbType.DateTime));

                paramCollection.Add(new DBParameter("@PRV_Party", objPRRet.Party));
                paramCollection.Add(new DBParameter("@PRV_MatCenter", objPRRet.MatCenter));
                paramCollection.Add(new DBParameter("@PRNarration", objPRRet.Narration));

                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                //paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));


                Query = "INSERT INTO Trans_PurchaseReturn([Series],[PurchaseType],[PR_Date],[VoucherNo],[BillNo],[DueDate],[Party],[MatCenter],[Narration]," +
                "[CreatedBy]) VALUES " +
                "(@PRSeries,@PRType,@PR_Date,@Voucher_Number,@PRBillNo,@PRDueDate, " +
                " @PRV_Party,@PRV_MatCenter,@PRNarration,@CreatedBy)";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                {
                    SavePRItems(objPRRet.Item_Voucher);
                    SavePRBillSundry(objPRRet.BillSundry_Voucher);
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

        public bool SavePRItems(List<Item_VoucherModel> lstSales)
        {
            string Query = string.Empty;
            bool isSaved = true;

            int ParentId = GetPurchaseReturnId();

            foreach (Item_VoucherModel item in lstSales)
            {
                item.ParentId = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@PR_ID",( item.ParentId)));
                    paramCollection.Add(new DBParameter("@PR_Item", item.Item));
                    paramCollection.Add(new DBParameter("@PR_Batch", item.Batch));
                    paramCollection.Add(new DBParameter("@PR_Qty", item.Qty));
                    paramCollection.Add(new DBParameter("@PR_Unit", (item.Unit)));
                    paramCollection.Add(new DBParameter("@PR_Price", Convert.ToDecimal( item.Price)));
                    paramCollection.Add(new DBParameter("@PR_Amount", Convert.ToDecimal(item.Amount)));
                    paramCollection.Add(new DBParameter("@TotalQty", item.TotalQty));
                    paramCollection.Add(new DBParameter("@TotalAmount", Convert.ToDecimal(item.TotalAmount)));

                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));


                    Query = "INSERT INTO Trans_PR_Items([TransPRId],[Item],[Batch],[Qty],[Unit]," +
                    "[Price],[Amount],[TotalQty],[TotalAmount],[CreatedBy],[CreatedDate]) VALUES " +
                    "(@PR_ID,@PR_Item,@PR_Batch,@PR_Qty,@PR_Unit,@PR_Price,@PR_Amount,@TotalQty,@TotalAmount,@CreatedBy,@CreatedDate)";

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

        public bool SavePRBillSundry(List<BillSundry_VoucherModel> lstBS)
        {
            string Query = string.Empty;
            bool isSaved = true;

            int ParentId = GetPurchaseReturnId();

            foreach (BillSundry_VoucherModel bs in lstBS)
            {
                bs.ParentId = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@PR_ID", bs.ParentId));
                    paramCollection.Add(new DBParameter("@PRB_Name", bs.BillSundry));
                    paramCollection.Add(new DBParameter("@Percentage", Convert.ToDecimal(bs.Percentage)));
                    paramCollection.Add(new DBParameter("@PRB_Amount", Convert.ToDecimal(bs.Amount)));
                    paramCollection.Add(new DBParameter("@TotalAmount", bs.TotalAmount));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));

                    Query = "INSERT INTO Trans_PR_BS([TransPRId],[BillSundry],[Percentage]," +
                    "[Amount],[TotalAmount],[CreatedBy],[CreatedDate]) VALUES " +
                    "(@PR_ID,@PRB_Name,@Percentage,@PRB_Amount,@TotalAmount,@CreatedBy,@CreatedDate)";

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

        public int GetPurchaseReturnId()
        {
            string Query = "SELECT MAX(TransPRId) FROM Trans_PurchaseReturn";

            int id = Convert.ToInt32(_dbHelper.ExecuteScalar(Query));

            return id;
        }


        #endregion

        public List<PurchaseReturnVoucherModel> GetAllPurchaseReturn()
        {
            List<PurchaseReturnVoucherModel> lstPurchase = new List<PurchaseReturnVoucherModel>();
            PurchaseReturnVoucherModel objPReturn;

            string Query = "SELECT * FROM Trans_PurchaseReturn";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objPReturn = new PurchaseReturnVoucherModel();

                objPReturn.PR_Id = DataFormat.GetInteger(dr["PR_Id"]);
                objPReturn.Series = dr["Series"].ToString();
                objPReturn.PR_Date = DataFormat.GetDateTime(dr["PR_Date"]);
                objPReturn.Voucher_Number = DataFormat.GetInteger(dr["VoucherNo"]);
                objPReturn.PurchaseType = dr["PurchaseType"].ToString();
                objPReturn.Party = dr["Party"].ToString();
                objPReturn.MatCenter = dr["MatCentre"].ToString();
                objPReturn.Narration = dr["Narration"].ToString();
                //objPReturn. = Convert.ToDecimal(dr["TotalQty"]);
                //objPReturn.TotalAmount = Convert.ToDecimal(dr["TotalAmount"]);
                //objPReturn.BSTotalAmount = Convert.ToDecimal(dr["BSTotalAmount"]);


                //SELECT Purchase Items
                string itemQuery = "SELECT * FROM Trans_PR_Items WHERE Pro_Id=" + objPReturn.PR_Id;
                System.Data.IDataReader drItem = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                objPReturn.Item_Voucher = new List<Item_VoucherModel>();
                Item_VoucherModel objItemModel;

                while (drItem.Read())
                {
                    objItemModel = new Item_VoucherModel();

                    objItemModel.ParentId = DataFormat.GetInteger(drItem["TransPRId"]);
                    objItemModel.Item_ID = DataFormat.GetInteger(drItem["Id"]);
                    objItemModel.Item = drItem["Item"].ToString();
                    objItemModel.Price = Convert.ToDecimal(drItem["Price"]);
                    objItemModel.Qty = Convert.ToDecimal(drItem["Qty"]);
                    objItemModel.Unit = drItem["Unit"].ToString();

                    objItemModel.Amount = Convert.ToDecimal(drItem["Amount"]);
                    objItemModel.TotalQty = Convert.ToDecimal(drItem["TotalQty"]);
                    objItemModel.TotalAmount = Convert.ToDecimal(drItem["TotalAmount"]);

                    objPReturn.Item_Voucher.Add(objItemModel);

                }

                //SELECT Bill Sundry Voucher items
                string bsQuery = "SELECT * FROM Trans_PR_BS WHERE TransPVId=" + objPReturn.PR_Id;
                System.Data.IDataReader drBS = _dbHelper.ExecuteDataReader(bsQuery, _dbHelper.GetConnObject());

                objPReturn.BillSundry_Voucher = new List<BillSundry_VoucherModel>();
                BillSundry_VoucherModel objBSModel;

                while (drBS.Read())
                {
                    objBSModel = new BillSundry_VoucherModel();

                    objBSModel.ParentId = DataFormat.GetInteger(drBS["TransPRId"]);
                    objBSModel.BSId = DataFormat.GetInteger(drBS["BSId"]);
                    objBSModel.BillSundry = drBS["BillSundry"].ToString();
                    objBSModel.Percentage = Convert.ToDecimal(drBS["Percentage"]);
                    objBSModel.Amount = Convert.ToDecimal(drBS["Amount"]);
                    objBSModel.TotalAmount = Convert.ToDecimal(drBS["TotalAmount"]);

                    objPReturn.BillSundry_Voucher.Add(objBSModel);

                }

                lstPurchase.Add(objPReturn);

            }
            return lstPurchase;
        }

        //Delete Purchase ReturnVoucher


        public bool DeletePurchaseReturn(int id)
        {
            bool isDelete = false;
            try
            {
                if (DeletePurchaseReturnItems(id))
                {
                    if (DeletePurchaseReturnBS(id))
                    {
                        string Query = "DELETE * FROM trans_PurchaseReturn WHERE transprid=" + id;
                        int rowes = _dbHelper.ExecuteNonQuery(Query);
                        if (rowes > 0)
                            isDelete = true;
                    }
                }
            }
            catch (Exception ex)
            {
                isDelete = false;
            }
            return isDelete;
        }

        public bool DeletePurchaseReturnItems(int id)
        {
            bool isDelete = false;
            try
            {
                string Query = "DELETE * FROM Trans_PR_Items WHERE transprid=" + id;
                int rowes = _dbHelper.ExecuteNonQuery(Query);
                if (rowes > 0)
                    isDelete = true;
            }
            catch (Exception ex)
            {
                isDelete = false;
            }
            return isDelete;
        }

        public bool DeletePurchaseReturnBS(int id)
        {
            bool isDelete = false;
            try
            {
                string Query = "DELETE * FROM Trans_PR_Bs WHERE transprid=" + id;
                int rowes = _dbHelper.ExecuteNonQuery(Query);
                if (rowes > 0)
                    isDelete = true;
            }
            catch (Exception ex)
            {
                isDelete = false;
            }
            return isDelete;
        }

        public List<TransListModel> GetAllPurchaseReturnVoucher()
        {
            List<TransListModel> lstModel = new List<TransListModel>();
            TransListModel objList;

            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT t.transprid, i.itemid, t.pr_date, t.series, t.voucherno, t.party, i.item, i.qty, i.unit, i.price, i.amount, i.totalqty, i.totalamount FROM trans_PurchaseReturn AS t ");
            sbQuery.Append("INNER JOIN trans_pr_items AS i ON t.TransprId=i.TransprId;");


            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(sbQuery.ToString(), _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objList = new TransListModel();

                objList.trans_sales_id = Convert.ToInt32(dr["TransprId"]);

                objList.item_id = Convert.ToInt32(dr["itemid"]);
                objList.saledate = Convert.ToDateTime(dr["pr_date"]);
                objList.series = Convert.ToString(dr["series"]);
                objList.voucherno = Convert.ToInt32(dr["VoucherNo"]);
                objList.party = Convert.ToString(dr["party"]);
                objList.item = Convert.ToString(dr["item"]);
                objList.qty = Convert.ToInt32(dr["qty"]);
                objList.unit = Convert.ToString(dr["unit"]);
                objList.price = Convert.ToInt32(dr["price"]);
                objList.amount = Convert.ToInt32(dr["amount"]);
                objList.amount = Convert.ToInt32(dr["amount"]);
                objList.totalqty = Convert.ToInt32((dr["totalqty"]));
                objList.totalamount = Convert.ToInt32((dr["totalamount"]));
                lstModel.Add(objList);

            }
            return lstModel;
        }

        public PurchaseReturnVoucherModel GetAllPurchaseReturnById(int id)
        {
            PurchaseReturnVoucherModel objPRVoucher = new PurchaseReturnVoucherModel();

            string Query = "SELECT * FROM Trans_purchaseReturn WHERE transprId=" + id;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {

                objPRVoucher.PR_Id = DataFormat.GetInteger(dr["TransPrId"]);
                objPRVoucher.Series = dr["series"].ToString();
                objPRVoucher.PurchaseType = dr["PurchaseType"].ToString();
                objPRVoucher.PR_Date= DataFormat.GetDateTime(dr["pr_Date"]);

                objPRVoucher.Voucher_Number = DataFormat.GetInteger(dr["Voucherno"]);
                objPRVoucher.BillNo = DataFormat.GetInteger(dr["BillNo"]);
                objPRVoucher.DueDate = DataFormat.GetDateTime(dr["DueDate"]);

                objPRVoucher.Party = dr["party"].ToString();
                objPRVoucher.MatCenter = dr["MatCenter"].ToString();
                objPRVoucher.Narration = dr["Narration"].ToString();
                //objpurchase.t = Convert.ToDecimal(dr["TotalQty"]);
                //objpurchase.TotalAmount = Convert.ToDecimal(dr["TotalAmount"].ToString());
                //objpurchase.BSTotalAmount = Convert.ToDecimal(dr["BSTotalAmount"]);

                //SELECT Purchase Items

                string itemQuery = "SELECT * FROM Trans_pr_items WHERE TransprId=" + id;
                System.Data.IDataReader drItems = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                objPRVoucher.Item_Voucher = new List<Item_VoucherModel>();
                Item_VoucherModel objitem;

                while (drItems.Read())
                {
                    objitem = new Item_VoucherModel();

                    objitem.Item_ID = Convert.ToInt32(drItems["ItemId"]);
                    objitem.ParentId = DataFormat.GetInteger(drItems["TransprId"]);
                    objitem.Item = drItems["item"].ToString();
                    objitem.Batch = drItems["Batch"].ToString();
                    objitem.Qty = Convert.ToInt32(drItems["qty"].ToString());
                    objitem.Unit = (drItems["unit"].ToString());
                    objitem.Price = Convert.ToDecimal(drItems["price"]);
                    objitem.Amount = Convert.ToInt32(drItems["amount"].ToString());
                    objitem.TotalQty = Convert.ToInt32(drItems["TotalQty"].ToString());
                    objitem.TotalAmount = Convert.ToDecimal(drItems["TotalAmount"]);


                    objPRVoucher.Item_Voucher.Add(objitem);

                }

                string BSQuery = "SELECT * FROM Trans_pr_BS WHERE TransprId=" + id;
                System.Data.IDataReader drbs = _dbHelper.ExecuteDataReader(BSQuery, _dbHelper.GetConnObject());

                objPRVoucher.BillSundry_Voucher = new List<BillSundry_VoucherModel>();
                BillSundry_VoucherModel objbs;

                while (drbs.Read())
                {
                    objbs = new BillSundry_VoucherModel();

                    objbs.BSId = Convert.ToInt32(drbs["BSId"]);
                    objbs.ParentId = DataFormat.GetInteger(drbs["TransprId"]);
                    objbs.BillSundry = drbs["BillSundry"].ToString();
                    objbs.Percentage = Convert.ToDecimal(drbs["Percentage"].ToString());
                    objbs.Amount = Convert.ToDecimal((drbs["Amount"].ToString()));
                    objbs.TotalAmount = Convert.ToDecimal(drbs["TotalAmount"].ToString());

                    objPRVoucher.BillSundry_Voucher.Add(objbs);

                }

            }
            return objPRVoucher;
        }

        public bool UpdatePurchaseReturnVoucher(PurchaseReturnVoucherModel objpurchaseReturn)
        {
            string Query = string.Empty;
            bool isUpdated = false;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Series", objpurchaseReturn.Series));
                paramCollection.Add(new DBParameter("@PurchaseType", objpurchaseReturn.PurchaseType));
                paramCollection.Add(new DBParameter("@PurchaseDate", objpurchaseReturn.PR_Date, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@VoucherNumber", objpurchaseReturn.Voucher_Number));
                paramCollection.Add(new DBParameter("@BillNumber", objpurchaseReturn.BillNo));
                paramCollection.Add(new DBParameter("@DueDate", objpurchaseReturn.DueDate, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@Party", objpurchaseReturn.Party));
                paramCollection.Add(new DBParameter("@MatCentre", objpurchaseReturn.MatCenter));

                paramCollection.Add(new DBParameter("@Narration", objpurchaseReturn.Narration));
                paramCollection.Add(new DBParameter("@TotalQty", objpurchaseReturn.TotalQty, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalAmount", objpurchaseReturn.TotalAmount, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@BSTotalAmount", objpurchaseReturn.BSTotalAmount, System.Data.DbType.Decimal));

                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                //paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));
                paramCollection.Add(new DBParameter("@PurchaseVoucher_ID", objpurchaseReturn.PR_Id));

                Query = "UPDATE Trans_PurchaseReturn SET [Series]=@Series,[PurchaseType]=@PurchaseType, " +
                    "[PR_Date]=@PurchaseDate,[VoucherNo] = @VoucherNumber,[BillNo]=@BillNumber,[DueDate]=@DueDate," +
                    "[Party]=@Party,[MatCenter]=@MatCentre," +
                    "[Narration]=@Narration,[TotalQty]=@TotalQty," +
                    "[TotalAmount]=@TotalAmount,[BSTotalAmount]=@BSTotalAmount," +
                     "[ModifiedBy]=@ModifiedBy " +
                     "WHERE TransPRId=@PurchaseVoucher_ID;";

                //Query = "UPDATE Trans_PurchaseReturn SET [Series]=@Series,[PurchaseType]=@PurchaseType,[PR_Date]=@PurchaseDate," +
                //         "[VoucherNo]=@VoucherNumber,[BillNo]=@BillNumber,DueDate=@DueDate," +
                //        "[Party]=@Party,[MatCenter]=@MatCentre," +
                //        "[Narration]=@Narration,[TotalQty]=@TotalQty," +
                //        "[TotalAmount]=@TotalAmount,[BSTotalAmount]=@BSTotalAmount," +
                //        "[ModifiedBy]=@ModifiedBy " +
                //        "WHERE TransPRId=@PurchaseVoucher_ID;";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                {
                    UpdatePurchaseReturnItemandBS(objpurchaseReturn);
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

        private bool UpdatePurchaseReturnItemandBS(PurchaseReturnVoucherModel objprv)
        {
            try
            {
                //UPDATE Item voucher -CHILD TABLE UPDATES
                foreach (Item_VoucherModel item in objprv.Item_Voucher)
                {
                    if (item.Item_ID > 0)
                    {
                        UpdatePurchaseReturnItems(item);

                    }
                    else
                    {
                        SavePurchaseReturntems(item);
                    }
                }

                //Update Bill Sundry Items
                foreach (BillSundry_VoucherModel bs in objprv.BillSundry_Voucher)
                {
                    if (bs.BSId > 0)
                    {
                        UpdatePurchaseReturnBillSundryVoucher(bs);

                    }
                    else
                    {
                        SavePurchaseReturnBillSundryVoucher(bs);
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

            return true;
        }

        public bool UpdatePurchaseReturnItems(Item_VoucherModel objPRItem)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();


                paramCollection.Add(new DBParameter("@Purchase_Item", objPRItem.Item));
                paramCollection.Add(new DBParameter("@Purchase_batch", objPRItem.Batch));
                paramCollection.Add(new DBParameter("@Purchase_Qty", objPRItem.Qty, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@Purchase_Unit", objPRItem.Unit));
                paramCollection.Add(new DBParameter("@Purchase_Price", objPRItem.Price, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@Purchase_Amount", objPRItem.Amount, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalQty", objPRItem.TotalQty, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalAmount", objPRItem.TotalAmount, System.Data.DbType.Decimal));

                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                //paramCollection.Add(new DBParameter("@ModifiedDate",DateTime.Now));

                paramCollection.Add(new DBParameter("@PurchaseId", objPRItem.ParentId));
                paramCollection.Add(new DBParameter("@ItemId", objPRItem.Item_ID));

                Query = "UPDATE Trans_PR_Items SET [Item]=@Purchase_Item,[Batch]=@Purchase_batch,[Qty]=@Purchase_Qty,[Unit]=@Purchase_Unit,"+
                         "[Price]=@Purchase_Price,[Amount]=@Purchase_Amount,[TotalQty]=@TotalQty,[TotalAmount]=@TotalAmount,[ModifiedBy]=@ModifiedBy " +
                        "WHERE transPRId=@PurchaseId AND [ItemId]=@ItemId";


                //Query = "UPDATE Trans_PR_Items SET [Item]=@Purchase_Item,[Batch]=@Purchase_batch,[Qty]=@Purchase_Qty,[Unit]=@Purchase_Unit," +
                //"[Price]=@Purchase_Price,[Amount]=@Purchase_Amount,[TotalQty]=@TotalQty,[TotalAmount]=@TotalAmount,[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
                //"WHERE transPRId=@PurchaseId AND [ItemId]=@ItemId";


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

        public bool SavePurchaseReturntems(Item_VoucherModel objItems)
        {
            string Query = string.Empty;
            bool isSaved = true;          

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@PR_ID", (objItems.ParentId)));
                    paramCollection.Add(new DBParameter("@PR_Item", objItems.Item));
                    paramCollection.Add(new DBParameter("@PR_Batch", objItems.Batch));
                    paramCollection.Add(new DBParameter("@PR_Qty", objItems.Qty));
                    paramCollection.Add(new DBParameter("@PR_Unit", (objItems.Unit)));
                    paramCollection.Add(new DBParameter("@PR_Price", Convert.ToDecimal(objItems.Price)));
                    paramCollection.Add(new DBParameter("@PR_Amount", Convert.ToDecimal(objItems.Amount)));
                    paramCollection.Add(new DBParameter("@TotalQty", objItems.TotalQty));
                    paramCollection.Add(new DBParameter("@TotalAmount", Convert.ToDecimal(objItems.TotalAmount)));

                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));


                    Query = "INSERT INTO Trans_PR_Items([TransPRId],[Item],[Batch],[Qty],[Unit]," +
                    "[Price],[Amount],[TotalQty],[TotalAmount],[CreatedBy],[CreatedDate]) VALUES " +
                    "(@PR_ID,@PR_Item,@PR_Batch,@PR_Qty,@PR_Unit,@PR_Price,@PR_Amount,@TotalQty,@TotalAmount,@CreatedBy,@CreatedDate)";

                    if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                        isSaved = true;
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            
            return isSaved;
        }

         public bool UpdatePurchaseReturnBillSundryVoucher(BillSundry_VoucherModel objBSVoucher)
        {
            string Query = string.Empty;
            bool isUpdate = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();


                paramCollection.Add(new DBParameter("@PurchaseBillSundry_Name", objBSVoucher.BillSundry));
                paramCollection.Add(new DBParameter("@PurchaseBillSundry_Amount", objBSVoucher.Amount));
                paramCollection.Add(new DBParameter("@Percentage", objBSVoucher.Percentage));
                paramCollection.Add(new DBParameter("@TotalAmount", objBSVoucher.TotalAmount));
                paramCollection.Add(new DBParameter("@ModifiedBy", objBSVoucher.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));

                paramCollection.Add(new DBParameter("@PurchaseBillSundry_ID", objBSVoucher.BSId));
                paramCollection.Add(new DBParameter("@PurchaseVoucher_ID", objBSVoucher.ParentId));

                Query = "UPDATE Trans_pr_BS SET [BillSundry]=@PurchaseBillSundry_Name,[Amount]=@PurchaseBillSundry_Amount," +
                "[Percentage]=@Percentage,[TotalAmount]=@TotalAmount,[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
                "WHERE [BSId]=@PurchaseBillSundry_ID AND [TransprId]=@PurchaseVoucher_ID";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                    isUpdate = true;
            }
            catch (Exception ex)
            {
                isUpdate = false;
                throw ex;
            }

            return isUpdate;
        }

        public bool SavePurchaseReturnBillSundryVoucher(BillSundry_VoucherModel objBS)
        {
            string Query = string.Empty;
            bool isSaved = true;          

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@PR_ID", objBS.ParentId));
                    paramCollection.Add(new DBParameter("@PRB_Name", objBS.BillSundry));
                    paramCollection.Add(new DBParameter("@Percentage", Convert.ToDecimal(objBS.Percentage)));
                    paramCollection.Add(new DBParameter("@PRB_Amount", Convert.ToDecimal(objBS.Amount)));
                    paramCollection.Add(new DBParameter("@TotalAmount", objBS.TotalAmount));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));

                    Query = "INSERT INTO Trans_PR_BS ([TransPRId],[BillSundry],[Percentage]," +
                    "[Amount],[TotalAmount],[CreatedBy],[CreatedDate]) VALUES " +
                    "(@PR_ID,@PRB_Name,@Percentage,@PRB_Amount,@TotalAmount,@CreatedBy,@CreatedDate)";

                    if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                        isSaved = true;
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            return isSaved;
        }

    }
}
