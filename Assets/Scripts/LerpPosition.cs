using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpPosition : MonoBehaviour
{

    public Transform origin;
    public Transform target;

    public float lerp;

    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lerp <= 1)
        {
            lerp += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(origin.position, target.position, lerp);
            transform.rotation = Quaternion.Lerp(origin.rotation,target.rotation,lerp);
        }
        else
        {
            lerp = 0;
        }
    }
}