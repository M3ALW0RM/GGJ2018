using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBehaviour : MonoBehaviour {

    [SerializeField]
    float speed;

    public AlertAnswer answer;
    public AlertSituation situation;
    public AlertResponseToAnswer response;

    // Use this for initialization
    void Start ()
    {
        Destroy(this, 9f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
	}
}
