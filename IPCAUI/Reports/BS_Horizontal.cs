using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPCAUI.Reports
{
    public partial class BS_Horizontal : Form
    {
        public BS_Horizontal()
        {
            InitializeComponent();
            //ComboBox combo = new ComboBox();
            ////ComboBoxEdit combo = new ComboBoxEdit();
            //ComboBox coll = combo.Properties.Items;
            //coll.BeginUpdate();
            //try
            //{
            //    coll.Add(new PersonInfo("Sven", "Petersen"));
            //    coll.Add(new PersonInfo("Cheryl", "Saylor"));
            //    coll.Add(new PersonInfo("Dirk", "Luchte"));
            //}
            //finally
            //{
            //    coll.EndUpdate();
            //}
            //combo.SelectedIndex = -1;

            //Controls.Add(combo);
            //string[] str = { "January", "Febary", "Kathy Finch", "Mark Flora", "Greg Hull", "Matt Flora" };
            //AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            //collection.AddRange(str);
            //tbxStartMonth.MaskBox.AutoCompleteCustomSource = collection;
            //tbxStartMonth.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //tbxStartMonth.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            
            


            
            //tbxEndmonth.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //tbxEndmonth.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //tbxEndmonth.MaskBox.AutoCompleteCustomSource = collection;

            cbxStartingdate.SelectedIndex = 0;
            cbxEndingdate.SelectedIndex = 0;
            cbxUpdatestock.SelectedIndex = 0;
            cbxBranch.SelectedIndex = 0;
            cbxSecondlevelgroup.SelectedIndex = 0;
            cbxShowgroupsAmounts.SelectedIndex = 0;
            cbxZerobalanceyesno.SelectedIndex = 0;
            cbxJobworkstock.SelectedIndex = 0;
            cbxShowratio.SelectedIndex = 0;
            cbxPLperiod.SelectedIndex = 0;
            tbxSalefactor.Text = "1";
        }
        //protected override void OnMaskBox_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!Properties.AllowUnlistedValueInput)
        //    {
        //        if (!Char.IsControl(e.KeyChar))
        //        {
        //            AutocompleteItemsCollection items = Properties.Items;
        //            if (items.CountFilterMatches( /*items.Filter*/AutoSearchText + e.KeyChar) == 0)
        //            {
        //                e.Handled = true;
        //                return;
        //            }
        //        }
        //    }
        //    base.OnMaskBox_KeyPress(sender, e);
        //}
        private void BS_Horizontal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are You Want To Show Reports");
            return;
            //Bshorizontalgrid frm = new Bshorizontalgrid();
            //frm.MdiParent = this.ParentForm;
            //frm.Show();
        }

        private void tbxStartmonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar < 32 || e.KeyChar > 126)
            //{
            //    return;
            //}
            //string t = tbxStartmonth.Text;
            //string typedT = t.Substring(0, tbxStartmonth.SelectionStart);
            //string newT = typedT + e.KeyChar;

            //int i = tbxStartmonth.text(newT);
            //if (i == -1)
            //{
            //    e.Handled = true;
            //}
            //if (Char.IsLetter(e.KeyChar))
            //{
            //    e.KeyChar = Char.ToUpper(e.KeyChar);
            //}
        }

        private void tbxBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //tbxStartMonth.Focus();
            }
        }

        private void textEdit5_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar < 32 || e.KeyChar > 126)
            //{
            //    return;
            //}
            //string t = textEdit5.Text;
            //string typedT = t.Substring(0, textEdit5.SelectionStart);
            //string newT = typedT + e.KeyChar;

            //int i = textEdit5.Text.Trim(newT);
            //if (i == -1)
            //{
            //    e.Handled = true;
            //}
            //if (Char.IsLetter(e.KeyChar))
            //{
            //    e.KeyChar = Char.ToUpper(e.KeyChar);
            //}
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar < 32 || e.KeyChar > 126)
            //{
            //    return;
            //}
            //string t = textEdit5.Text;
            //string typedT = t.Substring(0, textEdit5.SelectionStart);
            //string newT = typedT + e.KeyChar;

            //int i = comboBox1.FindString(newT);
            //if (i == -1)
            //{
            //    e.Handled = true;
            //}
            //if (Char.IsLetter(e.KeyChar))
            //{
            //    e.KeyChar = Char.ToUpper(e.KeyChar);
            //}
        }

        private void comboBoxEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar < 32 || e.KeyChar > 126)
            //{
            //    return;
            //}
            //string t = comboBoxEdit1.Text;
            //string typedT = t.Substring(0, comboBoxEdit1.SelectionStart);
            //string newT = typedT + e.KeyChar;

            //int i = comboBoxEdit1.FindString(newT);
            //if (i == -1)
            //{
            //    e.Handled = true;
            //}
            //if (Char.IsLetter(e.KeyChar))
            //{
            //    e.KeyChar = Char.ToUpper(e.KeyChar);
            //}
        }
    }
}
