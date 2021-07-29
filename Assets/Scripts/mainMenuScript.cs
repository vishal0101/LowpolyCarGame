using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour
{

    public GameObject resumeMenuUI;

    public void Pause()
    {
        Time.timeScale = 0f;
        resumeMenuUI.SetActive(true);
    }

    public void Resume()
    {
        resumeMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
