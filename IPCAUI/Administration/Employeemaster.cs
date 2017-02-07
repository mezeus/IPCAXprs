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
        EmployeeGroupBL objegrpbl = new EmployeeGroupBL();
        EmployeeMasterBL objempbl = new EmployeeMasterBL();
        public static int EmpMstId = 0;

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
            Administration.List.EmployeemasterList frmList = new Administration.List.EmployeemasterList();
            frmList.StartPosition = FormStartPosition.CenterScreen;

            frmList.ShowDialog();
            lblUpdate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            lblSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;

            tbxName.Focus();

            FillAccountInfo();
        }

        private void FillAccountInfo()
        {
            EmployeeMasterModel objemployees = objempbl.GetListofallEmployeesById(EmpMstId);

            //tbxName.Text=objemployees.EmployeeId]);
            //objemployees.EmployeeCode = Convert.ToInt32(dr["EmployeeCode"].ToString() == "" ? "0" : dr["EmployeeCode"]);
            tbxName.Text=objemployees.EmployeeName;
            tbxPrintname.Text=objemployees.PrintName;
            cbxGroupname.Text=objemployees.Group;
            tbxDesignation.Text=objemployees.Designation;
            tbxFname.Text=objemployees.FatherName;
            tbxSpousename.Text = objemployees.SpouseName;
            tbxAddress.Text = objemployees.Address;
            dtDob.Text = Convert.ToString(objemployees.DateofBirth);
            cbxGender.Text = objemployees.Gender;
            tbxMobileno.Text =Convert.ToString(objemployees.MobileNumber);
            tbxPhone.Text=Convert.ToString(objemployees.TelephoneNumber);
            tbxEmail.Text=objemployees.email;
            tbxITpan.Text= objemployees.ITpan;
            dtDoj.Text = Convert.ToString(objemployees.DateofJoining);
            tbxCurrentStatus.Text=objemployees.CurrentStatus;
            dtlwd.Text=Convert.ToString(objemployees.LastWorkingDate);
            tbxPfno.Text=objemployees.PFNo;
            tbxEsino.Text=objemployees.ESIInsurance;
            tbxBonusapplicable.Text=objemployees.BonusApplicable;
            tbxEmailQuery.Text= objemployees.EmailQuery;
            //objemployees.SMSQuery = dr["SMSQuery"].ToString();
            //objemployees.Contactperson = dr["ContactPerson"].ToString();
            //objemployees.Ward = dr["Ward"].ToString();
            //objemployees.LSTNo = dr["LSTNo."].ToString();
            //objemployees.CSTNo = dr["CSTNo"].ToString();
            //objemployees.TIN = dr["TIN"].ToString();
            //objemployees.LBTNo = dr["LBTNo"].ToString();
            //objemployees.ServiceTaxNo = dr["ServiceTaxNo"].ToString();
            //objemployees.IECode = dr["IECode"].ToString();
            //objemployees.DLNo1 = dr["DLNo"].ToString();
            //objemployees.ChequePrintName = dr["ChequePrintName"].ToString();
        }


        private void tbxSave_Click(object sender, EventArgs e)
        {
            if(tbxName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Name Can not Blank!");
            }
            EmployeeMasterModel objmodel = new EmployeeMasterModel();
            objmodel.EmployeeName = tbxName.Text.Trim();
            objmodel.PrintName = tbxPrintname.Text==""?String.Empty:tbxPrintname.Text.Trim();
            objmodel.EmployeeCode =Convert.ToInt32(tbxEmpCode.Text.Trim()==""?"0":tbxEmpCode.Text.Trim());
            objmodel.Group = cbxGroupname.SelectedItem.ToString();
            objmodel.Designation = tbxDesignation.Text == "" ? String.Empty : tbxDesignation.Text.Trim();
            objmodel.FatherName = tbxFname.Text.Trim() == "" ? String.Empty : tbxFname.Text.Trim();
            objmodel.SpouseName = tbxSpousename.Text.Trim() == "" ? String.Empty : tbxSpousename.Text.Trim();
            objmodel.Address = tbxAddress.Text.Trim() == "" ? String.Empty : tbxAddress.Text.Trim();
            objmodel.Address1 = tbxAddress1.Text.Trim() == "" ? String.Empty : tbxAddress1.Text.Trim();
            objmodel.Address2 = tbxAddress2.Text == "" ? String.Empty : tbxAddress2.Text.Trim();
            objmodel.Address3 = tbxAddress3.Text == "" ? String.Empty : tbxAddress3.Text.Trim();
            objmodel.DateofBirth =Convert.ToDateTime(dtDob.Text.Trim() == "" ? String.Empty : dtDob.Text.Trim());
            objmodel.Gender = cbxGender.Text.Trim();
            objmodel.MobileNumber =Convert.ToInt32(tbxMobileno.Text.Trim()==""?"0":tbxMobileno.Text.Trim());
            objmodel.TelephoneNumber =Convert.ToInt32(tbxPhone.Text.Trim()==""?"0":tbxPhone.Text.Trim());
            objmodel.email = tbxEmail.Text.Trim() == "" ? String.Empty : tbxEmail.Text.Trim();
            objmodel.ITpan = tbxITpan.Text.Trim() == "" ? String.Empty : tbxITpan.Text.Trim();
            objmodel.DateofJoining =Convert.ToDateTime(dtDoj.Text.Trim() == "" ? String.Empty : dtDoj.Text.Trim());
            objmodel.CurrentStatus = tbxCurrentStatus.Text == "" ? String.Empty : tbxCurrentStatus.Text.Trim();
            objmodel.LastWorkingDate =Convert.ToDateTime(dtlwd.Text.Trim() == "" ? String.Empty : dtlwd.Text.Trim());
            objmodel.PFNo = tbxPfno.Text == "" ? String.Empty : tbxPfno.Text.Trim();
            objmodel.ESIInsurance = tbxEsino.Text == "" ? String.Empty : tbxEsino.Text.Trim();
            objmodel.BonusApplicable = tbxBonusapplicable.Text.Trim() == "" ? String.Empty : tbxBonusapplicable.Text.Trim();
            objmodel.EmailQuery = tbxEmailQuery.Text == "" ? String.Empty : tbxEmailQuery.Text.Trim();
            objmodel.SMSQuery = tbxSMSQuery.Text == "" ? String.Empty : tbxSMSQuery.Text.Trim();
            objmodel.Contactperson = tbxContactPerson.Text == "" ? String.Empty : tbxContactPerson.Text.Trim();
            objmodel.Ward = tbxWard.Text.Trim() == "" ? String.Empty : tbxWard.Text.Trim();
            objmodel.LSTNo = tbxLstno.Text == "" ? String.Empty : tbxLstno.Text.Trim();
            objmodel.CSTNo = tbxCstno.Text == "" ? String.Empty : tbxCstno.Text.Trim();
            objmodel.TIN = tbxTin.Text == "" ? String.Empty : tbxTin.Text.Trim();
            objmodel.LBTNo = tbxlbtno.Text == "" ? String.Empty : tbxlbtno.Text.Trim();
            objmodel.ServiceTaxNo = tbxServicetax.Text == "" ? String.Empty : tbxServicetax.Text.Trim();
            objmodel.IECode = tbxIecode.Text == "" ? String.Empty : tbxIecode.Text.Trim();
            objmodel.DLNo1 = tbxDlno1.Text == "" ? String.Empty : tbxDlno1.Text.Trim();
            objmodel.ChequePrintName = tbxChequePrintName.Text == "" ? String.Empty : tbxChequePrintName.Text.Trim();

            bool issaved = objempbl.SaveEmployeeMaster(objmodel);
            if(issaved)
            {
                MessageBox.Show("Saved Succsuffly!");
            }

        }

        private void Employeemaster_Load(object sender, EventArgs e)
        {
            cbxGroupname.SelectedIndex = 0;
            cbxGender.SelectedIndex = 0;
            LodaGroups();
        }
        public void LodaGroups()
        {
            List<EmployeeGroupModel> objmodel = objegrpbl.GetListofEmployeeGroups();
            foreach (EmployeeGroupModel objgroup in objmodel)
            {
                cbxGroupname.Properties.Items.Add(objgroup.GroupName);
            }
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            tbxPrintname.Text = tbxName.Text.Trim();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
