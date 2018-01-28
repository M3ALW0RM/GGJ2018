using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannisterQueue : MonoBehaviour {

    [SerializeField]
    private Cannister cannisterPrefab;

    private List<Cannister> cannisterList;

    private float animOffset = 0.05f; //value in animation "time" in between two cans = distance between cans

    public void AddCannister(string message)
    {
        Cannister newCan = Instantiate(cannisterPrefab, this.transform, true);
        float canPosition = 0.6f;
        if(cannisterList.Count > 0)
        {
            Cannister previousCan = cannisterList[cannisterList.Count-1];
            float slidePos = previousCan.slidePos - animOffset;
            if (previousCan.goingDown > 0)
                slidePos = previousCan.goingDownStart + animOffset * previousCan.goingDown - animOffset;
            canPosition = Mathf.Min( 0.6f - animOffset, slidePos );
        }
        newCan.Initialize(message, canPosition );
        cannisterList.Add(newCan);
    }

	// Use this for initialization
	void Start ()
    {
        cannisterList = new List<Cannister>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //DEV - REMOVE WHEN CODE IS IN TO ADD MESSAGES
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AddCannister("test");
        }

        int canNum = cannisterList.Count;

        for( int i = 0; i<canNum; i++)
        {
            Cannister can = cannisterList[i];
            if(can.ejected)
            {
                for( int j = canNum-1; j>i; j--)
                {
                    cannisterList[j].GoDown(animOffset);
                }
                ////////INSERT CODE FOR FIRING MESSAGE////////
                cannisterList.Remove(can);
                break;
            }
            else if( can.outOfRange )
            {
                cannisterList.Remove(can);
                can.Kill();
                break;
            }

        }
	}
}
