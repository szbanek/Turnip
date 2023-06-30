using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;

public class MainMenuUtils : MonoBehaviour
{
    [SerializeField]
    private GameObject mainPanel;
    [SerializeField]
    private GameObject introPanel;
    [SerializeField]
    private GameObject credits;

    [SerializeField]
    private Button localeButton;
    [SerializeField]
    private int currentLocale = 0;

    private IEnumerator Start()
    {
        introPanel.SetActive(false);
        mainPanel.SetActive(true);

        yield return LocalizationSettings.InitializationOperation;

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[currentLocale];

        localeButton.onClick.AddListener(ChangeLocale);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("map", LoadSceneMode.Single);
    }

    public void ShowCredits()
    {
        credits.SetActive(!credits.activeSelf);
    }

    public void NewGame()
    {
        mainPanel.SetActive(false);
        credits.SetActive(false);
        introPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ChangeLocale()
    {
        currentLocale = (currentLocale + 1) % LocalizationSettings.AvailableLocales.Locales.Count;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[currentLocale];
    }
}
