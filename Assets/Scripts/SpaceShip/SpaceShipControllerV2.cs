using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpaceShipControllerV2 : MonoBehaviour
{
    // Point visé
    public Transform target;
    // Vitesse du véhicule
    public float defaultSpeed;
    public float speed;

    void Start()
    {
        transform.LookAt(target);
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        transform.LookAt(target);
        if (Vector3.Distance(transform.position, target.position) < 5f)
        {
            GameObject.Destroy(gameObject);
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("SpaceShip"))
        {
            SpaceShipControllerV2 otherSpaceShipController = collision.collider.gameObject.GetComponent<SpaceShipControllerV2>();
            if (otherSpaceShipController.speed < speed)
            {
                speed = otherSpaceShipController.speed;
                Debug.Log("Hit");
            }
        }
    }*/
}