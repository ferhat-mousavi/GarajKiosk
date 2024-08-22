using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace evieplus.CommonLibrary
{
    public class JsonParameter
    {
        private static JsonParameter m_xGlobalsInstance = null;

        public static JsonParameter xGetInstance()
        {
            if (m_xGlobalsInstance == null)
            {
                m_xGlobalsInstance = new JsonParameter();

                JsonReadWrite<JsonParameter>.xGetInstance().bRead(ref m_xGlobalsInstance);
            }

            return m_xGlobalsInstance;
        }

        public bool bUpdateJsonParameter()
        {
            return JsonReadWrite<JsonParameter>.xGetInstance().bWrite(m_xGlobalsInstance);
        }

        public short prop_sTraceLevel { get; set; }
        public string prop_strTracesFolder { get; set; }
        public bool prop_bEventLog { get; set; }
        public long prop_lTraceFileSize { get; set; }
        public string prop_strApplicationName { get; set; }
        public string prop_strApplicationVersion { get; set; }
        public string prop_strApplicationDescription { get; set; }
        public string prop_strImagesFolder { get; set; }
        public string prop_strLicenseOwner { get; set; }
        public string prop_strIsoCultureName { get; set; }
        public bool prop_bIsDebugModeActive { get; set; }
        public string prop_strGarajIdpUri { get; set; }
        public string prop_strGarajApiUri { get; set; }
        public string prop_strNayaxPort { get; set; }
        public string prop_strClientId { get; set; }
        public string prop_strClientSecret { get; set; }
        public string prop_strScope { get; set; }


        public JsonParameter()
        {
            FileInfo xFileInfo = new FileInfo(JsonReadWrite<JsonParameter>.xGetInstance().prop_strJsonFileName);

            if (xFileInfo.Exists == false)
            {
                prop_sTraceLevel = 5;
                prop_strTracesFolder = @"C:\GARAJ\Traces";
                prop_bEventLog = true;
                prop_lTraceFileSize = 5242880;
                prop_strApplicationName = string.Empty;
                prop_strApplicationVersion = string.Empty;
                prop_strApplicationDescription = string.Empty;
                prop_strImagesFolder = @"C:\GARAJ\Images";
                prop_strLicenseOwner = string.Empty;
                prop_strIsoCultureName = "tr - TR";            
                prop_bIsDebugModeActive = false;
                prop_strGarajIdpUri = @"https://id.kutu.tech";
                prop_strGarajApiUri = @"https://api.kutu.tech";
                prop_strNayaxPort = "COM5";
                prop_strClientId = "aygaz-1";
                prop_strClientSecret = "asecret";
                prop_strScope = "product-api";

                JsonReadWrite<JsonParameter>.xGetInstance().bWrite(this);
            }
        }
    }
}
