namespace TarotType.Main.Utilities
{
    public class WordManager
    {
        static string[] _resultWordArray;

        public WordManager(int wordPerEachCall)
        {
            _resultWordArray = new string[wordPerEachCall];
        }

        public WordManager()
        {

        }

        public static string[] GetRandomWord()
        {
            if (MainWindow._anotherArray == false)
                for (int i = 0; i < _resultWordArray.Length; i++)
                    _resultWordArray[i] = MainWindow._sourceWords[MainWindow._random.Next(0, MainWindow._sourceWords.Length)];
            else
                for (int i = 0; i < _resultWordArray.Length; i++)
                    _resultWordArray[i] = MainWindow._secondSourceWords[MainWindow._random.Next(0, MainWindow._secondSourceWords.Length)];

            return _resultWordArray;
        }


    }
}