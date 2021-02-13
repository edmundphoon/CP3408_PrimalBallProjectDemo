using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    //Applied force when hit by boulder
    public float forceAppliedForward;
    public float forceAppliedUpwards;
    public float forceAppliedBackwards;

    //Rigidbody
    private Rigidbody rb;

    //Player Movement
    public float Speed;
    public float jumpingHeight;

    //for jumping only once
    public bool isGrounded;

    private void Start()
    {
        //Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    //jumping
    private void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Ground" && isGrounded == false)
        {
            isGrounded = true;
        }

        //force in which the boulder hits the player
        if (hit.gameObject.tag == "Boulder")
        {
            rb.AddForce(forceAppliedForward, forceAppliedUpwards, forceAppliedBackwards);
        }        
    }

    //when the player goes out of bounds due to the boulder hitting the player, this is being 
    //used to immediately remove the force so that the player would not fall out of the map again
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "OutOfBounds")
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void Update()
    {
        PlayerMovement();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jumping();
        }
    }

    //jumping
    void Jumping()
    {
        rb.AddForce(new Vector3(0, jumpingHeight, 0), ForceMode.Impulse);
        isGrounded = false;
    }

    //Player movement
    void PlayerMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 playerMovement = new Vector3(moveHorizontal, 0.0f, moveVertical) * Speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }


}
