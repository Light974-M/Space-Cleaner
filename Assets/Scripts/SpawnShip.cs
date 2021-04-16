using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShip : MonoBehaviour
{
    public List<GameObject> spaceShips;
    //public Transform target;
    public Transform[] waypoints;

    //Counter Vaisseau
    public float timeBeforeGenerateSpaceShip = 3;
    float currentTimeBeforeNextGenSpaceShip = 0;

    void Update()
    {
        //Augmenter le timer du pop de vaisseau
        currentTimeBeforeNextGenSpaceShip += Time.deltaTime;

        //Pop un vaisseau régulièrement
        if (currentTimeBeforeNextGenSpaceShip >= timeBeforeGenerateSpaceShip)
        {
            // On appelle la fonction pour créer des trucs
            CreateSpaceShip(spaceShips[Random.Range(0, spaceShips.Count)]);

            currentTimeBeforeNextGenSpaceShip = 0;
        }
    }

    private void CreateSpaceShip(GameObject gameObject)
    {
        if ( gameObject != null)
        {
            //On fait une copie du vaisseau
            GameObject newSpaceShip = Instantiate(gameObject, transform);
            SpaceShipController spaceShipController = newSpaceShip.GetComponent<SpaceShipController>();
            //spaceShipController.target = target;
            spaceShipController.waypoints = waypoints;
        }
    }
}