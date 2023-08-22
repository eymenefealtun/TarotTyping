using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Utilities;

namespace TarotType.Main.Settings
{
    public static class Preferences
    {
        public static string ThemeHexCode { get; set; }

        public static string LanguageName { get; set; }

        private static string _prefencePath = Path.Combine(Environment.CurrentDirectory, @"Settings\Preference.txt");

        private static string _darkThemeCode = "#1e1e1e";

        public static void SetPreferences()
        {
            SourceManager.CurrentLanguage = SourceManager._languageDictionary.FirstOrDefault(x => x.Value.ToString() == LanguageName).Key;

            File.WriteAllText(_prefencePath, string.Empty); //cleans the txt file

            using (Stream stream = File.Open(_prefencePath, FileMode.Open))
            using (StreamWriter streamWriter = new StreamWriter(stream))
            {
                streamWriter.WriteLine(ThemeHexCode);
                streamWriter.WriteLine(LanguageName);
            }

        }


        public static void GetPreferences(ToggleButton btnTheme, Window mainWindow, ComboBox cBoxLanguages)
        {
            try
            {
                using (StreamReader reader = new StreamReader(_prefencePath))
                {
                    ThemeHexCode = reader.ReadLine();
                    LanguageName = reader.ReadLine();
                    SourceManager.CurrentLanguage = SourceManager._languageDictionary.FirstOrDefault(x => x.Value.ToString() == LanguageName).Key;

                    btnTheme.IsChecked = ThemeHexCode == _darkThemeCode ? btnTheme.IsChecked = false : btnTheme.IsChecked = true;
                    mainWindow.Background = (SolidColorBrush)new BrushConverter().ConvertFrom(ThemeHexCode);

                    cBoxLanguages.SelectedValue = SourceManager._languageDictionary.FirstOrDefault(x => x.Value.ToString() == LanguageName).Value;
                }
            }
            catch (Exception) { }

        }


    }
}