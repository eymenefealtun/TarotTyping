using System.Collections.Generic;
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
using TarotType.Main.Settings;
using TarotType.Main.Properties;
using System.Resources;
using TarotType.Main.Utilities.Words.Bulgarian;
using TarotType.Main.Utilities.Words.Georgian;
using TarotType.Main.Utilities.Words.English;
using TarotType.Main.Utilities.Words.Chinese;
using TarotType.Main.Words.Serbian;

namespace TarotType.Main.Utilities
{
    public class SourceManager
    {
        public static ResourceManager _resources;
        public SourceManager()
        {
            _resources = new ResourceManager(typeof(Resources));
        }


        public static Language? CurrentLanguage { get; set; }

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
            { new Georgian(), languages.Georgian},
            { new Bulgarian(), languages.Bulgarian},
            { new Chinese(), languages.Chinese},
            { new Serbian(), languages.Serbian},
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
            Turkish,
            Georgian,
            Bulgarian,
            Chinese,
            Serbian
        }

        public enum flowDirections
        {
            left,
            right
        }

        public static string[] GetLanguageArray(Language language)
        {
            return _resources.GetString(Preferences.LanguageName).Split(',');
        }

    }
}
