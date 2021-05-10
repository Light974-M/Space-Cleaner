using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpaceShipController : MonoBehaviour
{
    // Trajectoire
    public List<Transform> waypoints;
    // Point actuel visé
    public Transform target;
    // Index du point visé
    private int destPoint = 0;
    // Vitesse du véhicule
    private float defaultSpeed;

    private NavMeshAgent navMesh;
    bool lookIsActive;

    void Start()
    {
        lookIsActive = true;
        target = waypoints[0];

        navMesh = GetComponent<NavMeshAgent>();
        defaultSpeed = navMesh.speed;
        GoTo(target);
        transform.LookAt(target);
    }

    void Update()
    {
        if(lookIsActive)
        {
            transform.LookAt(target);
        }
        // Version avec Translate
        //Vector3 dir = target.position - transform.position;
        //transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //Si le vaisseau est presque arrivé à sa target
        if (Vector3.Distance(transform.position, target.position) < 2f)
        {
            // Si la target n'est pas la dernière de la liste
            if (target != waypoints[waypoints.Count - 1])
            {
                StartCoroutine(CoroutineStopLook());
                destPoint = destPoint + 1;
                target = waypoints[destPoint];
                GoTo(target);
                
                if (navMesh.speed != defaultSpeed)
                {
                    navMesh.speed = defaultSpeed;
                }
            }
            else
            {
                // Si c'est le dernier on détruit l'objet
                GameObject.Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Hit");
        if (collision.gameObject.layer == LayerMask.NameToLayer("SpaceShip"))
        {
            NavMeshAgent navMeshOtherShip = collision.collider.gameObject.GetComponent<NavMeshAgent>();        
            if (navMeshOtherShip.speed < navMesh.speed)
            {
                navMesh.speed = navMeshOtherShip.speed;
                //StartCoroutine(SlowdownSpeed(navMeshOtherShip.speed));
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }

    public void GoTo(Transform target)
    {
        navMesh.SetDestination(target.position);
    }

    IEnumerator CoroutineStopLook()
    {
        lookIsActive = false;
        yield return new WaitForSeconds(1.25f);
        lookIsActive = true;
    }
}