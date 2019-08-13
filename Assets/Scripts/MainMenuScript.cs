using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject settings;
    public GameObject menu;

    bool isHidden = false;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToggleSettings()
    {
        isHidden = !isHidden;
        settings.SetActive(isHidden);
        menu.SetActive(!isHidden);
    }
}
