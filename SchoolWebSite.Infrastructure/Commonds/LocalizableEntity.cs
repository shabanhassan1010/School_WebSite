using System.Globalization;

namespace SchoolWebSite.Infrastructure.Commonds
{
    public class LocalizableEntity
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string GetLocalizable()
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture; // i will see (currentThread Arabic : English)
            if (cultureInfo.TwoLetterISOLanguageName.ToLower() == ("Ar"))
                return NameAr;
            return NameEn;
        }
    }
}
