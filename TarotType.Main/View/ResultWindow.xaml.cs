using System.Windows;

namespace TarotType.Main.View
{
    public partial class ResultWindow : Window
    {
        private int _wpm;
        private int _numberOfWrongWords;
        private int _numberOfTrueWords;
        private int _numberOfKeyStrokes;

        public ResultWindow(int wpm, int numberOfWrongWords, int numberOfTrueWords, int numberOfKeyStrokes)
        {
            InitializeComponent();
            _wpm = wpm;
            _numberOfWrongWords = numberOfWrongWords;
            _numberOfTrueWords = numberOfTrueWords;
            _numberOfKeyStrokes = numberOfKeyStrokes;

            tBlockWpmResult.Text = _wpm.ToString() + " WPM";

        }


    }
}
