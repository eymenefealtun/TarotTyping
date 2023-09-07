using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using TarotType.Main.Settings;
using TarotType.Main.Utilities;
using TarotType.Main.Utilities.Words.EnglishFolder;
using TarotType.Main.View;

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
        public int Second
        {
            get
            {
                return this._second;
            }
            set
            {
                _second = value;
                lblTimer.Content = _second.ToString();
            }
        }


        int _numberOfWordsInEachCall = 20;

        string _targetText;
        string _currentTextOfTextBox;

        bool _isTextBoxChangedCanFire;
        bool _isStartedBefore;
        bool _canComboBoxChangedFired = false;
        bool _canSettignsChange = false;
        public bool IsRefreshing = false;
        public static bool _anotherArray = true;


        public static string[] _sourceWords;
        public static string[] _secondSourceWords;
        public static string[] _resultWordArray;
        public static Random _random;

        string _lightThemeCode = "#eeeee4";
        string _darkThemeCode = "#1e1e1e";

        public MainWindow()
        {
            InitializeComponent();

            _random = new Random();

            _words1 = new List<Label>();
            _words2 = new List<Label>();



            WordManager wordManager = new WordManager(_numberOfWordsInEachCall);
            SourceManager sourceManager = new SourceManager();



            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 1);


            //_second = 60;

            SourceManager.CurrentLanguage = new English();
            Preferences.CurrentTheme = _lightThemeCode;

            string initialLanguageName = nameof(English);

            _anotherArray = true;
            Preferences.LanguageName = initialLanguageName;
            cBoxLanguages.SelectedValue = initialLanguageName;

            //_sourceWords = SourceManager.GetLanguageArray(SourceManager.CurrentLanguage);
            //SetCurrentLanguageArray();

            _resultWordArray = new string[_numberOfWordsInEachCall];

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
            IsRefreshing = true;
            RefreshGame();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Second--;

            if (Second == 0)
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

            if (!_isStartedBefore && !string.IsNullOrWhiteSpace(tboxWrite.Text))
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
                    CurrentTextFalse(_words1[_currentWord1Index]);
                else
                    CurrentTextRight(_words1[_currentWord1Index]);
            }
            else
                CurrentTextFalse(_words1[_currentWord1Index]);

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
                    MarkedAsCorrect(_words1[_currentWord1Index], _words1[_currentWord1Index + 1]);
                else
                    MarkedAsIncorrect(_words1[_currentWord1Index], _words1[_currentWord1Index + 1]);
            }
            else
                _isTextBoxChangedCanFire = true;
        }

        private void MarkedAsCorrect(Label lbl, Label nextLabel)
        {
            _numberOfTrueWords++;

            lbl.Background = Brushes.Transparent;
            lbl.Foreground = Brushes.Green;
            nextLabel.Background = Brushes.LightGray;

            _currentWord1Index++;
        }

        private void MarkedAsIncorrect(Label lbl, Label nextLabel)
        {
            _numberOfWrongWords++;

            lbl.Background = Brushes.Transparent;
            lbl.Foreground = Brushes.Red;
            nextLabel.Background = Brushes.LightGray;

            _currentWord1Index++;
        }

        private void CurrentTextFalse(Label lbl)
        {
            lbl.Background = Brushes.Red;
            _numberOfFalseKeyStroke++;
        }

        private void CurrentTextRight(Label lbl)
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

            _resultWordArray = WordManager.GetRandomWord();

            int currentLength = 0;



            for (int i = 0; i < _resultWordArray.Length; i++)
            {
                Label lbl = new Label();
                lbl.Background = i == 0 && labels == _words1 ? Brushes.LightGray : Brushes.Transparent; //First word set to Light Gray
                lbl.Content = _resultWordArray[i];
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
            }
            panel.FlowDirection = SourceManager.CurrentLanguage.FlowDirection() == SourceManager.flowDirections.right ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
        }

        private void btnTheme_Click(object sender, RoutedEventArgs e)
        {
            Preferences.CurrentTheme = btnTheme.IsChecked == false ? _darkThemeCode : _lightThemeCode;
            SettingsChanged(Preferences.CurrentTheme, cBoxLanguages.SelectedValue.ToString());
        }


        private void SetCurrentLanguageArray()
        {
            if (_anotherArray == true)
            {
                _sourceWords = SourceManager.GetLanguageArray(SourceManager.CurrentLanguage);
                _secondSourceWords = null;
                _anotherArray = false;
            }
            else
            {
                _secondSourceWords = SourceManager.GetLanguageArray(SourceManager.CurrentLanguage);
                _sourceWords = null;
                _anotherArray = true;
            }

        }
        private void cBoxLanguages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            SettingsChanged(Preferences.CurrentTheme, cBoxLanguages.SelectedValue.ToString());

            Mouse.OverrideCursor = Cursors.Wait;

            SetCurrentLanguageArray();

            FlowDirection flowDirection = SourceManager.CurrentLanguage.FlowDirection() == SourceManager.flowDirections.right ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;

            tboxWrite.FlowDirection = flowDirection;
            stckPanel1.FlowDirection = flowDirection;
            stckPanel1.FlowDirection = flowDirection;

            RefreshGame();

            Mouse.OverrideCursor = null;
        }

        private void SettingsChanged(string themeCode, string languageName)
        {
            if (_canSettignsChange == false)
            {
                _canSettignsChange = true;
                return;
            }

            Preferences.CurrentTheme = themeCode;
            Preferences.LanguageName = languageName;
            SourceManager.CurrentLanguage = SourceManager._languageDictionary.FirstOrDefault(x => x.Value.ToString() == Preferences.LanguageName).Key;
            this.Background = (SolidColorBrush)new BrushConverter().ConvertFrom(Preferences.CurrentTheme);

        }

    }

}