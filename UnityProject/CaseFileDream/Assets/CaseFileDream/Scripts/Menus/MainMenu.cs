using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        LevelManager.Instance.LoadScene("TutorialLevel", "CrossFade");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);


    }

    public void SkipTutorial()
    {
        LevelManager.Instance.LoadScene("Cathedral", "CrossFade");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);


    }

    public void Quitgame ()
    {
        Application.Quit();

    }
}
