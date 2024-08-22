using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using evieplus.CommonLibrary;
using evieplus.Models;

namespace evieplus.Payments
{
    public class NayaxMarshall
    {
        byte m_bytePeripheralId = 0;
        byte[] m_byteaPeripheraModel = new byte[16];
        byte[] m_byteaPeripheraSwVersion = new byte[16];
        byte[] m_byteaPeripheraSerialNumber = new byte[16];
        byte[] m_byteaAmitSerialNumber = new byte[16];
        byte m_bytePackekId = 0;
        byte m_byteLastReceivedPackekId = 0;
        private int m_iTimeOutMilliseconds = 5000; // defaul value is 5 seconds

        public NayaxMarshall()
        {
        }

        bool bPairing()
        {
            bool bReturnValue = false;

            DateTime dtTimeOut = DateTime.Now.AddMilliseconds(m_iTimeOutMilliseconds);

            while (!bReturnValue && DateTime.Now < dtTimeOut)
                for (int iMessageCount = 0; iMessageCount < 2 && !bReturnValue; iMessageCount++)
                {
                    PacketData xRecievedPacketData = SerialCommunication.xGetInstance().xGetPacketData();
                    PacketData xSendPacketData = new PacketData();

                    if (xRecievedPacketData == null)
                        continue;

                    m_byteLastReceivedPackekId = xRecievedPacketData.prop_bytePackekId;

                    switch (xRecievedPacketData.prop_enumFunctionCode)
                    {
                        case FunctionsEnum.Reset:
                            m_bytePackekId = 0;
                            iMessageCount = 1;
                            m_byteaPeripheraModel = CommonProperty.prop_strApplicationName.GetAsciiByteArray();
                            m_byteaPeripheraSerialNumber = VolumeSerial.xGetInstance().strGetUniqueId().GetAsciiByteArray();
                            m_byteaPeripheraSwVersion = CommonProperty.prop_strApplicationVersion.GetAsciiByteArray();

                            xSendPacketData.prop_bytePacketOptions = 0;
                            xSendPacketData.prop_bytePackekId = m_bytePackekId++;
                            xSendPacketData.prop_byteSource = 0x01;
                            xSendPacketData.prop_byteSourceLsb = m_byteaPeripheraSerialNumber[0];
                            xSendPacketData.prop_byteDestination = 0;
                            xSendPacketData.prop_enumFunctionCode = FunctionsEnum.FirmwareInfo;

                            xSendPacketData.prop_byteaData = new byte[66];
                            xSendPacketData.prop_byteaData[0] = 0x02; // Protocol Version
                            xSendPacketData.prop_byteaData[1] = 0x00; // Protocol Version
                            xSendPacketData.prop_byteaData[2] = 0x08; // Peripheral Type
                            xSendPacketData.prop_byteaData[3] = 0x01; // Peripheral SubType
                            xSendPacketData.prop_byteaData[4] = 0x00; // Peripheral Capabilities bitmap
                            xSendPacketData.prop_byteaData[5] = 0x00; // Peripheral Capabilities bitmap

                            Array.Copy(m_byteaPeripheraModel, 0, xSendPacketData.prop_byteaData, 6, m_byteaPeripheraModel.Length);
                            Array.Copy(m_byteaPeripheraSerialNumber, 0, xSendPacketData.prop_byteaData, 26, m_byteaPeripheraSerialNumber.Length);
                            Array.Copy(m_byteaPeripheraSwVersion, 0, xSendPacketData.prop_byteaData, 46, m_byteaPeripheraSwVersion.Length);

                            SerialCommunication.xGetInstance().bSendPacketData(xSendPacketData);

                            break;
                        case FunctionsEnum.Config:
                            m_bytePeripheralId = xRecievedPacketData.prop_byteaData[2];
                            Array.Copy(xRecievedPacketData.prop_byteaData, 15, m_byteaAmitSerialNumber, 0, m_byteaAmitSerialNumber.Length);

                            xSendPacketData.prop_bytePacketOptions = 0x01;
                            xSendPacketData.prop_bytePackekId = m_bytePackekId++;
                            xSendPacketData.prop_byteSource = m_bytePeripheralId;
                            xSendPacketData.prop_byteSourceLsb = m_byteaPeripheraSerialNumber[0];
                            xSendPacketData.prop_byteDestination = 0;
                            xSendPacketData.prop_byteDestinationLsb = m_byteaAmitSerialNumber[0];
                            xSendPacketData.prop_enumFunctionCode = FunctionsEnum.KeepAlive;

                            bReturnValue = SerialCommunication.xGetInstance().bSendPacketData(xSendPacketData);

                            break;
                    }
                }

            return bReturnValue;
        }

