using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannisterQueue : MonoBehaviour {

    [SerializeField]
    private Cannister cannisterPrefab;

    private List<Cannister> cannisterList;


    public void AddCannister(string message)
    {
        Cannister newCan = Instantiate(cannisterPrefab, this.transform, true);
        newCan.Initialize(message, cannisterList.Count);
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
            if( can.outOfRange )
            {
                for( int j = canNum-1; j>i; j--)
                {
                    cannisterList[j].GoDown();
                }
                ////////INSERT CODE FOR FIRING MESSAGE////////
                cannisterList.Remove(can);
                break;
            }
        }
	}
}
