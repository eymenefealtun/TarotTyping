using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace TarotType.Main.View
{
    public partial class ResultWindow : Window
    {
        int _wpm;
        int _numberOfWrongWords;
        int _numberOfTrueWords;
        int _numberOfKeyStrokes;
        int _numberOfTrueKeyStroke;
        int _numberOfFalseKeyStroke;

        public ResultWindow(int wpm, int numberOfWrongWords, int numberOfTrueWords, int numberOfKeyStrokes, int numberOfTrueKeyStroke, int numberOfFalseKeyStroke)
        {

            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            Owner = Application.Current.MainWindow;

            _wpm = wpm;
            _numberOfWrongWords = numberOfWrongWords;
            _numberOfTrueWords = numberOfTrueWords;
            _numberOfKeyStrokes = numberOfKeyStrokes;
            _numberOfFalseKeyStroke = numberOfFalseKeyStroke;
            _numberOfTrueKeyStroke = numberOfTrueKeyStroke;


            #region tBlockKeyStrokeResult
            Run run = new Run("( ");
            run.Foreground = Brushes.Black;
            tBlockKeyStrokeResult.Inlines.Add(run);

            run = new Run(_numberOfTrueKeyStroke.ToString());
            run.Foreground = Brushes.Green;
            tBlockKeyStrokeResult.Inlines.Add(run);

            run = new Run(" | ");
            run.Foreground = Brushes.Black;
            tBlockKeyStrokeResult.Inlines.Add(run);

            run = new Run(_numberOfFalseKeyStroke.ToString());
            run.Foreground = Brushes.Red;
            tBlockKeyStrokeResult.Inlines.Add(run);

            run = new Run(" )");
            run.Foreground = Brushes.Black;
            tBlockKeyStrokeResult.Inlines.Add(run);

            run = new Run(" " + _numberOfKeyStrokes.ToString());
            run.Foreground = Brushes.Black;
            tBlockKeyStrokeResult.Inlines.Add(run);
            #endregion


            int wpmResult = ((_numberOfKeyStrokes / 5) - _numberOfWrongWords) / 1;

            tBlockWpmResult.Text = wpmResult + " WPM";

            double accurayResult = 100 * ((double)(((double)_numberOfKeyStrokes) - ((double)_numberOfWrongWords * 5)) / ((double)_numberOfKeyStrokes + (double)_numberOfFalseKeyStroke));
            tBlockAccuracyResult.Text = String.Format("{0:0.00}", accurayResult) + "%";

            tBlockFalseWordsResult.Text = _numberOfWrongWords.ToString();
            tBlockTrueWordsResult.Text = _numberOfTrueWords.ToString();
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                this.Close();

        }
    }
}
