using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PAA_Lab_2
{
    internal class MyString256 : MyString
    {
        private string m_Data;
        public MyString256(string path)
        {
            StreamReader? sr = null;
            try
            {
                sr = new StreamReader(new FileStream(path, FileMode.Open), false);
                m_Data = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally { sr?.Close(); }
        }


        public override char this[int index]
        {
            get
            {
                return m_Data[index];
            }
        }
        public override int Length 
        {
            get
            {
                return m_Data.Length;
            }
        }
    }
}
