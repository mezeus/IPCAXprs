using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;
using eSunSpeed.Formatting;

namespace eSunSpeed.BusinessLogic
{
    public class SalesQuotationBL
    {
        private DBHelper _dbHelper = new DBHelper();

        // SAVE Sales Quotation
        public bool SaveSalesQuotation(TransSalesModel objSalesQut)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@VoucherNumber", objSalesQut.VoucherNumber));
                paramCollection.Add(new DBParameter("@Series", objSalesQut.Series));
                paramCollection.Add(new DBParameter("@SQDate", objSalesQut.SaleDate, System.Data.DbType.DateTime));

                //paramCollection.Add(new DBParameter("@BillNo", objSales.BillNo));
                //paramCollection.Add(new DBParameter("@DueDate", objSales.DueDate));
                paramCollection.Add(new DBParameter("@SalesType", objSalesQut.SalesType));
                paramCollection.Add(new DBParameter("@Party", objSalesQut.Party));
                paramCollection.Add(new DBParameter("@MatCentre", objSalesQut.MatCentre));

                paramCollection.Add(new DBParameter("@Narration", objSalesQut.Narration));
                paramCollection.Add(new DBParameter("@ItemTotalAmount", objSalesQut.TotalAmount));
                paramCollection.Add(new DBParameter("@ItemTotalQty", objSalesQut.TotalQty));

                paramCollection.Add(new DBParameter("@BSTotalAmount", objSalesQut.BSTotalAmount));

                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));


                System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertSalesQuotationMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);

                int id = 0;
                dr.Read();
                id = Convert.ToInt32(dr[0]);

                SaveSalesQuotationItems(objSalesQut.SalesItem_Voucher, id);
                SaveSalesQuotationBillSundryVoucher(objSalesQut.SalesBillSundry_Voucher, id);

            }
            catch (Exception ex)
            {
                isSaved = false;
                throw ex;
            }

            return isSaved;
        }

        public bool SaveSalesQuotationItems(List<Item_VoucherModel> lstSales, int ParentId)
        {
            string Query = string.Empty;
            bool isSaved = true;
            foreach (Item_VoucherModel item in lstSales)
            {
                item.ParentId = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@SQId", item.ParentId));
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
                    _dbHelper.ExecuteDataReader("spInsertSalesQuotationItem", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
            
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }

        public bool SaveSalesQuotationBillSundryVoucher(List<BillSundry_VoucherModel> lstBS, int ParentId)
        {
            string Query = string.Empty;

            bool isSaved = true;

            foreach (BillSundry_VoucherModel bs in lstBS)
            {
                bs.ParentId = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@SQId", bs.ParentId));
                    paramCollection.Add(new DBParameter("@BillSundry", bs.BillSundry));
                    paramCollection.Add(new DBParameter("@Narration", bs.Narration));
                    paramCollection.Add(new DBParameter("@Percentage", bs.Percentage));
                    paramCollection.Add(new DBParameter("@Amount", bs.Amount));
                    paramCollection.Add(new DBParameter("@TotalAmount", bs.TotalAmount));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertSalesQuotationBS", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
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