        public AuthorizationModel xTransaction(int prm_iPrice, int prm_iItemCode, int prm_iTimeOutMilliseconds = 300000)
        {
            AuthorizationModel xAuthorizationModel = new AuthorizationModel();
            try
            {
                bool bCommandeReturnValue = false;
                SendLastMdbCommand enumSendLastMdbCommand = SendLastMdbCommand.None;
                DateTime dtTimeOut = DateTime.Now.AddMilliseconds(prm_iTimeOutMilliseconds);
                DateTime dtKeepAlive = DateTime.Now.AddMilliseconds(800);
                int iFundsAvailable = 0;

                bool bPairingStatus = bPairing();

                while (!xAuthorizationModel.bProcessStatus && DateTime.Now < dtTimeOut & bPairingStatus)
                {
                    PacketData xRecievedPacketData = SerialCommunication.xGetInstance().xGetPacketData();
                    PacketData xSendPacketData = new PacketData();

                    if (xRecievedPacketData == null && DateTime.Now > dtKeepAlive && bPairingStatus)
                    {
                        bCommandeReturnValue = bSendKeepAlive();
                        dtKeepAlive = DateTime.Now.AddMilliseconds(800);
                        continue;
                    }
                    else if (xRecievedPacketData == null)
                        continue;

                    m_byteLastReceivedPackekId = xRecievedPacketData.prop_bytePackekId;

                    if ((xRecievedPacketData.prop_bytePacketOptions & 0x01) == 0x01)
                        bCommandeReturnValue = bSendAck();

                    switch (xRecievedPacketData.prop_enumFunctionCode)
                    {
                        //case FunctionsEnum.Reset:
                        //    if ((bPairingStatus = bPairing()) == true)
                        //    {
                        //        bCommandeReturnValue = bSendReaderEnable();
                        //        enumSendLastMdbCommand = SendLastMdbCommand.ReaderEnable;
                        //    }
                        //    break;
                        case FunctionsEnum.MdbCommand:
                            switch (xRecievedPacketData.prop_byteaData[0])
                            {
                                case 0x03: // Begin Session
                                    iFundsAvailable = (int)xRecievedPacketData.prop_byteaData[1];
                                    iFundsAvailable += (int)(xRecievedPacketData.prop_byteaData[2] << 8);
                                    bCommandeReturnValue = bSendVendRequest(prm_iPrice, prm_iItemCode);
                                    enumSendLastMdbCommand = SendLastMdbCommand.VendRequest;
                                    break;
                                case 0x05: // Vend Approve
                                    if (enumSendLastMdbCommand == SendLastMdbCommand.VendSuccess)
                                    {
                                        bCommandeReturnValue = bSendSessionComplete();
                                        enumSendLastMdbCommand = SendLastMdbCommand.SessionComplete;
                                    }
                                    else
                                    {
                                        bCommandeReturnValue = bSendVendSuccess();
                                        enumSendLastMdbCommand = SendLastMdbCommand.VendSuccess;
                                        xAuthorizationModel.bAuthorizationResultStatus = true;
                                    }
                                    break;
                                case 0x06: // Vend Denied
                                    bCommandeReturnValue = bSendSessionComplete();
                                    enumSendLastMdbCommand = SendLastMdbCommand.SessionComplete;
                                    xAuthorizationModel.bAuthorizationResultStatus = false;
                                    break;
                                case 0x07: // End Session
                                    bCommandeReturnValue = bSendReaderDisable();
                                    enumSendLastMdbCommand = SendLastMdbCommand.ReaderDisable;
                                    xAuthorizationModel.bProcessStatus = true;
                                    break;
                            }
                            break;
                        case FunctionsEnum.Response:
                            if (enumSendLastMdbCommand == SendLastMdbCommand.None && bPairingStatus)
                            {
                                bCommandeReturnValue = bSendReaderEnable();
                                enumSendLastMdbCommand = SendLastMdbCommand.ReaderEnable;
                            }
                            else if (enumSendLastMdbCommand == SendLastMdbCommand.VendSuccess)
                            {
                                bCommandeReturnValue = bSendSessionComplete();
                                enumSendLastMdbCommand = SendLastMdbCommand.SessionComplete;
                            }
                            else if (DateTime.Now > dtKeepAlive && bPairingStatus)
                            {
                                bCommandeReturnValue = bSendKeepAlive();
                                dtKeepAlive = DateTime.Now.AddMilliseconds(800);
                            }
                            break;
                    }
                }
            }
            catch(Exception xException)
            {
                xException.strTraceError();
            }

            return xAuthorizationModel;
        }

