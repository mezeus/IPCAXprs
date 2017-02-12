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
    public class SalesVoucherBL
    {
        private DBHelper _dbHelper = new DBHelper();

        #region SAVE SALE VOUCHER
        public bool SaveSalesVoucher(TransSalesModel objSales)
        {
            string Query = string.Empty;
            bool isSaved = true;

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
                paramCollection.Add(new DBParameter("@BSTotalAmount", objSales.BSTotalAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalFree", objSales.TotalFree, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalBasicAmount", objSales.TotalBasicAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalDisAmount", objSales.TotalDisAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalTaxAmount", objSales.TotalTaxAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@PriceList", objSales.PriceList));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                paramCollection.Add(new DBParameter("@CreatedDate",DateTime.Now,DbType.DateTime));
                paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, DbType.DateTime));

                System.Data.IDataReader dr = 
                    _dbHelper.ExecuteDataReader("spInsertSalesVoucherMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                int id = 0;
                dr.Read();
                id = Convert.ToInt32(dr[0]);
                SaveSalesVoucherItems(objSales.SalesItem_Voucher,id);
                SaveSalesBillSundryVoucher(objSales.SalesBillSundry_Voucher,id);
            }
            catch (Exception ex)
            {
                isSaved = false;
               throw ex;
            }

            return isSaved;
        }
        //Save Sales Voucher Items Details
        public bool SaveSalesVoucherItems(List<Item_VoucherModel> lstSales,int ParentId)
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
                    paramCollection.Add(new DBParameter("@LedgerId", item.LedgerId));
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
                    paramCollection.Add(new DBParameter("@CreatedDate",DateTime.Now,System.Data.DbType.DateTime));
                    paramCollection.Add(new DBParameter("@ModifiedBy",""));
                    paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));
                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertSalesVoucherItemDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
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
        public bool SaveSalesBillSundryVoucher(List<BillSundry_VoucherModel> lstBS, int ParentId)
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
                    _dbHelper.ExecuteDataReader("spInsertSalesVoucherBS", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }

        public bool SaveBillSundryVoucher(BillSundry_VoucherModel bs)
        {
            string Query = string.Empty;
            bool isSaved = true;         
                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@SalesVoucher_ID", bs.ParentId));
                    paramCollection.Add(new DBParameter("@SalesBillSundry_Name", bs.BillSundry));
                    paramCollection.Add(new DBParameter("@SalesBillSundry_Amount", bs.Amount));
                    paramCollection.Add(new DBParameter("@Percentage", bs.Percentage));
                    paramCollection.Add(new DBParameter("@TotalAmount", bs.TotalAmount));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    Query = "INSERT INTO Trans_Sales_BS([Trans_Sales_Id],[BillSundry],[Amount]," +
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

        public int GetSalesId()
        {
            string Query = "SELECT MAX(Trans_Sales_Id) FROM Trans_Sales";

            int id = Convert.ToInt32(_dbHelper.ExecuteScalar(Query));

            return id;
        }
        #endregion

        //Update Sales Voucher
        public bool UpdateSalesVoucherMaster(eSunSpeedDomain.TransSalesModel objSales)
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
                paramCollection.Add(new DBParameter("@PriceList", objSales.PriceList));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, DbType.DateTime));
                paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, DbType.DateTime));
                paramCollection.Add(new DBParameter("@Trans_Sales_Id", objSales.Trans_Sales_Id));
                System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spUpdateSalesVoucherMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                //Update Sale Item Details
                foreach(Item_VoucherModel item in objSales.SalesItem_Voucher)
                {
                    item.ParentId = objSales.Trans_Sales_Id;
                    if(item.Item_ID>0)
                    {
                        paramCollection = new DBParameterCollection();

                        paramCollection.Add(new DBParameter("@Trans_Sales_Id", item.ParentId));
                        paramCollection.Add(new DBParameter("@ChalidId", item.Item_ID));
                        paramCollection.Add(new DBParameter("@ItemMastid", item.ITM_Id));
                        paramCollection.Add(new DBParameter("@LedgerId", item.LedgerId));
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
                        _dbHelper.ExecuteDataReader("spUpdateSalesVoucherItemDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    }
                    else
                    {
                        paramCollection = new DBParameterCollection();

                        paramCollection.Add(new DBParameter("@Trans_Sales_Id", item.ParentId));
                        paramCollection.Add(new DBParameter("@Itemid", item.ITM_Id));
                        paramCollection.Add(new DBParameter("@LedgerId", item.LedgerId));
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
                        _dbHelper.ExecuteDataReader("spInsertSalesVoucherItemDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    }
                }
                //Update Sales Bill Sundary
                foreach(BillSundry_VoucherModel bs in objSales.SalesBillSundry_Voucher)
                {
                    bs.ParentId = objSales.Trans_Sales_Id;
                    if(bs.BSId>0)
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
                        _dbHelper.ExecuteDataReader("spUpdateSalesVoucherBS", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    }
                    else
                    {
                        paramCollection = new DBParameterCollection();

                        paramCollection.Add(new DBParameter("@Trans_Sales_Id", bs.ParentId));
                        paramCollection.Add(new DBParameter("@BSId", bs.BS_Id));
                        paramCollection.Add(new DBParameter("@Percentage", bs.Percentage));
                        paramCollection.Add(new DBParameter("@Extra", bs.Extra));
                        paramCollection.Add(new DBParameter("@Amount", bs.Amount));
                        paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                        paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, DbType.DateTime));
                        paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                        paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, DbType.DateTime));

                        System.Data.IDataReader drbs =
                        _dbHelper.ExecuteDataReader("spInsertSalesVoucherBS", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
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
  
        public List<TransSalesModel> GetAllSalesVouchers()
        {
            List<TransSalesModel> lstSalesVouchers = new List<TransSalesModel>();
            TransSalesModel objsales;

            string Query = "SELECT * FROM Trans_Sales";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objsales = new eSunSpeedDomain.TransSalesModel();

                objsales.Trans_Sales_Id = DataFormat.GetInteger(dr["Trans_Sales_Id"]);
                objsales.Series = dr["Series"].ToString();
                objsales.SaleDate = DataFormat.GetDateTime(dr["SaleDate"]);
                objsales.VoucherNumber = DataFormat.GetInteger(dr["VoucherNumber"]);
                objsales.SalesType = dr["SalesType"].ToString();
                objsales.Party = dr["Party"].ToString();
                objsales.MatCentre = dr["MatCentre"].ToString();
                objsales.Narration = dr["Narration"].ToString();
                objsales.TotalQty = Convert.ToDecimal(dr["TotalQty"]);
                objsales.TotalAmount = Convert.ToDecimal(dr["TotalAmount"]);
                objsales.BSTotalAmount = Convert.ToDecimal(dr["BSTotalAmount"]);


                //SELECT Sales Items
                string itemQuery = "SELECT * FROM Trans_Sales_Item WHERE TransSalesId=" + objsales.Trans_Sales_Id;
                System.Data.IDataReader drItem = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                objsales.SalesItem_Voucher = new List<Item_VoucherModel>();
                Item_VoucherModel objItemModel;

                while (drItem.Read())
                {
                    objItemModel = new Item_VoucherModel();

                    objItemModel.ParentId = DataFormat.GetInteger(drItem["TransSalesId"]);
                    objItemModel.Item_ID = DataFormat.GetInteger(drItem["ItemId"]);
                    objItemModel.Item = drItem["Item"].ToString();
                    objItemModel.Price = Convert.ToDecimal(drItem["Price"]);
                    objItemModel.Qty = Convert.ToDecimal(drItem["Qty"]);
                    objItemModel.Unit = drItem["Unit"].ToString();

                    objItemModel.Amount = Convert.ToDecimal(drItem["Amount"]);
                    objItemModel.TotalQty = Convert.ToDecimal(drItem["TotalQty"]);
                    objItemModel.TotalAmount = Convert.ToDecimal(drItem["TotalAmount"]);

                    objsales.SalesItem_Voucher.Add(objItemModel);

                }

                //SELECT Bill Sundry Voucher items
                string bsQuery = "SELECT * FROM Trans_Sales_BS WHERE TransSalesId=" + objsales.Trans_Sales_Id;
                System.Data.IDataReader drBS = _dbHelper.ExecuteDataReader(bsQuery, _dbHelper.GetConnObject());

                objsales.SalesBillSundry_Voucher = new List<BillSundry_VoucherModel>();
                BillSundry_VoucherModel objBSModel;

                while (drBS.Read())
                {
                    objBSModel = new BillSundry_VoucherModel();

                    objBSModel.ParentId = DataFormat.GetInteger(drBS["TransSalesId"]);
                    objBSModel.BSId = DataFormat.GetInteger(drBS["BSId"]);
                    objBSModel.BillSundry = drBS["BillSundry"].ToString();
                    objBSModel.Percentage = Convert.ToDecimal(drBS["Percentage"]);
                    objBSModel.Amount = Convert.ToDecimal(drBS["Amount"]);
                    objBSModel.TotalAmount = Convert.ToDecimal(drBS["TotalAmount"]);

                    objsales.SalesBillSundry_Voucher.Add(objBSModel);

                }

                lstSalesVouchers.Add(objsales);

            }
            return lstSalesVouchers;
        }

        public TransSalesModel GetSalesById(String ID)
        {
            //List<TransSalesModel> lstSalesVouchers = new List<TransSalesModel>();
            TransSalesModel objsales = new TransSalesModel();

            string query = string.Empty;
            query = "SELECT count(*) FROM Trans_Sales";
             //int i=_dbHelper.ExecuteNonQuery(query);
            if (ID == "first")
                query = "SELECT TOP 1 * FROM Trans_Sales";
            ID ="1";
            if (ID == "last")
                query = "SELECT TOP 1 * FROM Trans_Sales order by Trans_Sales_Id desc";
            if(Convert.ToInt32(ID)>0)
                query = "SELECT * FROM Trans_Sales WHERE Trans_sales_id=" + ID;

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(query, _dbHelper.GetConnObject());

            while (dr.Read())
            {                
                objsales.Trans_Sales_Id = DataFormat.GetInteger(dr["Trans_Sales_Id"]);
                objsales.Series = dr["Series"].ToString();
                objsales.SaleDate = DataFormat.GetDateTime(dr["SaleDate"]);
                objsales.VoucherNumber = DataFormat.GetInteger(dr["VoucherNumber"]);
                objsales.SalesType = dr["SalesType"].ToString();
                objsales.Party = dr["Party"].ToString();
                objsales.MatCentre = dr["MatCentre"].ToString();
                objsales.Narration = dr["Narration"].ToString();
                objsales.TotalQty = Convert.ToDecimal(dr["TotalQty"]);
                objsales.TotalAmount = Convert.ToDecimal(dr["TotalAmount"]);
                objsales.BSTotalAmount = Convert.ToDecimal(dr["BSTotalAmount"]);

                objsales.Trans_Sales_Id = objsales.Trans_Sales_Id + 1;
                //SELECT Sales Items
                string itemQuery = "SELECT * FROM Trans_Sales_Item WHERE TransSalesId=" + objsales.Trans_Sales_Id;
                System.Data.IDataReader drItem = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                objsales.SalesItem_Voucher = new List<Item_VoucherModel>();
                Item_VoucherModel objItemModel;

                while (drItem.Read())
                {
                    objItemModel = new Item_VoucherModel();

                    objItemModel.ParentId = DataFormat.GetInteger(drItem["TransSalesId"]);
                    objItemModel.Item_ID = DataFormat.GetInteger(drItem["ItemId"]);
                    objItemModel.Item = drItem["Item"].ToString();
                    objItemModel.Price = Convert.ToDecimal(drItem["Price"]);
                    objItemModel.Qty = Convert.ToDecimal(drItem["Qty"]);
                    objItemModel.Unit = drItem["Unit"].ToString();

                    objItemModel.Amount = Convert.ToDecimal(drItem["Amount"]);
                    objItemModel.TotalQty = Convert.ToDecimal(drItem["TotalQty"]);
                    objItemModel.TotalAmount = Convert.ToDecimal(drItem["TotalAmount"]);

                    objsales.SalesItem_Voucher.Add(objItemModel);

                }

                //SELECT Bill Sundry Voucher items
                string bsQuery = "SELECT * FROM Trans_Sales_BS WHERE TransSalesId=" + objsales.Trans_Sales_Id;
                System.Data.IDataReader drBS = _dbHelper.ExecuteDataReader(bsQuery, _dbHelper.GetConnObject());

                objsales.SalesBillSundry_Voucher = new List<BillSundry_VoucherModel>();
                BillSundry_VoucherModel objBSModel;

                while (drBS.Read())
                {
                    objBSModel = new BillSundry_VoucherModel();

                    objBSModel.ParentId = DataFormat.GetInteger(drBS["TransSalesId"]);
                    objBSModel.BSId = DataFormat.GetInteger(drBS["BSId"]);
                    objBSModel.BillSundry = drBS["BillSundry"].ToString();
                    objBSModel.Percentage = Convert.ToDecimal(drBS["Percentage"]);
                    objBSModel.Amount = Convert.ToDecimal(drBS["Amount"]);
                    objBSModel.TotalAmount = Convert.ToDecimal(drBS["TotalAmount"]);

                    objsales.SalesBillSundry_Voucher.Add(objBSModel);

                }

              //  lstSalesVouchers.Add(objsales);

            }
            return objsales;
        }

        //Get List Of Sales Voucher Details In List
        public List<TransListModel> GetAllSalesVoucherMaster()
        {
            List<TransListModel> lstModel = new List<TransListModel>();
            TransListModel objList;
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.AppendLine("SELECT m.SalesVoucher_Id, i.Id,m.SaleDate,m.VoucherNumber, i.ITM_ID, i.Qty, i.Unit,i.Amount,im.ITEM_Name,am.ACC_NAME FROM salesvoucher_master AS m");
            sbQuery.AppendLine("INNER JOIN salesvoucher_itemdetails AS i ON m.SalesVoucher_Id=i.SalesVoucher_Id");
            sbQuery.AppendLine("left join itemmaster as im ON i.itm_id=im.ITM_ID");
            sbQuery.AppendLine("left join accountmaster am ON am.Ac_ID = m.LedgerId;");

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(sbQuery.ToString(), _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objList = new TransListModel();

                objList.trans_sales_id= Convert.ToInt32(dr["SalesVoucher_Id"]);
                objList.item_id = Convert.ToInt32(dr["Id"]);
                objList.saledate = Convert.ToDateTime(dr["SaleDate"]);
                objList.voucherno = Convert.ToInt32(dr["VoucherNumber"]);
                objList.party = Convert.ToString(dr["ACC_NAME"]);
                objList.item = Convert.ToString(dr["ITEM_Name"].ToString()==null?string.Empty: dr["ITEM_Name"].ToString());
                objList.qty= Convert.ToInt32 (dr["Qty"]);
                objList.unit = Convert.ToString(dr["Unit"]);
                objList.amount = Convert.ToDecimal(dr["Amount"]);
                lstModel.Add(objList);

            }
            return lstModel;
        }

        public TransSalesModel GetAllSalesbyId(long id)
        {            
            TransSalesModel objSaleVch =new TransSalesModel();

            StringBuilder sbQuery = new StringBuilder();

            sbQuery.AppendLine("SELECT m.*,am.ACC_NAME FROM `salesvoucher_master` AS m");
            sbQuery.AppendLine("INNER JOIN accountmaster AS am ON m.LedgerId= am.Ac_ID");
            sbQuery.AppendLine("WHERE m.`SalesVoucher_Id`='" + id + "'");
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(sbQuery.ToString(), _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objSaleVch.Trans_Sales_Id = Convert.ToInt64(dr["SalesVoucher_Id"]);
                objSaleVch.VoucherType= dr["VoucherType"].ToString();     
                objSaleVch.SaleDate= DataFormat.GetDateTime(dr["SaleDate"]);
                objSaleVch.Terms = dr["Terms"].ToString();
                objSaleVch.VoucherNumber = Convert.ToInt64(dr["VoucherNumber"]);
                objSaleVch.BillNo =Convert.ToInt64(dr["BillNumber"].ToString());
                objSaleVch.SalesType = dr["SalesType"].ToString();
                objSaleVch.Party = dr["ACC_NAME"].ToString();
                objSaleVch.MatCentre = dr["MatCentre"].ToString();
                objSaleVch.Narration= dr["Narration"].ToString();
                objSaleVch.TotalQty =Convert.ToDecimal(dr["TotalQty"]);
                objSaleVch.TotalAmount =Convert.ToDecimal( dr["TotalAmount"].ToString());
                objSaleVch.BSTotalAmount =Convert.ToDecimal( dr["BSTotalAmount"]);
                objSaleVch.PriceList = dr["PriceList"].ToString();

                //SELECT Item Details
                StringBuilder sbitemQuery = new StringBuilder();
                sbitemQuery.AppendLine("SELECT i.*,im.ITEM_Name,ia.ACC_NAME FROM salesvoucher_itemdetails as i");
                sbitemQuery.AppendLine("left join itemmaster as im on i.ITM_ID=im.ITM_ID");
                sbitemQuery.AppendLine("left join accountmaster as ia on i.LedgerId=ia.AC_ID");
                sbitemQuery.AppendLine("WHERE SalesVoucher_Id='" + id + "'");
                System.Data.IDataReader drItems = _dbHelper.ExecuteDataReader(sbitemQuery.ToString(), _dbHelper.GetConnObject());

                objSaleVch.SalesItem_Voucher = new List<Item_VoucherModel>();
                Item_VoucherModel objitem;

                while (drItems.Read())
                {
                    objitem = new Item_VoucherModel();

                    objitem.Item_ID = Convert.ToInt32(drItems["Id"]);
                    objitem.ParentId = DataFormat.GetInteger(drItems["SalesVoucher_Id"]);
                    objitem.ITM_Id = Convert.ToInt64(drItems["ITM_ID"].ToString()==string.Empty?"0": drItems["ITM_ID"].ToString());
                    objitem.LedgerId = Convert.ToInt64(drItems["LedgerId"].ToString()==string.Empty?"0":drItems["LedgerId"].ToString());
                    objitem.Item = drItems["ITEM_Name"].ToString();
                    objitem.Particulars = drItems["ACC_NAME"].ToString();
                    objitem.Qty = Convert.ToDecimal(drItems["qty"].ToString());
                    objitem.Unit = (drItems["Unit"].ToString());
                    objitem.Per = (drItems["Per"].ToString());
                    objitem.Batch = drItems["Batch"].ToString();                  
                    objitem.Price = Convert.ToDecimal(drItems["Price"]);
                    objitem.Amount =Convert.ToDecimal(drItems["Amount"].ToString());
                    objitem.Free = Convert.ToDecimal(drItems["Free"]);
                    objitem.BasicAmt = Convert.ToDecimal(drItems["BasicAmt"].ToString());
                    objitem.DiscountPercentage = Convert.ToDecimal(drItems["DiscountPercentage"].ToString());
                    objitem.DiscountAmount = Convert.ToDecimal(drItems["DiscountAmount"].ToString());
                    objitem.TaxAmount = Convert.ToDecimal(drItems["TaxAmount"].ToString());

                    objSaleVch.SalesItem_Voucher.Add(objitem);
                }
                //Select BS Details
                StringBuilder sbBSQuery = new StringBuilder();
                sbBSQuery.AppendLine("SELECT pbs.*,mbs.Name FROM salesvoucher_bsdetails as pbs");
                sbBSQuery.AppendLine("inner join  billsundarymaster as mbs on pbs.BS_Id=mbs.BS_Id");
                sbBSQuery.AppendLine("WHERE SalesVoucher_Id='" + id + "'");
                System.Data.IDataReader drbs = _dbHelper.ExecuteDataReader(sbBSQuery.ToString(), _dbHelper.GetConnObject());

                objSaleVch.SalesBillSundry_Voucher = new List<BillSundry_VoucherModel>();
                BillSundry_VoucherModel objbs;

                while (drbs.Read())
                {
                    objbs = new BillSundry_VoucherModel();

                    objbs.BSId = Convert.ToInt32(drbs["BSId"]);
                    objbs.ParentId = DataFormat.GetInteger(drbs["SalesVoucher_Id"]);
                    objbs.BillSundry = drbs["Name"].ToString();
                    objbs.Percentage = Convert.ToDecimal(drbs["Percentage"].ToString());
                    objbs.Extra = drbs["Extra"].ToString();
                    objbs.Amount =Convert.ToDecimal((drbs["Amount"].ToString()));

                    objSaleVch.SalesBillSundry_Voucher.Add(objbs);
                }

            }
            return objSaleVch;
        }
        //Delete Sales Voucher With Chaild Tables
        public bool DeleteSalesVoucher(long id)
        {
            bool isDelete = false;
            try
            {
                if (DeleteSalesVoucherItems(id))
                {
                    if (DeleteSalesVoucherBS(id))
                    {
                        string Query = "DELETE FROM `salesvoucher_master` WHERE SalesVoucher_Id=" + id;
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
        public bool DeleteSalesVoucherItems(long id)
        {
            bool isDelete = true;
            try
            {
                string Query = "DELETE FROM `salesvoucher_itemdetails` WHERE SalesVoucher_Id=" + id;
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
        public bool DeleteSalesVoucherBS(long id)
        {
            bool isDelete = true;
            try
            {
                string Query = "DELETE FROM `salesvoucher_bsdetails` WHERE SalesVoucher_Id=" + id;
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
