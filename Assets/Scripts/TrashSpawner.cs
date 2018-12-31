using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour {


    public GameObject wallSpawnerParent;
    public GameObject gameControllerObject;
    public GameObject playerGameObject;
    private DifficultyManager difficultyManager;

    private int countBeforeBolt = 0;
    public float spawnRate;

   
	// Use this for initialization
	void Start () {
        //WallInstantiate();
        difficultyManager = gameControllerObject.GetComponent<DifficultyManager>();
        spawnRate = 5;
        StartCoroutine("SpawnWall");
        
	}
	
	// Update is called once per frame
	void Update () {

       
            if (GameMaster.gameMaster.chronologicalPhase == GameMaster.ChronologicalPhase.cPhase10)
            {
                spawnRate = 1;
            }
            if (GameMaster.gameMaster.chronologicalPhase == GameMaster.ChronologicalPhase.cPhase9)
            {
                spawnRate = 1.2f;
            }
            if (GameMaster.gameMaster.chronologicalPhase == GameMaster.ChronologicalPhase.cPhase8)
            {
                spawnRate = 1.3f;
            }
            if (GameMaster.gameMaster.chronologicalPhase == GameMaster.ChronologicalPhase.cPhase7)
            {
                spawnRate = 1.4f;
            }
            if (GameMaster.gameMaster.chronologicalPhase == GameMaster.ChronologicalPhase.cPhase6)
            {
                spawnRate = 1.5f;
            }
            if (GameMaster.gameMaster.chronologicalPhase == GameMaster.ChronologicalPhase.cPhase5)
            {
                spawnRate = 1.6f;
            }
            if (GameMaster.gameMaster.chronologicalPhase == GameMaster.ChronologicalPhase.cPhase4)
            {
                spawnRate = 1.7f;
            }
            if (GameMaster.gameMaster.chronologicalPhase == GameMaster.ChronologicalPhase.cPhase3)
            {
                spawnRate = 1.8f;
            }
            if (GameMaster.gameMaster.chronologicalPhase == GameMaster.ChronologicalPhase.cPhase2)
            {
                spawnRate = 1.9f;
            }
            if (GameMaster.gameMaster.chronologicalPhase == GameMaster.ChronologicalPhase.cPhase1)
            {
                spawnRate = 2f;
            }


    }

    IEnumerator SpawnWall()
    {
        if (difficultyManager.gameHasStarted && !difficultyManager.gameIsTransitioning && !difficultyManager.gameIsPreTransition)
        {
            WallInstantiate();
        }
            yield return new WaitForSeconds(spawnRate);
            StartCoroutine("SpawnWall");
        
           

    }

    void WallInstantiate()
    {

        //Normal: 0, 6, 10
        //Electric: 1, 7
        //Drones: 2
        //Balls: 4, 8
        //Pushers: 3
        //Shooter: 5

        //Tester: use this to test any phase
        //SpawnNormalStuff();
        //SpawnElectricStuff();
        SpawnDrones();
       //SpawnBalls();
        //SpawnPushers();
        /*
        
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase0 || GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase6 || GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase10)
        {
            SpawnNormalStuff();
        }
        else if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase1 || GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase7)
        {
            SpawnElectricStuff();
        }
        else if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase2 || GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase9)
        {
            SpawnDrones();
        }
        else if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase4 || GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase8) //Spawn a big wall
        {
            SpawnBalls();
        }
        else if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase3)
        {
            SpawnPushers();
        }
        else
        {
            //Do nothing if the phase doesn't call for anything specific. 

        }*/
        



        countBeforeBolt++;

        if (countBeforeBolt >= 2)
        {
            int randomAngle = Random.Range(1, 180);
            float randomXPos = Random.Range(-3, 4);
            float randomZPos = Random.Range(-8, -6);

            if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase2 || GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase3 || GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase5 || GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase9)
            {
                Instantiate(Resources.Load("Misc/BoltPickUp"), new Vector3(0 + randomXPos, wallSpawnerParent.transform.position.y + 10, wallSpawnerParent.transform.position.z + randomZPos - 18), Quaternion.Euler(0 + randomAngle, 0, 0));
            }
            else
            {
                Instantiate(Resources.Load("Misc/BoltPickUp"), new Vector3(0 + randomXPos, wallSpawnerParent.transform.position.y + 10, wallSpawnerParent.transform.position.z + 5), Quaternion.Euler(0 + randomAngle, 0, 0));
            }

            countBeforeBolt = 0;
            //Spawns bolts out front.
            //Instantiate(Resources.Load("Misc/BoltPickUp"), new Vector3(0 + randomXPos, wallSpawnerParent.transform.position.y + 10, wallSpawnerParent.transform.position.z + randomZPos - 8), Quaternion.Euler(0 + randomAngle, 0, 0));

            //Spawns bolts slightly behind the conveyor belt.

        }




    }

    private void SpawnNormalStuff()
    {


        int randomWall = Random.Range(1, 6);

        int randomWallXPos = Random.Range(1, 3);

       

        if (randomWall == 1) //Spawns a single TALL wall. Wall will spawn either left or right.
        {
            if (randomWallXPos == 1)
            {
                Instantiate(Resources.Load("Trash/Box_Tall"), new Vector3(-1, wallSpawnerParent.transform.position.y - 4, wallSpawnerParent.transform.position.z + 2), Quaternion.Euler(0, 0, 0));
            }
            else
            {
                Instantiate(Resources.Load("Trash/Box_Tall"), new Vector3(1, wallSpawnerParent.transform.position.y - 4, wallSpawnerParent.transform.position.z + 2), Quaternion.Euler(0, 0, 0));
            }
        }
        else if (randomWall == 2) //Spawns a single LOW wall.
        {
            if (randomWallXPos == 1)
            {
                Instantiate(Resources.Load("Trash/Box_Short"), new Vector3(-1, wallSpawnerParent.transform.position.y - 4, wallSpawnerParent.transform.position.z + 2), Quaternion.Euler(0, 0, 0));
            }
            else
            {
                Instantiate(Resources.Load("Trash/Box_Short"), new Vector3(1, wallSpawnerParent.transform.position.y - 4, wallSpawnerParent.transform.position.z + 2), Quaternion.Euler(0, 0, 0));
            }
        }
        else if (randomWall == 3) //Spawns walls that require jumping.
        {
            int wallToChoose = Random.Range(1, 4);
            if (wallToChoose == 1)
            {
                Instantiate(Resources.Load("Trash/StackedBox_MiddleOpening"), new Vector3(0, wallSpawnerParent.transform.position.y - 4, wallSpawnerParent.transform.position.z + 2), Quaternion.Euler(0, 0, 0));
            }
            else if (wallToChoose == 2)
            {
                Instantiate(Resources.Load("Trash/Box_OpeningL"), new Vector3(0, wallSpawnerParent.transform.position.y - 4, wallSpawnerParent.transform.position.z + 2), Quaternion.Euler(0, 0, 0));
            }
            else
            {
                Instantiate(Resources.Load("Trash/Box_OpeningR"), new Vector3(0, wallSpawnerParent.transform.position.y - 4, wallSpawnerParent.transform.position.z + 2), Quaternion.Euler(0, 0, 0));
            }

        }
        else if (randomWall == 4) //Spawns a double wall with gap in the middle.
        {
            int wallToChoose = Random.Range(1, 3);
            if (wallToChoose == 1)
            {
                Instantiate(Resources.Load("Trash/DoubleBox_Short"), new Vector3(0, wallSpawnerParent.transform.position.y - 4, wallSpawnerParent.transform.position.z + 2), Quaternion.Euler(0, 0, 0));
            }
            else
            {
                Instantiate(Resources.Load("Trash/DoubleBox_Tall"), new Vector3(0, wallSpawnerParent.transform.position.y - 4, wallSpawnerParent.transform.position.z + 2), Quaternion.Euler(0, 0, 0));
            }

        }
        else //Spawn a ball.
        {
            float randomXPos = Random.Range(-2, 3);
            int randomProjectile = Random.Range(4, 7);
            Instantiate(Resources.Load("Projectiles/Ball" + randomProjectile), new Vector3(0 + randomXPos, wallSpawnerParent.transform.position.y, wallSpawnerParent.transform.position.z + 15), Quaternion.Euler(0, 0, -90));

        }


        


        for (int i = 0; i < 3; i++)
        {
            float xPosForClutter = 0;

            int randomAngle = Random.Range(1, 180);
            int randomClutter = Random.Range(1, 4);
            float randomXPos = Random.Range(-3, 4);
            float randomYpos = Random.Range(15, 21);
            float randomZPos = Random.Range(0, 8);
            xPosForClutter += .2f;
            Instantiate(Resources.Load("Trash/SmallBox" + randomClutter), new Vector3(randomXPos, wallSpawnerParent.transform.position.y + randomYpos, wallSpawnerParent.transform.position.z + randomZPos), Quaternion.Euler(0 + randomAngle, 0 + randomAngle, 0 + randomAngle));

        }
    }

    private void SpawnPushers() //Center pusher needs to spawn at 0
    {        
        int randomPusher = Random.Range(1, 3); //2 different types of pushers

        if (randomPusher == 1) //Spawn wide pusher.
        {
            Instantiate(Resources.Load("Pushers/Pusher1"), new Vector3(0, wallSpawnerParent.transform.position.y - 7.6f, wallSpawnerParent.transform.position.z + 20), Quaternion.Euler(0, 0, 0));
        }
        else //Spawn small pusher.
        {
            float randomXPos = Random.Range(-2, 3);

            Instantiate(Resources.Load("Pushers/Pusher2"), new Vector3(0 + randomXPos, wallSpawnerParent.transform.position.y - 7.6f, wallSpawnerParent.transform.position.z + 20), Quaternion.Euler(0, 0, 0));
        }

        for (int i = 0; i < 7; i++)
        {
            float xPosForClutter = 0;

            int randomAngle = Random.Range(1, 180);
            int randomClutter = Random.Range(1, 4);
            float randomXPos = Random.Range(-3, 4);
            float randomYpos = Random.Range(30, 36);
            float randomZPos = Random.Range(18, 35);
            xPosForClutter += .2f;
            Instantiate(Resources.Load("Pushers/PusherBox" + randomClutter), new Vector3(randomXPos, wallSpawnerParent.transform.position.y + randomYpos, wallSpawnerParent.transform.position.z - randomZPos), Quaternion.Euler(0 + randomAngle, 0 + randomAngle, 0 + randomAngle));

        }
    }

    private void SpawnDrones()
    {
        float randomXPos = Random.Range(-1, 2);
        int randomWall = Random.Range(1, 3); //3 different types of drones.
        if (randomWall == 2)
        {
            Instantiate(Resources.Load("Drones/Drone2"), new Vector3(0, wallSpawnerParent.transform.position.y - 7.1f, wallSpawnerParent.transform.position.z + 15), Quaternion.Euler(0, 0, 0));
        }
        else
        {
            Instantiate(Resources.Load("Drones/Drone1"), new Vector3(0 + randomXPos, wallSpawnerParent.transform.position.y - 7.1f, wallSpawnerParent.transform.position.z + 15), Quaternion.Euler(0, 0, 0));
        }
    }

    private void SpawnBalls()
    {
        int randomRotation = Random.Range(0, 181);
        float randomXPos = Random.Range(-2, 3);
        int randomWall = Random.Range(1, 5); //3 different types of balls
        if (randomWall == 4)
        {
            Instantiate(Resources.Load("Projectiles/Ball3B"), new Vector3(0, wallSpawnerParent.transform.position.y + 5, wallSpawnerParent.transform.position.z + 5), Quaternion.Euler(0, 0, 90));

        }
        else if (randomWall == 3)
        {
            Instantiate(Resources.Load("Projectiles/Ball3A"), new Vector3(0 + randomXPos, wallSpawnerParent.transform.position.y, wallSpawnerParent.transform.position.z), Quaternion.Euler(0, 0, 90));
        }
        else
        {
            Instantiate(Resources.Load("Projectiles/Ball" + randomWall), new Vector3(0 + randomXPos, wallSpawnerParent.transform.position.y, wallSpawnerParent.transform.position.z), Quaternion.Euler(0, 0, randomRotation));
        }
    }

    private void SpawnElectricStuff()
    {
        int randomWall = Random.Range(1, 6);     

        //      1:  ||||__  or   __||||

        //      2:  ||_||_||

        //      3:  |_|_|||| or  ||||_|_|

        //      4:  ||_|||| or ||||_||

        //      5: ___||___

        if (randomWall == 1)
        {
            int randomWallXPos = Random.Range(1, 3);

            if (randomWallXPos == 1)
            {
                Instantiate(Resources.Load("Electric/Electric1"), new Vector3(-.5f, wallSpawnerParent.transform.position.y - 4, wallSpawnerParent.transform.position.z + 2), Quaternion.Euler(0, 0, 0));
            }
            else
            {
                Instantiate(Resources.Load("Electric/Electric1"), new Vector3(.5f, wallSpawnerParent.transform.position.y - 4, wallSpawnerParent.transform.position.z + 2), Quaternion.Euler(0, 0, 0));
            }
        }
        else if (randomWall == 2) //Center piece.
        { 
            Instantiate(Resources.Load("Electric/Electric2"), new Vector3(0, wallSpawnerParent.transform.position.y - 4, wallSpawnerParent.transform.position.z + 2), Quaternion.Euler(0, 0, 0));
        }
        else if (randomWall == 3) //Center piece.
        {
            int wallToChoose = Random.Range(1, 3);
            if (wallToChoose == 1)
            {
                Instantiate(Resources.Load("Electric/Electric3A"), new Vector3(0, wallSpawnerParent.transform.position.y - 4, wallSpawnerParent.transform.position.z + 2), Quaternion.Euler(0, 0, 0));
            }
            else
            {
                Instantiate(Resources.Load("Electric/Electric3B"), new Vector3(0, wallSpawnerParent.transform.position.y - 4, wallSpawnerParent.transform.position.z + 2), Quaternion.Euler(0, 0, 0));
            }

        }
        else if (randomWall == 4) //Center piece.
        {
            int wallToChoose = Random.Range(1, 3);
            if (wallToChoose == 1)
            {
                Instantiate(Resources.Load("Electric/Electric4A"), new Vector3(0, wallSpawnerParent.transform.position.y - 4, wallSpawnerParent.transform.position.z + 2), Quaternion.Euler(0, 0, 0));
            }
            else
            {
                Instantiate(Resources.Load("Electric/Electric4B"), new Vector3(0, wallSpawnerParent.transform.position.y - 4, wallSpawnerParent.transform.position.z + 2), Quaternion.Euler(0, 0, 0));
            }

        }
        else //Center piece 5.
        {
            Instantiate(Resources.Load("Electric/Electric5"), new Vector3(0, wallSpawnerParent.transform.position.y - 4, wallSpawnerParent.transform.position.z + 2), Quaternion.Euler(0, 0, 0));
        }
    }
}
