using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    public float RotationSpeed = 1;
    public Transform Sight, Player;
    float mouseX, mouseY;


    // Start is called before the first frame update
    void Start()
    {
        //mouse cursor gets disabled so that it would not be in the way
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        CamControl();
    }

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;

        //Clamps the given value between the given minimum float and maximum float values. 
        //Returns the given value if it is within the min and max range
        mouseY = Mathf.Clamp(mouseY, -50, 60);

        transform.LookAt(Sight);

        Sight.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);
    }


}
