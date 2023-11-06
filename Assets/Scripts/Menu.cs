using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    
   public void RestartLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        Score.theScore = 0;
    }

    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
        Score.theScore = 0;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("QUIT!");
    }

    public void ReturnToHome()
    {
        SceneManager.LoadSceneAsync(0);
    }

 
}
