using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    [SerializeField]
    GameObject earth;

    [SerializeField]
    float TimeToEarth;

    float currentTime = 0;
    Vector3 startPos;

	// Use this for initialization
	void Start ()
    {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentTime += Time.deltaTime;
        transform.position = Vector3.Lerp(startPos, earth.transform.position, currentTime/TimeToEarth);	
	}
}
