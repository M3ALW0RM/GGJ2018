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
                    "Rendez-vous aux coordonnées 85-160-76.",
                    SITUATION_ENDING.NONE,
                    new AlertResponseToAnswer("Vous pouvez juste nous dire sur quels boutons on doit appuyer, chef ?", BACKGROUND.NORMAL_SHIP, CREW_EMOTION.HAPPY)),
                new AlertAnswer(
                    "Ça va bien sinon ?",
                    SITUATION_ENDING.NONE,
                    new AlertResponseToAnswer("Je ne sais pas, attendez, je demande au chef. Chef, est-ce qu’on va bien ?", BACKGROUND.NORMAL_SHIP, CREW_EMOTION.PUZZLED)),
                new AlertAnswer(
                    "Ayez confiance en vous !",
                    SITUATION_ENDING.NONE,
                    new AlertResponseToAnswer("Ça y est, chef, on a confiance en nous. Et maintenant on fait quoi ?", BACKGROUND.NORMAL_SHIP, CREW_EMOTION.HAPPY)),
                new AlertAnswer(
                    "À babord toute!",
                    SITUATION_ENDING.NONE,
                    new AlertResponseToAnswer("Y’a personne du nom de 'Babord' dans l’équipage, chef !", BACKGROUND.NORMAL_SHIP, CREW_EMOTION.PUZZLED))
            }),

        new AlertSituation(
            "Chef, une fuite de gaz a causé un incendie dans la salle de contrôle. Apparemment, ça fait ça souvent. Qu’est-ce qu’on fait ?",
            BACKGROUND.FIRE,
            CREW_EMOTION.PUZZLED,
            new AlertAnswer[]
            {
                new AlertAnswer(
                    "Utilisez l’extincteur sur les flammes !",
                    SITUATION_ENDING.CUT,
                    new AlertResponseToAnswer("C’était une bonne idée, l’extincteur, chef. Comment vous avez su ?", BACKGROUND.NORMAL_SHIP, CREW_EMOTION.PUZZLED)),
                new AlertAnswer(
                    "Vite, les amis ! Sortez tous !",
                    SITUATION_ENDING.EXPLOSION,
                    new AlertResponseToAnswer("Journal de bord : utilisation du sas d’évacuation détectée.", BACKGROUND.SPACE, CREW_EMOTION.DEAD)),
                new AlertAnswer(
                    "Restez calme et éteignez-le !",
                    SITUATION_ENDING.EXPLOSION,
                    new AlertResponseToAnswer("Journal de bord : extinction totale du vaisseau enclenché. Espérons qu'ils avaient sauvegardé leurs fichiers.", BACKGROUND.SAVED_MESSAGE, CREW_EMOTION.ABSENT)),
                new AlertAnswer(
                    "Ça devrait s’éteindre tout seul, il n’y a pas d’oxygène dans l’espace !",
                    SITUATION_ENDING.EXPLOSION,
                    new AlertResponseToAnswer("Merci, chef, c’est rassurant ! Nous on pensait que l'oxygène dans le vaisseau pourrait exploser !", BACKGROUND.NORMAL_SHIP, CREW_EMOTION.HAPPY))
            }),


        new AlertSituation(
            "Chef, nous avons trouvé des réserves d’uranium dans le vaisseau. Si on l’ajoute au carburant actuel, on aura plus de puissance ! On a l'autorisation ?",
            BACKGROUND.NORMAL_SHIP,
            CREW_EMOTION.HAPPY,
            new AlertAnswer[]
            {
                new AlertAnswer(
                    "L’uranium ne doit être utilisé qu'en cas d’urgence !",
                    SITUATION_ENDING.CUT,
                    new AlertResponseToAnswer("D’accord, chef, on trouvera une meilleure utilisation pour l’uranium plus tard, c'est promis.", BACKGROUND.NORMAL_SHIP, CREW_EMOTION.DISAPPOINTED)),
                new AlertAnswer(
                    "Allez-y, mais manipulez le avec prudence.",
                    SITUATION_ENDING.EXPLOSION,
                    new AlertResponseToAnswer("Désolé chef, on a essayé mais Ted a bousculé Léo et fait tomber l'uranium dans la ventilation...", BACKGROUND.RED_ALERT, CREW_EMOTION.PANICKED)),
                new AlertAnswer(
                    "Bonne idée, j’aurais dû y penser !",
                    SITUATION_ENDING.EXPLOSION,
                    new AlertResponseToAnswer("Journal : L’équipage du vaisseau a été carbonisé par une explosion. Bonne idée chef !", BACKGROUND.SPACE, CREW_EMOTION.ABSENT)),
                new AlertAnswer(
                    "Plusieurs têtes valent mieux qu’une ; je me fie à votre jugement.",
                    SITUATION_ENDING.EXPLOSION,
                    new AlertResponseToAnswer("On va essayer de se servir de nos têtes pour nous protéger de l'explosion imminente, chef !", BACKGROUND.RED_ALERT, CREW_EMOTION.HAPPY)),
                new AlertAnswer(
                    "D'accord, vous avez ma permission, mais juste pour cette fois.",
                    SITUATION_ENDING.EXPLOSION,
                    new AlertResponseToAnswer("Merci, chef ! On ne vous décevra pas !", BACKGROUND.NORMAL_SHIP, CREW_EMOTION.HAPPY))
            }),

        new AlertSituation(
            "Chef, on a repéré un vaisseau allié en provenance de la Terre. Ils ont peut-être de l'équipement et du carburant pour nous",
            BACKGROUND.NORMAL_SHIP,
            CREW_EMOTION.HAPPY,
            new AlertAnswer[]
            {
                new AlertAnswer(
                    "Envoyez un message au vaisseau allié pour les informer de vos intentions pacifiques.",
                    SITUATION_ENDING.CUT,
                    new AlertResponseToAnswer("Nos alliés nous ont donné tout ce qu'il nous faut pour compléter notre mission !", BACKGROUND.NORMAL_SHIP, CREW_EMOTION.HAPPY)),
                new AlertAnswer(
                    "Tentez d’établir un premier contact avec le vaisseau allié.",
                    SITUATION_ENDING.EXPLOSION,
                    new AlertResponseToAnswer("Journal de bord : notre vaisseau est entré en collision frontale avec le vaisseau allié. Explosion imminente.", BACKGROUND.RED_ALERT, CREW_EMOTION.ABSENT)),
                new AlertAnswer(
                    "Évitez tout contact avec le moindre vaisseau, il s'agit peut être d’un piège.",
                    SITUATION_ENDING.EXPLOSION,
                    new AlertResponseToAnswer("Journal de bord : l'équipage s'éloigne actuellement de notre vaisseau à bord d'une capsule de sauvetage.", BACKGROUND.NORMAL_SHIP, CREW_EMOTION.ABSENT)),
                new AlertAnswer(
                    "C’est sûrement un ennemi, détruisez-le !",
                    SITUATION_ENDING.EXPLOSION,
                    new AlertResponseToAnswer("Leur vaisseau riposte ! Il est bien plus puissant que nous ! Adieu, chef !", BACKGROUND.RED_ALERT, CREW_EMOTION.PANICKED)),
                new AlertAnswer(
                    "Allez, contactez nos alliés et qu'ça saute !!",
                    SITUATION_ENDING.EXPLOSION,
                    new AlertResponseToAnswer("Journal de bord : Explosion détectée. Origine inconnue. Enquête en cours.", BACKGROUND.SAVED_MESSAGE, CREW_EMOTION.ABSENT))
            }),



        new AlertSituation(
            "Chef, un monstre alien s'est infiltré dans le vaisseau que devons nous faire pour règler la situation.",
            BACKGROUND.MONSTER,
            CREW_EMOTION.PANICKED,
            new AlertAnswer[]
            {
                new AlertAnswer(
                    "Activez le système d’auto-défense.",
                    SITUATION_ENDING.CUT,
                    new AlertResponseToAnswer("Merci pour le conseil, chef ! La créature a été éradiquée avec succès !", BACKGROUND.NORMAL_SHIP, CREW_EMOTION.HAPPY)),
                new AlertAnswer(
                    "Repoussez l'envahisseur !",
                    SITUATION_ENDING.EXPLOSION,
                    new AlertResponseToAnswer("Journal de bord : Rapport de décès. L’équipage a tenté de pousser la créature hors du vaisseau mais leur force physique n’était pas suffisante pour y parvenir.", BACKGROUND.SAVED_MESSAGE, CREW_EMOTION.DEAD)),
                new AlertAnswer(
                    "Battez-vous comme des lions !",
                    SITUATION_ENDING.EXPLOSION,
                    new AlertResponseToAnswer("Journal de bord : Rapport de décès. L’équipage a rugi très fort mais cela n'a eu aucun effet sur la créature.", BACKGROUND.SAVED_MESSAGE, CREW_EMOTION.DEAD)),
                new AlertAnswer(
                    "Battez-vous !",
                    SITUATION_ENDING.EXPLOSION,
                    new AlertResponseToAnswer("Journal de bord : Les membres de l’équipage se sont battus à mort sous le regard horrifié de la créature qui les regardait s'affronter entre eux.", BACKGROUND.SAVED_MESSAGE, CREW_EMOTION.DEAD)),
                new AlertAnswer(
                    "Feu !",
                    SITUATION_ENDING.EXPLOSION,
                    new AlertResponseToAnswer("C’est pas pour critiquer, chef, mais on voit pas vraiment comment ça pourrait aider ?", BACKGROUND.FIRE, CREW_EMOTION.PUZZLED))
            }),



        new AlertSituation(
            "Message : Chef, vous allez rire, on va traverser une zone de turbulences !",
            BACKGROUND.RED_ALERT,
            CREW_EMOTION.HAPPY,
            new AlertAnswer[]
            {
                new AlertAnswer(
                    "Bouclez vos ceintures de sécurité !",
                    SITUATION_ENDING.CUT,
                    new AlertResponseToAnswer("Ça fonctionne, chef. Et en plus, ça nous fait un super look !", BACKGROUND.RED_ALERT, CREW_EMOTION.HAPPY)),
                new AlertAnswer(
                    "Poussez les moteurs, on va essayer de passer en force !",
                    SITUATION_ENDING.NONE,
                    new AlertResponseToAnswer("On a essayé de pousser les moteurs mais ça ne bouge pas d’un pouce, chef !", BACKGROUND.RED_ALERT, CREW_EMOTION.DISAPPOINTED)),
                new AlertAnswer(
                    "Sortez de là le plus rapidement possible !",
                    SITUATION_ENDING.EXPLOSION,
                    new AlertResponseToAnswer("Journal de bord : utilisation du sas d’évacuation détectée.", BACKGROUND.SPACE, CREW_EMOTION.DEAD)),
                new AlertAnswer(
                    "Je ne vois pas ce qu’il y a de drôle !",
                    SITUATION_ENDING.NONE,
                    new AlertResponseToAnswer("Bah turbulence c’est un mot rigolo quand même.", BACKGROUND.RED_ALERT, CREW_EMOTION.DISAPPOINTED)),
                new AlertAnswer(
                    "Je pense que ces météorites sont au moins aussi intelligents que vous !",
                    SITUATION_ENDING.NONE,
                    new AlertResponseToAnswer("Merci du compliment, chef !", BACKGROUND.RED_ALERT, CREW_EMOTION.HAPPY))
            }),




        new AlertSituation(
            "Chef, un vaisseau Xlubien s’approche à grande vitesse. Et ils nous envoient des messages plein de gros mots. Qu’est-ce qu’on fait ?",
            BACKGROUND.RED_ALERT,
            CREW_EMOTION.PUZZLED,
            new AlertAnswer[]
            {
                new AlertAnswer(
                    "Activez les boucliers et déclenchez les torpilles !",
                    SITUATION_ENDING.CUT,
                    new AlertResponseToAnswer("Chef, c’est dommage, le vaisseau Xlubien est détruit ! On ne saura jamais ce qu’ils voulaient nous dire !", BACKGROUND.NORMAL_SHIP, CREW_EMOTION.HAPPY)),
                new AlertAnswer(
                    "Ils essaient de vous déstabiliser, coupez les communications !",
                    SITUATION_ENDING.NONE,
                    new AlertResponseToAnswer("Journal de bord : Bonjour et bienvenue ! Malheureusement, toutes nos communications sont coupées ! Laissez-nous un message après le bip !", BACKGROUND.SAVED_MESSAGE, CREW_EMOTION.ABSENT)),
                new AlertAnswer(
                    "Tirez sur le vaisseau !",
                    SITUATION_ENDING.EXPLOSION,
                    new AlertResponseToAnswer("OK, on a tout détruit dans la salle de contrôle, vous voulez qu’on s’attaque au reste du vaisseau ?", BACKGROUND.FIRE, CREW_EMOTION.HAPPY)),
                new AlertAnswer(
                    "Vous devez vous montrer plus malins que l'ennemi !",
                    SITUATION_ENDING.NONE,
                    new AlertResponseToAnswer("Ce ne sera pas dur, chef ! Dites nous juste exactement quoi faire !", BACKGROUND.RED_ALERT, CREW_EMOTION.HAPPY)),
                new AlertAnswer(
                    "Faites semblant de ne pas l'avoir vu.",
                    SITUATION_ENDING.NONE,
                    new AlertResponseToAnswer("Nous ne sommes pas programmmés pour agir de façon décontractée, chef !", BACKGROUND.RED_ALERT, CREW_EMOTION.DISAPPOINTED))
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
