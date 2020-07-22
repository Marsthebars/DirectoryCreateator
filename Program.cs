using System;
using System.Collections;
using System.IO;
using System.Threading;

/// <summary>
///
/// </summary>
namespace DirectoryCreator
{
    internal class Program
    {/// <summary>
     ///
     /// </summary>
     /// <param name="args"></param>
        public static void Main(string[] args)
        {
            loadbar();
            string MainPath = AppDomain.CurrentDomain.BaseDirectory;

            string p2 = @"/citnames.txt";

            string cpath = Path.Combine(MainPath + p2);

            int count = File.ReadAllLines(cpath).Length;

            string Intammount = count.ToString();

            bool success = Int32.TryParse(Intammount, out int number);

            if (success)
            {
                ArrayList listAR = new ArrayList(File.ReadAllLines(cpath));
                foreach (var item in listAR)
                {
                    Directory.CreateDirectory(item.ToString());
                    Console.WriteLine("item  name " + item.ToString() + "item location ");
                }
            }

            Console.ReadKey();
        }

        /// <summary>
        ///
        /// </summary>
        private static void loadbar()
        {
            Console.Write("Creating Directories... ");
            using (var progress = new ProgressBar())
            {
                for (int i = 0; i <= 100; i++)
                {
                    progress.Report((double)i / 100);
                    Thread.Sleep(20);
                }
            }
            Console.WriteLine("Done.");
        }
    }
}