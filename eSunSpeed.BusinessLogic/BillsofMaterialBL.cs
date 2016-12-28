
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;
using System.Data;

namespace eSunSpeed.BusinessLogic
{
    public class BillsofMaterialBL
    {
        BillofMaterialModel objbommod = new BillofMaterialModel();
        private DBHelper _dbHelper = new DBHelper();

        //Save
        public bool SaveBOM(eSunSpeedDomain.BillofMaterialModel objBOM)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@BOMName", objBOM.BOMName));
                paramCollection.Add(new DBParameter("@Itemtoproduce",objBOM.Itemtoproduce));
                paramCollection.Add(new DBParameter("@Quantity", objBOM.Quantity, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@ItemUnit", objBOM.ItemUnit));
                paramCollection.Add(new DBParameter("@Expenses", objBOM.Expenses, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@SpecifyMCGenerated", objBOM.SpecifyMCGenerated, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@SpecifyDefaultMCforItemConsumed", objBOM.SpecifyDefaultMCforItemConsumed, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AppMc", objBOM.AppMc));
                paramCollection.Add(new DBParameter("@SNo", objBOM.SNo));
                paramCollection.Add(new DBParameter("@ItemName", objBOM.ItemName));
                paramCollection.Add(new DBParameter("@Qty", objBOM.Qty, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@Unit", objBOM.Unit, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalofConsumedqtyUnit", objBOM.TotalofConsumedqtyUnit, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                Query = "INSERT INTO billsofmaterial(`BomName`,`Itemtoproduce`,`Quantity`,`ItemUnit`,`Expenses`,`SpecifyMCGenerated`,`SpecifyDefaultMCforItemConsumed`,`AppMc`,`SNo`,`ItemName`,`Qty`,`Unit`,`TotalofConsumedqtyUnit`,`CreatedBy`) " +
                    "VALUES(@BOMName,@Itemtoproduce,@Quantity,@ItemUnit,@Expenses,@SpecifyMCGenerated,@SpecifyDefaultMCforItemConsumed,@AppMc,@SNo,@ItemName,@Qty,@Unit,@TotalofConsumedqtyUnit,@CreatedBy)";

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
        //updatebom
        public bool UpdateBOM(eSunSpeedDomain.BillofMaterialModel objBOM)
        {
            string Query = string.Empty;
            bool isUpdated = true;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();


                paramCollection.Add(new DBParameter("@BOMName", objBOM.BOMName));
                paramCollection.Add(new DBParameter("@ItemProduct", objBOM.Itemtoproduce));
                paramCollection.Add(new DBParameter("@Quantity", objBOM.Quantity, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@ItemUnit", objBOM.ItemUnit));
                paramCollection.Add(new DBParameter("@Expenses", objBOM.Expenses, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@SpecifyMCGenerated", objBOM.SpecifyMCGenerated, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@SpecifyDefaultMCforItemConsumed", objBOM.SpecifyDefaultMCforItemConsumed, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AppMc", objBOM.AppMc));
                paramCollection.Add(new DBParameter("@SNo", objBOM.SNo));
                paramCollection.Add(new DBParameter("@ItemName", objBOM.ItemName));
                paramCollection.Add(new DBParameter("@Qty", objBOM.Qty, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@Unit", objBOM.Unit, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@TotalofConsumedqtyUnit", objBOM.TotalofConsumedqtyUnit, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@Bom_Id", objBOM.Bom_Id));


                Query = "UPDATE BillsofMaterial SET [BOMName]=@BOMName,[ItemProduct]=@ItemProduct,[Quantity]=@Quantity,[ItemUnit]=@ItemUnit,[Expenses]=@Expenses,[SpecifyMCGenerated]=@SpecifyMCGenerated, " +
                   "[SpecifyDefaultMCforItemConsumed]=@SpecifyDefaultMCforItemConsumed,[AppMc]=@AppMc,[SNo]=@SNo,[ItemName]=@ItemName, " +
                   "[Qty]=@Qty,[Unit]=@Unit,[TotalofConsumedqtyUnit]=@TotalofConsumedqtyUnit,[ModifiedBy]=@ModifiedBy " +
                   "WHERE BOM_Id=@BOM_Id";



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

        #region Delete Unit
        /// <summary>
        /// Modified UNIT
        /// </summary>
        /// <param name="UNITIDS"></param>
        /// <returns>True/False</returns>
        public bool DeleteBOM(List<int> BomIds)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection;

                foreach (int id in BomIds)
                {
                    paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@BOM_ID", id));
                    Query = "Delete from BillsofMaterial WHERE [BOM_id]=@BOM_ID";

                    if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
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
        #endregion

        //List

        public List<eSunSpeedDomain.BillofMaterialModel> GetAllBillofMaterial()
        {
            List<eSunSpeedDomain.BillofMaterialModel> lstBom = new List<BillofMaterialModel>();
            eSunSpeedDomain.BillofMaterialModel objBom;

            string Query = "SELECT * FROM BillsofMaterial";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {

                objBom = new BillofMaterialModel();

                objBom.BOMName = dr["BOMName"].ToString();
                objBom.Itemtoproduce= dr["ItemProduct"].ToString();
                objBom.Quantity = Convert.ToDecimal(dr["Quantity"]);
                objBom.ItemUnit = dr["ItemUnit"].ToString();
                objBom.Expenses = Convert.ToDecimal(dr["Expenses"]);
                objBom.SpecifyMCGenerated = Convert.ToBoolean(dr["SpecifyMcGenerated"]);
                objBom.SourceMC = dr["SourceMC"].ToString();
                objBom.SpecifyDefaultMCforItemConsumed = Convert.ToBoolean(dr["SpecifyDefaultMCforItemConsumed"]);
                objBom.AppMc = dr["AppMc"].ToString();
                objBom.SNo = Convert.ToInt32(dr["SNo"]);
                objBom.ItemName = dr["ItemName"].ToString();
                objBom.Qty = Convert.ToDecimal(dr["Qty"]);
                objBom.Unit = Convert.ToDecimal(dr["Unit"]);
                objBom.TotalofConsumedqtyUnit = Convert.ToDecimal(dr["TotalofConsumedqtyUnit"]);


                lstBom.Add(objBom);



            }

            return lstBom;
        }

        //Search

        public List<eSunSpeedDomain.BillofMaterialModel> GetBOMbySearchCriteria(SearchCriteria obj)
        {
            //TODO: Required to finalize
            return null;
        }

    }
}
    
        




    