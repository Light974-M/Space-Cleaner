using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimitZone : MonoBehaviour
{
    public GameObject ecran;

    private float timer = 0;

    public int timeBeforeDie;

    private Rigidbody garbageRb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            ecran.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            timer += Time.deltaTime;
            if(timer > timeBeforeDie)
            {
                StatController.isGameOver = true;
            }
        }
        else if(other.gameObject.layer == LayerMask.NameToLayer("Garbage"))
        {
            garbageRb = other.gameObject.GetComponent<Rigidbody>();
            garbageRb.AddForce(-garbageRb.velocity * 100);
            Debug.Log("ralentis");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            ecran.SetActive(false);
            timer = 0;
        }
    }
}