using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour {

    [SerializeField]
    GameObject Missile;
    [SerializeField]
    ShipSpawner spawner;
    [SerializeField]
    GameObject missileTarget;

	// Use this for initialization
	void Start ()
    {
//        GameObject mis = Instantiate(Missile, transform.position, new Quaternion());
//        //mis.transform.LookAt(missileTarget.transform);
//        spawner.target = mis;
//        mis.GetComponentInChildren<Missile>().missileTarget = missileTarget;
//        mis.transform.LookAt(missileTarget.transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReceiveMessage(Alert alert)
    {
        Debug.Log("Play video with: " + Alert.possibleAlertSituations[alert.index].background + " background and with " + Alert.possibleAlertSituations[alert.index].crewEmotrion + " emotion and '" + Alert.possibleAlertSituations[alert.index].text + "' text.");
    }
}
