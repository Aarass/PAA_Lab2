using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAA_Lab_2
{
    internal class HexFileMaker
    {
        public void MakeHexFile(string destintaion, int n)
        {
            FileStream? fs = null;
            try
            {
                fs = new FileStream(destintaion, FileMode.Create);

                //string tmp = "";
                Random rnd = new Random();
                for (int i = 0; i < n; i += 2)
                {
                    byte r1 = (byte)rnd.Next(16);
                    byte r2 = (byte)rnd.Next(16);

                    byte b = 0;
                    b += r1;
                    b <<= 4;
                    b += r2;

                    fs.WriteByte(b);

                    //tmp += $"{Conversion.Hex(r1)} {Conversion.Hex(r2)} ";
                }

                //Console.WriteLine(tmp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                fs?.Close();
            }
        }
    }
}
