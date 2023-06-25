using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenuUtils : MonoBehaviour
{
    [SerializeField]
    private GameObject newGameButton;
    [SerializeField]
    private GameObject creditsButton;
    [SerializeField]
    private GameObject intro;
    [SerializeField]
    private GameObject startButton;

    [SerializeField]
    private GameObject credits;
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
        newGameButton.SetActive(false);
        creditsButton.SetActive(false);
        credits.SetActive(false);
        startButton.SetActive(true);
        intro.SetActive(true);
    }
}
