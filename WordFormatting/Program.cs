using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WordFormatting
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\txt";
            openFileDialog.Filter = "Text Files Only (*.txt) | *.txt";
            openFileDialog.DefaultExt = "txt";


            var stringBuilder = new StringBuilder();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                using (StreamReader streamReader = new StreamReader(openFileDialog.FileName))
                {
                    //for (int i = 0; i < File.ReadLines(openFileDialog.FileName).Count(); i++)           
                    for (int i = 0; i < 300000; i++)           
                    {
                        stringBuilder.Append($"{streamReader.ReadLine()},");
                        //stringBuilder.Append($"\"{streamReader.ReadLine()}\" , ");
                        if (i%100 == 0)
                        {
                            Console.Clear();
                            Console.WriteLine(i);
                        }
                        
                    }
                }

                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            }


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = @"C:\txt";
            saveFileDialog.Filter = "Text Files Only (*.txt) | *.txt";
            saveFileDialog.DefaultExt = "txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream stream = File.Open(saveFileDialog.FileName, FileMode.CreateNew))
                using (StreamWriter streamWriter = new StreamWriter(stream))
                {
                    streamWriter.WriteLine(stringBuilder);          
                }
            }





            Console.ReadLine();
        }
    }
}
