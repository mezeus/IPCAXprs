
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
                paramCollection.Add(new DBParameter("@IGTotalQty", objBOM.IGTotalQty, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@ICTotalQty", objBOM.ICTotalQty, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));
                paramCollection.Add(new DBParameter("@CreatedDate",DateTime.Now,DbType.DateTime));
                paramCollection.Add(new DBParameter("@ModifiedBy", ""));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, DbType.DateTime));

                Query = "INSERT INTO billsofmaterial(`BomName`,`Itemtoproduce`,`Quantity`,`ItemUnit`,`Expenses`,`SpecifyMCGenerated`,`SpecifyDefaultMCforItemConsumed`,`AppMc`,`IGTotalQty`,`ICTotalQty`,`CreatedBy`,`CreatedDate`,`ModifiedBy`,`ModifiedDate`) " +
                    "VALUES(@BOMName,@Itemtoproduce,@Quantity,@ItemUnit,@Expenses,@SpecifyMCGenerated,@SpecifyDefaultMCforItemConsumed,@AppMc,@IGTotalQty,@ICTotalQty,@CreatedBy,@CreatedDate,@ModifiedBy,@ModifiedDate)";
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
        //Update Item Raw Material Consued
        public bool UpdateBillsofMaterialConsumed(List<BillsofMaterialDetailsModel> lstConsumed,int id)
        {
            string Query = string.Empty;
            bool isUpdate = true;
            foreach (BillsofMaterialDetailsModel objConsumed in lstConsumed)
            {             
                  objConsumed.ParentId = id;
                if(objConsumed.id>0)
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@BillsId", objConsumed.ParentId));
                    paramCollection.Add(new DBParameter("@Consumed_Id", objConsumed.id));
                    paramCollection.Add(new DBParameter("@Consumed_Item", objConsumed.ItemName));
                    paramCollection.Add(new DBParameter("@Consumed_Qty", objConsumed.Qty));
                    paramCollection.Add(new DBParameter("@Consumed_Unit", objConsumed.Unit));
                    paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));

                    Query = "UPDATE bom_consumed_details SET `ItemName`=@Consumed_Item," +
                            "`Qty`=@Consumed_Qty,`Unit`=@Consumed_Unit,`ModifiedBy`=@ModifiedBy " +
                            "WHERE `Bom_Id`=@BillsId AND `Consumed_Id`=@Consumed_Id";
                    if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                    {
                        isUpdate = true;
                    }
                }
                else
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@BillsId",objConsumed.ParentId));
                    paramCollection.Add(new DBParameter("@Consumed_Item", objConsumed.ItemName));
                    paramCollection.Add(new DBParameter("@Consumed_Qty", objConsumed.Qty));
                    paramCollection.Add(new DBParameter("@Consumed_Unit", objConsumed.Unit));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    Query = "INSERT INTO bom_consumed_details(`Bom_Id`,`ItemName`,`Qty`,`Unit`,`CreatedBy`)" +
                            "VALUES(@BillsId,@Consumed_Item,@Consumed_Qty,@Consumed_Unit,@CreatedBy)";

                    if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                        isUpdate = true;
                }   

            
            }
            return isUpdate;
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

        //Update Item Raw Material generated
        public bool UpdateBillsofMaterialGenerate(List<BillsofMaterialDetailsModel> lstGenerate, int id)
        {
            string Query = string.Empty;
            bool isUpdate = true;
            foreach (BillsofMaterialDetailsModel objGenerate in lstGenerate)
            {
                objGenerate.ParentId = id;
                if (objGenerate.id > 0)
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@BillsId", objGenerate.ParentId));
                    paramCollection.Add(new DBParameter("@Generate_Id", objGenerate.id));
                    paramCollection.Add(new DBParameter("@Generate_Item", objGenerate.ItemName));
                    paramCollection.Add(new DBParameter("@Generate_Qty", objGenerate.Qty));
                    paramCollection.Add(new DBParameter("@Generate_Unit", objGenerate.Unit));
                    paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));

                    Query = "UPDATE bom_generate_details SET `ItemName`=@Generate_Item," +
                            "`Qty`=@Generate_Qty,`Unit`=@Generate_Unit,`ModifiedBy`=@ModifiedBy " +
                            "WHERE `Bom_Id`=@BillsId AND `Generate_Id`=@Generate_Id";
                    if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                    {
                        isUpdate = true;
                    }
                }
                else
                {
                    DBParameterCollection paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@Parent_Id", objGenerate.ParentId));
                    paramCollection.Add(new DBParameter("@Generate_Item", objGenerate.ItemName));
                    paramCollection.Add(new DBParameter("@Generate_Qty", objGenerate.Qty));
                    paramCollection.Add(new DBParameter("@Generate_Unit", objGenerate.Unit));
                    paramCollection.Add(new DBParameter("@CreatedBy", "Admin"));

                    Query = "INSERT INTO bom_generate_details(`Bom_Id`,`ItemName`,`Qty`,`Unit`,`CreatedBy`)" +
                            "VALUES(@Parent_Id,@Generate_Item,@Generate_Qty,@Generate_Unit,@CreatedBy)";

                    if (_dbHelper.ExecuteNonQuery(Query, paramCollection) > 0)
                        isUpdate = true;
                }


            }
            return isUpdate;
        }
        //update bom
        public bool UpdateBOM(eSunSpeedDomain.BillofMaterialModel objBOM)
        {
            string Query = string.Empty;
            bool isUpdated = true;
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@BOMName", objBOM.BOMName));
                paramCollection.Add(new DBParameter("@Itemtoproduce", objBOM.Itemtoproduce));
                paramCollection.Add(new DBParameter("@Quantity", objBOM.Quantity, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@ItemUnit", objBOM.ItemUnit));
                paramCollection.Add(new DBParameter("@Expenses", objBOM.Expenses, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@SpecifyMCGenerated", objBOM.SpecifyMCGenerated, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@SpecifyDefaultMCforItemConsumed", objBOM.SpecifyDefaultMCforItemConsumed, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AppMc", objBOM.AppMc));
                paramCollection.Add(new DBParameter("@IGTotalQty", objBOM.IGTotalQty, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@ICTotalQty", objBOM.ICTotalQty, System.Data.DbType.Decimal));
                paramCollection.Add(new DBParameter("@CreatedBy", ""));
                paramCollection.Add(new DBParameter("@CreatedDate", DateTime.Now, DbType.DateTime));
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@ModifiedDate", DateTime.Now, DbType.DateTime));
                paramCollection.Add(new DBParameter("@BillsId",objBOM.id));

                System.Data.IDataReader dr =
                        _dbHelper.ExecuteDataReader("spUpdateBillsOfMaterial", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);
                UpdateBillsofMaterialConsumed(objBOM.MaterialConsumed, objBOM.id);
                UpdateBillsofMaterialGenerate(objBOM.MaterialGenerated, objBOM.id);
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
        //Delete Single BOM Details
        public bool DeleteBillsOfMaterial(int id)
        {
            bool isDelete = false;
            try
            {
                if (DeleteBoMConsumed(id))
                {
                    if(DeleteBomGenerate(id))
                    {
                        string Query = "DELETE FROM `billsofmaterial` WHERE `Bom_Id`=" + id;

                        if (_dbHelper.ExecuteNonQuery(Query) > 0)

                            isDelete = true;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                isDelete = false;
                throw ex;
            }
            return isDelete;
        }
        //Delete Raw Material Consumed details
        public bool DeleteBoMConsumed(int id)
        {
            bool isDelete = true;
            try
            {
                string Query = "DELETE  FROM `bom_consumed_details` WHERE `Bom_Id`=" + id;

                if (_dbHelper.ExecuteNonQuery(Query) > 0)
                    isDelete = true;
            }
            catch (Exception ex)
            {
                isDelete = false;
                throw ex;
            }
            return isDelete;
        }
        //Delete Raw Material Generate Details
        public bool DeleteBomGenerate(int id)
        {
            bool isDelete = true;
            try
            {
                string Query = "DELETE  FROM `bom_generate_details` WHERE `Bom_Id`=" + id;
                if (_dbHelper.ExecuteNonQuery(Query) > 0)
                    isDelete = true;
            }
            catch (Exception ex)
            {
                isDelete = false;
                throw ex;
            }
            return isDelete;
        }
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
                objBom.Bom_Id = Convert.ToInt32(dr["Bom_Id"].ToString());
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
                objBom.Bom_Id = Convert.ToInt32(dr["Bom_Id"].ToString());
                objBom.BOMName = dr["BOMName"].ToString();
                objBom.Itemtoproduce = dr["Itemtoproduce"].ToString();
                objBom.Quantity = Convert.ToDecimal(dr["Quantity"]);
                objBom.ItemUnit = dr["ItemUnit"].ToString();
                objBom.Expenses = Convert.ToDecimal(dr["Expenses"]);
                objBom.SpecifyMCGenerated = Convert.ToBoolean(dr["SpecifyMCGenerated"]);
                objBom.SpecifyDefaultMCforItemConsumed = Convert.ToBoolean(dr["SpecifyDefaultMCforItemConsumed"]);

                string QueryCon = "SELECT * FROM bom_consumed_details WHERE Bom_Id=" + id;
                System.Data.IDataReader drCon = _dbHelper.ExecuteDataReader(QueryCon, _dbHelper.GetConnObject());

                objBom.MaterialConsumed = new List<BillsofMaterialDetailsModel>();
                BillsofMaterialDetailsModel objMaterial;

                while (drCon.Read())
                {
                    objMaterial = new BillsofMaterialDetailsModel();
                    objMaterial.id = Convert.ToInt32(drCon["Consumed_Id"]);
                    objMaterial.ParentId = Convert.ToInt32(drCon["Bom_Id"]);
                    objMaterial.ItemName = drCon["ItemName"].ToString();
                    objMaterial.Qty = Convert.ToDecimal(drCon["Qty"]);
                    objMaterial.Unit = drCon["Unit"].ToString();

                    objBom.MaterialConsumed.Add(objMaterial);
                }

                string QueryGen = "SELECT * FROM bom_generate_details WHERE Bom_Id=" + id;
                System.Data.IDataReader drGen = _dbHelper.ExecuteDataReader(QueryGen, _dbHelper.GetConnObject());

                objBom.MaterialGenerated = new List<BillsofMaterialDetailsModel>();
                BillsofMaterialDetailsModel objMatGen;

                while (drGen.Read())
                {
                    objMatGen = new BillsofMaterialDetailsModel();
                    objMatGen.id = Convert.ToInt32(drGen["Generate_Id"]);
                    objMatGen.ParentId = Convert.ToInt32(drGen["Bom_Id"]);
                    objMatGen.ItemName = drGen["ItemName"].ToString();
                    objMatGen.Qty = Convert.ToDecimal(drGen["Qty"]);
                    objMatGen.Unit = drGen["Unit"].ToString();
                    objBom.MaterialGenerated.Add(objMatGen);
                }
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
        //Is ItemGroup Master Exist or Not
        public bool IsBOMExists(string BOMName)
        {
            StringBuilder _sbQuery = new StringBuilder();
            _sbQuery.AppendFormat("SELECT COUNT(*) FROM billsofmaterial WHERE BomName='{0}'", BOMName);
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(_sbQuery.ToString(), _dbHelper.GetConnObject());
            dr.Read();
            if (Convert.ToInt32(dr[0]) > 0)
                return true;
            else
                return false;

        }

    }
}
    
        




    