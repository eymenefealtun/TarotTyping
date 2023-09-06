namespace TarotType.Main.Utilities
{
    public static class WordManager
    {
        public static string[] GetRandomWord(int wordPerEachCall)
        {
            string[] resultWordArray = new string[wordPerEachCall];

            for (int i = 0; i < resultWordArray.Length; i++)
                resultWordArray[i] = MainWindow._sourceWords[MainWindow._random.Next(0, MainWindow._sourceWords.Length)];

            return resultWordArray;
        }


    }
}