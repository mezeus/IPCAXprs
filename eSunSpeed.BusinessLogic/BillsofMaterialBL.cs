﻿
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
                {
                    SaveRawMaterialConsumed(objBOM.MaterialConsumed);
                    SaveMaterialGenerated(objBOM.MaterialGenerated);
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
        //Save Item Raw Material Consumed
        public bool SaveRawMaterialConsumed(List<BillsofMaterialDetailsModel> lstConsumed)
        {
            string Query = string.Empty;
            bool isSaved = true;
            int ParentId = GetBillofMaterialId();
            foreach (BillsofMaterialDetailsModel objConsumed in lstConsumed)
            {
                try
                {
                    objConsumed.id = ParentId;

                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Consumed_Id",ParentId));
                    paramCollection.Add(new DBParameter("@Consumed_Item", objConsumed.ItemName));
                    paramCollection.Add(new DBParameter("@Consumed_Qty", objConsumed.Qty));
                    paramCollection.Add(new DBParameter("@Consumed_Unit", objConsumed.Unit));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    Query = "INSERT INTO bom_consumed_details(`Bom_Id`,`ItemName`,`Qty`,`Unit`,`CreatedBy`)" +
                            "VALUES(@Consumed_Id,@Consumed_Item,@Consumed_Qty,@Consumed_Unit,@CreatedBy)";

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

        //Save Item Raw Material Generated
        public bool SaveMaterialGenerated(List<BillsofMaterialDetailsModel> lstGenerate)
        {
            string Query = string.Empty;
            bool isSaved = true;
            int ParentId = GetBillofMaterialId();
            foreach (BillsofMaterialDetailsModel objGenerate in lstGenerate)
            {
                try
                {
                    objGenerate.id = ParentId;

                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Generate_Id", ParentId));
                    paramCollection.Add(new DBParameter("@Generate_Item", objGenerate.ItemName));
                    paramCollection.Add(new DBParameter("@Generate_Qty", objGenerate.Qty));
                    paramCollection.Add(new DBParameter("@Generate_Unit", objGenerate.Unit));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    Query = "INSERT INTO bom_generate_details(`Bom_Id`,`ItemName`,`Qty`,`Unit`,`CreatedBy`)" +
                            "VALUES(@Generate_Id,@Generate_Item,@Generate_Qty,@Generate_Unit,@CreatedBy)";

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

        //List In Bills og Material

        public List<eSunSpeedDomain.BillofMaterialModel> GetAllBillofMaterial()
        {
            List<eSunSpeedDomain.BillofMaterialModel> lstBom = new List<BillofMaterialModel>();
            eSunSpeedDomain.BillofMaterialModel objBom;

            string Query = "SELECT * FROM `BillsofMaterial`";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {

                objBom = new BillofMaterialModel();

                objBom.BOMName = dr["BOMName"].ToString();
                objBom.Itemtoproduce= dr["Itemtoproduce"].ToString();
                objBom.Quantity = Convert.ToDecimal(dr["Quantity"]);
                objBom.ItemUnit = dr["ItemUnit"].ToString();
                objBom.Expenses = Convert.ToDecimal(dr["Expenses"]);
                objBom.SpecifyMCGenerated = Convert.ToBoolean(dr["SpecifyMCGenerated"]);
                objBom.SpecifyDefaultMCforItemConsumed = Convert.ToBoolean(dr["SpecifyDefaultMCforItemConsumed"]);

                lstBom.Add(objBom);

            }

            return lstBom;
        }
        //List Of BillofMaterial By Id
        public BillofMaterialModel GetAllBillofMaterialById(int id)
        {
            BillofMaterialModel objBom = new BillofMaterialModel();

            string Query = "SELECT * FROM `BillsofMaterial` WHERE Bom_Id="+id+"";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objBom.BOMName = dr["BOMName"].ToString();
                objBom.Itemtoproduce = dr["Itemtoproduce"].ToString();
                objBom.Quantity = Convert.ToDecimal(dr["Quantity"]);
                objBom.ItemUnit = dr["ItemUnit"].ToString();
                objBom.Expenses = Convert.ToDecimal(dr["Expenses"]);
                objBom.SpecifyMCGenerated = Convert.ToBoolean(dr["SpecifyMCGenerated"]);
                objBom.SpecifyDefaultMCforItemConsumed = Convert.ToBoolean(dr["SpecifyDefaultMCforItemConsumed"]);

            }
            return objBom;
        }

        //Search

        public List<eSunSpeedDomain.BillofMaterialModel> GetBOMbySearchCriteria(SearchCriteria obj)
        {
            //TODO: Required to finalize
            return null;
        }

        //Get Parent Id Need To Inscrt Grids
        public int GetBillofMaterialId()
        {
            string Query = "SELECT MAX(Bom_Id) FROM billsofmaterial";

            int id = Convert.ToInt32(_dbHelper.ExecuteScalar(Query));

            return id;
        }
    }
}
    
        




    