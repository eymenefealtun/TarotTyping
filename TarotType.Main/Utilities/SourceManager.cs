using System.Reflection;
using System.Collections.Generic;
using System.IO;
using TarotType.Main.Utilities.Words;
using TarotType.Main.Utilities.Words.Azerbaijani;
using TarotType.Main.Utilities.Words.Turkish;
using TarotType.Main.Utilities.Words.French;
using TarotType.Main.Utilities.Words.Kurdish;
using TarotType.Main.Utilities.Words.Spanish;
using TarotType.Main.Utilities.Words.Persian;
using TarotType.Main.Utilities.Words.Arabic;
using TarotType.Main.Utilities.Words.Armenian;
using TarotType.Main.Utilities.Words.English;
using TarotType.Main.Utilities.Words.Greek;

namespace TarotType.Main.Utilities
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
