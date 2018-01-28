using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour {

    [SerializeField]
    GameObject ship;

    [SerializeField]
    List<Transform> spawnPositions;

    [SerializeField]
    GameObject target;

    [SerializeField]
    float timeToImpact;

    [SerializeField]
    float timeBetweenShipSpawn;
    float currentTimerTime;
    

    // Use this for initialization
    void Start ()
    {
        currentTimerTime = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentTimerTime -= Time.deltaTime;
		if(Input.GetMouseButton(1) && currentTimerTime<=0)
        {
            currentTimerTime = timeBetweenShipSpawn;
            GameObject go = Instantiate(ship, spawnPositions[Random.Range(0, spawnPositions.Count)].position, new Quaternion());
            go.GetComponent<Ship>().timeToInpact = timeToImpact;
            go.GetComponent<Ship>().Target = target;
        }
	}
}
