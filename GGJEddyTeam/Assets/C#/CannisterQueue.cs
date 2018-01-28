using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannisterQueue : MonoBehaviour {

    [SerializeField]
    private Cannister cannisterPrefab;
    [SerializeField]
    private CannonBehavior cannon;

    private List<Cannister> visibleCannisterList;

    private List<AlertAnswer> totalAlertList;

    private float animOffset = 0.05f; //value in animation "time" in between two cans = distance between cans

    public void AddCannister(AlertAnswer message)
    {
        Cannister newCan = Instantiate(cannisterPrefab, this.transform, true);
        float canPosition = 0.6f;
        if(visibleCannisterList.Count > 0)
        {
            Cannister previousCan = visibleCannisterList[visibleCannisterList.Count-1];
            float slidePos = previousCan.slidePos - animOffset;
            if (previousCan.goingDown > 0)
                slidePos = previousCan.goingDownStart + animOffset * previousCan.goingDown - animOffset;
            canPosition = Mathf.Min( 0.6f - animOffset, slidePos );
        }
        newCan.Initialize(message, canPosition );
        visibleCannisterList.Add(newCan);
    }

    private string[] randomMessages = new string[]{"Revenez !", "Exécutez l'ordre 66.", "Foncez sur la cible !", "Sacrifiez vous !", "Paix et prospérité.", "Formation d'attaque !", "Formation de défense !", "Méfiez vous.", "Vous n'êtes pas prêt.",  "Vers l'infini et au delà !", "Interceptez la menace !", "Ne faites rien.", "Cette phrase est fausse.", "Interdiction formelle de faire ça.", "Nettoyez le vaisseau.", "Annulez l'ordre précédent."};

    // Use this for initialization
    void Start ()
    {
        visibleCannisterList = new List<Cannister>();
        for (int i = 0; i < 5; ++i)
        {
            AddCannister(new AlertAnswer(randomMessages[i], SITUATION_ENDING.EXPLOSION, new AlertResponseToAnswer()));
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        //DEV - REMOVE WHEN CODE IS IN TO ADD MESSAGES
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AddCannister(Alert.possibleAlertSituations[0].answers[0] );
        }

        int canNum = visibleCannisterList.Count;

        for( int i = 0; i<canNum; i++)
        {
            Cannister can = visibleCannisterList[i];
            if(can.ejected)
            {
                for( int j = canNum-1; j>i; j--)
                {
                    visibleCannisterList[j].GoDown(animOffset);
                }

                cannon.FireCannon(can.message);

                visibleCannisterList.Remove(can);
                AddCannister(new AlertAnswer(can.message.text, SITUATION_ENDING.EXPLOSION, new AlertResponseToAnswer()));
                break;
            }
            else if( can.outOfRange )
            {
                visibleCannisterList.Remove(can);
                AddCannister(new AlertAnswer(can.message.text, SITUATION_ENDING.EXPLOSION, new AlertResponseToAnswer()));
                can.Kill();
                break;
            }

        }
	}
}
