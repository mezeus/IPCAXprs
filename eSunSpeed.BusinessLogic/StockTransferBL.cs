using eSunSpeed.DataAccess;
using eSunSpeed.Formatting;
using eSunSpeedDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeed.BusinessLogic
{
    public class StockTransferBL
    {
        private DBHelper _dbHelper = new DBHelper();

        #region SAVE Stock Transfer
        public bool SaveStockVoucher(StockTransferModel objStock)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@VoucherNumber", objStock.Voucher_Number));
                paramCollection.Add(new DBParameter("@Series", objStock.Series));
                paramCollection.Add(new DBParameter("@Date", objStock.ST_Date, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@StockFrom", objStock.FromDate));
                paramCollection.Add(new DBParameter("@StockTo", objStock.ToDate));
                paramCollection.Add(new DBParameter("@Narration", objStock.Narration));
                paramCollection.Add(new DBParameter("@ItemTotalAmount", objStock.TotalAmount));
                paramCollection.Add(new DBParameter("@ItemTotalQty", objStock.TotalQty));

                paramCollection.Add(new DBParameter("@BSTotalAmount", objStock.BSTotalAmount));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertStockTransMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);

                int id = 0;
                dr.Read();
                id = Convert.ToInt32(dr[0]);

                SaveStockItems(objStock.StockItem_Voucher, id);
                SaveStockBillSundry(objStock.StockBillSundry_Voucher, id);
            }
            catch (Exception ex)
            {
                isSaved = false;
                throw ex;
            }

            return isSaved;
        }

        public bool SaveStockItems(List<Item_VoucherModel> lstSales,int ParentId)
        {
            string Query = string.Empty;
            bool isSaved = true;

            foreach (Item_VoucherModel item in lstSales)
            {
                item.ParentId = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@StockId", item.ParentId));
                    //paramCollection.Add(new DBParameter("@Batch", item.Batch));
                    paramCollection.Add(new DBParameter("@Item", item.Item));
                    paramCollection.Add(new DBParameter("@Qty", item.Qty));
                    paramCollection.Add(new DBParameter("@Unit", item.Unit));
                    paramCollection.Add(new DBParameter("@Price", item.Price));
                    paramCollection.Add(new DBParameter("@Amount", item.Amount));
                    //paramCollection.Add(new DBParameter("@TotalQty", item.TotalQty));
                    //paramCollection.Add(new DBParameter("@TotalAmount", item.TotalAmount));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertStockTransferItem", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }

        public bool SaveStockBillSundry(List<BillSundry_VoucherModel> lstBS,int ParentId)
        {
            string Query = string.Empty;
            bool isSaved = true;

            foreach (BillSundry_VoucherModel bs in lstBS)
            {
                bs.ParentId = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@StockId", bs.ParentId));
                    paramCollection.Add(new DBParameter("@BillSundry", bs.BillSundry));
                    paramCollection.Add(new DBParameter("@Narration", bs.Narration));
                    paramCollection.Add(new DBParameter("@Percentage", bs.Percentage));
                    paramCollection.Add(new DBParameter("@TotalAmount", bs.Amount));
                    //paramCollection.Add(new DBParameter("@TotalAmount", bs.TotalAmount));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertStockBillSundry", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }

        public int GetStockId()
        {
            string Query = "SELECT MAX(Stock_Id) FROM Stock_Transfer_Voucher";

            int id = Convert.ToInt32(_dbHelper.ExecuteScalar(Query));

            return id;
        }


        #endregion

        #region UPDATE SALE VOUCHER

        public bool UpdateStockTransferVoucher(StockTransferModel objStock)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
              
                paramCollection.Add(new DBParameter("@Series", objStock.Series));
                paramCollection.Add(new DBParameter("@STDate", objStock.ST_Date,System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@VoucherNumber", objStock.Voucher_Number));
                paramCollection.Add(new DBParameter("@fromdate",objStock.FromDate, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@Todate", objStock.ToDate, System.Data.DbType.DateTime));
                
                paramCollection.Add(new DBParameter("@Narration", objStock.Narration));
                paramCollection.Add(new DBParameter("@Createdby", "Admin"));
                paramCollection.Add(new DBParameter("@id", objStock.ST_Id));
                Query = "UPDATE Stock_Transfer_Voucher SET [Series]=@Series,[ST_Date]=@STDate," +
                         "[VoucherNo]=@VoucherNumber,[FromDate]=@fromdate,[ToDate]=@Todate," +
                        "[Narration]=@Narration,[CreatedBy]=@Createdby " +
                        "WHERE Stock_Id=@id";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                {
                    {
                        UpdateItemandBS(objStock);
                        isUpdated = true;
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

        private bool UpdateItemandBS(StockTransferModel objstock)
        {
            try
            {
                //UPDATE Item voucher -CHILD TABLE UPDATES
                foreach (Item_VoucherModel item in objstock.StockItem_Voucher)
                {
                    if (item.Item_ID > 0)
                    {
                        UpdateStockTransferItems(item);

                    }
                    else
                    {
                        SaveStockTransferVoucherItem(item);
                    }
                }

                //Update Bill Sundry Items
                foreach (BillSundry_VoucherModel bs in objstock.StockBillSundry_Voucher)
                {
                    if (bs.BSId > 0)
                    {
                        UpdateStockTransferBillSundryVoucher(bs);

                    }
                    else
                    {
                        SaveStockTransferBillSundryVoucher(bs);
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public bool UpdateStockTransferItems(Item_VoucherModel objItems)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
               
                paramCollection.Add(new DBParameter("@Item", objItems.Item));
                paramCollection.Add(new DBParameter("@Batch", objItems.Qty));
                paramCollection.Add(new DBParameter("@Qty", objItems.Qty));                
                paramCollection.Add(new DBParameter("@Unit", objItems.Unit));
                paramCollection.Add(new DBParameter("@Price", objItems.Price, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@Amount", objItems.Amount, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalQty", objItems.TotalQty, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalAmount", objItems.TotalAmount, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ID", objItems.ParentId));
                paramCollection.Add(new DBParameter("@ItemId", objItems.Item_ID));
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                //paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));

                Query = "UPDATE Stock_Transfer_Items SET [Item]=@Item,[Batch]=@Batch,[Qty]=@Qty,[Unit]=@Unit," +
                "[Price]=@Price,[Amount]=@Amount,[TotalQty]=@TotalQty,[TotalAmount]=@TotalAmount,[ModifiedBy]=@ModifiedBy " +
                "WHERE Stock_Id=@ID AND [ItemId]=@ItemId";


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

        public bool SaveStockTransferVoucherItem(Item_VoucherModel item)
        {
            string Query = string.Empty;
            bool isSaved = true;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ST_ID", (item.ParentId)));
                paramCollection.Add(new DBParameter("@Item", item.Item));
                paramCollection.Add(new DBParameter("@Batch", item.Batch));
                paramCollection.Add(new DBParameter("@Qty", item.Qty));
                paramCollection.Add(new DBParameter("@Unit", (item.Unit)));
                paramCollection.Add(new DBParameter("@Price", Convert.ToDecimal(item.Price)));
                paramCollection.Add(new DBParameter("@Amount", Convert.ToDecimal(item.Amount)));
                paramCollection.Add(new DBParameter("@TotalQty", item.TotalQty));
                paramCollection.Add(new DBParameter("@TotalAmount", Convert.ToDecimal(item.TotalAmount)));

                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                //paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));


                Query = "INSERT INTO Stock_Transfer_Items ([Stock_Id],[Item],[Batch],[Qty],[Unit]," +
                "[Price],[Amount],[TotalQty],[TotalAmount],[ModifiedBy]) VALUES " +
                "(@ST_ID,@Item,@Batch,@Qty,@Unit,@Price,@Amount,@TotalQty,@TotalAmount,@ModifiedBy)";

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

        public bool UpdateStockTransferBillSundryVoucher(BillSundry_VoucherModel objBSVoucher)
        {
            string Query = string.Empty;
            bool isUpdate = true;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                
                paramCollection.Add(new DBParameter("@BillSundry_Name", objBSVoucher.BillSundry));
                paramCollection.Add(new DBParameter("@BillSundry_Amount", objBSVoucher.Amount));
                paramCollection.Add(new DBParameter("@Percentage", objBSVoucher.Percentage));
                paramCollection.Add(new DBParameter("@TotalAmount", objBSVoucher.TotalAmount));
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                //paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));

                paramCollection.Add(new DBParameter("@BillSundry_ID", objBSVoucher.BSId));
                paramCollection.Add(new DBParameter("@Trans_ID", objBSVoucher.ParentId));


                Query = "UPDATE Stock_Transfer_BS SET [BillSundry]=@BillSundry_Name,[Amount]=@BillSundry_Amount," +
                "[Percentage]=@Percentage,[TotalAmount]=@TotalAmount,[ModifiedBy]=@ModifiedBy " +
                "WHERE [BSId]=@BillSundry_ID AND [Stock_Id]=@Trans_ID";

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

        public bool SaveStockTransferBillSundryVoucher(BillSundry_VoucherModel bs)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@ST_ID", bs.ParentId));
                paramCollection.Add(new DBParameter("@Name", bs.BillSundry));
                paramCollection.Add(new DBParameter("@Percentage", Convert.ToDecimal(bs.Percentage)));
                paramCollection.Add(new DBParameter("@Amount", Convert.ToDecimal(bs.Amount)));
                paramCollection.Add(new DBParameter("@TotalAmount", bs.TotalAmount));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                //paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));

                Query = "INSERT INTO Stock_Transfer_BS([Stock_Id],[BillSundry],[Percentage]," +
                "[Amount],[TotalAmount],[CreatedBy]) VALUES " +
                "(@ST_ID,@Name,@Percentage,@Amount,@TotalAmount,@CreatedBy)";

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

        public List<StockTransferModel> GetAllStockTransfer()
        {
            List<StockTransferModel> lstST = new List<StockTransferModel>();
            StockTransferModel objstock;

            string Query = "SELECT * FROM Stock_Transfer_Voucher";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objstock = new StockTransferModel();

                objstock.ST_Id = DataFormat.GetInteger(dr["ST_Id"]);
                objstock.Series = dr["Series"].ToString();
                objstock.SalesType = dr["SalesType"].ToString();
                objstock.ST_Date = DataFormat.GetDateTime(dr["ST_Date"]);
                objstock.Voucher_Number = DataFormat.GetInteger(dr["VoucherNo"]);
                objstock.BillNo = Convert.ToInt32(dr["BillNo"]);
                
                objstock.Party = dr["Party"].ToString();
                objstock.MatCenter = dr["MatCentre"].ToString();
                objstock.Narration = dr["Narration"].ToString();
                //objsales. = Convert.ToDecimal(dr["TotalQty"]);
                //objsales.TotalAmount = Convert.ToDecimal(dr["TotalAmount"]);
                //objsales.BSTotalAmount = Convert.ToDecimal(dr["BSTotalAmount"]);


                //SELECT ST Items
                string itemQuery = "SELECT * FROM Stock_Transfer_Items WHERE Stock_Id=" + objstock.ST_Id;
                System.Data.IDataReader drItem = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                objstock.StockItem_Voucher = new List<Item_VoucherModel>();
                Item_VoucherModel objItemModel;

                while (drItem.Read())
                {
                    objItemModel = new Item_VoucherModel();

                    objItemModel.ParentId = DataFormat.GetInteger(drItem["StockId"]);
                    objItemModel.Item_ID = DataFormat.GetInteger(drItem["ItemId"]);
                    objItemModel.Item = drItem["Item"].ToString();
                    objItemModel.Price = Convert.ToDecimal(drItem["Price"]);
                    objItemModel.Qty = Convert.ToDecimal(drItem["Qty"]);
                    objItemModel.Unit = drItem["Unit"].ToString();

                    objItemModel.Amount = Convert.ToDecimal(drItem["Amount"]);
                    objItemModel.TotalQty = Convert.ToDecimal(drItem["TotalQty"]);
                    objItemModel.TotalAmount = Convert.ToDecimal(drItem["TotalAmount"]);

                    objstock.StockItem_Voucher.Add(objItemModel);

                }

                //SELECT Bill Sundry Voucher items
                string bsQuery = "SELECT * FROM Trans_SalesReturn_BS WHERE StockId=" + objstock.ST_Id;
                System.Data.IDataReader drBS = _dbHelper.ExecuteDataReader(bsQuery, _dbHelper.GetConnObject());

                objstock.StockBillSundry_Voucher = new List<BillSundry_VoucherModel>();
                BillSundry_VoucherModel objBSModel;

                while (drBS.Read())
                {
                    objBSModel = new BillSundry_VoucherModel();

                    objBSModel.ParentId = DataFormat.GetInteger(drBS["StockId"]);
                    objBSModel.BSId = DataFormat.GetInteger(drBS["BSId"]);
                    objBSModel.BillSundry = drBS["BillSundry"].ToString();
                    objBSModel.Percentage = Convert.ToDecimal(drBS["Percentage"]);
                    objBSModel.Amount = Convert.ToDecimal(drBS["Amount"]);
                    objBSModel.TotalAmount = Convert.ToDecimal(drBS["TotalAmount"]);

                    objstock.StockBillSundry_Voucher.Add(objBSModel);

                }

                lstST.Add(objstock);

            }
            return lstST;
        }

        //Delete Stock Transfer
        public bool DeleteStockTransfer(int id)
        {
            bool isDelete = false;
            try
            {
                if (DeleteSTItems(id))
                {
                    if (DeleteSTBS(id))
                    {
                        string Query = "DELETE * FROM Stock_Transfer_Voucher WHERE Stock_Id=" + id;
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

        public bool DeleteSTItems(int id)
        {
            bool isDelete = false;
            try
            {
                string Query = "DELETE * FROM Stock_Transfer_Items WHERE Stock_Id=" + id;
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

        public bool DeleteSTBS(int id)
        {
            bool isDelete = false;
            try
            {
                string Query = "DELETE * FROM Stock_Transfer_BS WHERE Stock_Id=" + id;
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

        public List<TransListModel> GetAllStockList()
        {
            List<TransListModel> lstModel = new List<TransListModel>();
            TransListModel objList;

            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT t.Stock_Id, i.itemid, t.ST_Date, t.series, t.voucherno, i.item, i.qty, i.unit, i.price, i.amount, i.totalqty, i.totalamount FROM Stock_Transfer_Voucher AS t ");
            sbQuery.Append("INNER JOIN Stock_Transfer_items AS i ON t.Stock_Id=i.Stock_Id;");


            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(sbQuery.ToString(), _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objList = new TransListModel();

                objList.Stock_Id = Convert.ToInt32(dr["Stock_Id"]);

                objList.item_id = Convert.ToInt32(dr["itemid"]);
                objList.StockDate = Convert.ToDateTime(dr["ST_Date"]);
                objList.series = Convert.ToString(dr["series"]);
                objList.voucherno = Convert.ToInt32(dr["VoucherNo"]);
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

        public StockTransferModel GetAllStockTransferbyId(int id)
        {
            StockTransferModel objstock = new StockTransferModel();

            string Query = "SELECT * FROM Stock_Transfer_Voucher WHERE Stock_Id=" + id;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {

                objstock.ST_Id = Convert.ToInt32(dr["Stock_Id"]);
                objstock.Series = dr["series"].ToString();
                objstock.ST_Date = DataFormat.GetDateTime(dr["ST_Date"]);
                objstock.Voucher_Number = DataFormat.GetInteger(dr["VoucherNo"]);
                //objstock.FromDate = Convert.ToDateTime(dr["FromDate"]);
                //objstock.ToDate = Convert.ToDateTime(dr["ToDate"]);               
                objstock.Narration = dr["Narration"].ToString();

                //objSalesReturn.TotalQty = Convert.ToDecimal(dr["TotalQty"]);
                //objSalesReturn.TotalAmount = Convert.ToDecimal(dr["TotalAmount"].ToString());
                //objSalesReturn.BSTotalAmount = Convert.ToDecimal(dr["BSTotalAmount"]);
               
                string itemQuery = "SELECT * FROM Stock_Transfer_Items WHERE Stock_Id=" + id;
                System.Data.IDataReader drItems = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                objstock.StockItem_Voucher = new List<Item_VoucherModel>();
                Item_VoucherModel objitem;

                while (drItems.Read())
                {
                    objitem = new Item_VoucherModel();

                    objitem.Item_ID = Convert.ToInt32(drItems["ItemId"]);
                    objitem.ParentId = DataFormat.GetInteger(drItems["Stock_Id"]);
                    objitem.Item = drItems["item"].ToString();
                    objitem.Batch = drItems["Batch"].ToString();
                    objitem.Qty = Convert.ToInt32(drItems["qty"].ToString());
                    objitem.Unit = (drItems["unit"].ToString());
                    objitem.Price = Convert.ToDecimal(drItems["price"]);
                    objitem.Amount = Convert.ToInt32(drItems["amount"].ToString());
                    objitem.TotalAmount = Convert.ToDecimal(drItems["TotalAmount"]);
                    objitem.TotalQty = Convert.ToInt32(drItems["TotalQty"].ToString());

                    objstock.StockItem_Voucher.Add(objitem);

                }

                string BSQuery = "SELECT * FROM Stock_Transfer_BS WHERE Stock_Id=" + id;
                System.Data.IDataReader drbs = _dbHelper.ExecuteDataReader(BSQuery, _dbHelper.GetConnObject());

                objstock.StockBillSundry_Voucher = new List<BillSundry_VoucherModel>();
                BillSundry_VoucherModel objbs;

                while (drbs.Read())
                {
                    objbs = new BillSundry_VoucherModel();

                    objbs.BSId = Convert.ToInt32(drbs["BSId"]);
                    objbs.ParentId = DataFormat.GetInteger(drbs["Stock_Id"]);
                    objbs.BillSundry = drbs["BillSundry"].ToString();
                    objbs.Percentage = Convert.ToDecimal(drbs["Percentage"].ToString());
                    objbs.Amount = Convert.ToDecimal((drbs["Amount"].ToString()));
                    objbs.TotalAmount = Convert.ToDecimal(drbs["TotalAmount"].ToString());

                    objstock.StockBillSundry_Voucher.Add(objbs);

                }

            }
            return objstock;
        }


    }
}
