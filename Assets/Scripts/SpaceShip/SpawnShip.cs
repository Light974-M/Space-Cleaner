using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShip : MonoBehaviour
{
    public List<GameObject> spaceShips;
    
    //public List<Transform[]> roads;
    //public Transform target;
    //public List<Transform> waypoints1;
    //public Transform[] waypoints2;

    //Counter Vaisseau
    private float timeBeforeGenerateSpaceShip = 3;
    float currentTimeBeforeNextGenSpaceShip = 0;
    public float tempsMin = 1;
    public float tempsMax = 5;

    // Liste des itinéraires possibles
    public List<Routes> routes;

    void Update()
    {
        timeBeforeGenerateSpaceShip = Random.Range(tempsMin,tempsMax);

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
            int var = Random.Range(0, routes.Count);
            spaceShipController.waypoints = routes[var].waypoints;
            //spaceShipController.waypoints = roads[Random.Range(0, roads.Count)];
        }
    }
}