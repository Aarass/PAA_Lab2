using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAA_Lab_2
{
    internal class Levenstain : Algoritam
    {
        public override void Pronadji(string pattern, MyString text, string resultFilePath)
        {
            int[,] tabela = new int[pattern.Length + 1, text.Length + 1];
            for (int i = 0; i < tabela.GetLength(0); i++)
            {
                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    if(j == 0)
                        tabela[i, j] = i;
                    //else if (i == 0)
                    //    tabela[i, j] = j;
                    else
                        tabela[i, j] = 0;
                }
            }

            string result = "";
            for (int i = 1; i < tabela.GetLength(0); i++)
            {
                for (int j = 1; j < tabela.GetLength(1); j++)
                {
                    int cost;
                    if (pattern[i-1] == text[j-1])
                        cost = 0;
                    else
                        cost = 1;


                    int v1 = tabela[i-1, j  ] + 1;
                    int v2 = tabela[i  , j-1] + 1;
                    int v3 = tabela[i-1, j-1] + cost;

                    tabela[i, j] = Math.Min(Math.Min(v1, v2), v3);


                    if (i == tabela.GetLength(0) - 1)
                    {
                        //if (tabela[i, j] == 0)
                        //{
                        //    result += j + 1 - pattern.Length;
                        //    result += '\n';
                        //}
                        if (tabela[i, j] <= 3)
                        {
                            result += j + 1 - pattern.Length;
                            result += " " + tabela[i, j];
                            result += '\n';
                        }
                    }
                }
            }
            //Console.WriteLine(result);
            dumpToFile(resultFilePath, result);
#if false
            Console.Write("   ");
            text.Print();
            for (int i = 0; i < tabela.GetLength(0); i++)
            {
                if (i > 0)
                {
                    Console.Write(pattern[i - 1]);
                    Console.Write(" ");
                }
                else
                    Console.Write("  ");
                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    Console.Write(tabela[i, j]);           
                }
                Console.WriteLine();
            }
#endif
        }
    }
}
