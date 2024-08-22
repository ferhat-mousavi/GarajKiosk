using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using evieplus.CommonLibrary;

namespace evieplus.Printer
{
    public class Print : IDisposable
    {
        int m_iInit = -1;

        public Print()
        {
            if (m_iInit != 0)
            {
                MasungPrinter.SetUsbportauto();

                m_iInit = MasungPrinter.SetInit();

                if (m_iInit == 0)
                    MasungPrinter.SetCodepage(3, 0);
            }
        }

        public void Dispose()
        {
            try
            {
                if (m_iInit == 0)
                {
                    MasungPrinter.SetClose();
                    m_iInit = -1;
                }
            }
            catch
            {
                // no handling of the exception
            }
        }



        public void vPrintTicket(int prm_iOrderId, string prm_strProductName, decimal prm_decProductPrice, string prm_strOtpCode, string prm_strLockerNumber)
        {
            StringBuilder xStringBuilder = new StringBuilder("");

            MasungPrinter.SetCommandmode(1);
            MasungPrinter.SetAlignment(1);
            MasungPrinter.SetSizetext(1, 1);
            MasungPrinter.SetBold(1);
            MasungPrinter.PrintFeedline(1);
            xStringBuilder = new StringBuilder("** BILGILENDIRME FISI **");
            MasungPrinter.PrintString(xStringBuilder, 0);
            MasungPrinter.SetBold(0);
            MasungPrinter.PrintFeedline(1);
            xStringBuilder = new StringBuilder("").AppendFormat("No: {0} Tarih: {1:dd/MM/yyyy H:mm}", prm_iOrderId, DateTime.Now);
            MasungPrinter.PrintString(xStringBuilder, 0);
            xStringBuilder = new StringBuilder("").AppendFormat("{0} - {1:N} TL", prm_strProductName.strConvertTurkishCharacters(), prm_decProductPrice);
            MasungPrinter.PrintString(xStringBuilder, 0);
            MasungPrinter.SetBold(1);
            MasungPrinter.PrintFeedline(1);
            xStringBuilder = new StringBuilder().AppendFormat("Dolap Kodu: {0}", prm_strOtpCode);
            MasungPrinter.PrintString(xStringBuilder, 0); 
            xStringBuilder = new StringBuilder().AppendFormat("Dolap No: {0}", prm_strLockerNumber);
            MasungPrinter.PrintString(xStringBuilder, 0);
            MasungPrinter.SetBold(0);
            MasungPrinter.PrintFeedline(1);
            //xStringBuilder = new StringBuilder("").AppendFormat("Bu sifreyi {0} nolu dolabin uzerindeki kilide tuslayin ve kulbu saga çevirerek acın. Fisiniz ve urununuzu dolabin icinden alabilirsiniz.");
            xStringBuilder = new StringBuilder("").AppendFormat("Dolap kodunu {0} nolu dolaptaki", prm_strLockerNumber);
            MasungPrinter.PrintString(xStringBuilder, 0); 
            xStringBuilder = new StringBuilder("kilide girip kulbu cevirerek");
            MasungPrinter.PrintString(xStringBuilder, 0);
            xStringBuilder = new StringBuilder("urunu dolaptan alabilirsiniz.");
            MasungPrinter.PrintString(xStringBuilder, 0);
            MasungPrinter.SetBold(1);
            MasungPrinter.PrintFeedline(1);
            xStringBuilder = new StringBuilder("Tesekkurler!");
            MasungPrinter.PrintString(xStringBuilder, 0);
            MasungPrinter.PrintFeedline(5);

            MasungPrinter.PrintFeedline(5);
            MasungPrinter.PrintCutpaper(0);
            MasungPrinter.SetClean();
        }
    }
}
