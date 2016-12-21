using eSunSpeed.DataAccess;
using eSunSpeed.Formatting;
using eSunSpeedDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeed.BusinessLogic
{
    public class ProductionVoucherBL
    {
        private DBHelper _dbHelper = new DBHelper();

        #region SAVE PROUCTION VOUCHER
        public bool SaveProductionVoucher(ProductionVoucherModel objProduction)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();


                paramCollection.Add(new DBParameter("@ProductiopnSeries", objProduction.Series));
                paramCollection.Add(new DBParameter("@ProductionType", objProduction.ProductionType));
                paramCollection.Add(new DBParameter("@Date", objProduction.PV_Date));
                paramCollection.Add(new DBParameter("@Voucher_Number", objProduction.Voucher_Number));
                paramCollection.Add(new DBParameter("@BillNo", objProduction.BillNo));
                paramCollection.Add(new DBParameter("@DueDate", objProduction.DueDate));

                paramCollection.Add(new DBParameter("@Party", objProduction.Party));
                paramCollection.Add(new DBParameter("@MatCenter", objProduction.MatCenter));
                paramCollection.Add(new DBParameter("@Narration", objProduction.Narration));

                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));


                Query = "INSERT INTO Trans_Production_Voucher ([Series],[Production_Type],[Production_Date],[VoucherNo],[BillNo],[DueDate],[Party],[MatCenter],[Narration]," +
                "[CreatedBy],[CreatedDate]) VALUES " +
                "(@ProductiopnSeries,@ProductionType,@Date,@Voucher_Number,@BillNo,@DueDate, " +
                " @Party,@MatCenter,@Narration,@CreatedBy,@CreatedDate)";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                {
                    SaveProductionItems(objProduction.Item_Voucher);
                    SaveProductionBillSundry(objProduction.BillSundry_Voucher);
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

        public bool SaveProductionItems(List<Item_VoucherModel> lstItems)
        {
            string Query = string.Empty;
            bool isSaved = true;

            int ParentId = GetProductonReturnId();

            foreach (Item_VoucherModel item in lstItems)
            {
                item.ParentId = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@PV_ID",( item.ParentId)));
                    paramCollection.Add(new DBParameter("@Item", item.Item));
                    paramCollection.Add(new DBParameter("@Batch", item.Batch));
                    paramCollection.Add(new DBParameter("@Qty", item.Qty));
                    paramCollection.Add(new DBParameter("@Unit", (item.Unit)));
                    paramCollection.Add(new DBParameter("@Price", Convert.ToDecimal( item.Price)));
                    paramCollection.Add(new DBParameter("@Amount", Convert.ToDecimal(item.Amount)));
                    paramCollection.Add(new DBParameter("@TotalQty", item.TotalQty));
                    paramCollection.Add(new DBParameter("@TotalAmount", Convert.ToDecimal(item.TotalAmount)));

                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));


                    Query = "INSERT INTO Trans_Production_Items([Production_Id],[Item],[Batch],[Qty],[Unit]," +
                    "[Price],[Amount],[TotalQty],[TotalAmount],[CreatedBy],[CreatedDate]) VALUES " +
                    "(@PV_ID,@Item,@Batch,@Qty,@Unit,@Price,@Amount,@TotalQty,@TotalAmount,@CreatedBy,@CreatedDate)";

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

        public bool SaveProductionBillSundry(List<BillSundry_VoucherModel> lstBS)
        {
            string Query = string.Empty;
            bool isSaved = true;

            int ParentId = GetProductonReturnId();

            foreach (BillSundry_VoucherModel bs in lstBS)
            {
                bs.ParentId = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@PV_ID", bs.ParentId));
                    paramCollection.Add(new DBParameter("@Name", bs.BillSundry));
                    paramCollection.Add(new DBParameter("@Percentage", Convert.ToDecimal(bs.Percentage)));
                    paramCollection.Add(new DBParameter("@Amount", Convert.ToDecimal(bs.Amount)));
                    paramCollection.Add(new DBParameter("@TotalAmount", bs.TotalAmount));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));

                    Query = "INSERT INTO Trans_Production_BS ([Production_id],[BillSundry],[Percentage]," +
                    "[Amount],[TotalAmount],[CreatedBy],[CreatedDate]) VALUES " +
                    "(@PV_ID,@Name,@Percentage,@Amount,@TotalAmount,@CreatedBy,@CreatedDate)";

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

        public int GetProductonReturnId()
        {
            string Query = "SELECT MAX(Production_Id) FROM Trans_Production_Voucher";

            int id = Convert.ToInt32(_dbHelper.ExecuteScalar(Query));

            return id;
        }


        #endregion

        #region UPDATE SALE VOUCHER

        public bool UpdateProductionVoucher(ProductionVoucherModel objProduction)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                
               
                paramCollection.Add(new DBParameter("@Series", objProduction.Series));
                paramCollection.Add(new DBParameter("@PVType", objProduction.ProductionType));
                paramCollection.Add(new DBParameter("@PVDate", objProduction.PV_Date));
                paramCollection.Add(new DBParameter("@VoucherNumber", objProduction.Voucher_Number));
                paramCollection.Add(new DBParameter("@BillNo", objProduction.BillNo));

                paramCollection.Add(new DBParameter("@Duedate", objProduction.DueDate));
                paramCollection.Add(new DBParameter("@Party", objProduction.Party));
                paramCollection.Add(new DBParameter("@MatCentre", objProduction.MatCenter));

                paramCollection.Add(new DBParameter("@Narration", objProduction.Narration));
                paramCollection.Add(new DBParameter("@TotalQty", objProduction.TotalQty, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalAmount", objProduction.TotalAmount, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@BSTotalAmount", objProduction.BSTotalAmount, System.Data.DbType.Decimal));


                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate",DateTime.Now));
                paramCollection.Add(new DBParameter("@id", objProduction.Production_Id));

                Query = "UPDATE Trans_Production_Voucher SET [Series]=@Series,[Production_Type]=@PVType,[Production_Date]=@PVDate," +
                         "[VoucherNo]=@VoucherNumber,[BillNo]=@BillNo,[DueDate]=@Duedate," +
                        "[Party]=@Party,[MatCenter]=@MatCenter,[Narration]=@Narration,[TotalQty]=@TotalQty,[TotalAmount]=@TotalAmount,[BSTotalAmount]=@BSTotalAmount," +
                        "[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
                        "WHERE Production_Id=@id;";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                {
                    UpdateItemandBS(objProduction);
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

        private bool UpdateItemandBS(ProductionVoucherModel objproduction)
        {
            try
            {
                //UPDATE Item voucher -CHILD TABLE UPDATES
                foreach (Item_VoucherModel item in objproduction.Item_Voucher)
                {
                    if (item.Item_ID > 0)
                    {
                        UpdateProductionVoucherItems(item);

                    }
                    else
                    {
                        SaveProductionVoucherItems(item);
                    }
                }

                //Update Bill Sundry Items
                foreach (BillSundry_VoucherModel bs in objproduction.BillSundry_Voucher)
                {
                    if (bs.BSId > 0)
                    {
                        UpdateProductionBillSundryVoucher(bs);

                    }
                    else
                    {
                        SaveProductionBillSundryVoucher(bs);
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public bool UpdateProductionVoucherItems(Item_VoucherModel objProItem)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                
                paramCollection.Add(new DBParameter("@Pro_Item", objProItem.Item));
                paramCollection.Add(new DBParameter("@Pro_Batch", objProItem.Batch));
                paramCollection.Add(new DBParameter("@Pro_Qty", objProItem.Qty));
                paramCollection.Add(new DBParameter("@Pro_Unit", objProItem.Unit));
                paramCollection.Add(new DBParameter("@Pro_Price", objProItem.Price, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@Pro_Amount", objProItem.Amount, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalQty", objProItem.TotalQty, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalAmount", objProItem.TotalAmount, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));
                paramCollection.Add(new DBParameter("@TransPV_ID", objProItem.ParentId));
                paramCollection.Add(new DBParameter("@Pro_Id", objProItem.Item_ID));

                Query = "UPDATE Trans_Production_Items SET [Item]=@Pro_Item,[Batch]=@Pro_Batch,[Qty]=@Pro_Qty,[Unit]=@Pro_Unit," +
                "[Price]=@Pro_Price,[Amount]=@Pro_Amount,[TotalQty]=@TotalQty,[TotalAmount]=@TotalAmount,[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
                "WHERE Production_Id=@Transpv_ID AND [ItemId]=@ItemId";


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

        public bool SaveProductionVoucherItems(Item_VoucherModel lstItems)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@PV_ID", (lstItems.ParentId)));
                paramCollection.Add(new DBParameter("@Item", lstItems.Item));
                paramCollection.Add(new DBParameter("@Batch", lstItems.Batch));
                paramCollection.Add(new DBParameter("@Qty", lstItems.Qty));
                paramCollection.Add(new DBParameter("@Unit", (lstItems.Unit)));
                paramCollection.Add(new DBParameter("@Price", Convert.ToDecimal(lstItems.Price)));
                paramCollection.Add(new DBParameter("@Amount", Convert.ToDecimal(lstItems.Amount)));
                paramCollection.Add(new DBParameter("@TotalQty", lstItems.TotalQty));
                paramCollection.Add(new DBParameter("@TotalAmount", Convert.ToDecimal(lstItems.TotalAmount)));

                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));


                Query = "INSERT INTO Trans_Production_Items([Production_Id],[Item],[Batch],[Qty],[Unit]," +
                "[Price],[Amount],[TotalQty],[TotalAmount],[CreatedBy],[CreatedDate]) VALUES " +
                "(@PV_ID,@Item,@Batch,@Qty,@Unit,@Price,@Amount,@TotalQty,@TotalAmount,@CreatedBy,@CreatedDate)";

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

        public bool UpdateProductionBillSundryVoucher(BillSundry_VoucherModel objBSVoucher)
        {
            string Query = string.Empty;
            bool isUpdate = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();


                paramCollection.Add(new DBParameter("@ProductionBillSundry_Name", objBSVoucher.BillSundry));
                paramCollection.Add(new DBParameter("@ProductionBillSundry_Amount", objBSVoucher.Amount));
                paramCollection.Add(new DBParameter("@Percentage", objBSVoucher.Percentage));
                paramCollection.Add(new DBParameter("@TotalAmount", objBSVoucher.TotalAmount));
                paramCollection.Add(new DBParameter("@ModifiedBy", objBSVoucher.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));

                paramCollection.Add(new DBParameter("@ProductionBillSundry_ID", objBSVoucher.BSId));
                paramCollection.Add(new DBParameter("@ProductionVoucher_ID", objBSVoucher.ParentId));

                Query = "UPDATE Trans_PRODUCTION_BS SET [BillSundry]=@ProductionBillSundry_Name,[Amount]=@ProductionBillSundry_Amount," +
                "[Percentage]=@Percentage,[TotalAmount]=@TotalAmount,[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
                "WHERE [BSId]=@ProductionBillSundry_ID AND [Production_Id]=@ProductionVoucher_ID";

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

        public bool SaveProductionBillSundryVoucher(BillSundry_VoucherModel lstBS)
        {
            string Query = string.Empty;
            bool isSaved = true;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@PV_ID", lstBS.ParentId));
                    paramCollection.Add(new DBParameter("@Name", lstBS.BillSundry));
                    paramCollection.Add(new DBParameter("@Percentage", Convert.ToDecimal(lstBS.Percentage)));
                    paramCollection.Add(new DBParameter("@Amount", Convert.ToDecimal(lstBS.Amount)));
                    paramCollection.Add(new DBParameter("@TotalAmount", lstBS.TotalAmount));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now));

                    Query = "INSERT INTO Trans_Production_BS ([Production_id],[BillSundry],[Percentage]," +
                    "[Amount],[TotalAmount],[CreatedBy],[CreatedDate]) VALUES " +
                    "(@PV_ID,@Name,@Percentage,@Amount,@TotalAmount,@CreatedBy,@CreatedDate)";

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

        public List<TransListModel> GetAllProductionVoucher()
        {
            List<TransListModel> lstProduction = new List<TransListModel>();
            TransListModel objList;

            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT t.production_id, i.itemid, t.production_date, t.series, t.voucherno, t.party, i.item, i.qty, i.unit, i.price, i.amount, i.totalqty, i.totalamount FROM trans_Production_voucher AS t ");
            sbQuery.Append("INNER JOIN trans_production_items AS i ON t.production_id=i.production_id;");


            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(sbQuery.ToString(), _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objList = new TransListModel();

                objList.trans_sales_id = Convert.ToInt32(dr["production_id"]);

                objList.item_id = Convert.ToInt32(dr["itemid"]);
                objList.saledate = Convert.ToDateTime(dr["production_date"]);
                objList.series = Convert.ToString(dr["series"]);
                objList.voucherno = Convert.ToInt32(dr["VoucherNo"]);
                objList.party = Convert.ToString(dr["party"]);
                objList.item = Convert.ToString(dr["item"]);
                objList.qty = Convert.ToInt32(dr["qty"]);
                objList.unit = Convert.ToString(dr["unit"]);
                objList.price = Convert.ToInt32(dr["price"]);
                objList.amount = Convert.ToInt32(dr["amount"]);
                //objList.amount = Convert.ToInt32(dr["amount"]);
                objList.totalqty = Convert.ToInt32((dr["totalqty"]));
                objList.totalamount = Convert.ToInt32((dr["totalamount"]));
                lstProduction.Add(objList);

            }
            return lstProduction;
        }

        //Dellete Production Voucher

        public bool DeleteProductionVoucher(int id)
        {
            bool isDelete = false;
            try
            {
                if (DeleteProductionItems(id))
                {
                    if (DeleteProductionBS(id))
                    {
                        string Query = "DELETE * FROM trans_Production_Voucher WHERE Production_Id=" + id;
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

        public bool DeleteProductionItems(int id)
        {
            string Query = string.Empty;
            bool isDeleted = true;

            try
            {              
                    Query = "Delete from Trans_Production_Items WHERE [Production_Id]="+id;
                    int rows = _dbHelper.ExecuteNonQuery(Query);
                    if (rows > 0)
                        isDeleted = true;           

            }
            catch (Exception ex)
            {
                isDeleted = false;
                throw ex;
            }
            return isDeleted;
        }

        public bool DeleteProductionBS(int id)
        {
            string Query = string.Empty;
            bool isDeleted = true;

            try
            {
                    Query = "Delete from Trans_Production_BS WHERE [Production_Id]=" +id;

                int rows = _dbHelper.ExecuteNonQuery(Query);
                    if(rows>0)
                        isDeleted = true;                

                }          
            catch (Exception ex)
            {
                isDeleted = false;
                throw ex;
            }

            return isDeleted;
        }

        public ProductionVoucherModel GetAllProductionbyId(int id)
        {
            ProductionVoucherModel objProduction = new ProductionVoucherModel();

            string Query = "SELECT * FROM Trans_Production_Voucher WHERE Production_Id=" + id;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {

                objProduction.Production_Id = Convert.ToInt32(dr["Production_Id"]);
                objProduction.Series = dr["series"].ToString();

                objProduction.PV_Date = DataFormat.GetDateTime(dr["Production_Date"]);
                objProduction.Voucher_Number= DataFormat.GetInteger(dr["VoucherNo"]);
                objProduction.BillNo = Convert.ToInt32(dr["BillNo"].ToString());
                objProduction.DueDate = Convert.ToDateTime(dr["DueDate"]);
                objProduction.ProductionType = dr["Production_Type"].ToString();
                objProduction.Party = dr["party"].ToString();
                objProduction.MatCenter = dr["MatCenter"].ToString();
                objProduction.Narration = dr["Narration"].ToString();
                objProduction.TotalQty = Convert.ToDecimal(dr["TotalQty"]);
                objProduction.TotalAmount = Convert.ToDecimal(dr["TotalAmount"].ToString());
                objProduction.BSTotalAmount = Convert.ToDecimal(dr["BSTotalAmount"]);

                //SELECT Credit Note Accounts

                string itemQuery = "SELECT * FROM Trans_Production_Items WHERE Production_Id=" + id;
                System.Data.IDataReader drItems = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                objProduction.Item_Voucher = new List<Item_VoucherModel>();
                Item_VoucherModel objitem;

                while (drItems.Read())
                {
                    objitem = new Item_VoucherModel();

                    objitem.Item_ID = Convert.ToInt32(drItems["ItemId"]);
                    objitem.ParentId = DataFormat.GetInteger(drItems["Production_Id"]);
                    objitem.Item = drItems["item"].ToString();
                    objitem.Batch = drItems["Batch"].ToString();
                    objitem.Qty = Convert.ToInt32(drItems["qty"].ToString());
                    objitem.Unit = (drItems["unit"].ToString());
                    objitem.Price = Convert.ToDecimal(drItems["price"]);
                    objitem.Amount = Convert.ToInt32(drItems["amount"].ToString());
                    objitem.TotalAmount = Convert.ToDecimal(drItems["TotalAmount"]);
                    objitem.TotalQty = Convert.ToInt32(drItems["TotalQty"].ToString());

                    objProduction.Item_Voucher.Add(objitem);

                }

                string BSQuery = "SELECT * FROM Trans_Production_BS WHERE Production_Id=" + id;
                System.Data.IDataReader drbs = _dbHelper.ExecuteDataReader(BSQuery, _dbHelper.GetConnObject());

                objProduction.BillSundry_Voucher = new List<BillSundry_VoucherModel>();
                BillSundry_VoucherModel objbs;

                while (drbs.Read())
                {
                    objbs = new BillSundry_VoucherModel();

                    objbs.BSId = Convert.ToInt32(drbs["BSId"]);
                    objbs.ParentId = DataFormat.GetInteger(drbs["Production_Id"]);
                    objbs.BillSundry = drbs["BillSundry"].ToString();
                    objbs.Percentage = Convert.ToDecimal(drbs["Percentage"].ToString());
                    objbs.Amount = Convert.ToDecimal((drbs["Amount"].ToString()));
                    objbs.TotalAmount = Convert.ToDecimal(drbs["TotalAmount"].ToString());

                    objProduction.BillSundry_Voucher.Add(objbs);

                }

            }
            return objProduction;
        }
    }
}
