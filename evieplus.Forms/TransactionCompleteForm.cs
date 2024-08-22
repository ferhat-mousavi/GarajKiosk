using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using evieplus.Models;
using evieplus.Printer;

namespace evieplus.Forms
{
    public partial class TransactionCompleteForm : Form
    {
        private string m_strNationalIdNo = string.Empty;
        private CatalogItemForFlowModel m_xCatalogItem = null;
        private PickUpResultModel m_xPickUpResult = null;

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

        public TransactionCompleteForm()
        {
            InitializeComponent();
        }

        private void TransactionCompleteForm_Load(object sender, EventArgs e)
        {
            pictureBoxAygazTypeImage.Load(m_xCatalogItem.Image);
            labelBoxAygazTypeName.Text = m_xCatalogItem.Name;
            labelBoxAygazTypePrice.Text = string.Format("{0} TL", m_xCatalogItem.Price);
            labelMessage.Text = string.Format("Ürününüzü {0} numaralı dolaptan {1} şifresi ile alabilirsiniz.", m_xPickUpResult.LockerNumber, m_xPickUpResult.OtpCode);
        }

        private void TransactionCompleteForm_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();

            vTransactionComplete();

            DialogResult = DialogResult.OK;

        }

        delegate void vTransactionCompleteDelegate();
        void vTransactionComplete()
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new vTransactionCompleteDelegate(vTransactionComplete));
                return;
            }

            try
            {
                Print xPrint = new Print();
                xPrint.vPrintTicket(m_xPickUpResult.OrderId, m_xCatalogItem.Name, m_xCatalogItem.Price, m_xPickUpResult.OtpCode, m_xPickUpResult.LockerNumber);
            }
            catch
            {
            }

            Thread.Sleep(15000);
        }
    }
}
