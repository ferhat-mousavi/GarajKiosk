using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using evieplus.CommonLibrary;
using evieplus.Models;

namespace evieplus.Forms
{
    public partial class TcIdForm : Form
    {
        private CatalogItemForFlowModel m_xCatalogItem = null;
        private PickUpResultModel m_xPickUpResult = null;
        int m_iDurationLeft = 300;

        public CatalogItemForFlowModel prop_xCatalogItem
        {
            set
            {
                m_xCatalogItem = value;
            }
        }

        public PickUpResultModel prop_xPickUpResult
        {
            set
            {
                m_xPickUpResult = value;
            }
        }

        public TcIdForm()
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
                if (textBoxTcNo.Text.Length < 11)
                {
                    textBoxTcNo.Text += prm_strValue;
                    labelError.Visible = false;
                }

                if (textBoxTcNo.Text.Length == 11 && textBoxTcNo.Text.bCheckNationalIdentityNo() == true)
                {
                    buttonOk.Enabled = true;
                    labelError.Visible = false;
                }
                else if (textBoxTcNo.Text.Length == 11 && textBoxTcNo.Text.bCheckNationalIdentityNo() == false)
                {
                    buttonOk.Enabled = false;
                    labelError.Visible = true;
                }
            }

            vFocusOnOutputTextBox();
        }

        private void vFocusOnOutputTextBox()
        {
            textBoxTcNo.Focus();
            textBoxTcNo.Select(textBoxTcNo.Text.Length, 0);
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
            if (textBoxTcNo.Text.Length > 0)
            {
                textBoxTcNo.Text = textBoxTcNo.Text.Substring(0, textBoxTcNo.Text.Length - 1);
                buttonOk.Enabled = false;
                labelError.Visible = false;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                bool bConfirmStatus = evieplus.WebApi.GarajApi.xGetInstance().bConfirm(m_xPickUpResult.OrderId, textBoxTcNo.Text);

                if (bConfirmStatus)
                {
                    PaymentForm xPaymentForm = new PaymentForm();
                    xPaymentForm.prop_strNationalIdNo = textBoxTcNo.Text;
                    xPaymentForm.prop_xCatalogItem = m_xCatalogItem;
                    xPaymentForm.prop_xPickUpResult = m_xPickUpResult;
                    DialogResult xDialogResult = xPaymentForm.ShowDialog();

                    if (xDialogResult == DialogResult.OK)
                        DialogResult = DialogResult.OK;
                    else
                        DialogResult = DialogResult.Cancel;
                }
                else
                {
                }
            }
            catch
            {
                DialogResult = DialogResult.Abort;
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void timerDurationLeft_Tick(object sender, EventArgs e)
        {
            vUpdateLabel();
        }

        delegate void vUpdateLabelDelegate();
        private void vUpdateLabel()
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new vUpdateLabelDelegate(vUpdateLabel));
                return;
            }

            if (m_iDurationLeft > 0)
                m_iDurationLeft--;

            labelDurationLeft.Text = string.Format("{0} sn", m_iDurationLeft);

            if (m_iDurationLeft == 0)
            {
                timerDurationLeft.Stop();
                timerDurationLeft.Enabled = false;
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
