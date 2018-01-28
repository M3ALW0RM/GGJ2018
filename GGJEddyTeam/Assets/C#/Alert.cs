using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BACKGROUND
{
    NORMAL_SHIP,
    FIRE,
    SAVED_MESSAGE,
    MONSTER,
    RED_ALERT,
    SPACE
}

public enum CREW_EMOTION
{
    HAPPY,
    PUZZLED,
    DISAPPOINTED,
    PANICKED,
    ABSENT,
    DEAD
}

public enum SITUATION_ENDING
{
    NONE,
    EXPLOSION,
    CUT
}

public struct AlertSituation
{
    public string text;
    public BACKGROUND background;
    public CREW_EMOTION crewEmotrion;
    public AlertAnswer[] answers;
    public AlertSituation(string text, BACKGROUND background, CREW_EMOTION crewEmotrion, AlertAnswer[] answers)
    {
        this.text = text;
        background = new BACKGROUND();
        this.background = background;
        crewEmotrion = new CREW_EMOTION();
        this.crewEmotrion = crewEmotrion;
        this.answers = answers;
    }
}

public struct AlertResponseToAnswer
{
    public string text;
    public BACKGROUND background;
    public CREW_EMOTION crewEmotrion;
    public AlertResponseToAnswer(string text, BACKGROUND background, CREW_EMOTION crewEmotrion)
    {
        this.text = text;
        background = new BACKGROUND();
        this.background = background;
        crewEmotrion = new CREW_EMOTION();
        this.crewEmotrion = crewEmotrion;
    }
}

public struct AlertAnswer
{
    public string text;
    public SITUATION_ENDING ending;
    public AlertResponseToAnswer responses;
    public AlertAnswer(string text, SITUATION_ENDING ending, AlertResponseToAnswer responses)
    {
        this.text = text;
        ending = new SITUATION_ENDING();
        this.ending = ending;
        this.responses = responses;
    }
}

public class Alert : MonoBehaviour
{
    public static AlertSituation[] possibleAlertSituations = new AlertSituation[] 
    {
        new AlertSituation(
            "Chef, on doit programmer la trajectoire du vaisseau. Comment qu'on fait?", 
            BACKGROUND.NORMAL_SHIP, 
            CREW_EMOTION.PUZZLED, 
            new AlertAnswer[] 
            {
                new AlertAnswer(
                    "Contentez-vous de suive le protocole 2017.0.3f", 
                    SITUATION_ENDING.CUT,
                    new AlertResponseToAnswer("Ok, Chef! Hé ça marche, chef!", BACKGROUND.NORMAL_SHIP, CREW_EMOTION.HAPPY)),
                new AlertAnswer(
                    "À babord toute!",
                    SITUATION_ENDING.NONE,
                    new AlertResponseToAnswer("Ya personne du nom de babord.", BACKGROUND.NORMAL_SHIP, CREW_EMOTION.PUZZLED))
            })
    };

    public int index;

    [SerializeField]
    GameObject target;
    [SerializeField]
    float speed;
    [SerializeField]
    float accel;

    float currentSpeed = 0;
	// Use this for initialization
	void Start ()
    { 
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (currentSpeed < speed)
        {
            currentSpeed += accel * Time.deltaTime;
        }
        transform.position += (target.transform.position - transform.position).normalized * currentSpeed;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == target.name)
        {
            target.GetComponent<Earth>().ReceiveMessage(this);
        }
    }
}
