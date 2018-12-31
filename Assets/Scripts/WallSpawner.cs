using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour {


    public GameObject wallSpawnerParent;
    public float spawnRate;

    public bool[] introWalls = new bool[9];
	// Use this for initialization
	void Start () {
        //WallInstantiate();
        spawnRate = 5;
        StartCoroutine("SpawnWall");
        
	}
	
	// Update is called once per frame
	void Update () {

        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase10)
        {
            spawnRate = 2.5f;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase9)
        {
            spawnRate = 5;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase8)
        {
            spawnRate = 2;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase7)
        {
            spawnRate = 2;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase6)
        {
            spawnRate = 2;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase5)
        {
            spawnRate = 5;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase4)
        {
            spawnRate = 20;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase3)
        {
            spawnRate = 2.5f;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase2)
        {
            spawnRate = 5;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase1)
        {
            spawnRate = 2.5f;
        }

    }

    IEnumerator SpawnWall()
    {

        WallInstantiate();
        yield return new WaitForSeconds(spawnRate);
        
        StartCoroutine("SpawnWall");

    }

    void WallInstantiate()
    {
        int randomWall = Random.Range(11, 18);
        int randomWallForLaser = Random.Range(11, 18);
        //Debug.Log("Spawning a Wall number: " + randomWall);
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase2 && !introWalls[0])
        {
            Instantiate(Resources.Load("FrontWalls/Transition2"), new Vector3(0, wallSpawnerParent.transform.position.y, wallSpawnerParent.transform.position.z + 58), Quaternion.identity);
            introWalls[0] = true;
        } else if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase3 && !introWalls[1])
        {
            Instantiate(Resources.Load("FrontWalls/Transition3"), new Vector3(0, wallSpawnerParent.transform.position.y, wallSpawnerParent.transform.position.z + 58), Quaternion.identity);
            introWalls[1] = true;
        }
        else if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase4 && !introWalls[2])
        {
            Instantiate(Resources.Load("FrontWalls/Transition4"), new Vector3(0, wallSpawnerParent.transform.position.y, wallSpawnerParent.transform.position.z + 58), Quaternion.identity);
            introWalls[2] = true;
        }
        else if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase5 && !introWalls[3])
        {
            Instantiate(Resources.Load("FrontWalls/Transition5"), new Vector3(0, wallSpawnerParent.transform.position.y, wallSpawnerParent.transform.position.z + 58), Quaternion.identity);
            introWalls[3] = true;
        }
        else if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase6 && !introWalls[4])
        {
            Instantiate(Resources.Load("FrontWalls/Transition6"), new Vector3(0, wallSpawnerParent.transform.position.y, wallSpawnerParent.transform.position.z + 58), Quaternion.identity);
            introWalls[4] = true;
        }
        else if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase7 && !introWalls[5])
        {
            Instantiate(Resources.Load("FrontWalls/Transition7"), new Vector3(0, wallSpawnerParent.transform.position.y, wallSpawnerParent.transform.position.z + 58), Quaternion.identity);
            introWalls[5] = true;
        }
        else if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase8 && !introWalls[6])
        {
            Instantiate(Resources.Load("FrontWalls/Transition8"), new Vector3(0, wallSpawnerParent.transform.position.y, wallSpawnerParent.transform.position.z + 58), Quaternion.identity);
            introWalls[6] = true;
        }
        else if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase9 && !introWalls[7])
        {
            Instantiate(Resources.Load("FrontWalls/Transition9"), new Vector3(0, wallSpawnerParent.transform.position.y, wallSpawnerParent.transform.position.z + 58), Quaternion.identity);
            introWalls[7] = true;
        }
        else if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase10 && !introWalls[8])
        {
            Instantiate(Resources.Load("FrontWalls/Transition10"), new Vector3(0, wallSpawnerParent.transform.position.y, wallSpawnerParent.transform.position.z + 58), Quaternion.identity);
            introWalls[8] = true;
        }

        else
        {
            if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase3 || GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase6 || GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase8 || GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase9 || GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase10)
            {
                Instantiate(Resources.Load("FrontWalls/Wall" + randomWallForLaser), new Vector3(0, wallSpawnerParent.transform.position.y, wallSpawnerParent.transform.position.z), Quaternion.identity);
            }
            else
            {
                Instantiate(Resources.Load("FrontWalls/Wall" + randomWall), new Vector3(0, wallSpawnerParent.transform.position.y, wallSpawnerParent.transform.position.z), Quaternion.identity);
            }
            
        }
        
        
    }
}
