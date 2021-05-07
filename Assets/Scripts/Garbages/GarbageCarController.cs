using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCarController : MonoBehaviour
{
    public LevelManager levelManager;
    public Transform killGarbagePoint;

    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("Collision");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Garbage"))
        {
            Debug.Log("Garbage detected");
            //Vector3 dir = collision.transform.position - killGarbagePoint.position;
            //collision.transform.Translate(dir.normalized * 1 * Time.deltaTime, Space.World);

            //if (Vector3.Distance(transform.position, collision.transform.position) < 4f)
            //{
                Debug.Log("Garbage destroyed");
                Destroy(collision.gameObject);
                levelManager.trashRemaining -= 1;
                levelManager.SetTrashReminding();
            //}
        }
    }
}