using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evieplus.Payments
{
    public class Crc16
    {
        private const ushort m_const_usPolynomial = 0x1021;
        private ushort[] m_usaTable = new ushort[256];
        private ushort m_usInitialValue = 0;
        public Crc16()
        {
            m_usInitialValue = (ushort)0;
            ushort usTemporary, usA;
            for (int i = 0; i < m_usaTable.Length; ++i)
            {
                usTemporary = 0;
                usA = (ushort)(i << 8);
                for (int j = 0; j < 8; ++j)
                {
                    if (((usTemporary ^ usA) & 0x8000) != 0)
                    {
                        usTemporary = (ushort)((usTemporary << 1) ^ m_const_usPolynomial);
                    }
                    else
                    {
                        usTemporary <<= 1;
                    }
                    usA <<= 1;
                }
                m_usaTable[i] = usTemporary;
            }
        }

        public byte[] byteaCalculateCrcCcitt(byte[] prm_baArray)
        {
            ushort usCrc = usCalculateCrcCcitt(prm_baArray);
            return new byte[] { (byte)(usCrc >> 8), (byte)(usCrc & 0x00ff) };
        }

        public ushort usCalculateCrcCcitt(byte[] prm_baBytes)
        {
            ushort usCrc = m_usInitialValue;
            for (int iIndex = 0; iIndex < prm_baBytes.Length; ++iIndex)
            {
                usCrc = (ushort)((usCrc << 8) ^ m_usaTable[((usCrc >> 8) ^ (0xff & prm_baBytes[iIndex]))]);
            }
            return usCrc;
        }
    }
}
