using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAA_Lab_2
{
    internal class MyString16 : MyString
    {
        private int m_Length;
        private byte[] m_Data;
        public MyString16(string path)
        {
            FileStream? fs = null;
            try
            {
                fs = new FileStream(path, FileMode.Open);

                m_Length = (int) fs.Length;
                m_Data = new byte[fs.Length];

                fs.Read(m_Data, 0, m_Data.Length);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { fs?.Close(); }

            //for (int i = 0; i < m_Length; i++)
            //{
            //    Console.Write(Conversion.Hex(m_Data[i]));
            //    Console.Write(' ');
            //}
            //Console.WriteLine();

            //for (int i = 0; i < this.Length; i++)
            //{
            //    char c = this[i];
            //    Console.Write(c);
            //    Console.Write(' ');
            //}
            //Console.WriteLine();
        }

        public override char this[int index]
        {
            get
            {
                int i = index / 2;
                int j = index % 2;

                byte b;
                if (j == 0)
                    b = (byte)(m_Data[i] >> 4);
                else
                    b = (byte)(m_Data[i] & 0b00001111);

                return Conversion.Hex(b)[0];
            }
        }
        public override int Length
        {
            get
            {
                return m_Length * 2;
            }
        }
    }
}
