using SilverlightBanking.Dictionaries;
using System;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SilverlightBanking.Extensions
{
    public class TranslatorExtension : MarkupExtension
    {
        public string Key { get; set; }
        public string Default { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            string language = Thread.CurrentThread.CurrentCulture.ToString();
            return LithuanianDictionary.GetTranslation(Key, Default);

            //if (language == "lt-BE")
            //{
            //    return LithuanianDictionary.GetTranslation(Key, Default);
            //}
            //else
            //{
            //    return EnglishDictionary.GetTranslation(Key, Default);
            //}
        }
    }
}
