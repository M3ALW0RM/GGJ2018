using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonShoot : MonoBehaviour {

    public CannonBehavior test;
	
	// Update is called once per frame
	void Update () {
		
        if(Input.mousePosition.x>416)
        {
            if(Input.GetMouseButtonDown(0))
            {
                test.MoveCannon();
            }
        }



    }
}
