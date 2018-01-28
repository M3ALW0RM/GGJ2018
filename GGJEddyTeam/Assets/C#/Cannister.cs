using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannister : MonoBehaviour {

    private string message;
    private Text caption;
    private Animator anim;
    private float animOffset = 0.05f; //value in animation "time" in between two cans

    public float speed = 0.01f, sinSpeed = 100f;

    [HideInInspector]
    public bool outOfRange = false;
    public float slidePos;
    public int number;

    public void ButtonPressed()
    {
        outOfRange = true;
        anim.SetBool("Eject", true);
    }

    public void SetCaption( string txt )
    {
        caption.text = txt;
    }

    public void Initialize( string s, int n )
    {
        message = s;
        number = n;
    }

    public void GoDown()
    {
        slidePos += animOffset;
    }

	// Use this for initialization
	void Start ()
    {
        caption = GetComponentInChildren<Text>();
        anim = GetComponent<Animator>();
        SetCaption(message);
        slidePos = 0.6f - animOffset * number;
        anim.SetFloat("slidePos", slidePos);
	}
	
	// Update is called once per frame
	void Update ()
    {
        slidePos += Time.deltaTime * speed * Mathf.Abs(Mathf.Sin( Time.time * Time.deltaTime * sinSpeed ));
        anim.SetFloat("slidePos", slidePos);

        //Check if too far down in the anim
        if (slidePos > 0.7f)
        {
            outOfRange = true;
        }
	}
}
