using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void MoveToScene(int sceneID)
    {
       // AudioManager.instance.PlayOneShot(FMODEvents.instance.play, this.transform.position);
        SceneManager.LoadScene(sceneID, LoadSceneMode.Single);
    }
    public void StartGame()
    {
        //AudioManager.instance.PlayOneShot(FMODEvents.instance.play, this.transform.position);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.quit, this.transform.position);
        Debug.Log("GAME END");
        Application.Quit();
    }

    public void Settings()
    {
      // AudioManager.instance.PlayOneShot(FMODEvents.instance.select, this.transform.position);
    }
    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex == 1 && Input.GetKeyDown(KeyCode.X))
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.click, this.transform.position);
            MoveToScene(2);
        }

    }
}
