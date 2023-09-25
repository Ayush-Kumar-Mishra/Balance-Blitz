using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    public int currentLevel;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(currentLevel);
    }
    
    public void NextLevel()
    {
        SceneManager.LoadScene(currentLevel+1);
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
