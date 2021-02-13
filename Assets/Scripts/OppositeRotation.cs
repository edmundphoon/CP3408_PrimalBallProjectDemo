using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppositeRotation : MonoBehaviour
{
    public float speed = 50.0f;

    // Update is called once per frame
    void Update()
    {
        //Makes object rotates counterclockwise
        transform.Rotate(Vector3.down * speed * Time.deltaTime);
    }
}
