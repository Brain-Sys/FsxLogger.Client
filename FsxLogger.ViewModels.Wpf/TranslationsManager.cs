using System.Linq;
using WPFLocalizeExtension.Engine;

namespace FsxLogger.ViewModels.Wpf
{
    public class TranslationsManager : FsxLogger.Translations.TranslationsManager
    {
        public override void ChangeLanguage()
        {
            var cultures = base.GetAvailableCultures();
            var currentCulture = LocalizeDictionary.Instance.Culture;
            int index = cultures.IndexOf(currentCulture);

            if (index != -1)
            {
                if (index < (cultures.Count - 1))
                {
                    index++;
                }
                else
                {
                    index = 0;
                }
            }
            else
            {
                index = 0;
            }

            LocalizeDictionary.Instance.Culture = cultures[index];
        }
    }
}