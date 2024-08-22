using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

using evieplus.Models;
using evieplus.CommonLibrary;
using evieplus.Forms;
using evieplus.Printer;

namespace GarajKiosk
{
    public partial class MainForm : Form
    {
        List<CatalogItemForFlowModel> m_xCatalogItems = null;

        bool m_bSetting1 = false;
        bool m_bSetting2 = false;
        bool m_bSetting3 = false;
        bool m_bSetting4 = false;

        public MainForm()
        {
            string strName = CommonProperty.prop_strApplicationName = strAssemblyName;
            string strVersion = CommonProperty.prop_strApplicationVersion = strAssemblyVersion;
            string strDescription = CommonProperty.prop_strApplicationDescription = strAssemblyDescription;

            Trace.vInsert(enumTraceLevel.Normal, "Garaj (v{0},{1})", strVersion, strDescription);

            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            vLoadcatalogItems();

            Firebase xFirebase = new Firebase();
            xFirebase.vSendLiveMessage();

            timerLoadForm.Start();
            timerFirebase.Start();
        }

        public void vLoadcatalogItems()
        {
            IEnumerable<CatalogItemForFlowModel> xCatalogItems = null;

            while (xCatalogItems == null)
            {
                try
                {
                    xCatalogItems = evieplus.WebApi.GarajApi.xGetInstance().xGetCatalogs();
                }
                catch
                {
                    OutOfServiceForm xOutOfServiceForm = new OutOfServiceForm();
                    xOutOfServiceForm.ShowDialog();
                    xCatalogItems = xOutOfServiceForm.prop_xCatalogItems;
                }
            }
            m_xCatalogItems = xCatalogItems.ToList();

            pictureBoxAygazType1.Visible = false;
            pictureBoxAygazTypeImage1.Visible = false;
            labelBoxAygazTypeName1.Visible = false;
            labelBoxAygazTypePrice1.Visible = false;

            pictureBoxAygazType2.Visible = false;
            pictureBoxAygazTypeImage2.Visible = false;
            labelBoxAygazTypeName2.Visible = false;
            labelBoxAygazTypePrice2.Visible = false;

            if (m_xCatalogItems.Count == 0)
            {
                labelMessage.Text = "Maalesef şu anda dolapta ürün bulunmamaktadır. Anlayışınız için teşekkürler!";
            }

            int iId = 1;
            foreach (CatalogItemForFlowModel CatalogItem in m_xCatalogItems)
            {
                if (iId == 1)
                {
                    pictureBoxAygazType1.Visible = true;
                    pictureBoxAygazTypeImage1.Visible = true;
                    labelBoxAygazTypeName1.Visible = true;
                    labelBoxAygazTypePrice1.Visible = true;

                    try
                    {
                        pictureBoxAygazTypeImage1.Load(m_xCatalogItems[0].Image);
                    }
                    catch
                    { }
                    labelBoxAygazTypeName1.Text = m_xCatalogItems[0].Name;
                    labelBoxAygazTypePrice1.Text = string.Format("{0} TL", m_xCatalogItems[0].Price);

                    iId++;
                }
                else if (iId == 2)
                {
                    pictureBoxAygazType2.Visible = true;
                    pictureBoxAygazTypeImage2.Visible = true;
                    labelBoxAygazTypeName2.Visible = true;
                    labelBoxAygazTypePrice2.Visible = true;

                    try
                    {
                        pictureBoxAygazTypeImage2.Load(m_xCatalogItems[1].Image);
                    }
                    catch
                    { }
                    labelBoxAygazTypeName2.Text = m_xCatalogItems[1].Name;
                    labelBoxAygazTypePrice2.Text = string.Format("{0} TL", m_xCatalogItems[1].Price);

                    iId++;
                }
                else
                {
                    break;
                }
            }

        }

        private void timerLoadForm_Tick(object sender, EventArgs e)
        {
            vLoadcatalogItems();
            vResetSettingsButtons();
        }

        public string strAssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string strAssemblyName
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Name.ToString();
            }
        }

        public string strAssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        private void pictureBoxAygazType1_Click(object sender, EventArgs e)
        {
            timerLoadForm.Stop();

            bPickUp(m_xCatalogItems[0]);

            timerLoadForm.Start();
        }

        private void pictureBoxAygazType2_Click(object sender, EventArgs e)
        {
            timerLoadForm.Stop();

            bPickUp(m_xCatalogItems[1]);

            timerLoadForm.Start();
        }

        private bool bPickUp(CatalogItemForFlowModel prm_xCatalogItemForFlowModel)
        {
            try
            {
                PickUpResultModel xPickUpResult = evieplus.WebApi.GarajApi.xGetInstance().xPickUp(prm_xCatalogItemForFlowModel.Code);
                DialogResult xDialogResult = DialogResult.Cancel;

                if (xPickUpResult != null)
                {
                    TcIdForm xTcIdForm = new TcIdForm();
                    xTcIdForm.prop_xCatalogItem = prm_xCatalogItemForFlowModel;
                    xTcIdForm.prop_xPickUpResult = xPickUpResult;
                    xDialogResult = xTcIdForm.ShowDialog();

                    if(xDialogResult == DialogResult.Cancel)
                        evieplus.WebApi.GarajApi.xGetInstance().bCancel(xPickUpResult.OrderId);
                }
                else
                {
                    NotAvailableForm xNotAvailableForm = new NotAvailableForm();
                    xNotAvailableForm.prop_xCatalogItem = prm_xCatalogItemForFlowModel;

                    xDialogResult = xNotAvailableForm.ShowDialog();
                }

                if (xDialogResult == DialogResult.OK)
                {
                    return true;
                }

            }
            catch
            {
                vLoadcatalogItems();
                vResetSettingsButtons();
            }
            return false;
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

        private void timerFirebase_Tick(object sender, EventArgs e)
        {
            Firebase xFirebase = new Firebase();
            xFirebase.vSendLiveMessage();
        }
    }
}
