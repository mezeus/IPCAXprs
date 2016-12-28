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
using System.Xml.Linq;

namespace IPCAUI.Company
{
    public partial class Companycreate : Form
    {
        CompanyBL objcombl = new CompanyBL();

        public Companycreate()
        {
            InitializeComponent();
        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void labelControl12_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxName.Text.Equals(String.Empty))
            {
                MessageBox.Show("Company Name Is Blank !");
                return;
            }
            eSunSpeedDomain.CompanyModel objcommods = new eSunSpeedDomain.CompanyModel();
            objcommods.Name = tbxName.Text.Trim();
            objcommods.PrintName = tbxprintname.Text.Trim();
            objcommods.ShortName = tbxshortname.Text;
            objcommods.Country = cbxcountry.SelectedItem.ToString();
            objcommods.State = tbxstate.Text;
            objcommods.FYBegining = Convert.ToDateTime(defybeginingform.SelectedText.ToString());
            objcommods.BooksCommencing = Convert.ToDateTime(debokscommincingfrom.SelectedText.ToString());
            objcommods.Address = tbxaddress.Text;
            objcommods.CIN = tbxcin.Text;
            objcommods.PAN = tbxitpan.Text;
            objcommods.Ward = tbxward.Text;
            objcommods.Telephone = tbxtelno.Text;
            objcommods.Fax = tbxfax.Text;
            objcommods.Email = tbxemail.Text;
            objcommods.CurrencySymbol = tbxcurrencysymbol.Text;
            objcommods.CurrencyString = tbxcurrencystring.Text;
            objcommods.CurrencySubString = tbxcurrencysubstring.Text;
            objcommods.CurrencyFont = tbxcurrencyfont.Text;
            objcommods.CurrencyCharacter = tbxcurrencycharater.Text;
            objcommods.VAT = cbxenablevat.SelectedItem.ToString();
            objcommods.Type = cbxtype.SelectedItem.ToString();
            objcommods.EnableTaxSchg = Convert.ToBoolean(cbxenabletaxschg.SelectedItem.ToString());
            objcommods.TIN = tbxtin.Text;
            objcommods.CSTNo = tbxcstno.Text;
            objcommods.CreatedBy = "Admin";



            string message = string.Empty;


            bool isSuccess = objcombl.SaveCompany(objcommods);
            {
                if (isSuccess)
                    MessageBox.Show("Saved Successfully!");
            }


        }
    }

    //private void groupControl2_Paint(object sender, PaintEventArgs e)
    //{
    //}
}


//        private void btnSave_Click(object sender, EventArgs e)
//        {
//            if(XName.Text.Equals(String.Empty))
//            {
//                MessageBox.Show("Company Name Is Blank !");
//                return;
//            }
//            eSunSpeedDomain.CompanyModel objcommods = new eSunSpeedDomain.CompanyModel();
//            objcommods.Name = tbxName.Text.Trim();
//            objcommods.PrintName = tbxprintname.Text.Trim();
//            objcommods.ShortName = tbxshortname.Text;
//            objcommods.Country = cbxcountry.SelectedItem.ToString(); 
//            objcommods.State = tbxstate.Text;
//            objcommods.FYBegining = Convert.ToDateTime(defybeginingform.SelectedText.ToString());
//            objcommods.BooksCommencing = Convert.ToDateTime(debokscommincingfrom.SelectedText.ToString());
//            objcommods.Address = tbxaddress.Text;
//            objcommods.CIN = tbxcin.Text;
//            objcommods.PAN = tbxitpan.Text;
//            objcommods.Ward = tbxward.Text;
//            objcommods.Telephone= tbxtelno.Text;
//            objcommods.Fax = tbxfax.Text;
//            objcommods.Email = tbxemail.Text;
//            objcommods.CurrencySymbol= tbxcurrencysymbol.Text;
//            objcommods.CurrencyString = tbxcurrencystring.Text;
//            objcommods.CurrencySubString = tbxcurrencysubstring.Text;
//            objcommods.CurrencyFont = tbxcurrencyfont.Text; 
//            objcommods.CurrencyCharacter= tbxcurrencycharater.Text;
//            objcommods.VAT = cbxenablevat.SelectedItem.ToString();
//            objcommods.Type = cbxtype.SelectedItem.ToString(); 
//            objcommods.EnableTaxSchg =Convert.ToBoolean(cbxenabletaxschg.SelectedItem.ToString());
//            objcommods.TIN = tbxtin.Text;
//            objcommods.CSTNo = tbxcstno.Text;



//            string message = string.Empty;


//            bool isSuccess = objcombl.SaveCompany(objcommods);
//            {
//                if (isSuccess)
//                    MessageBox.Show("Saved Successfully!");
//            }

//        }

//        private void Companycreate_KeyDown(object sender, KeyEventArgs e)
//        {
//            if (e.KeyCode == Keys.Enter)
//            {
//                this.SelectNextControl(this.ActiveControl, true, true, true, true);
//            }
//        }

//        private void textEdit1_EditValueChanged(object sender, EventArgs e)
//        {

//        }
//    }
//}
//}
