using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    private GameObject targetParticle;
    private GameObject player;

    void Start()
    {
        targetParticle = GameObject.Find("targetParticle");
        player = GameObject.Find("PivotCam");
        transform.position = new Vector3(player.transform.position.x + Random.Range(-20, 20), player.transform.position.y + Random.Range(-20, 20), player.transform.position.z + Random.Range(-20, 20));
    }

    void Update()
    {
        transform.LookAt(targetParticle.transform);

        if(Vector3.Distance(transform.position, player.transform.position) > 30)
        {
            Destroy(gameObject);
        }

    }
}
