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
        private void tboxWrite_TextChanged(object sender, TextChangedEventArgs e)
        {


            _currentTextOfTextBox = tboxWrite.Text;
            if (_currentTextOfTextBox.Substring(0, _currentTextOfTextBox.Length) == _currentTextOfTextBox + " ")
                return;

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

                if (IsWordDoneTrue(_currentTextOfTextBox, _targetText))
                    TextDoneTrue(_words1[_currentWord1Index], _words1[_currentWord1Index + 1]);

                else
                    TextDoneWrong(_words1[_currentWord1Index], _words1[_currentWord1Index + 1]);
            }
        }

        private void TextDoneTrue(Label lbl, Label nextLabel)
        {
            lbl.Background = Brushes.Transparent;
            lbl.Foreground = Brushes.Green;



            nextLabel.Background = Brushes.LightGray;
            _numberOfTrueWords++;
            tboxWrite.Text = string.Empty;

            _currentWord1Index++;

        }

        private void TextDoneWrong(Label lbl, Label nextLabel)
        {

            lbl.Background = Brushes.Transparent;
            lbl.Foreground = Brushes.Red;



            nextLabel.Background = Brushes.LightGray;
            _numberOfWrongWords++;
            tboxWrite.Text = string.Empty;
            _currentWord1Index++;
        }

        private void CurrentTextWrong(Label lbl)
        {
            lbl.Background = Brushes.Red;
        }

        private void CurrentTextTrue(Label lbl)
        {
            lbl.Background = Brushes.LightGray; //sorun
        }


        private void RefreshGame()
        {
            RefreshStack(stckPanel1, _words1);
            RefreshStack(stckPanel2, _words2);
            _numberOfTrueWords = 0;
            _numberOfWrongWords = 0;
        }


        private void RefreshStack(StackPanel panel, List<Label> labels)
        {
            panel.Children.Clear();
            labels.Clear();

            string[] array = WordManager.GetRandomWord(204);

            int currentLength = 0;
            for (int i = 0; i < array.Length; i++)
            {
                currentLength += array[i].Length;
                if (currentLength < 62)
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
                        lbl.Style = FindResource("MainTextBlockTheme") as Style;
                    }



                    labels.Add(lbl);

                    panel.Children.Insert(i, lbl);
                }
                else
                    break;

            }
        }


    }

}