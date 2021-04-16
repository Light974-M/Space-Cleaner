using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookVelocityController : MonoBehaviour
{

    public Transform target;

    void Start()
    {
        
    }

    void Update()
    {

        if(Vector3.Distance(target.position, transform.position) < 3)
        {
            transform.Translate((target.position - transform.position) * 20 * Time.deltaTime, Space.World);
        }
        else
        {
            transform.Translate((target.position - transform.position) * 50 * Time.deltaTime, Space.World);
        }
        
    }
}
