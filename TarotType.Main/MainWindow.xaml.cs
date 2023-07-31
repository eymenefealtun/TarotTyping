using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using TarotType.Main.View;
using Utilities;

namespace TarotType.Main
{
    public partial class MainWindow : Window
    {
        List<Label> _words1;
        List<Label> _words2;
        DispatcherTimer _dispatcherTimer;

        int _numberOfWrongWords;
        int _numberOfTrueWords;
        int _numberOfKeyStroke;
        int _currentWord1Index = 0;
        string _targetText;
        string _currentTextOfTextBox;
        private int _second = 60;

        bool _isTextBoxChangedCanFire;
        private bool _isStartedBefore;

        public MainWindow()
        {
            InitializeComponent();
            _words1 = new List<Label>();
            _words2 = new List<Label>();


            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 1);

            RefreshGame();
            FocusManager.SetFocusedElement(this, tboxWrite);
        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshGame();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            lblTimer.Content = _second.ToString();
            _second--;
            lblTimer.Content = _second.ToString();

            if (_second == 0)
            {
                //MessageBox.Show($"Your WPM is {_numberOfTrueWords}\n Correct words {_numberOfTrueWords}\n Wrong words {_numberOfWrongWords}\n Keystrokes {_numberOfKeyStroke} ", "Tarot Type", MessageBoxButton.OK, MessageBoxImage.Information);

                ResultWindow resultWindow = new ResultWindow(_numberOfTrueWords,_numberOfWrongWords,_numberOfTrueWords,_numberOfKeyStroke);
                resultWindow.ShowDialog();

                RefreshGame();
            }

        }

        private void tboxWrite_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!_isStartedBefore && tboxWrite.Text != " " && tboxWrite.Text != "")
            {
                _isStartedBefore = true;
                _dispatcherTimer.Start();
                return;
            }
            else if (tboxWrite.Text != string.Empty && !_isTextBoxChangedCanFire || tboxWrite.Text == " ")
            {
                tboxWrite.Text = String.Empty;
                return;
            }

            _currentTextOfTextBox = tboxWrite.Text;

            _targetText = _words1[_currentWord1Index].Content.ToString();

            int currentLegth = _currentTextOfTextBox.Length;

            if (currentLegth <= _targetText.Length)
            {
                string currentTargetText = _targetText.Substring(0, currentLegth);

                if (currentTargetText != _currentTextOfTextBox)
                    CurrentTextWrong(_words1[_currentWord1Index]);
                else
                    CurrentTextTrue(_words1[_currentWord1Index]);
            }
            else
                CurrentTextWrong(_words1[_currentWord1Index]);

        }

        private void tboxWrite_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            _numberOfKeyStroke++;

            if (e.Key == Key.Space && tboxWrite.Text != string.Empty)
            {
                int lastIndex = _words1.Count;
                if (_currentWord1Index == lastIndex - 1)
                {
                    _currentWord1Index = 0;

                    GetAnotherStack(_words2);

                    return;
                }

                _isTextBoxChangedCanFire = false;

                if (_currentTextOfTextBox == _targetText)
                    TextDoneTrue(_words1[_currentWord1Index], _words1[_currentWord1Index + 1]);

                else
                    TextDoneWrong(_words1[_currentWord1Index], _words1[_currentWord1Index + 1]);
            }
            else
                _isTextBoxChangedCanFire = true;
        }

        private void TextDoneTrue(Label lbl, Label nextLabel)
        {
            _numberOfTrueWords++;

            lbl.Background = Brushes.Transparent;
            lbl.Foreground = Brushes.Green;
            nextLabel.Background = Brushes.LightGray;

            _currentWord1Index++;
        }

        private void TextDoneWrong(Label lbl, Label nextLabel)
        {
            _numberOfWrongWords++;

            lbl.Background = Brushes.Transparent;
            lbl.Foreground = Brushes.Red;
            nextLabel.Background = Brushes.LightGray;

            _currentWord1Index++;
        }

        private void CurrentTextWrong(Label lbl)
        {
            lbl.Background = Brushes.Red;
        }

        private void CurrentTextTrue(Label lbl)
        {
            lbl.Background = Brushes.LightGray;
        }

        private void GetAnotherStack(List<Label> words2)
        {
            stckPanel1.Children.Clear();
            stckPanel2.Children.Clear();
            _words1 = new List<Label>();

            for (int i = 0; i < words2.Count; i++)
            {
                stckPanel1.Children.Insert(i, words2[i]);
                _words1.Add(_words2[i]);
            }

            tboxWrite.Text = String.Empty;
            RefreshStack(stckPanel2, _words2);
        }

        private void RefreshGame()
        {
            _dispatcherTimer.Stop();
            lblTimer.Content = "60";
            _second = 60;

            _numberOfTrueWords = 0;
            _numberOfWrongWords = 0;
            _currentWord1Index = 0;
            _numberOfKeyStroke = 0;
            _isTextBoxChangedCanFire = true;
            _isStartedBefore = false;

            _targetText = string.Empty;
            _currentTextOfTextBox = string.Empty;
            tboxWrite.Text = string.Empty;


            RefreshStack(stckPanel1, _words1);
            RefreshStack(stckPanel2, _words2);

        }


        private void RefreshStack(StackPanel panel, List<Label> labels)
        {
            panel.Children.Clear();
            labels.Clear();

            string[] array = WordManager.GetRandomWord(20);

            int currentLength = 0;

            for (int i = 0; i < array.Length; i++)
            {

                Label lbl = new Label();
                if (i == 0 && labels == _words1)
                {
                    lbl.Content = array[i];
                    lbl.Background = Brushes.LightGray;
                    lbl.Style = FindResource("MainTextBlockTheme") as Style;

                }
                else
                {
                    lbl.Content = array[i];
                    lbl.Background = Brushes.Transparent;
                    lbl.Style = (Style)FindResource("MainTextBlockTheme");
                }



                lbl.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
                lbl.Arrange(new Rect(lbl.DesiredSize));
                currentLength += (Convert.ToInt32(lbl.ActualWidth) + 10); //this ten comes from margin of stackPanel

                if (currentLength > stckPanel1.Width)
                    break;

                labels.Add(lbl);
                panel.Children.Insert(i, lbl);


            }
        }

    }

}