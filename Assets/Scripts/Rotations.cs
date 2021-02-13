using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotations : MonoBehaviour
{
    public float speed = 50.0f;

    // Update is called once per frame
    void Update()
    {
        //object rotates in clockwise direction
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
