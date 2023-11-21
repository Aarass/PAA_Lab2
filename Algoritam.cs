using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAA_Lab_2
{
    abstract internal class Algoritam
    {
        abstract public void Pronadji(string pattern, MyString text, string resultFile);
        protected void dumpToFile(string path, string s)
        {
            StreamWriter? sw = null;
            try
            {
                sw = new StreamWriter(new FileStream(path, FileMode.Create));
                sw.Write(s);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally { sw?.Close(); }
        }
    }
}
