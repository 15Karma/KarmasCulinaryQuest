using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{

    #region atributos
    public GameObject optionsPanel;
    public GameObject controlsPanel;
    public AudioSource clip;
    #endregion

    #region funciones y métodos

    public void OptionPanel()
    {
        Time.timeScale = 0;
        optionsPanel.SetActive(true);
    }

    public void ControlsPanel()
    {
        optionsPanel.SetActive(false);
        Time.timeScale = 0;
        controlsPanel.SetActive(true);
    }

    public void Return()
    {
        Time.timeScale = 1;
        optionsPanel.SetActive(false);
        controlsPanel.SetActive(false);
    }

    public void GoMainMenu()
    {
        Time.timeScale = 1;
        Scenes.MainMenu();
    }

    public void QuitGame()
    {
        Scenes.Quit();
    }

    public void PlaySoundButton()
    {
        clip.Play();
    }
    #endregion
}
