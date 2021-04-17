using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float horizontalSpeed = 1f;
    public float verticalSpeed = 1f;
    private float xRotation = 0.0f;
    private float yRotation = 0.0f;
    public Camera cam;
    private float turnSpeed = 0.1f;
    private int timer = 0;
    private int wichSide = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {

        Look();

        if(!StatController.lastChance)
        {
            Flip();
        }
    }

    private void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * horizontalSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSpeed;

        transform.Rotate(new Vector3(-mouseY, mouseX, 0));
    }

    private void Flip()
    {
        if (Input.GetKey(KeyCode.D))
        {
            wichSide = 0;

            if (timer < 100)
            {
                turnSpeed = turnSpeed * 1.04f;
                timer++;
            }
            transform.Rotate(0, 0, -turnSpeed);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            wichSide = 1;

            if (timer < 100)
            {
                turnSpeed = turnSpeed * 1.04f;
                timer++;
            }
            transform.Rotate(0, 0, turnSpeed);
        }
        else
        {
            if (wichSide == 0)
            {
                if (timer > 1)
                {
                    turnSpeed = turnSpeed * 0.96f;
                    transform.Rotate(0, 0, -turnSpeed);
                    timer--;
                }
                else
                {
                    timer = 0;
                    turnSpeed = 0.1f;
                }
            }

            if (wichSide == 1)
            {
                if (timer > 1)
                {
                    turnSpeed = turnSpeed * 0.96f;
                    transform.Rotate(0, 0, turnSpeed);
                    timer--;
                }
                else
                {
                    timer = 0;
                    turnSpeed = 0.1f;
                }
            }
        }
    }
}
