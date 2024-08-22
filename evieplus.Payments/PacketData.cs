using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evieplus.Payments
{
    class PacketData : IDisposable
    {
        // Bitmap: 
        // Bit 0: 1 – ACK to Packet Requested 
        // Bit 1: 1 – Packet encrypted 
        // Bits 2-3: Retry number(0 means 1st transmission)
        // Bit 4: Is Last packet(0 means last) Bits 5-7: RFU
        private byte m_bytePacketOptions = 0;

        // Running identifier of packet. 
        // In case a packet is missing, i.e. 2 consecutive packets sent by the same peripheral have non-consecutive IDs, Amit will reset the specific Peripheral and 
        // this will re-synchronize the communication between Amit and the Peripheral.
        private byte m_bytePackekId = 0;

        // The Amit is always identified by ID 0x00. 
        // Each Peripheral device communicating with Amit performs a pairing process (described below) with Amit, 
        // in order to determine its specific ID. At the 1st communication, the Peripheral device identifies itself by ID 0xFF. 
        // Once a Peripheral device has been assigned an ID by the Amit, it will identify itself with this ID until its next Power Cycle.
        private byte m_byteSource = 0;
        private byte m_byteSourceLsb = 0;
        private byte m_byteDestination = 0;
        private byte m_byteDestinationLsb = 0;

        // Specific Code of Function
        private byte m_byteFunctionCode = 0;

        // Data of Message
        private byte[] m_byteaData = null;

        public PacketData()
        {
        }

        public void Dispose()
        {

        }

        public bool bDecode(byte[] prm_byteaReceivedData)
        {
            int iLength = (int)prm_byteaReceivedData[0];
            iLength += (int)(prm_byteaReceivedData[1] << 8);

            m_bytePacketOptions = prm_byteaReceivedData[2];
            m_bytePackekId = prm_byteaReceivedData[3];
            m_byteSource = prm_byteaReceivedData[4];
            m_byteDestination = prm_byteaReceivedData[6];
            m_byteFunctionCode = prm_byteaReceivedData[8];

            if (iLength > 9)
            {
                m_byteaData = new byte[iLength - 9];
                Array.Copy(prm_byteaReceivedData, 9, m_byteaData, 0, iLength - 9);
            }

            ushort usReceivedCrc = (ushort)prm_byteaReceivedData[iLength];
            usReceivedCrc += (ushort)(prm_byteaReceivedData[iLength + 1] << 8);

            byte[] byteaReceivedDataForCrc = new byte[iLength];
            Array.Copy(prm_byteaReceivedData, 0, byteaReceivedDataForCrc, 0, iLength);

            Crc16 xCrc16 = new Crc16();
            ushort usReceivedCalculatedCrc = xCrc16.usCalculateCrcCcitt(byteaReceivedDataForCrc);

            if (usReceivedCrc != usReceivedCalculatedCrc)
                return false;

            return true;
        }

        public byte[] byteaEncode()
        {
            ushort usLength = 9;

            if (m_byteaData != null)
                usLength += (ushort)m_byteaData.Length;

            byte[] byteaSendData = new byte[usLength + 2];

            int iIndex = 0;

            byteaSendData[iIndex++] = (byte)(usLength & 0x00FF); ;
            byteaSendData[iIndex++] = (byte)((usLength >> 8) & 0x00FF); ;
            byteaSendData[iIndex++] = m_bytePacketOptions;
            byteaSendData[iIndex++] = m_bytePackekId;
            byteaSendData[iIndex++] = m_byteSource;
            byteaSendData[iIndex++] = m_byteSourceLsb;
            byteaSendData[iIndex++] = m_byteDestination;
            byteaSendData[iIndex++] = m_byteDestinationLsb;
            byteaSendData[iIndex++] = m_byteFunctionCode;

            if (m_byteaData != null)
            {
                Array.Copy(m_byteaData, 0, byteaSendData, iIndex, m_byteaData.Length);
                iIndex += m_byteaData.Length;
            }

            byte[] byteaSendDataForCrc = new byte[usLength];
            Array.Copy(byteaSendData, 0, byteaSendDataForCrc, 0, usLength);

            Crc16 xCrc16 = new Crc16();
            ushort usReceivedCalculatedCrc = xCrc16.usCalculateCrcCcitt(byteaSendDataForCrc);

            byteaSendData[iIndex++] = (byte)(usReceivedCalculatedCrc & 0x00FF);
            byteaSendData[iIndex] = (byte)((usReceivedCalculatedCrc >> 8) & 0x00FF);

            return byteaSendData;
        }

        public byte prop_bytePacketOptions
        {
            get
            {
                return m_bytePacketOptions;
            }
            set
            {
                m_bytePacketOptions = value;
            }
        }

        public byte prop_bytePackekId
        {
            get
            {
                return m_bytePackekId;
            }
            set
            {
                m_bytePackekId = value;
            }
        }

        public byte prop_byteSource
        {
            get
            {
                return m_byteSource;
            }
            set
            {
                m_byteSource = value;
            }
        }

        public byte prop_byteSourceLsb
        {
            get
            {
                return m_byteSourceLsb;
            }
            set
            {
                m_byteSourceLsb = value;
            }
        }

        public byte prop_byteDestination
        {
            get
            {
                return m_byteDestination;
            }
            set
            {
                m_byteDestination = value;
            }
        }

        public byte prop_byteDestinationLsb
        {
            get
            {
                return m_byteDestinationLsb;
            }
            set
            {
                m_byteDestinationLsb = value;
            }
        }

        public FunctionsEnum prop_enumFunctionCode
        {
            get
            {
                return (FunctionsEnum)m_byteFunctionCode;
            }
            set
            {
                m_byteFunctionCode = (byte)value;
            }
        }

        public byte prop_byteFunctionCode
        {
            get
            {
                return m_byteFunctionCode;
            }
            set
            {
                m_byteFunctionCode = value;
            }
        }

        public byte[] prop_byteaData
        {
            get
            {
                return m_byteaData;
            }
            set
            {
                m_byteaData = value;
            }
        }
    }
}
