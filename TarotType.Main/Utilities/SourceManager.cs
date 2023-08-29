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
using TarotType.Main.Utilities.Words.Greek;
using TarotType.Main.Utilities.Words.EnglishFolder;
using TarotType.Main.Properties;
using System.Resources;
using TarotType.Main.Settings;

namespace TarotType.Main.Utilities
{
    public static class SourceManager
    {

        public static Language? CurrentLanguage { get; set; }

        public static Dictionary<Language, languages> _languageDictionary = new Dictionary<Language, languages>()
        //public static Dictionary<Language, string> _languageDictionary = new Dictionary<Language, string>()
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
            // { new Arabic(), Resources.Arabic},
            //{ new Armenian(),  Resources.Armenian},
            //{ new Azerbaijani(),  Resources.Azerbaijani},
            //{ new English(),  Resources.English},
            //{ new French(),  Resources.French},
            //{ new Greek(),  Resources.Greek},
            //{ new Kurdish(),  Resources.Kurdish},
            //{ new Persian(),  Resources.Persian},
            //{ new Spanish(),  Resources.Spanish},
            //{ new Turkish(),  Resources.Turkish},

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
            ResourceManager resources = new ResourceManager(typeof(Resources));

            return resources.GetString(Preferences.LanguageName).Split(',');
        }

    }
}
