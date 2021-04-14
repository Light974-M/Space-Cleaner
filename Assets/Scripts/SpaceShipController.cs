using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    public float speed;
    //public Transform[] waypoints;

    public Transform target;
    //private int destPoint = 0;

    void Start()
    {
        //target = waypoints[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //Si le vaisseau est presque arrivé à sa target
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            // Si la target n'est pas la dernière de la liste
            /*if(target != waypoints[waypoints.Length-1])
            {
                destPoint = destPoint + 1;
                target = waypoints[destPoint];
            }
            else*/
            {
                // Si c'est le dernier on détruit l'objet
                GameObject.Destroy(gameObject);
            }
        }
    }
}