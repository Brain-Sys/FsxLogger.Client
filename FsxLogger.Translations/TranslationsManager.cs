using System.Collections.Generic;
using System.Globalization;

namespace FsxLogger.Translations
{
    public abstract class TranslationsManager
    {
        public List<CultureInfo> GetAvailableCultures()
        {
            var result = new List<CultureInfo>();
            result.Add(CultureInfo.InvariantCulture);
            result.Add(new CultureInfo("it-IT"));

            return result;
        }

        public abstract void ChangeLanguage();
    }
}