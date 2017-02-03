using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace IPCAUI.Menu
{
    public partial class MastersMenu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        XtraForm1 frm;
        public static string Form = string.Empty;
        
        public MastersMenu(XtraForm1 frm)
        {
            InitializeComponent();
            this.frm = frm;
        }
        public void LoadForms(string name)
        {
            string selectedPage = name;

            switch (selectedPage)
            {
                case "Unit Master":
                    Administration.Unitmaster frm;
                    frm = new Administration.Unitmaster(); //generate new instance 
                    frm.Owner = this;
                    frm.TopLevel = false;

                    sptCtrlMastermenu.Panel2.Controls.Add(frm);
                    frm.Show();
                    break;
                //case "Reports":
                //    this.Hide();
                //    IPCAUI.Menu.ReportMenu frmReport = new IPCAUI.Menu.ReportMenu(this);
                //    frmReport.Show();
                //    break;
                //case "Transactions":
                //    this.Hide();
                //    IPCAUI.Menu.TransactionsMenu frmTransMenu = new IPCAUI.Menu.TransactionsMenu(this);
                //    frmTransMenu.Show();
                //    break;
                //case "Master":
                //    this.Hide();
                //    IPCAUI.Menu.MastersMenu frmMasterMenu = new IPCAUI.Menu.MastersMenu(this);
                //    frmMasterMenu.Show();
                //    break;
                //case "Configuration":
                //    this.Hide();
                //    IPCAUI.Menu.ConfigurationMenu frmConfigMenu = new IPCAUI.Menu.ConfigurationMenu(this);
                //    frmConfigMenu.Show();
                //    break;
                //case "Merged Accounts":
                //    break;
                //case "Single Column":
                //    break;
                //case "Multiple Column":
                //    break;
                //case "Bank Book(As per Clr.Date)":
                //    break;
                default:
                    break;
            }
        }

        //May be useful for future use
        //private void ShowForm<T>(T form) where T : Form, new()
        //{
        //    if (form == null || form.IsDisposed)
        //    {
        //        form = new T();

        //        form.Owner = this;
        //        form.TopLevel = false;

        //        sptCtrlMastermenu.Panel2.Controls.Add(form);
        //        form.Show();

        //        //form.MdiParent = this;
        //        //form.Show();
        //        //form.WindowState = FormWindowState.Maximized;
        //    }
        //    else
        //    {
        //        form.Activate();
        //    }
        //}

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
       {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }

            if (keyData == Keys.F3)
            {

                string name = Administration.ItemMasterNew.FormName;
                if (name != "")
                {
                    Form form = (Form)Activator.CreateInstance(Type.GetType(name));                
                    form.Owner = this;
                    form.TopLevel = false;

                    sptCtrlMastermenu.Panel2.Controls.Add(form);
                    form.Show();                    
                }
                string SaleType = Administration.SaleType.FormName;
                if(SaleType != "")
                {
                    Form form = (Form)Activator.CreateInstance(Type.GetType(SaleType));
                    form.Owner = this;
                    form.TopLevel = false;

                    sptCtrlMastermenu.Panel2.Controls.Add(form);
                    form.Show();
                }
                //string name = Administration.ItemMasterNew.FormName;
                //switch(name)
                //{
                //    case "ItemGroup":
                //        Administration.Itemgroup frmItem;
                //        frmItem = new Administration.Itemgroup(); //generate new instance 

                //        frmItem.Owner = this;
                //        frmItem.TopLevel = false;

                //        sptCtrlMastermenu.Panel2.Controls.Add(frmItem);
                //        frmItem.Show();
                //        break;
                //    case "UnitMaster":
                //        Administration.Unitmaster frmUnitMaster;
                //        frmUnitMaster = new Administration.Unitmaster(); //generate new instance 

                //        frmUnitMaster.Owner = this;
                //        frmUnitMaster.TopLevel = false;

                //        sptCtrlMastermenu.Panel2.Controls.Add(frmUnitMaster);
                //        frmUnitMaster.Show();
                //        break;
                //    case "TaxCategory":
                //        Administration.Taxcategory frmTaxCat;
                //        frmTaxCat = new Administration.Taxcategory(); //generate new instance 

                //        frmTaxCat.Owner = this;
                //        frmTaxCat.TopLevel = false;

                //        sptCtrlMastermenu.Panel2.Controls.Add(frmTaxCat);
                //        frmTaxCat.Show();
                //        break;
                //    case "ItemCompany":
                //        Administration.ItemCompany frmItemCompany;
                //        frmItemCompany = new Administration.ItemCompany(); //generate new instance 

                //        frmItemCompany.Owner = this;
                //        frmItemCompany.TopLevel = false;

                //        sptCtrlMastermenu.Panel2.Controls.Add(frmItemCompany);
                //        frmItemCompany.Show();
                //        break;
                //    case "ItemMaster":
                //        Administration.ItemMasterNew frmItemMaster;
                //        frmItemMaster = new Administration.ItemMasterNew(); //generate new instance 

                //        frmItemMaster.Owner = this;
                //        frmItemMaster.TopLevel = false;

                //        sptCtrlMastermenu.Panel2.Controls.Add(frmItemMaster);
                //        frmItemMaster.Show();
                //        break;
                //    case "MasterSeriesGroup":
                //        Administration.Masterseriesgroup frmMaster;
                //        frmMaster = new Administration.Masterseriesgroup(); //generate new instance 

                //        frmMaster.Owner = this;
                //        frmMaster.TopLevel = false;

                //        sptCtrlMastermenu.Panel2.Controls.Add(frmMaster);
                //        frmMaster.Show();
                //        break;
                //    default:
                //        break;
                        
                //}
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void MastersMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm.Visible = true;
        }

        private void barbtnAccount_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Administration.Account frm;
            frm = new Administration.Account(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;
            
            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();

            //if (this.ActiveMdiChild != null)
            //    this.ActiveMdiChild.Close();
            //Administration.Account frmacc = new Administration.Account();
            //frmacc.MdiParent = this;
            //frmacc.Show();
            //sptCtrlMastermenu.Panel2.Controls.Add(frmacc);
        }

        private void barbtnAccGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.Accountgroup frm;
            frm = new Administration.Accountgroup(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
            //if (this.ActiveMdiChild != null)
            //    this.ActiveMdiChild.Close();
            //Administration.Accountgroup frmaccgrp = new Administration.Accountgroup();
            //frmaccgrp.MdiParent = this;
            //frmaccgrp.Show();
            //sptCtrlMastermenu.Panel2.Controls.Add(frmaccgrp);
        }

        private void barbtnAuthotmain_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.Author frm;
            frm = new Administration.Author(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barbtnBillmaterial_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.BillsofMaterial frm;
            frm = new Administration.BillsofMaterial(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.Costcenter frm;
            frm = new Administration.Costcenter(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barbtnCostgroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.Costcentergroup frm;
            frm = new Administration.Costcentergroup(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barbtnCurrency_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.Currencyadd frm;
            frm = new Administration.Currencyadd(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barbtnCurrencyconv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.CurrencyConversionMaster frm;
            frm = new Administration.CurrencyConversionMaster(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barbtnSalesman_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.Salesman frm;
            frm = new Administration.Salesman(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barbtnStdNarration_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.StdNarration frm;
            frm = new Administration.StdNarration(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barbtnMastNarration_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.Masterseriesgroup frm;
            frm = new Administration.Masterseriesgroup(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barbtnItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.ItemMasterNew frm;
            frm = new Administration.ItemMasterNew(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barbtnItemgroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.Itemgroup frm;
            frm = new Administration.Itemgroup(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barbtMaterialcenter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.MaterialCenter frm;
            frm = new Administration.MaterialCenter(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barbtnMaterialgroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.Materialcentergroup frm;
            frm = new Administration.Materialcentergroup(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barbtnUnit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.Unitmaster frm;
            frm = new Administration.Unitmaster(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barbtnUnitConver_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.Unitconversion frm;
            frm = new Administration.Unitconversion(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barbtnBillsundary_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.BillSundaryMaster frm;
            frm = new Administration.BillSundaryMaster(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barbtnScheme_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.Schememaster frm;
            frm = new Administration.Schememaster(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barbtnStform_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.Stformmaster frm;
            frm = new Administration.Stformmaster(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barbtnSaletype_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.SaleType frm;
            frm = new Administration.SaleType(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barbtnPurchasetype_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.PurchaseType frm;
            frm = new Administration.PurchaseType(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barbtnTaxcategory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.Taxcategory frm;
            frm = new Administration.Taxcategory(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barbtnTdsCategory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.TDSCategory frm;
            frm = new Administration.TDSCategory(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barbtnContact_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.Contactmaster frm;
            frm = new Administration.Contactmaster(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barbtnContactgroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.Contactgroup frm;
            frm = new Administration.Contactgroup(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barbtnExecutive_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.Executivegroup frm;
            frm = new Administration.Executivegroup(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barbtnMiscellaneousmaster_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.DiscountStructureMaster frm;
            frm = new Administration.DiscountStructureMaster(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barbtnEmployee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.Employeemaster frm;
            frm = new Administration.Employeemaster(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barbtEmployeegrp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.Employeegroup frm;
            frm = new Administration.Employeegroup(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void barbtnSalaryCopm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.Salaraycomponent frm;
            frm = new Administration.Salaraycomponent(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void btnItemCompany_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.ItemCompany frm;
            frm = new Administration.ItemCompany(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void btnMarkupStructure_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.MarkupStructureMaster frm;
            frm = new Administration.MarkupStructureMaster(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void barbtnReference_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Administration.Referencegroup frm;
            frm = new Administration.Referencegroup(); //generate new instance 
            frm.Owner = this;
            frm.TopLevel = false;

            sptCtrlMastermenu.Panel2.Controls.Add(frm);
            frm.Show();
        }
    }
}