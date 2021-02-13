using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToPlatform : MonoBehaviour
{
    public GameObject Player;

    //Make player follow the floating platform
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player)
        {
            Player.transform.parent = transform;
        }
    }

    //player no longer follows the floating platform
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == Player)
        {
            Player.transform.parent = null;
        }
    }
}
