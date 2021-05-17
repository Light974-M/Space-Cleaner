using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbageController : MonoBehaviour
{
    private GameObject player;
    public static bool isGrab = false;
    private GameObject targetGrab;
    private GameObject targetVelocity;
    public static GameObject pressToGrabText;
    private GameObject pivotPressToGrab;

    private Vector3 memoVelocity;

    public LevelManager levelManager;

    void Start()
    {
        pivotPressToGrab = GameObject.Find("pivot2pressToGrab");
        pressToGrabText = GameObject.Find("PressToGrab");
        player = GameObject.Find("PivotCam");
        targetGrab = GameObject.Find("targetGrab");
        targetVelocity = GameObject.Find("targetVelocity");
        //levelManager.trashRemaining += 1;
    }

    void Update()
    {
        if(!LevelManager.isPause)
        {
            Grab();
        }

        if(PlayerMove.isGodMod)
        {
            ParticleSystem.EmissionModule emission = gameObject.GetComponent<ParticleSystem>().emission;
            emission.enabled = true;
        }
        else
        {
            ParticleSystem.EmissionModule emission = gameObject.GetComponent<ParticleSystem>().emission;
            emission.enabled = false;
        }
    }
 
    void OnMouseDown()
    {
        if (!LevelManager.isPause)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < 10)
            {
                isGrab = true;
            }
        }
    }

    private void OnMouseOver()
    {
        if(!LevelManager.isPause)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < 10)
            {
                pressToGrabText.SetActive(true);
                pressToGrabText.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                pivotPressToGrab.transform.eulerAngles = new Vector3(pivotPressToGrab.transform.eulerAngles.x, pivotPressToGrab.transform.eulerAngles.y, -player.transform.eulerAngles.z);
                pressToGrabText.transform.LookAt(player.transform);
            }
            else
            {
                pressToGrabText.SetActive(false);
            }
        }
    }

    private void OnMouseExit()
    {
        if (!LevelManager.isPause)
        {
            pressToGrabText.SetActive(false);
        }
    }

    private void Grab()
    {
        if (isGrab)
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            transform.SetParent(player.transform);
            transform.Translate((targetGrab.transform.position - transform.position) * 10 * Time.deltaTime, Space.World);
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                memoVelocity = player.GetComponent<Rigidbody>().velocity;
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                gameObject.GetComponent<Rigidbody>().velocity = memoVelocity;
                transform.SetParent(null);
                gameObject.GetComponent<Rigidbody>().AddForce((targetGrab.transform.position - targetVelocity.transform.position) * 80000);

                isGrab = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("SpaceShip"))
        {
            if(transform.parent == player)
            {
                StatController.LoseLife(20);

                if (StatController.life > 0)
                {
                    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    GetComponent<Rigidbody>().AddForce(new Vector3(GetComponent<Rigidbody>().velocity.x * (1 / GetComponent<Rigidbody>().velocity.x), GetComponent<Rigidbody>().velocity.y * (1 / GetComponent<Rigidbody>().velocity.x), GetComponent<Rigidbody>().velocity.z * (1 / GetComponent<Rigidbody>().velocity.x)) * 50000);
                    GetComponent<Rigidbody>().AddTorque(3000, 3000, 3000);
                    StatController.stabilization = true;
                }
            }
        }
    }
}