using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SilverlightBanking.Dictionaries
{
    public class LithuanianDictionary
    {
        public static Dictionary<string, string> Translations { get; set; }

        static LithuanianDictionary()
        {
            InitializeTranslations();
        }

        private static void InitializeTranslations()
        {
            Translations = new Dictionary<string, string>();
            Translations.Add("ApplicationName", "Prašom užeiti į Silverlight Banką");

        }

        public static string GetTranslation(string key, string defaultTranslation)
        {
            if (Translations.ContainsKey(key))
                return Translations[key];
            return defaultTranslation;
        }

    }
}
