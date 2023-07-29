using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TypeTrial
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Words\300.000-Words-WithOnlyComma.txt");
            string[] words = File.ReadAllText(path).Split(',').ToArray();




            Random random = new Random();               

            for (int j = 0; j < 2000; j++)          
            {
                for (int i = 0; i < 10; i++)
                {
                    var number = random.Next(0, words.Length);

                    Console.WriteLine(words[number]);

                }

                Console.WriteLine();
                Console.ReadLine();
            }



            Console.ReadLine();
        }



    }
}
