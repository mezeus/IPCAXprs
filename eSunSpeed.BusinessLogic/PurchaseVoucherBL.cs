using eSunSpeed.DataAccess;
using eSunSpeed.Formatting;
using eSunSpeedDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeed.BusinessLogic
{
    public class PurchaseVoucherBL
    {
        private DBHelper _dbHelper = new DBHelper();

        #region SAVE PURCHASE VOUCHER
        public bool SavePurchaseVoucher(PurchaseVoucherMainModel objPurc)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@VoucherNumber", objPurc.PurchaseVoucher_Number));
                paramCollection.Add(new DBParameter("@Series", objPurc.PurchaseVoucher_Series));
                paramCollection.Add(new DBParameter("@PurcDate", objPurc.PurchaseVoucher_Date, System.Data.DbType.DateTime));

                paramCollection.Add(new DBParameter("@PurcType", objPurc.PurchaseVoucher_PurchaseType));
                paramCollection.Add(new DBParameter("@Party", objPurc.PurchaseVoucher_Party));
                paramCollection.Add(new DBParameter("@MatCentre", objPurc.PurchaseVoucher_MatCenter));

                paramCollection.Add(new DBParameter("@Narration", objPurc.Narration));
                paramCollection.Add(new DBParameter("@ItemTotalAmount", objPurc.TotalAmount));
                paramCollection.Add(new DBParameter("@ItemTotalQty", objPurc.TotalQty));

                paramCollection.Add(new DBParameter("@BSTotalAmount", objPurc.BSTotalAmount));

                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertPurchaseVoucher", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);

                int id = 0;
                dr.Read();
                id = Convert.ToInt32(dr[0]);

                SavePurchaseVoucherItems(objPurc.PurchaseItem_Voucher, id);
                SavePurchaseBillSundryVoucher(objPurc.BillSundry_Voucher, id);
                //Query = "INSERT INTO PurchaseMain_Voucher([PurchaseVoucher_Series],[PurchaseVoucher_Date],[PurchaseVoucher_Number],[PurchaseVoucher_PurchaseType],[PurchaseVoucher_Party]," +
                //"[PurchaseVoucher_MatCenter],[CreatedBy]) VALUES " +
                //"(@PurchaseVoucher_Series,@PurchaseVoucher_Date,@PurchaseVoucher_Number,@PurchaseVoucher_PurchaseType,@PurchaseVoucher_Party,@PurchaseVoucher_MatCenter,@CreatedBy)";

                //if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                //    isSaved = true;
            }
            catch (Exception ex)
            {
                isSaved = false;
                throw ex;
            }

            return isSaved;
        }

        public bool SavePurchaseVoucherItems(List<Item_VoucherModel> lstItems, int ParentId)
        {
            string Query = string.Empty;
            bool isSaved = true;

            //objItem.ParentId = GetPurchaseVoucherId();
            foreach (Item_VoucherModel item in lstItems)
            {
                item.ParentId = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@TransPVId", item.ParentId));
                    paramCollection.Add(new DBParameter("@Item", item.Item));
                    paramCollection.Add(new DBParameter("@Batch", item.Batch));
                    paramCollection.Add(new DBParameter("@Qty", item.Qty));
                    paramCollection.Add(new DBParameter("@Unit", item.Qty));
                    paramCollection.Add(new DBParameter("@Price", item.Price));
                    paramCollection.Add(new DBParameter("@Amount", item.Amount));

                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    System.Data.IDataReader dr =
                      _dbHelper.ExecuteDataReader("spInsertPurcItem", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    //Query = "INSERT INTO PurchaseItem_Voucher([PurchaseVoucher_ID],[Purchase_Item],[Purchase_Qty],[Purchase_Unit]," +
                    //"[Purchase_Price],[Purchase_Amount],[CreatedBy]) VALUES " +
                    //"(@PurchaseVoucher_ID,@Purchase_Item,@Purchase_Qty,@Purchase_Unit,@Purchase_Price,@Purchase_Amount,@CreatedBy)";

                    //if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                    //    isSaved = true;
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }

        public bool SavePurchaseBillSundryVoucher(List<BillSundry_VoucherModel> lstpurcBS, int ParentId)
        {
            string Query = string.Empty;
            bool isSaved = true;

            //objBSVoucher.ParentId = GetPurchaseVoucherId();
            foreach (BillSundry_VoucherModel bs in lstpurcBS)
            {
                bs.ParentId = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@TransPVId", bs.ParentId));
                    paramCollection.Add(new DBParameter("@BillSundry", bs.BillSundry));
                    paramCollection.Add(new DBParameter("@Percentage", bs.Percentage));
                    paramCollection.Add(new DBParameter("@Amount", bs.Amount));
                    paramCollection.Add(new DBParameter("@TotalAmount", bs.TotalAmount));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertPVBillSundry", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);

                    //if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                    //    isSaved = true;
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }

        public int GetPurchaseVoucherId()
        {
            string Query = "SELECT MAX(TransPVId) FROM Trans_Purchase_Voucher";

            int id = Convert.ToInt32(_dbHelper.ExecuteScalar(Query));

            return id;
        }


        #endregion

       

       public bool DeletePurchaseItems(int id)
        { 
            bool isDelete = false;
            try
            {
                string Query = "DELETE * FROM Trans_PV_Items WHERE transpvid=" + id;
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

        public bool DeletePurchaseBS(int id)
        {
            bool isDelete = false;
            try
            {
                string Query = "DELETE * FROM Trans_PV_Bs WHERE transpvid=" + id;
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

        public List<TransListModel> GetAllPurchaseVoucher()
        { 
            List<TransListModel> lstModel = new List<TransListModel>();
            TransListModel objList;

            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append("SELECT t.transpvid, i.itemid, t.pv_date, t.series, t.voucherno, t.party, i.item, i.qty, i.unit, i.price, i.amount, i.totalqty, i.totalamount FROM trans_Purchase_voucher AS t ");
            sbQuery.Append("INNER JOIN trans_pv_items AS i ON t.TranspvId=i.TranspvId;");


            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(sbQuery.ToString(), _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objList = new TransListModel();

                objList.trans_sales_id = Convert.ToInt32(dr["TranspvId"]);

                objList.item_id = Convert.ToInt32(dr["itemid"]);
                objList.saledate = Convert.ToDateTime(dr["pv_date"]);
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

        public PurchaseVoucherModel GetAllPurcahseVoucherbyId(int id)
        {
            PurchaseVoucherModel objpurchase = new PurchaseVoucherModel();

            string Query = "SELECT * FROM Trans_purchase_voucher WHERE transpvId=" + id;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {

                //objpurchase.PV_Id = DataFormat.GetInteger(dr["TransPVId"]);
                //objpurchase.Series = dr["series"].ToString();
                
                //objpurchase.PV_Date = DataFormat.GetDateTime(dr["pv_Date"]);
                //objpurchase.Voucher_Number = DataFormat.GetInteger(dr["Voucherno"]);
                //objpurchase.BillNo = DataFormat.GetInteger(dr["BillNo"]);
                //objpurchase.PurchaseType = dr["pv_Type"].ToString();
                //objpurchase.Party = dr["party"].ToString();
                //objpurchase.MatCenter = dr["MatCenter"].ToString();
                objpurchase.Narration = dr["Narration"].ToString();
                //objpurchase.t = Convert.ToDecimal(dr["TotalQty"]);
                //objpurchase.TotalAmount = Convert.ToDecimal(dr["TotalAmount"].ToString());
                //objpurchase.BSTotalAmount = Convert.ToDecimal(dr["BSTotalAmount"]);

                //SELECT Purchase Items

                string itemQuery = "SELECT * FROM Trans_pv_items WHERE TranspvId=" + id;
                System.Data.IDataReader drItems = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                objpurchase.Item_Voucher = new List<Item_VoucherModel>();
                Item_VoucherModel objitem;

                while (drItems.Read())
                {
                    objitem = new Item_VoucherModel();

                    objitem.Item_ID = Convert.ToInt32(drItems["ItemId"]);
                    objitem.ParentId = DataFormat.GetInteger(drItems["TranspvId"]);
                    objitem.Item = drItems["item"].ToString();
                    objitem.Batch = drItems["Batch"].ToString();
                    objitem.Qty = Convert.ToInt32(drItems["qty"].ToString());
                    objitem.Unit = (drItems["unit"].ToString());
                    objitem.Price = Convert.ToDecimal(drItems["price"]);
                    objitem.Amount = Convert.ToInt32(drItems["amount"].ToString());
                    objitem.TotalQty = Convert.ToInt32(drItems["TotalQty"].ToString());
                    objitem.TotalAmount = Convert.ToDecimal(drItems["TotalAmount"]);
                    

                    objpurchase.Item_Voucher.Add(objitem);

                }

                string BSQuery = "SELECT * FROM Trans_pv_BS WHERE TranspvId=" + id;
                System.Data.IDataReader drbs = _dbHelper.ExecuteDataReader(BSQuery, _dbHelper.GetConnObject());

                objpurchase.BillSundry_Voucher = new List<BillSundry_VoucherModel>();
                BillSundry_VoucherModel objbs;

                while (drbs.Read())
                {
                    objbs = new BillSundry_VoucherModel();

                    objbs.BSId = Convert.ToInt32(drbs["BSId"]);
                    objbs.ParentId = DataFormat.GetInteger(drbs["TranspvId"]);
                    objbs.BillSundry = drbs["BillSundry"].ToString();
                    objbs.Percentage = Convert.ToDecimal(drbs["Percentage"].ToString());
                    objbs.Amount = Convert.ToDecimal((drbs["Amount"].ToString()));
                    objbs.TotalAmount = Convert.ToDecimal(drbs["TotalAmount"].ToString());

                    objpurchase.BillSundry_Voucher.Add(objbs);

                }

            }
            return objpurchase;
        }

        public bool UpdatePurchaseVoucher(eSunSpeedDomain.PurchaseVoucherModel objpv)
        {
            string Query = string.Empty;
            bool isUpdated = false;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Series", objpv.Series));
                //paramCollection.Add(new DBParameter("@PurchaseType", objpv.PurchaseType));
                //paramCollection.Add(new DBParameter("@PurchaseDate", objpv.PV_Date));
                //paramCollection.Add(new DBParameter("@VoucherNumber", objpv.Voucher_Number));
                //paramCollection.Add(new DBParameter("@BillNumber", objpv.BillNo));

                //paramCollection.Add(new DBParameter("@Party", objpv.Party));
                //paramCollection.Add(new DBParameter("@MatCentre", objpv.MatCenter));

                paramCollection.Add(new DBParameter("@Narration", objpv.Narration));
                paramCollection.Add(new DBParameter("@TotalQty", objpv.TotalQty, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalAmount", objpv.TotalAmount, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@BSTotalAmount", objpv.BSTotalAmount, System.Data.DbType.Decimal));

                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                //paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));
                //paramCollection.Add(new DBParameter("@PurchaseVoucher_ID", objpv.PV_Id));

                Query = "UPDATE Trans_Purchase_Voucher SET [Series]=@Series,[PV_Type]=@PurchaseType,[PV_Date]=@PurchaseDate," +
                         "[VoucherNo]=@VoucherNumber,[BillNo]=@BillNumber," +
                        "[Party]=@Party,[MatCenter]=@MatCentre," +
                        "[Narration]=@Narration,[TotalQty]=@TotalQty," +
                        "[TotalAmount]=@TotalAmount,[BSTotalAmount]=@BSTotalAmount," +
                        "[ModifiedBy]=@ModifiedBy " +
                        "WHERE TransPVId=@PurchaseVoucher_ID;";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                {
                    UpdatePurchaseItemandBS(objpv);
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

        private bool UpdatePurchaseItemandBS(PurchaseVoucherModel objpurchase)
        {
            try
            {
                //UPDATE Item voucher -CHILD TABLE UPDATES
                foreach (Item_VoucherModel item in objpurchase.Item_Voucher)
                {
                    if (item.Item_ID > 0)
                    {
                        UpdatePurchaseVoucherItems(item);

                    }
                    else
                    {
                        SavePurchaseItems(item);
                    }
                }

                //Update Bill Sundry Items
                foreach (BillSundry_VoucherModel bs in objpurchase.BillSundry_Voucher)
                {
                    if (bs.BSId > 0)
                    {
                        UpdatePurchaseBillSundryVoucher(bs);

                    }
                    else
                    {
                        SavePurchaseBillSundryVoucher(bs);
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public bool UpdatePurchaseVoucherItems(Item_VoucherModel objPVItem)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();


                paramCollection.Add(new DBParameter("@Purchase_Item", objPVItem.Item));
                paramCollection.Add(new DBParameter("@Purchase_batch", objPVItem.Batch));
                paramCollection.Add(new DBParameter("@Purchase_Qty", objPVItem.Qty, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@Purchase_Unit", objPVItem.Unit));
                paramCollection.Add(new DBParameter("@Purchase_Price", objPVItem.Price, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@Purchase_Amount", objPVItem.Amount, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalQty", objPVItem.TotalQty, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalAmount", objPVItem.TotalAmount, System.Data.DbType.Decimal));

                paramCollection.Add(new DBParameter("@ModifiedBy", objPVItem.ModifiedBy));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));

                paramCollection.Add(new DBParameter("@PurchaseId", objPVItem.ParentId));
                paramCollection.Add(new DBParameter("@ItemId", objPVItem.Item_ID));

                Query = "UPDATE Trans_PV_Items SET [Item]=@Purchase_Item,[Batch]=@Purchase_batch,[Qty]=@Purchase_Qty,[Unit]=@Purchase_Unit," +
                "[Price]=@Purchase_Price,[Amount]=@Purchase_Amount,[TotalQty]=@TotalQty,[TotalAmount]=@TotalAmount,[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
                "WHERE transPVId=@PurchaseId AND [ItemId]=@ItemId";


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

        public bool SavePurchaseItems(Item_VoucherModel lstitems)
        {
            string Query = string.Empty;
            bool isSaved = true;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Voucher_ID", Convert.ToInt32(lstitems.ParentId)));
                    paramCollection.Add(new DBParameter("@Item", lstitems.Item));
                    paramCollection.Add(new DBParameter("@Batch", lstitems.Batch));
                    paramCollection.Add(new DBParameter("@Qty", Convert.ToInt32(lstitems.Qty)));
                    paramCollection.Add(new DBParameter("@Unit", lstitems.Unit));
                    paramCollection.Add(new DBParameter("@Price", Convert.ToInt32(lstitems.Price)));
                    paramCollection.Add(new DBParameter("@Amount", Convert.ToInt32(lstitems.Amount)));
                    paramCollection.Add(new DBParameter("@TotalQty", Convert.ToInt32(lstitems.TotalQty)));
                    paramCollection.Add(new DBParameter("@TotalAmount", Convert.ToInt32(lstitems.TotalAmount)));

                    paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));


                    Query = "INSERT INTO Trans_PV_Items([TransPVId],[Item],[Batch],[Qty],[Unit]," +
                    "[Price],[Amount],[TotalQty],[TotalAmount],[ModifiedBy]) VALUES " +
                    "(@Voucher_ID,@Item,@Batch,@Qty,@Unit,@Price,@Amount,@TotalQty,@TotalAmount,@ModifiedBy)";

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

        public bool UpdatePurchaseBillSundryVoucher(BillSundry_VoucherModel objBSVoucher)
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

                Query = "UPDATE Trans_pv_BS SET [BillSundry]=@PurchaseBillSundry_Name,[Amount]=@PurchaseBillSundry_Amount," +
                "[Percentage]=@Percentage,[TotalAmount]=@TotalAmount,[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
                "WHERE [BSId]=@PurchaseBillSundry_ID AND [TranspvId]=@PurchaseVoucher_ID";

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

        public bool SavePurchaseBillSundryVoucher(BillSundry_VoucherModel lstBS)
        {
            string Query = string.Empty;
            bool isSaved = true;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Voucher_ID", lstBS.ParentId));
                    paramCollection.Add(new DBParameter("@BillSundry_Name", lstBS.BillSundry));
                    paramCollection.Add(new DBParameter("@Percentage", Convert.ToDecimal(lstBS.Percentage)));
                    paramCollection.Add(new DBParameter("@BillSundry_Amount", Convert.ToDecimal(lstBS.Amount)));
                    paramCollection.Add(new DBParameter("@TotalAmount", lstBS.TotalAmount));
                    paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));

                    Query = "INSERT INTO Trans_PV_BS([TransPVId],[BillSundry],[Percentage]," +
                    "[Amount],[TotalAmount],[ModifiedBy]) VALUES " +
                    "(@Voucher_ID,@BillSundry_Name,@Percentage,@BillSundry_Amount,@TotalAmount,@ModifiedBy)";

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

        public bool DeletePurchaseVoucher(int id)
        {
            bool isDelete = false;
            try
            {
                if (DeletePurchaseItems(id))
                {
                    if (DeletePurchaseBS(id))
                    {
                        string Query = "DELETE * FROM trans_Purchase_Voucher WHERE transpvid=" + id;
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
    }
}
