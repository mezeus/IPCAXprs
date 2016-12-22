using eSunSpeed.DataAccess;
using eSunSpeed.Formatting;
using eSunSpeedDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

                paramCollection.Add(new DBParameter("@VoucherNumber", objSales.VoucherNumber));
                paramCollection.Add(new DBParameter("@Series", objSales.Series));
                paramCollection.Add(new DBParameter("@SaleDate", objSales.SaleDate));
                
                //paramCollection.Add(new DBParameter("@BillNo", objSales.BillNo));
                //paramCollection.Add(new DBParameter("@DueDate", objSales.DueDate));
                paramCollection.Add(new DBParameter("@SalesType", objSales.SalesType));
                paramCollection.Add(new DBParameter("@Party", objSales.Party));
                paramCollection.Add(new DBParameter("@MatCentre", objSales.MatCentre));

                paramCollection.Add(new DBParameter("@Narration", objSales.Narration));
                paramCollection.Add(new DBParameter("@ItemTotalAmount", objSales.TotalAmount));
                paramCollection.Add(new DBParameter("@ItemTotalQty", objSales.TotalQty));
                
                paramCollection.Add(new DBParameter("@BSTotalAmount", objSales.BSTotalAmount));

                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));


                System.Data.IDataReader dr = 
                    _dbHelper.ExecuteDataReader("spInsertSalesVoucher", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                

                //Query = "INSERT INTO Trans_Sales([Series],[SaleDate],[VoucherNumber],[BillNumber],[DueDate],[SalesType],[Party]," +
                //"[MatCentre],[Narration],[TotalQty],[TotalAmount],[BSTotalAmount],[CreatedBy]) VALUES " +
                //"(@Series,@SaleDate,@VoucherNumber,@BillNo,@DueDate,@SalesType,@Party,@MatCentre,@Narration,@TotalQty,@TotalAmount,@BSTotalAmount,@CreatedBy)";

                //if (_dbHelper.ExecuteScalar(Query, paramCollection) > 0)
                //{
                //    SaveSalesVoucherItems(objSales.SalesItem_Voucher);
                //    SaveSalesBillSundryVoucher(objSales.SalesBillSundry_Voucher);
                //    isSaved = true;
                //}


            }
            catch (Exception ex)
            {
                isSaved = false;
               // throw ex;
            }

            return isSaved;
        }

        public bool SaveSalesVoucherItems(List<Item_VoucherModel> lstSales)
        {
            string Query = string.Empty;
            bool isSaved = true;

            int ParentId = GetSalesId();

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


                    Query = "INSERT INTO Trans_Sales_Item([Trans_Sales_Id],[Item],[Qty],[Unit]," +
                    "[Price],[Amount],[TotalQty],[TotalAmount],[CreatedBy]) VALUES " +
                    "(@SalesVoucher_ID,@Sales_Item,@Sales_Qty,@Sales_Unit,@Sales_Price,@Sales_Amount,@TotalQty,@TotalAmount,@CreatedBy)";

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

        public bool SaveSalesVoucherItem(Item_VoucherModel item)
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


                Query = "INSERT INTO Trans_Sales_Item([Trans_Sales_Id],[Item],[Batch],[Qty],[Unit]," +
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

        public bool SaveSalesBillSundryVoucher(List<BillSundry_VoucherModel> lstBS)
        {
            string Query = string.Empty;
            bool isSaved = true;

            int ParentId = GetSalesId();

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

        #region UPDATE SALE VOUCHER

        public bool UpdateSalesVoucher(eSunSpeedDomain.TransSalesModel objSales)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Series", objSales.Series));
                paramCollection.Add(new DBParameter("@SaleDate", objSales.SaleDate));
                paramCollection.Add(new DBParameter("@VoucherNumber", objSales.VoucherNumber));
                paramCollection.Add(new DBParameter("@SalesType", objSales.SalesType));
                paramCollection.Add(new DBParameter("@Party", objSales.Party));
                paramCollection.Add(new DBParameter("@MatCentre", objSales.MatCentre));

                paramCollection.Add(new DBParameter("@Narration", objSales.Narration));
                paramCollection.Add(new DBParameter("@TotalQty", objSales.TotalQty, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalAmount", objSales.TotalAmount, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@BSTotalAmount", objSales.BSTotalAmount, System.Data.DbType.Decimal));

                paramCollection.Add(new DBParameter("@ModifiedBy", objSales.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));
                paramCollection.Add(new DBParameter("@SalesVoucher_ID",objSales.Trans_Sales_Id));

                Query = "UPDATE Trans_Sales SET [Series]=@Series,[SaleDate]=@SaleDate," +
                         "[VoucherNumber]=@VoucherNumber,[SalesType]=@SalesType," +
                        "[Party]=@Party,[MatCentre]=@MatCentre," +
                        "[Narration]=@Narration,[TotalQty]=@TotalQty," +
                        "[TotalAmount]=@TotalAmount,[BSTotalAmount]=@BSTotalAmount," +
                        "[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
                        "WHERE Trans_Sales_Id=@SalesVoucher_ID;";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                {
                    UpdateItemandBS(objSales);
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
       
        private bool UpdateItemandBS(TransSalesModel objSales)
        {
            try
            {
                //UPDATE Item voucher -CHILD TABLE UPDATES
                foreach (Item_VoucherModel item in objSales.SalesItem_Voucher)
                {
                    if (item.Item_ID > 0)
                    {
                        UpdateSalesVoucherItems(item);

                    }
                    else
                    {
                        SaveSalesVoucherItem(item);
                    }
                }

                //Update Bill Sundry Items
                foreach (BillSundry_VoucherModel bs in objSales.SalesBillSundry_Voucher)
                {
                    if (bs.BSId > 0)
                    {
                        UpdateSalesBillSundryVoucher(bs);

                    }
                    else
                    {
                        SaveBillSundryVoucher(bs);
                    }
                }
            }
            catch(Exception ex)
            {
                return false;
            }

            return true;
        }
    

        public bool UpdateSalesVoucherItems(Item_VoucherModel objSalesItem)
        {
            string Query = string.Empty;
            bool isUpdated = true;            

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                
                paramCollection.Add(new DBParameter("@Sales_Item", objSalesItem.Item));
                paramCollection.Add(new DBParameter("@Sales_Qty", objSalesItem.Qty,System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@Sales_Unit", objSalesItem.Unit));
                paramCollection.Add(new DBParameter("@Sales_Price", objSalesItem.Price, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@Sales_Amount", objSalesItem.Amount, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalQty", objSalesItem.TotalQty, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalAmount", objSalesItem.TotalAmount, System.Data.DbType.Decimal));                

                paramCollection.Add(new DBParameter("@ModifiedBy", objSalesItem.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));

                paramCollection.Add(new DBParameter("@SalesVoucher_ID", objSalesItem.ParentId));
                paramCollection.Add(new DBParameter("@ItemId", objSalesItem.Item_ID));

                Query = "UPDATE Trans_Sales_Item SET [Item]=@Sales_Item,[Qty]=@Sales_Qty,[Unit]=@Sales_Unit," +
                "[Price]=@Sales_Price,[Amount]=@Sales_Amount,[TotalQty]=@TotalQty,[TotalAmount]=@TotalAmount,[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
                "WHERE SalesVoucher_ID=@SalesVoucher_ID AND [ItemId]=@ItemId";


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

        public bool UpdateSalesBillSundryVoucher(BillSundry_VoucherModel objBSVoucher)
        {
            string Query = string.Empty;
            bool isUpdate = true;            

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                
                paramCollection.Add(new DBParameter("@SalesBillSundry_Name", objBSVoucher.BillSundry));
                paramCollection.Add(new DBParameter("@SalesBillSundry_Amount", objBSVoucher.Amount));
                paramCollection.Add(new DBParameter("@Percentage", objBSVoucher.Percentage));
                paramCollection.Add(new DBParameter("@TotalAmount", objBSVoucher.TotalAmount));
                paramCollection.Add(new DBParameter("@ModifiedBy", objBSVoucher.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));
                
                paramCollection.Add(new DBParameter("@SalesBillSundry_ID", objBSVoucher.BSId));
                paramCollection.Add(new DBParameter("@SalesVoucher_ID", objBSVoucher.ParentId));

                Query = "UPDATE Trans_Sales_BS SET [BillSundry]=@SalesBillSundry_Name,[Amount]=@SalesBillSundry_Amount," +
                "[Percentage]=@Percentage,[TotalAmount]=@TotalAmount,[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
                "WHERE [BSId]=@SalesBillSundry_ID AND [Trans_Sales_Id]=@SalesVoucher_ID";

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
        #endregion

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

        public List<TransListModel> GetAllSales()
        {
            List<TransListModel> lstModel = new List<TransListModel>();
            TransListModel objList;

            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT t.trans_sales_id, i.itemid, t.saledate, t.series, t.vouchernumber, t.party, i.item, i.qty, i.unit, i.price, i.amount, i.totalqty, i.totalamount FROM trans_sales AS t ");
            sbQuery.Append("INNER JOIN trans_sales_item AS i ON t.Trans_Sales_Id=i.Trans_Sales_Id;");


            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(sbQuery.ToString(), _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objList = new TransListModel();

                objList.trans_sales_id= Convert.ToInt32(dr["Trans_Sales_Id"]);

                objList.item_id = Convert.ToInt32(dr["itemid"]);
                objList.saledate = Convert.ToDateTime(dr["SaleDate"]);
                objList.series= Convert.ToString(dr["series"]);
                objList.voucherno = Convert.ToInt32(dr["VoucherNumber"]);
                objList.party = Convert.ToString(dr["party"]);
                objList.item = Convert.ToString(dr["item"]);
                objList.qty= Convert.ToInt32 (dr["qty"]);
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

        public TransSalesModel GetAllSalesbyId(int id)
        {            
            TransSalesModel objSales =new TransSalesModel();

            string Query = "SELECT * FROM Trans_Sales WHERE trans_sales_Id=" + id;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {

                objSales.Trans_Sales_Id = Convert.ToInt32(dr["Trans_Sales_Id"]);
                objSales.Series= dr["series"].ToString();
                
                objSales.SaleDate= DataFormat.GetDateTime(dr["SaleDate"]);
                objSales.VoucherNumber = DataFormat.GetInteger(dr["VoucherNumber"]);
                objSales.BillNo =Convert.ToInt32(dr["BillNumber"].ToString());
                objSales.DueDate = Convert.ToDateTime(dr["DueDate"]);
                objSales.SalesType = dr["SalesType"].ToString();
                objSales.Party = dr["party"].ToString();
                objSales.MatCentre = dr["MatCentre"].ToString();
                objSales.Narration= dr["Narration"].ToString();
                objSales.TotalQty =Convert.ToDecimal(dr["TotalQty"]);
                objSales.TotalAmount =Convert.ToDecimal( dr["TotalAmount"].ToString());
                objSales.BSTotalAmount =Convert.ToDecimal( dr["BSTotalAmount"]);

                //SELECT Credit Note Accounts

                string itemQuery = "SELECT * FROM Trans_Sales_Item WHERE Trans_Sales_Id=" + id;
                System.Data.IDataReader drItems = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                objSales.SalesItem_Voucher = new List<Item_VoucherModel>();
                Item_VoucherModel objitem;

                while (drItems.Read())
                {
                    objitem = new Item_VoucherModel();

                    objitem.Item_ID = Convert.ToInt32(drItems["ItemId"]);
                    objitem.ParentId = DataFormat.GetInteger(drItems["Trans_Sales_Id"]);
                    objitem.Item = drItems["item"].ToString();
                    objitem.Batch = drItems["Batch"].ToString();
                    objitem.Qty =Convert.ToInt32( drItems["qty"].ToString());
                    objitem.Unit = (drItems["unit"].ToString());
                    objitem.Price = Convert.ToDecimal(drItems["price"]);
                    objitem.Amount =Convert.ToInt32(drItems["amount"].ToString());
                    objitem.TotalAmount = Convert.ToDecimal(drItems["TotalAmount"]);
                    objitem.TotalQty = Convert.ToInt32(drItems["TotalQty"].ToString());

                    objSales.SalesItem_Voucher.Add(objitem);

                }
                
                string BSQuery = "SELECT * FROM Trans_Sales_BS WHERE Trans_Sales_Id=" + id;
                System.Data.IDataReader drbs = _dbHelper.ExecuteDataReader(BSQuery, _dbHelper.GetConnObject());

                objSales.SalesBillSundry_Voucher = new List<BillSundry_VoucherModel>();
                BillSundry_VoucherModel objbs;

                while (drbs.Read())
                {
                    objbs = new BillSundry_VoucherModel();

                    objbs.BSId = Convert.ToInt32(drbs["BSId"]);
                    objbs.ParentId = DataFormat.GetInteger(drbs["Trans_Sales_Id"]);
                    objbs.BillSundry = drbs["BillSundry"].ToString();
                    objbs.Percentage = Convert.ToDecimal(drbs["Percentage"].ToString());
                    objbs.Amount =Convert.ToDecimal((drbs["Amount"].ToString()));
                    objbs.TotalAmount= Convert.ToDecimal(drbs["TotalAmount"].ToString());

                    objSales.SalesBillSundry_Voucher.Add(objbs);

                }

            }
            return objSales;
        }

        public bool DeleteSalesVoucher(int id)
        {
            bool isDelete = false;
            try
            {
                if (DeleteSalesItems(id))
                {
                    if (DeleteSalesBS(id))
                    {
                        string Query = "DELETE * FROM trans_Sales WHERE trans_Sales_Id=" + id;
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

        public bool DeleteSalesItems(int id)
        {
            bool isDelete = false;
            try
            {
                string Query = "DELETE * FROM Trans_Sales_Item WHERE trans_Sales_Id=" + id;
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

        public bool DeleteSalesBS(int id)
        {
            bool isDelete = false;
            try
            {
                string Query = "DELETE * FROM Trans_Sales_BS WHERE trans_Sales_Id=" + id;
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
