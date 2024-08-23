using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void MoveToScene(int sceneID)
    {
        //AudioManager.instance.StopMusic2();
        // AudioManager.instance.PlayOneShot(FMODEvents.instance.play, this.transform.position);
        SceneManager.LoadScene(sceneID, LoadSceneMode.Single);
    }
    public void StartGame()
    {
        AudioManager.instance.InitializeMusic2(FMODEvents.instance.Music2);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.quit, this.transform.position);
        Debug.Log("GAME END");
        Application.Quit();
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(2);
    }
    public void Settings()
    {
      // AudioManager.instance.PlayOneShot(FMODEvents.instance.select, this.transform.position);
    }


    public void PauseGame()
    {
        Time.timeScale = 0;
        AudioManager.instance.PlayOneShot(FMODEvents.instance.click, this.transform.position);
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        AudioManager.instance.PlayOneShot(FMODEvents.instance.click, this.transform.position);
    }

    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex == 1 && Input.GetKeyDown(KeyCode.X))
        {

            AudioManager.instance.PlayOneShot(FMODEvents.instance.click, this.transform.position);
            MoveToScene(2);
        }
        if (currentScene.buildIndex == 2)
        {
            //AudioManager.instance.StopMusic2();
        }

    }
}
