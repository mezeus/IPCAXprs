using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;
using eSunSpeed.BusinessLogic;



namespace eSunSpeed.BusinessLogic
{
    public class CompanyBL
    {
        CompanyModel objcommod = new CompanyModel();
        private DBHelper _dbHelper = new DBHelper();

        public int GetDiscountStructId()
        {
            string Query = "SELECT MAX(DS_Id) FROM CompanyBL";

            int id = Convert.ToInt32(_dbHelper.ExecuteScalar(Query));

            return id;
        }

        public bool SaveCompany(CompanyModel objCompany)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@Name", objCompany.Name));
                paramCollection.Add(new DBParameter("@PrintName", objCompany.PrintName));
                paramCollection.Add(new DBParameter("@ShortName", objCompany.ShortName));
                paramCollection.Add(new DBParameter("@Country", objCompany.Country));
                paramCollection.Add(new DBParameter("@State", objCompany.State));
                paramCollection.Add(new DBParameter("@FYBeginning", objCompany.FYBegining));
                paramCollection.Add(new DBParameter("@BooksCommencing", objCompany.BooksCommencing));
                paramCollection.Add(new DBParameter("@Address", objCompany.Address));
                paramCollection.Add(new DBParameter("@CIN", objCompany.CIN));
                paramCollection.Add(new DBParameter("@PAN", objCompany.PAN));
                paramCollection.Add(new DBParameter("@Ward", objCompany.Ward));
                paramCollection.Add(new DBParameter("@Telephone", objCompany.Telephone));
                paramCollection.Add(new DBParameter("@Fax", objCompany.Fax));
                paramCollection.Add(new DBParameter("@Email", objCompany.Email));
                paramCollection.Add(new DBParameter("@CurrencySymbol", objCompany.CurrencySymbol));
                paramCollection.Add(new DBParameter("@CurrencyString", objCompany.CurrencyString));
                paramCollection.Add(new DBParameter("@CurrencySubString", objCompany.CurrencySubString));
                paramCollection.Add(new DBParameter("@CurrencyFont", objCompany.CurrencyFont));
                paramCollection.Add(new DBParameter("@CurrencyCharacter", objCompany.CurrencyCharacter));
                paramCollection.Add(new DBParameter("@VAT", objCompany.VAT));
                paramCollection.Add(new DBParameter("@Type", objCompany.Type));
                paramCollection.Add(new DBParameter("@EnableTaxSchg", objCompany.EnableTaxSchg ? 1 : 0));
                paramCollection.Add(new DBParameter("@TIN", objCompany.TIN));
                paramCollection.Add(new DBParameter("@CSTNo", objCompany.CSTNo));
                paramCollection.Add(new DBParameter("@CreatedBy", objCompany.CreatedBy));

                Query = "INSERT INTO company (`Name`,`PrintName`,`ShortName`," +
                    "`Country`,`State`,`FYBeginning`,`Bookscommencing`,`Address`,`CIN`,`PAN`,`Ward`,`Telephone`,`Fax`,`Email`,`CurrencySymbol`,`CurrencyString`,`CurrencySubString`,`CurrencyFont`," +
                    "`CurrencyCharacter`,`VAT`,`Type`,`EnableTaxSchg`,`TIN`,`CSTNo`,`CreatedBy "+
                    "VALUES(@Name,@PrintName,@ShortName,@Country,@State,@FYBeginning,@BooksCommencing,@Address,@CIN,@PAN,@Ward,@Telephone,@Fax,@Email,@CurrencySymbol,@CurrencyString,@CurrencySubString,@CurrencyFont,@CurrencyCharacter," +
                    "@VAT,@Type,@EnableTaxSchg,@TIN,@CSTNo,@CreatedBy)";

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

