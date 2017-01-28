using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eSunSpeedDomain;
using IPCAUI;
using eSunSpeed.BusinessLogic;

namespace IPCAUI.Company
{
    public partial class OpenCompany : Form
    {
        CompanyBL objBL = new CompanyBL();
        DataTable dt = new DataTable();

        //XtraForm1 frmMainObj = null;

        public OpenCompany(XtraForm1 frmMain)
        {
            InitializeComponent();
          //  this.frmMainObj = frmMain;
        }

        private void OpenCompany_Load(object sender, EventArgs e)
        {
            SessionVariables.DBName = "ipcadb_0";
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(frmLogin))
                {
                    frm.Close();
                    break;
                }
            }

            CompanyGridFill();
        }

        public void CompanyGridFill()
        {
            try
            {
                List<CompanyModel> lstCompanies= objBL.GetAllCompany();

                dt.Columns.Add("SerialNo");
                dt.Columns.Add("Company");
                
                gdvCompanyMain.DataSource = dt;

                if (lstCompanies.Count>0)
                {
                    dt.Rows.Clear();

                    DataRow dr;

                    foreach (CompanyModel objCompany in lstCompanies)
                    {
                        dr = dt.NewRow();

                        dr["SerialNo"] = objCompany.CompanyId.ToString();
                        dr["Company"] = objCompany.Name;
                        
                        dt.Rows.Add(dr);
                    }

                    gdvCompanyMain.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                //formMDI.infoError.ErrorString = "SELCMPNY : 1" + ex.Message;

            }
        }

        private void gdvCompanyMain_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                System.Data.DataRowView dv= (DataRowView) gdvCompanyDetails.GetRow(gdvCompanyDetails.FocusedRowHandle);
                //  Author.AuthorId = lstAuthors.Author_Id;
                string compId=dv.Row["SerialNo"].ToString();

               SessionVariables.DBName = "dbipca_" + Convert.ToString(Convert.ToDecimal(compId));

                frmLogin frmLoginObj = new frmLogin();
                frmLogin.companyname = dv.Row["Company"].ToString();
                //frmLoginObj.CallFromSelectCompany(this);
                frmLoginObj.ShowDialog();

                
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(Menu.CompanyMenu))
                    {
                        form.Close();
                        break;
                    }
                }

                XtraForm1.MDIObj.MenuSettings(true);
                this.Close();
                //if (gdvCompanyDetails.CurrentRow.Index == e.RowIndex)
                //{

                //    SessionVariables.DBName = "dbipca" + Convert.ToString(Convert.ToDecimal(dgvSelectCompany.Rows[e.RowIndex].Cells["dgvtxtCompanyId"].Value.ToString()));
                //    CurrentDate();
                //    frmLogin frmLoginObj = new frmLogin();
                //    frmLoginObj.MdiParent = formMDI.MDIObj;
                //    frmLoginObj.CallFromSelectCompany(this);

                //}
            }
            catch (Exception ex)
            {
               // formMDI.infoError.ErrorString = "SELCMPNY : 5" + ex.Message;
            }
        }

        private void gdvCompanyDetails_DoubleClick(object sender, EventArgs e)
        {
            //System.Data.DataRowView dv = (DataRowView)gdvCompanyDetails.GetRow(gdvCompanyDetails.FocusedRowHandle);
            ////  Author.AuthorId = lstAuthors.Author_Id;
            //string compId = dv.Row["SerialNo"].ToString();

            //SessionVariables.DBName = "dbipca_" + Convert.ToString(Convert.ToDecimal(compId));
            //frmLogin frmLoginObj = new frmLogin(this.frmMainObj);
            //frmLoginObj.CallFromSelectCompany(this);
        }
    }
}
