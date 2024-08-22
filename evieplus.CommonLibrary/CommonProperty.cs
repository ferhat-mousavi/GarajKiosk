using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evieplus.CommonLibrary
{
    public class CommonProperty
    {
        public static string prop_strApplicationName
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strApplicationName;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strApplicationName = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strApplicationVersion
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strApplicationVersion;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strApplicationVersion = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strApplicationDescription
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strApplicationDescription;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strApplicationDescription = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strImagesFolder
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strImagesFolder;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strImagesFolder = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strLicenseOwner
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strLicenseOwner;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strLicenseOwner = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strIsoCultureName
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strIsoCultureName;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strIsoCultureName = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static bool prop_bIsDebugModeActive
        {
            get
            {
                return JsonParameter.xGetInstance().prop_bIsDebugModeActive;
            }
            set
            {
                JsonParameter.xGetInstance().prop_bIsDebugModeActive = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strGarajIdpUri
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strGarajIdpUri;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strGarajIdpUri = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strGarajApiUri
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strGarajApiUri;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strGarajApiUri = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strNayaxPort
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strNayaxPort;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strNayaxPort = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strClientId
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strClientId;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strClientId = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strClientSecret
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strClientSecret;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strClientSecret = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }

        public static string prop_strScope
        {
            get
            {
                return JsonParameter.xGetInstance().prop_strScope;
            }
            set
            {
                JsonParameter.xGetInstance().prop_strScope = value;
                JsonParameter.xGetInstance().bUpdateJsonParameter();
            }
        }
    }
}
