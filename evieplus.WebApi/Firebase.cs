using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

using Newtonsoft.Json;

using evieplus.CommonLibrary;

namespace evieplus.Printer
{
    public class Firebase
    {
        public Firebase()
        {

        }

        private static async Task taskSendLiveMessage()
        {
            try
            {
                string strClientId = CommonProperty.prop_strClientId;
                string strVolumeSerial = VolumeSerial.xGetInstance().strGetUniqueId();
                string strVersion = CommonProperty.prop_strApplicationVersion;
                string strDateTimeNow = string.Format("{0:dd.MM.yyyy HH:mm}", DateTime.Now);
                var xJsonData = string.Format("{{\"Kiosk{1}\":{{\"ClientId\":\"{0}\",\"SerialNumber\":\"{1}\",\"DateTime\":\"{2}\",\"Version\":\"{3}\"}}}}", strClientId, strVolumeSerial, strDateTimeNow, strVersion);

                HttpClient xHttpClient = new HttpClient();
                xHttpClient.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpRequestMessage xHttpRequestMessage =
                    new HttpRequestMessage(new HttpMethod("PATCH"), "https://garajkiosk.firebaseio.com/.json")
                    {
                        Content = new StringContent(xJsonData, Encoding.UTF8, "application/json")
                    };
                var response = await xHttpClient.SendAsync(xHttpRequestMessage);


                if (!response.IsSuccessStatusCode)
                {
                    // error
                }
            }
            catch
            { 
            }
        }

        public void vSendLiveMessage()
        {
            Task xTask = Task.Run(async () => await taskSendLiveMessage());
        }
    }
}
