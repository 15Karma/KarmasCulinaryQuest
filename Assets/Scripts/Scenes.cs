using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    #region atributos
    public AudioSource clip;
    #endregion

    #region funciones y métodos
    public static void NameInput()
    {

        SceneManager.LoadScene(1);
    }

    public static void PlayGame()
    {
       SceneManager.LoadScene(2);
    }

    public static void Credits()
    {
        SceneManager.LoadScene(3);
    }

    public static void Highscores()
    {
        SceneManager.LoadScene(4);
    }

    public static void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void PlaySoundButton()
    {
        clip.Play();
    }
    #endregion
}
