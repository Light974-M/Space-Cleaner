using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticleController : MonoBehaviour
{
    private Rigidbody rb;
    public static float velocity;
    public GameObject particle;
    private bool x = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        velocity = Mathf.Sqrt((rb.velocity.x* rb.velocity.x) + (rb.velocity.y * rb.velocity.y) + (rb.velocity.z * rb.velocity.z));

        if (velocity > 6)
        {
            if(!x)
            {
                Instantiate(particle);
                Instantiate(particle);
                Instantiate(particle);

            }
        }
    }
}
