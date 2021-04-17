using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbageController : MonoBehaviour
{
    private GameObject player;
    private bool isGrab = false;
    private GameObject targetGrab;
    private GameObject targetVelocity;

    private Vector3 memoVelocity;

    void Start()
    {
        player = GameObject.Find("PivotCam");
        targetGrab = GameObject.Find("targetGrab");
        targetVelocity = GameObject.Find("targetVelocity");
    }

    void Update()
    {
        Grab();

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
        if (Vector3.Distance(player.transform.position, transform.position) < 10)
        {
            isGrab = true;
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
}
