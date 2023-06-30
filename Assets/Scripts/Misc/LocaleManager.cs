using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleManager : Singleton<LocaleManager>
{ 
    private int currentLocale = 0;

    private IEnumerator Start()
    {
        yield return LocalizationSettings.InitializationOperation;

        currentLocale = LocalizationSettings.AvailableLocales.Locales.IndexOf(LocalizationSettings.SelectedLocale);
    }

    public void ChangeLocale()
    {
        currentLocale = (currentLocale + 1) % LocalizationSettings.AvailableLocales.Locales.Count;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[currentLocale];
    }
}
