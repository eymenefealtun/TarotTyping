using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Utilities;

namespace TarotType.Main
{
    public partial class MainWindow : Window
    {
        List<Label> _words1;
        List<Label> _words2;
        int _numberOfWrongWords;
        int _numberOfTrueWords;

        public MainWindow()
        {
            InitializeComponent();
            _words1 = new List<Label>();
            _words2 = new List<Label>();
        }
        int _currentWord1Index = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RefreshGame();
        }

        string _targetText;
        string _currentTextOfTextBox;
        bool _isTextBoxChangedCanFire;
        private void tboxWrite_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (!_isTextBoxChangedCanFire || tboxWrite.Text == " ")
            {
                tboxWrite.Text = String.Empty;
                return;
            }



            //MessageBox.Show("change");

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


        private bool IsWordDoneTrue(string currentText, string currentTargetText)
        {
            bool isDone = false;
            if (currentText == currentTargetText)
                isDone = true;

            return isDone;
        }


        private void tboxWrite_PreviewKeyDown(object sender, KeyEventArgs e)
        {


            if (e.Key == Key.Space && tboxWrite.Text != string.Empty)
            {
                int lastIndex = _words1.Count;
                if (_currentWord1Index == lastIndex - 1)
                {
                    _currentWord1Index = 0;

                    GetAnotherStack(_words2);

                    return;
                }
                //MessageBox.Show("previewKeyDown");

                _isTextBoxChangedCanFire = false;

                if (IsWordDoneTrue(_currentTextOfTextBox, _targetText))
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

            //tboxWrite.Text = null;

            _currentWord1Index++;
        }

        private void TextDoneWrong(Label lbl, Label nextLabel)
        {
            _numberOfWrongWords++;

            lbl.Background = Brushes.Transparent;
            lbl.Foreground = Brushes.Red;
            nextLabel.Background = Brushes.LightGray;



            //tboxWrite.Text = null;

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


        private void RefreshGame()
        {

            _numberOfTrueWords = 0;
            _numberOfWrongWords = 0;
            _isTextBoxChangedCanFire = true;
            _currentWord1Index = 0;
            _targetText = string.Empty;
            _currentTextOfTextBox = string.Empty;
            tboxWrite.Text = String.Empty;
            RefreshStack(stckPanel1, _words1);
            RefreshStack(stckPanel2, _words2);

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