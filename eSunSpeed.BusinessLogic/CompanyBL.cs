using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.DataAccess;
using eSunSpeed.BusinessLogic;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace eSunSpeed.BusinessLogic
{
    public class CompanyBL
    {
        CompanyModel objcommod = new CompanyModel();
        private DBHelper _dbHelper = new DBHelper();

        public List<CompanyModel> GetAllCompany()
        {

            List<CompanyModel> lstCompanies = new List<CompanyModel>();
            CompanyModel objModel;  
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                
                System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("select companyId,companyName from Company; ", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.Text);

                while(dr.Read())
                {
                    objModel = new CompanyModel();

                    objModel.CompanyId = Convert.ToInt32(dr[0]);
                    objModel.Name = dr[1].ToString();

                    lstCompanies.Add(objModel);
                }
               

            }
            catch (Exception ex)
            {              
                throw ex;
            }
            return lstCompanies;
        }

        public bool CheckIsCompanyExists(string companyName,decimal id)
        {
            string Query = string.Empty;
            bool isExists = true;

            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@companyName", companyName));
                paramCollection.Add(new DBParameter("@companyId", id));

                System.Data.IDataReader dr =
                    _dbHelper.ExecuteDataReader("spCompanyCheckExistence", _dbHelper.GetConnObject(), paramCollection, System.Data.CommandType.StoredProcedure);

                dr.Read();
                if (Convert.ToInt32(dr[0]) > 0)
                    isExists = true;
                else
                    isExists = false;
             
               }
            catch (Exception ex)
            {
                isExists = true;
                throw ex;
            }

            return isExists;
        }
        public int SaveCompany(CompanyModel objCompany)
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
                paramCollection.Add(new DBParameter("@FYBegining", objCompany.FYBegining, System.Data.DbType.DateTime));
                paramCollection.Add(new DBParameter("@BooksCommencing", objCompany.BooksCommencing, System.Data.DbType.DateTime));
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
                paramCollection.Add(new DBParameter("@EnableTaxSchg", objCompany.EnableTaxSchg ? 1 : 0,System.Data.DbType.Boolean));
                paramCollection.Add(new DBParameter("@TIN", objCompany.TIN));
                paramCollection.Add(new DBParameter("@CSTNo", objCompany.CSTNo));
                paramCollection.Add(new DBParameter("@CreatedBy", objCompany.CreatedBy));

                //Query = "INSERT INTO company (`Name`,`PrintName`,`ShortName`," +
                //    "`Country`,`State`,`FYBegining`,`Bookscommencing`,`Address`,`CIN`,`PAN`,`Ward`,`Telephone`,`Fax`,`Email`,`CurrencySymbol`,`CurrencyString`,`CurrencySubString`,`CurrencyFont`," +
                //    "`CurrencyCharacter`,`VAT`,`Type`,`EnableTaxSchg`,`TIN`,`CSTNo`,`CreatedBy`)" +
                //    "VALUES(@Name,@PrintName,@ShortName,@Country,@State,@FYBegining,@BooksCommencing,@Address,@CIN,@PAN,@Ward,@Telephone,@Fax,@Email,@CurrencySymbol,@CurrencyString,@CurrencySubString,@CurrencyFont,@CurrencyCharacter," +
                //    "@VAT,@Type,@EnableTaxSchg,@TIN,@CSTNo,@CreatedBy)";

                int companyId= Convert.ToInt32(_dbHelper.ExecuteScalar(SessionVariables.DBName.ToLower()+"."+"spCreateCompany", paramCollection, System.Data.CommandType.StoredProcedure));
                return companyId;
            }
            catch (Exception ex)
            {
                isSaved = false;
                throw ex;
            }            
        }

        public int CompanyAddForMain(MainCompanyInfo companyinfo)
        {
            int ina = 0;
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@S_companyName", companyinfo.CompanyName));                
                paramCollection.Add(new DBParameter("@S_isDefault", companyinfo.IsDefault?1:0,System.Data.DbType.Boolean));

                int companyId = Convert.ToInt32(_dbHelper.ExecuteScalar("CompanyAdd", paramCollection, System.Data.CommandType.StoredProcedure));
                return companyId;
                
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return ina;
        }
        public void CompanyPathAdd(CompanyPathInfo companypathinfo)
        {
            try
            {

                DBParameterCollection paramCollection = new DBParameterCollection();

                paramCollection.Add(new DBParameter("@companyName", companypathinfo.CompanyName));
                paramCollection.Add(new DBParameter("@companyPath", companypathinfo.CompanyPath));
                paramCollection.Add(new DBParameter("@isDefault", companypathinfo.IsDefault));
                paramCollection.Add(new DBParameter("@extra1", companypathinfo.Extra1));
                paramCollection.Add(new DBParameter("@extra2", companypathinfo.Extra2));
             
                _dbHelper.ExecuteNonQuery("spCompanyPathAdd", paramCollection, System.Data.CommandType.StoredProcedure);
                                             
            }
            catch (Exception ex)
            {
             
            }
            finally
            {
             
            }
        }

        /// <summary>
        /// Function for Create MySqlDatabase
        /// </summary>
        /// <param name="ServerName"></param>
        /// <param name="UserId"></param>
        /// <param name="Password"></param>
        /// <param name="DbName"></param>
        /// <returns></returns>
        public bool CreateMySqlDatabase(string ServerName, string UserId, string Password, string DbName)
        {
            bool isTrue = false;
            try
            {
                MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(string.Format("server={0};user id={1}; password={2};", ServerName, UserId, Password));
                connection.Open();
                MySql.Data.MySqlClient.MySqlCommand command1 = new MySql.Data.MySqlClient.MySqlCommand("CREATE DATABASE " + DbName + ";", connection);
                command1.ExecuteNonQuery();
                connection.Close();
                isTrue = true;
            }
            catch (Exception)
            {
                isTrue = false;
            }
            return isTrue;
        }
        /// <summary>
        /// Function for Restore the DataBase
        /// </summary>
        /// <param name="ServerName"></param>
        /// <param name="UserId"></param>
        /// <param name="Password"></param>
        /// <param name="DbName"></param>
        /// <param name="RestoreData"></param>
        /// <returns></returns>
        public bool DataBaseRestore(string ServerName, string UserId, string Password, string DbName, string RestoreData)
        {
            bool isTrue = false;
            try
            {

                ProcessStartInfo psi = new ProcessStartInfo();

                psi.FileName = System.Configuration.ConfigurationManager.AppSettings["MySqlUrl"] + "bin\\mysql.exe";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", UserId, Password, ServerName, DbName);
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(RestoreData);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
                isTrue = true;
            }
            catch (Exception)
            {

                isTrue = false;
            }
            return isTrue;

        }
    }
}


