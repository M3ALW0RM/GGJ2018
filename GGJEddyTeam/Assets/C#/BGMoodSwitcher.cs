using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BGMoodSwitcher : MonoBehaviour {

    public BACKGROUND defaultBG;
    public GameObject[] BGObjects;

    public CREW_EMOTION defaultMood;
    public GameObject[] MoodObjects;

    public void SetBG(BACKGROUND newBG)
    {
        for ( int i = 0; i<BGObjects.Length;i++)
        {
            GameObject bgObj = BGObjects[i];
            bgObj.SetActive(i == (int) newBG);
        }
    }

    public void SetEmotion(CREW_EMOTION newMood)
    {
        for ( int i = 0; i<MoodObjects.Length;i++)
        {
            GameObject moodObj = MoodObjects[i];
            moodObj.SetActive(i == (int) newMood);
        }
    }

	// Use this for initialization
	void Start ()
    {
        SetBG(defaultBG);
        SetEmotion(defaultMood);
	}
}
