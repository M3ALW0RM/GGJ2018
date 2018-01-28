using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    public GameObject missileTarget;

    [SerializeField]
    float timeToImpact;
    Vector3 initialPos;
    float currentTime;

	// Use this for initialization
	void Start ()
    {
        initialPos = transform.position;	
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentTime += Time.deltaTime;
        transform.position = Vector3.Lerp(initialPos, missileTarget.transform.position, currentTime/timeToImpact);
	}
}
