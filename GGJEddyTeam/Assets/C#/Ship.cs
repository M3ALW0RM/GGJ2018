using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    public GameObject Target;
    public float timeToInpact;
    float elapsedTime;

    Vector3 startPoint;
    


	// Use this for initialization
	void Start ()
    {
        startPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        elapsedTime += Time.deltaTime;
        transform.position = Vector3.Lerp(startPoint, Target.transform.GetChild(0).position, elapsedTime/timeToInpact);
        if(elapsedTime >= timeToInpact)
        {
            Debug.Log("Collision with missile");
            Destroy(this.gameObject);
        }
	}
}
