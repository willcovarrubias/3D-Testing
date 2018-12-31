using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject difficultyManagerObject;
    DifficultyManager difficultyManagerScript;

    AudioManager audioManager;
    public Transform firePoint;
    bool startedFiring = false;

    // Use this for initialization
    void Start () {

        audioManager = AudioManager.instance;

        difficultyManagerObject = GameObject.FindGameObjectWithTag("GameController");
        difficultyManagerScript = difficultyManagerObject.GetComponent<DifficultyManager>();
	}
	
	// Update is called once per frame
	void Update () {
        //TODO: change to the real phase value;
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase5 && !startedFiring && !difficultyManagerScript.gameIsTransitioning) 
        {
            startedFiring = true;
            StartCoroutine(Shoot());

        }
	}
    
    IEnumerator Shoot()
    {
        
        if (GameMaster.gameMaster.currentPhase == GameMaster.CurrentPhase.Phase5)
        {
            float fireRate = Random.Range(0, 1f);
            Instantiate(Resources.Load("Projectiles/MuzzleFlash"), new Vector3(firePoint.position.x, firePoint.position.y, firePoint.position.z + 2f), Quaternion.Euler(0, 0, 0));

            Instantiate(Resources.Load("Projectiles/Projectile002"), new Vector3(firePoint.position.x, firePoint.position.y, firePoint.position.z), Quaternion.Euler(0, 0, 0));
            audioManager.PlaySound("Cannon");
            yield return new WaitForSeconds(fireRate);
        
            StartCoroutine(Shoot());
        }
        
    }
}
