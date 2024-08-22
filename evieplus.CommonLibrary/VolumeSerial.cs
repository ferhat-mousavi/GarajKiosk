using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.IO;

namespace evieplus.CommonLibrary
{
    public class VolumeSerial
    {
        private static VolumeSerial m_xGlobalsInstance = null;

        public VolumeSerial()
        { 
        }

        public static VolumeSerial xGetInstance()
        {
            if (m_xGlobalsInstance == null)
            {
                m_xGlobalsInstance = new VolumeSerial();
            }

            return m_xGlobalsInstance;
        }

        public string strGetUniqueId()
        {
            string strDrive = string.Empty;

            //Find first drive
            foreach (DriveInfo compDrive in DriveInfo.GetDrives())
            {
                if (compDrive.IsReady)
                {
                    strDrive = compDrive.RootDirectory.ToString();
                    break;
                }
            }


            if (strDrive.EndsWith(":\\"))
            {
                //C:\ -> C
                strDrive = strDrive.Substring(0, strDrive.Length - 2);
            }

            string volumeSerial = getVolumeSerial(strDrive);
            string cpuID = getCPUID();

            //Mix them up and remove some useless 0's
            return cpuID.Substring(13) + cpuID.Substring(1, 4) + volumeSerial + cpuID.Substring(4, 4);
        }

        private string getVolumeSerial(string drive)
        {
            ManagementObject disk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + drive + @":""");
            disk.Get();

            string volumeSerial = disk["VolumeSerialNumber"].ToString();
            disk.Dispose();

            return volumeSerial;
        }

        private string getCPUID()
        {
            string cpuInfo = "";
            ManagementClass managClass = new ManagementClass("win32_processor");
            ManagementObjectCollection managCollec = managClass.GetInstances();

            foreach (ManagementObject managObj in managCollec)
            {
                if (cpuInfo == "")
                {
                    //Get only the first CPU's ID
                    cpuInfo = managObj.Properties["processorID"].Value.ToString();
                    break;
                }
            }

            return cpuInfo;
        }
    }
}
