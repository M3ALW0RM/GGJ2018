using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannisterQueue : MonoBehaviour {

    [SerializeField]
    private Cannister cannisterPrefab;

    private Queue cannisterQueue;

    private float animOffset = 0.05f;

    public void AddCannister(string message)
    {
        Cannister newCan = Instantiate(cannisterPrefab, this.transform, true);
        newCan.Initialize(message);
        cannisterQueue.Enqueue(newCan);
    }

	// Use this for initialization
	void Start ()
    {
        AddCannister("test");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
