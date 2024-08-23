using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public void RestartScene()
    {
        SceneManager.LoadScene("PikWip");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
