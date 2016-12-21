using eSunSpeed.DataAccess;
using eSunSpeed.Formatting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eSunSpeed.BusinessLogic
{
    public class SalesReturnVoucher
    {
        private DBHelper _dbHelper = new DBHelper();

        #region SAVE SALE RETURN VOUCHER
        public bool SaveSalesReturnVoucher(eSunSpeedDomain.SalesReturnVoucherModel objSalesRet)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@SalesReturnVoucher_Series", objSalesRet.SalesReturnVoucher_Series));
                paramCollection.Add(new DBParameter("@SalesReturnVoucher_Date", objSalesRet.SalesReturnVoucher_Date));
                paramCollection.Add(new DBParameter("@SalesReturnVoucher_Number", objSalesRet.SalesReturnVoucher_Number));
                paramCollection.Add(new DBParameter("@SalesReturnVoucher_SalesType", objSalesRet.SalesReturnVoucher_SalesType));
                paramCollection.Add(new DBParameter("@SalesReturnVoucher_Party", objSalesRet.SalesReturnVoucher_Party));
                paramCollection.Add(new DBParameter("@SalesVoucher_MatCenter", objSalesRet.SalesReturnVoucher_MatCenter));
                
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));


                Query = "INSERT INTO SalesReturn_Voucher([SalesReturnVoucher_Series],[SalesReturnVoucher_Date],[SalesReturnVoucher_Number],[SalesReturnVoucher_SalesType],[SalesReturnVoucher_Party],"+
                "[SalesReturnVoucher_MatCenter],[CreatedBy]) VALUES " +
                "(@SalesReturnVoucher_Series,@SalesReturnVoucher_Date,@SalesReturnVoucher_Number,@SalesReturnVoucher_SalesType,@SalesReturnVoucher_Party,@SalesReturnVoucher_MatCenter,@CreatedBy)";

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

        public bool SaveSalesReturnVoucherItems(eSunSpeedDomain.Item_VoucherModel objSalesItem)
        {
            string Query = string.Empty;
            bool isSaved = true;

            objSalesItem.ParentId = GetSalesVoucherId();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@SalesReturnVoucher_ID", objSalesItem.ParentId));                
                paramCollection.Add(new DBParameter("@SalesReturn_Item", objSalesItem.Item));
                paramCollection.Add(new DBParameter("@SalesReturn_Qty", objSalesItem.Qty));
                paramCollection.Add(new DBParameter("@SalesReturn_Unit", objSalesItem.Qty));
                paramCollection.Add(new DBParameter("@SalesReturn_Price", objSalesItem.Price));
                paramCollection.Add(new DBParameter("@SalesReturn_Amount", objSalesItem.Amount));

                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));


                Query = "INSERT INTO SalesReturnItem_Voucher([SalesReturnVoucher_ID],[SalesReturn_Item],[SalesReturn_Qty],[SalesReturn_Unit]," +
                "[SalesReturn_Price],[SalesReturn_Amount],[CreatedBy]) VALUES " +
                "(@SalesReturnVoucher_ID,@SalesReturn_Item,@SalesReturn_Qty,@SalesReturn_Unit,@SalesReturn_Price,@SalesReturn_Amount,@CreatedBy)";

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

        public bool SaveSalesReturnBillSundryVoucher(eSunSpeedDomain.BillSundry_VoucherModel objBSVoucher)
        {
            
            string Query = string.Empty;
            bool isSaved = true;
            /*
            objBSVoucher.Voucher_ID = GetSalesVoucherId();

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@SalesReturnVoucher_ID", objBSVoucher.Voucher_ID));
                paramCollection.Add(new DBParameter("@SalesReturnBillSundry_Name", objBSVoucher.BillSundry_Name));
                paramCollection.Add(new DBParameter("@SalesReturnBillSundry_Amount", objBSVoucher.BillSundry_Amount));
                paramCollection.Add(new DBParameter("@SalesReturnBillSundry_Qty", objBSVoucher.BillSundry_Qty));
                paramCollection.Add(new DBParameter("@SalesReturnBillSundry_Unit", objBSVoucher.BillSundry_Unit));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                Query = "INSERT INTO SalesReturnBillSundry_Voucher([SalesReturnVoucher_ID],[SalesReturnBillSundry_Name],[SalesReturnBillSundry_Amount]," +
                "[SalesReturnBillSundry_Qty],[SalesReturnBillSundry_Unit],[CreatedBy]) VALUES " +
                "(@SalesReturnVoucher_ID,@SalesReturnBillSundry_Name,@SalesReturnBillSundry_Amount,@SalesReturnBillSundry_Qty,@SalesReturnBillSundry_Unit,@CreatedBy)";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                    isSaved = true;
            }
            catch (Exception ex)
            {
                isSaved = false;
                throw ex;
            }
            */
            return isSaved;
        }

        public int GetSalesVoucherId()
        {
            string Query = "SELECT MAX(SalesReturnVoucher_ID) FROM SalesReturn_Voucher";

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

                paramCollection.Add(new DBParameter("@SalesVoucher_Series", objSales.Series));
                paramCollection.Add(new DBParameter("@SalesVoucher_Date", objSales.SaleDate));
                paramCollection.Add(new DBParameter("@SalesVoucher_Number", objSales.VoucherNumber));
                paramCollection.Add(new DBParameter("@SalesVoucher_SalesType", objSales.SalesType));
                paramCollection.Add(new DBParameter("@SalesVoucher_Party", objSales.Party));
                paramCollection.Add(new DBParameter("@SalesVoucher_MatCenter", objSales.MatCentre));

                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));
                paramCollection.Add(new DBParameter("@SalesVoucher_ID",objSales.Trans_Sales_Id));

                Query = "UPDATE SalesMain_Voucher SET [SalesVoucher_Series]=@SalesVoucher_Series,[SalesVoucher_Date]=@SalesVoucher_Date,"+
                         "[SalesVoucher_Number]=@SalesVoucher_Number,[SalesVoucher_SalesType]=@SalesVoucher_SalesType," +
                        "[SalesVoucher_Party]=@SalesVoucher_Party,[SalesVoucher_MatCenter]=@SalesVoucher_MatCenter,"+
                        "[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
                        "WHERE SalesVoucher_ID=@SalesVoucher_ID;";

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
       
        public bool UpdateSalesVoucherItems(eSunSpeedDomain.Item_VoucherModel objSalesItem)
        {
            string Query = string.Empty;
            bool isUpdated = true;            

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                
                paramCollection.Add(new DBParameter("@Sales_Item", objSalesItem.Item));
                paramCollection.Add(new DBParameter("@Sales_Qty", objSalesItem.Qty));
                paramCollection.Add(new DBParameter("@Sales_Unit", objSalesItem.Qty));
                paramCollection.Add(new DBParameter("@Sales_Price", objSalesItem.Price));
                paramCollection.Add(new DBParameter("@Sales_Amount", objSalesItem.Amount));
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));
                paramCollection.Add(new DBParameter("@SalesVoucher_ID", objSalesItem.ParentId));
                paramCollection.Add(new DBParameter("@SalesItem_ID", objSalesItem.Item_ID));                

                Query = "UPDATE SalesItem_Voucher SET [Sales_Item]=@Sales_Item,[Sales_Qty]=@Sales_Qty,[Sales_Unit]=@Sales_Unit," +
                "[Sales_Price]=@Sales_Price,[Sales_Amount]=@Sales_Amount,[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
                "WHERE SalesVoucher_ID=@SalesVoucher_ID AND [SalesItem_ID]=@SalesItem_ID";


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

        public bool UpdateSalesBillSundryVoucher(eSunSpeedDomain.BillSundry_VoucherModel objBSVoucher)
        {
            string Query = string.Empty;
            bool isUpdate = true;            

            /*
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                
                paramCollection.Add(new DBParameter("@SalesBillSundry_Name", objBSVoucher.BillSundry_Name));
                paramCollection.Add(new DBParameter("@SalesBillSundry_Amount", objBSVoucher.BillSundry_Amount));
                paramCollection.Add(new DBParameter("@SalesBillSundry_Qty", objBSVoucher.BillSundry_Qty));
                paramCollection.Add(new DBParameter("@SalesBillSundry_Unit", objBSVoucher.BillSundry_Unit));                                
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now));
                
                paramCollection.Add(new DBParameter("@SalesBillSundry_ID", objBSVoucher.BillSundry_ID));
                paramCollection.Add(new DBParameter("@SalesVoucher_ID", objBSVoucher.Voucher_ID));

                Query = "UPDATE SalesBillSundry_Voucher SET [SalesBillSundry_Name]=@SalesBillSundry_Name,[SalesBillSundry_Amount]=@SalesBillSundry_Amount," +
                "[SalesBillSundry_Qty]=@SalesBillSundry_Qty,[SalesBillSundry_Unit]=@SalesBillSundry_Unit,[ModifiedBy]=@ModifiedBy,[ModifiedDate]=@ModifiedDate " +
                "WHERE [SalesBillSundry_ID]=@SalesBillSundry_ID AND [SalesVoucher_ID]=@SalesVoucher_ID";

                if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                    isUpdate = true;
            }
            catch (Exception ex)
            {
                isUpdate = false;
                throw ex;
            }
            */
            return isUpdate;
        }
        #endregion

        public List<eSunSpeedDomain.SalesReturnVoucherModel> GetAllSalesReturnVouchers()
        {
            List<eSunSpeedDomain.SalesReturnVoucherModel> lstSalesReturnVouchers = new List<eSunSpeedDomain.SalesReturnVoucherModel>();
            eSunSpeedDomain.SalesReturnVoucherModel objSalesReturn;

            /*
            string Query = "SELECT * FROM SalesReturnMain_Voucher";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objSalesReturn = new eSunSpeedDomain.SalesReturnVoucherModel();

                objSalesReturn.SalesReturnVoucher_ID = DataFormat.GetInteger(dr["SalesReturnVoucher_ID"]);

                objSalesReturn.SalesReturnVoucher_Date = DataFormat.GetDateTime(dr["SalesReturnVoucher_Date"]);
                objSalesReturn.SalesReturnVoucher_Number = DataFormat.GetInteger(dr["SalesReturnVoucher_Number"]);
                objSalesReturn.SalesReturnVoucher_SalesType = dr["SalesReturnVoucher_SalesType"].ToString();
                objSalesReturn.SalesReturnVoucher_Party = dr["SalesReturnVoucher_Party"].ToString();
                objSalesReturn.SalesReturnVoucher_MatCenter = dr["SalesReturnVoucher_MatCenter"].ToString();
                

                //Add SalesReturn Items
                string itemQuery = "SELECT * FROM SalesReturnItem_Voucher WHERE SalesReturnVoucher_ID=" + objSalesReturn.SalesReturnVoucher_ID;
                System.Data.IDataReader drItem = _dbHelper.ExecuteDataReader(itemQuery, _dbHelper.GetConnObject());

                objSalesReturn.Item_Voucher = new List<eSunSpeedDomain.Item_VoucherModel>();
                eSunSpeedDomain.Item_VoucherModel objItemModel;

                while (drItem.Read())
                {
                    objItemModel = new eSunSpeedDomain.Item_VoucherModel();

                    objItemModel.Voucher_ID = DataFormat.GetInteger(drItem["SalesReturnVoucher_ID"]);
                    objItemModel.Item_ID = DataFormat.GetInteger(drItem["SalesReturnItem_ID"]);
                    objItemModel.Item = drItem["SalesReturn_Item"].ToString();
                    objItemModel.Price = Convert.ToDecimal(drItem["SalesReturn_Price"]);
                    objItemModel.Qty = Convert.ToDecimal(drItem["SalesReturn_Qty"]);
                    objItemModel.Unit = drItem["SalesReturn_Unit"].ToString();

                    objSalesReturn.Item_Voucher.Add(objItemModel);

                }

                //Add Bill Sundry Voucher items
                string bsQuery = "SELECT * FROM SalesReturnBillSundry_Voucher WHERE SalesReturnVoucher_ID=" + objSalesReturn.SalesReturnVoucher_ID;
                System.Data.IDataReader drBS = _dbHelper.ExecuteDataReader(bsQuery, _dbHelper.GetConnObject());

                objSalesReturn.BillSundry_Voucher = new List<eSunSpeedDomain.BillSundry_VoucherModel>();
                eSunSpeedDomain.BillSundry_VoucherModel objBSModel;

                while (drBS.Read())
                {
                    objBSModel = new eSunSpeedDomain.BillSundry_VoucherModel();

                    objBSModel.Voucher_ID = DataFormat.GetInteger(drBS["SalesReturnVoucher_ID"]);
                    objBSModel.BillSundry_ID = DataFormat.GetInteger(drBS["SalesReturnBillSundry_ID"]);
                    objBSModel.BillSundry_Name = drBS["SalesReturnBillSundry_Name"].ToString();
                    objBSModel.BillSundry_Amount = Convert.ToDecimal(drBS["SalesReturnBillSundry_Amount"]);
                    objBSModel.BillSundry_Qty = Convert.ToDecimal(drBS["SalesReturnBillSundry_Qty"]);
                    objBSModel.BillSundry_Unit = drBS["SalesReturnBillSundry_Unit"].ToString();

                    objSalesReturn.BillSundry_Voucher.Add(objBSModel);

                }

                lstSalesReturnVouchers.Add(objSalesReturn);

            }
            */
            return lstSalesReturnVouchers;
        }
    }
}
