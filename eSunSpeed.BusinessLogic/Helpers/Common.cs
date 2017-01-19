using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eSunSpeed.BusinessLogic.Helpers
{
    class Common
    {
        #region Function
        /// <summary>
        /// Function for Enterkey validation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void EnterKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }
        /// <summary>
        /// Function for decimal validation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="isNegativeFiled"></param>
        public static void DecimalValidation(object sender, KeyPressEventArgs e, bool isNegativeFiled)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                if (!char.IsNumber(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                }
                if (e.KeyChar == 46)
                {
                    if (txt.Text.Contains(".") && txt.SelectionStart != 0)
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        if (txt.Text == "" || txt.SelectionStart == 0)
                        {
                            txt.Clear();
                            txt.Text = "0.";
                            txt.SelectionStart = txt.Text.Length;
                        }
                        else
                        {
                            txt.Text = txt.Text + ".";
                            txt.SelectionStart = txt.Text.Length;
                        }
                    }
                }
                else if (e.KeyChar == 45 && (isNegativeFiled))
                {
                    if (txt.Text.Contains("-") && txt.SelectionStart != 0)
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        txt.Clear();
                        txt.Text = "-";
                        txt.SelectionStart = txt.Text.Length;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("TAX: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function for numberonly validation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void NumberOnly(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127;
        }
        /// <summary>
        /// Function for Email validation
        /// </summary>
        /// <param name="txtEmail"></param>
        /// <returns></returns>
        public static bool EmailValidation(TextBox txtEmail)
        {
            bool isOk = true;
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (txtEmail.Text.Length > 0)
            {
                if (!rEMail.IsMatch(txtEmail.Text))
                {
                    txtEmail.Focus();
                    isOk = false;
                }
            }
            return isOk;
        }
        /// <summary>
        /// For shortcut keys
        /// </summary>
        /// <param name="e"></param>
        /// <param name="btn"></param>
        /// <param name="btnclose"></param>
        public static void ExecuteShortCutKey(KeyEventArgs e, Button btn, Button btnclose)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnclose.PerformClick();
            }
            if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control) //Save
            {
                btn.PerformClick();
            }
        }
        #endregion Function
    }
}
