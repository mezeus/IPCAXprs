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
    public class PurchaseReturnVoucherBL
    {
        private DBHelper _dbHelper = new DBHelper();
        //This BL Is Used in Purchase Voucher Return
        #region SAVE PURCHASE Return  VOUCHER
        public bool SavePurcahseReturnVoucher(PurchaseReturnVoucherModel objPurcRet)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@VoucherType", objPurcRet.VoucherType));
                paramCollection.Add(new DBParameter("@PurcRetDate", objPurcRet.PR_Date, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@Terms", objPurcRet.Terms));
                paramCollection.Add(new DBParameter("@VoucherNumber", objPurcRet.VoucherNumber));
                paramCollection.Add(new DBParameter("@BillNumber", objPurcRet.BillNo));
                paramCollection.Add(new DBParameter("@LedgerId", objPurcRet.LedgerId));
                paramCollection.Add(new DBParameter("@PurcType", objPurcRet.PurchaseType));
                paramCollection.Add(new DBParameter("@MatCentre", objPurcRet.MatCenter));
                paramCollection.Add(new DBParameter("@Narration", objPurcRet.Narration));
                paramCollection.Add(new DBParameter("@TotalAmount", objPurcRet.TotalAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalQty", objPurcRet.TotalQty, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalFree", objPurcRet.TotalFree, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalBasicAmount", objPurcRet.TotalBasicAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalDisAmount", objPurcRet.TotalDisAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalTaxAmount", objPurcRet.TotalTaxAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@BSTotalAmount", objPurcRet.BSTotalAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, DbType.DateTime));
                paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, DbType.DateTime));

                System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertPurchaseReturnMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                int id = 0;
                dr.Read();
                id = Convert.ToInt32(dr[0]);
                SavePurchaseReturnItems(objPurcRet.Item_Voucher, id);
                SavePurchaseReturnBillSundry(objPurcRet.BillSundry_Voucher, id);
            }
            catch (Exception ex)
            {
                isSaved = false;
                //throw ex;
            }

            return isSaved;
        }
        //Save Purchase Return Item details
        public bool SavePurchaseReturnItems(List<Item_VoucherModel> lstPurcRet, int ParentId)
        {
            string Query = string.Empty;
            bool isSaved = true;
            foreach (Item_VoucherModel item in lstPurcRet)
            {
                item.ParentId = ParentId;
                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@ParentId", item.ParentId));
                    paramCollection.Add(new DBParameter("@ITM_Id", item.ITM_Id));
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
                    _dbHelper.ExecuteDataReader("spInsertPurchaseReturnItemDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    //throw ex;
                }
            }
            return isSaved;
        }
        //Save Purchase Return BS Details
        public bool SavePurchaseReturnBillSundry(List<BillSundry_VoucherModel> lstBS, int ParentId)
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
                    _dbHelper.ExecuteDataReader("spInsertPurchaseReturnBS", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
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
        //Get List Of Purchase Return Details In List
        public List<TransListModel> GetAllPurchaseReturnDetails()
        {
            List<TransListModel> lstModel = new List<TransListModel>();
            TransListModel objList;

            StringBuilder sbQuery = new StringBuilder();

            sbQuery.AppendLine("SELECT m.PurcReturn_Id, i.Id,m.PurcReturnDate,m.VoucherNumber, i.ITM_ID, i.Qty, i.Unit,im.ITEM_Name,am.ACC_NAME FROM purchasereturn_master AS m");
            sbQuery.AppendLine("INNER JOIN purchasereturn_itemdetails AS i ON m.PurcReturn_Id=i.PurcReturn_Id");
            sbQuery.AppendLine("inner join itemmaster as im ON i.itm_id=im.ITM_ID");
            sbQuery.AppendLine("inner join accountmaster am ON am.Ac_ID = m.LedgerId;");

            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(sbQuery.ToString(), _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objList = new TransListModel();

                objList.PurcRetId = Convert.ToInt64(dr["PurcReturn_Id"]);
                //objList.item_id = Convert.ToInt32(dr["ItemId"]);
                objList.Purcdate = Convert.ToDateTime(dr["PurcReturnDate"]);
                objList.voucherno = Convert.ToInt32(dr["VoucherNumber"]);
                objList.party = Convert.ToString(dr["ACC_NAME"]);
                objList.item = Convert.ToString(dr["ITEM_Name"]);
                objList.qty = Convert.ToInt32(dr["Qty"]);
                objList.unit = Convert.ToString(dr["Unit"]);
                lstModel.Add(objList);
            }
            return lstModel;
        }
        //Get All Purchase Return Details By ID
        public PurchaseReturnVoucherModel GetAllPurchaseVchDetailsbyId(long id)
        {
            PurchaseReturnVoucherModel objPurcRet = new PurchaseReturnVoucherModel();
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.AppendLine("SELECT m.*,am.ACC_NAME FROM `purchasereturn_master` AS m");
            sbQuery.AppendLine("INNER JOIN accountmaster AS am ON m.LedgerId= am.Ac_ID");
            sbQuery.AppendLine("WHERE m.`PurcReturn_Id`='" + id + "'");
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(sbQuery.ToString(), _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objPurcRet.PR_Id = Convert.ToInt64(dr["PurcReturn_Id"]);
                objPurcRet.VoucherType = dr["VoucherType"].ToString();
                objPurcRet.PR_Date = DataFormat.GetDateTime(dr["PurcReturnDate"]);
                objPurcRet.Terms = dr["Terms"].ToString();
                objPurcRet.VoucherNumber = Convert.ToInt64(dr["VoucherNumber"]);
                objPurcRet.BillNo = Convert.ToInt64(dr["BillNumber"].ToString());
                objPurcRet.PurchaseType = dr["PurcType"].ToString();
                objPurcRet.Party = dr["ACC_NAME"].ToString();
                objPurcRet.MatCenter = dr["MatCentre"].ToString();
                objPurcRet.Narration = dr["Narration"].ToString();
                objPurcRet.TotalQty = Convert.ToDecimal(dr["TotalQty"]);
                objPurcRet.TotalFree = Convert.ToDecimal(dr["TotalFree"]);
                objPurcRet.TotalBasicAmount = Convert.ToDecimal(dr["TotalBasicAmount"]);
                objPurcRet.TotalDisAmount = Convert.ToDecimal(dr["TotalDisAmount"]);
                objPurcRet.TotalTaxAmount = Convert.ToDecimal(dr["TotalTaxAmount"]);
                objPurcRet.TotalAmount = Convert.ToDecimal(dr["TotalAmount"].ToString());
                objPurcRet.BSTotalAmount = Convert.ToDecimal(dr["BSTotalAmount"]);

                //SELECT Item Details
                StringBuilder sbitemQuery = new StringBuilder();
                sbitemQuery.AppendLine("SELECT i.*,im.ITEM_Name FROM purchasereturn_itemdetails as i");
                sbitemQuery.AppendLine("inner join itemmaster as im on i.ITM_ID=im.ITM_ID");
                sbitemQuery.AppendLine("WHERE PurcReturn_Id='" + id + "'");
                System.Data.IDataReader drItems = _dbHelper.ExecuteDataReader(sbitemQuery.ToString(), _dbHelper.GetConnObject());

                objPurcRet.Item_Voucher = new List<Item_VoucherModel>();
                Item_VoucherModel objitem;

                while (drItems.Read())
                {
                    objitem = new Item_VoucherModel();

                    objitem.Item_ID = Convert.ToInt32(drItems["Id"]);
                    objitem.ParentId = DataFormat.GetInteger(drItems["PurcReturn_Id"]);
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

                    objPurcRet.Item_Voucher.Add(objitem);
                }
                //Select BS Details
                StringBuilder sbBSQuery = new StringBuilder();
                sbBSQuery.AppendLine("SELECT pbs.*,mbs.Name FROM purchasereturn_bsdetails  as pbs");
                sbBSQuery.AppendLine("inner join  billsundarymaster as mbs on pbs.BS_Id=mbs.BS_Id");
                sbBSQuery.AppendLine("WHERE PurcReturn_Id='" + id + "'");
                System.Data.IDataReader drbs = _dbHelper.ExecuteDataReader(sbBSQuery.ToString(), _dbHelper.GetConnObject());

                objPurcRet.BillSundry_Voucher = new List<BillSundry_VoucherModel>();
                BillSundry_VoucherModel objbs;

                while (drbs.Read())
                {
                    objbs = new BillSundry_VoucherModel();

                    objbs.BSId = Convert.ToInt32(drbs["Id"]);
                    objbs.ParentId = DataFormat.GetInteger(drbs["PurcReturn_Id"]);
                    objbs.BillSundry = drbs["Name"].ToString();
                    objbs.Percentage = Convert.ToDecimal(drbs["Percentage"].ToString());
                    objbs.Extra = drbs["Extra"].ToString();
                    objbs.Amount = Convert.ToDecimal((drbs["Amount"].ToString()));

                    objPurcRet.BillSundry_Voucher.Add(objbs);
                }

            }
            return objPurcRet;
        }
        //Update Purchase Return Details
        public bool UpdatePurchaseReturn(eSunSpeedDomain.PurchaseReturnVoucherModel objPurc)
        {
            string Query = string.Empty;
            bool isUpdate = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@PR_Id", objPurc.PR_Id));
                paramCollection.Add(new DBParameter("@VoucherType", objPurc.VoucherType));
                paramCollection.Add(new DBParameter("@PurcDate", objPurc.PR_Date, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@Terms", objPurc.Terms));
                paramCollection.Add(new DBParameter("@VoucherNumber", objPurc.VoucherNumber));
                paramCollection.Add(new DBParameter("@BillNumber", objPurc.BillNo));
                paramCollection.Add(new DBParameter("@LedgerId", objPurc.LedgerId));
                paramCollection.Add(new DBParameter("@PurcType", objPurc.PurchaseType));
                paramCollection.Add(new DBParameter("@MatCentre", objPurc.MatCenter));
                paramCollection.Add(new DBParameter("@Narration", objPurc.Narration));
                paramCollection.Add(new DBParameter("@TotalAmount", objPurc.TotalAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalQty", objPurc.TotalQty, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalFree", objPurc.TotalFree, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalBasicAmount", objPurc.TotalBasicAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalDisAmount", objPurc.TotalDisAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalTaxAmount", objPurc.TotalTaxAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@BSTotalAmount", objPurc.BSTotalAmount, DbType.Decimal));
                paramCollection.Add(new DBParameter("@CreatedBy", ""));
                paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, DbType.DateTime));
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, DbType.DateTime));

                System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spUpdatePurchaseReturnMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);

                foreach (Item_VoucherModel item in objPurc.Item_Voucher)
                {
                    item.ParentId = objPurc.PR_Id;
                    if (item.Item_ID > 0)
                    {
                        paramCollection = new DBParameterCollection();

                        paramCollection.Add(new DBParameter("@ParentId", item.ParentId));
                        paramCollection.Add(new DBParameter("@IId", item.Item_ID));
                        paramCollection.Add(new DBParameter("@ITM_Id", item.ITM_Id));
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
                        paramCollection.Add(new DBParameter("@CreatedBy", ""));
                        paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, System.Data.DbType.DateTime));
                        paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                        paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, System.Data.DbType.DateTime));
                        System.Data.IDataReader drpr =
                        _dbHelper.ExecuteDataReader("spUpdatePurchaseReturnItemDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    }
                    else
                    {
                        paramCollection = new DBParameterCollection();

                        paramCollection.Add(new DBParameter("@ParentId", item.ParentId));
                        paramCollection.Add(new DBParameter("@ITM_Id", item.ITM_Id));
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
                        System.Data.IDataReader drpr =
                        _dbHelper.ExecuteDataReader("spInsertPurchaseReturnItemDetails", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                    }
                }
                foreach (BillSundry_VoucherModel bs in objPurc.BillSundry_Voucher)
                {
                    bs.ParentId = objPurc.PR_Id;
                    if (bs.BSId > 0)
                    {
                        paramCollection = new DBParameterCollection();

                        paramCollection.Add(new DBParameter("@ParentId", bs.ParentId));
                        paramCollection.Add(new DBParameter("@BSId", bs.BSId));
                        paramCollection.Add(new DBParameter("@BS_Id", bs.BS_Id));
                        paramCollection.Add(new DBParameter("@Percentage", bs.Percentage));
                        paramCollection.Add(new DBParameter("@Extra", bs.Extra));
                        paramCollection.Add(new DBParameter("@Amount", bs.Amount));
                        paramCollection.Add(new DBParameter("@CreatedBy", ""));
                        paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, DbType.DateTime));
                        paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                        paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, DbType.DateTime));

                        System.Data.IDataReader drbs =
                        _dbHelper.ExecuteDataReader("spUpdatePurchaseReturnBS", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
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

                        System.Data.IDataReader drbS =
                        _dbHelper.ExecuteDataReader("spInsertPurchaseReturnBS", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
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


        //Delete Purchase ReturnVoucher By Single Query
        public bool DeletePurchaseReturn(long id)
        {
            bool isDelete = false;
            try
            {
                if (DeletePurchaseReturnItems(id))
                {
                    if (DeletePurchaseReturnBS(id))
                    {
                        string Query = "DELETE FROM purchasereturn_master WHERE PurcReturn_Id=" + id;
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

        public bool DeletePurchaseReturnItems(long id)
        {
            bool isDelete = true;
            try
            {
                string Query = "DELETE FROM purchasereturn_itemdetails WHERE PurcReturn_Id=" + id;
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

        public bool DeletePurchaseReturnBS(long id)
        {
            bool isDelete = true;
            try
            {
                string Query = "DELETE FROM purchasereturn_bsdetails WHERE PurcReturn_Id=" + id;
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
