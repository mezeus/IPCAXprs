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

namespace IPCAUI.Administration
{
    public partial class Employeemaster : Form
    {
        EmployeeMasterBL objempbl = new EmployeeMasterBL();
        public Employeemaster()
        {
            InitializeComponent();
        }

        private void tbxQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListEmployeemst_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Administration.List.EmployeegrpList frmList = new Administration.List.EmployeegrpList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
        }

        private void tbxSave_Click(object sender, EventArgs e)
        {
            if(tbxName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Name Can not Blank!");
            }
            EmployeeMasterModel objmodel = new EmployeeMasterModel();
            objmodel.EmployeeName = tbxName.Text.Trim();
            objmodel.PrintName = tbxPrintname.Text.Trim();
            objmodel.Group = cbxGroupname.SelectedItem.ToString();
            objmodel.Designation = tbxDesignation.Text.Trim();
            objmodel.FatherName = tbxFname.Text.Trim();
            objmodel.SpouseName = tbxSpousename.Text.Trim();
            objmodel.Address = tbxAddress.Text.Trim();
            objmodel.Address1 = tbxAddress1.Text.Trim();
            objmodel.Address2 = tbxAddress2.Text.Trim();
            objmodel.Address3 = tbxAddress3.Text.Trim();
            objmodel.DateofBirth =dtDob.Text.Trim();
            objmodel.Gender = cbxGender.Text.Trim();
            objmodel.MobileNumber = tbxMobileno.Text.Trim();
            objmodel.TelephoneNumber = tbxPhone.Text.Trim();
            objmodel.DateofJoining =dtDoj.Text.Trim();
            objmodel.CurrentStatus = tbxCurrentStatus.Text.Trim();
            objmodel.LastWorkingDate =dtlwd.Text.Trim();
            objmodel.PFNo = tbxPfno.Text.Trim();
            objmodel.ESIInsurance = tbxEsino.Text.Trim();
            objmodel.BonusApplicable = tbxBonusapplicable.Text.Trim();
            objmodel.EmailQuery = tbxEmailQuery.Text.Trim();
            objmodel.SMSQuery = tbxSMSQuery.Text.Trim();
            objmodel.Contactperson = tbxContactPerson.Text.Trim();
            objmodel.Ward = tbxWard.Text.Trim();
            objmodel.LSTNo = tbxLstno.Text.Trim();
            objmodel.CSTNo = tbxCstno.Text.Trim();
            objmodel.TIN = tbxTin.Text.Trim();
            objmodel.LBTNo = tbxlbtno.Text.Trim();
            objmodel.ServiceTaxNo = tbxServicetax.Text.Trim();
            objmodel.IECode = tbxIecode.Text.Trim();
            objmodel.DLNo1 = tbxDlno1.Text.Trim();
            objmodel.ChequePrintName = tbxChequePrintName.Text.Trim();

            bool issaved = objempbl.SaveEmployeeMaster(objmodel);
            if(issaved)
            {
                MessageBox.Show("Saved Succsuffly!");
            }

        }
    }
}
