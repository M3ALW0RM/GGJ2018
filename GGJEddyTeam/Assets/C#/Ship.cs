using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour {

    public GameObject Target, texturePlane;
    public Text text;
    public BGMoodSwitcher shipInside;
    public float timeToInpact = 30f;

    private BGMoodSwitcher switcher;

    float elapsedTime;

    Vector3 startPoint;

    public void DisplayMessage( AlertSituation alert )
    {
        switcher = Instantiate(shipInside, this.transform);
        switcher.SetBG(alert.background);
        switcher.SetEmotion(alert.crewEmotrion);
        text.text = alert.text;
        texturePlane.SetActive(true);
        StartCoroutine(WaitAndHide(5f));
    }

    public void HideMessage()
    {
        texturePlane.SetActive(false);
        Destroy(switcher);
    }

    IEnumerator WaitAndHide(float wait)
    {
        yield return new WaitForSeconds(wait);
        HideMessage();
    }



	// Use this for initialization
	void Start ()
    {
        startPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        elapsedTime += Time.deltaTime;
        transform.position = Vector3.Lerp(startPoint, Target.transform.position, elapsedTime/timeToInpact);
        if(elapsedTime >= timeToInpact)
        {
            Debug.Log("Collision with missile");
            Destroy(this.gameObject);
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            DisplayMessage(Alert.possibleAlertSituations[0]);
        }
	}
}
