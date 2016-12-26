using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeed.Formatting;
using eSunSpeed.DataAccess;
using eSunSpeedDomain;
using eSunSpeed.Configurations;

namespace eSunSpeed.BusinessLogic
{
    public class PurchaseQuotationBL
    {
        private DBHelper _dbHelper = new DBHelper();
        //SAVE PURCHASE Quotation
        public bool SavePurchaseQuotation(PurchaseVoucherMainModel objPurcQuotation)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@VoucherNumber", objPurcQuotation.PurchaseVoucher_Number));
                paramCollection.Add(new DBParameter("@Series", objPurcQuotation.PurchaseVoucher_Series));
                paramCollection.Add(new DBParameter("@PurcDate", objPurcQuotation.PurchaseVoucher_Date, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@PurcType", objPurcQuotation.PurchaseVoucher_PurchaseType));
                paramCollection.Add(new DBParameter("@Party", objPurcQuotation.PurchaseVoucher_Party));
                paramCollection.Add(new DBParameter("@MatCentre", objPurcQuotation.PurchaseVoucher_MatCenter));
                paramCollection.Add(new DBParameter("@Narration", objPurcQuotation.Narration));
                paramCollection.Add(new DBParameter("@ItemTotalAmount", objPurcQuotation.TotalAmount));
                paramCollection.Add(new DBParameter("@ItemTotalQty", objPurcQuotation.TotalQty));
                paramCollection.Add(new DBParameter("@BSTotalAmount", objPurcQuotation.BSTotalAmount));

                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertPurchaseQuotationMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);

                int id = 0;
                dr.Read();
                id = Convert.ToInt32(dr[0]);

                SavePurchaseQuotationItems(objPurcQuotation.PurchaseItem_Voucher, id);
                SavePurchaseQuotationBillSundry(objPurcQuotation.BillSundry_Voucher, id);
            }
            catch (Exception ex)
            {
                isSaved = false;
                throw ex;
            }

            return isSaved;
        }


        public bool SavePurchaseQuotationItems(List<Item_VoucherModel> lstSales, int ParentId)
        {
            string Query = string.Empty;
            bool isSaved = true;
            foreach (Item_VoucherModel item in lstSales)
            {
                item.ParentId = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@PQId", item.ParentId));
                    //paramCollection.Add(new DBParameter("@Batch", item.Batch));
                    paramCollection.Add(new DBParameter("@Item", item.Item));
                    paramCollection.Add(new DBParameter("@Qty", item.Qty));
                    paramCollection.Add(new DBParameter("@Unit", item.Unit));
                    paramCollection.Add(new DBParameter("@Price", item.Price));
                    paramCollection.Add(new DBParameter("@Amount", item.Amount));
                    //paramCollection.Add(new DBParameter("@TotalQty", item.TotalQty));
                    //paramCollection.Add(new DBParameter("@TotalAmount", item.TotalAmount));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertPurchaseQuotationItem", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);

                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }

        public bool SavePurchaseQuotationBillSundry(List<BillSundry_VoucherModel> lstBS, int ParentId)
        {
            string Query = string.Empty;

            bool isSaved = true;

            foreach (BillSundry_VoucherModel bs in lstBS)
            {
                bs.ParentId = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@PQId", bs.ParentId));
                    paramCollection.Add(new DBParameter("@BillSundry", bs.BillSundry));
                    paramCollection.Add(new DBParameter("@Narration", bs.Narration));
                    paramCollection.Add(new DBParameter("@Percentage", bs.Percentage));
                    paramCollection.Add(new DBParameter("@Amount", bs.Amount));
                    paramCollection.Add(new DBParameter("@TotalAmount", bs.TotalAmount));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertPurchaseQuotationBS", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }
    }
}
