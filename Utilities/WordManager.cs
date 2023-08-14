namespace Utilities
{           
    public static class WordManager      
    {
        public static string[] GetRandomWord(int wordPerEachCall, string[] sourceWords)
        {
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