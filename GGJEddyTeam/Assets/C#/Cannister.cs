using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannister : MonoBehaviour {

    private string message;
    private Text caption;
    private bool pressed;

    private void ButtonPressed()
    {
        
    }

    public void SetCaption( string txt )
    {
        caption.text = txt;
    }

    public void Initialize( string s )
    {
        message = s;
    }

	// Use this for initialization
	void Start ()
    {
        caption = GetComponentInChildren<Text>();
        SetCaption(message);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
