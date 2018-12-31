using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CubeDespawner : MonoBehaviour
{
    public Material destroyedMaterial;
    public bool failedToCleanAcid;
    public bool parentObject;


    private List<GameObject> models;
    private bool[] modelsActive = new bool[35];
    //private int selectionIndex = 0;

    private bool timeToClean;
    public float timer = 0f;
    private float countdownTimer;

    AudioManager audioManager;
    // Use this for initialization
    void Start()
    {
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.Log("No audio manager found!");
        }
        
        models = new List<GameObject>();
        foreach (Transform t in transform)
        {
            models.Add(t.gameObject);
            //t.gameObject.SetActive(false);
        }

        //models[3].SetActive(true);
        //GameMaster.gameMaster.unlockedPlatforms[22] = true;
        //GameMaster.gameMaster.unlockedPlatforms[23] = true;
        //GameMaster.gameMaster.unlockedPlatforms[24] = true;
        //GameMaster.gameMaster.unlockedPlatforms[26] = true;

        SpawnDefaultCubes();
        SpawnUnlockedCubes();

        for (int i = 0; i < GameMaster.gameMaster.rowsWithPlatforms.Length; i++)
        {
            CheckIfRowHasAPlatform();
        }

        StartCoroutine(TimerToStartAcid());
        StartCoroutine(TimerToStartBolts());
    }

    IEnumerator TimerToStartAcid()
    {
        float randomTimer = Random.Range(5, 9);
        yield return new WaitForSeconds(randomTimer);
        StartCoroutine(DestroyCube());
    }

    IEnumerator TimerToStartBolts()
    {
        float randomTimer = Random.Range(10, 13);
        yield return new WaitForSeconds(randomTimer);
        StartCoroutine(SpawnBolt());
    }

    void SpawnDefaultCubes()
    {
        for (int i = 0; i < 30; i++)
        {
            models[i].SetActive(true);
            modelsActive[i] = true;
        }
    }

    void SpawnUnlockedCubes()
    {
        for (int i = 0; i < GameMaster.gameMaster.unlockedPlatforms.Length; i++)
        {
            if (GameMaster.gameMaster.unlockedPlatforms[i] == true)
            {
                models[i + 9].SetActive(true);
                modelsActive[i + 9] = true;

            }
            
        }
    }

    void CheckIfRowHasAPlatform()
    {
        //Top row  2, 1, 0
        if (modelsActive[20] == true || modelsActive[21] == true || modelsActive[22] == true || modelsActive[23] == true || modelsActive[24] == true)
        {
            GameMaster.gameMaster.rowsWithPlatforms[0] = true;
        }
        else
        {
            GameMaster.gameMaster.rowsWithPlatforms[0] = false;
        }
            
        if (modelsActive[0] == true || modelsActive[1] == true || modelsActive[2] == true || modelsActive[9] == true || modelsActive[19] == true)
        {
            GameMaster.gameMaster.rowsWithPlatforms[1] = true;
        }
        else
        {
            GameMaster.gameMaster.rowsWithPlatforms[1] = false;
        }

        if (modelsActive[3] == true || modelsActive[4] == true || modelsActive[5] == true || modelsActive[10] == true || modelsActive[18] == true)
        {
            GameMaster.gameMaster.rowsWithPlatforms[2] = true;
        }
        else
        {
            GameMaster.gameMaster.rowsWithPlatforms[2] = false;
        }

        if (modelsActive[6] == true || modelsActive[7] == true || modelsActive[8] == true || modelsActive[11] == true || modelsActive[17] == true)
        {
            GameMaster.gameMaster.rowsWithPlatforms[3] = true;
        }
        else
        {
            GameMaster.gameMaster.rowsWithPlatforms[3] = false;
        }

        if (modelsActive[12] == true || modelsActive[13] == true || modelsActive[14] == true || modelsActive[15] == true || modelsActive[16] == true)
        {
            GameMaster.gameMaster.rowsWithPlatforms[4] = true;
        }
        else
        {
            GameMaster.gameMaster.rowsWithPlatforms[4] = false;
        }

        if (modelsActive[25] == true || modelsActive[26] == true || modelsActive[27] == true || modelsActive[28] == true || modelsActive[29] == true)
        {
            GameMaster.gameMaster.rowsWithPlatforms[5] = true;
        }
        else
        {
            GameMaster.gameMaster.rowsWithPlatforms[5] = false;
        }
    }

    IEnumerator DestroyCube()
    {
        List<int> listToChooseFrom = new List<int>();
            for (int i = 0; i < 35; i++)
            {
                if (modelsActive[i] == true)
                {
                    listToChooseFrom.Add(i);
                }
            }

        System.Random ran = new System.Random();
        int myNum = listToChooseFrom[ran.Next(listToChooseFrom.Count())];
        
                   

        Animator _anim = models[myNum].GetComponentInChildren<Animator>();
        _anim.Play("ShinyAcid");
        audioManager.PlaySound("Splat");


        //Begin function to handle cleaning window.
        //StartCoroutine(SpawnATriggerForAcidClean(models[myNum])); //Spawn a trigger collider over the tile with the acid
        GameObject triggerToDestroy;
        
        triggerToDestroy = SpawnATriggerForAcidClean(models[myNum]);


        //If player touches this collider, make a UI icon appear over the player's head
        //If player taps that UI icon before timer expires, remove acid.

        yield return new WaitForSeconds(1);
        if (GameMaster.gameMaster.acidWasCleaned == true)
        {
            GameMaster.gameMaster.acidIconIsOn = false;
            Destroy(triggerToDestroy);
        }
        yield return new WaitForSeconds(1);
        if (GameMaster.gameMaster.acidWasCleaned == true)
        {
            GameMaster.gameMaster.acidIconIsOn = false;
            Destroy(triggerToDestroy);
        }
        yield return new WaitForSeconds(1);
        if (GameMaster.gameMaster.acidWasCleaned == true)
        {
            GameMaster.gameMaster.acidIconIsOn = false;
            Destroy(triggerToDestroy);
        }
        yield return new WaitForSeconds(1);
        if (GameMaster.gameMaster.acidWasCleaned == true)
        {
            GameMaster.gameMaster.acidIconIsOn = false;
            Destroy(triggerToDestroy);
        }
     
        yield return new WaitForSeconds(1);
        if (GameMaster.gameMaster.acidWasCleaned == true)
        {
            GameMaster.gameMaster.acidIconIsOn = false;
            Destroy(triggerToDestroy);
        }

        if (GameMaster.gameMaster.acidWasCleaned == false)
        {
            modelsActive[myNum] = false;

            MeshRenderer _meshRenderer = models[myNum].GetComponentInChildren<MeshRenderer>();

            StartCoroutine(DestroyedBlinkingEffect(_meshRenderer, .1f, models[myNum]));

            Debug.Log("Destroying: " + models[myNum]);
            Destroy(_anim);

            GameMaster.gameMaster.acidIconIsOn = false;
            Destroy(triggerToDestroy);
        }
        else
        {
            //Play the cleaning animation.
            //modelsActive[myNum] = true;
            GameMaster.gameMaster.acidWasCleaned = false;
            Destroy(triggerToDestroy);
            //ScoreManager.scoreManager.pointsForSuccessfulClean += 5;
            //scoreManager.pointsForSuccessfulClean += 5;
            GameMaster.gameMaster.acidCleanUps += 5;
            Debug.Log("Successfully prevented platform from melting!");
          
        }


        float timeTilNextAcid = Random.Range(4, 9);
        yield return new WaitForSeconds(timeTilNextAcid);

        StartCoroutine("DestroyCube");

    }

    IEnumerator SpawnBolt()
    {
        
        List<int> listToChooseFrom = new List<int>();
        for (int i = 0; i < 35; i++)
        {
            if (modelsActive[i] == true)
            {
                listToChooseFrom.Add(i);
            }
        }

        System.Random ran = new System.Random();
        int myNum = listToChooseFrom[ran.Next(listToChooseFrom.Count())];

        GameObject boltToSpawn;

        boltToSpawn = SpawnBoltAtPosition(models[myNum]);

        float nextBoltSpawnTime = Random.Range(20, 26);
        yield return new WaitForSeconds(nextBoltSpawnTime);
        StartCoroutine(SpawnBolt());

    }

    private GameObject SpawnATriggerForAcidClean(GameObject objectToDisable)
    {
        //Instantiate a trigger at the platform.
        GameObject acidHitBox = Instantiate(Resources.Load("Misc/AcidTrigger"), new Vector3(objectToDisable.transform.position.x, objectToDisable.transform.position.y, objectToDisable.transform.position.z), Quaternion.Euler(0, 0, 0)) as GameObject;
        acidHitBox.transform.parent = objectToDisable.transform;


        //yield return new WaitForSeconds(5);
        //GameMaster.gameMaster.acidIconIsOn = false;
        //Destroy(acidHitBox);
        return acidHitBox;

    }

    private GameObject SpawnBoltAtPosition(GameObject objectWhereBoltWillSpawn)
    {
        //Instantiate a trigger at the platform.
        GameObject bolt = Instantiate(Resources.Load("Misc/BoltPickUp"), new Vector3(objectWhereBoltWillSpawn.transform.position.x, objectWhereBoltWillSpawn.transform.position.y + .5f, objectWhereBoltWillSpawn.transform.position.z), Quaternion.Euler(0, 0, 0)) as GameObject;
        bolt.transform.parent = objectWhereBoltWillSpawn.transform;


        //yield return new WaitForSeconds(5);
        //GameMaster.gameMaster.acidIconIsOn = false;
        //Destroy(acidHitBox);
        return bolt;

    }

    IEnumerator DestroyedBlinkingEffect(MeshRenderer meshRenderer, float blinkTime, GameObject objectToDisable)
    {
        for (int i = 0; i < 5; i++)
        {
            meshRenderer.enabled = true;
            yield return new WaitForSeconds(blinkTime);
            meshRenderer.enabled = false;
            yield return new WaitForSeconds(blinkTime);
        }
        
        objectToDisable.SetActive(false);
        CheckIfRowHasAPlatform();
    }


    private void Update()
    {
        if (timeToClean == true)
        {
            //timeToClean = false;
            
            countdownTimer = 5f;
            timer += Time.deltaTime;
            if (countdownTimer >= timer)
            {
                
                //failed to clean
            }

            


        }
    }
}
