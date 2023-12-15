using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    public int currentLevel;
    public static int currLevel;
    public GameObject allLevels;
    public GameObject mainScreen;
    public GameObject pauseBtn;
    public GameObject pauseImg;

    private void Start()
    {
        currLevel = currentLevel;
    }


    public void MainMenu()
    {
       SceneManager.LoadScene(0);
    }

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
    
    public void DiffLevels()
    {
        allLevels.gameObject.SetActive(true);
        mainScreen.gameObject.SetActive(false);
    }
    
    public void PauseLevel()
    {
        Time.timeScale = 0;
        pauseBtn.SetActive(false);
        pauseImg.SetActive(true);
    }
    public void PlayLevel()
    {
        Time.timeScale = 1;
        pauseBtn.SetActive(true);
        pauseImg.SetActive(false);
    }
    
    public void backLevels()
    {
        allLevels.gameObject.SetActive(false);
        mainScreen.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
