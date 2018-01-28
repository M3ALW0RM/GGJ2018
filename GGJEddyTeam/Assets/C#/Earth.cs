using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReceiveMessage(Alert alert)
    {
        Debug.Log("Play video with: " + Alert.possibleAlertSituations[alert.index].background + " background and with " + Alert.possibleAlertSituations[alert.index].crewEmotrion + " emotion and '" + Alert.possibleAlertSituations[alert.index].text + "' text.");
    }
}
