using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using evieplus.Models;

namespace evieplus.Forms
{
    public partial class PaymentForm : Form
    {
        private string m_strNationalIdNo = string.Empty;
        private CatalogItemForFlowModel m_xCatalogItem = null;
        private PickUpResultModel m_xPickUpResult = null;
        int m_iDurationLeft = 300;

        public string prop_strNationalIdNo
        {
            set
            {
                m_strNationalIdNo = value;
            }
        }

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

        public PaymentForm()
        {
            InitializeComponent();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            pictureBoxAygazTypeImage.Load(m_xCatalogItem.Image);
            labelBoxAygazTypeName.Text = m_xCatalogItem.Name;
            labelBoxAygazTypePrice.Text = string.Format("{0} TL", m_xCatalogItem.Price);

            // timerDurationLeft.Start();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void PaymentForm_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();

            vDoAuthorization();
        }

        delegate void vDoAuthorizationDelegate();
        private void vDoAuthorization()
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new vDoAuthorizationDelegate(vDoAuthorization));
                return;
            }

            int iPrice = (int)(m_xCatalogItem.Price * 100);
            evieplus.Payments.NayaxMarshall xNayaxMarshall = new evieplus.Payments.NayaxMarshall();
            AuthorizationModel xAuthorizationModel = xNayaxMarshall.xTransaction(iPrice, 1);

            if (xAuthorizationModel.bProcessStatus && xAuthorizationModel.bAuthorizationResultStatus)
            {
                TransactionCompleteForm xTransactionCompleteForm = new TransactionCompleteForm();
                xTransactionCompleteForm.prop_strNationalIdNo = m_strNationalIdNo;
                xTransactionCompleteForm.prop_xCatalogItem = m_xCatalogItem;
                xTransactionCompleteForm.prop_xPickUpResult = m_xPickUpResult;

                DialogResult = xTransactionCompleteForm.ShowDialog();
            }
            else if (xAuthorizationModel.bProcessStatus)
            {
                NotAuhtorizationForm xNotAuhtorizationForm = new NotAuhtorizationForm();
                xNotAuhtorizationForm.ShowDialog();
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                NayaxNotWorkForm xNayaxNotWorkForm = new NayaxNotWorkForm();
                xNayaxNotWorkForm.ShowDialog();
                DialogResult = DialogResult.Cancel;
            }
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
                timerDurationLeft.Stop();
        }
    }
}
