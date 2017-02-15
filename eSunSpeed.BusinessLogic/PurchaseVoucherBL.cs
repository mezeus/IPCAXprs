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
    public class PurchaseVoucherBL
    {
        private DBHelper _dbHelper = new DBHelper();

        //This BL is Used For Purchase Voucher Screen
        #region SAVE PURCHASE VOUCHER
        public bool SavePurcahseVoucher(PurchaseVoucherModel objPurc)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@VoucherType", objPurc.VoucherType));
                paramCollection.Add(new DBParameter("@PurcDate", objPurc.PurcDate, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@Terms", objPurc.Terms));
                paramCollection.Add(new DBParameter("@VoucherNumber", objPurc.VoucherNumber));
                paramCollection.Add(new DBParameter("@BillNumber", objPurc.BillNo));
                paramCollection.Add(new DBParameter("@LedgerId", objPurc.LedgerId));
                paramCollection.Add(new DBParameter("@PurcType", objPurc.PurcType));
                paramCollection.Add(new DBParameter("@MatCentre", objPurc.MatCentre));
                paramCollection.Add(new DBParameter("@Narration", objPurc.Narration));
                paramCollection.Add(new DBParameter("@TotalAmount", objPurc.TotalAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalQty", objPurc.TotalQty, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalFree", objPurc.TotalFree, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalBasicAmount", objPurc.TotalBasicAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalDisAmount", objPurc.TotalDisAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalTaxAmount", objPurc.TotalTaxAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@BSTotalAmount", objPurc.BSTotalAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, DbType.DateTime));
                paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, DbType.DateTime));

                System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertPurchaseVoucherMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                int id = 0;
                dr.Read();
                id = Convert.ToInt32(dr[0]);
                SavePurchaseVoucherItems(objPurc.Item_Voucher, id);
                SavePurchaseBillSundryVoucher(objPurc.BillSundry_Voucher, id);
            }
            catch (Exception ex)
            {
                isSaved = false;
                //throw ex;
            }

            return isSaved;
        }

        //Save Purchase Item details
        public bool SavePurchaseVoucherItems(List<Item_VoucherModel> lstSales, int ParentId)
        {
            string Query = string.Empty;
            bool isSaved = true;
            foreach (Item_VoucherModel item in lstSales)
            {
                item.ParentId = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@ParentId", item.ParentId));
                    paramCollection.Add(new DBParameter("@ITM_Id", item.ITM_Id));
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
                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertPurchaseVoucherItemDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    //throw ex;
                }
            }
            return isSaved;
        }
        //Save Purchase BS Details
        public bool SavePurchaseBillSundryVoucher(List<BillSundry_VoucherModel> lstBS, int ParentId)
        {
            string Query = string.Empty;
            bool isSaved = true;
            foreach (BillSundry_VoucherModel bs in lstBS)
            {
                bs.ParentId = ParentId;
                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@ParentId", bs.ParentId));
                    paramCollection.Add(new DBParameter("@BS_Id", bs.BS_Id));
                    paramCollection.Add(new DBParameter("@Percentage", bs.Percentage));
                    paramCollection.Add(new DBParameter("@Extra", bs.Extra));
                    paramCollection.Add(new DBParameter("@Amount", bs.Amount));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                    paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, DbType.DateTime));
                    paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                    paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, DbType.DateTime));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertPurchaseVoucherBS", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    //throw ex;
                }
            }
            return isSaved;
        }
        #endregion
        //Get List Of Purchase Vouchers Details In List
        public List<TransListModel> GetAllPurchaseVoucherMaster()
        {
            List<TransListModel> lstModel = new List<TransListModel>();
            TransListModel objList;

            StringBuilder sbQuery = new StringBuilder();

            sbQuery.AppendLine("SELECT m.PurcVoucher_Id, i.Id,m.PurcDate,m.VoucherNumber, i.ITM_ID, i.Qty, i.Unit,im.ITEM_Name,am.ACC_NAME FROM purchasevoucher_master AS m");
            sbQuery.AppendLine("INNER JOIN purchasevoucher_itemdetails AS i ON m.PurcVoucher_Id=i.PurcVoucher_Id");
            sbQuery.AppendLine("left join itemmaster as im ON i.itm_id=im.ITM_ID");
            sbQuery.AppendLine("left join accountmaster am ON am.Ac_ID = m.LedgerId;");

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(sbQuery.ToString(), _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objList = new TransListModel();

                objList.PurcVchId = Convert.ToInt64(dr["PurcVoucher_Id"]);
                //objList.item_id = Convert.ToInt32(dr["ItemId"]);
                objList.Purcdate = Convert.ToDateTime(dr["PurcDate"]);
                objList.voucherno = Convert.ToInt32(dr["VoucherNumber"]);
                objList.party = Convert.ToString(dr["ACC_NAME"]);
                objList.item = Convert.ToString(dr["ITEM_Name"]);
                objList.qty = Convert.ToInt32(dr["Qty"]);
                objList.unit = Convert.ToString(dr["Unit"]);
                lstModel.Add(objList);
            }
            return lstModel;
        }
        //Delete Purchase Voucher Item details
        public bool DeletePurchaseItems(long id)
        { 
            bool isDelete = true;
            try
            {
                string Query = "DELETE FROM purchasevoucher_itemdetails WHERE PurcVoucher_Id=" + id;
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
        //Delete Purchase Voucher BS Details
        public bool DeletePurchaseBS(long id)
        {
            bool isDelete = true;
            try
            {
                string Query = "DELETE FROM purchasevoucher_bsdetails WHERE PurcVoucher_Id=" + id;
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
        //Update Purchase Voucher
        public bool UpdatePurchaseVoucher(eSunSpeedDomain.PurchaseVoucherModel objPurc)
        {
            string Query = string.Empty;
            bool isUpdate = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Trans_Purc_Id", objPurc.Trans_Purc_Id));
                paramCollection.Add(new DBParameter("@VoucherType", objPurc.VoucherType));
                paramCollection.Add(new DBParameter("@PurcDate", objPurc.PurcDate, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@Terms", objPurc.Terms));
                paramCollection.Add(new DBParameter("@VoucherNumber", objPurc.VoucherNumber));
                paramCollection.Add(new DBParameter("@BillNumber", objPurc.BillNo));
                paramCollection.Add(new DBParameter("@LedgerId", objPurc.LedgerId));
                paramCollection.Add(new DBParameter("@PurcType", objPurc.PurcType));
                paramCollection.Add(new DBParameter("@MatCentre", objPurc.MatCentre));
                paramCollection.Add(new DBParameter("@Narration", objPurc.Narration));
                paramCollection.Add(new DBParameter("@TotalAmount", objPurc.TotalAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalQty", objPurc.TotalQty, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalFree", objPurc.TotalFree, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalBasicAmount", objPurc.TotalBasicAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalDisAmount", objPurc.TotalDisAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalTaxAmount", objPurc.TotalTaxAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@BSTotalAmount", objPurc.BSTotalAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, DbType.DateTime));
                paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, DbType.DateTime));

                System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spUpdatePurchaseVoucherMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);

                foreach (Item_VoucherModel item in objPurc.Item_Voucher)
                {
                    item.ParentId = objPurc.Trans_Purc_Id;
                    if (item.Item_ID > 0)
                    {
                        paramCollection = new DBParameterCollection();

                        paramCollection.Add(new DBParameter("@ParentId", item.ParentId));
                        paramCollection.Add(new DBParameter("@IId", item.Item_ID));
                        paramCollection.Add(new DBParameter("@ITM_Id", item.ITM_Id));
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
                        System.Data.IDataReader drpv =
                        _dbHelper.ExecuteDataReader("spUpdatePurchaseVoucherItemDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    }
                    else
                    {
                        paramCollection = new DBParameterCollection();

                        paramCollection.Add(new DBParameter("@ParentId", item.ParentId));
                        paramCollection.Add(new DBParameter("@ITM_Id", item.ITM_Id));
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
                        System.Data.IDataReader drpv =
                        _dbHelper.ExecuteDataReader("spInsertPurchaseVoucherItemDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    }
                }
                foreach (BillSundry_VoucherModel bs in objPurc.BillSundry_Voucher)
                {
                    bs.ParentId = objPurc.Trans_Purc_Id;
                    if(bs.BSId>0)
                    {
                        paramCollection = new DBParameterCollection();

                        paramCollection.Add(new DBParameter("@ParentId", bs.ParentId));
                        paramCollection.Add(new DBParameter("@BSId", bs.BSId));
                        paramCollection.Add(new DBParameter("@BS_Id", bs.BS_Id));
                        paramCollection.Add(new DBParameter("@Percentage", bs.Percentage));
                        paramCollection.Add(new DBParameter("@Extra", bs.Extra));
                        paramCollection.Add(new DBParameter("@Amount", bs.Amount));
                        paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                        paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, DbType.DateTime));
                        paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                        paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, DbType.DateTime));

                        System.Data.IDataReader drbs =
                        _dbHelper.ExecuteDataReader("spUpdatePurchaseVoucherBS", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    }
                   else
                    {
                        paramCollection = new DBParameterCollection();

                        paramCollection.Add(new DBParameter("@ParentId", bs.ParentId));
                        paramCollection.Add(new DBParameter("@BS_Id", bs.BS_Id));
                        paramCollection.Add(new DBParameter("@Percentage", bs.Percentage));
                        paramCollection.Add(new DBParameter("@Extra", bs.Extra));
                        paramCollection.Add(new DBParameter("@Amount", bs.Amount));
                        paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                        paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, DbType.DateTime));
                        paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                        paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, DbType.DateTime));

                        System.Data.IDataReader drbs =
                        _dbHelper.ExecuteDataReader("spInsertPurchaseVoucherBS", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    }         
                }
            }
            catch (Exception ex)
            {
                isUpdate = false;
                //throw ex;
            }

            return isUpdate;
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
        //Delete Purchase Voucher
        public bool DeletePurchaseVoucher(long id)
        {
            bool isDelete = false;
            try
            {
                if (DeletePurchaseItems(id))
                {
                    if (DeletePurchaseBS(id))
                    {
                        string Query = "DELETE FROM purchasevoucher_master WHERE PurcVoucher_Id=" + id;
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

        //Get All Purchase Vouchers Details By ID
        public PurchaseVoucherModel GetAllPurchaseVchDetailsbyId(long id)
        {
            PurchaseVoucherModel objPurcVch = new PurchaseVoucherModel();
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.AppendLine("SELECT m.*,am.ACC_NAME FROM `purchasevoucher_master` AS m");
            sbQuery.AppendLine("INNER JOIN accountmaster AS am ON m.LedgerId= am.Ac_ID");
            sbQuery.AppendLine("WHERE m.`PurcVoucher_Id`='"+id+"'");
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(sbQuery.ToString(), _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objPurcVch.Trans_Purc_Id = Convert.ToInt64(dr["PurcVoucher_Id"]);
                objPurcVch.VoucherType = dr["VoucherType"].ToString();
                objPurcVch.PurcDate = DataFormat.GetDateTime(dr["PurcDate"]);
                objPurcVch.Terms = dr["Terms"].ToString();
                objPurcVch.VoucherNumber = Convert.ToInt64(dr["VoucherNumber"]);
                objPurcVch.BillNo = Convert.ToInt64(dr["BillNumber"].ToString());
                objPurcVch.PurcType = dr["PurcType"].ToString();
                objPurcVch.Party = dr["ACC_NAME"].ToString();
                objPurcVch.MatCentre = dr["MatCentre"].ToString();
                objPurcVch.Narration = dr["Narration"].ToString();
                objPurcVch.TotalQty = Convert.ToDecimal(dr["TotalQty"]);
                objPurcVch.TotalFree = Convert.ToDecimal(dr["TotalFree"]);
                objPurcVch.TotalBasicAmount = Convert.ToDecimal(dr["TotalBasicAmount"]);
                objPurcVch.TotalDisAmount = Convert.ToDecimal(dr["TotalDisAmount"]);
                objPurcVch.TotalTaxAmount = Convert.ToDecimal(dr["TotalTaxAmount"]);
                objPurcVch.TotalAmount = Convert.ToDecimal(dr["TotalAmount"].ToString());
                objPurcVch.BSTotalAmount = Convert.ToDecimal(dr["BSTotalAmount"]);

                //SELECT Item Details
                StringBuilder sbitemQuery = new StringBuilder();
                sbitemQuery.AppendLine("SELECT i.*,im.ITEM_Name,ia.ACC_NAME FROM purchasevoucher_itemdetails as i");
                sbitemQuery.AppendLine("left join itemmaster as im on i.ITM_ID=im.ITM_ID");
                sbitemQuery.AppendLine("left join accountmaster as ia on i.LedgerId=ia.AC_ID");
                sbitemQuery.AppendLine("WHERE PurcVoucher_Id='" + id + "'");
                System.Data.IDataReader drItems = _dbHelper.ExecuteDataReader(sbitemQuery.ToString(), _dbHelper.GetConnObject());

                objPurcVch.Item_Voucher = new List<Item_VoucherModel>();
                Item_VoucherModel objitem;

                while (drItems.Read())
                {
                    objitem = new Item_VoucherModel();

                    objitem.Item_ID = Convert.ToInt64(drItems["Id"]);
                    objitem.ITM_Id = Convert.ToInt64(drItems["ITM_ID"]);
                    objitem.ParentId = DataFormat.GetInteger(drItems["PurcVoucher_Id"]);
                    objitem.Item = drItems["ITEM_Name"].ToString();
                    objitem.Particulars = drItems["ACC_NAME"].ToString();
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

                    objPurcVch.Item_Voucher.Add(objitem);
                }
                //Select BS Details
                StringBuilder sbBSQuery = new StringBuilder();
                sbBSQuery.AppendLine("SELECT pbs.*,mbs.Name FROM purchasevoucher_bsdetails  as pbs");
                sbBSQuery.AppendLine("inner join  billsundarymaster as mbs on pbs.BS_Id=mbs.BS_Id");
                sbBSQuery.AppendLine("WHERE PurcVoucher_Id='"+id+"'");
                System.Data.IDataReader drbs = _dbHelper.ExecuteDataReader(sbBSQuery.ToString(), _dbHelper.GetConnObject());

                objPurcVch.BillSundry_Voucher = new List<BillSundry_VoucherModel>();
                BillSundry_VoucherModel objbs;

                while (drbs.Read())
                {
                    objbs = new BillSundry_VoucherModel();

                    objbs.BSId = Convert.ToInt32(drbs["Id"]);
                    objbs.ParentId = DataFormat.GetInteger(drbs["PurcVoucher_Id"]);
                    objbs.BillSundry = drbs["Name"].ToString();
                    objbs.Percentage = Convert.ToDecimal(drbs["Percentage"].ToString());
                    objbs.Extra = drbs["Extra"].ToString();
                    objbs.Amount = Convert.ToDecimal((drbs["Amount"].ToString()));

                    objPurcVch.BillSundry_Voucher.Add(objbs);
                }

            }
            return objPurcVch;
        }
    }
}
