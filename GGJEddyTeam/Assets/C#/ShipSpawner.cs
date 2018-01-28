using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour {

    [SerializeField]
    GameObject ship;

    [SerializeField]
    Transform spawnPos;

    [SerializeField]
    GameObject target;

    [SerializeField]
    float timeToImpact;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetMouseButton(1))
        {
            GameObject go = Instantiate(ship, spawnPos.position, new Quaternion());
            go.GetComponent<Ship>().timeToInpact = timeToImpact;
            go.GetComponent<Ship>().Target = target;
        }
	}
}
