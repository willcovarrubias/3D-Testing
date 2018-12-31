using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour {

    public bool isThisARightShooter;
    public Transform projectileSpawnerParentRight;
    public Transform projectileSpawnerParentLeft;
    // public int spawnRate;
    public float minTimeToFire;
    public float maxTimeToFire;
    private float fireRate;
    private float randomZPos;
    private float minZpos;
    private float maxZpos;
    private float yAxisAngle;
    // Use this for initialization
    void Start()
    {

        StartCoroutine("SpawnProjectile");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase10)
        {
            minZpos = 5f;
            maxZpos = 15f;
            minTimeToFire = .25f;
            maxTimeToFire = .5f;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase9)
        {
            minZpos = 5.5f;
            maxZpos = 15.5f;
            minTimeToFire = .4f;
            maxTimeToFire = .6f;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase8)
        {
            minZpos = 4f;
            maxZpos = 14f;
            minTimeToFire = .4f;
            maxTimeToFire = .7f;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase7)
        {
            minZpos = 3f;
            maxZpos = 12f;
            minTimeToFire = .4f;
            maxTimeToFire = .8f;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase6)
        {
            minZpos = 2.5f;
            maxZpos = 11f;
            minTimeToFire = .5f;
            maxTimeToFire = .8f;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase5)
        {
            minZpos = 2f;
            maxZpos = 10f;
            minTimeToFire = .5f;
            maxTimeToFire = 1f;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase4)
        {
            minZpos = 0f;
            maxZpos = 6.2f;
            minTimeToFire = .8f;
            maxTimeToFire = 1.5f;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase3)
        {
            minZpos = -1.5f;
            maxZpos = 5f;
            minTimeToFire = .8f;
            maxTimeToFire = 1.8f;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase2)
        {
            minZpos = -1.5f;
            maxZpos = 5.5f;
            //minTimeToFire = 1f;
            //maxTimeToFire = 2f;
            minTimeToFire = 20;
            maxTimeToFire = 20;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase1)
        {
            minZpos = -8f;
            maxZpos = 0f;
            minTimeToFire = 1f;
            maxTimeToFire = 2f;
        }

    }

    IEnumerator SpawnProjectile()
    {
        fireRate = Random.Range(1, 3);

        yield return new WaitForSeconds(fireRate);
        ProjectInstantiate();
        StartCoroutine("SpawnProjectile");

    }

    //Change projectile Z position spawn point according to difficulty.
    //Difficulty 1 : Thrust 400 - Min Z: 0,  Max Z: 7   //Y-Axis angle: 90
    //Difficulty 2 : Thrust 420                     6.8                 80
    //Difficulty 3 : Thrust 440                     6.6                 70
    //Difficulty 4 : Thrust 460                     6.4                 65
    //Difficulty 5 : Thrust 480               2 / 10     //Y-Axis angle : 60
    //Difficulty 6 : Thrust 500 - Min Z: 1, Max Z:  6                       58
    //Difficulty 7 : Thrust 520                     5.8                     54
    //Difficulty 8 : Thrust 540                     5.6                     50
    //Difficulty 9 : Thrust 560                     5.4                     45
    //Difficulty 10 : Thrust 580              8 / 18   // Y-axis angle : 40
    //Difficulty Infinite: Thrust 600 - Min Z: 0,  Max Z: 5
    void ProjectInstantiate()
    {
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase10)
        {
            yAxisAngle = 40;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase9)
        {
            yAxisAngle = 45;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase8)
        {
            yAxisAngle = 50;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase7)
        {
            yAxisAngle = 54;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase6)
        {
            yAxisAngle = 58;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase5)
        {
            yAxisAngle = 60;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase4)
        {
            yAxisAngle = 65;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase3)
        {
            yAxisAngle = 70;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase2)
        {
            yAxisAngle = 80;
        }
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase1)
        {
            yAxisAngle = 125;
        }


        randomZPos = Random.Range(-8, 0);
        if (isThisARightShooter)
        {
            GameObject projectile = Instantiate(Resources.Load("Projectiles/Projectile001"), new Vector3(projectileSpawnerParentRight.transform.position.x, projectileSpawnerParentRight.transform.position.y, projectileSpawnerParentRight.transform.position.z + randomZPos), Quaternion.Euler(0, -125 , projectileSpawnerParentRight.rotation.z)) as GameObject;
            projectile.transform.parent = projectileSpawnerParentRight;
        }
        else
        {
            GameObject projectile = Instantiate(Resources.Load("Projectiles/Projectile001"), new Vector3(projectileSpawnerParentLeft.transform.position.x, projectileSpawnerParentLeft.transform.position.y, projectileSpawnerParentLeft.transform.position.z + randomZPos), Quaternion.Euler(0, 125, projectileSpawnerParentLeft.rotation.z)) as GameObject;
            projectile.transform.parent = projectileSpawnerParentLeft;
        }
        

    }
}
