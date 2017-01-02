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
    public partial class NewCompany : Form
    {
        CompanyBL objcombl = new CompanyBL();

        public NewCompany()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
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


            bool isSuccess = objcombl.SaveCompany(objcommods);
            {
                if (isSuccess)
                    MessageBox.Show("Saved Successfully!");
            }

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
