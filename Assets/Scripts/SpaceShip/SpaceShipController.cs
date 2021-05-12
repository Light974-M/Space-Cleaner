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

    public float lerp;

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

        //Si le vaisseau est presque arrivé à sa target
        if (Vector3.Distance(transform.position, target.position) < 2f)
        {
            // Si la target n'est pas la dernière de la liste
            if (target != waypoints[waypoints.Count - 1])
            {
                // Tentative de look avec un Lerp (ça marche pas)
                //rotateView();
                StartCoroutine(CoroutineStopLook());
                destPoint = destPoint + 1;
                target = waypoints[destPoint];
                GoTo(target);
            }
            else
            {
                // Si c'est le dernier on détruit l'objet
                GameObject.Destroy(gameObject);
            }
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("SpaceShip"))
        {
            NavMeshAgent navMeshOtherShip = collision.collider.gameObject.GetComponent<NavMeshAgent>();        
            if (navMeshOtherShip.speed < navMesh.speed)
            {
                navMesh.speed = navMeshOtherShip.speed;
                Debug.Log("Hit");
                bouchon = true;
            }
        }
    }*/

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("SpaceShip"))
        {
            if(navMesh.speed != defaultSpeed)
            {
                StartCoroutine(CoroutineResetSpeed());
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("SpaceShip"))
        {
            NavMeshAgent navMeshOtherShip = collision.collider.gameObject.GetComponent<NavMeshAgent>();
            if (navMeshOtherShip.speed < navMesh.speed)
            {
                navMesh.speed = navMeshOtherShip.speed;
            }
        }
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

    IEnumerator CoroutineResetSpeed()
    {
        yield return new WaitForSeconds(1f);
        navMesh.speed = defaultSpeed;
    }

    /*private void rotateView()
    {
        bool tant = true;
        while(tant)
        {
            if (lerp <= 1)
            {
                lerp += Time.deltaTime;
                transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, lerp);
            }
            else
            {
                lerp = 0;
                tant = false;
            }
        }
    }*/
}