using eSunSpeed.DataAccess;
using eSunSpeed.Formatting;
using eSunSpeedDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeed.BusinessLogic
{
    public class SalesReturnVoucherBL
    {
        private DBHelper _dbHelper = new DBHelper();

        #region SAVE SALE RETURN VOUCHER
        public bool SaveSalesReturnVoucher(SalesReturnVoucherModel objSalesRet)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@SalesReturnVoucher_SalesType", objSalesRet.SalesType));
                paramCollection.Add(new DBParameter("@SalesReturnVoucher_Series", objSalesRet.Series));
                paramCollection.Add(new DBParameter("@SalesReturnVoucher_Date", objSalesRet.SR_Date));
                paramCollection.Add(new DBParameter("@SalesReturnVoucher_Number", objSalesRet.Voucher_Number));
                paramCollection.Add(new DBParameter("@SRBillNo", objSalesRet.BillNo));
                paramCollection.Add(new DBParameter("@SRDueDate", objSalesRet.DueDate));
                
                paramCollection.Add(new DBParameter("@SalesReturnVoucher_Party", objSalesRet.Party));
                paramCollection.Add(new DBParameter("@SalesVoucher_MatCenter", objSalesRet.MatCenter));
                paramCollection.Add(new DBParameter("@SRNarration", objSalesRet.Narration));
                paramCollection.Add(new DBParameter("@SRTotalQty", objSalesRet.TotalQty));
                paramCollection.Add(new DBParameter("@SRTotalAmount", objSalesRet.TotalAmount));
                paramCollection.Add(new DBParameter("@SRBSTotal", objSalesRet.BSTotalAmount));

                paramCollection.Add(new DBParameter("@CreatedBy", objSalesRet.CreatedBy));


                Query = "INSERT INTO Trans_SalesReturn ([SalesType],[Series],[SR_Date],[VoucherNo],[BillNo],[DueDate],[Party],[MatCentre],[Narration],[TotalQty],[TotalAmount],[BSTotalAmount]," +
                "[CreatedBy]) VALUES " +
                "(@SalesReturnVoucher_SalesType,@SalesReturnVoucher_Series,@SalesReturnVoucher_Date,@SalesReturnVoucher_Number,@SRBillNo,@SRDueDate," +
                "@SalesReturnVoucher_Party, @SalesVoucher_MatCenter,@SRTotalQty,@SRNarration,@SRTotalAmount,@SRBSTotal,@CreatedBy)";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                {
                    SaveSRItems(objSalesRet.Item_Voucher);
                    SaveSRBillSundry(objSalesRet.BillSundry_Voucher);
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
        
        public bool SaveSRItems(List<Item_VoucherModel> lstSales)
        {
            string Query = string.Empty;
            bool isSaved = true;

            int ParentId = GetSalesReturnId();

            foreach (Item_VoucherModel item in lstSales)
            {
                item.ParentId = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@SalesVoucher_ID", item.ParentId));
                    paramCollection.Add(new DBParameter("@Sales_Item", item.Item));
                    paramCollection.Add(new DBParameter("@Sales_Batch", item.Batch));
                    paramCollection.Add(new DBParameter("@Sales_Qty", item.Qty));
                    paramCollection.Add(new DBParameter("@Sales_Unit", item.Unit));
                    paramCollection.Add(new DBParameter("@Sales_Price", item.Price));
                    paramCollection.Add(new DBParameter("@Sales_Amount", item.Amount));
                    paramCollection.Add(new DBParameter("@TotalQty", item.TotalQty));
                    paramCollection.Add(new DBParameter("@TotalAmount", item.TotalAmount));

                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));


                    Query = "INSERT INTO Trans_SalesReturn_Item([TransSRId],[Item],[Batch],[Qty],[Unit]," +
                    "[Price],[Amount],[TotalQty],[TotalAmount],[CreatedBy]) VALUES " +
                    "(@SalesVoucher_ID,@Sales_Item,@Sales_Batch,@Sales_Qty,@Sales_Unit,@Sales_Price,@Sales_Amount,@TotalQty,@TotalAmount,@CreatedBy)";

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

        public bool SaveSRBillSundry(List<BillSundry_VoucherModel> lstBS)
        {
            string Query = string.Empty;
            bool isSaved = true;

            int ParentId = GetSalesReturnId();

            foreach (BillSundry_VoucherModel bs in lstBS)
            {
                bs.ParentId = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@SalesVoucher_ID", bs.ParentId));
                    paramCollection.Add(new DBParameter("@SalesBillSundry_Name", bs.BillSundry));
                    paramCollection.Add(new DBParameter("@SalesBillSundry_Amount", bs.Amount));
                    paramCollection.Add(new DBParameter("@Percentage", bs.Percentage));
                    paramCollection.Add(new DBParameter("@TotalAmount", bs.TotalAmount));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    Query = "INSERT INTO Trans_SalesReturn_BS([TransSRId],[BillSundry],[Amount]," +
                    "[Percentage],[TotalAmount],[CreatedBy]) VALUES " +
                    "(@SalesVoucher_ID,@SalesBillSundry_Name,@SalesBillSundry_Amount,@Percentage,@TotalAmount,@CreatedBy)";

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

        public int GetSalesReturnId()
        {
            string Query = "SELECT MAX(TransSRId) FROM Trans_SalesReturn";

            int id = Convert.ToInt32(_dbHelper.ExecuteScalar(Query));

            return id;
        }


        #endregion

        #region UPDATE SALE VOUCHER

        public bool UpdateSalesReturnVoucher(SalesReturnVoucherModel objSalesRet)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                
                paramCollection.Add(new DBParameter("@SalesType", objSalesRet.SalesType));
                paramCollection.Add(new DBParameter("@Series", objSalesRet.Series));
                paramCollection.Add(new DBParameter("@SRDate", objSalesRet.SR_Date));
                paramCollection.Add(new DBParameter("@VoucherNumber", objSalesRet.Voucher_Number));
                paramCollection.Add(new DBParameter("@BillNo", objSalesRet.BillNo));


                
                paramCollection.Add(new DBParameter("@Duedate", objSalesRet.DueDate));
                paramCollection.Add(new DBParameter("@Party", objSalesRet.Party));
                paramCollection.Add(new DBParameter("@MatCentre", objSalesRet.MatCenter));
                paramCollection.Add(new DBParameter("@Narration", objSalesRet.Narration));
                paramCollection.Add(new DBParameter("@qty", "0.00"));
                paramCollection.Add(new DBParameter("@amount", "0.00"));
                paramCollection.Add(new DBParameter("@bsamount", "0.00"));
                
                paramCollection.Add(new DBParameter("@Createdby", "Admin"));
                paramCollection.Add(new DBParameter("@PRid", objSalesRet.SR_Id));

                Query = "UPDATE Trans_SalesReturn SET [SalesType]=@SalesType,[Series]=@Series,[SR_Date]=@SRDate," +
                         "[VoucherNo]=@VoucherNumber,[BillNo]=@BillNo,[DueDate]=@Duedate," +
                        "[Party]=@Party,[MatCentre]=@MatCentre," +
                        "[Narration]=@Narration,[CreatedBy]=@Createdby " +
                        "WHERE [TransSRId]=@PRid ";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                {
                    UpdateItemandBS(objSalesRet);
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

        private bool UpdateItemandBS(SalesReturnVoucherModel objSreturns)
        {
            try
            {
                //UPDATE Item voucher -CHILD TABLE UPDATES
                foreach (Item_VoucherModel item in objSreturns.Item_Voucher)
                {
                    if (item.Item_ID > 0)
                    {
                        UpdateSRItems(item);

                    }
                    else
                    {
                        SaveSRVoucherItems(item);
                    }
                }

                //Update Bill Sundry Items
                foreach (BillSundry_VoucherModel bs in objSreturns.BillSundry_Voucher)
                {
                    if (bs.BSId > 0)
                    {
                        UpdateSRBillSundry(bs);

                    }
                    else
                    {
                        SaveSRBillSundryVoucher(bs);
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        

        public bool UpdateSRItems(Item_VoucherModel objSRItem)
        {
            string Query = string.Empty;
            bool isUpdated = true;
          
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Trans_ID", objSRItem.ParentId));
                paramCollection.Add(new DBParameter("@Sales_Item", objSRItem.Item));
                paramCollection.Add(new DBParameter("@Sales_Qty", objSRItem.Qty));
                paramCollection.Add(new DBParameter("@Sales_Unit", objSRItem.Unit));
                paramCollection.Add(new DBParameter("@Sales_Price", objSRItem.Price, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@Sales_Amount", objSRItem.Amount, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalQty", objSRItem.TotalQty, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalAmount", objSRItem.TotalAmount, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ItemId", objSRItem.Item_ID));
                //paramCollection.Add(new DBParameter("@ModifiedBy", objSalesItem.ModifiedBy));
                //paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));

                Query = "UPDATE Trans_SalesReturn_Item SET [Item]=@Sales_Item,[Qty]=@Sales_Qty,[Unit]=@Sales_Unit," +
                "[Price]=@Sales_Price,[Amount]=@Sales_Amount,[TotalQty]=@TotalQty,[TotalAmount]=@TotalAmount,[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
                "WHERE TransSRId=@Trans_ID AND [ItemId]=@ItemId";


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

        public bool UpdateSRBillSundry(BillSundry_VoucherModel objBSVoucher)
        {
            string Query = string.Empty;
            bool isUpdate = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Trans_ID", objBSVoucher.ParentId));
                paramCollection.Add(new DBParameter("@SalesBillSundry_Name", objBSVoucher.BillSundry));
                paramCollection.Add(new DBParameter("@SalesBillSundry_Amount", objBSVoucher.Amount));
                paramCollection.Add(new DBParameter("@Percentage", objBSVoucher.Percentage));
                paramCollection.Add(new DBParameter("@TotalAmount", objBSVoucher.TotalAmount));
                paramCollection.Add(new DBParameter("@ModifiedBy", objBSVoucher.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));

                paramCollection.Add(new DBParameter("@SalesBillSundry_ID", objBSVoucher.BSId));
                

                Query = "UPDATE Trans_SalesReturn_BS SET [BillSundry]=@SalesBillSundry_Name,[Amount]=@SalesBillSundry_Amount," +
                "[Percentage]=@Percentage,[TotalAmount]=@TotalAmount,[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
                "WHERE [BSId]=@SalesBillSundry_ID AND [TransSRId]=@Trans_ID";

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

        public bool SaveSRVoucherItems(Item_VoucherModel item)
        {
            string Query = string.Empty;
            bool isSaved = true;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@SalesVoucher_ID", item.ParentId));
                    paramCollection.Add(new DBParameter("@Sales_Item", item.Item));
                    paramCollection.Add(new DBParameter("@Sales_Batch", item.Batch));
                    paramCollection.Add(new DBParameter("@Sales_Qty", item.Qty));
                    paramCollection.Add(new DBParameter("@Sales_Unit", item.Unit));
                    paramCollection.Add(new DBParameter("@Sales_Price", item.Price));
                    paramCollection.Add(new DBParameter("@Sales_Amount", item.Amount));
                    paramCollection.Add(new DBParameter("@TotalQty", item.TotalQty));
                    paramCollection.Add(new DBParameter("@TotalAmount", item.TotalAmount));

                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));


                    Query = "INSERT INTO Trans_SalesReturn_Item([TransSRId],[Item],[Batch],[Qty],[Unit]," +
                    "[Price],[Amount],[TotalQty],[TotalAmount],[CreatedBy]) VALUES " +
                    "(@SalesVoucher_ID,@Sales_Item,@Sales_Batch,@Sales_Qty,@Sales_Unit,@Sales_Price,@Sales_Amount,@TotalQty,@TotalAmount,@CreatedBy)";

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

        public bool SaveSRBillSundryVoucher(BillSundry_VoucherModel objBS)
        {
            string Query = string.Empty;
            bool isSaved = true;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@SalesVoucher_ID", objBS.ParentId));
                    paramCollection.Add(new DBParameter("@SalesBillSundry_Name", objBS.BillSundry));
                    paramCollection.Add(new DBParameter("@SalesBillSundry_Amount", objBS.Amount));
                    paramCollection.Add(new DBParameter("@Percentage", objBS.Percentage));
                    paramCollection.Add(new DBParameter("@TotalAmount", objBS.TotalAmount));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    Query = "INSERT INTO Trans_SalesReturn_BS([TransSRId],[BillSundry],[Amount]," +
                    "[Percentage],[TotalAmount],[CreatedBy]) VALUES " +
                    "(@SalesVoucher_ID,@SalesBillSundry_Name,@SalesBillSundry_Amount,@Percentage,@TotalAmount,@CreatedBy)";

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

        #endregion

        public List<SalesReturnVoucherModel> GetAllSalesReturn()
        {
            List<SalesReturnVoucherModel> lstSR = new List<SalesReturnVoucherModel>();
            SalesReturnVoucherModel objsales;

            string Query = "SELECT * FROM Trans_SalesReturn";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objsales = new SalesReturnVoucherModel();

                objsales.SR_Id = DataFormat.GetInteger(dr["SR_Id"]);
                objsales.Series = dr["Series"].ToString();
                objsales.SR_Date = DataFormat.GetDateTime(dr["SR_Date"]);
                objsales.Voucher_Number = DataFormat.GetInteger(dr["VoucherNo"]);
                objsales.SalesType = dr["SalesType"].ToString();
                objsales.Party = dr["Party"].ToString();
                objsales.MatCenter = dr["MatCentre"].ToString();
                objsales.Narration = dr["Narration"].ToString();
                //objsales. = Convert.ToDecimal(dr["TotalQty"]);
                //objsales.TotalAmount = Convert.ToDecimal(dr["TotalAmount"]);
                //objsales.BSTotalAmount = Convert.ToDecimal(dr["BSTotalAmount"]);


                //SELECT Sales Items
                string itemQuery = "SELECT * FROM Trans_SalesReturn_Item WHERE SR_Id=" + objsales.SR_Id;
                System.Data.IDataReader drItem = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                objsales.Item_Voucher = new List<Item_VoucherModel>();
                Item_VoucherModel objItemModel;

                while (drItem.Read())
                {
                    objItemModel = new Item_VoucherModel();

                    objItemModel.ParentId = DataFormat.GetInteger(drItem["TransSRId"]);
                    objItemModel.Item_ID = DataFormat.GetInteger(drItem["ItemId"]);
                    objItemModel.Item = drItem["Item"].ToString();
                    objItemModel.Price = Convert.ToDecimal(drItem["Price"]);
                    objItemModel.Qty = Convert.ToDecimal(drItem["Qty"]);
                    objItemModel.Unit = drItem["Unit"].ToString();

                    objItemModel.Amount = Convert.ToDecimal(drItem["Amount"]);
                    objItemModel.TotalQty = Convert.ToDecimal(drItem["TotalQty"]);
                    objItemModel.TotalAmount = Convert.ToDecimal(drItem["TotalAmount"]);

                    objsales.Item_Voucher.Add(objItemModel);

                }

                //SELECT Bill Sundry Voucher items
                string bsQuery = "SELECT * FROM Trans_SalesReturn_BS WHERE TransSRId=" + objsales.SR_Id;
                System.Data.IDataReader drBS = _dbHelper.ExecuteDataReader(bsQuery, _dbHelper.GetConnObject());

                objsales.BillSundry_Voucher = new List<BillSundry_VoucherModel>();
                BillSundry_VoucherModel objBSModel;

                while (drBS.Read())
                {
                    objBSModel = new BillSundry_VoucherModel();

                    objBSModel.ParentId = DataFormat.GetInteger(drBS["TransSRId"]);
                    objBSModel.BSId = DataFormat.GetInteger(drBS["BSId"]);
                    objBSModel.BillSundry = drBS["BillSundry"].ToString();
                    objBSModel.Percentage = Convert.ToDecimal(drBS["Percentage"]);
                    objBSModel.Amount = Convert.ToDecimal(drBS["Amount"]);
                    objBSModel.TotalAmount = Convert.ToDecimal(drBS["TotalAmount"]);

                    objsales.BillSundry_Voucher.Add(objBSModel);

                }

                lstSR.Add(objsales);

            }
            return lstSR;
        }

        #region UPDATE SALE VOUCHER



        #endregion

        public List<TransListModel> GetAllSalesReturnList()
        {
            List<TransListModel> lstModel = new List<TransListModel>();
            TransListModel objList;

            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT t.transsrid, i.itemid, t.sr_date, t.series, t.voucherno, t.party, i.item, i.qty, i.unit, i.price, i.amount, i.totalqty, i.totalamount FROM trans_salesreturn AS t ");
            sbQuery.Append("INNER JOIN trans_salesReturn_item AS i ON t.Transsrid=i.Transsrid;");


            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(sbQuery.ToString(), _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objList = new TransListModel();

                objList.trans_sales_id = Convert.ToInt32(dr["TranssrId"]);

                objList.item_id = Convert.ToInt32(dr["itemid"]);
                objList.saledate = Convert.ToDateTime(dr["SR_Date"]);
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

        public SalesReturnVoucherModel GetAllSaleReturnbyId(int id)
        {
            SalesReturnVoucherModel objSalesReturn = new SalesReturnVoucherModel();

            string Query = "SELECT * FROM Trans_SalesReturn WHERE transsrId=" + id;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {

                objSalesReturn.SR_Id = Convert.ToInt32(dr["TransSRId"]);
                objSalesReturn.Series = dr["series"].ToString();

                objSalesReturn.SR_Date = DataFormat.GetDateTime(dr["SR_Date"]);
                objSalesReturn.Voucher_Number = DataFormat.GetInteger(dr["VoucherNo"]);
                objSalesReturn.BillNo = dr["BillNo"].ToString() ;
                objSalesReturn.DueDate = Convert.ToDateTime(dr["DueDate"]);
                objSalesReturn.SalesType = dr["SalesType"].ToString();
                objSalesReturn.Party = dr["party"].ToString();
                objSalesReturn.MatCenter = dr["MatCentre"].ToString();
                objSalesReturn.Narration = dr["Narration"].ToString();
                objSalesReturn.TotalQty = Convert.ToDecimal(dr["TotalQty"]);
                objSalesReturn.TotalAmount = Convert.ToDecimal(dr["TotalAmount"].ToString());
                objSalesReturn.BSTotalAmount = Convert.ToDecimal(dr["BSTotalAmount"]);

                //SELECT Credit Note Accounts

                string itemQuery = "SELECT * FROM Trans_SalesReturn_Item WHERE TransSRId=" + id;
                System.Data.IDataReader drItems = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                objSalesReturn.Item_Voucher = new List<Item_VoucherModel>();
                Item_VoucherModel objitem;

                while (drItems.Read())
                {
                    objitem = new Item_VoucherModel();

                    objitem.Item_ID = Convert.ToInt32(drItems["ItemId"]);
                    objitem.ParentId = DataFormat.GetInteger(drItems["TransSRId"]);
                    objitem.Item = drItems["item"].ToString();
                    objitem.Batch = drItems["Batch"].ToString();
                    objitem.Qty = Convert.ToInt32(drItems["qty"].ToString());
                    objitem.Unit = (drItems["unit"].ToString());
                    objitem.Price = Convert.ToDecimal(drItems["price"]);
                    objitem.Amount = Convert.ToInt32(drItems["amount"].ToString());
                    objitem.TotalAmount = Convert.ToDecimal(drItems["TotalAmount"]);
                    objitem.TotalQty = Convert.ToInt32(drItems["TotalQty"].ToString());

                    objSalesReturn.Item_Voucher.Add(objitem);

                }

                string BSQuery = "SELECT * FROM Trans_SalesReturn_BS WHERE TransSRId=" + id;
                System.Data.IDataReader drbs = _dbHelper.ExecuteDataReader(BSQuery, _dbHelper.GetConnObject());

                objSalesReturn.BillSundry_Voucher = new List<BillSundry_VoucherModel>();
                BillSundry_VoucherModel objbs;

                while (drbs.Read())
                {
                    objbs = new BillSundry_VoucherModel();

                    objbs.BSId = Convert.ToInt32(drbs["BSId"]);
                    objbs.ParentId = DataFormat.GetInteger(drbs["TransSRId"]);
                    objbs.BillSundry = drbs["BillSundry"].ToString();
                    objbs.Percentage = Convert.ToDecimal(drbs["Percentage"].ToString());
                    objbs.Amount = Convert.ToDecimal((drbs["Amount"].ToString()));
                    objbs.TotalAmount = Convert.ToDecimal(drbs["TotalAmount"].ToString());

                    objSalesReturn.BillSundry_Voucher.Add(objbs);

                }

            }
            return objSalesReturn;
        }

        public bool DeleteSalesReturnVoucher(int id)
        {
            bool isDelete = false;
            try
            {
                if (DeleteSalesReturnItems(id))
                {
                    if (DeleteSalesReturnBS(id))
                    {
                        string Query = "DELETE * FROM trans_SalesReturn WHERE transsrid=" + id;
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

        public bool DeleteSalesReturnItems(int id)
        {
            bool isDelete = false;
            try
            {
                string Query = "DELETE * FROM Trans_SalesReturn_Item WHERE transsrid=" + id;
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
        public bool DeleteSalesReturnBS(int id)
        {

            bool isDelete = false;
            try
            {
                string Query = "DELETE * FROM Trans_SalesReturn_BS WHERE transsrid=" + id;
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
    }
}
