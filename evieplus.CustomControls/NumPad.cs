using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace evieplus.CustomControls
{
    public partial class NumPad : UserControl
    {
        public NumPad()
        {
            InitializeComponent();
            vInitializeCustomComponents();
        }

        public void vInitializeCustomComponents()
        {
            buttonZero.BackColor = BackColor;
            buttonOne.BackColor = BackColor;
            buttonTwo.BackColor = BackColor;
            buttonThree.BackColor = BackColor;
            buttonFour.BackColor = BackColor;
            buttonFive.BackColor = BackColor;
            buttonSix.BackColor = BackColor;
            buttonSeven.BackColor = BackColor;
            buttonEight.BackColor = BackColor;
            buttonNine.BackColor = BackColor;
            buttonComma.BackColor = BackColor;

            buttonZero.ForeColor = ForeColor;
            buttonOne.ForeColor = ForeColor;
            buttonTwo.ForeColor = ForeColor;
            buttonThree.ForeColor = ForeColor;
            buttonFour.ForeColor = ForeColor;
            buttonFive.ForeColor = ForeColor;
            buttonSix.ForeColor = ForeColor;
            buttonSeven.ForeColor = ForeColor;
            buttonEight.ForeColor = ForeColor;
            buttonNine.ForeColor = ForeColor;
            buttonComma.ForeColor = ForeColor;

            textBoxOuput.SelectionLength = 0;
        }

        public string strNumPadOutput
        {
            get
            {
                return textBoxOuput.Text;
            }
            set
            {
                textBoxOuput.Text = value;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            vFocusOnOutputTextBox();
            vInvokeExternalEvent(e, false);
        }

        delegate void vNewKeyDelegate(string prm_strValue, string prm_strFunction);
        void vNewKey(string prm_strValue, string prm_strFunction)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new vNewKeyDelegate(vNewKey), prm_strValue, prm_strFunction);
                return;
            }

            if (prm_strValue != string.Empty)
            {
                textBoxOuput.Text += prm_strValue;
            }
            else if (prm_strFunction != string.Empty)
            {
                switch (prm_strFunction)
                {
                    case "DELETE":
                        if (textBoxOuput.Text.Length > 0)
                        {
                            textBoxOuput.Text = textBoxOuput.Text.Substring(0, textBoxOuput.Text.Length - 1);
                        }
                        break;
                    case "OK":
                        break;
                    case "CLEAR":
                        textBoxOuput.Text = "";
                        break;
                }
            }

            vFocusOnOutputTextBox();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            vNewKey(string.Empty, "DELETE");
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            vNewKey(string.Empty, "CLEAR");
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            if (textBoxOuput.Text.Length > 0 && textBoxOuput.Text.IndexOf("X") < 0)
            {
                vNewKey("X", string.Empty);
            }
            vFocusOnOutputTextBox();
        }

        private void buttonComma_Click(object sender, EventArgs e)
        {
            if (textBoxOuput.Text.IndexOf(",") < 0)
            {
                vNewKey(",", string.Empty);
            }
            vFocusOnOutputTextBox();
        }

        private void buttonOne_Click(object sender, EventArgs e)
        {
            vNewKey("1", string.Empty);
        }

        private void buttonTwo_Click(object sender, EventArgs e)
        {
            vNewKey("2", string.Empty);
        }

        private void buttonThree_Click(object sender, EventArgs e)
        {
            vNewKey("3", string.Empty);
        }

        private void buttonFour_Click(object sender, EventArgs e)
        {
            vNewKey("4", string.Empty);
        }

        private void buttonFive_Click(object sender, EventArgs e)
        {
            vNewKey("5", string.Empty);
        }

        private void buttonSix_Click(object sender, EventArgs e)
        {
            vNewKey("6", string.Empty);
        }

        private void buttonSeven_Click(object sender, EventArgs e)
        {
            vNewKey("7", string.Empty);
        }

        private void buttonEight_Click(object sender, EventArgs e)
        {
            vNewKey("8", string.Empty);
        }

        private void buttonNine_Click(object sender, EventArgs e)
        {
            vNewKey("9", string.Empty);
        }

        private void buttonZero_Click(object sender, EventArgs e)
        {
            vNewKey("0", string.Empty);
        }

        private void textBoxOuput_TextChanged(object sender, EventArgs e)
        {
            vFocusOnOutputTextBox();
            vInvokeExternalEvent(e);
        }

        private void vInvokeExternalEvent(EventArgs e, bool prm_bForce = true)
        {
            if (prm_bForce == false)
            {
                    if (xEventHandler1 != null)
                        xEventHandler1.Invoke(this, e);

                vFocusOnOutputTextBox();
                return;
            }

            vFocusOnOutputTextBox();
        }

        private void vFocusOnOutputTextBox()
        {
            textBoxOuput.Focus();
            textBoxOuput.Select(textBoxOuput.Text.Length, 0);
        }

        public EventHandler xEventHandler1 { get; set; }
        public EventHandler xEventHandler2 { get; set; }

        public void vOnEvent1(object prm_objObject, EventArgs prm_xEventArgs)
        {
            if (xEventHandler1 != null)
                xEventHandler1(prm_objObject, prm_xEventArgs);

            vFocusOnOutputTextBox();
        }

        public void vOnEvent2(object prm_objObject, EventArgs prm_xEventArgs)
        {
            if (xEventHandler2 != null)
                xEventHandler2(prm_objObject, prm_xEventArgs);

            vFocusOnOutputTextBox();
        }

        private void CustomNumpad_Enter(object prm_objObject, EventArgs e)
        {
            vFocusOnOutputTextBox();
        }

        private void textBoxOuput_KeyDown(object prm_objObject, KeyEventArgs prm_xKeyEventArgs)
        {
            vFocusOnOutputTextBox();
        }

        public KeyPressEventHandler xExternalKeyPressEventHandler { get; set; }
        public KeyEventHandler xExternalKeyEventHandler { get; set; }

        private void textBoxOuput_KeyPress(object prm_objObject, KeyPressEventArgs prm_xKeyPressEventArgs)
        {
            if (prm_xKeyPressEventArgs.KeyChar.bIsDigit() == true || prm_xKeyPressEventArgs.KeyChar == ',' || prm_xKeyPressEventArgs.KeyChar == 13)
            {
                return;
            }

            if (xExternalKeyPressEventHandler != null)
                xExternalKeyPressEventHandler(prm_objObject, prm_xKeyPressEventArgs);

            prm_xKeyPressEventArgs.Handled = true;

            vFocusOnOutputTextBox();
        }

        private void textBoxOuput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                vInvokeExternalEvent(e, false);

            vFocusOnOutputTextBox();
        }

        private void CustomNumpad_Load(object sender, EventArgs e)
        {
            // Loop through the controls inside the  form i.e. Tabcontrol Container

            foreach (Control xControl in this.Controls)
            {
                xControl.Tag = xControl.Name + "/" + xControl.Left + "/" + xControl.Top + "/" + xControl.Width + "/" + xControl.Height + "/" + (int)xControl.Font.Size;

            }

            vFocusOnOutputTextBox();
        }
    }

    public static class CharacterExtension
    {
        public static bool bIsDigit(this char prm_cCharacter)
        {
            foreach (char cCharacter in "0123456789")
            {
                if (prm_cCharacter == cCharacter)
                    return true;
            }

            return false;
        }
    }
}
