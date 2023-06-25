using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenuUtils : MonoBehaviour
{
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
}
