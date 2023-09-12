using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using TarotType.Main.Utilities;

namespace TarotType.Main.Settings
{
    public static class Preferences
    {
        public static string CurrentTheme { get; set; }

        public static string LanguageName { get; set; }

        //private static string _prefencePath = Path.Combine(Environment.CurrentDirectory, @"Settings\Preference.txt");
        private static string _prefencePath = Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), @"Settings\Preference.txt");

        private static string _darkThemeCode = "#1e1e1e";

        public static void SetPreferences()
        {
            SourceManager.CurrentLanguage = SourceManager._languageDictionary.FirstOrDefault(x => x.Value.ToString() == LanguageName).Key;

            File.WriteAllText(_prefencePath, string.Empty); //cleans the txt file

            using (Stream stream = File.Open(_prefencePath, FileMode.Open))
            using (StreamWriter streamWriter = new StreamWriter(stream))
            {
                streamWriter.WriteLine(CurrentTheme);
                streamWriter.WriteLine(LanguageName);
            }

        }


        public static void GetPreferences(ToggleButton btnTheme, Window mainWindow, ComboBox cBoxLanguages)
        {
            //try
            //{
            string strResourceName = "Preference.txt";
            Assembly asm = Assembly.GetExecutingAssembly();
            using (Stream rsrcStream = asm.GetManifestResourceStream(asm.GetName().Name + ".Settings." + strResourceName))
            using (StreamReader reader = new StreamReader(rsrcStream))
            {
                string[] temp = reader.ReadLine().Split(',');
                CurrentTheme = temp[0];
                LanguageName = temp[1];

                SourceManager.CurrentLanguage = SourceManager._languageDictionary.FirstOrDefault(x => x.Value.ToString() == LanguageName).Key;

                btnTheme.IsChecked = CurrentTheme == _darkThemeCode ? btnTheme.IsChecked = false : btnTheme.IsChecked = true;
                mainWindow.Background = (SolidColorBrush)new BrushConverter().ConvertFrom(CurrentTheme);

                cBoxLanguages.SelectedValue = SourceManager._languageDictionary.FirstOrDefault(x => x.Value.ToString() == LanguageName).Value;
            }
            //}
            //catch (Exception exception)
            //{

            //    MessageBox.Show(exception.Message);
            //}

        }


    }
}