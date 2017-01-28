using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using eSunSpeedDomain;
using eSunSpeed.BusinessLogic;
using System.Windows.Forms;
namespace IPCAUI.Company
{
    public partial class frmLogin : Form
    {
        #region PublicVariables
        OpenCompany frmSelectCompanyObj = null;
        //XtraForm1 formMdiObj = null;
        UsersBL objBL = new UsersBL();
        public static string companyname = string.Empty;   
 
        #endregion
        #region Function
        /// <summary>
        /// Creates an instance of a frmLogin class.
        /// </summary>
        public frmLogin()
        {
            InitializeComponent();
          //  this.formMdiObj = frmMain;
        }

        /// <summary>
        /// Function to call from 'Select Company' form, To show Login form and close Select Company form
        /// </summary>
        /// <param name="frmSelectCompanyObj"></param>
        public void CallFromSelectCompany(OpenCompany frmSelectCompanyObj)
        {
            try
            {
                base.ShowDialog();
                               
                //this.frmSelectCompanyObj = frmSelectCompanyObj;
                //frmSelectCompanyObj.Close();
            }
            catch (Exception ex)
            {
               // formMDI.infoError.ErrorString = "LOGIN03:" + ex.Message;
            }
        }

        #endregion
        #region Events
        /// <summary>
        /// On Label lblUserName Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblUserName_Click(object sender, EventArgs e)
        {
            try
            {

                txtUserName.Focus();
            }
            catch (Exception ex)
            {
               // formMDI.infoError.ErrorString = "LOGIN14:" + ex.Message;
            }

        }
        /// <summary>
        /// On Label lblPassword Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblPassword_Click(object sender, EventArgs e)
        {
            try
            {
                txtPassword.Focus();
            }
            catch (Exception ex)
            {
               // formMDI.infoError.ErrorString = "LOGIN15:" + ex.Message;
            }
        }
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                lbldatabase.Text = companyname;
                // Clear();
            }
            catch (Exception ex)
            {
                //formMDI.infoError.ErrorString = "LOGIN06:" + ex.Message;
            }
        }
        /// <summary>
        /// On 'Login' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
               Login();

              // base.Close();
            }
            catch (Exception ex)
            {
               // formMDI.infoError.ErrorString = "LOGIN07:" + ex.Message;
            }
        }

        public void Login()
        {
            try
            {

                UserInfoModel objModel = objBL.CheckUserLogin(txtUserName.Text.Trim(), txtPassword.Text.Trim());

                if (objModel.UserId == 0)
                {
                    MessageBox.Show("User does not exists!\n Please try again.");
                    return;
                }

                if (!objModel.Password.Equals(txtPassword.Text.Trim()))
                {
                    MessageBox.Show("Password is not correct!\n Please try again.");
                    return;
                }

                SessionVariables._decCurrencyId = objModel.UserId;
                base.Close();

               // SessionVariables.DBName = "dbipca_" + objModel.UserId;
                
                //TODO: Read Settings, Menu'S ETC               
            }
            catch(Exception ex)
            {

            }
        }
        /// <summary>
        /// On 'Reset' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                //Clear();
            }
            catch (Exception ex)
            {
                //formMDI.infoError.ErrorString = "LOGIN08:" + ex.Message;
            }
        }
        /// <summary>
        /// On 'Close' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFrmClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
               // formMDI.infoError.ErrorString = "LOGIN09:" + ex.Message;
            }
        }
        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    if (SessionVariables.isMessageClose)
                    {
                        this.Close();
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
               // formMDI.infoError.ErrorString = "LOGIN10:" + ex.Message;
            }
        }
        #endregion
        #region Navigation
        /// <summary>
        /// On Keydown, For navigating to Password textbox using Enter key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                lblError.Visible = false;
                if (e.KeyCode == Keys.Enter)
                {
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                //formMDI.infoError.ErrorString = "LOGIN11:" + ex.Message;
            }
        }
        /// <summary>
        /// On Keydown, For navigating to Login button/Username textbox using Enter/Backspace keys
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                lblError.Visible = false;
                if (e.KeyCode == Keys.Enter)
                {
                    btnLogin.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtPassword.Text == string.Empty || txtPassword.SelectionStart == 0)
                    {
                        txtUserName.SelectionStart = 0;
                        txtUserName.SelectionLength = 0;
                        txtUserName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
              //  formMDI.infoError.ErrorString = "LOGIN12:" + ex.Message;
            }
        }
        /// <summary>
        /// Backspace navigation of btnLogin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
              //  formMDI.infoError.ErrorString = "LOGIN13:" + ex.Message;
            }
        }
        #endregion

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
