using System.Reflection;
using Utilities.Words;
using Utilities.Words.Turkish;

namespace Utilities
{
    public static class SourceManager
    {

        public static Language CurrentLanguage { get; set; }

        public static Dictionary<Language, string> _languageDictionary = new Dictionary<Language, string>()
        {
            { new English(), "English"},
            { new Arabic(), "Arabic"},
            { new Turkish(), "Turkish"},
        };

        public static string[] GetLanguageArray(Language language)
        {
            CurrentLanguage = language;
            return File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), language.Path())).Split(',');
        }
    }
}
