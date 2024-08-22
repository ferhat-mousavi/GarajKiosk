using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Threading;

using evieplus.CommonLibrary;

namespace evieplus.Payments
{
    class SerialCommunication : IDisposable
    {
        private static SerialCommunication m_xGlobalsInstance = null;
        private SerialPort m_xSerialPort = null;
        private int m_iTimeOutMilliseconds = 200; 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prm_iTimeOutMilliseconds">Defaul value is 5 seconds in milliseconds (5000)</param>
        public SerialCommunication(int prm_iTimeOutMilliseconds = 5000)
        {
            if (m_xSerialPort == null)
            {
                m_xSerialPort = new SerialPort(CommonProperty.prop_strNayaxPort, 115200, Parity.None, 8, StopBits.One);
                m_xSerialPort.ReadTimeout = 100;
                m_xSerialPort.WriteTimeout = 10000;
                m_xSerialPort.WriteBufferSize = 4096;
                m_xSerialPort.ReadBufferSize = 4096;
                m_xSerialPort.Handshake = Handshake.None;
                m_xSerialPort.DtrEnable = true;
                m_xSerialPort.Open();
            }

            m_iTimeOutMilliseconds = prm_iTimeOutMilliseconds;
        }

        public static SerialCommunication xGetInstance(int prm_iTimeOutMilliseconds = 200)
        {
            if (m_xGlobalsInstance == null)
            {
                m_xGlobalsInstance = new SerialCommunication(prm_iTimeOutMilliseconds);
            }

            return m_xGlobalsInstance;
        }

        public void Dispose()
        {
            if (m_xSerialPort != null)
            {
                try
                {
                    if (m_xSerialPort.IsOpen)
                        m_xSerialPort.Close();
                }
                catch
                {
                    // no handling of the exception
                }
            }
        }

        private void vOpen()
        {
            if (m_xSerialPort.IsOpen == false)
            {
                m_xSerialPort.Open();
            }
        }

        private void vClearReadBuffer()
        {
            if (m_xSerialPort.IsOpen == false)
                return;

            while (m_xSerialPort.BytesToRead != 0)
            {
                m_xSerialPort.DiscardInBuffer();
            }
        }

        private void vClearWriteBuffer()
        {
            if (m_xSerialPort.IsOpen == false)
                return;

            m_xSerialPort.DiscardOutBuffer();

            if (m_xSerialPort.BytesToWrite == 0)
                return;

            if (m_xSerialPort.BytesToWrite > 0)
                m_xSerialPort.DiscardOutBuffer();
        }

        private bool bWriteByte(byte prm_byteData)
        {
            DateTime dtTimeOut = DateTime.Now.AddMilliseconds(m_iTimeOutMilliseconds);
            byte[] byteaData = new byte[1];
            byteaData[0] = prm_byteData;
            bool bMessageWriteSucceeded = true;

            m_xSerialPort.Write(byteaData, 0, 1);

            while (m_xSerialPort.BytesToWrite > 0)
            {
                Thread.Sleep(20);

                if (DateTime.Now > dtTimeOut)
                {
                    bMessageWriteSucceeded = false;
                    break;
                }
            }

            return bMessageWriteSucceeded;
        }

        private byte byteReadByte()
        {
            DateTime xDateTimeOut = DateTime.Now.AddMilliseconds(m_iTimeOutMilliseconds);

            do
            {
                if (m_xSerialPort.BytesToRead > 0)
                {
                    return (byte)m_xSerialPort.ReadByte();
                }
            } while (DateTime.Now < xDateTimeOut);

            throw new System.TimeoutException();
        }

        public PacketData xGetPacketData()
        {
            PacketData xPacketData = new PacketData();
            byte[] byteaReceivedData = new byte[2];

            vOpen();
            vClearReadBuffer();

            try
            {

                byteaReceivedData[0] = byteReadByte();
                byteaReceivedData[1] = byteReadByte();
                int iLength = (int)byteaReceivedData[0];
                iLength += (int)(byteaReceivedData[1] << 8);

                Array.Resize<byte>(ref byteaReceivedData, iLength + 2);

                if (m_xSerialPort.BytesToRead != 0)
                    for (int iReadBufferCount = 2; iReadBufferCount < iLength + 2; iReadBufferCount++)
                        byteaReceivedData[iReadBufferCount] = byteReadByte();

                byteaReceivedData.strTraceDump("GET");

                xPacketData.bDecode(byteaReceivedData);
            }
            catch
            {
                xPacketData = null;
            }

            return xPacketData;
        }

        public bool bSendPacketData(PacketData prm_xPacketData)
        {
            byte[] byteaSendData = prm_xPacketData.byteaEncode();

            vOpen();

            // Make sure that Send buffer is empty
            vClearWriteBuffer();

            m_xSerialPort.Write(byteaSendData, 0, byteaSendData.Length);

            byteaSendData.strTraceDump("SEND");

            DateTime dtTimeOut = DateTime.Now.AddMilliseconds(m_iTimeOutMilliseconds);
            bool bMessageSendSucceeded = true;

            // wait for send buffer to be empty or time out elapses
            while (m_xSerialPort.BytesToWrite != 0)
            {
                Thread.Sleep(20);

                if (DateTime.Now > dtTimeOut)
                {
                    bMessageSendSucceeded = false;
                    break;
                }
            }

            return bMessageSendSucceeded;
        }
    }
}
