using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Timer : MonoBehaviour
{
    //seconds left before timer hits 0 seconds
    public int timeLeft = 300;

    //To be able to countdown in seconds
    public Text countdown;

    //Times Up UI  
    public GameObject TimesUpUI;

    // Start is called before the first frame update
    void Start()
    {
        countdown.text = ("Time Left: " + timeLeft);
        StartCoroutine("LoseTime");
        Time.timeScale = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Displays how many seconds left
        countdown.text = ("Time Left: " + timeLeft);
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
            if (timeLeft == 0)
            {
                Time.timeScale = 0f;
                TimesUpUI.SetActive(true);
            }
        }
    }
}
