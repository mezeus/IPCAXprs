using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eSunSpeed.BusinessLogic;
using eSunSpeedDomain;
using System.IO;
using System.Threading;
using System.Configuration;
using IPCAUI.Menu;
namespace IPCAUI.Company
{
    public partial class NewCompany : Form
    {
        CompanyBL objcombl = new CompanyBL();
        frmLoading f1 = null;
        string strPath;
        bool isExternalDrive = false;

        CompanyMenu _frmMenu = null;

        public NewCompany(CompanyMenu frmMenu)
        {
            InitializeComponent();
            this._frmMenu = frmMenu;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void threadStart()
        {
            IPCAUI.Company.frmWait obj = new frmWait();
            obj.ShowDialog();

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SessionVariables.DBName = "ipcadb_0";

            if (tbxname.Text.Equals(String.Empty))
            {
                MessageBox.Show(" Name Cannot be Blank !");
                return;
            }
            eSunSpeedDomain.CompanyModel objcommods = new eSunSpeedDomain.CompanyModel();
            objcommods.Name = tbxname.Text.Trim();
            objcommods.PrintName = tbxPrintName.Text.Trim();
            objcommods.ShortName = tbxshortname.Text;
            objcommods.Country = tbxcountry.Text;
            objcommods.State =tbxstate.Text;
            objcommods.FYBegining = Convert.ToDateTime(tbxfybeginningfrom.Text);
            objcommods.BooksCommencing = Convert.ToDateTime(tbxbookscommencingfrom.SelectedText.ToString());
            objcommods.Address = tbxaddress.Text;
            objcommods.CIN = tbxCIN.Text;
            objcommods.PAN = tbxITPan.Text;
            objcommods.Ward = tbxWard.Text;
            objcommods.Telephone = tbxTelNo.Text;
            objcommods.Fax = tbxFax.Text;
            objcommods.Email = tbxEmail.Text;
            objcommods.CurrencySymbol = tbxcurrencysymbol.Text;
            objcommods.CurrencyString = tbxcurrencystring.Text;
            objcommods.CurrencySubString = tbxcurrencysubstring.Text;
            objcommods.CurrencyFont = tbxcurrencyfont.Text;
            objcommods.CurrencyCharacter = tbxcurrencycharacter.Text;
            objcommods.VAT = tbxEnableVAT.Text;
            objcommods.Type = tbxtype.Text;
           objcommods.EnableTaxSchg = Convert.ToBoolean(tbxEnableAddTax.Text.ToString()=="Y"?true:false);
            objcommods.TIN = tbxTin.Text;
            objcommods.CSTNo = tbxCSTNO.Text;
            objcommods.CreatedBy = "Admin";

            string message = string.Empty;

            //Check for company existence in Main db
            if (objcombl.CheckIsCompanyExists(tbxname.Text.Trim(), 0))
            {
                MessageBox.Show("Company already exists! \n Please try with a different Name.");
                return;
            }
            else
            {
                Thread oThread = new Thread(new ThreadStart(threadStart));
                oThread.Start();

                MainCompanyInfo mainInfo = new MainCompanyInfo();
                mainInfo.CompanyName = tbxname.Text.Trim();
                mainInfo.IsDefault = true; // Currently hardcoded need to retrieve it from ui design

                int companyId = objcombl.CompanyAddForMain(mainInfo);

                SessionVariables.DBName = "DBIPCA_" + companyId.ToString();

                if (objcombl.CreateMySqlDatabase(ConfigurationManager.AppSettings["MySqlServer"].ToString(), ConfigurationManager.AppSettings["MySqlUserId"].ToString(), ConfigurationManager.AppSettings["MySqlPassword"].ToString(), SessionVariables.DBName))
                {
                    if (objcombl.DataBaseRestore(ConfigurationManager.AppSettings["MySqlServer"].ToString(), ConfigurationManager.AppSettings["MySqlUserId"].ToString(), ConfigurationManager.AppSettings["MySqlPassword"].ToString(), SessionVariables.DBName, global::IPCAUI.Properties.Resources.AllSql))
                    {

                        objcombl.SaveCompany(objcommods);

                        oThread.Abort();

                        CreateUser frmUser = new CreateUser();
                        frmUser.ShowDialog();

                        _frmMenu.Close();
                    }



                }
            }           
        }
     
        /// <summary>
        /// creates company 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                strPath = string.Empty;
                if (IPCAUI.Menu.CompanyMenu.DBConnectionType != "Single-User")
                {
                    isExternalDrive = false;
                    string strServer = File.ReadAllText(Application.StartupPath + "\\sys.txt");
                    if (File.Exists(strServer + "\\" + Application.StartupPath + "\\file.txt"))
                    {
                        strPath = File.ReadAllText(strServer + "\\" + Application.StartupPath + "\\file.txt");
                        if (strPath != null && strPath != string.Empty)
                        {
                            strPath = strServer + "\\" + strPath + "\\Data\\" + SessionVariables._decCurrentCompanyId;
                            isExternalDrive = true;
                        }
                    }
                    if (!isExternalDrive)
                    {
                        if (IPCAUI.Menu.CompanyMenu.isEstimateDB && IPCAUI.Menu.CompanyMenu.strEstimateCompanyPath != string.Empty)
                        {
                            strPath = IPCAUI.Menu.CompanyMenu.strEstimateCompanyPath + "\\Data\\" + SessionVariables._decCurrentCompanyId;
                        }
                        else
                        {
                            strPath = Application.StartupPath + "\\Data\\" + SessionVariables._decCurrentCompanyId;
                        }
                    }
                }
                DirectoryInfo infoDirectory = new DirectoryInfo(strPath);
                if (!infoDirectory.Exists)
                {
                    infoDirectory.Create();
                }
                //Copying empty database to new created directory
                string strSourcePath = Application.StartupPath + "\\Data\\" + "COMP";
                string strTargetPath = Application.StartupPath + "\\Data\\" + SessionVariables._decCurrentCompanyId;
                File.Copy(strSourcePath + "\\DBIPCA.mdf", strTargetPath + "\\DBIPCA.mdf");
                File.Copy(strSourcePath + "\\DBIPCA_log.ldf", strTargetPath + "\\DBIPCA_log.ldf");
                strPath = Application.StartupPath + "\\Data\\" + SessionVariables._decCurrentCompanyId;
                FileInfo SourceMDFinfo = new FileInfo(strPath + "\\DBIPCA.mdf");
                FileInfo SourceLDFinfo = new FileInfo(strPath + "\\DBIPCA_log.ldf");
            }
            catch (Exception ex)
            {
                MessageBox.Show("CR26" + ex.Message, "IPCA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On completion of background worker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                f1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CR27" + ex.Message, "IPCA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Create database for new company
        /// </summary>
        /// <returns></returns>
        public bool CreateCompany()
        {
            try
            {
                backgroundWorker1.RunWorkerAsync();
                f1 = new frmLoading();
                f1.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("CR10:" + ex.Message, "IPCA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return true;
        }
        private void NewCompany_Load(object sender, EventArgs e)
        {
            tbxcountry.SelectedIndex = 0;
            tbxstate.SelectedIndex = 0;
            tbxEnableVAT.SelectedIndex = 0;
            tbxtype.SelectedIndex = 0;
            tbxEnableAddTax.SelectedIndex = 0;
            tbxCaption.SelectedIndex = 0;                
        }
    }
}
