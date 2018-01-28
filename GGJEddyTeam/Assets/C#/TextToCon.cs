using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TextToCon : MonoBehaviour 
{
	public string desigedString = "testsetsetsetset set set set set set .se t.se.ts.e t.se t.se.t s.e t.set set set set set .se t.se.ts.e t.se t.se.t s.e t.set set set set set .se t.se.ts.e t.se t.se.t s.e t.set set set set set .se t.se.ts.e t.se t.se.t s.e t.set";
	public Text myText;
	public int letterSound,letterSound1, letterSound2, letterSound3, letterSound4, letterSound5, letterSound6, letterSound7;
	private int currentLetter = 0;
	public List<AudioClip> soundList,soundList1,soundList2,soundList3,soundList4,soundList5,soundList6,soundList7;
	public AudioSource voicesSource,musicSource;
	private int currentText = 0;
	float letterSpeed = .07f,dotSpeed = 0.3f,spaceSpeed = 0.2f;
	public int myInt = 6;

	void Start()
	{
		//int myInt = Random.Range (0, 7);
		Debug.LogError ((myInt +=1));

		if (myInt == 0) 
		{
			for (int i = 0; i < soundList1.Count; i++) 
			{
				soundList.Add(soundList1[i]);
			}
			letterSound = letterSound1;
		}
		if (myInt == 1) 
		{
			for (int i = 0; i < soundList2.Count; i++) 
			{
				soundList.Add(soundList2[i]);
			}
			letterSound = letterSound2;
		}
		if (myInt == 2) 
		{
			for (int i = 0; i < soundList3.Count; i++) 
			{
				soundList.Add(soundList3[i]);
			}
			letterSound = letterSound3;
		}
		if (myInt == 3) 
		{
			for (int i = 0; i < soundList4.Count; i++) 
			{
				soundList.Add(soundList4[i]);
			}
			letterSound = letterSound4;
		}
		if (myInt == 4) 
		{
			for (int i = 0; i < soundList5.Count; i++) 
			{
				soundList.Add(soundList5[i]);
			}
			letterSound = letterSound5;
		}
		if (myInt == 5) 
		{
			for (int i = 0; i < soundList6.Count; i++) 
			{
				soundList.Add(soundList6[i]);
			}
			letterSound = letterSound6;
		}
		if (myInt == 6) 
		{
			soundList = soundList7;
			//for (int i = 0; i < soundList7.Count; i++) 
			//{
			//	soundList.Add(soundList7[i]);
			//}
			letterSound = letterSound7;
		}
		Typing ();
	}

	void Typing()
	{
		if (currentLetter < desigedString.Length)
		{
			myText.text += desigedString[currentLetter];
			if (desigedString[currentLetter] == ' ')
			{
				Invoke("Typing",spaceSpeed);
			}
			else if (desigedString[currentLetter] == '.')
			{
				Invoke("Typing",dotSpeed);
			}
			else
			{
				Invoke("Typing",letterSpeed);
			}

			if (currentLetter%letterSound == 0)
			//if(!voicesSource.isPlaying)
			{
				AudioClip myClip = soundList [Random.Range (0, soundList.Count)];

				for (int i = 0; myClip == voicesSource.clip;i++)
				{
					myClip = soundList [Random.Range (0, soundList.Count)];
				}
				voicesSource.clip = myClip;
				voicesSource.Play();
			}
			currentLetter+=1;
		}
	}
}