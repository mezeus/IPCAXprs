using eSunSpeed.DataAccess;
using eSunSpeed.Formatting;
using eSunSpeedDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace eSunSpeed.BusinessLogic
{
    public class SalesReturnVoucherBL
    {
        private DBHelper _dbHelper = new DBHelper();
        //This BL Used For Sales Return Voucher
        #region SAVE SALE RETURN VOUCHER
        public bool SaveSalesReturn(TransSalesModel objSalesRet)
        {
            string Query = string.Empty;
            bool isSaved = true;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@VoucherType", objSalesRet.VoucherType));
                paramCollection.Add(new DBParameter("@SaleDate", objSalesRet.SaleDate,System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@Terms", objSalesRet.Terms));
                paramCollection.Add(new DBParameter("@VoucherNumber", objSalesRet.VoucherNumber));
                paramCollection.Add(new DBParameter("@BillNumber", objSalesRet.BillNo));
                paramCollection.Add(new DBParameter("@LedgerId", objSalesRet.LedgerId));
                paramCollection.Add(new DBParameter("@SalesType", objSalesRet.SalesType));
                paramCollection.Add(new DBParameter("@MatCentre", objSalesRet.MatCentre));
                paramCollection.Add(new DBParameter("@Narration", objSalesRet.Narration));
                paramCollection.Add(new DBParameter("@TotalAmount", objSalesRet.TotalAmount,DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalQty", objSalesRet.TotalQty, DbType.Decimal));
                paramCollection.Add(new DBParameter("@BSTotalAmount", objSalesRet.BSTotalAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalFree", objSalesRet.TotalFree, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalBasicAmount", objSalesRet.TotalBasicAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalDisAmount", objSalesRet.TotalDisAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalTaxAmount", objSalesRet.TotalTaxAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@PriceList", objSalesRet.PriceList));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, DbType.DateTime));
                paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, DbType.DateTime));

                System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertSalesReturnMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                int id = 0;
                dr.Read();
                id = Convert.ToInt32(dr[0]);
                SaveSalesReturnItems(objSalesRet.SalesItem_Voucher, id);
                SaveSalesReturnBillSundryVoucher(objSalesRet.SalesBillSundry_Voucher, id);
            }
            catch (Exception ex)
            {
                isSaved = false;
                throw ex;
            }

            return isSaved;
        }
        //Save Sales Return Items Details
        public bool SaveSalesReturnItems(List<Item_VoucherModel> lstSales, int ParentId)
        {
            string Query = string.Empty;
            bool isSaved = true;
            foreach (Item_VoucherModel item in lstSales)
            {
                item.ParentId = ParentId;
                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Trans_Sales_Id", item.ParentId));
                    paramCollection.Add(new DBParameter("@ItemId", item.ITM_Id));
                    paramCollection.Add(new DBParameter("@Qty", item.Qty, DbType.Decimal));
                    paramCollection.Add(new DBParameter("@Unit", item.Unit));
                    paramCollection.Add(new DBParameter("@Per", item.Per));
                    paramCollection.Add(new DBParameter("@Price", item.Price, DbType.Decimal));
                    paramCollection.Add(new DBParameter("@Batch", item.Batch));
                    paramCollection.Add(new DBParameter("@Free", item.Free, DbType.Decimal));
                    paramCollection.Add(new DBParameter("@BasicAmt", item.BasicAmt, DbType.Decimal));
                    paramCollection.Add(new DBParameter("@DiscountPercentage", item.DiscountPercentage, DbType.Decimal));
                    paramCollection.Add(new DBParameter("@DiscountAmount", item.DiscountAmount, DbType.Decimal));
                    paramCollection.Add(new DBParameter("@TaxAmount", item.TaxAmount, DbType.Decimal));
                    paramCollection.Add(new DBParameter("@Amount", item.Amount, DbType.Decimal));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                    paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));
                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertSalesReturnItemDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }

        //Save Sales Voucher BillSundary Details
        public bool SaveSalesReturnBillSundryVoucher(List<BillSundry_VoucherModel> lstBS, int ParentId)
        {
            string Query = string.Empty;
            bool isSaved = true;

            foreach (BillSundry_VoucherModel bs in lstBS)
            {
                bs.ParentId = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Trans_Sales_Id", bs.ParentId));
                    paramCollection.Add(new DBParameter("@BSID", bs.BS_Id));
                    paramCollection.Add(new DBParameter("@Percentage", bs.Percentage));
                    paramCollection.Add(new DBParameter("@Extra", bs.Extra));
                    paramCollection.Add(new DBParameter("@Amount", bs.Amount));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, DbType.DateTime));
                    paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                    paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, DbType.DateTime));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertSalesReturnBS", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
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

        #region UPDATE SALE Return VOUCHER
        //Update Sales Return Voucher
        public bool UpdateSalesReturnMaster(TransSalesModel objSales)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@VoucherType", objSales.VoucherType));
                paramCollection.Add(new DBParameter("@SaleDate", objSales.SaleDate, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@Terms", objSales.Terms));
                paramCollection.Add(new DBParameter("@VoucherNumber", objSales.VoucherNumber));
                paramCollection.Add(new DBParameter("@BillNumber", objSales.BillNo));
                paramCollection.Add(new DBParameter("@LedgerId", objSales.LedgerId));
                paramCollection.Add(new DBParameter("@SalesType", objSales.SalesType));
                paramCollection.Add(new DBParameter("@MatCentre", objSales.MatCentre));
                paramCollection.Add(new DBParameter("@Narration", objSales.Narration));
                paramCollection.Add(new DBParameter("@TotalAmount", objSales.TotalAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalQty", objSales.TotalQty, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalFree", objSales.TotalFree, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalBasicAmount", objSales.TotalBasicAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalDisAmount", objSales.TotalDisAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalTaxAmount", objSales.TotalTaxAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@BSTotalAmount", objSales.BSTotalAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@PriceList", objSales.PriceList, DbType.Decimal));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, DbType.DateTime));
                paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, DbType.DateTime));
                paramCollection.Add(new DBParameter("@Trans_Sales_Id", objSales.Trans_Sales_Id));
                System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spUpdateSalesReturnMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                //Update Sale Item Details
                foreach (Item_VoucherModel item in objSales.SalesItem_Voucher)
                {
                    item.ParentId = objSales.Trans_Sales_Id;
                    if (item.Item_ID > 0)
                    {
                        paramCollection = new DBParameterCollection();

                        paramCollection.Add(new DBParameter("@Trans_Sales_Id", item.ParentId));
                        paramCollection.Add(new DBParameter("@Item_ID", item.Item_ID));
                        paramCollection.Add(new DBParameter("@ItemMastid", item.ITM_Id));
                        paramCollection.Add(new DBParameter("@Qty", item.Qty, DbType.Decimal));
                        paramCollection.Add(new DBParameter("@Unit", item.Unit));
                        paramCollection.Add(new DBParameter("@Per", item.Per));
                        paramCollection.Add(new DBParameter("@Price", item.Price, DbType.Decimal));
                        paramCollection.Add(new DBParameter("@Batch", item.Batch));
                        paramCollection.Add(new DBParameter("@Free", item.Free, DbType.Decimal));
                        paramCollection.Add(new DBParameter("@BasicAmt", item.BasicAmt, DbType.Decimal));
                        paramCollection.Add(new DBParameter("@DiscountPercentage", item.DiscountPercentage, DbType.Decimal));
                        paramCollection.Add(new DBParameter("@DiscountAmount", item.DiscountAmount, DbType.Decimal));
                        paramCollection.Add(new DBParameter("@TaxAmount", item.TaxAmount, DbType.Decimal));
                        paramCollection.Add(new DBParameter("@Amount", item.Amount, DbType.Decimal));
                        paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                        paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));
                        paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                        paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));
                        System.Data.IDataReader Idr =
                        _dbHelper.ExecuteDataReader("spUpdateSalesReturnItemDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    }
                    else
                    {
                        paramCollection = new DBParameterCollection();

                        paramCollection.Add(new DBParameter("@Trans_Sales_Id", item.ParentId));
                        paramCollection.Add(new DBParameter("@ItemId", item.ITM_Id));
                        paramCollection.Add(new DBParameter("@Qty", item.Qty, DbType.Decimal));
                        paramCollection.Add(new DBParameter("@Unit", item.Unit));
                        paramCollection.Add(new DBParameter("@Per", item.Per));
                        paramCollection.Add(new DBParameter("@Price", item.Price, DbType.Decimal));
                        paramCollection.Add(new DBParameter("@Batch", item.Batch));
                        paramCollection.Add(new DBParameter("@Free", item.Free, DbType.Decimal));
                        paramCollection.Add(new DBParameter("@BasicAmt", item.BasicAmt, DbType.Decimal));
                        paramCollection.Add(new DBParameter("@DiscountPercentage", item.DiscountPercentage, DbType.Decimal));
                        paramCollection.Add(new DBParameter("@DiscountAmount", item.DiscountAmount, DbType.Decimal));
                        paramCollection.Add(new DBParameter("@TaxAmount", item.TaxAmount, DbType.Decimal));
                        paramCollection.Add(new DBParameter("@Amount", item.Amount, DbType.Decimal));
                        paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                        paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));
                        paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                        paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));
                        System.Data.IDataReader Idr =
                        _dbHelper.ExecuteDataReader("spInsertSalesReturnItemDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    }
                }
                //Update Sales Bill Sundary
                foreach (BillSundry_VoucherModel bs in objSales.SalesBillSundry_Voucher)
                {
                    bs.ParentId = objSales.Trans_Sales_Id;
                    if (bs.BSId > 0)
                    {
                        paramCollection = new DBParameterCollection();

                        paramCollection.Add(new DBParameter("@Trans_Sales_Id", bs.ParentId));
                        paramCollection.Add(new DBParameter("@BS_Id", bs.BSId));
                        paramCollection.Add(new DBParameter("@BSMastID", bs.BS_Id));
                        paramCollection.Add(new DBParameter("@Percentage", bs.Percentage));
                        paramCollection.Add(new DBParameter("@Extra", bs.Extra));
                        paramCollection.Add(new DBParameter("@Amount", bs.Amount));
                        paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                        paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, DbType.DateTime));
                        paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                        paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, DbType.DateTime));

                        System.Data.IDataReader drbs =
                        _dbHelper.ExecuteDataReader("spUpdateSalesReturnBS", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    }
                    else
                    {
                        paramCollection = new DBParameterCollection();

                        paramCollection.Add(new DBParameter("@Trans_Sales_Id", bs.ParentId));
                        paramCollection.Add(new DBParameter("@BSID", bs.BS_Id));
                        paramCollection.Add(new DBParameter("@Percentage", bs.Percentage));
                        paramCollection.Add(new DBParameter("@Extra", bs.Extra));
                        paramCollection.Add(new DBParameter("@Amount", bs.Amount));
                        paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                        paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, DbType.DateTime));
                        paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                        paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, DbType.DateTime));

                        System.Data.IDataReader drbs =
                        _dbHelper.ExecuteDataReader("spInsertSalesReturnBS", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                isUpdated = false;
                //throw ex;
            }

            return isUpdated;
        }

        #endregion
        //Get List Of Sales Return Details In List
        public List<TransListModel> GetAllSalesReturnMaster()
        {
            List<TransListModel> lstModel = new List<TransListModel>();
            TransListModel objList;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.AppendLine("SELECT m.SalesReturn_Id, i.Id,m.SaleRetDate,m.VoucherNumber, i.ITM_ID, i.Qty,i.Unit,im.ITEM_Name,am.ACC_NAME FROM salesreturn_master AS m");
            sbQuery.AppendLine("INNER JOIN salesreturn_itemdetails AS i ON m.SalesReturn_Id=i.SalesReturn_Id");
            sbQuery.AppendLine("inner join itemmaster as im ON i.itm_id=im.ITM_ID");
            sbQuery.AppendLine("inner join accountmaster am ON am.Ac_ID = m.LedgerId;");

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(sbQuery.ToString(), _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objList = new TransListModel();

                objList.trans_sales_id = Convert.ToInt32(dr["SalesReturn_Id"]);
                objList.item_id = Convert.ToInt32(dr["Id"]);
                objList.saledate = Convert.ToDateTime(dr["SaleRetDate"]);
                objList.voucherno = Convert.ToInt32(dr["VoucherNumber"]);
                objList.party = Convert.ToString(dr["ACC_NAME"]);
                objList.item = Convert.ToString(dr["ITEM_Name"]);
                objList.qty = Convert.ToInt32(dr["Qty"]);
                objList.unit = Convert.ToString(dr["Unit"]);
                lstModel.Add(objList);

            }
            return lstModel;
        }
        //Get All Sales Return By Id
        public TransSalesModel GetAllSaleReturnbyId(long id)
        {
            TransSalesModel objSaleVch = new TransSalesModel();

            StringBuilder sbQuery = new StringBuilder();

            sbQuery.AppendLine("SELECT m.*,am.ACC_NAME FROM `salesreturn_master` AS m");
            sbQuery.AppendLine("INNER JOIN accountmaster AS am ON m.LedgerId= am.Ac_ID");
            sbQuery.AppendLine("WHERE m.`SalesReturn_Id`='" + id + "'");
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(sbQuery.ToString(), _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objSaleVch.Trans_Sales_Id = Convert.ToInt64(dr["SalesReturn_Id"]);
                objSaleVch.VoucherType = dr["VoucherType"].ToString();
                objSaleVch.SaleDate = DataFormat.GetDateTime(dr["SaleRetDate"]);
                objSaleVch.Terms = dr["Terms"].ToString();
                objSaleVch.VoucherNumber = Convert.ToInt64(dr["VoucherNumber"]);
                objSaleVch.BillNo = Convert.ToInt64(dr["BillNumber"].ToString());
                objSaleVch.SalesType = dr["SalesType"].ToString();
                objSaleVch.Party = dr["ACC_NAME"].ToString();
                objSaleVch.MatCentre = dr["MatCentre"].ToString();
                objSaleVch.Narration = dr["Narration"].ToString();
                objSaleVch.TotalQty = Convert.ToDecimal(dr["TotalQty"]);
                objSaleVch.TotalAmount = Convert.ToDecimal(dr["TotalAmount"].ToString());
                objSaleVch.BSTotalAmount = Convert.ToDecimal(dr["BSTotalAmount"]);
                objSaleVch.PriceList = dr["PriceList"].ToString();

                //SELECT Item Details
                StringBuilder sbitemQuery = new StringBuilder();
                sbitemQuery.AppendLine("SELECT i.*,im.ITEM_Name FROM salesreturn_itemdetails as i");
                sbitemQuery.AppendLine("inner join itemmaster as im on i.ITM_ID=im.ITM_ID");
                sbitemQuery.AppendLine("WHERE SalesReturn_Id='" + id + "'");
                System.Data.IDataReader drItems = _dbHelper.ExecuteDataReader(sbitemQuery.ToString(), _dbHelper.GetConnObject());

                objSaleVch.SalesItem_Voucher = new List<Item_VoucherModel>();
                Item_VoucherModel objitem;

                while (drItems.Read())
                {
                    objitem = new Item_VoucherModel();

                    objitem.Item_ID = Convert.ToInt32(drItems["Id"]);
                    objitem.ParentId = DataFormat.GetInteger(drItems["SalesReturn_Id"]);
                    objitem.Item = drItems["ITEM_Name"].ToString();
                    objitem.Qty = Convert.ToDecimal(drItems["qty"].ToString());
                    objitem.Unit = (drItems["Unit"].ToString());
                    objitem.Per = (drItems["Per"].ToString());
                    objitem.Batch = drItems["Batch"].ToString();
                    objitem.Price = Convert.ToDecimal(drItems["Price"]);
                    objitem.Amount = Convert.ToDecimal(drItems["Amount"].ToString());
                    objitem.Free = Convert.ToDecimal(drItems["Free"]);
                    objitem.BasicAmt = Convert.ToDecimal(drItems["BasicAmt"].ToString());
                    objitem.DiscountPercentage = Convert.ToDecimal(drItems["DiscountPercentage"].ToString());
                    objitem.DiscountAmount = Convert.ToDecimal(drItems["DiscountAmount"].ToString());
                    objitem.TaxAmount = Convert.ToDecimal(drItems["TaxAmount"].ToString());

                    objSaleVch.SalesItem_Voucher.Add(objitem);
                }
                //Select BS Details
                StringBuilder sbBSQuery = new StringBuilder();
                sbBSQuery.AppendLine("SELECT pbs.*,mbs.Name FROM salesreturn_bsdetails as pbs");
                sbBSQuery.AppendLine("inner join  billsundarymaster as mbs on pbs.BS_Id=mbs.BS_Id");
                sbBSQuery.AppendLine("WHERE SalesReturn_Id='" + id + "'");
                System.Data.IDataReader drbs = _dbHelper.ExecuteDataReader(sbBSQuery.ToString(), _dbHelper.GetConnObject());

                objSaleVch.SalesBillSundry_Voucher = new List<BillSundry_VoucherModel>();
                BillSundry_VoucherModel objbs;

                while (drbs.Read())
                {
                    objbs = new BillSundry_VoucherModel();

                    objbs.BSId = Convert.ToInt32(drbs["Id"]);
                    objbs.ParentId = DataFormat.GetInteger(drbs["SalesReturn_Id"]);
                    objbs.BillSundry = drbs["Name"].ToString();
                    objbs.Percentage = Convert.ToDecimal(drbs["Percentage"].ToString());
                    objbs.Extra = drbs["Extra"].ToString();
                    objbs.Amount = Convert.ToDecimal((drbs["Amount"].ToString()));

                    objSaleVch.SalesBillSundry_Voucher.Add(objbs);
                }

            }
            return objSaleVch;
        }
        //Delete Sales Voucher With Chaild Tables
        public bool DeleteSalesReturn(long id)
        {
            bool isDelete = false;
            try
            {
                if (DeleteSalesReturnItems(id))
                {
                    if (DeleteSalesReturnBS(id))
                    {
                        string Query = "DELETE FROM `salesreturn_master` WHERE SalesReturn_Id=" + id;
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
        //Delete Sales Voucher Item Details
        public bool DeleteSalesReturnItems(long id)
        {
            bool isDelete = true;
            try
            {
                string Query = "DELETE FROM `salesreturn_itemdetails` WHERE SalesReturn_Id=" + id;
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
        //Delete Sales Voucher Bill Sundary Details
        public bool DeleteSalesReturnBS(long id)
        {
            bool isDelete = true;
            try
            {
                string Query = "DELETE FROM `salesreturn_bsdetails` WHERE SalesReturn_Id=" + id;
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
