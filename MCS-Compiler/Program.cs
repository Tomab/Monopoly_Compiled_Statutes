using System;
using System.IO;
using System.Text.RegularExpressions;

namespace MCS_Compiler
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Scblieter Systems - Monopoly Compiled Statutes - Compiler v0.2");


            StreamReader sr = new StreamReader("../Version");
            String version = sr.ReadToEnd();
            sr.Close();

            String AllText = "<h1>Monopoly Compiled Statutes - " + version + "</h1>";

            foreach ( var file in Directory.EnumerateFiles("../", "*.txt"))
            {
                sr = new StreamReader(file);
                AllText += sr.ReadToEnd();
                sr.Close();
            }
            AllText = Regex.Replace(AllText, "((MCS )[0-9]*[A-Z \\-]{2,})", "<br><b>$1</b>");
            AllText = Regex.Replace(AllText, "\\n", "<br>");
            AllText = Regex.Replace(AllText, "(\\t\\([a-z\\-0-9]*\\))", "&emsp;&emsp;$1");
            AllText = Regex.Replace(AllText, "\\t", "&emsp;");            
            AllText = Regex.Replace(AllText, "(Sec. [0-9]*-[0-9]*)", "<b>$1</b>");

            StreamWriter sw = new StreamWriter(@"..\output\MCS" + version + ".html");
            sw.Write(AllText);
            sw.Close();

            Console.WriteLine("A file has been generated at " + @"..\output\MCS" + version + ".html");

            System.Diagnostics.Process.Start(@"cmd.exe ", @"/c ..\output\MCS" + version + ".html");


            Console.WriteLine("Press <ENTER> to exit.");
            Console.ReadLine();
        }
    }
}
