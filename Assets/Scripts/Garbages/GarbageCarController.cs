using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCarController : MonoBehaviour
{
    public LevelManager levelManager;
    public Transform killGarbagePoint;
    private garbageController garbageControllerBis;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Garbage"))
        {
            garbageControllerBis = collision.gameObject.GetComponent<garbageController>();
            //garbageController.pressToGrabText.SetActive(false);
            garbageControllerBis.Destruction();
            levelManager.trashRemaining -= 1;
            levelManager.SetTrashReminding();
        }
    }
}