using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    //UI seen when players pauses the game
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    //loads the main menu
    public void loadMenu()
    {
        Debug.Log("Playing is returning to the main menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    //player quits the game
    public void quitGame()
    {
        Debug.Log("Player is quitting the game");
        Application.Quit();
    }

    //proceed to level 2
    public void NextLevel2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }

    //proceed to level 3
    public void NextLevel3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(3);
    }

    //repeat level 1
    public void RepeatLevel1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    
}
