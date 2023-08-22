using System.Reflection;
using Utilities.Words;
using Utilities.Words.Azerbaijani;
using Utilities.Words.French;
using Utilities.Words.Kurdish;
using Utilities.Words.Persian;
using Utilities.Words.Spanish;
using Utilities.Words.Turkish;
using Utilities.Words.Greek;

namespace Utilities
{
    public static class SourceManager
    {

        public static Language CurrentLanguage { get; set; }

        public static Dictionary<Language, languages> _languageDictionary = new Dictionary<Language, languages>()
        {
            { new Arabic(), languages.Arabic},
            { new Armenian(), languages.Armenian},
            { new Azerbaijani(), languages.Azerbaijani},
            { new English(), languages.English},
            { new French(), languages.French},
            { new Greek(), languages.Greek},
            { new Kurdish(), languages.Kurdish},
            { new Persian(), languages.Persian},
            { new Spanish(), languages.Spanish},
            { new Turkish(), languages.Turkish},

        };
        public enum languages
        {
            Arabic,
            Armenian,
            Azerbaijani,
            English,
            French,
            Greek,
            Kurdish,
            Persian,
            Spanish,
            Turkish
        }
        public enum flowDirections
        {
            left,
            right
        }

        public static string[] GetLanguageArray(Language language)
        {
            CurrentLanguage = language;
            return File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), language.Path())).Split(',');
        }
    }
}
