using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float horizontalSpeed = 1f;
    public float verticalSpeed = 1f;
    public Camera cam;

    public Rigidbody rb;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb.constraints = RigidbodyConstraints.None;
    }

    void Update()
    {
        if (!StatController.isGameOver && !LevelManager.isPause)
        {
            Look();

            if (!StatController.stabilization)
            {
                rb.AddTorque(-rb.angularVelocity * 100);
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                cam.transform.Rotate(0, 180, 0);
            }
            if(Input.GetKeyUp(KeyCode.Space))
            {
                cam.transform.Rotate(0, -180, 0);
            }

            /*if (!StatController.lastChance)
            {
                Flip();
            }*/
        }
    }

    private void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;

        transform.Rotate(new Vector3(-mouseY, mouseX, 0));
    }

    /*private void Flip()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddRelativeTorque(0, 0, -50);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            rb.AddRelativeTorque(0, 0, 50);
        }
        else
        {
            if(!StatController.stabilization)
            {
                rb.AddTorque(-rb.angularVelocity * 100);
            }
        }
    }*/
}
