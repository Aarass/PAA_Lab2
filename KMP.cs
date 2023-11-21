using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAA_Lab_2
{
    internal class KMP : Algoritam
    {
        int[] π;
        int c;
        public KMP()
        {
            π = new int[1];
        }
        private void Preprocesiranje(string p)
        {
            π = new int[p.Length+1];
            π[1] = 0;
            int k = 0;
            for (int q = 2; q <= p.Length; q++)
            {
                while (k > 0 && (p[k+1-1] != p[q - 1]))
                    k = π[k];
                if (p[k+1 - 1] == p[q - 1])
                    k++;

                π[q] = k;
            }
            c = 0;
#if false
            Console.Write('|');
            for (int i = 1; i <= p.Length; i++)
            {
                Console.Write(p[i-1]);
                Console.Write('|');

            }
            Console.WriteLine();
            Console.Write('|');
            for (int i = 1; i <= p.Length; i++)
            {
                Console.Write(π[i]);
                Console.Write('|');
            }
            Console.WriteLine();
#endif
        }
        public override void Pronadji(string p, MyString t, string resultFilePath)
        {
            string result = "";
            Preprocesiranje(p);
            for(int i = 1; i <= t.Length; i++)
            {
                char s1 = p[c + 1 - 1];
                char s2 = t[i - 1];
                while (c > 0 && (p[c+1 - 1] != t[i - 1]))
                    c = π[c];

                if (p[c+1 - 1] == t[i - 1])
                    c++;

                if(c == p.Length)
                {
                    result += i + 1 - p.Length;
                    result += '\n';
                    //Console.WriteLine($"Pattern occur with shift {i + 1 - p.Length}");
                    c = π[c];
                }
            }
            //Console.WriteLine(result);
            dumpToFile(resultFilePath, result);
        }
    }
}
