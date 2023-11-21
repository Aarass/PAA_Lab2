using System.Diagnostics;
using System.Text;

namespace PAA_Lab_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //new HexFileMaker().MakeHexFile("C:\\Users\\proko\\source\\repos\\PAA_Lab_2\\Src\\/100.hex", 100);
            //new HexFileMaker().MakeHexFile("C:\\Users\\proko\\source\\repos\\PAA_Lab_2\\Src\\/1000.hex", 1000);
            //new HexFileMaker().MakeHexFile("C:\\Users\\proko\\source\\repos\\PAA_Lab_2\\Src\\/10000.hex", 10000);
            //new HexFileMaker().MakeHexFile("C:\\Users\\proko\\source\\repos\\PAA_Lab_2\\Src\\/100000.hex", 100000);
            //return;

            string pathsToStrings = "C:\\Users\\proko\\source\\repos\\PAA_Lab_2\\Src\\";
            string pathsToResults = "C:\\Users\\proko\\source\\repos\\PAA_Lab_2\\Res\\";

            int[] stringSizes = { 100, 1000, 10000, 100000 };
            Algoritam[] algoritmi =
            {
                new KMP(),
                new Levenstain()
            };

            Stopwatch stopwatch = new Stopwatch();
            foreach (Algoritam algoritam in algoritmi)
            {
                //string pattern = "phare";
                //string pattern = "pharetra m";
                //string pattern = "pharetra maximus urna";
                string pattern = "Nulla vehicula, lectus non volutpat fringilla, enim";
                foreach (int n in stringSizes)
                {
                    string source = pathsToStrings + n + ".txt";
                    string name = "Normal_" + algoritam.GetType().Name + "_" + n;
                    string dest = pathsToResults + name + ".txt";

                    stopwatch.Restart();
                    algoritam.Pronadji(pattern, new MyString256(source), dest);
                    stopwatch.Stop();

                    Console.WriteLine(name);
                    printTime(stopwatch.Elapsed);
                }
            }
            foreach (Algoritam algoritam in algoritmi)
            {
                //string pattern = "15265";
                //string pattern = "15265D4EDE";
                //string pattern = "15265D4EDE362923109F";
                string pattern = "15265D4EDE362923109F2454CCD9E0C13674C8929E338BB6";
                foreach (int n in stringSizes)
                {
                    string source = pathsToStrings + n + ".hex";
                    string name = "Hex_" + algoritam.GetType().Name + "_" + n;
                    string dest = pathsToResults + name + ".txt";

                    stopwatch.Restart();
                    algoritam.Pronadji(pattern, new MyString16(source), dest);
                    stopwatch.Stop();

                    Console.WriteLine(name);
                    printTime(stopwatch.Elapsed);
                }
            }
        }
        static void printTime(TimeSpan ts)
        {
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds);
            Console.WriteLine(elapsedTime);
        }
    }
}