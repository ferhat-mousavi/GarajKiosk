using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evieplus.Payments
{
    enum FunctionsEnum
    {
        Response = 0x00, // Amit <> Peripheral - Contains ACK / NAK response to message.
        Reset = 0x01, // Amit ➔ Peripheral - To Software reset the Peripheral.
        FirmwareInfo = 0x05, // Peripheral ➔ Amit - Contains specific FW details of Peripheral.
        Config = 0x06, // Amit ➔ Peripheral - Set parameters for communication. Sent as a response to the FirmwareInfo() function.
        KeepAlive = 0x07, // Peripheral ➔ Amit - Indication that the Peripheral is connected. Sent every X mSec (default is 1 second), if no activity. i.e. not a during transaction nor during communication.
        DisplayMessage = 0x08, // Amit ➔ Peripheral - Display Message on Peripheral’s LCD.
        DisplayMessageStatus = 0x09, // Peripheral ➔ Amit - A response to the DisplayMessage() function.
        TransferData = 0x0A, // Amit <> Peripheral - Transfer specific data. Specific data in TLV mode.
        Status = 0x0B, // Amit <> Peripheral - Status message.
        GetTime = 0x0C, // Peripheral ➔ Amit - Retrieve Current Time data.
        Time = 0x0D, // Amit ➔ Peripheral - Time.
        SetPeripheralParameter = 0x0E, // Amit ➔ Peripheral - Set peripheral parameter as set in DCS Nayax’ back office. Parameters in TLV mode.
        SetPaymentParameters = 0x0F, // Amit ➔ Peripheral - Set specific Payment Parameters required in order to process the Transaction vs. their own Acquirer or PSP. Parameters are defined in DCS Nayax’ back office. Specific data in TLV mode.
        ModemStatus = 0x20, // Amit ➔ Peripheral - This is a response to all modem commands.
        OpenSocket = 0x21, // Peripheral ➔ Amit - Open a socket for communication with a server.
        CloseSocket = 0x22, // Peripheral ➔ Amit - Close the socket.
        SendData = 0x23, // Peripheral ➔ Amit - Send Data message to the opened socket.
        ReceiveData = 0x024, // Amit ➔ Peripheral - Amit will send the data received from the opened socket.
        ModemRxControl = 0x25, // Peripheral ➔ Amit - Used for flow control: Peripheral can pause/resume the Modem’s activity while receiving data.
        Trace = 0x30, // Peripheral ➔ Amit - Send Trace parameters to Amit. The Peripheral’s Trace will be inserted within the existing Nayax’ “GTrace”.
        Alert = 0x31, // Peripheral ➔ Amit - Send Alert to Amit. Alert can be forwarded to Nayax’ server.
        GetFileVersion = 0x32, // Amit ➔ Peripheral - Get file version.
        FilleVersion = 0x33, // Peripheral ➔ Amit - File version.
        SendFile = 0x34, // Amit ➔ Peripheral - Send file/file header from Amit.
        CheckFileCrc = 0x35, // Amit <> Peripheral - Check File Crc16 and return status.
        PosalFwUpdate = 0x36, // Amit ➔ Peripheral - POSAL FW update.
        MdbCommand = 0x80, // Peripheral <> Amit - Pass MDB standard command. MDB Poll interval is defined as “Keep Alive” interval parameter of the Config() function.

    }
}
