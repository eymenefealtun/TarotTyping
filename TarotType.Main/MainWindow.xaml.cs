using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using TarotType.Main.Settings;
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
        int _numberOfTrueKeyStroke;
        int _numberOfFalseKeyStroke;

        int _currentWord1Index = 0;
        int _second = 60;

        string _targetText;
        string _currentTextOfTextBox;

        bool _isTextBoxChangedCanFire;
        bool _isStartedBefore;
        bool _canComboBoxChangedFired = false;

        string[] _sourceWords;

        string _lightThemeCode = "#eeeee4";
        string _darkThemeCode = "#1e1e1e";

        public MainWindow()
        {
            InitializeComponent();
            _words1 = new List<Label>();
            _words2 = new List<Label>();


            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 1);

            Preferences.GetPreferences(btnTheme, this, cBoxLanguages);
            _sourceWords = SourceManager.GetLanguageArray(SourceManager.CurrentLanguage);

            if (SourceManager.CurrentLanguage.FlowDirection() == SourceManager.flowDirections.right)
            {
                tboxWrite.FlowDirection = FlowDirection.RightToLeft;
                stckPanel1.FlowDirection = FlowDirection.RightToLeft;
                stckPanel1.FlowDirection = FlowDirection.RightToLeft;
            }

            RefreshGame();
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
                tboxWrite.IsEnabled = false;
                ResultWindow resultWindow = new ResultWindow(_numberOfTrueWords, _numberOfWrongWords, _numberOfTrueWords, _numberOfKeyStroke, _numberOfTrueKeyStroke, _numberOfFalseKeyStroke);
                resultWindow.ShowDialog();
                tboxWrite.IsEnabled = true;

                RefreshGame();
            }

        }

        private void tboxWrite_TextChanged(object sender, TextChangedEventArgs e)
        {
            _currentTextOfTextBox = tboxWrite.Text;


            if (!_isStartedBefore && tboxWrite.Text != " " && tboxWrite.Text != "")
            {
                _isStartedBefore = true;
                _dispatcherTimer.Start();
            }
            else if (tboxWrite.Text != string.Empty && !_isTextBoxChangedCanFire || tboxWrite.Text == " ")
            {
                tboxWrite.Text = String.Empty;
                return;
            }

            _numberOfKeyStroke++;

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

        private void tboxWrite_PreviewKeyDown(object sender, KeyEventArgs e) //when text of tboxWrite changed PreviewKeyDown event get fires first
        {
            _targetText = _words1[_currentWord1Index].Content.ToString();
            if (e.Key == Key.Escape)
            {
                RefreshGame();
                return;
            }

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
            _numberOfFalseKeyStroke++;
        }

        private void CurrentTextTrue(Label lbl)
        {
            lbl.Background = Brushes.LightGray;
            _numberOfTrueKeyStroke++;
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
            tboxWrite.Focus();


            _dispatcherTimer.Stop();
            lblTimer.Content = "60";
            _second = 60;

            _numberOfTrueWords = 0;
            _numberOfWrongWords = 0;
            _currentWord1Index = 0;
            _numberOfKeyStroke = 0;
            _numberOfTrueKeyStroke = 0;
            _numberOfFalseKeyStroke = 0;

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

            string[] wordArray = WordManager.GetRandomWord(20, _sourceWords);

            int currentLength = 0;          

            for (int i = 0; i < wordArray.Length; i++)
            {

                Label lbl = new Label();
                lbl.Background = i == 0 && labels == _words1 ? Brushes.LightGray : Brushes.Transparent; //First word set to Light Gray
                lbl.Content = wordArray[i];
                lbl.Style = (Style)FindResource("MainTextBlockTheme");
                //Calculations in order not to break the size limit of stack panel.

                lbl.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
                lbl.Arrange(new Rect(lbl.DesiredSize));

                currentLength += (Convert.ToInt32(lbl.ActualWidth) + (int)lbl.Margin.Left);

                //If total length of the words exceeds the limit we break.

                if (currentLength > stckPanel1.Width)
                    break;

                labels.Add(lbl);
                panel.Children.Insert(i, lbl);

                if (SourceManager.CurrentLanguage.FlowDirection() == SourceManager.flowDirections.right)
                    panel.FlowDirection = FlowDirection.RightToLeft;
                else
                    panel.FlowDirection = FlowDirection.LeftToRight;
            }
        }

        private void btnTheme_Click(object sender, RoutedEventArgs e)
        {
            if (btnTheme.IsChecked == false)
                Preferences.ThemeHexCode = _darkThemeCode;
            else
                Preferences.ThemeHexCode = _lightThemeCode;

            SettingsChanged(Preferences.ThemeHexCode, cBoxLanguages.SelectedValue.ToString());
        }

        private void cBoxLanguages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_canComboBoxChangedFired == false)
            {
                _canComboBoxChangedFired = true;
                return;
            }
                            

            SettingsChanged(Preferences.ThemeHexCode,cBoxLanguages.SelectedValue.ToString());

            Mouse.OverrideCursor = Cursors.Wait;

            _sourceWords = SourceManager.GetLanguageArray(SourceManager.CurrentLanguage);

            if (SourceManager.CurrentLanguage.FlowDirection() == SourceManager.flowDirections.right)            
            {
                tboxWrite.FlowDirection = FlowDirection.RightToLeft;
                stckPanel1.FlowDirection = FlowDirection.RightToLeft;
                stckPanel1.FlowDirection = FlowDirection.RightToLeft;
            }
            else
            {
                tboxWrite.FlowDirection = FlowDirection.LeftToRight;
                stckPanel1.FlowDirection = FlowDirection.LeftToRight;
                stckPanel1.FlowDirection = FlowDirection.LeftToRight;
            }

            RefreshGame();

            Mouse.OverrideCursor = null;
        }

        private void SettingsChanged(string themeCode, string languageName)
        {
            Preferences.ThemeHexCode = themeCode;
            Preferences.LanguageName = languageName;
            Preferences.SetPreferences();
            Preferences.GetPreferences(btnTheme, this, cBoxLanguages);
        }

    }

}