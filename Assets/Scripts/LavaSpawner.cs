using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSpawner : MonoBehaviour {

    public Transform wallSpawnerParent;
    private float spawnRate;
    // Use this for initialization
    void Start()
    {
        //WallInstantiate();
        spawnRate = 10;
        StartCoroutine("SpawnLava");
    }

    // Update is called once per frame
    void Update()
    {

        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase10)
        {
            spawnRate = 4;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase9)
        {
            spawnRate = 4.5f;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase8)
        {
            spawnRate = 5;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase7)
        {
            spawnRate = 5.5f;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase6)
        {
            spawnRate = 6;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase5)
        {
            spawnRate = 7;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase4)
        {
            spawnRate = 7.5f;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase3)
        {
            spawnRate = 8;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase2)
        {
            spawnRate = 8.5f;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase1)
        {
            spawnRate = 8;
        }

    }

    IEnumerator SpawnLava()
    {


        yield return new WaitForSeconds(spawnRate);
        LavaInstantiate();
        StartCoroutine("SpawnLava");

    }

    void LavaInstantiate()
    {
        //int randomWall = Random.Range(1, 4);
        //Debug.Log("Spawning a Wall number: " + randomWall);
        Instantiate(Resources.Load("Floors/Floor"), new Vector3(0, wallSpawnerParent.transform.position.y, wallSpawnerParent.transform.position.z), Quaternion.Euler(90, 90, wallSpawnerParent.rotation.z));

    }
}
