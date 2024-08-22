using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using Microsoft.Win32;

namespace GarajKiosk
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            foreach (Process xProcess in Process.GetProcesses())
            {
                if (Process.GetCurrentProcess().ProcessName == xProcess.ProcessName && Process.GetCurrentProcess().Id != xProcess.Id)
                {
                    MessageBox.Show("Zaten uygulama çalışıyor.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            //using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            //{
            //    key.SetValue(Assembly.GetExecutingAssembly().GetName().Name.ToString(), "\"" + Application.ExecutablePath + "\"");
            //}

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(vCurrentDomainUnhandledException);
            Application.Run(new MainForm());
        }

        static void vCurrentDomainUnhandledException(object prm_Sender, UnhandledExceptionEventArgs prm_xUnhandledExceptionEventArgs)
        {
            MessageBox.Show(string.Format("Öngörülmeyen hata.  Uygulama kapatıldı. {0}", prm_xUnhandledExceptionEventArgs.ExceptionObject.ToString()));
            Environment.Exit(1);
        }
    }
}
