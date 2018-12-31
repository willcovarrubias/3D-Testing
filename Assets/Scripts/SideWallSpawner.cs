using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWallSpawner : MonoBehaviour {

    public Transform wallSpawnerParent;
    private float spawnRate;
    // Use this for initialization
    void Start()
    {
        spawnRate = 8;
        WallInstantiate();
        StartCoroutine("SpawnWall");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase10)
        {
            spawnRate = 4f;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase9 )
        {
            spawnRate = 4.2f;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase8 )
        {
            spawnRate = 4.3f;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase7)
        {
            spawnRate = 4.4f;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase6)
        {
            spawnRate = 5f;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase5)
        {
            spawnRate = 5.8f;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase4)
        {
            spawnRate = 6.2f;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase3)
        {
            spawnRate = 6.8f;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase2)
        {
            spawnRate = 7.2f;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase1)
        {
            spawnRate = 8;
        }


    }

    IEnumerator SpawnWall()
    {


        yield return new WaitForSeconds(spawnRate);
        WallInstantiate();
        StartCoroutine("SpawnWall");

    }

    void WallInstantiate()
    {
        
        Instantiate(Resources.Load("Background/Background"), new Vector3(wallSpawnerParent.transform.position.x, wallSpawnerParent.transform.position.y, wallSpawnerParent.transform.position.z), Quaternion.Euler(0, 0, wallSpawnerParent.rotation.z));

    }
}
