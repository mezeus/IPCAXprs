using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;
using eSunSpeed.Formatting;

namespace eSunSpeed.BusinessLogic
{
    public class StockJournalBL
    {
        private DBHelper _dbHelper = new DBHelper();

        public bool SaveStockJournalMaster(StockJournalModel objjournal)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@VoucherNumber", objjournal.Voucher_Number));
                paramCollection.Add(new DBParameter("@Series", objjournal.Series));
                paramCollection.Add(new DBParameter("@Date", objjournal.SJ_Date, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@MatCentreIG", objjournal.MatCenterIG));
                paramCollection.Add(new DBParameter("@MatCentreIC", objjournal.MatCenterIC));
                paramCollection.Add(new DBParameter("@Narration", objjournal.Narration));
                //paramCollection.Add(new DBParameter("@ItemTotalAmount", objSales.TotalAmount));
                //paramCollection.Add(new DBParameter("@ItemTotalQty", objSales.TotalQty));

                //paramCollection.Add(new DBParameter("@BSTotalAmount", objSales.BSTotalAmount));

                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spInsertStockjournalMaster", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);

                int id = 0;
                dr.Read();
                id = Convert.ToInt32(dr[0]);

                SaveStockJournalItemgenerate(objjournal.Item_Generated, id);
                SaveStockJournalItemConsumed(objjournal.Item_Consumed, id);
            }
            catch (Exception ex)
            {
                isSaved = false;
                throw ex;
            }

            return isSaved;
        }

        public bool SaveStockJournalItemgenerate(List<Item_VoucherModel> lstItemGenerate, int ParentId)
        {
            string Query = string.Empty;
            bool isSaved = true;

            foreach (Item_VoucherModel item in lstItemGenerate)
            {
                item.ParentId = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@StockId", item.ParentId));
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
                    _dbHelper.ExecuteDataReader("spInsertStockJournalItemgenerated", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    isSaved = false;
                    throw ex;
                }
            }
            return isSaved;
        }

        public bool SaveStockJournalItemConsumed(List<ItemConsumedModel> lstItemConsumed, int ParentId)
        {
            string Query = string.Empty;
            bool isSaved = true;

            foreach (ItemConsumedModel itemcon in lstItemConsumed)
            {
                itemcon.ParentId = ParentId;

                try
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@StockId", itemcon.ParentId));
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
                    _dbHelper.ExecuteDataReader("spInsertStockJournalItemconsumed", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
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
