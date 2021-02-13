using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderShooting : MonoBehaviour
{
    public float speed;
    private float timer;
    public float life;

    private void Update()
    {
        this.transform.position += this.transform.forward * Time.deltaTime * speed;

        timer += Time.deltaTime;
        if (timer > life)
        {
            Destroy(this.gameObject);
        }
    }


}