        bool bSendKeepAlive()
        {
            bool bReturnValue = false;

            PacketData xSendPacketData = new PacketData();

            xSendPacketData.prop_bytePacketOptions = 0x01;
            xSendPacketData.prop_bytePackekId = m_bytePackekId++;
            xSendPacketData.prop_byteSource = m_bytePeripheralId;
            xSendPacketData.prop_byteSourceLsb = m_byteaPeripheraSerialNumber[0];
            xSendPacketData.prop_byteDestination = 0;
            xSendPacketData.prop_byteDestinationLsb = m_byteaAmitSerialNumber[0];
            xSendPacketData.prop_enumFunctionCode = FunctionsEnum.KeepAlive;

            bReturnValue = SerialCommunication.xGetInstance().bSendPacketData(xSendPacketData);

            return bReturnValue;
        }

        bool bSendReaderEnable()
        {
            bool bReturnValue = false;

            PacketData xSendPacketData = new PacketData();

            xSendPacketData.prop_bytePacketOptions = 0x01;
            xSendPacketData.prop_bytePackekId = m_bytePackekId++;
            xSendPacketData.prop_byteSource = m_bytePeripheralId;
            xSendPacketData.prop_byteSourceLsb = m_byteaPeripheraSerialNumber[0];
            xSendPacketData.prop_byteDestination = 0;
            xSendPacketData.prop_byteDestinationLsb = m_byteaAmitSerialNumber[0];
            xSendPacketData.prop_enumFunctionCode = FunctionsEnum.MdbCommand;

            xSendPacketData.prop_byteaData = new byte[2];
            xSendPacketData.prop_byteaData[0] = 0x14; // Reader
            xSendPacketData.prop_byteaData[1] = 0x01; // Reader Enable

            bReturnValue = SerialCommunication.xGetInstance().bSendPacketData(xSendPacketData);

            return bReturnValue;
        }

        bool bSendReaderDisable()
        {
            bool bReturnValue = false;

            PacketData xSendPacketData = new PacketData();

            xSendPacketData.prop_bytePacketOptions = 0x01;
            xSendPacketData.prop_bytePackekId = m_bytePackekId++;
            xSendPacketData.prop_byteSource = m_bytePeripheralId;
            xSendPacketData.prop_byteSourceLsb = m_byteaPeripheraSerialNumber[0];
            xSendPacketData.prop_byteDestination = 0;
            xSendPacketData.prop_byteDestinationLsb = m_byteaAmitSerialNumber[0];
            xSendPacketData.prop_enumFunctionCode = FunctionsEnum.MdbCommand;

            xSendPacketData.prop_byteaData = new byte[2];
            xSendPacketData.prop_byteaData[0] = 0x14; // Reader
            xSendPacketData.prop_byteaData[1] = 0x00; // Reader Disable

            bReturnValue = SerialCommunication.xGetInstance().bSendPacketData(xSendPacketData);

            return bReturnValue;
        }

        bool bSendVendRequest(int prm_iPrice, int prm_iItemCode)
        {
            bool bReturnValue = false;

            PacketData xSendPacketData = new PacketData();

            xSendPacketData.prop_bytePacketOptions = 0x01;
            xSendPacketData.prop_bytePackekId = m_bytePackekId++;
            xSendPacketData.prop_byteSource = m_bytePeripheralId;
            xSendPacketData.prop_byteSourceLsb = m_byteaPeripheraSerialNumber[0];
            xSendPacketData.prop_byteDestination = 0;
            xSendPacketData.prop_byteDestinationLsb = m_byteaAmitSerialNumber[0];
            xSendPacketData.prop_enumFunctionCode = FunctionsEnum.MdbCommand;

            xSendPacketData.prop_byteaData = new byte[6];
            xSendPacketData.prop_byteaData[0] = 0x13; // Vend
            xSendPacketData.prop_byteaData[1] = 0x00; // Vend Request
            xSendPacketData.prop_byteaData[2] = (byte)(prm_iPrice & 0x00FF); // Price
            xSendPacketData.prop_byteaData[3] = (byte)((prm_iPrice >> 8) & 0x00FF); // Price
            xSendPacketData.prop_byteaData[4] = (byte)(prm_iItemCode & 0x00FF); // Item Code
            xSendPacketData.prop_byteaData[5] = (byte)((prm_iItemCode >> 8) & 0x00FF); // Item Code

            bReturnValue = SerialCommunication.xGetInstance().bSendPacketData(xSendPacketData);

            return bReturnValue;
        }

        bool bSendVendSuccess()
        {
            bool bReturnValue = false;

            PacketData xSendPacketData = new PacketData();

            xSendPacketData.prop_bytePacketOptions = 0x01;
            xSendPacketData.prop_bytePackekId = m_bytePackekId++;
            xSendPacketData.prop_byteSource = m_bytePeripheralId;
            xSendPacketData.prop_byteSourceLsb = m_byteaPeripheraSerialNumber[0];
            xSendPacketData.prop_byteDestination = 0;
            xSendPacketData.prop_byteDestinationLsb = m_byteaAmitSerialNumber[0];
            xSendPacketData.prop_enumFunctionCode = FunctionsEnum.MdbCommand;

            xSendPacketData.prop_byteaData = new byte[2];
            xSendPacketData.prop_byteaData[0] = 0x13; // Vend
            xSendPacketData.prop_byteaData[1] = 0x02; // Vend Success

            bReturnValue = SerialCommunication.xGetInstance().bSendPacketData(xSendPacketData);

            return bReturnValue;
        }

