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
using TarotType.Main.Utilities.Words.Swedish;
using TarotType.Main.Utilities.Words.Finnish;
using TarotType.Main.Utilities.Words.Hebrew;
using TarotType.Main.Utilities.Words.Romanian;
using TarotType.Main.Words.German;
using TarotType.Main.Utilities.Words.Italian;
using TarotType.Main.Words.Vietnamese;
using TarotType.Main.Utilities.Words.Portuguese;
using TarotType.Main.Words.Hindi;
using TarotType.Main.Words.Russian;
using TarotType.Main.Words.Bengali;

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
            { new Bengali(), languages.Bengali},
            { new Bulgarian(), languages.Bulgarian},
            { new Chinese(), languages.Chinese},
            { new English(), languages.English},
            { new Finnish(), languages.Finnish},
            { new French(), languages.French},
            { new Georgian(), languages.Georgian},
            { new German(), languages.German},
            { new Greek(), languages.Greek},
            { new Hebrew(), languages.Hebrew},
            { new Hindi(), languages.Hindi},
            { new Italian(), languages.Italian},
            { new Kurdish(), languages.Kurdish},
            { new Persian(), languages.Persian},
            { new Portuguese(), languages.Portuguese},
            { new Romanian(), languages.Romanian},
            { new Russian(), languages.Russian},
            { new Serbian(), languages.Serbian},
            { new Spanish(), languages.Spanish},
            { new Swedish(), languages.Swedish},
            { new Turkish(), languages.Turkish},
            { new Vietnamese(), languages.Vietnamese},

        };

        public enum languages
        {
            Arabic,
            Armenian,
            Azerbaijani,
            Bengali,
            Bulgarian,
            Chinese,
            English,
            Finnish,
            French,
            Georgian,
            German,
            Greek,
            Hebrew,
            Hindi,
            Italian,
            Kurdish,
            Persian,
            Portuguese,
            Romanian,
            Russian,
            Serbian,
            Spanish,
            Swedish,
            Turkish,
            Vietnamese
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
