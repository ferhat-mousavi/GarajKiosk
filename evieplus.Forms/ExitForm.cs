using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace evieplus.Forms
{
    public partial class ExitForm : Form
    {
        public ExitForm()
        {
            InitializeComponent();
        }

        delegate void vNewKeyDelegate(string prm_strValue);
        void vNewKey(string prm_strValue)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new vNewKeyDelegate(vNewKey), prm_strValue);
                return;
            }

            if (prm_strValue != string.Empty)
            {
                if (textBoxPassword.Text.Length < 8)
                {
                    textBoxPassword.Text += prm_strValue;
                }

                if (textBoxPassword.Text.Length == 8)
                {
                    buttonOk.Enabled = true;
                }
                else
                {
                    buttonOk.Enabled = false;
                }
            }

            vFocusOnOutputTextBox();
        }

        private void vFocusOnOutputTextBox()
        {
            textBoxPassword.Focus();
            textBoxPassword.Select(textBoxPassword.Text.Length, 0);
        }

        private void buttonZero_Click(object sender, EventArgs e)
        {
            vNewKey("0");
        }

        private void buttonOne_Click(object sender, EventArgs e)
        {
            vNewKey("1");
        }

        private void buttonTwo_Click(object sender, EventArgs e)
        {
            vNewKey("2");
        }

        private void buttonThree_Click(object sender, EventArgs e)
        {
            vNewKey("3");
        }

        private void buttonFour_Click(object sender, EventArgs e)
        {
            vNewKey("4");
        }

        private void buttonFive_Click(object sender, EventArgs e)
        {
            vNewKey("5");
        }

        private void buttonSix_Click(object sender, EventArgs e)
        {
            vNewKey("6");
        }

        private void buttonSeven_Click(object sender, EventArgs e)
        {
            vNewKey("7");
        }

        private void buttonEight_Click(object sender, EventArgs e)
        {
            vNewKey("8");
        }

        private void buttonNine_Click(object sender, EventArgs e)
        {
            vNewKey("9");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.Text.Length > 0)
            {
                textBoxPassword.Text = textBoxPassword.Text.Substring(0, textBoxPassword.Text.Length - 1);
                buttonOk.Enabled = false;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                string strPassword = string.Format("{0:ddMMyyHH}", DateTime.Now);

                if (textBoxPassword.Text == strPassword)
                    DialogResult = DialogResult.Yes;
            }
            catch
            {
                DialogResult = DialogResult.No;
            }

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}