        public bool SaveAccountPosting(DSAccountPosting objDSPosting)
        {
            string Query = string.Empty;
            bool isSaved = true;

            try
            {

                objDSPosting.DS_Id = GetDiscountStructId();

                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@DS_Id", objDSPosting.DS_Id));
                paramCollection.Add(new DBParameter("@AccountPosting", objDSPosting.AccountPost, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@AccountHeadPost", objDSPosting.AccountHeadPost));
                paramCollection.Add(new DBParameter("@AffectsGoods", objDSPosting.AffectsGoods, System.Data.DbType.Boolean));                
                paramCollection.Add(new DBParameter("@CreatedBy", objDSPosting.CreatedBy));

                Query = "INSERT INTO DS_AccountPosting ([DS_Id],[AccountPosting],[AccountHeadPost]," +
                    "[AffectsGoods],[CreatedBy]) " +
                    "VALUES(@DS_Id,@AccountPosting,@AccountHeadPost,@AffectsGoods," +                   
                    "@CreatedBy)";

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

        //update
        public bool UpdateStructure(DiscountStructureMasterModel objDS)
        {
            string Query = string.Empty;
            bool isUpdate = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@StructureName", objDS.StructureName));
                paramCollection.Add(new DBParameter("@SimpleDiscount", objDS.SimpleDiscount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@CD_withSameNature", objDS.CompoundDiscountwithSameNature, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@CD_DifferentNature", objDS.CompoundDiscountDifferentNature, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@NoOfDiscounts", objDS.NoOfDiscounts));
                paramCollection.Add(new DBParameter("@SpecifyCaptionForDiscount", objDS.SpecifyCaptionForDiscount));
                paramCollection.Add(new DBParameter("@AbsoluteAmount", objDS.AbsoluteDiscount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@PerMainQty", objDS.PerMainQty, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@Percentage", objDS.Percentage, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@PerAltQty", objDS.PerAltQty, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ItemPrice", objDS.ItemPrice, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ItemMRP", objDS.ItemMRP, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ItemAmount", objDS.ItemAmount, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ItemListPrice", objDS.ItemListPrice, System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@ModifiedBy", "Admin"));
                paramCollection.Add(new DBParameter("@DS_Id", objDS.Ds_id));



                Query = "UPDATE DiscountStructure SET [SimpleDiscount]=@SimpleDiscount,[CD_withSameNature]=@CompoundDiscountwithSameNature,[CD_DifferentNature]=@CompoundDiscountDifferentNature,[NoOfDiscounts]=@NoOfDiscounts,[SpecifyCaptionForDiscount]=@SpecifyCaptionForDiscount,[AbsoluteAmount]=@AbsoluteAmount," +
                                   "[PerMainQty]=@PerMainQty,[Percentage]=@Percentage,[PerAltQty]=@PerAltQty,[ItemPrice]=@ItemPrice," +
                                   "[ItemMRP]=@ItemMRP,[ItemAmount]=@ItemAmount,[ItemListPrice]=@ItemListPrice,[ModifiedBy]=@ModifiedBy " +
                                   "WHERE DS_Id=@DS_Id";

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

        //List

        public List<DiscountStructureMasterModel> GetAllDiscountStructure()
        {
            List<eSunSpeedDomain.DiscountStructureMasterModel> lstDS = new List<DiscountStructureMasterModel>();
            eSunSpeedDomain.DiscountStructureMasterModel objDS;

            string Query = "SELECT * FROM DiscountStructure";
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {

                objDS = new DiscountStructureMasterModel();

                objDS.Ds_id = Convert.ToInt32(dr["DS_Id"]);
                objDS.StructureName = dr["StructureName"].ToString();
                objDS.SimpleDiscount = Convert.ToBoolean(dr["SimpleDiscount"]);
                objDS.CompoundDiscountwithSameNature = Convert.ToBoolean(dr["CD_withSameNature"]);
                objDS.CompoundDiscountDifferentNature = Convert.ToBoolean(dr["CD_DifferentNature"]);
                objDS.NoOfDiscounts = dr["NoOfDiscounts"]==null|| dr["NoOfDiscounts"].ToString()=="" ? 0:Convert.ToInt32(dr["NoOfDiscounts"]);
                objDS.SpecifyCaptionForDiscount = dr["SpecifyCaptionForDiscount"].ToString();
                objDS.AbsoluteDiscount = Convert.ToBoolean(dr["AbsoluteAmount"]);
                objDS.PerMainQty = Convert.ToBoolean(dr["PerMainQty"]);
                objDS.Percentage = Convert.ToBoolean(dr["Percentage"]);
                objDS.PerAltQty = Convert.ToBoolean(dr["PerAltQty"]);
                objDS.ItemPrice = Convert.ToBoolean(dr["ItemPrice"]);
                objDS.ItemMRP = Convert.ToBoolean(dr["ItemMRP"]);
                objDS.ItemAmount = Convert.ToBoolean(dr["ItemAmount"]);
                objDS.ItemListPrice = Convert.ToBoolean(dr["ItemListPrice"]);
                
                lstDS.Add(objDS);
                
            }

            return lstDS;
        }

        public DiscountStructureMasterModel GetDiscountStructureByDSId(int dsid)
        {
            List<eSunSpeedDomain.DiscountStructureMasterModel> lstDS = new List<DiscountStructureMasterModel>();
            eSunSpeedDomain.DiscountStructureMasterModel objDS;

            string Query = "SELECT * FROM DiscountStructure WHERE DS_ID=" + dsid;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            dr.Read();

            objDS = new DiscountStructureMasterModel();

            objDS.Ds_id = Convert.ToInt32(dr["DS_Id"]);
            objDS.StructureName = dr["StructureName"].ToString();
            objDS.SimpleDiscount = Convert.ToBoolean(dr["SimpleDiscount"]);
            objDS.CompoundDiscountwithSameNature = Convert.ToBoolean(dr["CD_withSameNature"]);
            objDS.CompoundDiscountDifferentNature = Convert.ToBoolean(dr["CD_DifferentNature"]);
            objDS.NoOfDiscounts = dr["NoOfDiscounts"] == null || dr["NoOfDiscounts"].ToString() == "" ? 0 : Convert.ToInt32(dr["NoOfDiscounts"]);
            objDS.SpecifyCaptionForDiscount = dr["SpecifyCaptionForDiscount"].ToString();
            objDS.AbsoluteDiscount = Convert.ToBoolean(dr["AbsoluteAmount"]);
            objDS.PerMainQty = Convert.ToBoolean(dr["PerMainQty"]);
            objDS.Percentage = Convert.ToBoolean(dr["Percentage"]);
            objDS.PerAltQty = Convert.ToBoolean(dr["PerAltQty"]);
            objDS.ItemPrice = Convert.ToBoolean(dr["ItemPrice"]);
            objDS.ItemMRP = Convert.ToBoolean(dr["ItemMRP"]);
            objDS.ItemAmount = Convert.ToBoolean(dr["ItemAmount"]);
            objDS.ItemListPrice = Convert.ToBoolean(dr["ItemListPrice"]);
            
            return objDS;
        }

        public List<DSAccountPosting> GetAccountPostingDetails()
        {
            List<DSAccountPosting> lstDS = new List<DSAccountPosting>();
            DSAccountPosting objDS;

            int DS_Id = GetDiscountStructId();
            
            string Query = string.Format("SELECT * FROM DS_AccountPosting WHERE DS_Id={0}",DS_Id)  ;
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {

                objDS = new DSAccountPosting();

                objDS.AccPost_Id = Convert.ToInt32(dr["AccPost_Id"]);
                objDS.DS_Id = Convert.ToInt32(dr["DS_Id"]);
                objDS.AccountHeadPost =dr["AccountHeadPost"].ToString();
                objDS.AffectsGoods= Convert.ToBoolean(dr["AffectsGoods"]);
                objDS.AccountPost = Convert.ToBoolean(dr["AccountPosting"]);

                lstDS.Add(objDS);

            }

            return lstDS;
        }

        public List<DSAccountPosting> GetAccountPostingDetailsbyDSId(int dsid)
        {

            List<DSAccountPosting> lstjDS = new List<DSAccountPosting>();
            DSAccountPosting objDS;

            string Query = string.Format("SELECT * FROM DS_AccountPosting WHERE DS_Id={0}", dsid);
            System.Data.IDataReader dr = _dbHelper.ExecuteDataReader(Query, _dbHelper.GetConnObject());

            while (dr.Read())
            {
                objDS = new DSAccountPosting();

                objDS.AccPost_Id = Convert.ToInt32(dr["AccPost_Id"]);
                objDS.DS_Id = Convert.ToInt32(dr["DS_Id"]);
                objDS.AccountHeadPost = dr["AccountHeadPost"].ToString();
                objDS.AffectsGoods = Convert.ToBoolean(dr["AffectsGoods"]);
                objDS.AccountPost = Convert.ToBoolean(dr["AccountPosting"]);

                lstjDS.Add(objDS);
            }
            return lstjDS;
        }
        public bool DeleteDiscount(List<int> Discountid)
        {
            string Query = string.Empty;
            bool isUpdated = true;

            try
            {
                DBParameterCollection paramCollection;

                foreach (int dsid in Discountid)
                {
                    paramCollection = new DBParameterCollection();

                    paramCollection.Add(new DBParameter("@dsid", dsid));
                    Query = "Delete from DiscountStructure WHERE [DS_Id]=@dsid";

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
    }
}


