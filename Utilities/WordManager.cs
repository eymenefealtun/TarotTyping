using System.Reflection;

namespace Utilities
{
    public static class WordManager
    {
        
        public static string[] GetRandomWord(int wordPerEachCall = 10)
        {

            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Words\300.000-Words-WithOnlyComma.txt");
            string[] sourceWords = File.ReadAllText(path).Split(',').ToArray();

            string[] resultWordArray = new string[wordPerEachCall];

            Random random = new Random();

            for (int i = 0; i < resultWordArray.Length; i++)
            {
                var number = random.Next(0, sourceWords.Length);
                resultWordArray[i] = sourceWords[number];

            }

            return resultWordArray;

        }
    }
}
