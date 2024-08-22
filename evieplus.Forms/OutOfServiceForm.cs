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
    public partial class OutOfServiceForm : Form
    {
        private IEnumerable<CatalogItemForFlowModel> m_xCatalogItems = null;

        bool m_bSetting1 = false;
        bool m_bSetting2 = false;
        bool m_bSetting3 = false;
        bool m_bSetting4 = false;

        public IEnumerable<CatalogItemForFlowModel> prop_xCatalogItems
        {
            set
            {
                m_xCatalogItems = value;
            }
            get
            {
                return m_xCatalogItems;
            }
        }

        public OutOfServiceForm()
        {
            InitializeComponent();
        }

        private void OutOfServiceForm_Shown(object sender, EventArgs e)
        {
            vServiceControlLoop();

            DialogResult = DialogResult.OK;
        }

        delegate void vServiceControlLoopDelegate();
        private void vServiceControlLoop()
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new vServiceControlLoopDelegate(vServiceControlLoop));
                return;
            }

            while (m_xCatalogItems == null)
            {
                try
                {
                    Application.DoEvents();
                    Thread.Sleep(100);
                    m_xCatalogItems = evieplus.WebApi.GarajApi.xGetInstance().xGetCatalogs();
                }
                catch
                {
                }
            }
        }

        private void buttonSettings1_Click(object sender, EventArgs e)
        {
            if (m_bSetting1 == true)
            {
                vResetSettingsButtons();
                return;
            }

            m_bSetting1 = true;

            if (m_bSetting1 == true && m_bSetting2 == true && m_bSetting3 == true && m_bSetting4 == true)
            {
                ExitForm xExitForm = new ExitForm();
                DialogResult = xExitForm.ShowDialog();
                if (DialogResult == DialogResult.Yes)
                    Environment.Exit(0);
            }
        }

        private void buttonSettings2_Click(object sender, EventArgs e)
        {
            if (m_bSetting2 == true)
            {
                vResetSettingsButtons();
                return;
            }

            m_bSetting2 = true;

            if (m_bSetting1 == true && m_bSetting2 == true && m_bSetting3 == true && m_bSetting4 == true)
            {
                ExitForm xExitForm = new ExitForm();
                DialogResult = xExitForm.ShowDialog();
                if (DialogResult == DialogResult.Yes)
                    Environment.Exit(0);
            }
        }

        private void buttonSettings3_Click(object sender, EventArgs e)
        {
            if (m_bSetting3 == true)
            {
                vResetSettingsButtons();
                return;
            }

            m_bSetting3 = true;

            if (m_bSetting1 == true && m_bSetting2 == true && m_bSetting3 == true && m_bSetting4 == true)
            {
                ExitForm xExitForm = new ExitForm();
                DialogResult = xExitForm.ShowDialog();
                if (DialogResult == DialogResult.Yes)
                    Environment.Exit(0);
            }
        }

        private void buttonSettings4_Click(object sender, EventArgs e)
        {
            if (m_bSetting4 == true)
            {
                vResetSettingsButtons();
                return;
            }

            m_bSetting4 = true;

            if (m_bSetting1 == true && m_bSetting2 == true && m_bSetting3 == true && m_bSetting4 == true)
            {
                ExitForm xExitForm = new ExitForm();
                DialogResult = xExitForm.ShowDialog();
                if (DialogResult == DialogResult.Yes)
                    Environment.Exit(0);
            }
        }

        private void vResetSettingsButtons()
        {
            m_bSetting1 = false;
            m_bSetting2 = false;
            m_bSetting3 = false;
            m_bSetting4 = false;
        }
    }
}
