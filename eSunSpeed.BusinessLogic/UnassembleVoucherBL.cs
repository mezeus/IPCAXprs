using eSunSpeed.DataAccess;
using eSunSpeed.Formatting;
using eSunSpeedDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeed.BusinessLogic
{
    public class UnassembleVoucherBL
    {
        private DBHelper _dbHelper = new DBHelper();
        
        #region SAVE Unassemble VOUCHER
        public bool SaveUnassembleVoucher(UnassembleVoucherModel objAssemble)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@VoucherNumber", objAssemble.Voucher_Number));
                paramCollection.Add(new DBParameter("@Series", objAssemble.Series));
                paramCollection.Add(new DBParameter("@Date", objAssemble.UA_Date, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@BOMName", objAssemble.BOM_Name));
                paramCollection.Add(new DBParameter("@MatCentreIG", objAssemble.MatCenterIG));
                paramCollection.Add(new DBParameter("@MatCentreIC", objAssemble.MatCenterIC));
                paramCollection.Add(new DBParameter("@Narration", objAssemble.Narration));
                //paramCollection.Add(new DBParameter("@ItemTotalAmount", objSales.TotalAmount));
                //paramCollection.Add(new DBParameter("@ItemTotalQty", objSales.TotalQty));

                //paramCollection.Add(new DBParameter("@BSTotalAmount", objSales.BSTotalAmount));

                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertUnassembleMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);

                int id = 0;
                dr.Read();
                id = Convert.ToInt32(dr[0]);

                SaveUnassembleItemgenerate(objAssemble.Item_Generated, id);
                SaveUnassembleItemConsumed(objAssemble.Item_Consumed, id);
            }
            catch (Exception ex)
            {
                isSaved = false;
                throw ex;
            }

            return isSaved;
        }

        public bool SaveUnassembleItemgenerate(List<Item_VoucherModel> lstItemGenerate,int ParentId)
        {
            string Query = string.Empty;
            bool isSaved = true;

            foreach (Item_VoucherModel item in lstItemGenerate)
            {
                item.ParentId = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@UnassembleId", item.ParentId));
                    paramCollection.Add(new DBParameter("@Batch", item.Batch));
                    paramCollection.Add(new DBParameter("@Item", item.Item));
                    paramCollection.Add(new DBParameter("@Qty", item.Qty));
                    paramCollection.Add(new DBParameter("@Unit", item.Unit));
                    paramCollection.Add(new DBParameter("@Price", item.Price));
                    paramCollection.Add(new DBParameter("@Amount", item.Amount));
                    //paramCollection.Add(new DBParameter("@TotalQty", item.TotalQty));
                    //paramCollection.Add(new DBParameter("@TotalAmount", item.TotalAmount));

                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertUnassembleItemgenerated", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }

        public bool SaveUnassembleItemConsumed(List<ItemConsumedModel> lstItemConsumed, int ParentId)
        {
            string Query = string.Empty;
            bool isSaved = true;

            foreach (ItemConsumedModel itemcon in lstItemConsumed)
            {
                itemcon.ParentId = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@UnassembleId", itemcon.ParentId));
                    paramCollection.Add(new DBParameter("@Batch", itemcon.Batch));
                    paramCollection.Add(new DBParameter("@Item", itemcon.Item));
                    paramCollection.Add(new DBParameter("@Qty", itemcon.Qty));
                    paramCollection.Add(new DBParameter("@Unit", itemcon.Unit));
                    paramCollection.Add(new DBParameter("@Price", itemcon.Price));
                    paramCollection.Add(new DBParameter("@Amount", itemcon.Amount));
                    //paramCollection.Add(new DBParameter("@TotalQty", item.TotalQty));
                    //paramCollection.Add(new DBParameter("@TotalAmount", item.TotalAmount));

                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));


                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertUnassembleItemconsumed", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }

                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }

                return isSaved;   
        }


        public bool SaveUnassembleVoucherBillSundryVoucher(BillSundry_VoucherModel bs)
        {
            string Query = string.Empty;
            bool isSaved = true;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@AssembleVoucher_ID", bs.ParentId));
                paramCollection.Add(new DBParameter("@AssembleBillSundry_Name", bs.BillSundry));
                paramCollection.Add(new DBParameter("@AssembleBillSundry_Amount", bs.Amount));
                paramCollection.Add(new DBParameter("@Percentage", bs.Percentage));
                paramCollection.Add(new DBParameter("@TotalAmount", bs.TotalAmount));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                paramCollection.Add(new DBParameter("@CreatedBy", DateTime.Now));

                Query = "INSERT INTO Trans_Unassemble_BS([Unassemble_Id],[BillSundry],[Amount]," +
                "[Percentage],[TotalAmount],[CreatedBy],[CreatedDate]) VALUES " +
                "(@AssembleVoucher_ID,@AssembleBillSundry_Name,@AssembleBillSundry_Amount,@Percentage,@TotalAmount,@CreatedBy,@CreatedDate)";

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

        public int GetUnassembleId()
        {
            string Query = "SELECT MAX(Unassemble_Id) FROM Trans_Unassemble_Voucher";

            int id = Convert.ToInt32(_dbHelper.ExecuteScalar(Query));

            return id;
        }
        #endregion

        #region UPDATE SALE VOUCHER

        public bool UpdateSalesVoucher(UnassembleVoucherModel objassemble)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Series", objassemble.Series));
                paramCollection.Add(new DBParameter("@Date", objassemble.UA_Date));
                paramCollection.Add(new DBParameter("@VoucherNumber", objassemble.Voucher_Number));
                paramCollection.Add(new DBParameter("@BomName", objassemble.BOM_Name));
                paramCollection.Add(new DBParameter("@MatCentre1", objassemble.MatCenterIG));
                paramCollection.Add(new DBParameter("@MatCentre2", objassemble.MatCenterIC));

                paramCollection.Add(new DBParameter("@Narration", objassemble.Narration));
                paramCollection.Add(new DBParameter("@TotalQty", objassemble.TotalAmountIG, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalAmount", objassemble.TotalAmountIG, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@BSTotalAmount", objassemble.BSTotalAmount, System.Data.DbType.Decimal));

                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));
                paramCollection.Add(new DBParameter("@UassembleVoucher_ID", objassemble.UA_Id));

                Query = "UPDATE Trans_Unassemble_Voucher SET [Series]=@Series,[UA_Date]=@Date," +
                         "[VoucherNo]=@VoucherNumber,[BOM_Name]=@BomName," +
                        "[MatCenter1]=@MatCentre1,[MatCenter2]=@MatCentre2," +
                        "[Narration]=@Narration,[TotalQty]=@TotalQty," +
                        "[TotalAmount]=@TotalAmount,[BSTotalAmount]=@BSTotalAmount," +
                        "[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
                        "WHERE Unassemble_Id=@UassembleVoucher_ID;";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                {
                    //UpdateItemandBS(objassemble);
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
       
        //private bool UpdateItemandBS(UnassembleVoucherModel objassemble)
        //{
        //    try
        //    {
        //        //UPDATE Item voucher -CHILD TABLE UPDATES
        //        foreach (Item_VoucherModel item in objassemble.AssembleItem_Voucher)
        //        {
        //            if (item.Item_ID > 0)
        //            {
        //                UpdateUnassembleVoucherItems(item);

        //            }
        //            else
        //            {
        //                SaveUnassembleVoucherItem(item);
        //            }
        //        }

        //        //Update Bill Sundry Items
        //        foreach (BillSundry_VoucherModel bs in objassemble.AssembleBillSundry_Voucher)
        //        {
        //            if (bs.BSId > 0)
        //            {
        //                UpdateUnassembleBillSundryVoucher(bs);

        //            }
        //            else
        //            {
        //                SaveUnassembleVoucherBillSundryVoucher(bs);
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return false;
        //    }

        //    return true;
        //}
    

        public bool UpdateUnassembleVoucherItems(Item_VoucherModel objItems)
        {
            string Query = string.Empty;
            bool isUpdated = true;            

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                
                paramCollection.Add(new DBParameter("@Item", objItems.Item));
                paramCollection.Add(new DBParameter("@Batch", objItems.Batch));
                paramCollection.Add(new DBParameter("@Qty", objItems.Qty,System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@Unit", objItems.Unit));
                paramCollection.Add(new DBParameter("@Price", objItems.Price, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@Amount", objItems.Amount, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalQty", objItems.TotalQty, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalAmount", objItems.TotalAmount, System.Data.DbType.Decimal));                

                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));

                paramCollection.Add(new DBParameter("@Voucher_ID", objItems.ParentId));
                paramCollection.Add(new DBParameter("@ItemId", objItems.Item_ID));

                Query = "UPDATE Trans_Unassemble_Items SET [Item]=@Item,[Batch]=@Batch,[Qty]=@Qty,[Unit]=@Unit," +
                "[Price]=@Price,[Amount]=@Amount,[TotalQty]=@TotalQty,[TotalAmount]=@TotalAmount,[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
                "WHERE Unassemble_ID=@Voucher_ID AND [ItemId]=@ItemId";


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

        public bool UpdateUnassembleBillSundryVoucher(BillSundry_VoucherModel objBSVoucher)
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
                paramCollection.Add(new DBParameter("@ModifiedBy", objBSVoucher.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));
                
                paramCollection.Add(new DBParameter("@BillSundry_ID", objBSVoucher.BSId));
                paramCollection.Add(new DBParameter("@Voucher_ID", objBSVoucher.ParentId));

                Query = "UPDATE Trans_Unassemble_BS SET [BillSundry]=@BillSundry_Name,[Amount]=@BillSundry_Amount," +
                "[Percentage]=@Percentage,[TotalAmount]=@TotalAmount,[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
                "WHERE [BSId]=@SalesBillSundry_ID AND [Unassemble_Id]=@Voucher_ID";

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

        public List<TransListModel> GetAllUnassemble()
        {
            List<TransListModel> lstModel = new List<TransListModel>();
            TransListModel objList;

            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT t.Unassemble_id, i.itemid, t.UA_date, t.series, t.voucherno,i.item,i.qty,i.unit,i.price,i.amount,i.totalqty, i.totalamount FROM trans_Unassemble_Voucher AS t ");
            sbQuery.Append("INNER JOIN trans_Unassemble_items AS i ON t.Unassemble_Id=i.Unassemble_Id;");


            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(sbQuery.ToString(), _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objList = new TransListModel();

                objList.trans_sales_id= Convert.ToInt32(dr["Unassemble_Id"]);

                objList.item_id = Convert.ToInt32(dr["itemid"]);
                objList.saledate = Convert.ToDateTime(dr["UA_Date"]);
                objList.series= Convert.ToString(dr["series"]);
                objList.voucherno = Convert.ToInt32(dr["VoucherNo"]);
                objList.item = Convert.ToString(dr["item"]);
                objList.qty= Convert.ToInt32 (dr["qty"]);
                objList.unit = Convert.ToString(dr["unit"]);
                objList.price = Convert.ToInt32(dr["price"]);
                objList.amount = Convert.ToInt32(dr["amount"]);
                objList.totalqty = Convert.ToInt32((dr["totalqty"]));
                objList.totalamount = Convert.ToInt32((dr["totalamount"]));
                lstModel.Add(objList);

            }
            return lstModel;
        }

        public UnassembleVoucherModel GetAllUnassemblebyId(int id)
        {
            UnassembleVoucherModel objassemble =new UnassembleVoucherModel();

            string Query = "SELECT * FROM Trans_Unassemble_Voucher WHERE Unassemble_Id=" + id;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {

                objassemble.UA_Id = Convert.ToInt32(dr["Unassemble_Id"]);
                objassemble.Series= dr["series"].ToString();

                objassemble.UA_Date= DataFormat.GetDateTime(dr["UA_Date"]);
                objassemble.Voucher_Number = DataFormat.GetInteger(dr["VoucherNo"]);
                objassemble.BOM_Name = dr["BOM_Name"].ToString();
                
                objassemble.MatCenterIG = dr["MatCenter1"].ToString();
                objassemble.MatCenterIC = dr["MatCenter2"].ToString();
                objassemble.Narration= dr["Narration"].ToString();
                objassemble.TotalQtyIG =Convert.ToDecimal(dr["TotalQty"]);
                objassemble.TotalAmountIG =Convert.ToDecimal( dr["TotalAmount"].ToString());
                objassemble.BSTotalAmount =Convert.ToDecimal( dr["BSTotalAmount"]);

                //SELECT Credit Note Accounts

                string itemQuery = "SELECT * FROM Trans_Unassemble_Items WHERE Unassemble_Id=" + id;
                System.Data.IDataReader drItems = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                //objassemble.AssembleItem_Voucher = new List<Item_VoucherModel>();
                Item_VoucherModel objitem;

                while (drItems.Read())
                {
                    objitem = new Item_VoucherModel();

                    objitem.Item_ID = Convert.ToInt32(drItems["ItemId"]);
                    objitem.ParentId = DataFormat.GetInteger(drItems["Unassemble_Id"]);
                    objitem.Item = drItems["item"].ToString();
                    objitem.Batch = drItems["Batch"].ToString();
                    objitem.Qty =Convert.ToInt32( drItems["qty"].ToString());
                    objitem.Unit = (drItems["unit"].ToString());
                    objitem.Price = Convert.ToDecimal(drItems["price"]);
                    objitem.Amount =Convert.ToInt32(drItems["amount"].ToString());
                    objitem.TotalAmount = Convert.ToDecimal(drItems["TotalAmount"]);
                    objitem.TotalQty = Convert.ToInt32(drItems["TotalQty"].ToString());

                    //objassemble.AssembleItem_Voucher.Add(objitem);

                }
                
                string BSQuery = "SELECT * FROM Trans_Unassemble_BS WHERE Unassemble_Id=" + id;
                System.Data.IDataReader drbs = _dbHelper.ExecuteDataReader(BSQuery, _dbHelper.GetConnObject());

                //objassemble.AssembleBillSundry_Voucher = new List<BillSundry_VoucherModel>();
                BillSundry_VoucherModel objbs;

                while (drbs.Read())
                {
                    objbs = new BillSundry_VoucherModel();

                    objbs.BSId = Convert.ToInt32(drbs["BSId"]);
                    objbs.ParentId = DataFormat.GetInteger(drbs["Unassemble_Id"]);
                    objbs.BillSundry = drbs["BillSundry"].ToString();
                    objbs.Percentage = Convert.ToDecimal(drbs["Percentage"].ToString());
                    objbs.Amount =Convert.ToDecimal((drbs["Amount"].ToString()));
                    objbs.TotalAmount= Convert.ToDecimal(drbs["TotalAmount"].ToString());

                    //objassemble.AssembleBillSundry_Voucher.Add(objbs);

                }

            }
            return objassemble;
        }

        public bool DeleteUnassembleVoucher(int id)
        {
            bool isDelete = false;
            try
            {
                if (DeleteUnassembleItems(id))
                {
                    if (DeleteUnassembleBS(id))
                    {
                        string Query = "DELETE * FROM trans_Unassemble_Voucher WHERE Unassemble_Id=" + id;
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

        public bool DeleteUnassembleItems(int id)
        {
            bool isDelete = false;
            try
            {
                string Query = "DELETE * FROM Trans_Unassemble_Items WHERE Unassemble_Id=" + id;
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

        public bool DeleteUnassembleBS(int id)
        {
            bool isDelete = false;
            try
            {
                string Query = "DELETE * FROM Trans_Unassemble_BS WHERE Unassemble_Id=" + id;
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
