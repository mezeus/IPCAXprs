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
namespace IPCAUI.Company
{
    public partial class CreateUser : Form
    {
        UsersBL objBL = new UsersBL();
        public CreateUser()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UserInfoModel objModel = new UserInfoModel();

            if (!tbxPassword.Text.Trim().Equals(tbxRetypePassword.Text.Trim()))
            {
                MessageBox.Show("Password and Re-Type password do not match! \n Please try again. \n Thank you.");
                return;
            }
            objModel.UserName = tbxUserName.Text.Trim();
            objModel.Password = tbxPassword.Text.Trim();
            objModel.Active = true;
            objModel.Extra1 = string.Empty;
            objModel.Extra2 = string.Empty;
            objModel.Narration = string.Empty;
            objModel.RoleId = 1;

          if( objBL.UserAdd(objModel))
            {               
                MessageBox.Show("User created sucessfully!");
                this.Close();
                XtraForm1.MDIObj.MenuSettings(true);
            }
        }
    }
}
