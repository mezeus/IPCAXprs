using eSunSpeed.DataAccess;
using eSunSpeed.Formatting;
using eSunSpeedDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeed.BusinessLogic
{
    public class PurchaseVoucher
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
            string Query = "SELECT MAX(PurchaseVoucher_ID) FROM PurchaseMain_Voucher";

            int id = Convert.ToInt32(_dbHelper.ExecuteScalar(Query));

            return id;
        }
        #endregion

        #region UPDATE SALE VOUCHER

        public bool UpdatePurchaseVoucher(eSunSpeedDomain.PurchaseVoucherMainModel objPurc)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@PurchaseVoucher_Series", objPurc.PurchaseVoucher_Series));
                paramCollection.Add(new DBParameter("@PurchaseVoucher_Date", objPurc.PurchaseVoucher_Date));
                paramCollection.Add(new DBParameter("@PurchaseVoucher_Number", objPurc.PurchaseVoucher_Number));
                paramCollection.Add(new DBParameter("@PurchaseVoucher_PurchaseType", objPurc.PurchaseVoucher_PurchaseType));
                paramCollection.Add(new DBParameter("@PurchaseVoucher_Party", objPurc.PurchaseVoucher_Party));
                paramCollection.Add(new DBParameter("@PurchaseVoucher_MatCenter", objPurc.PurchaseVoucher_MatCenter));

                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));
                paramCollection.Add(new DBParameter("@PurchaseVoucher_ID",objPurc.PurchaseVoucher_ID));

                Query = "UPDATE PurchaseMain_Voucher SET [PurchaseVoucher_Series]=@PurchaseVoucher_Series,[PurchaseVoucher_Date]=@PurchaseVoucher_Date,"+
                         "[PurchaseVoucher_Number]=@PurchaseVoucher_Number,[PurchaseVoucher_PurchType]=@PurchaseVoucher_PurchaseType," +
                        "[PurchaseVoucher_Party]=@PurchaseVoucher_Party,[PurchaseVoucher_MatCenter]=@PurchaseVoucher_MatCenter,"+
                        "[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
                        "WHERE PurchaseVoucher_ID=@PurchaseVoucher_ID;";

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
       
        public bool UpdatePurchaseVoucherItems(eSunSpeedDomain.Item_VoucherModel objPurchItem)
        {
            string Query = string.Empty;
            bool isUpdated = true;            

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                
                paramCollection.Add(new DBParameter("@Purchase_Item", objPurchItem.Item));
                paramCollection.Add(new DBParameter("@Purchase_Qty", objPurchItem.Qty));
                paramCollection.Add(new DBParameter("@Purchase_Unit", objPurchItem.Qty));
                paramCollection.Add(new DBParameter("@Purchase_Price", objPurchItem.Price));
                paramCollection.Add(new DBParameter("@Purchase_Amount", objPurchItem.Amount));
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));
                paramCollection.Add(new DBParameter("@PurchaseVoucher_ID", objPurchItem.ParentId));
                paramCollection.Add(new DBParameter("@PurchaseItem_ID", objPurchItem.Item_ID));                

                Query = "UPDATE PurchaseItem_Voucher SET [Purchase_Item]=@Purchase_Item,[Purchase_Qty]=@Purchase_Qty,[Purchase_Unit]=@Purchase_Unit," +
                "[Purchase_Price]=@Purchase_Price,[Purchase_Amount]=@Purchase_Amount,[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
                "WHERE PurchaseVoucher_ID=@PurchaseVoucher_ID AND [PurchaseItem_ID]=@PurchaseItem_ID";


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

        public bool UpdatePurchaseBillSundryVoucher(eSunSpeedDomain.BillSundry_VoucherModel objBSVoucher)
        {
            string Query = string.Empty;
            bool isUpdate = true;            

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                
                paramCollection.Add(new DBParameter("@PurchaseBillSundry_Name", objBSVoucher.BillSundry));
                paramCollection.Add(new DBParameter("@PurchaseBillSundry_Amount", objBSVoucher.Amount));
                paramCollection.Add(new DBParameter("@PurchaseBillSundry_Qty", objBSVoucher.Amount));
                paramCollection.Add(new DBParameter("@PurchaseBillSundry_Unit", objBSVoucher.Percentage));                                
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));
                
                paramCollection.Add(new DBParameter("@PurchaseBillSundry_ID", objBSVoucher.BSId));
                paramCollection.Add(new DBParameter("@PurchaseVoucher_ID", objBSVoucher.ParentId));

                Query = "UPDATE PurchaseBillSundry_Voucher SET [PurchaseBillSundry_Name]=@PurchaseBillSundry_Name,[PurchaseBillSundry_Amount]=@PurchaseBillSundry_Amount," +
                "[PurchaseBillSundry_Qty]=@PurchaseBillSundry_Qty,[PurchaseBillSundry_Unit]=@PurchaseBillSundry_Unit,[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
                "WHERE [PurchaseBillSundry_ID]=@PurchaseBillSundry_ID AND [PurchaseVoucher_ID]=@PurchaseVoucher_ID";

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

        public List<eSunSpeedDomain.PurchaseVoucherMainModel> GetAllPurchaseVouchers()
        {
            List<eSunSpeedDomain.PurchaseVoucherMainModel> lstPurchaseVouchers = new List<eSunSpeedDomain.PurchaseVoucherMainModel>();
            eSunSpeedDomain.PurchaseVoucherMainModel objPurch;

            string Query = "SELECT * FROM PurchaseMain_Voucher";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objPurch = new eSunSpeedDomain.PurchaseVoucherMainModel();

                objPurch.PurchaseVoucher_ID = DataFormat.GetInteger(dr["PurchaseVoucher_ID"]);

                objPurch.PurchaseVoucher_Date = DataFormat.GetDateTime(dr["PurchaseVoucher_Date"]);
                objPurch.PurchaseVoucher_Number = DataFormat.GetInteger(dr["PurchaseVoucher_Number"]);
                objPurch.PurchaseVoucher_PurchaseType = dr["PurchaseVoucher_PurchType"].ToString();
                objPurch.PurchaseVoucher_Party = dr["PurchaseVoucher_Party"].ToString();
                objPurch.PurchaseVoucher_MatCenter = dr["PurchaseVoucher_MatCenter"].ToString();
                

                //Add Purchase Items
                string itemQuery = "SELECT * FROM PurchaseItem_Voucher WHERE PurchaseVoucher_ID=" + objPurch.PurchaseVoucher_ID;
                System.Data.IDataReader drItem = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                objPurch.PurchaseItem_Voucher = new List<eSunSpeedDomain.Item_VoucherModel>();
                eSunSpeedDomain.Item_VoucherModel objItemModel;

                while (drItem.Read())
                {
                    objItemModel = new eSunSpeedDomain.Item_VoucherModel();

                    objItemModel.ParentId = DataFormat.GetInteger(drItem["PurchaseVoucher_ID"]);
                    objItemModel.Item_ID = DataFormat.GetInteger(drItem["PurchaseItem_ID"]);
                    objItemModel.Item = drItem["Purchase_Item"].ToString();
                    objItemModel.Price = Convert.ToDecimal(drItem["Purchase_Price"]);
                    objItemModel.Qty = Convert.ToDecimal(drItem["Purchase_Qty"]);
                    objItemModel.Unit = drItem["Purchase_Unit"].ToString();

                    objPurch.PurchaseItem_Voucher.Add(objItemModel);

                }

                //Add Bill Sundry Voucher items
                string bsQuery = "SELECT * FROM PurchaseBillSundry_Voucher WHERE PurchaseVoucher_ID=" + objPurch.PurchaseVoucher_ID;
                System.Data.IDataReader drBS = _dbHelper.ExecuteDataReader(bsQuery, _dbHelper.GetConnObject());

                objPurch.BillSundry_Voucher = new List<eSunSpeedDomain.BillSundry_VoucherModel>();
                eSunSpeedDomain.BillSundry_VoucherModel objBSModel;

                while (drBS.Read())
                {
                    objBSModel = new eSunSpeedDomain.BillSundry_VoucherModel();

                    objBSModel.ParentId = DataFormat.GetInteger(drBS["PurchaseVoucher_ID"]);
                    objBSModel.BSId = DataFormat.GetInteger(drBS["PurchaseBillSundry_ID"]);
                    objBSModel.BillSundry = drBS["PurchaseBillSundry_Name"].ToString();
                    objBSModel.Amount = Convert.ToDecimal(drBS["PurchaseBillSundry_Amount"]);
                    objBSModel.Percentage = Convert.ToDecimal(drBS["PurchaseBillSundry_Qty"]);
                    //objBSModel.TotalAmount = drBS["PurchaseBillSundry_Unit"]

                    objPurch.BillSundry_Voucher.Add(objBSModel);

                }

                lstPurchaseVouchers.Add(objPurch);

            }
            return lstPurchaseVouchers;
        }
    }
}
