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
    public partial class NotAvailableForm : Form
    {
        private CatalogItemForFlowModel m_xCatalogItem = null;

        public CatalogItemForFlowModel prop_xCatalogItem
        {
            set
            {
                m_xCatalogItem = value;
            }
        }

        public NotAvailableForm()
        {
            InitializeComponent();

            m_iCounter = 0;
        }

        private void NotAvailableForm_Load(object sender, EventArgs e)
        {
            pictureBoxAygazTypeImage.Load(m_xCatalogItem.Image);
            labelBoxAygazTypeName.Text = m_xCatalogItem.Name;
            labelBoxAygazTypePrice.Text = string.Format("{0} TL", m_xCatalogItem.Price);
        }

        int m_iCounter = 0;

        private void NotAvailableForm_Shown(object sender, EventArgs e)
        {
            vNotAvailableFormControlLoop();
            DialogResult = DialogResult.Cancel;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            m_iCounter = 50;
            DialogResult = DialogResult.Cancel;
        }

        delegate void vNotAvailableFormControlLoopDelegate();
        private void vNotAvailableFormControlLoop()
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new vNotAvailableFormControlLoopDelegate(vNotAvailableFormControlLoop));
                return;
            }

            while (m_iCounter < 50)
            {
                try
                {
                    Application.DoEvents();
                    Thread.Sleep(100);
                    m_iCounter++;
                }
                catch
                {
                }
            }
        }
    }
}
