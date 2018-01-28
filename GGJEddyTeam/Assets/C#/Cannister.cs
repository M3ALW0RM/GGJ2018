﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannister : MonoBehaviour {

    private string message;
    private Text caption;
    private Animator anim;

    private Button button;

    public float speed = 0.01f, sinSpeed = 100f, sinAmplitude = 1f;

    [HideInInspector]
    public bool outOfRange = false;
    public float slidePos;
    public bool ejected = false;

    public void ButtonPressed()
    {
        outOfRange = true;
        anim.SetBool("Eject", true);
        ejected = true;
        Destroy(this.gameObject, 0.4f);
    }

    public void SetCaption( string txt )
    {
        caption.text = txt;
    }

    public void Initialize( string s, float n )
    {
        message = s;
        slidePos = n;
    }

    public void GoDown(float animOffset)
    {
        slidePos += animOffset;
    }

    public void Kill()
    {
        if (outOfRange)
        {
            Destroy(this.gameObject);
        }
    }

	// Use this for initialization
	void Start ()
    {
        caption = GetComponentInChildren<Text>();
        anim = GetComponent<Animator>();
        button = GetComponentInChildren<Button>();
        SetCaption(message);
        anim.SetFloat("slidePos", slidePos);

	}
	
	// Update is called once per frame
	void Update ()
    {
        slidePos += Time.deltaTime * speed * Mathf.Abs(sinAmplitude * Mathf.Sin( Time.time * Time.deltaTime * sinSpeed ));
        anim.SetFloat("slidePos", slidePos);

        //Check if too far down in the anim
        if (slidePos >= 1f)
        {
            outOfRange = true;
        }
        if (slidePos >= 0.68f)
        {
            button.enabled = false;
        }
	}
}