using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWallManager : MonoBehaviour {


    float moveSpeed = 100;
    float step;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        step = moveSpeed * Time.deltaTime;

        int c = (int)GameMaster.gameMaster.currentPhase;
        switch (c)
        {
            case 0:
                //MoveSideWallsBack(0);
                break;
            case 1:
                MoveSideWallsBack(-300);
                break;
            case 2:
                MoveSideWallsBack(-600);
                break;
            case 3:
                MoveSideWallsBack(-900);
                break;
            case 4:
                MoveSideWallsBack(-1200);
                break;
            case 5:
                MoveSideWallsBack(-1500);
                break;
            case 6:
                MoveSideWallsBack(-1800);
                break;
            case 7:
                MoveSideWallsBack(-2100);
                break;
            case 8:
                MoveSideWallsBack(-2400);
                break;
            case 9:
                MoveSideWallsBack(-2700);
                break;
            case 10:
                MoveSideWallsBack(-3000);
                break;
            default:
                MoveSideWallsBack(0);
                break;
        }
    }

    void MoveSideWallsBack(float targetZ)
    {
        //Vector3 target = new Vector3(0,0,targetZ);
        //transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        //transform.position = Vector3.MoveTowards(transform.position, ( transform.position + target), step);
        //transform.position = new Vector3(0,0,transform.position.z - targetZ);
        transform.Translate( new Vector3(0, 0, transform.position.z - targetZ));
    }
}
