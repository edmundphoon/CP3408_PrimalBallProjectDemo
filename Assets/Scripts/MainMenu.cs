﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //load scene
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //player quits the game
    public void QuitGame()
    {
        Debug.Log("Player has quit the game!");
        Application.Quit();
    }
}