        bool bSendVendFailure()
        {
            bool bReturnValue = false;

            PacketData xSendPacketData = new PacketData();

            xSendPacketData.prop_bytePacketOptions = 0x01;
            xSendPacketData.prop_bytePackekId = m_bytePackekId++;
            xSendPacketData.prop_byteSource = m_bytePeripheralId;
            xSendPacketData.prop_byteSourceLsb = m_byteaPeripheraSerialNumber[0];
            xSendPacketData.prop_byteDestination = 0;
            xSendPacketData.prop_byteDestinationLsb = m_byteaAmitSerialNumber[0];
            xSendPacketData.prop_enumFunctionCode = FunctionsEnum.MdbCommand;

            xSendPacketData.prop_byteaData = new byte[2];
            xSendPacketData.prop_byteaData[0] = 0x13; // Vend
            xSendPacketData.prop_byteaData[1] = 0x03; // Vend Failure

            bReturnValue = SerialCommunication.xGetInstance().bSendPacketData(xSendPacketData);

            return bReturnValue;
        }

        bool bSendSessionComplete()
        {
            bool bReturnValue = false;

            PacketData xSendPacketData = new PacketData();

            xSendPacketData.prop_bytePacketOptions = 0x01;
            xSendPacketData.prop_bytePackekId = m_bytePackekId++;
            xSendPacketData.prop_byteSource = m_bytePeripheralId;
            xSendPacketData.prop_byteSourceLsb = m_byteaPeripheraSerialNumber[0];
            xSendPacketData.prop_byteDestination = 0;
            xSendPacketData.prop_byteDestinationLsb = m_byteaAmitSerialNumber[0];
            xSendPacketData.prop_enumFunctionCode = FunctionsEnum.MdbCommand;

            xSendPacketData.prop_byteaData = new byte[2];
            xSendPacketData.prop_byteaData[0] = 0x13; // Vend
            xSendPacketData.prop_byteaData[1] = 0x04; // Session Complete

            bReturnValue = SerialCommunication.xGetInstance().bSendPacketData(xSendPacketData);

            return bReturnValue;
        }

        bool bSendTransferData()
        {
            bool bReturnValue = false;

            PacketData xSendPacketData = new PacketData();

            xSendPacketData.prop_bytePacketOptions = 0x01;
            xSendPacketData.prop_bytePackekId = m_bytePackekId++;
            xSendPacketData.prop_byteSource = m_bytePeripheralId;
            xSendPacketData.prop_byteSourceLsb = m_byteaPeripheraSerialNumber[0];
            xSendPacketData.prop_byteDestination = 0;
            xSendPacketData.prop_byteDestinationLsb = m_byteaAmitSerialNumber[0];
            xSendPacketData.prop_enumFunctionCode = FunctionsEnum.TransferData;

            xSendPacketData.prop_byteaData = new byte[22];
            xSendPacketData.prop_byteaData[0] = 0x01; // TAG
            xSendPacketData.prop_byteaData[1] = 0x14; // LENGTH

            bReturnValue = SerialCommunication.xGetInstance().bSendPacketData(xSendPacketData);

            return bReturnValue;
        }

        bool bSendAck()
        {
            bool bReturnValue = false;

            PacketData xSendPacketData = new PacketData();

            xSendPacketData.prop_bytePacketOptions = 0x00;
            xSendPacketData.prop_bytePackekId = m_byteLastReceivedPackekId;
            xSendPacketData.prop_byteSource = m_bytePeripheralId;
            xSendPacketData.prop_byteSourceLsb = m_byteaPeripheraSerialNumber[0];
            xSendPacketData.prop_byteDestination = 0;
            xSendPacketData.prop_byteDestinationLsb = m_byteaAmitSerialNumber[0];
            xSendPacketData.prop_enumFunctionCode = FunctionsEnum.Response;

            xSendPacketData.prop_byteaData = new byte[1];
            xSendPacketData.prop_byteaData[0] = 0x00; // ACK

            bReturnValue = SerialCommunication.xGetInstance().bSendPacketData(xSendPacketData);

            return bReturnValue;
        }

        enum SendLastMdbCommand
        {
            None,
            ReaderEnable,
            VendRequest,
            VendSuccess,
            SessionComplete,
            ReaderDisable,
        }

        enum ReceivedLastMdbCommand
        {
            None,
            BeginSession,
            VendApprove,
            EndSession,
        }
    }
}
