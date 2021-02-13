using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ThirdPersonCharacterController : MonoBehaviour
{
    //Rigidbody
    private Rigidbody rb;

    //when player hits the current checkpoint
    public Transform currentCheckpoint;

    //Victory Screen UI
    public GameObject VictoryScreenUI;

    //Player lives
    private int count;
    public Text lifeText;

    //Game Over UI when player runs out of lives
    public GameObject GameOverMenuUI;

    //When the boss captures the player
    public GameObject BossCapturedPlayerUI;

    private void Start()
    {
        //Rigidbody
        rb = GetComponent<Rigidbody>();

        //Player lives
        count = 10;
        NumberOfLivesText();
    }

    private void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "OutOfBounds")
        {
            //player respawns at the most recent checkpoint reached
            transform.position = currentCheckpoint.position;            
        }

        //checkpoint
        if (hit.CompareTag("Checkpoint"))
        {
            //updates new checkpoint when player reaches it
            currentCheckpoint = hit.transform;
        }

        if (hit.CompareTag("PickUp"))
        {
            //Collect the collectible item by making it disappear
            hit.gameObject.SetActive(false);

            //Victory Screen
            ShowVictoryScreen();
        }

        // for boss
        if(hit.gameObject.tag == "Boss")
        {
            Time.timeScale = 0f;
            BossCapturedPlayerUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider hit)
    {
        if (hit.CompareTag("OutOfBounds"))
        {
            //Player lives
            LoseLife();
        }
        
    }

    //Victory Screen
    public void ShowVictoryScreen()
    {
        Time.timeScale = 0f;
        VictoryScreenUI.SetActive(true);
    }

    //Player loses a life whenever they fall out of bounds
    private void LoseLife()
    {
        count = count - 1;

        NumberOfLivesText();
        if(count == 0)
        {
            Debug.Log("Game Over!");
        }
    }

    void NumberOfLivesText()
    {
        if(count == 10)
        {
            lifeText.text = "Lives: " + 5;
        }
        if (count == 8)
        {
            lifeText.text = "Lives: " + 4;
        }
        if (count == 6)
        {
            lifeText.text = "Lives: " + 3;
        }
        if (count == 4)
        {
            lifeText.text = "Lives: " + 2;
        }
        if (count == 2)
        {
            lifeText.text = "Lives: " + 1;
        }
        if (count == 0)
        {
            lifeText.text = "Lives: " + 0;
            Time.timeScale = 0f;
            GameOverMenuUI.SetActive(true);
        }
    }









}
