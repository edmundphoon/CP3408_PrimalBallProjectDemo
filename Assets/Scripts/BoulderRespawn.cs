using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderRespawn : MonoBehaviour
{
    public GameObject Boulder;
    public int speed = 200;

    //The rate in which the boulder fires
    public float rate = 2f;

    //How many seconds from the start till the boulder spawns
    public float startTime = 1f;

    private void Start()
    {
        if (Boulder)
        {
            //Starting in 1 second, a boulder would fire every "rate" seconds
            InvokeRepeating("Shoot", startTime, rate);
        }
    }

    void Shoot()
    {
        Instantiate(Boulder, transform.position, transform.rotation);
    }

}
