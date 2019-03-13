using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Kostantinos()
    {
        SceneManager.LoadScene("Kostantinos", LoadSceneMode.Single);
    }

    public void Palmatree_Road()
    {
        SceneManager.LoadScene("PalmtreeRoad", LoadSceneMode.Single);
    }
}
