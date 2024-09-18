using System.Globalization;

namespace SchoolWebSite.Data.Commonds
{
    public class GeneralLocalizableEntity
    {
        public string Localizable(string TextAr, string TextEn)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture; // i will see (currentThread Arabic : English)
            if (cultureInfo.TwoLetterISOLanguageName.ToLower() == ("ar"))
                return TextAr;
            return TextEn;
        }
    }
}
